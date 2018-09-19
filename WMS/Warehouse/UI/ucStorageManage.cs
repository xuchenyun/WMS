using Common.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse.BLL;

namespace Warehouse.UI
{
    public partial class ucStorageManage : UserControl
    {
        #region 变量
        /// <summary>
        /// 操作类型1：新增；2：编辑
        /// </summary>
        public string _opreateFlag = string.Empty;
        public DataTable _dt_storage = null;
        public DataTable _dt_container = null;
        #endregion
        #region 构造函数
        public ucStorageManage()
        {
            InitializeComponent();
            //dgv_Container.AutoGenerateColumns = false;
            DataBindToType();
            InitTreeData();
            //DataTable dt_Step = Common.BLL.Bll_Common.GetSysParameter("JB");
            //DataRow dr = dt_Step.NewRow();
            //dr["DICT_VALUE"] = string.Empty;
            //dr["DICT_CODE"] = string.Empty;
            //dt_Step.Rows.InsertAt(dr, 0);
            //cbo_Step.DataSource = dt_Step;
            //cbo_Step.DisplayMember = "DICT_VALUE";
            //cbo_Step.ValueMember = "DICT_CODE";
            //***xcy 2018-9-19
            this.lbl_AreaType.Visible = false;
            this.cmb_AreaType.Visible = false;
        }
        #endregion
        #region 初始化树
        /// <summary>
        /// 初始化树
        /// </summary>
        private void InitTreeData()
        {
            while (true)
            {
                try
                {
                    tv_Storage.Nodes.Remove(tv_Storage.Nodes[0]);
                }
                catch
                {
                    break;
                }

            }
            _dt_storage = BLL.Bll_Bllb_Storage_tbs.GetListOfAll();

            string storage_sn = string.Empty;//仓库SN
            TreeNode storage_Node = null;//仓库节点
            TreeNode area_Node = null;//库区节点
            string area_sn = string.Empty;//库区SN
            for (int i = 0; i < _dt_storage.Rows.Count; i++)
            {
                #region 仓库

                if (SqlInput.ChangeNullToString(_dt_storage.Rows[i]["Storage_SN"].ToString()) == string.Empty)
                {
                    continue;
                }
                else if (storage_sn != SqlInput.ChangeNullToString(_dt_storage.Rows[i]["Storage_SN"].ToString()))
                {
                    storage_sn = SqlInput.ChangeNullToString(_dt_storage.Rows[i]["Storage_SN"].ToString());//仓库SN
                    storage_Node = new TreeNode();
                    storage_Node.Text = _dt_storage.Rows[i]["Storage_Name"].ToString();
                    storage_Node.Tag = _dt_storage.Rows[i]["Storage_SN"].ToString() + "|1|" + _dt_storage.Rows[i]["Storage_Type"].ToString() + "|" + SqlInput.ChangeNullToString(_dt_storage.Rows[i]["Step"]) + "|" + SqlInput.ChangeNullToString(_dt_storage.Rows[i]["Respons_Person"]);//仓库SN|1标识仓库|仓库类型|仓库保质阶别|负责人
                    storage_Node.Name = string.Empty;
                    tv_Storage.Nodes.Add(storage_Node);
                }
                #endregion
                #region 库区
                if (SqlInput.ChangeNullToString(_dt_storage.Rows[i]["Area_SN"].ToString()) == string.Empty)
                {
                    continue;
                }
                else if (area_sn != SqlInput.ChangeNullToString(_dt_storage.Rows[i]["Area_SN"].ToString()))
                {
                    area_sn = SqlInput.ChangeNullToString(_dt_storage.Rows[i]["Area_SN"].ToString());//库区
                    area_Node = new TreeNode();
                    area_Node.Text = _dt_storage.Rows[i]["Area_Name"].ToString();
                    area_Node.Tag = _dt_storage.Rows[i]["Area_SN"].ToString() + "|2";//库区SN|2标志库区
                    area_Node.Name = _dt_storage.Rows[i]["Storage_SN"].ToString();//父级（仓库SN）
                    storage_Node.Nodes.Add(area_Node);
                    //storage_Node.ExpandAll();
                }
                #endregion
                #region 库位
                string location_sn = SqlInput.ChangeNullToString(_dt_storage.Rows[i]["Location_SN"].ToString());
                if (location_sn == string.Empty)
                {
                    continue;
                }
                else
                {
                    TreeNode location_Node = new TreeNode();
                    location_Node.Text = _dt_storage.Rows[i]["Location_Name"].ToString();
                    location_Node.Tag = _dt_storage.Rows[i]["Location_SN"].ToString() + "|3|" + SqlInput.ChangeNullToString(_dt_storage.Rows[i]["Enable_Flag"]);//库位SN|3标识库位|是否启用
                    location_Node.Name = _dt_storage.Rows[i]["Area_SN"].ToString();//父级（库区SN）
                    area_Node.Nodes.Add(location_Node);
                    //area_Node.ExpandAll();
                }
                #endregion

            }
        }
        #endregion
        #region 初始化 存储类型
        private void DataBindToType()
        {
            DataTable dt_type = new DataTable();
            dt_type.Columns.Add("Value");
            dt_type.Columns.Add("Text");
            dt_type.Rows.Add("1", "仓库");
            dt_type.Rows.Add("2", "库区");
            dt_type.Rows.Add("3", "库位");
            cbo_Type.DisplayMember = "Text";
            cbo_Type.ValueMember = "Value";
            cbo_Type.DataSource = dt_type;
        }
        #endregion
        List<string> listUser = new List<string>();
        private void DataBindToUser()
        {
            string strsql = "select ltrim(rtrim(UserName))+'@'+ltrim(rtrim(UserID))  as 'ShowUserName' from dbo.SysDatUser";
            DataTable dtUser = CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, strsql);
            listUser.Clear();
            foreach (DataRow dr in dtUser.Rows)
            {
                listUser.Add(dr["ShowUserName"].ToString().Trim());
            }
        }
        #region 判断需要新增或编辑的储位类型，触发的数据绑定和展示
        /// <summary>
        /// 判断需要新增或编辑的储位类型，触发的数据绑定和展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbo_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            //***xcy 2018-9-19
            this.lbl_AreaType.Visible = false;
            this.cmb_AreaType.Visible = false;

            if (cbo_Type.SelectedValue.ToString() == "1")//储位类型:仓库
            {
                lbl_ParentStorage.Text = "仓库类型";
                //***xcy 2018-9-19
                DataTable dt = Common.BLL.Bll_Common.GetSysParameter("CKLX");
                //DataTable dt = BLL.Bll_Bllb_Storage_tbs.GetListOfStorage(string.Empty);

                cbo_ParentStorage.DataSource = dt;
                //***xcy 2018-9-19
                cbo_ParentStorage.DisplayMember = "DICT_VALUE";
                cbo_ParentStorage.ValueMember = "DICT_CODE";
                //cbo_ParentStorage.DisplayMember = "Storage_Name";
                //cbo_ParentStorage.ValueMember = "Storage_SN";

                //dgv_Container.Visible = false;
                chk_Enable_Flag.Visible = false;
                lblPerson.Visible = true;
                cbo_Person.Visible = true;
                cbo_Person.Enabled = true;
                //cbo_Step.Visible = true;
                //lbl_Step.Visible = true;
            }
            else if (cbo_Type.SelectedValue.ToString() == "2")//储位类型:库区
            {
                //***xcy 2018-9-19
                this.lbl_AreaType.Visible = true;
                this.cmb_AreaType.Visible = true;

                lbl_ParentStorage.Text = "仓库";//父级储位
                lbl_SN.Text = "库区SN";
                lbl_Name.Text = "库区名称";
                DataTable dt = BLL.Bll_Bllb_Storage_tbs.GetListOfStorage(string.Empty);//获取所有仓库信息
                cbo_ParentStorage.DataSource = dt;
                cbo_ParentStorage.DisplayMember = "Storage_Name";
                cbo_ParentStorage.ValueMember = "Storage_SN";
                //dgv_Container.Visible = false;
                chk_Enable_Flag.Visible = false;
                //cbo_Step.Visible = false;
                //lbl_Step.Visible = false;
                lblPerson.Visible = false;
                cbo_Person.Visible = false;
                cbo_Person.Enabled = false;
            }
            else if (cbo_Type.SelectedValue.ToString() == "3")//储位类型:库位
            {
                lbl_ParentStorage.Text = "库区";//父级储位
                lbl_SN.Text = "库位SN";
                lbl_Name.Text = "库位名称";
                DataTable dt = BLL.Bll_Bllb_StorageArea_tbsa.GetListOfArea();//获取所有库位信息
                cbo_ParentStorage.DataSource = dt;
                cbo_ParentStorage.DisplayMember = "Area_Name";
                cbo_ParentStorage.ValueMember = "Area_SN";
                //dgv_Container.Visible = true;
                chk_Enable_Flag.Visible = true;
                //cbo_Step.Visible = false;
                //lbl_Step.Visible = false;
                //try
                //{
                //    _dt_container = BLL.Bll_Bllb_LocationContainer_tblc.GetListByLocatin_SN(txt_StorageSN.Text.Trim());
                //    dgv_Container.DataSource = _dt_container;
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //    return;
                //}
                lblPerson.Visible = false;
                cbo_Person.Visible = false;
                cbo_Person.Enabled = false;
            }
        }
        #endregion
        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            //***xcy 2018-9-19
            this.lbl_AreaType.Visible = false;
            this.cmb_AreaType.Visible = false;

            _opreateFlag = "1";//新增标识
            EnableControl(true);
            txt_StorageName.Text = string.Empty;
            txt_StorageSN.Text = string.Empty;

            cbo_Type.Enabled = true;
            cbo_ParentStorage.Enabled = true;
            txt_StorageName.ReadOnly = false;
            txt_StorageSN.ReadOnly = false;
            //checkId.ReadOnly = false;
            //QTY.ReadOnly = false;
            tv_Storage.Enabled = false;
            chk_Enable_Flag.Enabled = true;
            chk_Enable_Flag.Checked = true;
            if (cbo_Type.SelectedValue.ToString() == "3")
            {
                cbo_Type_SelectedIndexChanged(null, null);
            }
        }

        private void EnableControl(bool isEdit)
        {
            btn_add.Enabled = !isEdit;
            btn_del.Enabled = !isEdit;
            btn_edit.Enabled = !isEdit;
            btn_ok.Enabled = isEdit;
            btn_no.Enabled = isEdit;
        }
        #endregion
        #region 编辑
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (tv_Storage.SelectedNode == null)
            {
                ShowMsg("请选择储位", false);
            }
            _opreateFlag = "2";//修改标识

            EnableControl(true);
            cbo_Type.Enabled = false;
            cbo_ParentStorage.Enabled = true;
            txt_StorageName.ReadOnly = false;
            txt_StorageSN.ReadOnly = true;
            //checkId.ReadOnly = false;
            //QTY.ReadOnly = false;
            tv_Storage.Enabled = false;
            chk_Enable_Flag.Enabled = true;
            if (cbo_Type.SelectedValue.ToString() == "3")
            {
                cbo_Type_SelectedIndexChanged(null, null);
            }
            //cbo_Step.Enabled = true;
        }
        #endregion
        #region 提示信息
        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="IsOk"></param>
        private void ShowMsg(string msg, bool IsOk)
        {
            lbl_Msg.Text = msg;
            if (IsOk == false)
            {
                lbl_Msg.ForeColor = Color.Red;
            }
            else
            {
                lbl_Msg.ForeColor = Color.Green;
            }

        }
        #endregion
        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            ShowMsg(string.Empty, true);
            //dgv_Container.EndEdit();
            #region 校验
            if (_opreateFlag == "1")//新增
            {
                if (txt_StorageSN.Text.Trim() == string.Empty)
                {
                    ShowMsg(lbl_SN.Text + "不能为空", false);
                    return;
                }
                else if (txt_StorageName.Text.Trim() == string.Empty)
                {
                    ShowMsg(lbl_Name.Text + "不能为空", false);
                    return;
                }
                DataRow[] dr = _dt_storage.Select(string.Format("Storage_SN='{0}' OR Area_SN='{0}' OR Location_SN='{0}'", txt_StorageSN.Text.Trim()));
                if (dr.Length > 0)
                {
                    ShowMsg("储位SN已存在", false);
                    return;
                }
                dr = _dt_storage.Select(string.Format("Storage_Name='{0}' OR Area_Name='{0}' OR Location_Name='{0}'", txt_StorageName.Text.Trim()));
                if (dr.Length > 0)
                {
                    ShowMsg("储位已存在", false);
                    return;
                }
            }
            else if (_opreateFlag == "2")//编辑
            {
                if (txt_StorageName.Text.Trim() == string.Empty)
                {
                    ShowMsg(lbl_Name.Text + "不能为空", false);
                    return;
                }
                DataRow[] dr = _dt_storage.Select(string.Format("Storage_Name='{0}' OR Area_Name='{0}' OR Location_Name='{0}'", txt_StorageName.Text.Trim()/*, txt_StorageSN.Text.Trim()*/));
                if (dr.Length > 0)
                {
                    if (dr[0]["Storage_SN"].ToString() != txt_StorageSN.Text.Trim() & dr[0]["Area_SN"].ToString() != txt_StorageSN.Text.Trim() & dr[0]["Location_SN"].ToString() != txt_StorageSN.Text.Trim())
                    {
                        ShowMsg(lbl_Name.Text + "已存在", false);
                        return;
                    }

                }
            }
            #region MyRegion
            //if (_dt_container != null)
            //{
            //    //获取库位现在存放的容器数量及类型
            //    DataTable dt_LocationContainer = Bll_Bllb_StorageLocation_tbsl.GetListOfLocationContainer(txt_StorageSN.Text.Trim());

            //    foreach (DataRow dr in _dt_container.Rows)
            //    {
            //        int res = 1;
            //        //if (int.TryParse(dr[QTY.Name].ToString(), out res))
            //        //{
            //        //    if (res == 0)
            //        //    {
            //        //        ShowMsg("请输入大于0的整数", false);
            //        //        return;
            //        //    }
            //        //}
            //        //else
            //        //{
            //        //    ShowMsg("请输入大于0的整数", false);
            //        //    return;
            //        //}
            //        if (dt_LocationContainer.Rows.Count > 0)
            //        {
            //            if (dr["flag"].ToString() == "3")//删除库位容器信息
            //            {
            //                if (dt_LocationContainer.Rows[0]["Container_Type"].ToString() == dr["DICT_CODE"].ToString())
            //                {
            //                    ShowMsg(string.Format("库位上有[{0}]不能进行取消", dt_LocationContainer.Rows[0]["DICT_VALUE"]), false);
            //                    return;
            //                }
            //            }
            //            else if (dr["flag"].ToString() == "4")//修改库位容器信息
            //            {
            //                int Container_Qty = int.Parse(dt_LocationContainer.Rows[0]["Container_Qty"].ToString());
            //                //if (Container_Qty > int.Parse(dr[QTY.Name].ToString()))
            //                //{
            //                //    ShowMsg(string.Format("库位上有[{0}]数量{1}", dt_LocationContainer.Rows[0]["DICT_VALUE"], Container_Qty), false);
            //                //    return;
            //                //}
            //            }
            //        }

            //    }
            //} 
            #endregion

            if (cbo_Type.SelectedValue.ToString() == "1")//仓库操作
            {
                if (string.IsNullOrEmpty(cbo_Person.Text.Trim()))
                {
                    ShowMsg("仓库负责人必填", false);
                    return;
                }
                try
                {
                    string sqlCheckUser = string.Format("select *  from SysDatUser where UserID='{0}'", cbo_Person.Text.Trim().Substring(cbo_Person.Text.IndexOf('@') + 1));
                    if (CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sqlCheckUser).Rows.Count == 0)
                    {
                        ShowMsg("仓库负责人不存在", false);
                        return;
                    }
                }
                catch (Exception)
                {
                    ShowMsg("仓库负责人不存在", false);
                    return;
                }

            }
            #endregion
            #region 保存数据
            //保存数据
            if (cbo_Type.SelectedValue.ToString() == "1")//仓库
            {
                #region 仓库数据操作
                Model.T_Bllb_Storage_tbs tbs = new Model.T_Bllb_Storage_tbs();
                tbs.Storage_SN = txt_StorageSN.Text.Trim();
                tbs.Storage_Name = txt_StorageName.Text.Trim();
                tbs.Storage_Type = cbo_ParentStorage.SelectedValue.ToString();
                tbs.Respons_Person = cbo_Person.Text.Trim().Substring(cbo_Person.Text.Trim().IndexOf('@') + 1);
                //tbs.Step = cbo_Step.SelectedValue.ToString();
                if (_opreateFlag == "1")//新增
                {
                    BLL.Bll_Bllb_Storage_tbs.Insert(tbs);
                }
                else if (_opreateFlag == "2")//修改
                {
                    BLL.Bll_Bllb_Storage_tbs.Update(tbs);
                }
                #endregion
            }
            else if (cbo_Type.SelectedValue.ToString() == "2")//库区
            {
                #region 库区数据操作
                Model.T_Bllb_StorageArea_tbsa tbsa = new Model.T_Bllb_StorageArea_tbsa();
                tbsa.Area_SN = txt_StorageSN.Text.Trim();
                tbsa.Area_Name = txt_StorageName.Text.Trim();
                tbsa.Storage_SN = cbo_ParentStorage.SelectedValue.ToString();
                if (_opreateFlag == "1")//新增
                {
                    BLL.Bll_Bllb_StorageArea_tbsa.Insert(tbsa);
                }
                else if (_opreateFlag == "2")//修改
                {
                    BLL.Bll_Bllb_StorageArea_tbsa.Update(tbsa);
                }
                #endregion
            }
            else if (cbo_Type.SelectedValue.ToString() == "3")//库位
            {
                #region 库位数据操作
                Model.T_Bllb_StorageLocation_tbsl tbsl = new Model.T_Bllb_StorageLocation_tbsl();
                tbsl.Location_SN = txt_StorageSN.Text.Trim();
                tbsl.Location_Name = txt_StorageName.Text.Trim();
                tbsl.Area_SN = cbo_ParentStorage.SelectedValue.ToString();
                tbsl.Enable_Flag = chk_Enable_Flag.Checked ? "Y" : "N";
                if (_opreateFlag == "1")//新增
                {
                    BLL.Bll_Bllb_StorageLocation_tbsl.Insert(tbsl);
                }
                else if (_opreateFlag == "2")//修改
                {
                    BLL.Bll_Bllb_StorageLocation_tbsl.Update(tbsl);
                }
                #endregion
                #region 库位容器信息
                //foreach (DataRow dr in _dt_container.Rows)
                //{
                //    Model.T_Bllb_LocationContainer_tblc obj = new Model.T_Bllb_LocationContainer_tblc();
                //    obj.Location_SN = txt_StorageSN.Text.Trim();
                //    obj.Container_Type = dr["DICT_CODE"].ToString();
                //    obj.QTY = SqlInput.ChangeNullToInt(dr["QTY"], 1);
                //    if (dr["flag"].ToString() == "2")//新增库位容器信息
                //    {
                //        BLL.Bll_Bllb_LocationContainer_tblc.Insert(obj);
                //    }
                //    else if (dr["flag"].ToString() == "3")//删除库位容器信息
                //    {
                //        BLL.Bll_Bllb_LocationContainer_tblc.Delete(obj);
                //    }
                //    else if (dr["flag"].ToString() == "4")//修改库位容器信息
                //    {
                //        BLL.Bll_Bllb_LocationContainer_tblc.Update(obj);
                //    }
                //}
                #endregion

            }
            #endregion
            EnableControl(false);
            cbo_Type.Enabled = false;
            cbo_ParentStorage.Enabled = false;
            txt_StorageName.ReadOnly = true;
            txt_StorageSN.ReadOnly = true;
            //checkId.ReadOnly = true;
            //QTY.ReadOnly = true;
            tv_Storage.Enabled = true;
            chk_Enable_Flag.Enabled = false;
            InitTreeData();//重新加载数据
            tv_Storage.Refresh();

            ShowMsg("保存成功", true);
        }
        #endregion
        #region 选择仓库信息节点
        /// <summary>
        /// 选择仓库信息节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tv_Storage_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tv_Storage.SelectedNode != null)
            {
                //***xcy 2018-9-19
                this.lbl_AreaType.Visible = false;
                this.cmb_AreaType.Visible = false;

                string str_type = tv_Storage.SelectedNode.Tag.ToString().Split('|')[1];
                if (str_type == "1")//仓库
                {
                    cbo_Type.SelectedValue = str_type;
                    cbo_ParentStorage.SelectedValue = tv_Storage.SelectedNode.Tag.ToString().Split('|')[2];
                    txt_StorageSN.Text = tv_Storage.SelectedNode.Tag.ToString().Split('|')[0];
                    txt_StorageName.Text = tv_Storage.SelectedNode.Text;
                    cbo_Person.Visible = true;
                    DataBindToUser();
                    var person = (
                                  from UserName in listUser
                                  where UserName.Contains(tv_Storage.SelectedNode.Tag.ToString().Split('|')[4].Trim())
                                  select UserName
                               ).Distinct().FirstOrDefault();
                    cbo_Person.Text = person;
                    //try
                    //{
                    //    cbo_Step.SelectedValue = tv_Storage.SelectedNode.Tag.ToString().Split('|')[3];
                    //}
                    //catch
                    //{ }
                }
                else if (str_type == "2" || str_type == "3")//库区或库位
                {
                    cbo_Type.SelectedValue = str_type;
                    cbo_ParentStorage.SelectedValue = tv_Storage.SelectedNode.Parent.Tag.ToString().Split('|')[0];
                    txt_StorageSN.Text = tv_Storage.SelectedNode.Tag.ToString().Split('|')[0];
                    txt_StorageName.Text = tv_Storage.SelectedNode.Text;
                    if (str_type == "3")
                    {
                        chk_Enable_Flag.Checked = tv_Storage.SelectedNode.Tag.ToString().Split('|')[2] == "Y" ? true : false;
                        //_dt_container = BLL.Bll_Bllb_LocationContainer_tblc.GetListByLocatin_SN(txt_StorageSN.Text.Trim());
                        //dgv_Container.DataSource = _dt_container;
                    }
                    else
                    {
                        //***xcy 2018-9-19
                        this.lbl_AreaType.Visible = true;
                        this.cmb_AreaType.Visible = true;
                    }
                    cbo_Person.Visible = false;
                }

            }
        }
        #endregion
        #region 删除
        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_del_Click(object sender, EventArgs e)
        {
            if (tv_Storage.SelectedNode != null)
            {
                string str_type = tv_Storage.SelectedNode.Tag.ToString().Split('|')[1];
                if (str_type == "1")//仓库
                {
                    BLL.Bll_Bllb_Storage_tbs.Delete(tv_Storage.SelectedNode.Tag.ToString().Split('|')[0]);
                }
                else if (str_type == "2")//库区
                {
                    BLL.Bll_Bllb_StorageArea_tbsa.DeleteByArea_SN(tv_Storage.SelectedNode.Tag.ToString().Split('|')[0]);
                }
                else if (str_type == "3")//库位
                {
                    BLL.Bll_Bllb_StorageLocation_tbsl.DeleteByLocation_SN(tv_Storage.SelectedNode.Tag.ToString().Split('|')[0]);
                }
            }
            InitTreeData();
        }
        #endregion
        /// <summary>
        /// 导入库位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_import_Click(object sender, EventArgs e)
        {
            Frm_LocationLotAdd f = new Frm_LocationLotAdd();
            if (f.ShowDialog() == DialogResult.OK)
            {
                InitTreeData();//重新加载数据
            }
        }
        #region 设置库位可用容器类型
        /// <summary>
        /// 设置库位可用容器类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void dgv_Container_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dgv_Container.Columns[e.ColumnIndex].Name == checkId.Name & e.RowIndex >= 0)
        //    {
        //        string container_type = dgv_Container.Rows[e.RowIndex].Cells[DICT_VALUE.Name].Value.ToString();
        //        DataRow[] drs = _dt_container.Select(string.Format("DICT_VALUE='{0}'", container_type));
        //        if (drs.Length > 0)
        //        {
        //            bool isCheck = SqlInput.ChangeBoolToValue(dgv_Container.Rows[e.RowIndex].Cells[checkId.Name].Value, false);

        //            if (isCheck == true)
        //            {
        //                switch (drs[0]["flag"].ToString())
        //                {
        //                    case "0":
        //                        drs[0]["flag"] = "2";//新增（只有状态0才能变成2）
        //                        break;
        //                    case "3":
        //                        drs[0]["flag"] = "1";//有（ 只有状态3才能变成1）（状态0和1都不对数据库进行操作）
        //                        break;
        //                }
        //            }
        //            else
        //            {
        //                switch (drs[0]["flag"].ToString())
        //                {
        //                    case "2":
        //                        drs[0]["flag"] = "0";//无（只有状态2才能变成0）（状态0和1都不对数据库进行操作）
        //                        break;
        //                    case "1":
        //                        drs[0]["flag"] = "3";//删除（只有状态1才能变成3）
        //                        break;
        //                }
        //            }
        //            dgv_Container.DataSource = _dt_container;
        //        }
        //    }
        //    if (dgv_Container.Columns[e.ColumnIndex].Name == QTY.Name & e.RowIndex >= 0)//输入数量
        //    {
        //        string container_type = dgv_Container.Rows[e.RowIndex].Cells[DICT_VALUE.Name].Value.ToString();
        //        DataRow[] drs = _dt_container.Select(string.Format("DICT_VALUE='{0}'", container_type));
        //        if (drs.Length > 0)
        //        {
        //            int res = 1;
        //            if (int.TryParse(dgv_Container.Rows[e.RowIndex].Cells[QTY.Name].Value.ToString(), out res))
        //            {
        //                if (res == 0)
        //                {
        //                    ShowMsg("请输入大于0的整数", false);
        //                }
        //                else
        //                {
        //                    if (drs[0]["flag"].ToString() == "0")
        //                    {
        //                        drs[0]["flag"] = "2";
        //                    }
        //                    else if (drs[0]["flag"].ToString() == "1")
        //                    {
        //                        drs[0]["flag"] = "4";//修改数量
        //                    }

        //                }
        //            }
        //            else
        //            {
        //                ShowMsg("请输入大于0的整数", false);
        //            }


        //        }

        //    }
        //}
        #endregion

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_no_Click(object sender, EventArgs e)
        {
            btn_add.Enabled = true;
            btn_edit.Enabled = true;
            btn_del.Enabled = true;
            tv_Storage.Enabled = true;
            try
            {
                tv_Storage.SelectedNode = tv_Storage.Nodes[0];
            }
            catch
            { }
            btn_no.Enabled = false;
            btn_ok.Enabled = false;
            //cbo_Step.Enabled = false;

        }

        private void cbo_Person_TextUpdate(object sender, EventArgs e)
        {
            DataBindToUser();
            cbo_Person.Items.Clear();
            cbo_Person.Items.Add(string.Empty);
            var queryUser = (
                                from UserName in listUser
                                where UserName.Contains(cbo_Person.Text.Trim())
                                select UserName
                             ).Distinct();
            foreach (var item in queryUser)
            {
                cbo_Person.Items.Add(item.ToString());
            }
            this.cbo_Person.DroppedDown = true;
            Cursor = Cursors.Default;
            this.cbo_Person.SelectionStart = this.cbo_Person.Text.Length;
        }
    }
}
