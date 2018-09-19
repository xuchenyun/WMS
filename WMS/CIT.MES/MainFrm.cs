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
using System.Reflection;

namespace CIT.MES
{
    public partial class MainFrm : IMainForm
    {

        public MainFrm()
        {
            InitializeComponent();
            tol_username.Text = PubUtils.uContext.UserName;
            Menu();//菜单权限        
            //维修领C料
            txTabControl1.TabpageCurrentClose += txTabControl1_TabpageCurrentClose;
            txTabControl1.TabpageCloseAll += txTabControl1_TabpageCloseAll;
            txTabControl1.TabpageCloseExcaptCurrentClose += txTabControl1_TabpageCloseExcaptCurrentClose;
            this.OnRibbonButtonClick += MainFrm_OnRibbonButtonClick;
            flag = PubUtils.CheckConnectERP(out type);

        }
        PubUtils.ERPType type = new PubUtils.ERPType();
        bool flag = false;


        void MainFrm_OnRibbonButtonClick(object sender, BtnEventArgs e)
        {
            ContextMenuStrip cMS = new System.Windows.Forms.ContextMenuStrip();
            System.Windows.Forms.ToolStripMenuItem tsmi1 = new ToolStripMenuItem();
            System.Windows.Forms.ToolStripMenuItem tsmi2 = new ToolStripMenuItem();

            cMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            tsmi2,
            tsmi1});

            tsmi2.Name = "tsmi2";
            tsmi2.Size = new System.Drawing.Size(152, 22);
            tsmi2.Text = "系统设置";
            tsmi2.Click += tsmi2_Click;

            tsmi1.Name = "tsmi1";
            tsmi1.Size = new System.Drawing.Size(152, 22);
            tsmi1.Text = "退出";
            tsmi1.Click += tsmi1_Click;
            cMS.Show(MousePosition);
        }

        void tsmi1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void tsmi2_Click(object sender, EventArgs e)
        {
            Setting.FrmSetting frm = new Setting.FrmSetting();
            frm.ShowDialog();
        }

        void HideAllBtn(System.Windows.Forms.Control con)
        {
            foreach (var item in con.Controls)
            {
                if (item is DevComponents.DotNetBar.ButtonX)
                {
                    ((DevComponents.DotNetBar.ButtonX)item).Visible = false;
                }
                else
                {
                    HideAllBtn((System.Windows.Forms.Control)item);
                }
            }

        }

        /// <summary>
        /// 菜单权限
        /// </summary>
        private void Menu()
        {
            //是否显示标签设计群组
            bool bargroup = false;

            HideAllBtn(this);
            foreach (var item in toolStrip2.Items)
            {
                if (item is System.Windows.Forms.ToolStripButton)
                {
                    ((System.Windows.Forms.ToolStripButton)item).Visible = false;
                }
            }

            string sql = "select a.MenuCode,b.MenuName,b.description from SysOrgMenuMap a inner join SysdatMenu b on a.menucode=b.menucode where OrgID in(select OrgID from MdcDatOrgUserMap where UserID='" + PubUtils.uContext.UserID + "')";
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, sql);
            DataRow[] drArr = dt.Select(" MenuCode='winfrmwocode'");//工单查询（制令单管理）
         



            drArr = dt.Select(" MenuCode='winfrmdescbarcode'");//条码设计
            if (drArr.Length > 0)
                btn_de_barcode.Visible = true;
            else
                bargroup = true;


            drArr = dt.Select(" MenuCode='WinfrmInventory'");//盘点单
            if (drArr.Length > 0)
                btn_inventory.Visible = true;

            drArr = dt.Select(" MenuCode='WinfrmInventoryDetail'");//盘点单明细
            if (drArr.Length > 0)
                btn_inventoryDetail.Visible = true;

            drArr = dt.Select(" MenuCode='WinfrmInventoryDetailManager'");//盘点单明细管理
            if (drArr.Length > 0)
                btn_inventoryManager.Visible = true;

            drArr = dt.Select(" MenuCode='WinfrmInventoryCollect'");//盘点汇总
            if (drArr.Length > 0)
                btn_inventoryCollect.Visible = true;

            if (!bargroup)
            {
                xPanderPanel6.Visible = true;
            }
            drArr = dt.Select(" MenuCode='extend_ucCustomerManage'");//客户管理
            if (drArr.Length > 0)
            {
                btn_customer.Visible = true;
            }
            drArr = dt.Select(" MenuCode='extend_ucSuppliesManage'");//供应商管理
            if (drArr.Length > 0)
            {
                btnSupplies.Visible = true;
            }
            //IQC
            //drArr = dt.Select(" MenuCode='extend_ucStrorageDocQuery'");
            if (drArr.Length > 0)
            {
                btn_IQC.Visible = true;
            }
            drArr = dt.Select(" MenuCode='extend_ucStorageManage'");//容器管理
            if (drArr.Length > 0)
            {
                btn_Container.Visible = true;
            }
            drArr = dt.Select(" MenuCode='extend_ucMaterialQuery'");//物料管理
            if (drArr.Length > 0)
            {
                btn_MaterialQuery.Visible = true;
            }
            //有效期管理
            //drArr = dt.Select(" MenuCode='extend_ucOrgUser'");
            btn_ExpiryDate.Visible = true;
            //if (drArr.Length > 0)
            //{
            //    btn_ExpiryDate.Visible = true;
            //}
            //半成品/成品入库
            drArr = dt.Select(" MenuCode='extend_ucSemiAndFinishedWareHousing'");
            if (drArr.Length > 0)
            {
                btn_SemiAndFinished.Visible = true;
            }   
            drArr = dt.Select(" MenuCode='extend_ucStockAll'");//库存汇总
            if (drArr.Length > 0)
            {
                btn_stockQuery.Visible = true;
            }
            drArr = dt.Select(" MenuCode='extend_ucStockQuery'");//库存查询
            if (drArr.Length > 0)
            {
                btn_stockAll.Visible = true;
            }
            //库存调整
            //drArr = dt.Select(" MenuCode='extend_ucBatchCutReel'");
            if (drArr.Length > 0)
            {
                btn_InventoryAdjustment.Visible = true;
            }
            //辅料管理
            //drArr = dt.Select(" MenuCode='extend_ucMaterialRelation'");
            if (drArr.Length > 0)
            {
                btn_AuxiliaryMaterials.Visible = true;
            }
            //产品管理
            //drArr = dt.Select(" MenuCode='extend_ucMaterialRelation'");
            if (drArr.Length > 0)
            {
                btn_Product.Visible = true;
            }
            //生产退料入库            
            //drArr = dt.Select(" MenuCode='extend_CreateDocManage'");
            if (drArr.Length > 0)
            {
                btn_ProducteRetreating.Visible = true;
            }
            //成品销售出库
            drArr = dt.Select(" MenuCode='extend_ucSalesOfFinishedQroducts'");
            if (drArr.Length > 0)
            {
                btn_FinishedSale.Visible = true;
            }
            //生产领料出库
            //drArr = dt.Select(" MenuCode='extend_CreateDocManage'");
            if (drArr.Length > 0)
            {
                btn_Productepicking.Visible = true;
            }
            //检查项目
            //drArr = dt.Select(" MenuCode='extend_CreateDocManage'");
            if (drArr.Length > 0)
            {
                btn_CheckProject.Visible = true;
            }
            //IQC执行
            //drArr = dt.Select(" MenuCode='extend_CreateDocManage'");
            if (drArr.Length > 0)
            {
                btn_IQCImplement.Visible = true;
            }
            //标签数据源
            //drArr = dt.Select(" MenuCode='extend_ucMaterialRelation'");
            if (drArr.Length > 0)
            {
                btn_LabelDateBase.Visible = true;
            }
            //生产标签打印            
            //drArr = dt.Select(" MenuCode='extend_CreateDocManage'");
            if (drArr.Length > 0)
            {
                btn_LabelPrinting.Visible = true;
            }
            //数据同步
            //drArr = dt.Select(" MenuCode='extend_CreateDocManage'");
            if (drArr.Length > 0)
            {
                btn_DataSynchronization.Visible = true;
            }
            //用户设定
            //drArr = dt.Select(" MenuCode='extend_CreateDocManage'");
            if (drArr.Length > 0)
            {
                btn_UserSetUp.Visible = true;
            }
            //角色设定
            //drArr = dt.Select(" MenuCode='extend_CreateDocManage'");
            if (drArr.Length > 0)
            {
                btn_RoleSetUp.Visible = true;
            }
            //权限设定
            //drArr = dt.Select(" MenuCode='extend_CreateDocManage'");
            if (drArr.Length > 0)
            {
                btn_SetUpJurisdiction.Visible = true;
            }


            //入库通知            
            //drArr = dt.Select(" MenuCode='extend_CreateDocManage'");
            if (drArr.Length > 0)
            {
                btn_StorageNotice.Visible = true;
            }
            //收货确认
            //drArr = dt.Select(" MenuCode='extend_CreateDocManage'");
            if (drArr.Length > 0)
            {
                btn_RecipientConfirm.Visible = true;
            }
            //收货履历
            //drArr = dt.Select(" MenuCode='extend_CreateDocManage'");
            if (drArr.Length > 0)
            {
                btn_RecipientResume.Visible = true;
            }
            //标签打印
            //drArr = dt.Select(" MenuCode='extend_CreateDocManage'");
            if (drArr.Length > 0)
            {
                btn_TagPrint.Visible = true;
            }
            //打印履历
            //drArr = dt.Select(" MenuCode='extend_CreateDocManage'");
            if (drArr.Length > 0)
            {
                btn_PrintResume.Visible = true;
            }
            //密码修改
            tolPwd.Visible = true;
        }
        void DynAddButton(string name, string Text, string tag)
        {
            DevComponents.DotNetBar.ButtonX btn = new DevComponents.DotNetBar.ButtonX();
            btn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            btn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            btn.Dock = System.Windows.Forms.DockStyle.Top;
            btn.Image = global::CIT.MES.Properties.Resources.extend;
            btn.ImageFixedSize = new System.Drawing.Size(40, 35);
            btn.Location = new System.Drawing.Point(1, 25);
            btn.Name = name;
            btn.Tag = tag;
            btn.Size = new System.Drawing.Size(205, 50);
            btn.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            btn.TabIndex = 25;
            btn.Text = Text;
            btn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            btn.Click += btn_menu_Click;
            this.xPanderPanel3.Controls.Add(btn);
        }

        void txTabControl1_TabpageCloseExcaptCurrentClose(object sender, EventArgs e)
        {
            foreach (TabPage item in txTabControl1.TabPages)
            {
                if (item != txTabControl1.SelectedTab)
                    item.Dispose();
            }
        }

        void txTabControl1_TabpageCloseAll(object sender, EventArgs e)
        {
            foreach (TabPage item in txTabControl1.TabPages)
            {
                item.Dispose();
            }
        }

        void txTabControl1_TabpageCurrentClose(object sender, EventArgs e)
        {
            txTabControl1.SelectedTab.Dispose();
        }

        void btn_menu_Click(object sender, EventArgs e)
        {
            string menu = ((DevComponents.DotNetBar.ButtonX)sender).Text;
            if (((DevComponents.DotNetBar.ButtonX)sender).Name.ToLower().Contains("extend"))
            {
                try
                {
                    //反射调用程序
                    //返回form或者uc
                    //tabcontrol加载
                    string temp = ((DevComponents.DotNetBar.ButtonX)sender).Tag.ToString().Replace("extend", "");
                    string path = AppDomain.CurrentDomain.BaseDirectory + "Extend\\" + temp.Split('$')[0];
                    string Class = temp.Split('$')[1].ToString();
                    object frm = PubUtils.GetObject<object>(path, Class);
                    if (frm is Form)
                    {
                        Form f = (Form)frm;
                        FrmUtils.AddTab(txTabControl1, menu, f);
                    }
                    else if (frm is UserControl)
                    {
                        UserControl u = (UserControl)frm;
                        FrmUtils.AddTab(txTabControl1, menu, u);
                    }
                }
                catch { }
            }
            ShowForm(menu);
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            ShowForm(e.ClickedItem.Text);
        }
        void ShowForm(string menu)
        {
            //写日志信息
            string sql = string.Format(@"if not exists(select *from MdcDatMenuCount where MenuCode='{0}')
begin
insert into MdcDatMenuCount (MenuCode,count)values('{0}','1')
end
else
begin
update MdcDatMenuCount set count=count+1 where MenuCode='{0}'
end", menu);
            NMS.ExecTransql(PubUtils.uContext, sql);
            switch (menu)
            {
                case "客户管理":
                    FrmUtils.AddTab(txTabControl1, menu, (UserControl)Assembly.LoadFile(Application.StartupPath + "\\BaseData.dll").CreateInstance("BaseData.UI.ucCustomerManage"));
                    break;

                case "供应商管理":
                    FrmUtils.AddTab(txTabControl1, menu, (UserControl)Assembly.LoadFile(Application.StartupPath + "\\BaseData.dll").CreateInstance("BaseData.UI.ucSuppliesManage"));
                    break;

                case "仓库管理":
                    FrmUtils.AddTab(txTabControl1, menu, (UserControl)Assembly.LoadFile(Application.StartupPath + "\\Warehouse.dll").CreateInstance("Warehouse.UI.ucStorageManage"));
                    break;

                case "物料管理":
                    FrmUtils.AddTab(txTabControl1, menu, (UserControl)Assembly.LoadFile(Application.StartupPath + "\\BaseData.dll").CreateInstance("BaseData.UI.ucMaterialQuery"));
                    break;

                //case "有效期管理":
                case "库区类型管理":
                    FrmUtils.AddTab(txTabControl1, menu, (UserControl)Assembly.LoadFile(Application.StartupPath + "\\Warehouse.dll").CreateInstance("Warehouse.UI.ucAreaType"));
                    break;

                case "辅料管理":

                    break;

                case "产品管理":

                    break;

                case "库存查询":
                    FrmUtils.AddTab(txTabControl1, menu, (UserControl)Assembly.LoadFile(Application.StartupPath + "\\Warehouse.dll").CreateInstance("Warehouse.UI.ucStockQuery"));
                    break;                

                case "库存调整":
                    //FrmUtils.AddTab(txTabControl1, menu, (UserControl)Assembly.LoadFile(Application.StartupPath + "\\Warehouse.dll").CreateInstance("Warehouse.UI.ucBatchCutReel"));
                    break;

                case "采购入库":
                    break;

                case "IQC":

                    break;

                case "半成品/成品入库":
                    FrmUtils.AddTab(txTabControl1, menu, (UserControl)Assembly.LoadFile(Application.StartupPath + "\\Warehouse.dll").CreateInstance("Query.UI.ucSemiAndFinishedWareHousing"));
                    break;

                case "生产退料入库":

                    break;

                case "成品销售出库":
                    FrmUtils.AddTab(txTabControl1, menu, (UserControl)Assembly.LoadFile(Application.StartupPath + "\\Warehouse.dll").CreateInstance("Query.UI.ucSalesOfFinishedQroducts"));
                    break;

                case "生产领料出库":

                    break;

                case "检验项目":

                    break;

                case "IQC执行":

                    break;
                
                case "盘点单":
                    FrmUtils.AddTab(txTabControl1, menu, (UserControl)Assembly.LoadFile(Application.StartupPath + "\\Warehouse.dll").CreateInstance("Warehouse.UI.ucInventoryManager"));
                    break;

                case "盘点单明细":
                    FrmUtils.AddTab(txTabControl1, menu, (UserControl)Assembly.LoadFile(Application.StartupPath + "\\Warehouse.dll").CreateInstance("Warehouse.UI.ucInventoryDetail"));
                    break;

                case "盘点单明细管理":
                    FrmUtils.AddTab(txTabControl1, menu, (UserControl)Assembly.LoadFile(Application.StartupPath + "\\Warehouse.dll").CreateInstance("Warehouse.UI.ucInventoryDetailManager"));
                    break;

                case "盘点汇总":
                    FrmUtils.AddTab(txTabControl1, menu, (UserControl)Assembly.LoadFile(Application.StartupPath + "\\Warehouse.dll").CreateInstance("Warehouse.UI.ucInventoryCollect"));
                    break;

                case "标签格式设计":
                    FrmUtils.AddTab(txTabControl1, menu, new BarCode.ucBarcode());
                    break;

                case "标签数据源":

                    break;

                case "生产标签打印":

                    break;

                case "数据同步":

                    break;

                case "用户设定":

                    break;

                case "角色设定":

                    break;

                case "权限设定":

                    break;

                case "入库确认":

                    break;

                case "收货确认":

                    break;

                case "收货履历":

                    break;

                case "标签打印":

                    break;

                case "打印履历":

                    break;
            }
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MsgBox.Question("确认是否关闭") == DialogResult.OK)
            {
                e.Cancel = true;
                PubUtils.LoginLog("1", ForceOut);
                e.Cancel = false;
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
        bool ForceOut = false;
        private void tmr_checkLogin_Tick(object sender, EventArgs e)
        {
            string sql = "select top 1* from SysDatLoginDetail where userid='" + PubUtils.uContext.UserID + "' and flag='0' order by Createtime desc";
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, sql);
            if (dt.Rows.Count == 0)
            {
                tmr_checkLogin.Stop();
                ForceOut = true;
                PubUtils.LoginLog("1", ForceOut);
                MsgBox.Error("系统登录异常,请重新登录.");
                //通过线程关闭
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            else
            {
                if (dt.Rows[0]["guid"].ToString() != PubUtils.Controller)
                {
                    tmr_checkLogin.Stop();
                    ForceOut = true;
                    PubUtils.LoginLog("1", ForceOut);
                    FrmLoginException frm = new FrmLoginException("用户【" + PubUtils.uContext.UserName + "】被异地登录", "主机名称【" + dt.Rows[0]["winName"].ToString() + "】 IP地址【" + dt.Rows[0]["loginip"].ToString() + "】");
                    frm.ShowDialog();
                    //MsgBox.Error("当前用户在异地登录,IP地址【" + dt.Rows[0]["loginip"].ToString() + "】");
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            }
        }

        private void tmr_time_Tick(object sender, EventArgs e)
        {
            tol_time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void tim_checkwo_Tick(object sender, EventArgs e)
        {
            GetRefresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FrmUtils.AddTab(txTabControl1, "来料打印", new WMS.BRIO.ucBRIO());
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            foreach (var item in xPanderPanel6.Parent.Controls)
            {
                if (item is CIT.Client.XPanderPanel)
                {
                    int i = 0;
                    foreach (var item1 in ((CIT.Client.XPanderPanel)item).Controls)
                    {
                        if (((DevComponents.DotNetBar.ButtonX)item1).Visible == true)
                        {
                            i++;
                        }
                    }
                    if (i == 0)
                    {
                        ((CIT.Client.XPanderPanel)item).Visible = false;
                    }
                }
            }
        }
        void GetRefresh()
        {
            if (flag)
            {
                if (type == PubUtils.ERPType.YiFei)
                {
                    new System.Threading.Thread(new System.Threading.ThreadStart(delegate
                    {
                        UserContext uContext = new UserContext();
                        uContext.UserID = PubUtils.uContext.UserID;
                        uContext.Account = PubUtils.ERPAct;
                        DataTable dt = NMS.QueryDataTable(uContext, "select DISTINCT a.TA001,a.TA003,a.TA004,a.TA005,a.TA007,a.TA009,a.TA010,b.MD002 from MOCTA_V a left join  CMSMD_V b on a.TA011=b.MD001 where  datediff(day,convert(date,SUBSTRING(a.CREATE_DATE,0,9)),GETDATE())<2");
                        StringBuilder str = new StringBuilder();
                        int planqty = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string wocode = dt.Rows[i]["TA001"].ToString();
                            str.Append(" if not exists(select * from sfcdatproduct where wocode='" + wocode + "') begin ");
                            string product = dt.Rows[i]["TA004"].ToString().Replace(" ", "");
                            string productname = dt.Rows[i]["TA005"].ToString().Replace(" ", "");
                            string isenable = dt.Rows[i]["TA003"].ToString().Replace(" ", "");
                            planqty = Convert.ToInt32(dt.Rows[i]["TA007"].ToString().Replace(" ", "").Split('.')[0]);
                            string planstart = dt.Rows[i]["TA009"].ToString().Replace(" ", "");
                            string planend = dt.Rows[i]["TA010"].ToString().Replace(" ", "");
                            str.Append(string.Format(@" insert into sfcdatproduct( fguid,WoCode,SfcNo,Product,Line,[Status],processid,planqty,actqty,isenable,planstart,actstart,planend,actend,Creator,Createtime,productname)
values('{1}','{0}','{0}','{2}','" + dt.Rows[i]["MD002"].ToString().Replace(" ", "") + "','1','',{3},0,'{4}','{5}',null,'{6}',null,'" + PubUtils.uContext.UserName + "',getdate(),'{7}')", wocode, Guid.NewGuid(), product, planqty, isenable, planstart, planend, productname));
                            str.Append("  end ");
                            str.Append(" else  begin  update  sfcdatproduct set planqty='" + planqty + "',isenable='" + isenable + "'  where wocode='" + wocode + "'  end ");
                        }
                        NMS.ExecTransql(PubUtils.uContext, str.ToString());

                    }))
                    { IsBackground = true }.Start();
                }
            }
        }

        private void btn_SysPara_Click(object sender, EventArgs e)
        {

        }

        private void tolPwd_Click(object sender, EventArgs e)
        {
            FrmUtils.AddTab(txTabControl1, "密码修改", (UserControl)Assembly.LoadFile(Application.StartupPath + "\\BaseData.dll").CreateInstance("BaseData.UI.uc_ResetPwd"));
        }

    }
}
