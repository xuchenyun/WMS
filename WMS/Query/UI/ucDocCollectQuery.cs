using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Query.DAL;
using CIT.Wcf.Utils;
using CIT.MES;
using Common.Helper;
using Query.BLL;

namespace Query.UI
{
    public partial class ucDocCollectQuery : UserControl
    {
        public ucDocCollectQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 单据汇总查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            Query();
            new PubUtils().ShowNoteOKMsg("查询成功");
        }

        private void Query()
        {
            StringBuilder strBuilderWhere = new StringBuilder(" where 1=1 ");
            if (!string.IsNullOrEmpty(txt_Doc_NO.Text))
            {
                strBuilderWhere.AppendFormat(" AND a.S_Doc_NO='{0}'", txt_Doc_NO.Text.Trim());//单据号
            }
            if (!string.IsNullOrEmpty(txt_materialCode.Text))
            {
                strBuilderWhere.AppendFormat(" AND b.MaterialCode='{0}'", txt_materialCode.Text.Trim());//料号
            }
            if (cbo_DocType.SelectedValue.ToString() != string.Empty)
            {
                strBuilderWhere.AppendFormat(" AND c.TYPE_NAME='{0}'", cbo_DocType.SelectedValue.ToString());//类型
            }
            DataTable dt_docno = T_Bllb_StorageDoc_tbsd_DAL.QueryDoc(strBuilderWhere.ToString());
            dgv_DocCollect.DataSource = dt_docno;
        }

        private void ucDocCollectQuery_Load(object sender, EventArgs e)
        {
            ///绑定类型下拉框数据源
            string strsql = string.Format(" select TYPE_NAME from T_Bllb_DocType_tbdt");
            DataTable dt_Type = NMS.QueryDataTable(PubUtils.uContext, strsql);
            DataRow dr_Type = dt_Type.NewRow();
            dr_Type["TYPE_NAME"] = string.Empty;
            dt_Type.Rows.InsertAt(dr_Type, 0);
            cbo_DocType.DataSource = dt_Type;
            cbo_DocType.DisplayMember = "TYPE_NAME";
            cbo_DocType.ValueMember = "TYPE_NAME";
        }
        /// <summary>
        /// 双击复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_DocCollect_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_DocCollect, e);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Form_CreateDocManage f = new Form_CreateDocManage();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("新增成功");
            }
        }

        private void tol_del_Click(object sender, EventArgs e)
        {
            if (dgv_DocCollect.CurrentCell == null || dgv_DocCollect.CurrentCell.RowIndex == -1)
            {
                new PubUtils().ShowNoteNGMsg("请先选中行", 2, grade.OrdinaryError);
                return;
            }
            DataGridViewRow dgvr = dgv_DocCollect.Rows[dgv_DocCollect.CurrentCell.RowIndex];
            string s_doc_no = SqlInput.ChangeNullToString(dgvr.Cells["S_Doc_NO"].Value);
            DataTable dt = BLL_Bllb_StorageDoc_tbsd.Query("where S_Doc_NO='" + s_doc_no + "'");
            if (dt.Rows.Count > 0)
            {
                if (SqlInput.ChangeNullToString(dt.Rows[0]["Status"]) != "1")
                {
                    new PubUtils().ShowNoteNGMsg("仅开立中的单据可以删除!", 2, grade.OrdinaryError);
                    return;
                }
            }
            if (BLL_Bllb_StorageDoc_tbsd.Delete("where S_Doc_NO='" + s_doc_no + "'") == true)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("删除成功");
            }
        }
    }
}
