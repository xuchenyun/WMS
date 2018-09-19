using CIT.Client;
using CIT.MES;
using CIT.Wcf.Utils;
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
    public partial class Form_AddPO : Form
    {
        DataTable dtPoMain = new DataTable();
        public Form_AddPO()
        {
            InitializeComponent();
            InitControl();
            cbo_TypeCode.Items.Add("来料单");
            cbo_TypeCode.SelectedIndex = 0;
            dtPoMain.Columns.Add("InCode");
            dtPoMain.Columns.Add("PO");
            dtPoMain.Columns.Add("PO_TypeCode");
            dtPoMain.Columns.Add("EmployeeCode");
            dtPoMain.Columns.Add("MaterialCode");
            dtPoMain.Columns.Add("Quantity");
            dgv_po.DataSource = dtPoMain;
        }

        private void InitControl()
        {
            DataTable dtType = NMS.QueryDataTable(PubUtils.uContext, "select * from T_Bllb_DocType_tbdt ");
            PO_TypeCode.DataSource = dtType;
            PO_TypeCode.DisplayMember = "TYPE_NAME";
            PO_TypeCode.ValueMember = "TYPE_CODE";
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
            string doc_head = "L";
            string doc_flow = BLL_Bllb_POMain_tbpm.QueryPocodeFlow("17").Rows[0][1].ToString();
            string pocode = doc_head + doc_flow;
            DataRow dr = dtPoMain.NewRow();
            dr["InCode"] = pocode;
            dr["PO"] = txtERPCode.Text.Trim();
            dr["PO_TypeCode"] = "17";
            dr["EmployeeCode"] = PubUtils.uContext.UserID;
            dr["MaterialCode"] = txtMaterialCode.Text.Trim();
            dr["Quantity"] = txtQuantity.Text.Trim();
            dtPoMain.Rows.Add(dr);
            txtMaterialCode.Clear();
            txtQuantity.Clear();
            txtERPCode.Focus();
            txtERPCode.SelectAll();
        }

        private bool ValidateInput(out string validateMsg)
        {
            if (string.IsNullOrEmpty(txtERPCode.Text.Trim()))
            {
                validateMsg = "ERP订单号不能为空";
                return false;
            }
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
            if (dtPoMain.Select(string.Format("MaterialCode='{0}'", txtMaterialCode.Text.Trim())).Length > 0)
            {
                validateMsg = "一个料号只能存在一行记录";
                return false;
            }
            if (dtPoMain.Select(string.Format("PO<>'{0}'", txtERPCode.Text.Trim())).Length > 0)
            {
                validateMsg = "一个来料单只能存在一个ERP订单号";
                return false;
            }
            validateMsg = "OK";
            return true;
        }

        private void tol_del_Click(object sender, EventArgs e)
        {
            if (dgv_po.CurrentCell == null || dgv_po.CurrentCell.RowIndex == -1)
            {
                MsgBox.Error("请先选中行");
                return;
            }
            dtPoMain.Rows.RemoveAt(dgv_po.CurrentCell.RowIndex);
            dgv_po.DataSource = dtPoMain;
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
            if (dgv_po.Rows.Count == 0)
            {
                new PubUtils().ShowNoteNGMsg("记录行为0，无需保存!", 2, grade.OrdinaryError);
                return;
            }
            List<T_Bllb_POMain_tbpm> lstPoMaintbpm = new List<T_Bllb_POMain_tbpm>();
            List<T_Bllb_PODetail_tbpd> lstPoDetailTbpd = new List<T_Bllb_PODetail_tbpd>();
            T_Bllb_POMain_tbpm tbpm_obj = new T_Bllb_POMain_tbpm();
            T_Bllb_PODetail_tbpd tbpd_obj = new T_Bllb_PODetail_tbpd();
            foreach (DataRow dr in dtPoMain.Rows)
            {
                tbpm_obj.InCode = dr["InCode"].ToString();
                tbpm_obj.PO = dr["PO"].ToString();
                tbpm_obj.EmployeeCode = PubUtils.uContext.UserID;
                tbpm_obj.PO_TypeCode = dr["PO_TypeCode"].ToString();
                string _guid = Guid.NewGuid().ToString();
                tbpm_obj.POID = _guid;
                lstPoMaintbpm.Add(tbpm_obj);

                tbpd_obj.POID = _guid;
                tbpd_obj.PO = dr["PO"].ToString();
                tbpd_obj.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                tbpd_obj.RowNumber = (dtPoMain.Rows.IndexOf(dr) + 1).ToString();
                tbpd_obj.MaterialCode = dr["MaterialCode"].ToString();
                lstPoDetailTbpd.Add(tbpd_obj);
                tbpm_obj = new T_Bllb_POMain_tbpm();
                tbpd_obj = new T_Bllb_PODetail_tbpd();
            }
            if (BLL_Bllb_POMain_tbpm.AddListPocode(lstPoMaintbpm, lstPoDetailTbpd))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }
    }
}
