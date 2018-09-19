using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIT.Client;
using CIT.Wcf.Utils;
using CIT.Interface;
using CIT.Global;
using System.Configuration;

using System.Diagnostics;

namespace CIT.MES
{
    public partial class FrmLogin :  BaseForm
    {
        public FrmLogin()
        {
            InitializeComponent();
            int SH = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            int SW = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Location = new Point(SW, SH);

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            bool flag = true;
            bool flag_ver = true;
            foreach (var item in config.AppSettings.Settings.AllKeys)
            {
                if (item.ToLower() == "loginuser")
                    flag = false;
            }
            if (flag)
            {
                config.AppSettings.Settings.Add("loginuser", "");
            }
            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
            //txt_Userlogin.Text = System.Configuration.ConfigurationManager.AppSettings["loginuser"];
            uSystem.HostIPAddress = ConfigurationManager.AppSettings["serip"].ToString();
            uSystem.HostPort = int.Parse(ConfigurationManager.AppSettings["serport"].ToString());
            PubUtils.uContext.Account = PubUtils.MesActs;
            txt_Userlogin.LostFocus += txt_Userlogin_LostFocus;
            txt_Userlogin.GotFocus += txt_Userlogin_GotFocus;


            //BarcodeUtils obj = new BarcodeUtils();
            //BarcodeUtils.BarObject sss5 = obj.AnalysisBarcode(@"http://174.36.249.85:10001/uaes/cq?barcode=","[)>@06@12S0002@P8905708027@1PSP000757916@31PSP000757916@12V341137102@10VAUT-CHN@2P@20P@6D20170313@14D20190319@30PY@Z01@K55012403/001@16K4025367319@V84069@3SS000001484609@Q3000NAR000@20T1@1TVC6490852I7@2T@1Z@@");
            //BarcodeUtils.BarObject sss = obj.AnalysisBarcode(@"http://174.36.249.85:10001/uaes/cq?barcode=[)>@06@12S0002@P1267370471@1PT491D476K010AT4802@31PT491D476K010AT4802@12VKEMET001@10VMEX-87380@2P@20P@6D20170320@14D20190320@30PY@Z1@K5100001190@16K0@V46852@3SS170790000118@Q2500NAR000@20T1@1T1707ME471@2T@1Z@@");
            //BarcodeUtils.BarObject sss1 = obj.AnalysisBarcode("http://174.36.249.85:10001/uaes/cq?barcode=[)>@06@12S0002@P3337617280@1PI50302507@31PC1608X7R2A472KTNY9N@12V529898793@10VCHN-SUZHOU0@2P01@20P@6D20170322@14D20180322@30PY@ZN@K0@16K0@V101165@3SSIA17C206371P@Q10000NAR000@20T1@1TIA17C20637@2T@1ZS7C106143@@");
            //BarcodeUtils.BarObject sss2 = obj.AnalysisBarcode("http://174.36.249.85:10001/uaes/cq?barcode=[)>@06@12S0002@P1267369223@1PEXS00A-00482@31PEXS00A-00482_20.000MHZ@12V654265701@10VCHN-SUZHOU@2P@20P@6D20170304@14D20180304@30PY@Z1@K0@16KX6114724-4@V101223@3SSX6L472414631@Q1000NAR000@20T1@1TX6114724-4@2T@1ZNX5032GA@@");
            //BarcodeUtils.BarObject sss3 = obj.AnalysisBarcode("http://174.36.249.85:10001/uaes/cq?barcode=[)>@06@12S0002@P1267360636@1PRK73H1ETTP4642F@31PRK73H1ETTP4642F@12V0000101849@10VCHN-O@2P@20P@6D20170427@14D20190417@30PY@ZN@K5100012698@16K2017015524@V101849@3SS8524T6619718@Q10000NAR000@20T1@1T8524T661@2T@1Z20170427@@");
            //BarcodeUtils.BarObject sss4 = obj.AnalysisBarcode("http://174.36.249.85:10001/uaes/cq?barcode=[)>@06@12S0002@P1267360636@1PRK73H1ETTP4642F@31PRK73H1ETTP4642F@12V0000101849@10VCHN-O@2P@20P@6D20170427@14D20190417@30PY@ZN@K5100012698@16K2017015524@V101849@3SS8524T6619718@Q10000NAR000@20T1@1T8524T661@2T@1Z20170427@@");

            //BarcodeUtils.BarObject sss = obj.AnalysisBarcode("0.0.0.0=AA1234567890");

        }

        void txt_Userlogin_GotFocus(object sender, EventArgs e)
        {
            if (username.Length > 0)
            {
                txt_Userlogin.Text = username;
            }
            //throw new NotImplementedException();
        }
        string userid = "";
        string username = "";
        void txt_Userlogin_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (txt_Userlogin.Text.Length > 0)
                {
                    txt_Userlogin.Enabled = false;
                    username = txt_Userlogin.Text;
                    userid = txt_Userlogin.Text;
                    new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(delegate
                    {
                        try
                        {
                            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, "select username from sysdatuser where userid='" + userid + "'");
                            if (dt.Rows.Count > 0)
                            {
                                this.Invoke(new Action(delegate
                                {
                                    txt_Userlogin.Text = dt.Rows[0][0].ToString();
                                    txt_Userlogin.Enabled = true;
                                    //txt_pawlogin.SelectAll();
                                    txt_pawlogin.Focus();
                                }));
                            }
                        }
                        catch (Exception ee) { if (ee.Message.Length < 20) MsgBox.Error(ee.Message); }
                    }))
                    { IsBackground = true }.Start();
                }
            }
            catch { }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //new PubUtils().PlayPersonSound();
            label3.Text = "";
            if (txt_Userlogin.Text.Length == 0)
            {
                label3.Text = "提示:用户名不可为空.";
                label3.ForeColor = Color.Red;
                return;
            }
            if (txt_pawlogin.Text.Length == 0)
            {
                label3.Text = "提示:密码不可为空.";
                label3.ForeColor = Color.Red;
                txt_pawlogin.Focus();
                return;
            }
            label3.Text = "";
            PubUtils.uContext.UserID = userid;
            PubUtils.uContext.Password = txt_pawlogin.Text;

            string sql = "select isnull(max(UserName),0) from SysDatUser where UserID='" + userid + "'";//获取用户姓名
            string sql_logincheck = "select top 1 * from [SysDatLoginDetail] where userid='" + userid + "' and flag='0' order by createtime desc";
            this.Waiting(delegate
            {
                try
                {
                    DataTable dt = NMS.QueryDataTable(PubUtils.uContext, sql);
                    if (dt.Rows.Count > 0)
                    {
                        PubUtils.uContext.UserName = dt.Rows[0][0].ToString().Trim();//查找数据库是否存在此条码
                        //if (NMS.LoginUser(PubUtils.uContext))
                        if(true)
                        {
                            DataTable dt_barcode = NMS.QueryDataTable(PubUtils.uContext, "select val1 from sysdatconfig where key1='barcodeanlysis'");
                            if (dt_barcode.Rows.Count > 0 && dt_barcode.Rows[0][0] != null && dt_barcode.Rows[0][0].ToString().Length > 0)
                            {
                                PubUtils.AnalysisSerPath = dt_barcode.Rows[0][0].ToString();
                            }
                            else
                            {
                                PubUtils.AnalysisSerPath = "0.0.0.0";
                            }
                            //string a = NMS.GetPnUniqueCode(PubUtils.uContext, "sfdsfds,343fds,1ewew,343fdsa,", "E808A86F-9C88-491D-824C-5B43FF3AD309");
                            //检验服务器版本信息
                            //string ver = NMS.CheckVer();
                            //string a = Application.ProductVersion;
                            //if (a.Split('.')[0] != ver.Split('.')[0])
                            //{
                            //    MsgBox.Error("客户端版本和服务器端版本不一致");
                            //    return;
                            //}
                            //判断上次登录的IP地址是否和当前登录的一致
                            //DataTable dt_login = NMS.QueryDataTable(PubUtils.uContext, sql_logincheck);
                            //if (dt_login.Rows.Count > 0)
                            //{
                            //    string LoginIP = dt_login.Rows[0]["LoginIP"].ToString();
                            //    if (CurIP == LoginIP)
                            //    {

                            //    }
                            //}
                            PubUtils.LoginLog("0", false);
                            this.Invoke(new Action(delegate
                            {
                                this.RealHide();
                                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                                config.AppSettings.Settings["loginuser"].Value = PubUtils.uContext.UserID;
                                config.Save(ConfigurationSaveMode.Full);
                                ConfigurationManager.RefreshSection("appSettings");
                                #region 获取erp接口url nancy 2007.08.03
                                PubUtils.ERPURL = PubUtils.IsErpURL();
                                #endregion
                                try
                                {
                                    Utils.existsTable();
                                    MainFrm frm = new MainFrm();
                                    frm.ShowDialog();

                                    //MainFrm_New f = new MainFrm_New();
                                    //f.ShowDialog();

                                    //FrmSLRecordSeach frd = new FrmSLRecordSeach();
                                    //frd.ShowDialog();

                                    //test Test = new test();
                                    //Test.ShowDialog();
                                }
                                catch (Exception ex)
                                {
                                    if (MsgBox.Error("错误：" + ex.Message + "\n\t系统即将退出！") == DialogResult.OK)
                                    {
                                        Application.Exit();
                                    }
                                }
                                Application.Exit();
                            }));
                        }
                        else
                        {
                            label3.Text = "提示:登录失败.";
                            label3.ForeColor = Color.Red;
                            //new PubUtils().ShowNoteNGMsg("登录失败", 2);
                            txt_pawlogin.Text = "";
                            txt_pawlogin.Focus();
                        }
                    }
                    else
                    {
                        this.Invoke(new Action(delegate
                            {
                                label3.Text = "提示:不存在用户.";
                                label3.ForeColor = Color.Red;
                                txt_Userlogin.SelectAll();
                                txt_Userlogin.Focus();
                                return;
                            }));
                    }
                }
                catch (Exception ee)
                {
                    if (ee.Message.Length < 20)
                        new PubUtils().ShowNoteNGMsg(ee.Message, 1, grade.SevereError);
                }
            });
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txt_pawlogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btn_login.PerformClick();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                FileUpdate.SoftVer checkVer = new FileUpdate.SoftVer();
                string thisUri = System.Windows.Forms.Application.StartupPath;
                //版本不一致启动更新
                if (!checkVer.CheckVer())
                {
                    Process.Start(thisUri + "//FileUpdate.exe");
                    this.Close();
                }
            }
            catch (Exception ex) { }
        }

        private void txt_Userlogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_pawlogin.SelectAll();
                txt_pawlogin.Focus();
            }
        }
    }
}
