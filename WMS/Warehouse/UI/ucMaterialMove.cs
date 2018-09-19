using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIT.MES;
using Warehouse.BLL;
using CIT.Client;
using CIT.Wcf.Utils;
using Model;

namespace Warehouse.UI
{
    public partial class ucMaterialMove : UserControl
    {
        bool isAddOrEdit = false;//操作标志位 新增--false 修改 --true
        public ucMaterialMove()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 调拨查询
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
            string strWhere = "";
            if (txt_DocNO.Text != string.Empty)
            {
                strWhere += string.Format(" AND a.S_Doc_NO='{0}'", txt_DocNO.Text.Trim());//单据号
            }
            if (txt_MaterialCode.Text != string.Empty)
            {
                strWhere += string.Format(" AND b.MaterialCode='{0}'", txt_MaterialCode.Text.Trim());//料号
            }
            DataTable dt_MaterialDoc = Bll_Bllb_StorageDoc_tbsd.QueryMaterialDoc(strWhere);
            dgv_MaterialDoc.DataSource = dt_MaterialDoc;
         
        }

        /// <summary>
        /// 开单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            isAddOrEdit = false;
            FrmMaterialMoveAdd frm = new FrmMaterialMoveAdd(isAddOrEdit);
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("新增成功");
            }
        }
       /// <summary>
       /// 修改
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (!DocEdit())
            {
                return;
            }
            isAddOrEdit = true;
            if (dgv_MaterialDoc.CurrentRow == null || dgv_MaterialDoc.CurrentRow.Index == -1)
            {
                new PubUtils().ShowNoteNGMsg("请选中行", 2, grade.OrdinaryError);
                return;
            }
            FrmMaterialMoveAdd frm = new FrmMaterialMoveAdd(isAddOrEdit);
            frm.Doc = Common.Helper.PublicSetModel<T_Bllb_StorageDoc_tbsd>.GetTByDataGridViewRow(dgv_MaterialDoc.CurrentRow);
            frm.DocM = Common.Helper.PublicSetModel<T_Bllb_StorageDocMaterial_tsdm>.GetTByDataGridViewRow(dgv_MaterialDoc.CurrentRow);
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("修改成功");
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dgv_MaterialDoc.CurrentRow == null || dgv_MaterialDoc.CurrentRow.Index == -1)
            {
                new PubUtils().ShowNoteNGMsg("请选中行", 2, grade.OrdinaryError);
                return;
            }
            if (!DocEdit())
            {
                return;
            }
            if (MsgBox.Question("确定要删除？") == DialogResult.OK)
            {
                Bll_Bllb_StorageDoc_tbsd.Delete(string.Format(" where S_Doc_NO='{0}'", dgv_MaterialDoc.CurrentRow.Cells["S_Doc_NO"].Value.ToString()));
                Query();
                new PubUtils().ShowNoteOKMsg("删除成功");
            }
        }
        private bool DocEdit()
        {
            foreach (DataGridViewRow row in dgv_MaterialDoc.Rows)
            {
                string strSql = string.Format("select * from T_Bllb_StorageDocDetail_tbsdd where S_Doc_NO='{0}'", row.Cells["S_Doc_NO"].Value);
                DataTable dt_Doc = NMS.QueryDataTable(PubUtils.uContext, strSql);
                if (dt_Doc.Rows.Count > 0)
                {
                    new PubUtils().ShowNoteNGMsg("已操作不能编辑", 1, grade.OrdinaryError);
                    return false;
                }
            }
            return true;
           
        }
        /// <summary>
        /// 双击复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_MaterialDoc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_MaterialDoc, e);
        }
        #region 按Enter键查询
        private void txt_DocNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("查询成功");
            }
        }

        private void txt_MaterialCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("查询成功");
            }
        }
        #endregion
    }
}
