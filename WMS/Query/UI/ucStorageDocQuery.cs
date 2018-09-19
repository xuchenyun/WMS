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

namespace Query.UI
{
    public partial class ucStorageDocQuery : UserControl
    {
        private string _S_Doc_NO = string.Empty;
        private string _MaterialCode = string.Empty;
        private string _PO_DetailID = string.Empty;

        public ucStorageDocQuery()
        {
            InitializeComponent();
            dgv_Doc_Tbsd.AutoGenerateColumns = false;
            dgv_DocMaterial_tsdm.AutoGenerateColumns = false;
            dgv_Detail_tbsdd.AutoGenerateColumns = false;
            Init();
        }

        private void btn_qeury_Click(object sender, EventArgs e)
        {
            dgv_Detail_tbsdd.DataSource = null;
            dgv_DocMaterial_tsdm.DataSource = null;
            dgv_Doc_Tbsd.DataSource = null;
            QueryData();
            new PubUtils().ShowNoteOKMsg("查询成功");
        }

        void Init()
        {
            DataTable dtDocType = new DataTable();
            dtDocType.Columns.AddRange(
                new DataColumn[] {
                new DataColumn("text", Type.GetType("System.String")),
                new DataColumn("value", Type.GetType("System.String"))
            });
            DataRow dr = dtDocType.NewRow();
            dr["text"] = "入库单";
            dr["value"] = "1";
            dtDocType.Rows.Add(dr);
            dr = dtDocType.NewRow();
            dr["text"] = "发料单";
            dr["value"] = "2";
            dtDocType.Rows.Add(dr);
            dr = dtDocType.NewRow();
            dr["text"] = "退料单";
            dr["value"] = "3";
            dtDocType.Rows.Add(dr);
            dr = dtDocType.NewRow();
            dr["text"] = string.Empty;
            dr["value"] = "-1";
            dtDocType.Rows.InsertAt(dr, 0);
            cbo_S_Doc_NO_Type.DataSource = dtDocType;
            cbo_S_Doc_NO_Type.DisplayMember = "text";
            cbo_S_Doc_NO_Type.ValueMember = "value";
        }

        private void QueryData()
        {
            StringBuilder strwhereBuilder = new StringBuilder(" where 1=1 ");
            if (!string.IsNullOrEmpty(txt_S_Doc_NO.Text.Trim()))
            {
                strwhereBuilder.AppendFormat(" and S_Doc_NO ='{0}'", txt_S_Doc_NO.Text.Trim());
            }
            if (cbo_S_Doc_NO_Type.SelectedValue.ToString() != "-1")
            {
                strwhereBuilder.AppendFormat(" and S_Doc_Type='{0}'", cbo_S_Doc_NO_Type.SelectedValue.ToString());
            }
            if (!string.IsNullOrEmpty(txt_LotNo.Text.Trim()))
            {
                strwhereBuilder.AppendFormat(" and LotNo='{0}' ", txt_LotNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txt_PO.Text.Trim()))
            {
                strwhereBuilder.AppendFormat(" and PO='{0}' ", txt_PO.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txt_Arrival_NO.Text.Trim()))
            {
                strwhereBuilder.AppendFormat(" and Arrival_NO='{0}' ", txt_Arrival_NO.Text.Trim());
            }
            DataTable dt_Doc_Tbsd = BLL_Bllb_StorageDoc_tbsd.Query(strwhereBuilder.ToString());
            dgv_Doc_Tbsd.DataSource = dt_Doc_Tbsd;
        }

        private void dgv_Doc_Tbsd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgv_Doc_Tbsd.CurrentRow == null || dgv_Doc_Tbsd.CurrentRow.Index == -1)
            //{
            //    return;
            //}
            //_S_Doc_NO = dgv_Doc_Tbsd.CurrentRow.Cells["S_Doc_NO"].Value.ToString();
            //DataTable dt_DocMaterial = BLL_Bllb_StorageDocMaterial_tsdm.Query(string.Format(" where S_Doc_NO='{0}'", _S_Doc_NO));
            //dgv_DocMaterial_tsdm.DataSource = dt_DocMaterial;
        }

        private void dgv_DocMaterial_tsdm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgv_DocMaterial_tsdm.CurrentRow == null || dgv_DocMaterial_tsdm.CurrentRow.Index == -1)
            //{
            //    return;
            //}
            //_MaterialCode = dgv_DocMaterial_tsdm.CurrentRow.Cells["MaterialCode"].Value.ToString();
            //_PO_DetailID = dgv_DocMaterial_tsdm.CurrentRow.Cells["PO_DetailID"].Value.ToString();
            //DataTable dt_DocDetail = BLL_Bllb_StorageDocDetail_tbsdd.Query(string.Format(" where S_Doc_NO='{0}' and MaterialCode='{1}' and PO_DetailID='{2}'", _S_Doc_NO, _MaterialCode, _PO_DetailID));
            //dgv_Detail_tbsdd.DataSource = dt_DocDetail;
        }
    }
}
