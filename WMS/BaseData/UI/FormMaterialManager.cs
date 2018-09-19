using BaseData.DAL;
using CIT.Client;
using CIT.MES;
using CIT.MES.Common.Helper;
using CIT.Wcf.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseData.UI
{
    public partial class frmMaterialManager : BaseForm
    {
        /// <summary>
        /// 物料选中行DataGridView转换的对象
        /// </summary>
        public MdcdatMaterial obj = new MdcdatMaterial();

        public bool _isAddOrEdit = false;

        DialogResult result = DialogResult.Cancel;
        public frmMaterialManager(bool isAddOrEdit)
        {
            InitializeComponent();
            this._isAddOrEdit = isAddOrEdit;
            DataBind();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            MdcdatMaterial M = new MdcdatMaterial();
            bool isSucess = false;
            if (txt_materialCode.Text == string.Empty)
            {
                new PubUtils().ShowNoteNGMsg("料号不能为空", 1, grade.OrdinaryError);
                return;
            }
            if (cbo_houseCode.SelectedValue.ToString() == string.Empty)
            {
                if (cbo_houseCode1.SelectedValue.ToString() != string.Empty || cbo_houseCode2.SelectedValue.ToString() != string.Empty)
                {
                    MsgBox.Waring("请先选择默认仓库！");
                    return;
                }
            }

            if (cbo_houseCode.SelectedValue.ToString() == cbo_houseCode1.SelectedValue.ToString() || cbo_houseCode.SelectedValue.ToString() == cbo_houseCode2.SelectedValue.ToString())
            {
                new PubUtils().ShowNoteNGMsg("备用仓库不能跟默认仓库相同", 2, grade.RepeatedError);
                return;
            }
            if (cbo_houseCode1.SelectedValue.ToString() != string.Empty && cbo_houseCode2.SelectedValue.ToString() != string.Empty)
            {
                if (cbo_houseCode1.SelectedValue.ToString() == cbo_houseCode2.SelectedValue.ToString())
                {
                    new PubUtils().ShowNoteNGMsg("备用仓库1不能跟备用仓库2相同", 2, grade.RepeatedError);
                    return;
                }
            }
          
            M.MaterialCode = txt_materialCode.Text.Trim();
            M.MaterialName = txt_materialName.Text.Trim();
            if (cbo_Type.SelectedValue.ToString() != "-1")//类型
            {
                M.Type = cbo_Type.Text.ToString();
            }
            if (cbo_houseCode.SelectedValue.ToString() != "-1")//默认苍库
            {
                M.HouseCode = cbo_houseCode.SelectedValue.ToString();
            }
            
            M.HouseCode1 = cbo_houseCode1.SelectedValue.ToString();
            M.HouseCode2 = cbo_houseCode2.SelectedValue.ToString();
            if (cbo_isMSD.SelectedValue.ToString() != "-1")//是否MSD
            {
                M.IsMSD = cbo_isMSD.SelectedValue.ToString();
            }
            if (cbo_isSendCheck.SelectedValue.ToString() != "-1")//是否送检
            {
                M.IsSendCheck = cbo_isSendCheck.Text.Trim();
            }
            if (cbo_inComingType.SelectedValue.ToString() != "-1")//供料模式
            {
                M.INCOMINGTYPE = cbo_inComingType.SelectedValue.ToString();
            }
            if (cbo_secMateiralClass.Text != "")//辅材等级
            {
                M.SecondMaterialClass = cbo_secMateiralClass.Text.Trim();
            }
          
            M.PackageType = txt_packType.Text.Trim();
            M.PackagingMax = txt_packMax.Text.Trim();
            M.PackagingMin = txt_packMin.Text.Trim();
            M.ShelfLifeTime = StringChange.ChangeNullToInt(txt_shelfLifeTime.Text.Trim(), 0);
            M.SafeQty = StringChange.ChangeNullToInt(txt_safeQty.Text.Trim(), 0);
            if (_isAddOrEdit == false)
            {
                string strSql = string.Format(@"select * from MdcdatMaterial where MaterialCode='{0}'", txt_materialCode.Text.Trim());
                DataTable dt = NMS.QueryDataTable(PubUtils.uContext, strSql);
                if (dt.Rows.Count > 0)
                {
                    new PubUtils().ShowNoteNGMsg("料号已存在", 2, grade.RepeatedError);
                    return;
                }

                isSucess = MdcdatMaterial_DAL.Insert(M);
            }
            else
            {
                M.MaterialCode = obj.MaterialCode;
                isSucess = MdcdatMaterial_DAL.Update(M);
            }
            if (isSucess)
            {
                new PubUtils().ShowNoteOKMsg("保存成功！");
                this.result = DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataBind()
        {
            ///默认仓库数据源
            DataTable dt_HouseCode = MdcdatMaterial_DAL.QueryHouseCode();
            DataRow dr_HouseCode = dt_HouseCode.NewRow();
            dr_HouseCode["Storage_Name"] = "";
            dr_HouseCode["Storage_SN"] = -1;
            dt_HouseCode.Rows.InsertAt(dr_HouseCode, 0);
            cbo_houseCode.DataSource = dt_HouseCode;
            cbo_houseCode.DisplayMember = "Storage_Name";
            cbo_houseCode.ValueMember = "Storage_SN";
            ///备用仓库1数据源
            DataTable dt_HouseCode1 = MdcdatMaterial_DAL.QueryHouseCode();
            DataRow dr_HouseCode1 = dt_HouseCode1.NewRow();
            dt_HouseCode1.Rows.InsertAt(dr_HouseCode1, 0);
            cbo_houseCode1.DataSource = dt_HouseCode1;
            cbo_houseCode1.DisplayMember = "Storage_Name";
            cbo_houseCode1.ValueMember = "Storage_SN";
            ///备用仓库2数据源
            DataTable dt_HouseCode2 = MdcdatMaterial_DAL.QueryHouseCode();
            DataRow dr_HouseCode2 = dt_HouseCode2.NewRow();
            dt_HouseCode2.Rows.InsertAt(dr_HouseCode2, 0);
            cbo_houseCode2.DataSource = dt_HouseCode2;
            cbo_houseCode2.DisplayMember = "Storage_Name";
            cbo_houseCode2.ValueMember = "Storage_SN";

            DataTable dt_Type = new DataTable();
            dt_Type.Columns.Add("DisplayValue");
            dt_Type.Columns.Add("Value");
            DataRow dr_Type = dt_Type.NewRow();
            dr_Type["DisplayValue"] = "";
            dr_Type["Value"] = "-1";
            dt_Type.Rows.InsertAt(dr_Type, 0);
            dr_Type = dt_Type.NewRow();
            dr_Type = dt_Type.NewRow();
            dr_Type["DisplayValue"] = "红胶";
            dr_Type["Value"] = "0";
            dt_Type.Rows.Add(dr_Type);
            dr_Type = dt_Type.NewRow();
            dr_Type["DisplayValue"] = "锡膏";
            dr_Type["Value"] = "1";
            dt_Type.Rows.Add(dr_Type);
            dr_Type = dt_Type.NewRow();
            dr_Type["DisplayValue"] = "MSD";
            dr_Type["Value"] = "2";
            dt_Type.Rows.Add(dr_Type);
            dr_Type = dt_Type.NewRow();
            dr_Type["DisplayValue"] = "普通";
            dr_Type["Value"] = "3";
            dt_Type.Rows.Add(dr_Type);
            cbo_Type.DataSource = dt_Type;
            cbo_Type.DisplayMember = "DisplayValue";
            cbo_Type.ValueMember = "Value";

            DataTable dt_IsMSD = new DataTable();
            dt_IsMSD.Columns.Add("DisplayValue");
            dt_IsMSD.Columns.Add("Value");
            DataRow dr_IsMSD = dt_IsMSD.NewRow();
            dr_IsMSD["DisplayValue"] = "";
            dr_IsMSD["Value"] = "-1";
            dt_IsMSD.Rows.InsertAt(dr_IsMSD, 0);
            dr_IsMSD = dt_IsMSD.NewRow();
            dr_IsMSD["DisplayValue"] = "是";
            dr_IsMSD["Value"] = "0";
            dt_IsMSD.Rows.Add(dr_IsMSD);
            dr_IsMSD = dt_IsMSD.NewRow();
            dr_IsMSD["DisplayValue"] = "否";
            dr_IsMSD["Value"] = "1";
            dt_IsMSD.Rows.Add(dr_IsMSD);
            cbo_isMSD.DataSource = dt_IsMSD;
            cbo_isMSD.DisplayMember = "DisplayValue";
            cbo_isMSD.ValueMember = "Value";

            DataTable dt_IsSendCheck = new DataTable();
            dt_IsSendCheck.Columns.Add("DisplayValue");
            dt_IsSendCheck.Columns.Add("Value");
            DataRow dr_IsSendCheck = dt_IsSendCheck.NewRow();
            dr_IsSendCheck["DisplayValue"] = "";
            dr_IsSendCheck["Value"] = "-1";
            dt_IsSendCheck.Rows.InsertAt(dr_IsSendCheck, 0);
            dr_IsSendCheck = dt_IsSendCheck.NewRow();
            dr_IsSendCheck["DisplayValue"] = "是";
            dr_IsSendCheck["Value"] = "0";
            dt_IsSendCheck.Rows.Add(dr_IsSendCheck);
            dr_IsSendCheck = dt_IsSendCheck.NewRow();
            dr_IsSendCheck["DisplayValue"] = "否";
            dr_IsSendCheck["Value"] = "1";
            dt_IsSendCheck.Rows.Add(dr_IsSendCheck);
            cbo_isSendCheck.DataSource = dt_IsSendCheck;
            cbo_isSendCheck.DisplayMember = "DisplayValue";
            cbo_isSendCheck.ValueMember = "Value";

            DataTable dt_IncomingTypek = new DataTable();
            dt_IncomingTypek.Columns.Add("DisplayValue");
            dt_IncomingTypek.Columns.Add("Value");
            DataRow dr_IncomingTypek = dt_IncomingTypek.NewRow();
            dr_IncomingTypek["DisplayValue"] = "";
            dr_IncomingTypek["Value"] = "-1";
            dt_IncomingTypek.Rows.InsertAt(dr_IncomingTypek, 0);
            dr_IncomingTypek = dt_IncomingTypek.NewRow();
            dr_IncomingTypek["DisplayValue"] = "自供";
            dr_IncomingTypek["Value"] = "0";
            dt_IncomingTypek.Rows.Add(dr_IncomingTypek);
            dr_IncomingTypek = dt_IncomingTypek.NewRow();
            dr_IncomingTypek["DisplayValue"] = "客供";
            dr_IncomingTypek["Value"] = "1";
            dt_IncomingTypek.Rows.Add(dr_IncomingTypek);
            cbo_inComingType.DataSource = dt_IncomingTypek;
            cbo_inComingType.DisplayMember = "DisplayValue";
            cbo_inComingType.ValueMember = "Value";
        }

        private void frmMaterialManager_Load(object sender, EventArgs e)
        {
            cbo_secMateiralClass.DataSource = MdcdatMaterial_DAL.GetSecMaterialClass(cbo_Type.Text);
            cbo_secMateiralClass.DisplayMember = "Class";
            cbo_secMateiralClass.ValueMember = "Class";

            if (_isAddOrEdit)
            {
                txt_materialCode.ReadOnly = true;
                txt_materialName.ReadOnly = true;

                txt_materialCode.Text = obj.MaterialCode;

                txt_materialName.Text = obj.MaterialName;

                if (obj.Type != string.Empty)
                {
                    cbo_Type.Text = obj.Type;//类型
                    cbo_Type_SelectionChangeCommitted(null, null);
                }

                if (obj.HouseCode != string.Empty)//备用仓库
                {
                    cbo_houseCode.Text = obj.HouseCode;
                }
                if (obj.HouseCode1 != string.Empty)//备用仓库1
                {
                    cbo_houseCode1.Text = obj.HouseCode1;
                }
                if (obj.HouseCode2 != string.Empty)//备用仓库2
                {
                    cbo_houseCode2.Text = obj.HouseCode2;
                }
                if (obj.IsMSD != string.Empty)//是否MSD
                {
                    cbo_isMSD.Text = obj.IsMSD;
                }
                if (obj.IsSendCheck != string.Empty)//是否送检
                {
                    cbo_isSendCheck.Text = obj.IsSendCheck;
                }
                if (obj.SecondMaterialClass != string.Empty)//辅材等级
                {
                    cbo_secMateiralClass.Text = obj.SecondMaterialClass;
                }
                if (obj.INCOMINGTYPE != string.Empty)//gongl方式
                {
                    cbo_inComingType.Text = obj.INCOMINGTYPE;
                }
                if (obj.PackageType != string.Empty)//包装类型
                {
                    txt_packType.Text = obj.PackageType;
                }
                if (obj.PackagingMax != string.Empty)//最大包装
                {
                    txt_packMax.Text = obj.PackagingMax;
                }
                if (obj.PackagingMin != string.Empty)//最小包装
                {
                    txt_packMin.Text = obj.PackagingMin;
                }
                txt_shelfLifeTime.Text = obj.ShelfLifeTime.ToString();
                txt_safeQty.Text = obj.SafeQty.ToString();

            }
        }

        private void frmMaterialManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = this.result;
        }


        private void txt_shelfLifeTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                MsgBox.Waring("有效期只能输入整数！");
                e.Handled = true;
            }
        }

        private void txt_safeQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                MsgBox.Waring("安全库存只能输入整数！");
                e.Handled = true;
            }
        }
        /// <summary>
        /// 类型带出辅材等级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbo_Type_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbo_secMateiralClass.DataSource = null;
            DataTable dt = MdcdatMaterial_DAL.GetSecMaterialClass(cbo_Type.Text);
            if (dt.Rows.Count > 0)
            {
                cbo_secMateiralClass.DataSource = dt;
                cbo_secMateiralClass.DisplayMember = "Class";
                cbo_secMateiralClass.ValueMember = "Class";
            }

        }
    }
}
