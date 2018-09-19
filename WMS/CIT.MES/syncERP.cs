using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CIT.Wcf.Utils;
using CIT.Interface;
using System.Threading;
using System.Configuration;
using CIT.Client;

namespace CIT.MES
{
    class syncERP
    {
        UserContext uContext_mes = new UserContext();
        UserContext uContext_erp = new UserContext();
        public void JinHuo(string POCode, string user)
        {
            uContext_mes.Account = ConfigurationManager.AppSettings["mesact"].ToString();
            uContext_erp.Account = ConfigurationManager.AppSettings["erpact"].ToString();

            StringBuilder str = new StringBuilder();
            str.Append("<?xml version=\"1.0\" encoding=\"GB2312\"?>");
            str.Append("<!DOCTYPE SC[<!ENTITY stdd \"&amp;stdd;\">]>");
            str.Append("<STD_IN Origin=\"EB\">");
            str.Append("<Service Name=\"SetData\">");
            str.Append("<ServiceId />");
            str.Append("<User>PMES</User>");
            str.Append("<Factory>" + ConfigurationManager.AppSettings["yifeifactory"].ToString() + "</Factory>");
            str.Append("<Operate>ADJUST</Operate>");
            str.Append("<ObjectID>SET_PURTH</ObjectID>");
            str.Append("<Data>");
            str.Append("<DataSet Field=\"TG001|TG003|TG005|TG007|TH009|TH011C|TH004|TH015|TH072|TH017\">" + Environment.NewLine);
            DataTable dt = NMS.QueryDataTable(uContext_mes, "    select * from SfcDatERPJHinfo where  status='0' and POCode= '" + POCode + "' ORDER BY CREATETIME ");
            List<string> list = new List<string>();
            try
            {
                //数据汇总
                DataTable dts = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["fguid"].ToString());
                    DataRow[] dr = dts.Select(" partnumber='" + dt.Rows[i]["partnumber"].ToString() + "'");
                    if (dr.Length == 0)
                    {
                        DataRow _dr = dts.NewRow();
                        _dr["pocode"] = dt.Rows[i]["pocode"].ToString();
                        _dr["partnumber"] = dt.Rows[i]["partnumber"].ToString();
                        _dr["sqty"] = dt.Rows[i]["sqty"].ToString();
                        _dr["nqty"] = dt.Rows[i]["nqty"].ToString();
                        _dr["FGUID"] = dt.Rows[i]["FGUID"].ToString();
                        dts.Rows.Add(_dr);
                    }
                    else
                    {
                        foreach (var item in dr)
                        {
                            string sqty = "";
                            if (item["sqty"] == null)
                                sqty = "0";
                            else if (item["sqty"].ToString().Length == 0)
                                sqty = "0";
                            else
                                sqty = item["sqty"].ToString();

                            string nqty = "";
                            if (item["nqty"] == null)
                                nqty = "0";
                            else if (item["nqty"].ToString().Length == 0)
                                nqty = "0";
                            else
                                nqty = item["nqty"].ToString();
                            item["sqty"] = Convert.ToDecimal(sqty) + Convert.ToDecimal(dt.Rows[i]["sqty"].ToString());
                            item["nqty"] = Convert.ToDecimal(nqty) + Convert.ToDecimal(dt.Rows[i]["nqty"].ToString());
                        }
                    }
                }
                dt = dts;
                string wocode = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //根据品号获取仓库信息
                    string partbumber = dt.Rows[i]["partnumber"].ToString().Replace(" ", "");
                    DataTable dt_pn = NMS.QueryDataTable(uContext_erp, "select top 1 * from INVMB_V where MB001='" + partbumber + "'");


                    if (dt_pn.Rows.Count > 0)
                    {
                        #region  料号转换 nancy 2017.08.01
                        if (PubUtils.IsErpPartNumberReplace())
                            partbumber = dt_pn.Rows[0]["MB080"].ToString().Trim();
                        #endregion
                        string housecode = dt_pn.Rows[0]["MB007"].ToString().Replace(" ", "");
                        string db = dt.Rows[i]["pocode"].ToString().Substring(0, 4);
                        string ds = dt.Rows[i]["pocode"].ToString().Remove(0, 4);
                        ds = ds.Remove(ds.Length - 4, 4);
                        string dw = dt.Rows[i]["pocode"].ToString().Substring(dt.Rows[i]["pocode"].ToString().Length - 4, 4);
                        wocode = db + ds + dw;
                        //根据PO获取供应商信息
                        DataTable dt_supplier = NMS.QueryDataTable(uContext_erp, "select top 1 * from PURTC_V where TC001='" + dt.Rows[i]["pocode"].ToString().Replace(" ", "") + "'");
                        if (dt_supplier.Rows.Count > 0)
                        {
                            string supplier = dt_supplier.Rows[0]["TC002"].ToString().Replace(" ", "");
                            string bz = "";
                            DataTable dt_bz = NMS.QueryDataTable(uContext_erp, "select top 1 * from PURTC_V where TC001='" + dt.Rows[i]["pocode"].ToString().Replace(" ", "") + "' AND TC004='" + partbumber + "'");
                            if (dt_bz.Rows.Count > 0)
                            {
                                bz = dt_bz.Rows[0]["TC010"].ToString();
                            }

                            //获取库位 根据品号信息
                            string locationID = dt_pn.Rows[0]["MB008"].ToString().Replace(" ", "");
                            DataTable dt_jh = NMS.QueryDataTable(uContext_mes, "select val1 from SysDatConfig where key1='erp' and key2='yf' and key3='jh'");

                            if (dt_jh.Rows.Count > 0 && dt_jh.Rows[0][0] != null && dt_jh.Rows[0][0].ToString().Length != 0)
                                str.Append("<Row Data=\"" + dt_jh.Rows[0][0].ToString() + "|" + DateTime.Now.ToString("yyyyMMdd") + "|" + supplier + "|" + bz + "|" + housecode + "|" + db + "-" + ds + "-" + dw + "|" + partbumber + "|" + dt.Rows[i]["SQTY"].ToString() + "|" + locationID + "|" + dt.Rows[i]["NQTY"].ToString() + "\"/> " + Environment.NewLine);
                            else
                                str.Append("<Row Data=\"3401|" + DateTime.Now.ToString("yyyyMMdd") + "|" + supplier + "|" + bz + "|" + housecode + "|" + db + "-" + ds + "-" + dw + "|" + partbumber + "|" + dt.Rows[i]["SQTY"].ToString() + "|" + locationID + "|" + dt.Rows[i]["NQTY"].ToString() + "\"/> " + Environment.NewLine);
                        }
                        else
                        {
                            StringBuilder strlog = new StringBuilder();
                            strlog.Append(" insert into SfcdaterpLog (ID,Name,type,EventName,WO,PN,qty,Fnote,Creator,Createtime) ");
                            strlog.Append(" values('SET_PURTH','自供料进货','0','','" + db + ds + dw + "','" + partbumber + "','" + dt.Rows[i]["SQTY"].ToString().Split('.')[0] + "','无货位信息','mes',getdate())");
                            NMS.ExecTransql(uContext_mes, strlog.ToString());
                            string sql_temp = "update SfcDatERPJHinfo set status='2' where partnumber='" + partbumber + "' and status='0'";
                            NMS.ExecTransql(uContext_mes, sql_temp);
                            Utils.AddLog("无货位信息$$$$$$$$$$$$$$$ " + partbumber);
                            MsgBox.Error("无货位信息$$$$$$$$$$$$$$$ " + partbumber);
                        }
                    }
                }
                /*<Row Data="3401|20161009|2002|01|330-20161009001-0002|110100950|20|##########|0"/> */
                str.Append(@" </DataSet>
                    </Data>
                    </Service>
                    </STD_IN>");
                if (list.Count > 0)
                {
                    Utils.AddLog("进货发送数据-" + str.ToString());
                    string resutl = yifei.YiFeiGatewayEx(str.ToString());
                    if (resutl.ToLower().Contains("<status>0</status>"))
                    {
                        //更新数据
                        for (int i = 0; i < list.Count; i++)
                        {
                            //
                            bool flag = NMS.ExecTransql(uContext_mes, "update SfcDatERPJHinfo set Status='1',Updatetime=GETDATE(),updator='" + user + "' where FGUID='" + list[i] + "' and status='0' ");
                            if (!flag)
                            {
                                Utils.AddLog("进货单更新失败" + DateTime.Now.ToString());
                                MsgBox.Error("进货单更新失败" + DateTime.Now.ToString());

                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            NMS.ExecTransql(uContext_mes, "update SfcDatERPJHinfo set Status='2',Updatetime=GETDATE(),updator='" + user + "' where FGUID='" + list[i] + "' and status='0' ");
                        }

                        //ERP接口提交失败
                        StringBuilder strlog = new StringBuilder();
                        strlog.Append(" insert into SfcdaterpLog (ID,Name,type,EventName,WO,PN,qty,Fnote,Creator,Createtime) ");
                        strlog.Append(" values('SET_PURTH','自供料进货','1','','" + str.ToString() + "','','0','ERP接口提交信息失败:" + resutl + "','mes',getdate())");
                        NMS.ExecTransql(uContext_mes, strlog.ToString());

                    }
                    Utils.AddLog("接收数据-" + resutl);
                }
            }
            catch
            {
                //更新数据
                StringBuilder _str = new StringBuilder();
                for (int i = 0; i < list.Count; i++)
                {
                    //
                    _str.Append(" update SfcDatERPJHinfo set Status='2',Updatetime=GETDATE() where FGUID='" + list[i] + "' ");
                }
                bool flag = NMS.ExecTransql(uContext_mes, _str.ToString());
                if (!flag)
                {
                    Utils.AddLog("进货单更新失败" + DateTime.Now.ToString());
                }
            }
        }
        public void JinHuo(string POCode, string ph, string user)
        {
            uContext_mes.Account = ConfigurationManager.AppSettings["mesact"].ToString();
            uContext_erp.Account = ConfigurationManager.AppSettings["erpact"].ToString();

            StringBuilder str = new StringBuilder();
            str.Append("<?xml version=\"1.0\" encoding=\"GB2312\"?>");
            str.Append("<!DOCTYPE SC[<!ENTITY stdd \"&amp;stdd;\">]>");
            str.Append("<STD_IN Origin=\"EB\">");
            str.Append("<Service Name=\"SetData\">");
            str.Append("<ServiceId />");
            str.Append("<User>PMES</User>");
            str.Append("<Factory>" + ConfigurationManager.AppSettings["yifeifactory"].ToString() + "</Factory>");
            str.Append("<Operate>ADJUST</Operate>");
            str.Append("<ObjectID>SET_PURTH</ObjectID>");
            str.Append("<Data>");
            str.Append("<DataSet Field=\"TG001|TG003|TG005|TG007|TH009|TH011C|TH004|TH015|TH072|TH017\">" + Environment.NewLine);
            DataTable dt = NMS.QueryDataTable(uContext_mes, "    select * from SfcDatERPJHinfo where  (status='2' or (status='1' and creator='syserror')) and POCode= '" + POCode + "' and ph='" + ph + "' ORDER BY CREATETIME ");
            List<string> list = new List<string>();
            try
            {
                //数据汇总
                DataTable dts = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["fguid"].ToString());
                    DataRow[] dr = dts.Select(" partnumber='" + dt.Rows[i]["partnumber"].ToString() + "'");
                    if (dr.Length == 0)
                    {
                        DataRow _dr = dts.NewRow();
                        _dr["pocode"] = dt.Rows[i]["pocode"].ToString();
                        _dr["partnumber"] = dt.Rows[i]["partnumber"].ToString();
                        _dr["sqty"] = dt.Rows[i]["sqty"].ToString();
                        _dr["nqty"] = dt.Rows[i]["nqty"].ToString();
                        _dr["FGUID"] = dt.Rows[i]["FGUID"].ToString();
                        dts.Rows.Add(_dr);
                    }
                    else
                    {
                        foreach (var item in dr)
                        {
                            string sqty = "";
                            if (item["sqty"] == null)
                                sqty = "0";
                            else if (item["sqty"].ToString().Length == 0)
                                sqty = "0";
                            else
                                sqty = item["sqty"].ToString();

                            string nqty = "";
                            if (item["nqty"] == null)
                                nqty = "0";
                            else if (item["nqty"].ToString().Length == 0)
                                nqty = "0";
                            else
                                nqty = item["nqty"].ToString();
                            item["sqty"] = Convert.ToDecimal(sqty) + Convert.ToDecimal(dt.Rows[i]["sqty"].ToString());
                            item["nqty"] = Convert.ToDecimal(nqty) + Convert.ToDecimal(dt.Rows[i]["nqty"].ToString());
                        }
                    }
                }
                dt = dts;
                string wocode = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //根据品号获取仓库信息
                    string partbumber = dt.Rows[i]["partnumber"].ToString().Replace(" ", "");
                    DataTable dt_pn = NMS.QueryDataTable(uContext_erp, "select top 1 * from INVMB_V where MB001='" + partbumber + "'");


                    if (dt_pn.Rows.Count > 0)
                    {
                        string housecode = dt_pn.Rows[0]["MB007"].ToString().Replace(" ", "");
                        string db = dt.Rows[i]["pocode"].ToString().Substring(0, 4);
                        string ds = dt.Rows[i]["pocode"].ToString().Remove(0, 4);
                        ds = ds.Remove(ds.Length - 4, 4);
                        string dw = dt.Rows[i]["pocode"].ToString().Substring(dt.Rows[i]["pocode"].ToString().Length - 4, 4);
                        wocode = db + ds + dw;
                        //根据PO获取供应商信息
                        DataTable dt_supplier = NMS.QueryDataTable(uContext_erp, "select top 1 * from PURTC_V where TC001='" + dt.Rows[i]["pocode"].ToString().Replace(" ", "") + "'");
                        if (dt_supplier.Rows.Count > 0)
                        {
                            string supplier = dt_supplier.Rows[0]["TC002"].ToString().Replace(" ", "");
                            string bz = "";
                            DataTable dt_bz = NMS.QueryDataTable(uContext_erp, "select top 1 * from PURTC_V where TC001='" + dt.Rows[i]["pocode"].ToString().Replace(" ", "") + "' AND TC004='" + partbumber + "'");
                            if (dt_bz.Rows.Count > 0)
                            {
                                bz = dt_bz.Rows[0]["TC010"].ToString();
                            }

                            //获取库位 根据品号信息
                            string locationID = dt_pn.Rows[0]["MB008"].ToString().Replace(" ", "");
                            DataTable dt_jh = NMS.QueryDataTable(uContext_mes, "select val1 from SysDatConfig where key1='erp' and key2='yf' and key3='jh'");

                            if (dt_jh.Rows.Count > 0 && dt_jh.Rows[0][0] != null && dt_jh.Rows[0][0].ToString().Length != 0)
                                str.Append("<Row Data=\"" + dt_jh.Rows[0][0].ToString() + "|" + DateTime.Now.ToString("yyyyMMdd") + "|" + supplier + "|" + bz + "|" + housecode + "|" + db + "-" + ds + "-" + dw + "|" + partbumber + "|" + dt.Rows[i]["SQTY"].ToString() + "|" + locationID + "|" + dt.Rows[i]["NQTY"].ToString() + "\"/> " + Environment.NewLine);
                            else
                                str.Append("<Row Data=\"3401|" + DateTime.Now.ToString("yyyyMMdd") + "|" + supplier + "|" + bz + "|" + housecode + "|" + db + "-" + ds + "-" + dw + "|" + partbumber + "|" + dt.Rows[i]["SQTY"].ToString() + "|" + locationID + "|" + dt.Rows[i]["NQTY"].ToString() + "\"/> " + Environment.NewLine);
                        }
                        else
                        {
                            StringBuilder strlog = new StringBuilder();
                            strlog.Append(" insert into SfcdaterpLog (ID,Name,type,EventName,WO,PN,qty,Fnote,Creator,Createtime) ");
                            strlog.Append(" values('SET_PURTH','自供料进货','0','','" + db + ds + dw + "','" + partbumber + "','" + dt.Rows[i]["SQTY"].ToString().Split('.')[0] + "','无货位信息','mes',getdate())");
                            NMS.ExecTransql(uContext_mes, strlog.ToString());
                            Utils.AddLog("无货位信息$$$$$$$$$$$$$$$ " + partbumber);
                            MsgBox.Error("无货位信息$$$$$$$$$$$$$$$ " + partbumber);
                        }
                    }
                }
                /*<Row Data="3401|20161009|2002|01|330-20161009001-0002|110100950|20|##########|0"/> */
                str.Append(@" </DataSet>
                    </Data>
                    </Service>
                    </STD_IN>");
                if (list.Count > 0)
                {
                    Utils.AddLog("进货发送数据-" + str.ToString());
                    string resutl = yifei.YiFeiGatewayEx(str.ToString());
                    if (resutl.ToLower().Contains("<status>0</status>"))
                    {
                        //更新数据
                        for (int i = 0; i < list.Count; i++)
                        {
                            //
                            bool flag = NMS.ExecTransql(uContext_mes, "update SfcDatERPJHinfo set Status='1',Updatetime=GETDATE(),updator='" + user + "' where FGUID='" + list[i] + "' and status='0' ");
                            if (!flag)
                            {
                                Utils.AddLog("进货单更新失败" + DateTime.Now.ToString());
                                MsgBox.Error("进货单更新失败" + DateTime.Now.ToString());

                            }
                        }
                    }
                    else
                    {
                        //ERP接口提交失败
                        StringBuilder strlog = new StringBuilder();
                        strlog.Append(" insert into SfcdaterpLog (ID,Name,type,EventName,WO,PN,qty,Fnote,Creator,Createtime) ");
                        strlog.Append(" values('SET_PURTH','自供料进货','1','','" + str.ToString() + "','','0','ERP接口提交信息失败:" + resutl + "','mes',getdate())");
                        NMS.ExecTransql(uContext_mes, strlog.ToString());

                    }
                    Utils.AddLog("接收数据-" + resutl);
                }
            }
            catch
            {
                //更新数据
                StringBuilder _str = new StringBuilder();
                for (int i = 0; i < list.Count; i++)
                {
                    //
                    _str.Append(" update SfcDatERPJHinfo set Status='2',Updatetime=GETDATE() where FGUID='" + list[i] + "' ");
                }
                bool flag = NMS.ExecTransql(uContext_mes, _str.ToString());
                if (!flag)
                {
                    Utils.AddLog("进货单更新失败" + DateTime.Now.ToString());
                }
            }
        }

        public void KJinHuo(string mespo, string user)
        {
            uContext_mes.Account = ConfigurationManager.AppSettings["mesact"].ToString();
            uContext_erp.Account = ConfigurationManager.AppSettings["erpact"].ToString();

            StringBuilder str = new StringBuilder();
            str.Append("<?xml version=\"1.0\" encoding=\"GB2312\"?>");
            str.Append("<!DOCTYPE SC[<!ENTITY stdd \"&amp;stdd;\">]>");
            str.Append("<STD_IN Origin=\"EB\">");
            str.Append("<Service Name=\"SetData\">");
            str.Append("<ServiceId />");
            str.Append("<User>PMES</User>");
            str.Append("<Factory>" + ConfigurationManager.AppSettings["yifeifactory"].ToString() + "</Factory>");
            str.Append("<Operate>ADJUST</Operate>");
            str.Append("<ObjectID>set_INVI05</ObjectID>");
            str.Append("<Data>");
            str.Append("<DataSet Field=\"TA001|TA005|TB004|TB007|TB012|TB029\">" + Environment.NewLine);
            DataTable dt = NMS.QueryDataTable(uContext_mes, "   SELECT * FROM SfcDatERPKJHinfo WHERE status='0' and mespo = '" + mespo + "' order by Createtime ");
            List<string> list = new List<string>();
            try
            {
                //数据汇总
                DataTable dts = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["fguid"].ToString());
                    DataRow[] dr = dts.Select(" ph='" + dt.Rows[i]["ph"].ToString() + "'");
                    if (dr.Length == 0)
                    {
                        DataRow _dr = dts.NewRow();
                        _dr["mespo"] = dt.Rows[i]["mespo"].ToString();
                        _dr["db"] = dt.Rows[i]["db"].ToString();
                        _dr["ph"] = dt.Rows[i]["ph"].ToString();
                        _dr["qty"] = dt.Rows[i]["qty"].ToString();
                        _dr["FGUID"] = dt.Rows[i]["FGUID"].ToString();
                        dts.Rows.Add(_dr);
                    }
                    else
                    {
                        foreach (var item in dr)
                        {
                            string sqty = "";
                            if (item["qty"] == null)
                                sqty = "0";
                            else if (item["qty"].ToString().Length == 0)
                                sqty = "0";
                            else
                                sqty = item["qty"].ToString();
                            item["qty"] = Convert.ToDecimal(sqty) + Convert.ToDecimal(dt.Rows[i]["qty"].ToString());
                        }
                    }
                }
                dt = dts;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //根据品号获取仓库信息
                    string partbumber = dt.Rows[i]["ph"].ToString().Replace(" ", "");
                    DataTable dt_pn = NMS.QueryDataTable(uContext_erp, "select top 1 * from INVMB_V where MB001='" + partbumber + "'");

                    if (dt_pn.Rows.Count > 0)
                    {
                        #region  料号转换 nancy 2017.08.01
                        if (PubUtils.IsErpPartNumberReplace())
                            partbumber = dt_pn.Rows[0]["MB080"].ToString();
                        #endregion
                        //主要仓库
                        string housecode = dt_pn.Rows[0]["MB007"].ToString();
                        //获取库位 根据品号信息
                        string locationID = dt_pn.Rows[0]["MB008"].ToString();
                        str.Append("<Row Data=\"" + dt.Rows[i]["db"].ToString().ToUpper() + "|" + dt.Rows[i]["mespo"].ToString().ToUpper() + "|" + dt.Rows[i]["ph"].ToString() + "|" + dt.Rows[i]["qty"].ToString() + "|" + housecode.Replace(" ", "") + "|" + locationID.Replace(" ", "") + "\"/> " + Environment.NewLine);
                    }
                    else
                    {
                        StringBuilder strlog = new StringBuilder();
                        strlog.Append(" insert into SfcdaterpLog (ID,Name,type,EventName,WO,PN,qty,Fnote,Creator,Createtime) ");
                        strlog.Append(" values('set_INVI05','客供料进货','0','','" + dt.Rows[i]["mespo"].ToString() + "','" + dt.Rows[i]["ph"].ToString() + "','" + dt.Rows[i]["qty"].ToString().Split('.')[0] + "','无货位信息','mes',getdate())");
                        NMS.ExecTransql(uContext_mes, strlog.ToString());
                        string sql_temp = "update SfcDatERPKJHinfo set status='2' where ph='" + partbumber + "' and status='0'";
                        NMS.ExecTransql(uContext_mes, sql_temp);

                        Utils.AddLog("无货位信息$$$$$$$$$$$$$$$" + partbumber);
                        MsgBox.Error("无货位信息$$$$$$$$$$$$$$$" + partbumber);

                        return;
                    }
                }
                str.Append(@" </DataSet>
                    </Data>
                    </Service>
                    </STD_IN>");
                if (list.Count > 0)
                {
                    Utils.AddLog("客供料入库=>发送数据-" + str.ToString());
                    string resutl = yifei.YiFeiGatewayEx(str.ToString());
                    if (resutl.ToLower().Contains("<status>0</status>"))
                    {
                        //更新数据
                        for (int i = 0; i < list.Count; i++)
                        {
                            //
                            bool flag = NMS.ExecTransql(uContext_mes, "update SfcDatERPkJHinfo set Status='1',Updatetime=GETDATE(),updator='" + user + "' where FGUID='" + list[i] + "' and status='0' ");
                            if (!flag)
                            {
                                Utils.AddLog("客供料入库=>进货单更新失败" + DateTime.Now.ToString());
                            }
                        }
                    }
                    else
                    {
                        //ERP接口提交失败
                        StringBuilder strlog = new StringBuilder();
                        strlog.Append(" insert into SfcdaterpLog (ID,Name,type,EventName,WO,PN,qty,Fnote,Creator,Createtime) ");
                        strlog.Append(" values('set_INVI05','客供料进货','1','" + str.ToString() + "','','','0','ERP接口提交信息失败:" + resutl + "','mes',getdate())");
                        NMS.ExecTransql(uContext_mes, strlog.ToString());

                    }
                    Utils.AddLog("客供料入库=>接收数据-" + resutl);
                }
            }
            catch
            {
                //更新数据
                StringBuilder _str = new StringBuilder();
                for (int i = 0; i < list.Count; i++)
                {
                    //
                    _str.Append(" update SfcDatERPJHinfo set Status='2',Updatetime=GETDATE() where FGUID='" + list[i] + "' and status='0' ");
                }
                bool flag = NMS.ExecTransql(uContext_mes, _str.ToString());
                if (!flag)
                {
                    Utils.AddLog("客供料入库=>进货单更新失败" + DateTime.Now.ToString());
                }
            }
        }

        //发送消息到服务器
        public void DiaoBo(string WOcode, string user)
        {
            uContext_mes.Account = ConfigurationManager.AppSettings["mesact"].ToString();
            uContext_erp.Account = ConfigurationManager.AppSettings["erpact"].ToString();

            StringBuilder str = new StringBuilder();
            str.Append(@"<?xml version=""1.0"" encoding=""GB2312""?>
                        <!DOCTYPE SC[<!ENTITY stdd ""&amp;stdd;"">]>
                        <STD_IN Origin=""EB"">
                            <Service Name=""SetData"">
                            <ServiceId /> 
                            <User>PMES</User>                           
                            <Factory>" + ConfigurationManager.AppSettings["yifeifactory"].ToString() + @"</Factory>  
                            <Operate>ADJUST</Operate>      
                            <ObjectID>SET_INVI08</ObjectID>  
                            <Data>
                                <DataSet Field=""TA001|TA003|TA008|TA004|TB012|TB013|TB004|TB007|TB029|TB017"">");
            //DataTable dt = NMS.QueryDataTable(uContext_mes, "select TOP 200 * from SfcDatERPDBinfo where status='0' AND WOCODE=(SELECT TOP 1 WOcode from SfcDatERPDBinfo where Status='0' order by Createtime ) order by createtime ");
            DataTable dt = NMS.QueryDataTable(uContext_mes, "select * from SfcDatERPDBinfo where status='0' AND WOCODE='" + WOcode + "' order by createtime ");
            if (dt.Rows.Count > 0)
            {
                //StringBuilder strFlag = new StringBuilder();
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    strFlag.Append(" update SfcDatERPDBinfo set Status='1',Updatetime=GETDATE() where FGUID='" + dt.Rows[i]["fguid"].ToString() + "' ");
                //}
                //bool _flag = new CIT.BLL.LocalDBHelper().ExecTransSql(acctConnection, strFlag.ToString());
                //if (_flag)
                {
                    List<string> list = new List<string>();
                    DataTable dts = dt.Clone();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        list.Add(dt.Rows[i]["FGUID"].ToString());
                        DataRow[] dr = dts.Select(" ph='" + dt.Rows[i]["ph"].ToString() + "'");
                        if (dr.Length == 0)
                        {
                            DataRow _dr = dts.NewRow();
                            _dr["wocode"] = dt.Rows[i]["wocode"].ToString();
                            _dr["ph"] = dt.Rows[i]["ph"].ToString();
                            _dr["BM"] = dt.Rows[i]["BM"].ToString();
                            _dr["GCBH"] = dt.Rows[i]["GCBH"].ToString();
                            _dr["SL"] = dt.Rows[i]["SL"].ToString();
                            _dr["FGUID"] = dt.Rows[i]["FGUID"].ToString();
                            _dr["DW"] = dt.Rows[i]["DW"].ToString();
                            dts.Rows.Add(_dr);
                        }
                        else
                        {
                            foreach (var item in dr)
                            {
                                item["SL"] = Convert.ToDecimal(item["SL"]) + Convert.ToDecimal(dt.Rows[i]["SL"].ToString());
                            }
                        }

                    }
                    dt = dts;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //根据品号获取仓库信息
                        string partbumber = dt.Rows[i]["ph"].ToString().Replace(" ", "");
                        DataTable dt_pn = NMS.QueryDataTable(uContext_erp, "select top 1 A.*,B.MC002 from INVMB_V A INNER JOIN INVMC_V B ON A.MB007=B.MC001 where MB001='" + partbumber + "'");
                        if (dt_pn.Rows.Count > 0)
                        {
                            string ZCC = dt_pn.Rows[0]["MB007"].ToString().Replace(" ", "");
                            string zigoukegong = dt_pn.Rows[0]["MC002"].ToString().Replace(" ", "");
                            //当为false时 自购 当为true 客供
                            bool Flag = false;
                            //string ZCC = "";
                            if (zigoukegong.Contains("自购"))
                            {
                                Flag = true;
                            }
                            else
                            {
                                Flag = false;
                            }

                            //根据工单号获取工作中心然后写入转入仓
                            string wocode = dt.Rows[i]["wocode"].ToString().Replace(" ", "");
                            DataTable dt_pocode = NMS.QueryDataTable(uContext_erp, "select * from MOCTA_V where TA001='" + wocode + "'");
                            if (dt_pocode.Rows.Count > 0)
                            {
                                //根据工单获取工作中心，然后根据物料区分自购和客供料
                                string workstation = dt_pocode.Rows[0]["TA011"].ToString().Replace(" ", "");
                                DataTable dt_zrc = NMS.QueryDataTable(uContext_erp, "select * from INVMC_V where MC004 ='" + workstation + "'");
                                string ZRC = "";
                                for (int v = 0; v < dt_zrc.Rows.Count; v++)
                                {
                                    if (Flag)
                                    {
                                        if (dt_zrc.Rows[v]["MC002"].ToString().Contains("自购"))
                                        {
                                            ZRC = dt_zrc.Rows[v]["MC001"].ToString().Replace(" ", "");
                                        }
                                    }
                                    else
                                    {
                                        if (dt_zrc.Rows[v]["MC002"].ToString().Contains("客供"))
                                        {
                                            ZRC = dt_zrc.Rows[v]["MC001"].ToString().Replace(" ", "");
                                        }
                                    }
                                }
                                str.Append("<Row Data=\"1201|" + DateTime.Now.ToString("yyyyMMdd") + "|" + dt.Rows[i]["GCBH"].ToString().Replace(" ", "") + "|" +
                                    dt.Rows[i]["BM"].ToString().Replace(" ", "") + "|" + ZCC + "|" + ZRC + "|" + partbumber + "|" +
                                    dt.Rows[i]["SL"].ToString().Replace(" ", "") + "|" + dt_pn.Rows[0]["MB008"].ToString().Replace(" ", "") + "|" + wocode + "\"/> " + Environment.NewLine);
                            }
                        }
                        else
                        {
                            string sql_temp = "update SfcDatERPDBinfo set status='2' where ph='" + partbumber + "' and status='0'";
                            NMS.ExecTransql(uContext_mes, sql_temp);

                            Utils.AddLog("调拨无货位信息$$$$$$$$$$$$$$$" + partbumber);
                            MsgBox.Error("调拨无货位信息$$$$$$$$$$$$$$$" + partbumber);

                            StringBuilder strlog = new StringBuilder();
                            strlog.Append(" insert into SfcdaterpLog (ID,Name,type,EventName,WO,PN,qty,Fnote,Creator,Createtime) ");
                            strlog.Append(" values('SET_INVI08','原料仓调拨到线边仓','0','','" + dt.Rows[i]["wocode"].ToString().Replace(" ", "") + "','" + partbumber + "','" + dt.Rows[i]["SL"].ToString().Replace(" ", "").Split('.')[0] + "','无货位信息','mes',getdate())");
                            NMS.ExecTransql(uContext_mes, strlog.ToString());

                        }
                    }
                    str.Append(@"      </DataSet>
                        </Data>
                        </Service>
                        </STD_IN>");
                    if (list.Count > 0)
                    {
                        Utils.AddLog("物料调拨=>发送数据-" + str.ToString());
                        string resutl = yifei.YiFeiGatewayEx(str.ToString());
                        if (resutl.ToLower().Contains("<status>0</status>") || resutl.ToLower().Contains("<status>-1</status>"))
                        {
                            //更新数据
                            for (int i = 0; i < list.Count; i++)
                            {
                                //
                                bool flag = NMS.ExecTransql(uContext_mes, "update SfcDatERPDBinfo set Status='1',Updatetime=GETDATE(),updator='" + user + "' where FGUID='" + list[i] + "' and status='0' ");
                                if (!flag)
                                {
                                    Utils.AddLog("物料调拨=>调拨单更新失败" + DateTime.Now.ToString());
                                }
                            }
                            NMS.ExecTransql(uContext_mes,
                " insert into sysdatsyslog(eventname,op,[application],moudle,status,msg,fnote,creator,createtime)values('ERP同步','调拨','服务平台程序','ERP同步模块','成功','','" + resutl + "','sys',getdate()) ");
                        }
                        else
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                bool flag = NMS.ExecTransql(uContext_mes, "update SfcDatERPDBinfo set Status='2',Updatetime=GETDATE(),updator='" + user + "' where FGUID='" + list[i] + "' and status='0' ");
                            }

                            //ERP接口提交失败
                            StringBuilder strlog = new StringBuilder();
                            strlog.Append(" insert into SfcdaterpLog (ID,Name,type,EventName,WO,PN,qty,Fnote,Creator,Createtime) ");
                            strlog.Append(" values('SET_INVI08','原料仓调拨到线边仓','1','','" + str.ToString() + "','','0','ERP接口提交信息失败:" + resutl + "','mes',getdate())");
                            NMS.ExecTransql(uContext_mes, strlog.ToString());
                        }
                        Utils.AddLog("物料调拨=>接收数据-" + resutl);
                    }
                }
            }
        }

        public void DiaoBoToWms(string WOcode, string user)
        {
            try
            {
                uContext_mes.Account = ConfigurationManager.AppSettings["mesact"].ToString();
                uContext_erp.Account = ConfigurationManager.AppSettings["erpact"].ToString();

                StringBuilder str = new StringBuilder();
                str.Append(@"<?xml version=""1.0"" encoding=""GB2312""?>
                        <!DOCTYPE SC[<!ENTITY stdd ""&amp;stdd;"">]>
                        <STD_IN Origin=""EB"">
                            <Service Name=""SetData"">
                            <ServiceId /> 
                            <User>PMES</User>                           
                            <Factory>" + ConfigurationManager.AppSettings["yifeifactory"].ToString() + @"</Factory>  
                            <Operate>ADJUST</Operate>      
                            <ObjectID>SET_INVI08</ObjectID>  
                            <Data>
                                <DataSet Field=""TA001|TA003|TA008|TA004|TB012|TB013|TB004|TB007|TB029|TB017"">");
                DataTable dt = NMS.QueryDataTable(uContext_mes, "select * from SfcDatERPDBTOwmsinfo where status='0' AND WOCODE='" + WOcode + "' order by createtime ");
                if (dt.Rows.Count > 0)
                {
                    //StringBuilder strFlag = new StringBuilder();
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    strFlag.Append(" update SfcDatERPDBinfo set Status='1',Updatetime=GETDATE() where FGUID='" + dt.Rows[i]["fguid"].ToString() + "' ");
                    //}
                    //bool _flag = new CIT.BLL.LocalDBHelper().ExecTransSql(acctConnection, strFlag.ToString());
                    //if (_flag)
                    {
                        List<string> list = new List<string>();
                        DataTable dts = dt.Clone();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            list.Add(dt.Rows[i]["FGUID"].ToString());
                            DataRow[] dr = dts.Select(" ph='" + dt.Rows[i]["ph"].ToString() + "'");
                            if (dr.Length == 0)
                            {
                                DataRow _dr = dts.NewRow();
                                _dr["wocode"] = dt.Rows[i]["wocode"].ToString();
                                _dr["ph"] = dt.Rows[i]["ph"].ToString();
                                _dr["BM"] = dt.Rows[i]["BM"].ToString();
                                _dr["GCBH"] = dt.Rows[i]["GCBH"].ToString();
                                _dr["SL"] = dt.Rows[i]["SL"].ToString();
                                _dr["FGUID"] = dt.Rows[i]["FGUID"].ToString();
                                _dr["DW"] = dt.Rows[i]["DW"].ToString();
                                dts.Rows.Add(_dr);
                            }
                            else
                            {
                                foreach (var item in dr)
                                {
                                    item["SL"] = Convert.ToDecimal(item["SL"]) + Convert.ToDecimal(dt.Rows[i]["SL"].ToString());
                                }
                            }

                        }
                        dt = dts;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //根据品号获取仓库信息
                            string partbumber = dt.Rows[i]["ph"].ToString().Replace(" ", "");
                            DataTable dt_pn = NMS.QueryDataTable(uContext_erp, "select top 1 A.*,B.MC002 from INVMB_V A INNER JOIN INVMC_V B ON A.MB007=B.MC001 where MB001='" + partbumber + "'");
                            if (dt_pn.Rows.Count > 0)
                            {
                                string ZCC = dt_pn.Rows[0]["MB007"].ToString().Replace(" ", "");
                                string zigoukegong = dt_pn.Rows[0]["MC002"].ToString().Replace(" ", "");
                                //当为false时 自购 当为true 客供
                                bool Flag = false;
                                //string ZCC = "";
                                if (zigoukegong.Contains("自购"))
                                {
                                    Flag = true;
                                }
                                else
                                {
                                    Flag = false;
                                }

                                //根据工单号获取工作中心然后写入转入仓
                                string wocode = dt.Rows[i]["wocode"].ToString().Replace(" ", "");
                                DataTable dt_pocode = NMS.QueryDataTable(uContext_erp, "select * from MOCTA_V where TA001='" + wocode + "'");
                                if (dt_pocode.Rows.Count > 0)
                                {
                                    //根据工单获取工作中心，然后根据物料区分自购和客供料
                                    string workstation = dt_pocode.Rows[0]["TA011"].ToString().Replace(" ", "");
                                    DataTable dt_zrc = NMS.QueryDataTable(uContext_erp, "select * from INVMC_V where MC004 ='" + workstation + "'");
                                    string ZRC = "";
                                    for (int v = 0; v < dt_zrc.Rows.Count; v++)
                                    {
                                        if (Flag)
                                        {
                                            if (dt_zrc.Rows[v]["MC002"].ToString().Contains("自购"))
                                            {
                                                ZRC = dt_zrc.Rows[v]["MC001"].ToString().Replace(" ", "");
                                            }
                                        }
                                        else
                                        {
                                            if (dt_zrc.Rows[v]["MC002"].ToString().Contains("客供"))
                                            {
                                                ZRC = dt_zrc.Rows[v]["MC001"].ToString().Replace(" ", "");
                                            }
                                        }
                                    }
                                    str.Append("<Row Data=\"1201|" + DateTime.Now.ToString("yyyyMMdd") + "|" + dt.Rows[i]["GCBH"].ToString().Replace(" ", "") + "|" +
                                        dt.Rows[i]["BM"].ToString().Replace(" ", "") + "|" + ZRC + "|" + ZCC + "|" + partbumber + "|" +
                                        dt.Rows[i]["SL"].ToString().Replace(" ", "") + "|0|" + wocode + "\"/> " + Environment.NewLine);
                                }
                                else
                                {
                                    Utils.AddLog("无工单信息$$$$$$$$$$$$$$$" + wocode);
                                    MsgBox.Error("无工单信息$$$$$$$$$$$$$$$" + wocode);

                                }
                            }
                            else
                            {
                                StringBuilder strlog = new StringBuilder();
                                strlog.Append(" insert into SfcdaterpLog (ID,Name,type,EventName,WO,PN,qty,Fnote,Creator,Createtime) ");
                                strlog.Append(" values('SET_INVI08','线边仓调拨到原料仓','0','','" + dt.Rows[i]["wocode"].ToString().Replace(" ", "") + "','" + partbumber + "','" + dt.Rows[i]["SL"].ToString().Replace(" ", "").Split('.')[0] + "','无货位信息','mes',getdate())");
                                NMS.ExecTransql(uContext_mes, strlog.ToString());
                                string sql_temp = "update SfcDatERPDBTOwmsinfo set status='2' where ph='" + partbumber + "' and status='0'";
                                NMS.ExecTransql(uContext_mes, sql_temp);

                                Utils.AddLog("回调无货位信息$$$$$$$$$$$$$$$" + partbumber);
                                MsgBox.Error("回调无货位信息$$$$$$$$$$$$$$$" + partbumber);

                            }
                        }
                        str.Append(@"      </DataSet>
                        </Data>
                        </Service>
                        </STD_IN>");
                        if (list.Count > 0)
                        {
                            Utils.AddLog("物料调拨回主仓=>发送数据-" + str.ToString());
                            string resutl = yifei.YiFeiGatewayEx(str.ToString());
                            if (resutl.ToLower().Contains("<status>0</status>") || resutl.ToLower().Contains("<status>-1</status>"))
                            {
                                //更新数据
                                for (int i = 0; i < list.Count; i++)
                                {
                                    //
                                    bool flag = NMS.ExecTransql(uContext_mes, "update SfcDatERPDBTOwmsinfo set Status='1',Updatetime=GETDATE(),updator='" + user + "' where FGUID='" + list[i] + "' and status='0' ");
                                    if (!flag)
                                    {
                                        Utils.AddLog("物料调拨回主仓=>调拨单更新失败" + DateTime.Now.ToString());
                                    }
                                }
                                NMS.ExecTransql(uContext_mes,
                    " insert into sysdatsyslog(eventname,op,[application],moudle,status,msg,fnote,creator,createtime)values('ERP同步','调拨回仓库','服务平台程序','ERP同步模块','成功','','" + resutl + "','sys',getdate()) ");
                            }
                            else
                            {
                                for (int i = 0; i < list.Count; i++)
                                {
                                    NMS.ExecTransql(uContext_mes, "update SfcDatERPDBTOwmsinfo set Status='2',Updatetime=GETDATE(),updator='" + user + "' where FGUID='" + list[i] + "' and status='0' ");
                                }

                                //ERP接口提交失败
                                StringBuilder strlog = new StringBuilder();
                                strlog.Append(" insert into SfcdaterpLog (ID,Name,type,EventName,WO,PN,qty,Fnote,Creator,Createtime) ");
                                strlog.Append(" values('SET_INVI08','线边仓调拨到原料仓','1','" + str.ToString() + "','','0','ERP接口提交信息失败:" + resutl + "','mes',getdate())");
                                NMS.ExecTransql(uContext_mes, strlog.ToString());

                            }
                            Utils.AddLog("物料调拨回主仓=>接收数据-" + resutl);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MsgBox.Error(ee.Message);
            }
        }

        IYiFeiGatewayExservice yifei = new IYiFeiGatewayExservice();

        public void ChuKu(string user)
        {

            uContext_mes.Account = ConfigurationManager.AppSettings["mesact"].ToString();
            uContext_erp.Account = ConfigurationManager.AppSettings["erpact"].ToString();

            //            //先将数据同步到待同步的表中
            //            DataTable dt_chuku = new CIT.BLL.LocalDBHelper().Querydt(CIT.BLL.DBHelper.accList[cbx_sync_acct_mes.Text], "select top 100 * from PVS_Event_MaterialRecords order by ID");
            //            for (int i = 0; i < dt_chuku.Rows.Count; i++)
            //            {
            //                //逐行处理数据
            //                string sql = string.Format(@"insert into SfcDatERPLLinfo(FGUID,LTLDB,GC,PH,LTLSL,GDDBDH,Status,Creator,Createtime)
            //values(newid(),'5401','01','{0}','{1}','{2}','0','sys',getdate())  delete from PVS_Event_MaterialRecords where id='{3}'", dt_chuku.Rows[i]["partnumber"].ToString(), dt_chuku.Rows[i]["qty"].ToString(), dt_chuku.Rows[i]["WorkOrderNo"].ToString(), dt_chuku.Rows[i]["id"].ToString());
            //                new CIT.BLL.LocalDBHelper().ExecTransSql(CIT.BLL.DBHelper.accList[cbx_sync_acct_mes.Text], sql);
            //            }
            StringBuilder str = new StringBuilder();
            str.Append(@"<?xml version=""1.0"" encoding=""GB2312""?>
                    <!DOCTYPE SC[<!ENTITY stdd ""&amp;stdd;"">]>
                    <STD_IN Origin=""EB"">
                     <Service Name=""SetData"">
                      <ServiceId /> 
                      <User>PMES</User>                           
                      <Factory>" + ConfigurationManager.AppSettings["yifeifactory"].ToString() + @"</Factory>  
                      <Operate>ADJUST</Operate>      
                      <ObjectID>SET_MOCI03</ObjectID>  
                      <Data>
                           <DataSet Field=""TC001|TC003|TC004|TC005|TE008|TE004|TE005|TE011C"">");
            DataTable dt = NMS.QueryDataTable(uContext_mes, "select * from SfcDatERPLLinfo where status='0' and GDDBDH=(SELECT TOP 1 GDDBDH from SfcDatERPLLinfo where Status='0' and len(GDDBDH)>0 order by Createtime ) order by createtime ");
            List<string> list = new List<string>();


            //数据汇总
            DataTable dts = dt.Clone();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i]["fguid"].ToString());
                DataRow[] dr = dts.Select(" ph='" + dt.Rows[i]["ph"].ToString() + "'");
                if (dr.Length == 0)
                {
                    DataRow _dr = dts.NewRow();
                    _dr["GDDBDH"] = dt.Rows[i]["GDDBDH"].ToString();
                    _dr["ph"] = dt.Rows[i]["ph"].ToString();
                    _dr["LTLSL"] = dt.Rows[i]["LTLSL"].ToString();
                    _dr["LTLDB"] = dt.Rows[i]["LTLDB"].ToString();
                    _dr["GC"] = dt.Rows[i]["GC"].ToString();
                    _dr["FGUID"] = dt.Rows[i]["FGUID"].ToString();
                    dts.Rows.Add(_dr);
                }
                else
                {
                    foreach (var item in dr)
                    {
                        item["LTLSL"] = Convert.ToDecimal(item["LTLSL"]) + Convert.ToDecimal(dt.Rows[i]["LTLSL"].ToString());
                    }
                }
            }
            dt = dts;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //根据品号获取仓库信息
                string partbumber = dt.Rows[i]["ph"].ToString().Replace(" ", "");
                DataTable dt_pn = NMS.QueryDataTable(uContext_erp, "select top 1 A.*,B.MC002 from INVMB_V A INNER JOIN INVMC_V B ON A.MB007=B.MC001 where MB001='" + partbumber + "'");
                if (dt_pn.Rows.Count > 0)
                {
                    string ck = dt_pn.Rows[0]["MB007"].ToString();
                    string zigoukegong = dt_pn.Rows[0]["MC002"].ToString().Replace(" ", "");
                    //当为false时 自购 当为true 客供
                    bool Flag = false;
                    //string ZCC = "";
                    if (zigoukegong.Contains("自购"))
                    {
                        Flag = true;
                    }
                    else
                    {
                        Flag = false;
                    }
                    string wocode = dt.Rows[i]["GDDBDH"].ToString().Replace(" ", "");
                    DataTable dt_pocode = NMS.QueryDataTable(uContext_erp, "select * from MOCTA_V where TA001='" + wocode + "'");
                    if (dt_pocode.Rows.Count > 0)
                    {
                        string workstation = dt_pocode.Rows[0]["TA011"].ToString();
                        DataTable dt_zrc = NMS.QueryDataTable(uContext_erp, "select * from INVMC_V where MC004 ='" + workstation + "'");
                        string ZRC = "";
                        for (int v = 0; v < dt_zrc.Rows.Count; v++)
                        {
                            if (Flag)
                            {
                                if (dt_zrc.Rows[v]["MC002"].ToString().Contains("自购"))
                                {
                                    ZRC = dt_zrc.Rows[v]["MC001"].ToString().Replace(" ", "");
                                }
                            }
                            else
                            {
                                if (dt_zrc.Rows[v]["MC002"].ToString().Contains("客供"))
                                {
                                    ZRC = dt_zrc.Rows[v]["MC001"].ToString().Replace(" ", "");
                                }
                            }
                        }
                        //根据工作中获取线边仓仓库

                        if (Convert.ToInt32(dt.Rows[i]["LTLSL"].ToString().Replace(" ", "")) > -500)
                        {
                            str.Append("<Row Data=\"" + dt.Rows[i]["LTLDB"].ToString().Replace(" ", "") + "|" + DateTime.Now.ToString("yyyyMMdd") + "|" + dt.Rows[i]["gc"].ToString().Replace(" ", "") + "|" + workstation.Replace(" ", "") + "|" +
                              ZRC.Replace(" ", "") + "|" + partbumber.Replace(" ", "") + "|" + dt.Rows[i]["LTLSL"].ToString().Replace(" ", "") + "|" + dt.Rows[i]["GDDBDH"].ToString().Substring(0, 4) + "-" + dt.Rows[i]["GDDBDH"].ToString().Substring(4, 11) + "\"/> " + Environment.NewLine);
                        }
                    }
                }

            }

            str.Append(@"      </DataSet>
                        </Data>
                        </Service>
                        </STD_IN>");
            if (list.Count > 0)
            {
                Utils.AddLog("领料单=>发送数据-" + str.ToString());
                string resutl = yifei.YiFeiGatewayEx(str.ToString());
                if (resutl.ToLower().Contains("<status>0</status>"))
                {
                    StringBuilder strDel = new StringBuilder();
                    //更新数据
                    for (int i = 0; i < list.Count; i++)
                    {
                        //

                        //strDel.Append(" delete from SfcDatERPLLinfo  where FGUID='" + list[i] + "' ");
                        strDel.Append(" update SfcDatERPLLinfo set Status='1',Updatetime=GETDATE(),updator='" + user + "' where status='0' and FGUID='" + list[i] + "'  ");

                        if (list.Count - 1 == i)
                        {
                            strDel.Append(" delete from SfcDatERPLLinfo  where DATEDIFF (DAY,createtime,GETDATE())>2 and status='1' ");

                            NMS.ExecTransql(uContext_mes, strDel.ToString());
                            strDel.Clear();
                        }
                        else if (i % 100 == 0)
                        {
                            strDel.Append(" delete from SfcDatERPLLinfo  where DATEDIFF (DAY,createtime,GETDATE())>2 and status='1' ");

                            NMS.ExecTransql(uContext_mes, strDel.ToString());
                            strDel.Clear();
                        }
                    }
                    NMS.ExecTransql(uContext_mes, " delete from SfcDatERPLLinfo where len(GDDBDH)=0  insert into sysdatsyslog(eventname,op,[application],moudle,status,msg,fnote,creator,createtime)values('ERP同步','出库','服务平台程序','ERP同步模块','成功','','" + resutl + "','sys',getdate()) ");
                }
                else
                {

                    //ERP接口提交失败
                    StringBuilder strlog = new StringBuilder();
                    strlog.Append(" insert into SfcdaterpLog (ID,Name,type,EventName,WO,PN,qty,Fnote,Creator,Createtime) ");
                    strlog.Append(" values('SET_MOCI03','领料出库','1','','" + str.ToString() + "','','0','ERP接口提交信息失败:" + resutl + "','mes',getdate())");
                    NMS.ExecTransql(uContext_mes, strlog.ToString());

                    StringBuilder strupdate = new StringBuilder();
                    for (int i = 0; i < list.Count; i++)
                    {
                        strupdate.Append("update sfcdaterpllinfo set creator='error',status='1',updatetime=getdate() where fguid='" + list[i] + "' ");
                    }
                    NMS.ExecTransql(uContext_mes, strupdate.ToString());
                    Utils.AddLog("出库单ERP连接失败." + DateTime.Now.ToString());
                    NMS.ExecTransql(uContext_mes,
         "  insert into sysdatsyslog(eventname,op,[application],moudle,status,msg,fnote,creator,createtime)values('ERP同步','出库','服务平台程序','ERP同步模块','失败','" + str.ToString() + "','" + resutl + "','sys',getdate()) ");
                }
                Utils.AddLog("领料单=>接收数据-" + resutl.ToString());
            }
        }
        public void WoChuKu(string db, DataTable dt, string wocode, string user)
        {
            uContext_mes.Account = ConfigurationManager.AppSettings["mesact"].ToString();
            uContext_erp.Account = ConfigurationManager.AppSettings["erpact"].ToString();
            StringBuilder str = new StringBuilder();
            str.Append(@"<?xml version=""1.0"" encoding=""GB2312""?>
                    <!DOCTYPE SC[<!ENTITY stdd ""&amp;stdd;"">]>
                    <STD_IN Origin=""EB"">
                     <Service Name=""SetData"">
                      <ServiceId /> 
                      <User>PMES</User>                           
                      <Factory>" + ConfigurationManager.AppSettings["yifeifactory"].ToString() + @"</Factory>  
                      <Operate>ADJUST</Operate>      
                      <ObjectID>SET_MOCI03</ObjectID>  
                      <Data>
                           <DataSet Field=""TC001|TC003|TC004|TC005|TE008|TE004|TE005|TE011C"">");


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //根据品号获取仓库信息
                string partbumber = dt.Rows[i]["partnumber"].ToString().Replace(" ", "");
                DataTable dt_pn = NMS.QueryDataTable(uContext_erp, "select top 1 A.*,B.MC002 from INVMB_V A INNER JOIN INVMC_V B ON A.MB007=B.MC001 where MB001='" + partbumber + "'");
                if (dt_pn.Rows.Count > 0)
                {
                    string ck = dt_pn.Rows[0]["MB007"].ToString();
                    string zigoukegong = dt_pn.Rows[0]["MC002"].ToString().Replace(" ", "");
                    //当为false时 自购 当为true 客供
                    bool Flag = false;
                    //string ZCC = "";
                    if (zigoukegong.Contains("自购"))
                    {
                        Flag = true;
                    }
                    else
                    {
                        Flag = false;
                    }
                    DataTable dt_pocode = NMS.QueryDataTable(uContext_erp, "select * from MOCTA_V where TA001='" + wocode + "'");
                    if (dt_pocode.Rows.Count > 0)
                    {
                        string workstation = dt_pocode.Rows[0]["TA011"].ToString();
                        DataTable dt_zrc = NMS.QueryDataTable(uContext_erp, "select * from INVMC_V where MC004 ='" + workstation + "'");
                        string ZRC = "";
                        for (int v = 0; v < dt_zrc.Rows.Count; v++)
                        {
                            if (Flag)
                            {
                                if (dt_zrc.Rows[v]["MC002"].ToString().Contains("自购"))
                                {
                                    ZRC = dt_zrc.Rows[v]["MC001"].ToString().Replace(" ", "");
                                }
                            }
                            else
                            {
                                if (dt_zrc.Rows[v]["MC002"].ToString().Contains("客供"))
                                {
                                    ZRC = dt_zrc.Rows[v]["MC001"].ToString().Replace(" ", "");
                                }
                            }
                        }
                        //根据工作中获取线边仓仓库

                        if (Convert.ToDouble(dt.Rows[i]["qty"].ToString().Replace(" ", "")) > -500)
                        {
                            str.Append("<Row Data=\"" + db + "|" + DateTime.Now.ToString("yyyyMMdd") + "|01|" + workstation.Replace(" ", "") + "|" +
                              ZRC.Replace(" ", "") + "|" + partbumber.Replace(" ", "") + "|" + dt.Rows[i]["qty"].ToString().Replace(" ", "") + "|" + wocode.Substring(0, 4) + "-" + wocode.Substring(4, 11) + "\"/> " + Environment.NewLine);
                        }
                    }
                }

            }

            str.Append(@"      </DataSet>
                        </Data>
                        </Service>
                        </STD_IN>");
            if (dt.Rows.Count > 0)
            {
                Utils.AddLog("领料单" + db + "=>发送数据-" + str.ToString());
                string resutl = yifei.YiFeiGatewayEx(str.ToString());
                if (resutl.ToLower().Contains("<status>0</status>"))
                {
                    NMS.ExecTransql(uContext_mes, " delete from SfcDatERPLLinfo where len(GDDBDH)=0  insert into sysdatsyslog(eventname,op,[application],moudle,status,msg,fnote,creator,createtime)values('ERP同步','出库','服务平台程序','ERP同步模块','成功','','" + resutl + "','sys',getdate()) ");
                }
                else
                {
                    //ERP接口提交失败
                    StringBuilder strlog = new StringBuilder();
                    strlog.Append(" insert into SfcdaterpLog (ID,Name,type,EventName,WO,PN,qty,Fnote,Creator,Createtime) ");
                    strlog.Append(" values('SET_MOCI03','领料出库','1','','" + str.ToString() + "','','0','ERP接口提交信息失败:" + resutl + "','mes',getdate())");
                    NMS.ExecTransql(uContext_mes, strlog.ToString());

                    Utils.AddLog("出库单ERP连接失败." + DateTime.Now.ToString());
                    NMS.ExecTransql(uContext_mes,
         "  insert into sysdatsyslog(eventname,op,[application],moudle,status,msg,fnote,creator,createtime)values('ERP同步','出库','服务平台程序','ERP同步模块','失败','" + str.ToString() + "','" + resutl + "','sys',getdate()) ");
                }
                Utils.AddLog("领料单" + db + "=>接收数据-" + resutl.ToString());
            }
        }

        private void tim_erp_Tick(object sender, EventArgs e)
        {

        }

        public void LineMateMove(string user)
        {
            uContext_mes.Account = ConfigurationManager.AppSettings["mesact"].ToString();
            uContext_erp.Account = ConfigurationManager.AppSettings["erpact"].ToString();

            StringBuilder str = new StringBuilder();
            str.Append(@"<?xml version=""1.0"" encoding=""GB2312""?>
                        <!DOCTYPE SC[<!ENTITY stdd ""&amp;stdd;"">]>
                        <STD_IN Origin=""EB"">
                            <Service Name=""SetData"">
                            <ServiceId /> 
                            <User>PMES</User>                           
                            <Factory>" + ConfigurationManager.AppSettings["yifeifactory"].ToString() + @"</Factory>  
                            <Operate>ADJUST</Operate>      
                            <ObjectID>SET_INVI08</ObjectID>  
                            <Data>
                                <DataSet Field=""TA001|TA003|TA008|TA004|TB012|TB013|TB004|TB007|TB029"">");
            DataTable dt = NMS.QueryDataTable(uContext_mes, "select TOP 300 * from SfcDatERPLineMove where status='0'  order by createtime ");
            if (dt.Rows.Count > 0)
            {
                {
                    List<string> list = new List<string>();
                    DataTable dts = dt.Clone();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        list.Add(dt.Rows[i]["FGUID"].ToString());
                        DataRow[] dr = dts.Select(" pn='" + dt.Rows[i]["pn"].ToString() + "'");
                        if (dr.Length == 0)
                        {
                            DataRow _dr = dts.NewRow();
                            _dr["dbh"] = dt.Rows[i]["dbh"].ToString();
                            _dr["dbrq"] = dt.Rows[i]["dbrq"].ToString();
                            _dr["gch"] = dt.Rows[i]["gch"].ToString();
                            _dr["bm"] = dt.Rows[i]["bm"].ToString();
                            _dr["zcc"] = dt.Rows[i]["zcc"].ToString();
                            _dr["zrc"] = dt.Rows[i]["zrc"].ToString();
                            _dr["pn"] = dt.Rows[i]["pn"].ToString();
                            _dr["qty"] = dt.Rows[i]["qty"].ToString();
                            _dr["zckw"] = dt.Rows[i]["zckw"].ToString();
                            dts.Rows.Add(_dr);
                        }
                        else
                        {
                            foreach (var item in dr)
                            {
                                item["qty"] = Convert.ToDecimal(item["qty"]) + Convert.ToDecimal(dt.Rows[i]["qty"].ToString());
                            }
                        }

                    }
                    dt = dts;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        str.Append(Environment.NewLine + "<Row Data=\"" + dt.Rows[i]["DBH"].ToString() + "|" + dt.Rows[i]["DBRQ"].ToString() + "|" + dt.Rows[i]["GCH"].ToString() + "|" +
                            dt.Rows[i]["BM"].ToString() + "|" + dt.Rows[i]["ZCC"].ToString() + "|" + dt.Rows[i]["ZRC"].ToString() + "|" + dt.Rows[i]["PN"].ToString() + "|" +
                            dt.Rows[i]["QTY"].ToString() + "|" + dt.Rows[i]["ZCKW"].ToString() + "\"/> ");
                    }
                    str.Append(@"      </DataSet>
                        </Data>
                        </Service>
                        </STD_IN>");
                    if (list.Count > 0)
                    {
                        Utils.AddLog("线体调拨单=>发送数据-" + str.ToString());
                        string resutl = yifei.YiFeiGatewayEx(str.ToString());
                        if (resutl.ToLower().Contains("<status>0</status>"))
                        {
                            //更新数据
                            for (int i = 0; i < list.Count; i++)
                            {
                                //
                                bool flag = NMS.ExecTransql(uContext_mes, "update SfcDatERPLineMove set Status='1',Updatetime=GETDATE(),updator='" + user + "' where FGUID='" + list[i] + "' and status='0' ");
                                if (!flag)
                                {
                                    Utils.AddLog("线体调拨单=>更新失败" + DateTime.Now.ToString());
                                }
                            }
                            NMS.ExecTransql(uContext_mes,
                " insert into sysdatsyslog(eventname,op,[application],moudle,status,msg,fnote,creator,createtime)values('ERP同步','线体调拨','服务平台程序','ERP同步模块','成功','','" + resutl + "','sys',getdate()) ");
                        }
                        else
                        {
                            //ERP接口提交失败
                            StringBuilder strlog = new StringBuilder();
                            strlog.Append(" insert into SfcdaterpLog (ID,Name,type,EventName,WO,PN,qty,Fnote,Creator,Createtime) ");
                            strlog.Append(" values('SET_INVI08','线体调拨','1','','" + str.ToString() + "','','0','ERP接口提交信息失败:" + resutl + "','mes',getdate())");
                            NMS.ExecTransql(uContext_mes, strlog.ToString());
                        }
                        Utils.AddLog("线体调拨单=>接收数据-" + resutl);
                    }
                }
            }
        }
    }
}
