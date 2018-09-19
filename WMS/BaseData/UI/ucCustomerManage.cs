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
using CIT.MES.Common.Helper;
using Model;
using CIT.MES;
using Common.Enum;

namespace BaseData.UI
{
    public partial class ucCustomerManage : UserControl
    {

        DataTable dtCustomer = new DataTable();

        public ucCustomerManage()
        {
            InitializeComponent();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            QueryData();
            new PubUtils().ShowNoteOKMsg("查询成功");
        }

        private void QueryData()
        {
            string strWhere = "where 1= 1";

            if (!string.IsNullOrEmpty(txt_CustomerCode.Text.Trim()))
            {
                strWhere += string.Format(" and CustomerCode='{0}'", txt_CustomerCode.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txt_customerName.Text.Trim()))
            {
                strWhere += string.Format(" and  CustomerName='{0}'", txt_customerName.Text.Trim());
            }
            dtCustomer = Bll_SysdatMPNCustomer.Query(strWhere);
            dgvCustomer.DataSource = dtCustomer;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            FormCustomerEdit f = new FormCustomerEdit();
            f.opetrationType = OperationType.Add;
            if (f.ShowDialog() == DialogResult.OK)
            {
                QueryData();
                new PubUtils().ShowNoteOKMsg("新增成功");
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow == null || dgvCustomer.CurrentRow.Index == -1)
            {
                new PubUtils().ShowNoteNGMsg("请选中行", 2, grade.OrdinaryError);
                return;
            }
            FormCustomerEdit f = new FormCustomerEdit();
            f.opetrationType = OperationType.Edit;
            f.obj = Common.Helper.PublicSetModel<SysdatMPNCustomer>.GetTByDataGridViewRow(dgvCustomer.CurrentRow);
            if (f.ShowDialog() == DialogResult.OK)
            {
                QueryData();
                new PubUtils().ShowNoteOKMsg("编辑成功");
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow == null || dgvCustomer.CurrentRow.Index == -1)
            {
                new PubUtils().ShowNoteNGMsg("请选中行", 2, grade.OrdinaryError);
                return;
            }
            if (Bll_SysdatMPNCustomer.Delete(string.Format(" where CustomerID='{0}'", dgvCustomer.CurrentRow.Cells["CustomerID"].Value.ToString())))
            {
                QueryData();
                new PubUtils().ShowNoteOKMsg("删除成功");
            }
        }
    }
}
