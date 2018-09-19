using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIT.Client;
using CIT.Wcf.Utils;
using System.Text.RegularExpressions;
using System.IO;
using System.Configuration;
using CIT.MES;
using Common.Helper;
using Common.BLL;
using Common.UI;

namespace Common.PCB
{
    public partial class ucpcb : UserControl
    {
        /// <summary>
        /// Ini文件操作对象
        /// </summary>
        IniFiles _objIni = new IniFiles(System.Environment.CurrentDirectory + "\\Config.ini");
        public string TBS_ID = string.Empty;
        public string sql = "";
        DataTable dtPanlChild = new DataTable();
        string _BoardSide = string.Empty;//面别
        DataColumn dcPanlChild = null;
        /// <summary>
        /// 最后一次使用过的制令单
        /// </summary>
        public string _sfcno_old = string.Empty;
        DataRow newRow;
        /// <summary>
        /// 比对位数 默认为0
        /// </summary>
        int comparisonNum = 0;
        /// <summary>
        /// 工位表业务层操作对象
        /// </summary>
        BLL_Bllb_station_tbs t_Bllb_station_tbs_BLL = new BLL_Bllb_station_tbs();

        public string TBTG_ID = string.Empty;
        public string WIP_TBTG_ID = string.Empty;
        public ucpcb()
        {
            InitializeComponent();
            this.txtChildCode.ReadOnly = false;
            dcPanlChild = dtPanlChild.Columns.Add("id", Type.GetType("System.Int32"));
            dcPanlChild = dtPanlChild.Columns.Add("WoCode", Type.GetType("System.String"));
            dcPanlChild = dtPanlChild.Columns.Add("SfcNo", Type.GetType("System.String"));
            dcPanlChild = dtPanlChild.Columns.Add("line", Type.GetType("System.String"));
            dcPanlChild = dtPanlChild.Columns.Add("code", Type.GetType("System.String"));
            #region 增加PCB类型列 2017.10.24 Zach.zhong
            dcPanlChild = dtPanlChild.Columns.Add("PCBType", Type.GetType("System.String"));
            #endregion

            #region 隐藏扫描OK时间  2017.11.24 Zach.zhong
            dcPanlChild = dtPanlChild.Columns.Add("Createtime", Type.GetType("System.String"));
            #endregion

            #region 新增板型 2017.12.07 zach.zhong
            dcPanlChild = dtPanlChild.Columns.Add("IsError", Type.GetType("System.String"));
            #endregion
            //产线模糊查找
            GetPanleLine();
            //打开串口
            //com.InitCom("PCB绑定");
            //com.ReceiveComData += com_ReceiveComData;
            this.Disposed += ucpcb_Disposed;

            this.TBS_ID = _objIni.ReadString("Package", "TBS_ID", string.Empty); //工位ID
            try
            {
                DataTable dt_station = t_Bllb_station_tbs_BLL.Query(string.Format(" TBS_ID='{0}'", TBS_ID));
                if (dt_station.Rows.Count > 0)
                {
                    txt_tbsName.Text = dt_station.Rows[0]["WORKSTATION_NAME"].ToString();
                }
                else
                {
                    this.TBS_ID = string.Empty;
                }
            }
            catch
            {

            }
        }

        void ucpcb_Disposed(object sender, EventArgs e)
        {
            try
            {
                com.CloseCom();
            }
            catch
            {

            }
        }
        ComUtils com = new ComUtils();

        void com_ReceiveComData(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate
            {
                txtChildCode.Clear();
                this.txtChildCode.Text = com.ComStr;
                if (Regex.IsMatch(txtChildCode.Text.Trim(), @"[?]"))
                {
                    new PubUtils().ShowNoteNGMsg("有不合法的字符", 1, grade.OrdinaryError);
                    txtChildCode.Clear();
                    return;
                }
                inputTxtchildcode();
            }));
        }
        /// <summary>
        /// 数据绑定dateGrid条码
        /// </summary>
        private void data()
        {
            dataChildCode.DataSource = dtPanlChild;

        }
        private void txtcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                InputPcbCode();
            }
        }
        void InputPcbCode()
        {
            if (txtSfcno.Text != "" && txtwoCodePanel.Text.Trim() != "" && cmbPanleLine.Text.Trim() != "" && txtPanelQTY.Text.Trim() != "" && txtChildCode.Text.Trim() != "")
            {
                try
                {
                    //                    string SqlUpdate = string.Format(@"if exists (select * from MdcDatSteelPlate where SfcNo='{0}' and statu=3)
                    //                    begin
                    //	                    update MdcDatSteelPlate set UseValue=UseValue+1 where SfcNo='{0}'
                    //                        select 1,'更新成功'
                    //                    end
                    //                    else begin
                    //	                    select 0,'当前工单的钢网未上线，不能生产'
                    //                    end", txtSfcno.Text.Trim());
                    //                    if (NMS.QueryDataTable(PubUtils.uContext, SqlUpdate).Rows[0][0].ToString() == "0")
                    //                    {
                    //                        new PubUtils().ShowNoteNGMsg("当前工单钢网未上线，不能生产", 2, grade.SevereError);
                    //                        return;
                    //                    }
                    int count = Int32.Parse(txtPanelQTY.Text.Trim());//拼版数量
                    DataRow[] drArr = dtPanlChild.Select(" code='" + txtChildCode.Text.Trim() + "'");//查找data中是否存在此条码
                    sql = "select isnull(min(PCBCode),0) from TRS_Base_PCBCode where PCBCode='" + txtChildCode.Text.Trim() + "'";
                    string WoCode = NMS.QueryDataTable(PubUtils.uContext, sql).Rows[0][0].ToString().Trim();//查找数据库是否存在此条码
                    if ((drArr.Length == 0) && (WoCode == "0"))//条码不存在于data与数据库中时运行
                    {
                        newRow = dtPanlChild.NewRow();
                        newRow["id"] = dtPanlChild.Rows.Count + 1;
                        newRow["WoCode"] = txtwoCodePanel.Text.Trim();
                        newRow["SfcNo"] = txtSfcno.Text;
                        newRow["line"] = cmbPanleLine.Text.Trim();
                        newRow["code"] = txtChildCode.Text.Trim();
                        #region 新增PCB类型列 Zach 2017.11.24
                        string pcbType = CutCharToString();
                        newRow["PCBType"] = pcbType == null ? string.Empty : pcbType;
                        #endregion
                        #region 新增隐藏扫描时间 Zach.2017.11.24
                        newRow["Createtime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        #endregion
                        #region 新增板型 Zach 2017.12.07
                        newRow["IsError"] = chk_x.Checked == true ? "0" : "10";
                        #endregion
                        dtPanlChild.Rows.Add(newRow);
                        this.dataChildCode.DataSource = dtPanlChild;
                        if (count == dtPanlChild.Rows.Count)
                        {
                            sql = "";

                            string PanlCode = "";//已第一个条码为panlcode
                            if (count == 1)
                            {
                                PanlCode = dtPanlChild.Rows[0][4].ToString().Trim();
                            }
                            else
                            {
                                PanlCode = "F" + dtPanlChild.Rows[0][4].ToString().Trim();
                            }
                            foreach (DataRow dr in dtPanlChild.Rows)
                            {
                                sql += " insert TRS_Base_PCBCode(WorkOrderNo,PCBCode,Status,Printed,PanelCode,Line,Creator,Createtime,SfcNo,[PCBType],IsError)";
                                sql += " values('" + dr["WoCode"].ToString() + "','" + dr["code"].ToString() + "',0,0,'" + PanlCode + "','" + cmbPanleLine.Text.Trim() + "','" + PubUtils.uContext.UserName + "','" + dr["Createtime"].ToString().Trim() + "','" + dr["SfcNo"].ToString().Trim() + "','" + dr["PCBType"].ToString().Trim() + "','" + dr["IsError"].ToString().Trim() + "');";
                                //增加SyssystemLog日志 nancy 2017.07.27
                                sql += " insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)";
                                sql += " values(newid(),'" + cmbPanleLine.Text.Trim() + "','" + dr["WoCode"].ToString() + "','" + dr["SfcNo"].ToString().Trim() + "','','','" + dr["code"].ToString() + "','','','003',1,'MES-PCB绑定,PanlCode:" + PanlCode + "','" + PubUtils.uContext.UserName + "')";
                            }
                            bool flag = NMS.ExecTransql(PubUtils.uContext, sql);
                            if (flag)
                            {
                                new PubUtils().ShowNoteOKMsg("数据上传成功");
                                txtChildCode.Text = "";
                                dtPanlChild.Clear();
                            }
                        }
                        txtChildCode.SelectAll();
                        txtChildCode.Focus();
                        data();
                    }
                    else
                    {
                        new PubUtils().ShowNoteNGMsg("此条码已经扫过", 1, grade.RepeatedError);
                        txtChildCode.Text = "";
                        txtChildCode.Focus();
                        return;
                    }
                }
                catch
                {
                    new PubUtils().ShowNoteNGMsg("拼板数必须为整数,请重新输入!", 1, grade.OrdinaryError);
                    txtPanelQTY.SelectAll();
                    txtPanelQTY.Focus();
                    return;
                }
            }
            else
            {
                new PubUtils().ShowNoteNGMsg("必填项不可为空!", 1, grade.OrdinaryError);
                txtChildCode.Text = "";
                txtChildCode.Focus();
                return;
            }
        }
        private void datacode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (MsgBox.Question("确定要删除吗？") == DialogResult.OK)
            {
                int id = Convert.ToInt32(dataChildCode.Rows[e.RowIndex].Cells["id"].Value);
                dtPanlChild.Rows[e.RowIndex].Delete();
                data();
                txtChildCode.Text = "";
            }
        }
        #region 扫描pannelCode数据
        /// <summary>
        /// 绑定工单
        /// </summary>
        List<string> list_line = new List<string>();
        private void GetPanleLine()
        {
            list_line.Clear();
            sql = "select distinct Line from SfcDatProduct";
            DataTable dtw = NMS.QueryDataTable(PubUtils.uContext, sql);
            for (int i = 0; i < dtw.Rows.Count; i++)
            {
                list_line.Add(dtw.Rows[i]["Line"].ToString());
            }
        }
        /// <summary>
        /// 绑定panlCode列表
        /// </summary>
        /// <param name="code"></param>
        private void GetPanelWoCode(string SfcNo)
        {
            sql = "select isnull(max(WoCode),0) from SfcDatProduct where SfcNo='" + SfcNo + "'";
            string WoCode = NMS.QueryDataTable(PubUtils.uContext, sql).Rows[0][0].ToString();
            txtwoCodePanel.Text = WoCode;
        }

        string UUID = null;
        private void txtChildCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            string firstChar = "";
            if (e.KeyChar == 13)
            {
            
                if (txtChildCode.TextLength > 0)
                {
                    firstChar = this.txtChildCode.Text.Substring(0, 1);

                }
                else
                {
                    new PubUtils().ShowNoteNGMsg("没有扫描条码ID！", 1, grade.SevereError);
                    txtChildCode.Clear();
                    return;
                }

                if (!firstChar.Contains("F"))
                {
                    if (txtSource.Text.Length != txtChildCode.Text.Length)
                    {
                        new PubUtils().ShowNoteNGMsg("源比对字符长度与条码ID长度不一致", 1, grade.SevereError);
                        txtChildCode.Clear();
                        return;
                    }
                }

                inputTxtchildcode();
            }
        }
        void inputTxtchildcode()
        {
            if (btnLock.Text != "解锁")
            {
                new PubUtils().ShowNoteNGMsg("源比对没有锁定", 1, grade.SevereError);
                txtChildCode.Clear();
                return;
            }
            //CIT.Client.MsgBox.Info(txtChildCode.Text);
            //return;
            //比对指定位数据
            if (txtChildCode.Text.Trim().StartsWith(@"F"))//||Regex.IsMatch(txtChildCode.Text.Trim().ToUpper(), @"F"
            {
            }
            else
            {
                for (int i = 0; i < txtSource.Text.Trim().Length; i++)
                {
                    if (txtSource.Text.Trim().Substring(i, 1).ToUpper() == "*".ToUpper())
                    {
                        continue;
                    }
                    if ((txtChildCode.Text.Trim().Substring(i, 1)).ToUpper() != (txtSource.Text.Trim().Substring(i, 1)).ToUpper())
                    {
                        new PubUtils().ShowNoteNGMsg(i + 1 + "位数据比对错误", 1, grade.SevereError);
                        txtChildCode.Clear();
                        return;
                    }
                }
            }
            DataTable dt = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, @"select top 1 a.*,b.key1,b.Value2 from SfcDatProduct as a inner join MdcdatProductDetail as b on a.Product=b.ProductCode where [status]=3 and Line='" + cmbPanleLine.Text.Trim() + "' order by Createtime desc");
            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }
            txtwoCodePanel.Text = dt.Rows[0]["WOCode"].ToString().Trim();
            txtSfcno.Text = dt.Rows[0]["SfcNo"].ToString().Trim();
            txtProduct.Text = dt.Rows[0]["Product"].ToString().Trim();
            _BoardSide = SqlInput.ChangeNullToString(dt.Rows[0]["BoardSide"]);//面别
            dt = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, @"select top 1 a.*,b.key1,b.Value2 from SfcDatProduct as a inner join MdcdatProductDetail as b on a.Product=b.ProductCode where [status]=3 and Line='" + cmbPanleLine.Text.Trim() + "' and key1='FixTure' and Value2='是' order by Createtime desc");
            if (dt != null && dt.Rows.Count > 0)
            {
                chbFixtuerAction.Checked = true;
            }
            else
            {
                chbFixtuerAction.Checked = false;
            }
            //判断是否启用夹具
            if (!chbFixtuerAction.Checked)
            {
                InputPcbCode();
                return;
            }
            if (cmbPanleLine.Text.Trim().Length == 0 || txtwoCodePanel.Text.Trim().Length == 0 || txtSfcno.Text.Trim().Length == 0 || txtPanelQTY.Text.Trim().Length == 0 || txtChildCode.Text.Trim().Length == 0 || txt_pcbType.Text.Trim().Length == 0 || txt_cnum.Text.Trim().Length == 0)
            {
                CIT.Client.MsgBox.Error("输入框不能为空");
                txtChildCode.Clear();
                return;
            }
            DataRow[] dr = dtPanlChild.Select("code='" + txtChildCode.Text.Trim() + "'");
            if (dr.Length > 0)
            {
                new PubUtils().ShowNoteNGMsg("子板已存在", 1, grade.RepeatedError);
                txtChildCode.Clear();
                return;
            }
            string SqlQuery = string.Format(@"if not exists (select * from MdcDatFixTure where FixCode='{0}')
                begin
	                select '0','不是夹具'
                end
                else if ( (select FixValue-CumulativeNum from MdcDatFixTure where FixCode='{0}')<=0 or (select case IsEnable when '可用' then 1 when '不可用' then 0 end isenable from MdcDatFixTure where FixCode='{0}')=0)
                begin
	                select '2','此夹具被禁用或超过使用次数'
                end
                else
                begin
	                select '1','此夹具可以使用'
                end
                ", txtChildCode.Text.Trim());
            DataTable dtfixture = NMS.QueryDataTable(PubUtils.uContext, SqlQuery);
            if ((txtChildCode.Text.Trim().StartsWith(@"F") && dtfixture.Rows[0][0].ToString() != "2") || dtfixture.Rows[0][0].ToString() == "1")//Regex.IsMatch(txtChildCode.Text.Trim().ToUpper(), @"F"
            {
                txtFixtureNO.Text = txtChildCode.Text;
                txtChildCode.SelectAll();
                txtChildCode.Focus();
                return;
            }
            else if (dtfixture.Rows[0][0].ToString() == "2")
            {
                new PubUtils().ShowNoteNGMsg(dtfixture.Rows[0][1].ToString(), 1, grade.OrdinaryError);
                return;
            }

            string msg = string.Empty;
            #region 注释掉
            //string strSql = string.Format(@"SELECT TBT_ID FROM dbo.SfcDatProduct WHERE SfcNo='{0}'",txtSfcno.Text.Trim());
            //DataTable dt_tbt_id= CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);            
            //DataTable dt_gy= BLL_TechRoute.QueryTechGroup(dt_tbt_id.Rows[0]["TBT_ID"].ToString(), TBS_ID);
            //if (dt_gy.Rows[0]["INOUT_TYPE"].ToString() == "0")
            //{
            //    TBTG_ID = dt_gy.Rows[0]["TBTG_ID"].ToString();

            //    WIP_TBTG_ID = BLL_TechRoute.GetNextTechGroupID(TBTG_ID, true);//获取下一个工艺工序ID
            //}
            //else
            //{
            //    TBTG_ID = BLL_TechRoute.GetNextRe_TBTG_ID(txtChildCode.Text.Trim(), this.TBS_ID, ref msg);
            //    if (msg == string.Empty)
            //    {
            //        //1.4校验此产品SN流程是否到了包装
            //        //msg = BLL_TechRoute.CheckRoute(txt_serialNumber.Text, this.TBS_ID, ref TBTG_ID);        
            //        msg = BLL_TechRoute.CheckRoute(txtChildCode.Text, this.TBS_ID, ref TBTG_ID, ref WIP_TBTG_ID);
            //    }
            //    else
            //    {
            //        WIP_TBTG_ID = BLL_TechRoute.GetNextTechGroupID(TBTG_ID, true);//获取下一个工艺工序ID
            //    }
            //    if (msg != "OK")
            //    {
            //        new PubUtils().ShowNoteNGMsg(msg, 1, grade.OrdinaryError);
            //        txtChildCode.SelectAll();
            //        return;

            //    }
            //}

            //获取工艺工位对应的工艺信息
            //DataTable dt_tech = BLL_TechRoute.GetTechFirtstGroupInfo(txtSfcno.Text.Trim(), TBS_ID);
            //    if (dt_tech.Rows.Count == 0)
            //    {
            //        MessageBox.Show("当前工位不属于工艺的投入工序下的工位");
            //        txtChildCode.Clear();
            //        return;
            //    }
            //    else
            //    {
            //        TBTG_ID = dt_tech.Rows[0][0].ToString();
            //        try
            //        {
            //            WIP_TBTG_ID = dt_tech.Rows[0]["WIP_TBTG_ID"].ToString();
            //        }
            //        catch
            //        { }

            //    }
            #endregion
            T_Bllb_productInfo_tbpi_BLL bll = new T_Bllb_productInfo_tbpi_BLL();
            Model.T_Bllb_productInfo_tbpi obj = new Model.T_Bllb_productInfo_tbpi();
            obj.SERIAL_NUMBER = txtChildCode.Text.Trim();
            DataTable dt_sn = bll.SelectBySN(obj);
            bool reflow_flag = false;
            if (dt_sn.Rows.Count > 0)
            {
                if (dt_sn.Rows[0]["SfcNo"].ToString() == txtSfcno.Text.Trim())//判断是否为同一个制令单，若是说明为回流或返工
                {
                    TBTG_ID = BLL_TechRoute.GetNextRe_TBTG_ID(txtChildCode.Text.Trim(), this.TBS_ID, ref msg);
                    if (msg == string.Empty)
                    {
                        //1.4校验此产品SN流程是否到了包装
                        //msg = BLL_TechRoute.CheckRoute(txt_serialNumber.Text, this.TBS_ID, ref TBTG_ID);        
                        msg = BLL_TechRoute.CheckRoute(txtChildCode.Text, this.TBS_ID, ref TBTG_ID, ref WIP_TBTG_ID);

                    }
                    if (msg == "OK")
                    {
                        WIP_TBTG_ID = BLL_TechRoute.GetNextTechGroupID(TBTG_ID, true);//获取下一个工艺工序ID
                        reflow_flag = true;
                    }
                    else
                    {
                        MessageBox.Show(msg);
                        txtChildCode.Clear();
                        return;
                    }
                }
            }

            if (!reflow_flag)//非回流情况
            {
                //获取工艺工位对应的工艺信息
                DataTable dt_tech = BLL_TechRoute.GetTechFirtstGroupInfo(txtSfcno.Text.Trim(), TBS_ID);
                if (dt_tech.Rows.Count == 0)
                {
                    MessageBox.Show("当前工位不属于工艺的投入工序下的工位");
                    txtChildCode.Clear();
                    return;
                }
                else
                {
                    TBTG_ID = dt_tech.Rows[0][0].ToString();
                    try
                    {
                        WIP_TBTG_ID = dt_tech.Rows[0]["WIP_TBTG_ID"].ToString();
                    }
                    catch
                    { }

                }
            }

            // panelno拼板数  datagridview总行数
            int panelno = int.Parse(txtPanelQTY.Text.Trim());
            int dgvRowscount = dataChildCode.Rows.Count + 1;
            bool isNewBoardSide = false;
            if (!(NMS.QueryDataTable(PubUtils.uContext, @"select count(*) from TRS_Base_PCBCode where PCBCode='" + txtChildCode.Text.Trim() + "'").Rows[0][0].ToString() == "0"))
            {
                //判断是否面别相同
                DataTable dt_old = NMS.QueryDataTable(PubUtils.uContext, string.Format(@"SELECT B.WoCode,B.BoardSide FROM T_Bllb_productInfo_tbpi A  LEFT JOIN SfcDatProduct B ON A.SfcNo=B.SfcNo
 WHERE SERIAL_NUMBER='{0}' AND LAST_FLAG='Y' and b.WoCode='{1}'", txtChildCode.Text.Trim(),txtwoCodePanel.Text.Trim()));
                if(dt_old.Rows.Count>0)
                {
                    DataRow[] drs= dt_old.Select(string.Format("BoardSide='{0}'", _BoardSide));
                    if (drs.Length==0)
                    {
                        isNewBoardSide = true;
                    }
                 
                }
                NMS.ExecTransql(PubUtils.uContext, string.Format(@"DELETE FROM TRS_Base_PCBCode where PCBCode='{0}'", txtChildCode.Text.Trim()));
                //else
                //{
                //    new PubUtils().ShowNoteNGMsg("子板已存在", 1, grade.RepeatedError);
                //    txtChildCode.Clear();
                //    txtChildCode.Focus();
                //    return;
                //}

            }
            //if (!(NMS.QueryDataTable(PubUtils.uContext, @"select count(*) from TRS_Base_PCBCode where  PanelCode='" + txtFixtureNO.Text.Trim() + "'").Rows[0][0].ToString() == "0"))
            //{
            //    new PubUtils().ShowNoteNGMsg("夹具已存在", 1, grade.RepeatedError);
            //    txtChildCode.Clear();
            //    txtChildCode.Focus();
            //    return;
            //}
            if (dgvRowscount >= panelno && txtFixtureNO.Text.Trim().Length == 0)
            {
                new PubUtils().ShowNoteNGMsg("夹具编号不能为空", 1, grade.SevereError);
                txtChildCode.Clear();
                txtChildCode.Focus();
                return;
            }

      

            newRow = dtPanlChild.NewRow();
            newRow["id"] = dtPanlChild.Rows.Count + 1;
            newRow["WoCode"] = txtwoCodePanel.Text.Trim();
            newRow["SfcNO"] = txtSfcno.Text.Trim();
            newRow["line"] = cmbPanleLine.Text.Trim();
            newRow["code"] = txtChildCode.Text.Trim();
            #region 新增PCB类型列 2017.10.24 Zach.zhong
            string pcbType = CutCharToString();
            newRow["PCBType"] = pcbType == null ? string.Empty : pcbType;
            #endregion
            #region 新增隐藏扫描时间 Zach.2017.11.24 1
            newRow["Createtime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            newRow["IsError"] = chk_x.Checked == true ? "0" : "10";
            #endregion
            dtPanlChild.Rows.Add(newRow);


            //dataChildCode.Rows.Add(dgvRowscount, txtwoCodePanel.Text.Trim(), txtSfcno.Text.Trim(), cmbPanleLine.Text.Trim(), txtChildCode.Text.Trim());
            dataChildCode.DataSource = dtPanlChild;
            DataTable dtBackBanding = NMS.QueryDataTable(PubUtils.uContext, @"select BarCodeType from MdcdatProduct where ProductCode = '" + txtProduct.Text.Trim() + "'");
            if (dtBackBanding == null || dtBackBanding.Rows.Count == 0)
            {
                new PubUtils().ShowNoteNGMsg("为维护条码类别", 2, grade.OrdinaryError);
                txtChildCode.Clear();
                return;
            }
            if (dtBackBanding.Rows[0][0].ToString() == "3")
            {
                chbBackBanding.Checked = true;
            }
            else
            {
                chbBackBanding.Checked = false;
            }
            if (dgvRowscount >= panelno)
            {
                //UUID = Guid.NewGuid().ToString();
                UUID = txtFixtureNO.Text.Trim();
                //string sqlinsert = null; 20170524
                string sqlinsert = null;

                if (chbBackBanding.Checked)
                {

                }
                else
                {
                    string str_time ="_"+ DateTime.Now.ToString("yyMMddHHmmss");
                    //前道绑定
                    sqlinsert = "delete from SfcDatFixtureCodeBands where FixtureCode='" + txtFixtureNO.Text.Trim() + "' INSERT INTO SfcDatFixtureCodeBands (Sfcno,Wocode,FixtureCode,PanelCode) values('" + txtSfcno.Text.Trim() + "','" + txtwoCodePanel.Text.Trim() + "','" + txtFixtureNO.Text.Trim() + "','" + UUID + "')";
                    sqlinsert += string.Format("delete from TRS_Base_PCBCode  where PanelCode='{0}'",txtFixtureNO.Text.Trim());
                }
                foreach (DataRow item in dtPanlChild.Rows)
                {
                    //新增了插入PCB类型一列 2017.10.24 Zach.zhong  修改createtime时间 为校验OK时间 2017.11.24
                    sqlinsert += string.Format(@" INSERT INTO [dbo].[TRS_Base_PCBCode] ([FixtureCode],[WorkOrderNo],[PCBCode],[Status],[Printed],[LastProcess],[Remark],[PanelCode],[Line],[SfcNO],[Creator],[Createtime],[PCBType],[IsError])
                        VALUES ('" + txtFixtureNO.Text.Trim() + "','{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}','{10}','{11}','{12}')", item["wocode"].ToString().Trim(), item["code"].ToString().Trim(), "0", "0", "NULL", "NULL", UUID, item["line"].ToString().Trim(), item["sfcno"].ToString().Trim(), PubUtils.uContext.UserName, item["Createtime"].ToString().Trim(), item["PCBType"].ToString().Trim(), item["IsError"].ToString());
                    //sqlinsert += string.Format(@" INSERT INTO [dbo].[TRS_Base_PCBCode] ([FixtureCode],[WorkOrderNo],[PCBCode],[Status],[Printed],[LastProcess],[Remark],[PanelCode],[Line],[SfcNO],[Creator],[Createtime],[PCBType],[IsError])
                    //    VALUES ('" + txtFixtureNO.Text.Trim() + "','{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}','{10}','{11}','{12}')", item["wocode"].ToString().Trim(), item["code"].ToString().Trim(), "0", "0", "NULL", "NULL", txtFixtureNO.Text.Trim(), item["line"].ToString().Trim(), item["sfcno"].ToString().Trim(), PubUtils.uContext.UserName, item["Createtime"].ToString().Trim(), item["PCBType"].ToString().Trim(), item["IsError"].ToString());

                    //增加SyssystemLog日志 nancy 2017.07.27
                    sqlinsert += " insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)";
                    sqlinsert += " values(newid(),'" + item["line"].ToString().Trim() + "','" + item["wocode"].ToString().Trim() + "','" + item["sfcno"].ToString().Trim() + "','','','" + item["code"].ToString().Trim() + "','','','003',1,'MES-PCB绑定,PanlCode:" + UUID + "','" + PubUtils.uContext.UserName + "')";
                    if (chbBackBanding.Checked)
                    {
                        //                        //后道绑定
                        //                        sqlinsert += string.Format(@" INSERT INTO [dbo].[TRS_Base_PCBCode] ([FixtureCode],[WorkOrderNo],[PCBCode],[Status],[Printed],[LastProcess],[Remark],[PanelCode],[Line],[SfcNO],[Creator],[Createtime])
                        //                        VALUES ('" + txtFixtureNO.Text.Trim() + "','{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}',GETDATE())", item["wocode"].ToString().Trim(), item["code"].ToString().Trim(), "0", "0", "NULL", "NULL", txtFixtureNO.Text.Trim(), item["line"].ToString().Trim(), item["sfcno"].ToString().Trim(), PubUtils.uContext.UserName);
                        sqlinsert += @"update TRS_Busi_MachineTrace set PCBCode='" + UUID + "' from TRS_Busi_MachineTrace as a inner join TRS_Base_PCBCode as b on a.PCBCode=b.FixtureCode where a.PCBCode='" + txtFixtureNO.Text.Trim() + "'";
                    }
                    else
                    {
                        //                        //前道绑定
                        //                        sqlinsert += string.Format(@" INSERT INTO [dbo].[TRS_Base_PCBCode] ([FixtureCode],[WorkOrderNo],[PCBCode],[Status],[Printed],[LastProcess],[Remark],[PanelCode],[Line],[SfcNO],[Creator],[Createtime])
                        //                        VALUES ('" + txtFixtureNO.Text.Trim() + "','{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}',GETDATE())", item["wocode"].ToString().Trim(), item["code"].ToString().Trim(), "0", "0", "NULL", "NULL", UUID, item["line"].ToString().Trim(), item["sfcno"].ToString().Trim(), PubUtils.uContext.UserName);
                    }
                }
                if (!CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, sqlinsert))
                {
                    new PubUtils().ShowNoteNGMsg("导入数据失败", 1, grade.SevereError);
                    txtChildCode.Clear();
                    txtChildCode.Focus();
                    return;
                }
                msg = string.Empty;
                #region 过站
                foreach (DataRow item in dtPanlChild.Rows)
                {
                    if (isNewBoardSide)
                    {
                       string strSql = string.Format(@"UPDATE T_Bllb_productInfo_tbpi SET LAST_FLAG='N' WHERE SERIAL_NUMBER='{0}'", item["code"].ToString());
                        CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
                    }
                    BLL_Save_Pass_SN.PassGroup(txtSfcno.Text.Trim(), item["code"].ToString().Trim(), TBS_ID, TBTG_ID, WIP_TBTG_ID, new List<string> { }, ref msg);
                }
                #endregion
                new PubUtils().ShowNoteOKMsg("数据上传成功");
                txtChildCode.Clear();
                txtChildCode.Focus();
                if (!NMS.ExecTransql(PubUtils.uContext, @"update MdcDatFixTure set CumulativeNum=CumulativeNum+1 where FixCode='" + txtFixtureNO.Text.Trim() + "'"))
                {
                    new PubUtils().ShowNoteNGMsg("夹具次数累加失败，请重新执行", 1, grade.OrdinaryError);
                    txtChildCode.Clear();
                    return;
                }
                dtPanlChild.Clear();
                txtFixtureNO.Clear();
                txtChildCode.Clear();
            }
            txtChildCode.Clear();
            txtChildCode.Focus();

        }

        private void dataChildCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataChildCode.Columns[e.ColumnIndex].Name != "del")
            {
                return;
            }
            if (MsgBox.Question("确定要删除吗？") == DialogResult.OK)
            {

                int id = Convert.ToInt32(dataChildCode.Rows[e.RowIndex].Cells["IDPanelChild"].Value);
                dataChildCode.Rows.RemoveAt(e.RowIndex);
                //dataChildCode.Rows[e.RowIndex].Delete();
                //DataPanelChild();
            }
        }
        #endregion

        private void cmbPanleLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, @"select top 1 a.*,b.key1,b.Value2 from SfcDatProduct as a inner join MdcdatProductDetail as b on a.Product=b.ProductCode where [status]=3 and Line='" + cmbPanleLine.Text.Trim() + "' order by Createtime desc");
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("请先维护产品信息");
                return;
            }
            txtwoCodePanel.Clear();
            txtSfcno.Clear();
            txtProduct.Clear();
            txtwoCodePanel.Text = dt.Rows[0]["WOCode"].ToString().Trim();
            txtSfcno.Text = dt.Rows[0]["SfcNo"].ToString().Trim();
            _BoardSide =SqlInput.ChangeNullToString(dt.Rows[0]["BoardSide"]);
            txtProduct.Text = dt.Rows[0]["Product"].ToString().Trim();
            dt = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, @"select top 1 a.*,b.key1,b.Value2 from SfcDatProduct as a inner join MdcdatProductDetail as b on a.Product=b.ProductCode where [status]=3 and Line='" + cmbPanleLine.Text.Trim() + "' and key1='FixTure' and Value2='是'  order by Createtime desc");
            if (dt != null && dt.Rows.Count > 0)
            {
                chbFixtuerAction.Checked = true;
            }
            else
            {
                chbFixtuerAction.Checked = false;
            }
            txtSource.Clear();
            txtSource.ReadOnly = false;
            btnLock.Text = "锁定";
            txt_pcbType.Clear();
            txt_pcbType.ReadOnly = false;
            chk_x.Enabled = true;
            chk_t.Enabled = true;
            chk_x.Checked = false;
            chk_t.Checked = false;
            txt_cnum.ReadOnly = false;
            txt_cnum.Clear();
            txtPanelQTY.SelectAll();
            txtPanelQTY.Focus();
        }

        private void cmbPanleLine_TextUpdate(object sender, EventArgs e)
        {
            cmbPanleLine.Items.Clear();
            var find_gdh = from gdh in list_line where gdh.Contains(cmbPanleLine.Text.Trim().ToUpper()) select gdh;
            foreach (var item in find_gdh)
            {
                cmbPanleLine.Items.Add(item.ToString());
            }
            this.cmbPanleLine.DroppedDown = true;
            Cursor = Cursors.Default;
            this.cmbPanleLine.SelectionStart = this.cmbPanleLine.Text.Length;
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (btnLock.Text == "锁定")
            {
                if (txt_tbsName.Text.Trim().Length==0 || cmbPanleLine.Text.Trim().Length == 0 || txtwoCodePanel.Text.Trim().Length == 0 || txtSfcno.Text.Trim().Length == 0 || txtPanelQTY.Text.Trim().Length == 0 || txt_pcbType.Text.Trim().Length == 0 || txt_cnum.Text.Trim().Length == 0)
                {
                    CIT.Client.MsgBox.Error("必填项不能为空");
                    return;
                }
                if (chk_x.Checked == false && chk_t.Checked == false)
                {
                    CIT.Client.MsgBox.Error("FCT必选!");
                    return;
                }
                CIT.MES.Package.Formpermission f = new CIT.MES.Package.Formpermission();
                f.ShowDialog();
                if (!f.IsHavePermission)
                {
                    return;
                }
                try
                {
                    try
                    {
                        comparisonNum = int.Parse(txt_cnum.Text.Trim());
                    }
                    catch (Exception ee)
                    {
                        new PubUtils().ShowNoteNGMsg("比对位数只能是整数!", 1, grade.OrdinaryError);
                        return;
                    }
                    string product = GetNumbers(txtProduct.Text.Trim());
                    //if (txtSource.Text.Trim().Substring(0, 4) != product.Substring(product.Length - 4, 4))
                    //{
                    //    new PubUtils().ShowNoteNGMsg("比对源错误!", 1, grade.SevereError);
                    //    return;
                    //}
                    if (txtSource.Text.Trim().Substring(0, comparisonNum) != product.Substring(product.Length - comparisonNum, comparisonNum))
                    {
                        new PubUtils().ShowNoteNGMsg("比对源错误!", 1, grade.SevereError);
                        return;
                    }
                }
                catch (Exception ee)
                {
                    new PubUtils().ShowNoteNGMsg(string.Format("产品或比对源不足{0}位!", comparisonNum), 1, grade.SevereError);
                    return;
                }
                txtSource.ReadOnly = true;
                txt_pcbType.ReadOnly = true;
                txt_cnum.ReadOnly = true;
                chk_x.Enabled = false;
                chk_t.Enabled = false;
                btn_open.Enabled = false;
                btnLock.Text = "解锁";
            }
            else
            {
                CIT.MES.Package.Formpermission f = new CIT.MES.Package.Formpermission();
                f.ShowDialog();
                if (!f.IsHavePermission)
                {
                    return;
                }
                txtSource.ReadOnly = false;
                txt_pcbType.ReadOnly = false;
                txt_cnum.ReadOnly = false;
                chk_x.Enabled = true;
                chk_t.Enabled = true;
                btn_open.Enabled = true;
                btnLock.Text = "锁定";
            }
        }
        /// <summary>
        /// 提取字符串中的数字
        /// </summary>
        /// <param name="p_str"></param>
        /// <returns></returns>
        public static string GetNumbers(string p_str)
        {
            string strReturn = string.Empty;
            if (p_str == null || p_str.Trim() == "")
            {
                strReturn = "";
            }

            foreach (char chrTemp in p_str)
            {
                if (Char.IsNumber(chrTemp))
                {
                    strReturn += chrTemp.ToString();
                }
            }
            return strReturn;
        }

        private void dataChildCode_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ucpcb_Load(object sender, EventArgs e)
        {
            //if (ConfigurationManager.AppSettings["ComIO"].ToString() == "1")
            //{
            //    txtChildCode.Enabled = false;
            //}
            //else
            //{
            //    txtChildCode.Enabled = true;
            //}
        }

        private void txtManualBindPcb_Click(object sender, EventArgs e)
        {
            if (btnLock.Text != "解锁")
            {
                new PubUtils().ShowNoteNGMsg("源比对没有锁定", 1, grade.SevereError);
                return;
            }
            //CIT.Client.MsgBox.Info(txtChildCode.Text);
            //return;
            //比对指定位数据
            if (txtChildCode.Text.Trim().StartsWith(@"F"))//||Regex.IsMatch(txtChildCode.Text.Trim().ToUpper(), @"F"
            {
            }
            else
            {
                for (int i = 0; i < txtSource.Text.Trim().Length; i++)
                {
                    try
                    {
                        if (txtSource.Text.Trim().Substring(i, 1).ToUpper() == "*".ToUpper())
                        {
                            continue;
                        }
                        if ((txtChildCode.Text.Trim().Substring(i, 1)).ToUpper() != (txtSource.Text.Trim().Substring(i, 1)).ToUpper())
                        {
                            new PubUtils().ShowNoteNGMsg(i + 1 + "位数据比对错误", 1, grade.SevereError);
                            txtChildCode.Clear();
                            return;
                        }
                    }
                    catch (Exception ee)
                    {

                    }
                }
            }
            DataTable dt = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, @"select top 1 a.*,b.key1,b.Value2 from SfcDatProduct as a inner join MdcdatProductDetail as b on a.Product=b.ProductCode where [status]=3 and Line='" + cmbPanleLine.Text.Trim() + "' order by Createtime desc");
            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }
            txtwoCodePanel.Text = dt.Rows[0]["WOCode"].ToString().Trim();
            txtSfcno.Text = dt.Rows[0]["SfcNo"].ToString().Trim();
            txtProduct.Text = dt.Rows[0]["Product"].ToString().Trim();
            dt = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, @"select top 1 a.*,b.key1,b.Value2 from SfcDatProduct as a inner join MdcdatProductDetail as b on a.Product=b.ProductCode where [status]=3 and Line='" + cmbPanleLine.Text.Trim() + "' and key1='FixTure' and Value2='是' order by Createtime desc");
            if (dt != null && dt.Rows.Count > 0)
            {
                chbFixtuerAction.Checked = true;
            }
            else
            {
                chbFixtuerAction.Checked = false;
            }
            //判断是否启用夹具
            if (!chbFixtuerAction.Checked)
            {
                InputPcbCode();
                return;
            }
            if (cmbPanleLine.Text.Trim().Length == 0 || txtwoCodePanel.Text.Trim().Length == 0 || txtSfcno.Text.Trim().Length == 0 || txtPanelQTY.Text.Trim().Length == 0 || txt_pcbType.Text.Trim().Length == 0)
            {
                CIT.Client.MsgBox.Error("输入框不能为空");
                return;
            }
            DataRow[] dr = dtPanlChild.Select("code='" + txtChildCode.Text.Trim() + "'");
            if (dr.Length > 0)
            {
                new PubUtils().ShowNoteNGMsg("子板已存在", 1, grade.RepeatedError);
                return;
            }
            string SqlQuery = string.Format(@"if not exists (select * from MdcDatFixTure where FixCode='{0}')
                begin
	                select '0','不是夹具'
                end
                else if ( (select FixValue-CumulativeNum from MdcDatFixTure where FixCode='{0}')<=0 or (select case IsEnable when '可用' then 1 when '不可用' then 0 end isenable from MdcDatFixTure where FixCode='{0}')=0)
                begin
	                select '2','此夹具被禁用或超过使用次数'
                end
                else
                begin
	                select '1','此夹具可以使用'
                end
                ", txtChildCode.Text.Trim());
            DataTable dtfixture = NMS.QueryDataTable(PubUtils.uContext, SqlQuery);
            if ((txtChildCode.Text.Trim().StartsWith(@"F") && dtfixture.Rows[0][0].ToString() != "2") || dtfixture.Rows[0][0].ToString() == "1")//Regex.IsMatch(txtChildCode.Text.Trim().ToUpper(), @"F"
            {
                txtFixtureNO.Text = txtChildCode.Text;
                txtChildCode.SelectAll();
                txtChildCode.Focus();
                return;
            }
            else if (dtfixture.Rows[0][0].ToString() == "2")
            {
                new PubUtils().ShowNoteNGMsg(dtfixture.Rows[0][1].ToString(), 1, grade.OrdinaryError);
                return;
            }
            // panelno拼板数  datagridview总行数
            int panelno = int.Parse(txtPanelQTY.Text.Trim());
            int dgvRowscount = dataChildCode.Rows.Count + 1;
            if (!(NMS.QueryDataTable(PubUtils.uContext, @"select count(*) from TRS_Base_PCBCode where PCBCode='" + txtChildCode.Text.Trim() + "' or PanelCode='" + txtFixtureNO.Text.Trim() + "'").Rows[0][0].ToString() == "0"))
            {
                new PubUtils().ShowNoteNGMsg("子板或夹具已存在", 1, grade.RepeatedError);
                txtChildCode.Clear();
                txtChildCode.Focus();
                return;
            }
            if (txtFixtureNO.Text.Trim().Length == 0)
            {
                new PubUtils().ShowNoteNGMsg("夹具编号不能为空", 1, grade.SevereError);
                txtChildCode.Clear();
                txtChildCode.Focus();
                return;
            }
            if (txtChildCode.Text != string.Empty)
            {
                newRow = dtPanlChild.NewRow();
                newRow["id"] = dtPanlChild.Rows.Count + 1;
                newRow["WoCode"] = txtwoCodePanel.Text.Trim();
                newRow["SfcNO"] = txtSfcno.Text.Trim();
                newRow["line"] = cmbPanleLine.Text.Trim();
                newRow["code"] = txtChildCode.Text.Trim();
                #region 新增PCB类型列 2017.10.24 Zach.zhong
                string pcbType = CutCharToString();
                if (pcbType == "error")
                {
                    new PubUtils().ShowNoteNGMsg("子项编码错误!", 2, grade.OrdinaryError);
                    return;
                }
                newRow["PCBType"] = pcbType == null ? string.Empty : pcbType;
                #endregion
                #region 新增隐藏扫描时间 Zach.2017.11.24
                newRow["Createtime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                #endregion
                #region 新增板型 Zach 2017.12.07
                newRow["IsError"] = chk_x.Checked == true ? "0" : "10";
                #endregion
                dtPanlChild.Rows.Add(newRow);
            }
            //dataChildCode.Rows.Add(dgvRowscount, txtwoCodePanel.Text.Trim(), txtSfcno.Text.Trim(), cmbPanleLine.Text.Trim(), txtChildCode.Text.Trim());
            dataChildCode.DataSource = dtPanlChild;
            DataTable dtBackBanding = NMS.QueryDataTable(PubUtils.uContext, @"select BarCodeType from MdcdatProduct where ProductCode = '" + txtProduct.Text.Trim() + "'");
            if (dtBackBanding == null || dtBackBanding.Rows.Count == 0)
            {
                new PubUtils().ShowNoteNGMsg("未维护条码类别", 2, grade.OrdinaryError);
                return;
            }
            if (dtBackBanding.Rows[0][0].ToString() == "3")
            {
                chbBackBanding.Checked = true;
            }
            else
            {
                chbBackBanding.Checked = false;
            }
            //if (dgvRowscount >= panelno)
            //{
            //UUID = Guid.NewGuid().ToString();
            UUID = txtFixtureNO.Text.Trim();
            //string sqlinsert = null; 20170524
            string sqlinsert = null;

            if (chbBackBanding.Checked)
            {

            }
            else
            {
                string str_time = "_" + DateTime.Now.ToString("yyMMddHHmmss");
                //前道绑定
                sqlinsert = "delete from SfcDatFixtureCodeBands where FixtureCode='" + txtFixtureNO.Text.Trim() + "' INSERT INTO SfcDatFixtureCodeBands (Sfcno,Wocode,FixtureCode,PanelCode) values('" + txtSfcno.Text.Trim() + "','" + txtwoCodePanel.Text.Trim() + "','" + txtFixtureNO.Text.Trim() + "','" + UUID + "')";
                sqlinsert += string.Format("update TRS_Base_PCBCode set FixtureCode=FixtureCode+'{1}',PanelCode=PanelCode+'{1}' where PanelCode='{0}'", txtFixtureNO.Text.Trim(), str_time);
            }
            foreach (DataRow item in dtPanlChild.Rows)
            {
                sqlinsert += string.Format(@" INSERT INTO [dbo].[TRS_Base_PCBCode] ([FixtureCode],[WorkOrderNo],[PCBCode],[Status],[Printed],[LastProcess],[Remark],[PanelCode],[Line],[SfcNO],[Creator],[Createtime],[PCBType],[IsError])
                        VALUES ('" + txtFixtureNO.Text.Trim() + "','{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}','{10}','{11}','{12}')", item["wocode"].ToString().Trim(), item["code"].ToString().Trim(), "0", "0", "NULL", "NULL", UUID, item["line"].ToString().Trim(), item["sfcno"].ToString().Trim(), PubUtils.uContext.UserName, item["Createtime"].ToString().Trim(), item["PCBType"].ToString().Trim(), item["IsError"].ToString().Trim());
                //增加SyssystemLog日志 nancy 2017.07.27
                sqlinsert += " insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)";
                sqlinsert += " values(newid(),'" + item["line"].ToString().Trim() + "','" + item["wocode"].ToString().Trim() + "','" + item["sfcno"].ToString().Trim() + "','','','" + item["code"].ToString().Trim() + "','','','003',1,'MES-PCB绑定,PanlCode:" + UUID + "','" + PubUtils.uContext.UserName + "')";
                if (chbBackBanding.Checked)
                {
                    //                        //后道绑定
                    //                        sqlinsert += string.Format(@" INSERT INTO [dbo].[TRS_Base_PCBCode] ([FixtureCode],[WorkOrderNo],[PCBCode],[Status],[Printed],[LastProcess],[Remark],[PanelCode],[Line],[SfcNO],[Creator],[Createtime])
                    //                        VALUES ('" + txtFixtureNO.Text.Trim() + "','{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}',GETDATE())", item["wocode"].ToString().Trim(), item["code"].ToString().Trim(), "0", "0", "NULL", "NULL", txtFixtureNO.Text.Trim(), item["line"].ToString().Trim(), item["sfcno"].ToString().Trim(), PubUtils.uContext.UserName);
                    sqlinsert += @"update TRS_Busi_MachineTrace set PCBCode='" + UUID + "' from TRS_Busi_MachineTrace as a inner join TRS_Base_PCBCode as b on a.PCBCode=b.FixtureCode where a.PCBCode='" + txtFixtureNO.Text.Trim() + "'";
                }
                else
                {
                    //                        //前道绑定
                    //                        sqlinsert += string.Format(@" INSERT INTO [dbo].[TRS_Base_PCBCode] ([FixtureCode],[WorkOrderNo],[PCBCode],[Status],[Printed],[LastProcess],[Remark],[PanelCode],[Line],[SfcNO],[Creator],[Createtime])
                    //                        VALUES ('" + txtFixtureNO.Text.Trim() + "','{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}',GETDATE())", item["wocode"].ToString().Trim(), item["code"].ToString().Trim(), "0", "0", "NULL", "NULL", UUID, item["line"].ToString().Trim(), item["sfcno"].ToString().Trim(), PubUtils.uContext.UserName);
                }
            }
            if (!CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, sqlinsert))
            {
                new PubUtils().ShowNoteNGMsg("导入数据失败", 1, grade.SevereError);
                txtChildCode.Clear();
                txtChildCode.Focus();
                return;
            }
            new PubUtils().ShowNoteOKMsg("数据上传成功");
            txtChildCode.Clear();
            txtChildCode.Focus();
            if (!NMS.ExecTransql(PubUtils.uContext, @"update MdcDatFixTure set CumulativeNum=CumulativeNum+1 where FixCode='" + txtFixtureNO.Text.Trim() + "'"))
            {
                new PubUtils().ShowNoteNGMsg("夹具次数累加失败，请重新执行", 1, grade.OrdinaryError);
                return;
            }
            dtPanlChild.Clear();
            txtFixtureNO.Clear();
            txtChildCode.Clear();
            //}
            txtChildCode.Clear();
            txtChildCode.Focus();
        }

        private void txt_pcbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == ' ' || e.KeyChar == 8))//不输入输入除了数字之外的所有非法字符的判断
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// PCB类型输入框截取字符
        /// </summary>
        /// <returns></returns>
        private string CutCharToString()
        {
            if (txt_pcbType.Text == string.Empty || txt_pcbType.Text == "0")
            {
                return null;
            }
            else
            {
                try
                {
                    string str = txtChildCode.Text.Trim().Substring(int.Parse(txt_pcbType.Text.Trim()) - 1, 1);
                    return str;
                }
                catch
                {
                    return "error";
                }
            }
        }
        /// <summary>
        /// 比对位数只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_cnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == ' ' || e.KeyChar == 8))//不输入输入除了数字之外的所有非法字符的判断
            {
                e.Handled = true;
            }
        }

        private void chk_x_Click(object sender, EventArgs e)
        {
            if (chk_t.Checked)
            {
                chk_x.Checked = true;
                chk_t.Checked = false;
            }
        }

        private void chk_t_Click(object sender, EventArgs e)
        {
            if (chk_x.Checked)
            {
                chk_t.Checked = true;
                chk_x.Checked = false;

            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            FrmStationSelect frmStationSelect = new FrmStationSelect();
            frmStationSelect.group_type = "0";
            frmStationSelect._delStationRowDataHandler += GetWorkStationInfo;
            frmStationSelect.ShowDialog();
        }
        /// <summary>
        /// 获得工位信息
        /// </summary>
        /// <param name="dt"></param>
        private void GetWorkStationInfo(DataTable dt)
        {
            this.TBS_ID = dt.Rows[0]["TBS_ID"].ToString().Trim();//工艺ID
            txt_tbsName.Text = dt.Rows[0]["WORKSTATION_NAME"].ToString().Trim();//工位名
            _objIni.WriteString("Package", "TBS_ID", TBS_ID);

        }
    }
}
