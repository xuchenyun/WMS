using CIT.Client;
using CIT.MES;
using Model;
using Query.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Query.UI
{
    public partial class Form_CreateDocManage : Form
    {

        DataTable dtStroage = new DataTable();
        DataTable dtDocType = new DataTable();
        DataTable dtDoc = new DataTable();
        public Form_CreateDocManage()
        {
            InitializeComponent();
            DataBindToType();
            dtDoc.Columns.Add("S_Doc_NO");
            dtDoc.Columns.Add("Source_Storage");
            dtDoc.Columns.Add("S_Doc_Type");
            dtDoc.Columns.Add("EmployeeCode");
            dtDoc.Columns.Add("MaterialCode");
            dtDoc.Columns.Add("Quantity");
            dgv_doc.DataSource = dtDoc;
        }

        private void DataBindToType()
        {
            dtStroage = CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "SELECT Storage_SN,Storage_Name  FROM dbo.T_Bllb_Storage_tbs");
            DataRow dr = dtStroage.NewRow();
            dr["Storage_Name"] = string.Empty;
            dr["Storage_SN"] = "-1";
            dtStroage.Rows.InsertAt(dr, 0);
            cmbStorage.DataSource = dtStroage;
            cmbStorage.DisplayMember = "Storage_Name";
            cmbStorage.ValueMember = "Storage_SN";
            dtDocType = CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "SELECT TYPE_NAME,TYPE_CODE,TYPE_HEAD FROM dbo.T_Bllb_DocType_tbdt WHERE IsAutoCreate = 'N'");


            Source_Storage.DataSource = dtStroage;
            Source_Storage.DisplayMember = "Storage_Name";
            Source_Storage.ValueMember = "Storage_SN";

            cbo_TypeCode.DataSource = dtDocType;
            cbo_TypeCode.DisplayMember = "TYPE_NAME";
            cbo_TypeCode.ValueMember = "TYPE_CODE";

            S_Doc_Type.DataSource = dtDocType;
            S_Doc_Type.DisplayMember = "TYPE_NAME";
            S_Doc_Type.ValueMember = "TYPE_CODE";
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            InsertToTempDgv();
        }

        private void InsertToTempDgv()
        {
            string msg = string.Empty;

            if (!ValidateInput(out msg))
            {
                MsgBox.Error(msg);
                return;
            }
            string head = BLL_Bllb_POMain_tbpm.GetDoctypeHead(cbo_TypeCode.SelectedValue.ToString()).Rows[0]["TYPE_HEAD"].ToString().Trim();
            string flow = BLL_Bllb_StorageDoc_tbsd.GetFlow(cbo_TypeCode.SelectedValue.ToString(), head).Rows[0][1].ToString();
            string pocode = head + flow;
            DataRow dr = dtDoc.NewRow();
            dr["S_Doc_NO"] = pocode;
            dr["Source_Storage"] = cmbStorage.SelectedValue.ToString();
            dr["S_Doc_Type"] = cbo_TypeCode.SelectedValue.ToString();
            dr["EmployeeCode"] = PubUtils.uContext.UserID;
            dr["MaterialCode"] = txtMaterialCode.Text.Trim();
            dr["Quantity"] = txtQuantity.Text.Trim();
            dtDoc.Rows.Add(dr);
            txtMaterialCode.Clear();
            txtQuantity.Clear();
        }


        private bool ValidateInput(out string validateMsg)
        {
            if (string.IsNullOrEmpty(txtMaterialCode.Text.Trim()))
            {
                validateMsg = "料号不能为空";
                return false;
            }
            if (string.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                validateMsg = "数量不能为空";
                return false;
            }
            DataTable dtMaterialCode = BLL_Bllb_POMain_tbpm.GetMaterialCode(string.Format(" where MaterialCode='{0}'", txtMaterialCode.Text.Trim()));
            if (dtMaterialCode.Rows.Count == 0)
            {
                validateMsg = "料号错误";
                return false;
            }
            int result = 0;
            if (!int.TryParse(txtQuantity.Text.Trim(), out result))
            {
                validateMsg = "数量只能为正整数";
                return false;
            }
            if (result <= 0)
            {
                validateMsg = "数量只能为正整数";
                return false;
            }
            if (dtDoc.Select(string.Format("MaterialCode='{0}'", txtMaterialCode.Text.Trim())).Length > 0)
            {
                validateMsg = "一个料号只能存在一行记录";
                return false;
            }
            if (dtDoc.Select(string.Format("S_Doc_Type<>'{0}'", cbo_TypeCode.SelectedValue.ToString())).Length > 0)
            {
                validateMsg = "一个单据只能存在一种采购类型";
                return false;
            }
            if (dtDoc.Select(string.Format("Source_Storage<>'{0}'", cmbStorage.SelectedValue.ToString())).Length > 0)
            {
                validateMsg = "一个单据只能存在一种仓库类型";
                return false;
            }
            validateMsg = "OK";
            return true;
        }

        private void tol_del_Click(object sender, EventArgs e)
        {
            if (dgv_doc.CurrentCell == null || dgv_doc.CurrentCell.RowIndex == -1)
            {
                MsgBox.Error("请先选中行");
                return;
            }
            dtDoc.Rows.RemoveAt(dgv_doc.CurrentCell.RowIndex);
            dgv_doc.DataSource = dtDoc;
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                InsertToTempDgv();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (dgv_doc.Rows.Count == 0)
            {
                MsgBox.Error("记录行为0，无需保存!");
                return;
            }
            List<T_Bllb_StorageDoc_tbsd> List_tbsd = new List<T_Bllb_StorageDoc_tbsd>();
            T_Bllb_StorageDoc_tbsd model_tbsd = new T_Bllb_StorageDoc_tbsd();
            model_tbsd.S_Doc_NO = dtDoc.Rows[0]["S_Doc_NO"].ToString();
            model_tbsd.Source_Storage = dtDoc.Rows[0]["Source_Storage"].ToString();
            model_tbsd.S_Doc_Type = dtDoc.Rows[0]["S_Doc_Type"].ToString();
            model_tbsd.Creator = PubUtils.uContext.UserID;
            List_tbsd.Add(model_tbsd);

            List<T_Bllb_StorageDocMaterial_tsdm> List_tbdm = new List<T_Bllb_StorageDocMaterial_tsdm>();
            T_Bllb_StorageDocMaterial_tsdm model_tsdm = new T_Bllb_StorageDocMaterial_tsdm();
            foreach (DataRow dr in dtDoc.Rows)
            {
                model_tsdm.S_Doc_NO = dr["S_Doc_NO"].ToString();
                model_tsdm.MaterialCode = dr["MaterialCode"].ToString();
                model_tsdm.Plan_Qty = Convert.ToInt32(dr["Quantity"].ToString());
                List_tbdm.Add(model_tsdm);
                model_tsdm = new T_Bllb_StorageDocMaterial_tsdm();
            }
            if (BLL_Bllb_StorageDoc_tbsd.SaveStorageDoc(List_tbsd, List_tbdm))
            {
                model_tbsd = new T_Bllb_StorageDoc_tbsd();
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
    }
}
