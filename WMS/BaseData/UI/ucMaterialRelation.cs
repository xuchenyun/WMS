using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseData.BLL;
using CIT.MES;
using Common.Helper;
using Model;

namespace BaseData.UI
{
    public partial class ucMaterialRelation : UserControl
    {
        public ucMaterialRelation()
        {
            InitializeComponent();
        }

        private void tol_add_Click(object sender, EventArgs e)
        {
            Form_MaterialRelManage f = new Form_MaterialRelManage();
            f._operationType = Common.Enum.OperationType.Add;
            f.ShowDialog();
            Query();
        }
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null || dgvData.CurrentRow.Index == -1)
            {
                new PubUtils().ShowNoteNGMsg("请先选中行", 2, grade.OrdinaryError);
                return;
            }
            Form_MaterialRelManage f = new Form_MaterialRelManage();
            f.obj_tbmr = PublicSetModel<T_Bllb_MaterialRelation_Tbmr>.GetTByDataGridViewRow(dgvData.Rows[dgvData.CurrentCell.RowIndex]);
            f._operationType = Common.Enum.OperationType.Edit;
            if (f.ShowDialog() == DialogResult.OK)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("编辑成功");
            }
        }

        private void tol_del_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null || dgvData.CurrentRow.Index == -1)
            {
                new PubUtils().ShowNoteNGMsg("请先选中行", 2, grade.OrdinaryError);
                return;
            }
            if (BLL_Bllb_MaterialRelation_Tbmr.Delete(string.Format(" WHERE TBMR_ID='{0}'", SqlInput.ChangeNullToString(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["TBMR_ID"].Value))))
            {
                Query();
                new PubUtils().ShowNoteOKMsg("删除成功");
            }          
        }

        private void Query()
        {
            StringBuilder strBuilder = new StringBuilder(" where 1=1 ");

            if (!string.IsNullOrEmpty(txtLocalMaterial.Text.Trim()))
            {
                strBuilder.AppendFormat(" AND LocalMaterialCode='{0}'", txtLocalMaterial.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtSupplyMaterial.Text.Trim()))
            {
                strBuilder.AppendFormat(" AND SupplyMaterialCode='{0}'", txtSupplyMaterial.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtSupply.Text.Trim()))
            {
                strBuilder.AppendFormat(" AND Supply='{0}'", txtSupply.Text.Trim());
            }
            DataTable dt = BLL_Bllb_MaterialRelation_Tbmr.Query(strBuilder.ToString());
            dgvData.DataSource = dt;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Query();
            new PubUtils().ShowNoteOKMsg("查询成功");
        }
    }
}
