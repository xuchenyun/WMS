using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIT.Interface;
using System.Configuration;
using System.Windows.Forms;
using System.Data;
using System.IO;
using CIT.Wcf.Utils;
using CIT.Global;
using System.IO.Ports;

using System.Reflection;
using System.Runtime.InteropServices;


using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using CIT.MES.Common.Helper;

namespace CIT.MES
{
    public enum grade
    {
        SevereError = 0,
        OrdinaryError = 1,
        RepeatedError = 2
    }
    /// <summary>
    /// 智能货架类型，单灯还是多灯
    /// </summary>
    public enum LGSType
    {
        /// <summary>
        /// 单灯模式
        /// </summary>
        Single,
        /// <summary>
        /// 多灯模式
        /// </summary>
        Mult
    }
    public enum MateSendType
    {
        JIT,
        First,
        Repair
    }
    public class ComUtils
    {
        private static SerialPort Sport = null;
        private static string ComIO = ConfigurationManager.AppSettings["ComIO"].ToString();
        //串口扫描枪
        public SerialPort InitCom(string ObjectName)
        {
            string portName = "";
            try
            {
                if (ComIO == "1")
                {
                    if (Sport == null)
                    {
                        string[] str = SerialPort.GetPortNames();
                        if (str == null)
                        {
                            new PubUtils().ShowNoteNGMsg("本机没有串口", 1, grade.OrdinaryError);
                            return null;
                        }
                        if (ObjectName == "PCB绑定")
                        {
                            //初始化串口
                            portName = ConfigurationManager.AppSettings["PCBbind"].ToString();
                        }
                        else if (ObjectName == "半成品入库")
                        {
                            //初始化串口
                            portName = ConfigurationManager.AppSettings["SemiStorage"].ToString();
                        }
                        else if (ObjectName == "半成品上线")
                        {
                            //初始化串口
                            portName = ConfigurationManager.AppSettings["SemiOnLine"].ToString();
                            short Cur_Port = short.Parse(ConfigurationManager.AppSettings["SemiOnLineBuzzer"].ToString());
                            int status = Module1.Brio_Open_Port(ref Handle_6, Cur_Port, 19200);
                            if (status != 0)
                            {
                                Module1.OpError(status);
                            }
                        }

                        Sport = new SerialPort(portName);
                        Sport.BaudRate = 9600;
                        Sport.Parity = Parity.None;
                        Sport.Open();//打开串口
                        Sport.DataReceived += Sport_DataReceived;
                        return Sport;
                    }
                    else
                    {
                        return Sport;
                    }
                }
                return null;
            }
            catch
            {
                new PubUtils().ShowNoteNGMsg("串口[" + portName + "]初始化失败", 1, grade.SevereError);
                return null;
            }
        }
        int Handle_6 = 0;
        public void CloseCom()
        {
            if (Sport != null)
            {
                Sport.Close();
                Sport.Dispose();
                Sport = null;
            }
            int status = Module1.Brio_Close_Port(Handle_6);
        }
        void Sport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //ComStr = Sport.ReadTo("\r");
            ComStr = Sport.ReadLine();
        }
        public void comNGbuzzer(string ObjectName, string Result)
        {
            new System.Threading.Thread(() =>
            {
                //ObjectName == "半成品上线读卡器" &&
                if (Result.ToUpper() == "OK")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Module1.Brio_Beep_Option(Handle_6);
                        //System.Threading.Thread.Sleep(5000);
                    }
                }
                if (Result.ToUpper() == "ERROR")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Module1.Brio_Beep_Option(Handle_6);
                        //System.Threading.Thread.Sleep(5000);
                    }
                }

            }) { IsBackground = true }.Start();

        }

        private string _comStr;
        public string ComStr
        {
            get { return _comStr; }
            set
            {
                _comStr = value;
                OnReceiveComData();
            }
        }
        public event EventHandler ReceiveComData;
        public void OnReceiveComData()
        {
            if (ReceiveComData != null)
            {
                ReceiveComData(this, EventArgs.Empty);
            }
        }

    }
    public class PubUtils
    {
        public enum ERPType
        {
            JinDie,
            YiFei,
            YongYou,
            SAP,
            Oracle
        }
        public static DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 列强制转换  
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }

            // 循环行  
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public static LGSType CheckLGSCustomer()
        {
            DataTable dt = Wcf.Utils.NMS.QueryDataTable(uContext, "select VAL1 from sysdatconfig where key1='lgs_customer'");
            if (dt.Rows.Count > 0)
            {
                string type=dt.Rows[0][0].ToString();
                if (type == "S")
                {
                    return LGSType.Single;
                }
                else if(type == "M")
                {
                    return LGSType.Mult;
                }
                else
                {
                    return LGSType.Single;
                }
            }
            return LGSType.Single;
        }
        public static bool CheckConnectERP(out ERPType type)
        {
            DataTable dt = Wcf.Utils.NMS.QueryDataTable(uContext, "sp_checkconnecterp");

            if (dt.Rows[0][0].ToString() == "1")
            {

                if (dt.Rows[0][1].ToString() == "1")
                {
                    type = ERPType.YiFei;
                }
                else if (dt.Rows[0][1].ToString() == "2")
                {
                    type = ERPType.JinDie;
                }
                else if (dt.Rows[0][1].ToString() == "3")
                {
                    type = ERPType.YongYou;
                }
                else if (dt.Rows[0][1].ToString() == "4")
                {
                    type = ERPType.SAP;
                }
                else if (dt.Rows[0][1].ToString() == "5")
                {
                    type = ERPType.Oracle;
                }
                else
                {
                    type = new ERPType();
                    return false;
                }
                return true;
            }
            else
            {
                type = new ERPType();
                return false;
            }
        }
        public static bool CheckConnectLGS(out string ipaddress, out string port,out LGSType lgstype)
        {
            DataTable dt = Wcf.Utils.NMS.QueryDataTable(uContext, "sp_checkconnectlgs");
            if (dt.Rows[0][0].ToString() == "1")
            {
                ipaddress = dt.Rows[0][1].ToString();
                port = dt.Rows[0][2].ToString();
                lgstype = CheckLGSCustomer();
                return true;
            }
            else
            {
                ipaddress = "";
                port = "";
                lgstype = LGSType.Single;
                return false;
            }
        }
        public static string Controller = "";

        public static bool SyncBomInfo(string wocode, string Product)
        {
            string sp = null;
            DataTable dtPrint = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select val1 from SysDatConfig where key1='SyncBOM';");

            if (dtPrint.Rows.Count > 0)
            {
                try
                {
                    sp = dtPrint.Rows[0][0].ToString();
                }
                catch
                {
                    sp = null;
                }
            }
            switch (sp)
            {
                case "FZB":
                    string url = Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, "select val1 from sysdatconfig where key1='connectSyncErp'").Rows[0][0].ToString();
                    //同步金蝶数据 需要调用服务端接口
                    string result = HttpHelper.CreatePostHttpResponse("http://" + url + "/api/ErpSync/BomSyncMes?product=" + Product + "&creator=" + PubUtils.uContext.UserName, "");
                    return true;
                    break;
                default:
                    //同步Bom信息至MES
                    PubUtils.ERPType type = new PubUtils.ERPType();
                    if (PubUtils.CheckConnectERP(out type))
                    {
                        if (type == PubUtils.ERPType.YiFei)
                        {
                            CIT.Interface.UserContext ucontext = new Interface.UserContext();
                            ucontext.Account = PubUtils.ERPAct;
                            StringBuilder str = new StringBuilder();
                            DataTable dt = NMS.QueryDataTable(ucontext, "select * from BOMCA_V where CA001='" + Product + "'");
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                str.Append(" insert into mdcdatbom(product,bunit,partnumber,punit,qty,rate,status,isenable,ver,creator,createtime) ");
                                str.Append(" values('" + Product + "','" + dt.Rows[i]["CA002"].ToString().Trim() + "','" + dt.Rows[i]["CA003"].ToString().Trim() + "','" + dt.Rows[i]["CA004"].ToString().Trim() + "','" + dt.Rows[i]["CA005"].ToString().Trim() + "','" + dt.Rows[i]["CA006"].ToString().Trim() + "','0','0','0','" + PubUtils.uContext.UserName + "',getdate()) ");
                            }
                            if (str.Length > 0)
                            {
                                string sql = " delete from mdcdatbom where product='" + Product + "' ";
                                return NMS.ExecTransql(PubUtils.uContext, sql + str.ToString());
                            }
                        }
                        return false;
                    }
                    break;
            }


            //先获取标准用量
            return false;
        }


        public static void LoginLog(string flag, bool forceout)
        {
            if (Controller.Length == 0)
                Controller = Guid.NewGuid().ToString();
            string CurIP = Core.TCPUtils.GetAddressIP();
            string Mac = Core.TCPUtils.GetMacAddress();
            if (forceout)
            {
                string str_loing = "insert into [SysDatLoginDetail](guid,userid,username,logintype,flag,mac,loginip,loginport,hostname,winver,netver,createtime,winname,forceout)";
                str_loing += " values('" + Controller + "','" + PubUtils.uContext.UserID + "','" + PubUtils.uContext.UserName + "','客户端','" + flag + "','" + Mac + "','" + CurIP + "','" + uSystem.HostPort + "','" + Environment.UserName + "','" + Environment.OSVersion + "','" + Environment.Version + "',getdate(),'" + Environment.MachineName + "','1') ";
                NMS.ExecTransql(PubUtils.uContext, str_loing);
            }
            else
            {
                string str_loing = "insert into [SysDatLoginDetail](guid,userid,username,logintype,flag,mac,loginip,loginport,hostname,winver,netver,createtime,winname,forceout)";
                str_loing += " values('" + Controller + "','" + PubUtils.uContext.UserID + "','" + PubUtils.uContext.UserName + "','客户端','" + flag + "','" + Mac + "','" + CurIP + "','" + uSystem.HostPort + "','" + Environment.UserName + "','" + Environment.OSVersion + "','" + Environment.Version + "',getdate(),'" + Environment.MachineName + "','0') ";
                NMS.ExecTransql(PubUtils.uContext, str_loing);
            }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ShowWindow(HandleRef hWnd, int nCmdShow);

        public static UserContext uContext = new UserContext();

        /// <summary>
        /// 默认解析路径
        /// </summary>
        public static string AnalysisSerPath = "0.0.0.0";

        public static string MesActs = ConfigurationManager.AppSettings["mesact"].ToString();
        public static string ERPAct = ConfigurationManager.AppSettings["erpact"].ToString();
        public static string ERPURL = "";//配置erp链接端口
        /// <summary>
        /// 获取工单状态
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static string GetWoStatus(string flag)
        {
            if (flag == "3")
            {
                return "开始生产";
            }
            else if (flag == "0")
            {
                return "同步完成";
            }
            else if (flag == "1")
            {
                return "分配完成";
            }
            else if (flag == "2")
            {
                return "工单上线";
            }
            else if (flag == "4")
            {
                return "工单暂停";
            }
            else if (flag == "5")
            {
                return "生产完成";
            }
            else if (flag == "6")
            {
                return "强制完成";
            }
            else if (flag == "7")
            {
                return "报单作废";
            }
            else if (flag == "V")
            {
                return "工单作废";
            }
            else if (flag == "8")
            {
                return "备料完成";
            }
            else
            {
                return "未知";
            }
        }

        public static DataRow GetDgvSelectRow(DataGridView dgv)
        {
            DataRow dr = null;
            for (int i = 0; i < dgv.SelectedRows.Count; i++)
            {
                dr = (dgv.SelectedRows[i].DataBoundItem as DataRowView).Row;
                if (dr != null)
                {
                    return dr;
                }
            }
            return null;
        }
        public static void SaveAppropriationSheet(AppropriationSheet appSheet)
        {
            string sql = string.Format(@"insert into [MdcDatInOutLog](WOCode,sfcno,PartNumber,HouseCode,FromHouse,Reelid,MType,Qty,line,laneno,machineid,slot,side,[DESCRIDE],Creator,Createtime,pocode)
values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',getdate(),'{15}')", appSheet.WOCode, appSheet.SfcNo, appSheet.PartNumber, appSheet.HouseCode, appSheet.FromHouse,
appSheet.ReelID, appSheet.MType, appSheet.Qty, appSheet.Line, appSheet.LaneNo, appSheet.MachineID, appSheet.Slot, appSheet.Side, appSheet.Description, appSheet.User, appSheet.POCode);
            NMS.ExecTransql(uContext, sql);
        }

        public static string SaveOutMate(OutMate mate)
        {
//            string sql = string.Format(@" insert into sfcdatoutorderno (fGUID,OrderNo,WOCode,sfcno,type,reelid,partnumber,line,laneno,machineid,tableid,slot,side,qty,status,cutstatus,cutqty,creator,createtime,updator,updatetime,localid)
//values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}',getdate(),'{17}',getdate(),'{18}')", mate.FGuid, mate.OrderNo, mate.WOCode, mate.SfcNo, mate.Type, mate.ReelID, mate.PartNumber, mate.Line, mate.LaneNo, mate.MachineNo, mate.TableID, mate.Slot, mate.Side, mate.Qty, mate.Status, mate.CutStatus, mate.CutQty, PubUtils.uContext.UserName, mate.localID);
      
            string strSql = string.Format(@"SELECT TOP 1 Close_Flag,S_Doc_NO FROM dbo.T_Bllb_StorageDoc_tbsd WHERE S_Doc_Type='7' AND PO='{0}' AND Create_Time>=CONVERT(CHAR(10),GETDATE(),120)  ORDER BY Create_Time desc", mate.MoCode);
            DataTable dt_doc= NMS.QueryDataTable(PubUtils.uContext, strSql);
            string doc_no = string.Empty;//发料单
            if (dt_doc.Rows.Count == 0 || dt_doc.Rows[0]["Close_Flag"].ToString()=="Y")
            {
                //新建单据
                dt_doc = NMS.QueryDataTable(PubUtils.uContext, string.Format("SELECT  RIGHT(S_Doc_NO,4)+1  FROM T_Bllb_StorageDoc_tbsd WHERE Create_Time>=CONVERT(CHAR(10),GETDATE(),120) AND S_Doc_Type='7'"));
                if (dt_doc.Rows.Count > 0)
                {
                    doc_no = "FL" + DateTime.Now.ToString("yyMMdd") + StringChange.ChangeNullToInt(dt_doc.Rows[0][0], 0).ToString("0000");
                }
                else
                {
                    doc_no = "FL" + DateTime.Now.ToString("yyMMdd") + "0001";
                }

                strSql = string.Format(@"INSERT INTO dbo.T_Bllb_StorageDoc_tbsd
                                                    ( S_Doc_NO ,
                                                      S_Doc_Type ,
                                                      Create_Time ,
                                                      Creator ,
                                                      PO ,
                                                      POID
                                                    )
                                            VALUES  ( '{0}' , -- S_Doc_NO - nvarchar(50)
                                                      '7' , -- S_Doc_Type - nvarchar(10)
                                                      GETDATE() , -- Create_Time - datetime
                                                      '{1}' , -- Creator - nvarchar(50)
                                                      '{2}' , -- PO - nvarchar(50)
                                                      '{3}' -- POID - nvarchar(50)      
                                                    )", doc_no, PubUtils.uContext.UserID, mate.MoCode,mate.MoId); 

                NMS.ExecTransql(PubUtils.uContext, strSql);
            }
            else
            {
                doc_no = dt_doc.Rows[0]["S_Doc_NO"].ToString();
            }
            int totalQty = 0;
            strSql = string.Format(@"SELECT S_Doc_NO,QTY FROM T_Bllb_StorageDocMaterial_tsdm WHERE S_Doc_NO='{0}' AND MaterialCode='{1}'", doc_no, mate.PartNumber);
            //判断清点单中是否已存在某物料
            DataTable dt_doc_material = NMS.QueryDataTable(PubUtils.uContext, strSql);
            if (dt_doc_material.Rows.Count == 0)
            {
                strSql = string.Format(@"INSERT INTO dbo.T_Bllb_StorageDocMaterial_tsdm
                                                    ( S_Doc_NO ,
                                                      MaterialCode ,
                                                      QTY ,
                                                      RowNumber ,
                                                      PO_DetailID,PO_DetailI_SubID 
                                                    )
                                            VALUES  ( '{0}' , -- S_Doc_NO - nvarchar(50)
                                                      '{1}' , -- MaterialCode - nvarchar(50)
                                                      {2} , -- QTY - int
                                                      {3} , -- RowNumber - int
                                                      '{4}',  -- PO_DetailID - nvarchar(50) 
                                                      '{5}'
                                                    )", doc_no, mate.PartNumber, mate.Qty, 0, mate.MoDId,mate.AllocateId);

                NMS.ExecTransql(PubUtils.uContext, strSql);
                totalQty = mate.Qty;
            }
            else
            {
                //修改单据物料发料总数
                strSql = string.Format(@"UPDATE T_Bllb_StorageDocMaterial_tsdm SET QTY=QTY+{2} WHERE S_Doc_NO='{0}' AND MaterialCode='{1}'", doc_no, mate.PartNumber, mate.Qty);
                NMS.ExecTransql(PubUtils.uContext, strSql);
                totalQty = StringChange.ChangeNullToInt(dt_doc_material.Rows[0]["QTY"].ToString(), 0) + mate.Qty;
            }
            //保存物料SN到单据中
            strSql = string.Format(@"INSERT INTO dbo.T_Bllb_StorageDocDetail_tbsdd
                                                ( S_Doc_NO ,
                                                  MaterialCode ,
                                                  QTY ,
                                                  Create_Time ,
                                                  Creator ,
                                                  SerialNumber ,  
                                                  RowNumber ,
                                                  PO_DetailID,Lot_No
                                                )
                                        VALUES  ( '{0}' , -- S_Doc_NO - nvarchar(50)
                                                  '{1}' , -- MaterialCode - nvarchar(50)
                                                  '{2}' , -- QTY - int
                                                  GETDATE() , -- Create_Time - datetime
                                                  '{3}' , -- Creator - nvarchar(50)
                                                  '{4}' , -- SerialNumber - nvarchar(50)   
                                                  '{5}' , -- RowNumber - int
                                                  '{6}',  -- PO_DetailID - nvarchar(50)
                                                   '{7}'
                                                )", doc_no, mate.PartNumber, mate.Qty, PubUtils.uContext.UserID, mate.ReelID, 0, mate.MoDId, "");

            NMS.ExecTransql(PubUtils.uContext, strSql);
            return strSql;
        }
        public class OutMate
        {
            public string FGuid { get; set; }
            public string OrderNo { get; set; }
            public string WOCode { get; set; }
            /// <summary>
            /// 生产订单ID（ERP）
            /// </summary>
            public string MoId { get; set; }
            /// <summary>
            /// 生产订单（ERP）
            /// </summary>
            public string MoCode { get; set; }
            /// <summary>
            /// 母件行号
            /// </summary>
            public string SortSeq { get; set; }
            /// <summary>
            /// 生产订单子表ID（ERP）
            /// </summary>
            public string MoDId { get; set; }
            /// <summary>
            /// 生产订单孙表（用料表）ID（ERP）
            /// </summary>
            public string AllocateId { get; set; }
            public string SfcNo { get; set; }
            public string Product { get; set; }
            public string BoardSide { get; set; }
            public string Type { get; set; }
            public string ReelID { get; set; }
            public string PartNumber { get; set; }
            public string Line { get; set; }
            public string LaneNo { get; set; }
            public string MachineNo { get; set; }
            public string TableID { get; set; }
            public string Slot { get; set; }
            public string Side { get; set; }
            public int Qty { get; set; }
            public string Status { get; set; }
            public string CutStatus { get; set; }
            public string CutQty { get; set; }
            public string localID { get; set; }
        }
        static System.Media.SoundPlayer player = null;
        public static void PlaySound(string path)
        {
            try
            {
                player = new System.Media.SoundPlayer(path);
                player.Play();
            }
            catch { }
        }
        public void ShowMsg(DataGridView dgv, MouseEventArgs e)
        {
            try
            {
                DataGridView.HitTestInfo info = dgv.HitTest(e.X, e.Y);
                object obj = dgv.Rows[info.RowIndex].Cells[info.ColumnIndex].Value;
                if (obj == null)
                    obj = "";
                if (obj.ToString().Length == 0)
                    return;
                Clipboard.SetDataObject(obj.ToString());
                FrmNote frm = new FrmNote(obj.ToString());
                PubUtils.ShowWindow(new System.Runtime.InteropServices.HandleRef(frm, frm.Handle), 4);
            }
            catch { }
        }
        public void PlayPersonSound(string Text = "PASS")
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Volume = 100;
            synth.Rate = -2;
            //SelectVoiceByHints(VoiceGender.Male, VoiceAge.Child, 2, System.Globalization.CultureInfo.CurrentCulture);
            //synth.SelectVoice("Microsoft Lili");
            synth.SelectVoice("Microsoft Anna");
            synth.Speak(Text);
        }
        /// <summary>
        /// 判断erp料号是不是需要替换
        /// </summary>
        public static bool IsErpPartNumberReplace()
        {
            string cmdsql = string.Format(@"
                  DECLARE @value int 
                  select @value=isnull(max(val1),-1) from SysDatConfig where key1='ErpPartNumberReplace'
                     if (@value=-1)
                         begin 
                        insert SysDatConfig(Cguid,Key1,val1) values(newid(),'ErpPartNumberReplace','0')
                        set @value=0 
                          end 
                    select @value
                       ");//判断erp是不是存在替代料
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, cmdsql);
            if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 配置ERP链接路径
        /// </summary>
        public static string IsErpURL()
        {
            string cmdsql = string.Format(@"
                  DECLARE @value varchar(100) 
                  select @value=isnull(max(val1),'') from SysDatConfig where key1='ErpConnectURL'
                     if (@value='')
                         begin 
                        insert SysDatConfig(Cguid,Key1,val1) values(newid(),'ErpConnectURL','http://192.168.0.118:8082/soap/IYiFeiGatewayEx')
                        set @value='http://192.168.0.118:8082/soap/IYiFeiGatewayEx' 
                          end 
                    select @value
                       ");//判断erp是不是存在替代料
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, cmdsql);
            return dt.Rows[0][0].ToString();
        }
        //public void ShowNoteNGMsgs(string msg, int closeTime = 1, bool PlaySound = true)
        //{
        //    try
        //    {
        //        if (PlaySound)
        //            PubUtils.PlaySound(@".\sound\error.wav");
        //        //System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
        //        //{
        //        HandleRef handle = new HandleRef();
        //        if (msg.Length > 20)
        //        {
        //            msg = "系统异常错误";
        //        }
        //        FrmNote frm = new FrmNote(msg, System.Drawing.Color.White, System.Drawing.Color.Red, closeTime);

        //        handle = new System.Runtime.InteropServices.HandleRef(frm, frm.Handle);
        //        PubUtils.ShowWindow(handle, 4);
        //        //}));
        //        //thread.IsBackground = true;
        //        //thread.Start();
        //    }
        //    catch { }
        //}
        /// <summary>
        /// 报错界面
        /// </summary>
        /// <param name="msg">报错信息</param>
        /// <param name="closetime">显示时间</param>
        /// <param name="Grade">错误等级</param>
        public void ShowNoteNGMsg(string msg, int closetime, grade Grade)
        {
            try
            {
                if (Grade == grade.SevereError)
                    PubUtils.PlaySound(@".\sound\SevereError.wav");
                else if (Grade == grade.OrdinaryError)
                    PubUtils.PlaySound(@".\sound\OrdinaryError.wav");
                else if (Grade == grade.RepeatedError)
                    PubUtils.PlaySound(@".\sound\Repeated.wav");
                //System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
                //{
                HandleRef handle = new HandleRef();
                if (msg.Length > 20)
                {
                    msg = "系统异常错误";
                }
                //else
                //    CIT.Client.MsgBox.Error(msg);
                FrmNote frm = new FrmNote(msg, System.Drawing.Color.White, System.Drawing.Color.Red, closetime);

                handle = new System.Runtime.InteropServices.HandleRef(frm, frm.Handle);
                PubUtils.ShowWindow(handle, 4);
                //}));
                //thread.IsBackground = true;
                //thread.Start();
            }
            catch { }
        }

        public void ShowNoteRepeatMsg(string msg, int closeTime = 1, bool PlaySound = true)
        {
            try
            {
                if (PlaySound)
                    PubUtils.PlaySound(@".\sound\error.wav");
                //System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
                //{
                HandleRef handle = new HandleRef();
                if (msg.Length > 20)
                {
                    msg = "系统异常错误";
                }
                FrmNote frm = new FrmNote(msg, System.Drawing.Color.White, System.Drawing.Color.Red, closeTime);

                handle = new System.Runtime.InteropServices.HandleRef(frm, frm.Handle);
                PubUtils.ShowWindow(handle, 4);
                //}));
                //thread.IsBackground = true;
                //thread.Start();
            }
            catch { }
        }
        public void ShowNoteOKMsg(string msg, int closeTime = 1, bool PlaySound = true)
        {
            try
            {
                if (PlaySound)
                    PubUtils.PlaySound(@".\sound\complete.wav");

                //System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
                //{
                HandleRef handle = new HandleRef();
                FrmNote frm = new FrmNote(msg, System.Drawing.Color.Blue, System.Drawing.Color.LimeGreen, closeTime);
                handle = new System.Runtime.InteropServices.HandleRef(frm, frm.Handle);
                PubUtils.ShowWindow(handle, 4);
                //}));
                //thread.IsBackground = true;
                //thread.Start();
            }
            catch { }
        }
        public static void SetConfig(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            bool flag = true;
            foreach (var item in config.AppSettings.Settings.AllKeys)
            {
                if (item.ToLower() == key)
                    flag = false;
            }
            if (flag)
            {
                config.AppSettings.Settings.Add(key, "");
            }
            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static T GetObject<T>(string Path, string Class)
        {
            Assembly assembly = Assembly.LoadFile(Path); // 加载程序集（EXE 或 DLL） 
            dynamic obj = assembly.CreateInstance(Class); // 创建类的实例 
            return (T)obj;
        }

        public void UpdateERPinfo(string wocode)
        {
            UserContext uContext = new UserContext();
            uContext.UserID = PubUtils.uContext.UserID;
            uContext.Account = PubUtils.ERPAct;
            DataTable dt = NMS.QueryDataTable(uContext, "select top 1 a.*,b.MD002 from MOCTA_V a inner join  CMSMD_V b on a.TA011=b.MD001 where TA001='" + wocode + "'");
            StringBuilder str = new StringBuilder();
            string planqty = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str.Append(" if not exists(select * from sfcdatproduct where wocode='" + wocode + "') begin ");
                string product = dt.Rows[i]["TA004"].ToString().Replace(" ", "");
                string productname = dt.Rows[i]["TA005"].ToString().Replace(" ", "");
                string isenable = dt.Rows[i]["TA003"].ToString();
                planqty = dt.Rows[i]["TA007"].ToString();
                string planstart = dt.Rows[i]["TA009"].ToString();
                string planend = dt.Rows[i]["TA010"].ToString();
                string line = dt.Rows[i]["MD002"].ToString().Replace(" ", "");
                str.Append(string.Format(@" insert into sfcdatproduct( fguid,WoCode,SfcNo,Product,Line,[Status],processid,planqty,actqty,isenable,planstart,actstart,planend,actend,Creator,Createtime,productname)
values('{1}','{0}','{0}','{2}','" + dt.Rows[i]["MD002"].ToString().Replace(" ", "") + "','1','',{3},0,'{4}','{5}',null,'{6}',null,'" + PubUtils.uContext.UserName + "',getdate(),'{7}')", wocode, Guid.NewGuid(), product, planqty, isenable, planstart, planend, productname));
                str.Append(" select '1','同步成功' end ");
                str.Append("  update  sfcdatproduct set Product='" + product + "',planqty='" + planqty + "',line='" + line + "',isenable='" + isenable + "'  where wocode='" + wocode + "' ");
                str.Append(" update PUB_MOrderProduce set Qty=cast(" + planqty + " as int) where WorkOrderNo='" + wocode + "' ");
            }
            if (str.Length > 0)
            {
                NMS.ExecTransql(PubUtils.uContext, str.ToString());
            }
        }
        /// <summary>
        /// 导入固定路径的EXCEL
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="hasTitle">是否显示标题</param>
        /// <returns></returns>
        public static DataTable GetDataFromExcel(string path, bool hasTitle = false)
        {
            try
            {
                var filePath = path;
                if (!System.IO.File.Exists(filePath))
                    return null;
                string fileType = System.IO.Path.GetExtension(filePath);
                if (string.IsNullOrEmpty(fileType)) return null;

                using (DataSet ds = new DataSet())
                {
                    string strCon = "";
                    if (fileType == ".xlsx")
                    {
                        strCon = string.Format("Provider=Microsoft.ace.OLEDB.12.0;" + "Extended Properties=\"Excel 12.0 xml;HDR={0};IMEX=1;\";" + "data source={1};",
                                     (hasTitle ? "Yes" : "NO"), filePath);
                    }
                    else
                    {
                        strCon = string.Format("Provider=Microsoft.jet.OLEDB.4.0;" + "Extended Properties=\"Excel 8.0;HDR={0};IMEX=1;\";" + "data source={1};",
                 (hasTitle ? "Yes" : "NO"), filePath);

                    }
                    try
                    {
                        using (OleDbConnection myConn = new OleDbConnection(strCon))
                        {
                            myConn.Open();
                            DataTable dt = myConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string strCom = " SELECT * FROM [Sheet1$]";
                            if (dt.Rows.Count > 0)
                                strCom = " SELECT * FROM [" + dt.Rows[0]["table_name"].ToString() + "]";

                            using (OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn))
                            {
                                myCommand.Fill(ds);
                            }
                            if (ds == null || ds.Tables.Count <= 0) return null;
                            return ds.Tables[0];
                        }
                    }
                    catch
                    {
                        CIT.Client.MsgBox.Error("读取文件失败。查看文件是否正在打开或者文件不完整。");
                        return null;
                    }
                }
            }
            catch
            {
                CIT.Client.MsgBox.Error("导入文档失败.");
                return null;
            }
        }

        /// <summary>
        /// 将数据集中的数据导出到EXCEL文件
        /// </summary>
        /// <param name="dataSet">输入数据集</param>
        /// <param name="isShowExcle">是否显示该EXCEL文件</param>
        /// <returns></returns>
        public static bool DataSetToExcel(DataTable dt, bool isShowExcle)
        {
            try
            {
                if (dt == null)
                {
                    throw new Exception("数据源为空");
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel文件|*.xlsx";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                var filePath = "";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                }
                else
                    return true;

                DataTable dataTable = dt;
                int rowNumber = dataTable.Rows.Count;//不包括字段名
                int columnNumber = dataTable.Columns.Count;
                int colIndex = 0;

                if (rowNumber == 0)
                {
                    return false;
                }

                //建立Excel对象 
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                //excel.Application.Workbooks.Add(true);
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
                excel.Visible = isShowExcle;
                //Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.Worksheets[1];
                Microsoft.Office.Interop.Excel.Range range;

                //生成字段名称 
                foreach (DataColumn col in dataTable.Columns)
                {
                    colIndex++;
                    excel.Cells[1, colIndex] = col.ColumnName;
                }

                object[,] objData = new object[rowNumber, columnNumber];

                for (int r = 0; r < rowNumber; r++)
                {
                    for (int c = 0; c < columnNumber; c++)
                    {
                        objData[r, c] = dataTable.Rows[r][c];
                    }
                    //Application.DoEvents();
                }

                // 写入Excel 
                range = worksheet.Range[excel.Cells[2, 1], excel.Cells[rowNumber + 1, columnNumber]];
                //range.NumberFormat = "@";//设置单元格为文本格式
                range.Value2 = objData;
                //worksheet.get_Range(excel.Cells[2, 1], excel.Cells[rowNumber + 1, 1]).NumberFormat = "yyyy-m-d h:mm";
                System.Reflection.Missing miss = System.Reflection.Missing.Value;
                workbook.SaveAs(filePath, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                workbook.Close(false, miss, miss);
                excel.Workbooks.Close();
                excel.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel.Workbooks);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                GC.Collect();
                return true;
            }
            catch (Exception ee)
            {
                CIT.Client.MsgBox.Error(ee.ToString());
                //CIT.Client.MsgBox.Error("保存到Excel文件失败.");
                return false;
            }
        }
    }

    public class AppropriationSheet
    {
        /// <summary>
        /// 采购订单信息
        /// </summary>
        public string POCode { get; set; }
        /// <summary>
        /// 工单信息
        /// </summary>
        public string WOCode { get; set; }
        /// <summary>
        /// 指令单
        /// </summary>
        public string SfcNo { get; set; }
        /// <summary>
        /// 物料信息
        /// </summary>
        public string PartNumber { get; set; }
        /// <summary>
        /// 目的仓库ID
        /// </summary>
        public string HouseCode { get; set; }
        /// <summary>
        /// 源仓库ID
        /// </summary>
        public string FromHouse { get; set; }
        /// <summary>
        /// 料卷ID
        /// </summary>
        public string ReelID { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string MType { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string Qty { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// 生产线ID
        /// </summary>
        public string Line { get; set; }
        /// <summary>
        /// 轨道ID
        /// </summary>
        public string LaneNo { get; set; }
        /// <summary>
        /// 设备ID
        /// </summary>
        public string MachineID { get; set; }
        /// <summary>
        /// 站位ID
        /// </summary>
        public string Slot { get; set; }
        /// <summary>
        /// 边别
        /// </summary>
        public string Side { get; set; }
    }

    public class DBHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="type">0:nvarchar 1:nvarchar,int 2:nvarchar,int,datetime </param>
        /// <returns></returns>
        public static string BlurQueryStr(string tableName, string val)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" and (t.name='nvarchar' or t.name='varchar' ");
            try
            {
                int.Parse(val);
                str.Append(" or t.name='int' or t.name ='bit' ");
            }
            catch
            {
            }
            try
            {
                Convert.ToDateTime(val);
                str.Append(" or t.name='datetime' ");
            }
            catch
            {
            }
            str.Append(")");
            return string.Format(@"select b.name as table_name,a.name as column_name,t.name type_name
        ,a.max_length ,a.precision,a.scale,isnull(c.value,N'') as memo 
from sys.columns a left join sys.tables b  on a.object_id=b.object_id and b.type=N'U'
left join sys.types t  on a.system_type_id=t.system_type_id
left join sys.extended_properties c  on b.object_id=c.major_id and a.column_id=c.minor_id
where b.name='{0}' and t.name<>'sysname' {1}
order by 1", tableName, str.ToString());
        }
        /// <summary>
        /// 获取table所有列信息
        /// </summary>
        /// <param name="uContext"></param>
        /// <param name="TableName"></param>
        /// <param name="searchVal"></param>
        /// <param name="IgnoreColumns">集合元素必须是小写</param>
        /// <param name="key">表的别名 2017.08.22 nancy</param>
        /// <returns></returns>
        public static string GetColumns(UserContext uContext, string TableName, string searchVal, List<string> IgnoreColumns)
        {
            string sql = "select name from syscolumns where id=(select max(id) from sysobjects where xtype='u' and name='" + TableName + "')";
            DataTable dt = Wcf.Utils.NMS.QueryDataTable(uContext, sql);
            StringBuilder str = new StringBuilder();
            if (dt.Rows.Count > 0)
                str.Append(" where (");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!IgnoreColumns.Contains(dt.Rows[i][0].ToString().ToLower()))
                    str.Append(" " + dt.Rows[i][0].ToString() + " like '%" + searchVal + "%' or ");
            }
            str.Remove(str.Length - 3, 3);
            str.Append(")");
            return str.ToString();
        }
        public static string GetColumns(UserContext uContext, string TableName, string searchVal, List<string> IgnoreColumns, string OtherName)
        {
            string sql = "select name from syscolumns where id=(select max(id) from sysobjects where xtype='u' and name='" + TableName + "')";
            DataTable dt = Wcf.Utils.NMS.QueryDataTable(uContext, sql);
            StringBuilder str = new StringBuilder();
            if (dt.Rows.Count > 0)
                str.Append(" where (");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!IgnoreColumns.Contains(dt.Rows[i][0].ToString().ToLower()))
                    str.Append(" " + OtherName + "." + dt.Rows[i][0].ToString() + " like '%" + searchVal + "%' or ");
            }
            str.Remove(str.Length - 3, 3);
            str.Append(")");
            return str.ToString();
        }
    }
    public class FrmUtils
    {
        public static void ShowUcControl(Panel panel, UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            uc.Show();
            panel.Controls.Clear();
            panel.Controls.Add(uc);
        }
        public static void ShowUcControl(Panel panel, Form uc)
        {
            uc.Dock = DockStyle.Fill;
            uc.TopMost = true;
            uc.TopLevel = false;
            panel.Controls.Clear();
            panel.Controls.Add(uc);
            uc.Show();
        }
        public static void ShowUcControl(TabPage tp, UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            uc.Show();
            tp.Controls.Clear();
            tp.Controls.Add(uc);
        }
        public static void AddTab(TabControl tbc, string tbpage, UserControl uc)
        {
            bool flag = true;
            foreach (TabPage item in tbc.TabPages)
            {
                if (item.Text == tbpage)
                {
                    flag = false;
                    tbc.SelectedTab = item;
                    break;
                }
            }
            //不存在进行创建
            if (flag)
            {
                TabPage tp = new TabPage();
                tp.Text = tbpage;
                tp.Name = tbpage;
                ShowUcControl(tp, uc);
                tbc.TabPages.Add(tp);
                tbc.SelectedTab = tp;
            }
        }
        public static void AddTab(TabControl tbc, string tbpage, Form uc)
        {
            bool flag = true;
            foreach (TabPage item in tbc.TabPages)
            {
                if (item.Text == tbpage)
                {
                    flag = false;
                    tbc.SelectedTab = item;
                    break;
                }
            }
            //不存在进行创建
            if (flag)
            {
                TabPage tp = new TabPage();
                tp.Text = tbpage;
                tp.Name = tbpage;
                ShowUcControl(tp, uc);
                tbc.TabPages.Add(tp);
                tbc.SelectedTab = tp;
            }
        }

        public static string ReadTempFile(string FilePath)
        {
            if (!File.Exists(FilePath))
            {
                return "Not Exist File";
            }
            using (StreamReader sr = new StreamReader(FilePath, Encoding.UTF8))
            {
                StringBuilder line = new StringBuilder();
                line.Append(sr.ReadToEnd());
                sr.Close();
                return line.ToString();
            }
        }
        /// <summary>
        /// 检查表单列设置
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="FileName"></param>
        /// <param name="dgv"></param>
        public static void CheckConfigFile(string FileName, DataGridView dgv)
        {
          
            if (!File.Exists(".\\temp\\" + FileName))
                return;
            string[] columns = ReadTempFile(".\\temp\\" + FileName).Split(',');
            for (int x = 0; x < dgv.Columns.Count; x++)
            {
                bool exists = false;
                for (int i = 0; i < columns.Length; i++)
                {
                    if (dgv.Columns[x].HeaderText == columns[i])
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                    dgv.Columns[x].Visible = false;
            }
        }
        /// <summary>
        /// 记录LOG
        /// </summary>
        /// <param name="loginfo">要记录的信息</param>
        /// <param name="logfilename">log文件名(全路径)</param>
        public static void WriteNewTempFile(string loginfo, string context)
        {
            if (!Directory.Exists(".\\temp\\"))
                Directory.CreateDirectory(".\\temp\\");
            FileStream fs = null;
            try
            {
                using (fs = new FileStream(".\\temp\\" + loginfo, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(context);
                        sw.Close();
                    }
                }
            }
            catch
            {
            }
            finally
            {
                try
                {
                    fs.Close();
                }
                catch
                { }
            }

        }
    }
}
