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
using Model;

namespace BaseData.UI
{
    public partial class ucSuppliesManage : UserControl
    {
        public ucSuppliesManage()
        {
            InitializeComponent();
            dgvSupplies.AutoGenerateColumns = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            FormSuppliesEdit f = new FormSuppliesEdit();
            f.opetrationType = Common.Enum.OperationType.Add;
            if (f.ShowDialog() == DialogResult.OK)
            {
                QueryData();
                new PubUtils().ShowNoteOKMsg("新增成功");
            }
        }

        private void QueryData()
        {
            StringBuilder strbuilder = new StringBuilder(" where 1=1 ");
            if (!string.IsNullOrEmpty(txt_suppliesCode.Text.Trim()))
            {
                strbuilder.Append(" and SupplierCode='").Append(txt_suppliesCode.Text.Trim()).Append("'");
            }
            if (!string.IsNullOrEmpty(txt_suppliesName.Text.Trim()))
            {
                strbuilder.Append(" and SupplierName='").Append(txt_suppliesName.Text.Trim()).Append("'");
            }
            DataTable dtSupplyies = Bll_MdcDatSuppliesManage.Query(strbuilder.ToString());
            dgvSupplies.DataSource = dtSupplyies;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgvSupplies.CurrentRow == null || dgvSupplies.CurrentRow.Index == -1)
            {
                new PubUtils().ShowNoteNGMsg("请选中行", 2, grade.OrdinaryError);
                return;
            }
            FormSuppliesEdit f = new FormSuppliesEdit();
            f.opetrationType = Common.Enum.OperationType.Edit;
            f.obj = Common.Helper.PublicSetModel<MdcDatSuppliesManage>.GetTByDataGridViewRow(dgvSupplies.CurrentRow);
            if (f.ShowDialog() == DialogResult.OK)
            {
                QueryData();
                new PubUtils().ShowNoteOKMsg("编辑成功");
            }
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            QueryData();
            new PubUtils().ShowNoteOKMsg("查询成功");
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dgvSupplies.CurrentRow == null || dgvSupplies.CurrentRow.Index == -1)
            {
                new PubUtils().ShowNoteNGMsg("请选中行", 2, grade.OrdinaryError);
                return;
            }
            if (Bll_MdcDatSuppliesManage.Delete(string.Format(" where SupplierCode='{0}'", dgvSupplies.CurrentRow.Cells["SupplierCode"].Value.ToString())))
            {
                QueryData();
                new PubUtils().ShowNoteOKMsg("删除成功");
            }
        }
    }
}
