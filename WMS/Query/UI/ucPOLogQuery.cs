using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Query.BLL;
using CIT.MES;
using CIT.Wcf.Utils;
using Common.Helper;
using CIT.Client;

namespace Query.UI
{
    public partial class ucPOLogQuery : UserControl
    {
        public ucPOLogQuery()
        {
            InitializeComponent();
            dgv_po.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            InitControl();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            QueryData();
            new PubUtils().ShowNoteOKMsg("查询成功");
        }

        private void InitControl()
        {
            #region
            //DataTable dtType = new DataTable();
            //dtType.Columns.Add("text");
            //dtType.Columns.Add("value");
            //DataRow dr = dtType.NewRow();
            //dr["text"] = "采购";
            //dr["value"] = "1";
            //dtType.Rows.Add(dr);
            //dr = dtType.NewRow();
            //dr["text"] = "生产入库";
            //dr["value"] = "2";
            //dtType.Rows.Add(dr);
            //dr = dtType.NewRow();
            //dr["text"] = "生产领用";
            //dr["value"] = "3";
            //dtType.Rows.Add(dr);
            //dr = dtType.NewRow();
            //dr["text"] = string.Empty;
            //dr["value"] = "-1";
            //dtType.Rows.InsertAt(dr, 0);
            //cbo_potype.DataSource = dtType;
            //cbo_potype.DisplayMember = "text";
            //cbo_potype.ValueMember = "value"; 
            #endregion

            DataTable dtType = NMS.QueryDataTable(PubUtils.uContext, "select * from T_Bllb_DocType_tbdt ");
            DataRow dr = dtType.NewRow();
            dr["TYPE_NAME"] = string.Empty;
            dr["TYPE_CODE"] = "-1";
            dtType.Rows.InsertAt(dr, 0);
            cbo_potype.DataSource = dtType;
            cbo_potype.DisplayMember = "TYPE_NAME";
            cbo_potype.ValueMember = "TYPE_CODE";
        }

        private void QueryData()
        {
            string strWhere = "where 1=1 ";

            if (!string.IsNullOrEmpty(txt_po.Text.Trim()))
            {
                strWhere += string.Format(" and a.PO='{0}'", txt_po.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txt_SupplierCode.Text.Trim()))
            {
                strWhere += string.Format(" and a.SupplierCode='{0}'", txt_SupplierCode.Text.Trim());
            }
            if (cbo_potype.SelectedValue.ToString() != "-1")
            {
                strWhere += string.Format(" and a.PO_TypeCode='{0}'", cbo_potype.SelectedValue.ToString());
            }
            if (!string.IsNullOrEmpty(txtMaterialCode.Text.Trim()))
            {
                strWhere += string.Format(" and b.MaterialCode='{0}'", txtMaterialCode.Text.Trim());
            }
            DataTable dtPOLog = BLL_Bllb_POMain_tbpm.Query(strWhere);
            dgv_po.DataSource = dtPOLog;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Form_AddPO f_add = new Form_AddPO();
            if (f_add.ShowDialog() == DialogResult.OK)
            {
                QueryData();
                new PubUtils().ShowNoteOKMsg("新增成功");
            }
        }

        private void tol_del_Click(object sender, EventArgs e)
        {
            if (dgv_po.CurrentCell == null || dgv_po.CurrentCell.RowIndex == -1)
            {
                new PubUtils().ShowNoteNGMsg("请先选中行", 2, grade.OrdinaryError);
                return;
            }
            DataGridViewRow dgvr = dgv_po.Rows[dgv_po.CurrentCell.RowIndex];
            if (SqlInput.ChangeNullToString(dgvr.Cells["PO类型编码"].Value) != "客供单")
            {
                new PubUtils().ShowNoteNGMsg("仅客供单可以删除", 2, grade.OrdinaryError);
                return;
            }
            string POCode = SqlInput.ChangeNullToString(dgvr.Cells["PO订单编号"].Value);
            DataTable dt = BLL_Bllb_POMain_tbpm.GetPostatus(POCode);
            if (dt.Select("CurrentReceiveQty<>0 or ClearQty<>0").Length > 0)
            {
                MsgBox.Error("已收数量或者清点数量不为零时，不可以删除");
                return;
            }
            else
            {
                BLL_Bllb_POMain_tbpm.DeletePocode(POCode);
                new PubUtils().ShowNoteOKMsg("删除成功");
                QueryData();
            }
        }

        private void tsbRelPrint_Click(object sender, EventArgs e)
        {
            //Form_ReelPrint ff= new Form_ReelPrint();
            //MessageBox.Show(ff.GetSnNumber());
            //return;
            if (dgv_po.CurrentCell == null || dgv_po.CurrentCell.RowIndex == -1)
            {
                new PubUtils().ShowNoteNGMsg("请先选中行", 2, grade.OrdinaryError);
                return;
            }
            Form_ReelPrint f = new Form_ReelPrint();
            f.dgvrSelected = dgv_po.CurrentRow;
            f.ShowDialog();
            QueryData();
        }

        private void tsb_repeatPrint_Click(object sender, EventArgs e)
        {
            Form_RepeatPrint f = new Form_RepeatPrint();
            f.ShowDialog();
        }
    }
}
