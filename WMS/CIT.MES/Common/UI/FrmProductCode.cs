using CIT.Client;
using CIT.MES;
using Common;
using Common.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Common.UI
{
    public partial class FrmProductCode : BaseForm
    {
        public delegate void DelRowDataHandler(DataTable dt);
        public DelRowDataHandler _delProRowDataHandler;
        BLL_MdcdatProduct mdcdatProduct_BLL = new BLL_MdcdatProduct();//机种表业务层操作类
        public FrmProductCode()
        {
            InitializeComponent();
            dgv_product.AutoGenerateColumns = false;
        }

        private void FrmProductCode_Load(object sender, EventArgs e)
        {

        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (dgv_product.SelectedRows.Count == 0)
            {
                MsgBox.Error("请先选中行！");
                return;
            }
            else if (dgv_product.SelectedRows.Count > 1)
            {
                MsgBox.Error("请勿选择多行 ");
                return;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ProductCode");
                dt.Columns.Add("ProductName");
                DataRow dr = dt.NewRow();
                dr["ProductCode"] = dgv_product.SelectedRows[0].Cells["ProductCode"].Value.ToString().Trim();
                dr["ProductName"] = dgv_product.SelectedRows[0].Cells["ProductName"].Value.ToString().Trim();
                dt.Rows.Add(dr);
                _delProRowDataHandler(dt);
                this.Close();
            }
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            string strWhere = string.Empty;
            if (txt_ProductCode.Text.Trim() != string.Empty)
            {
                strWhere = string.Format("  ProductCode LIKE '{0}%'", txt_ProductCode.Text.Trim());
            }
            DataTable dt = mdcdatProduct_BLL.Select(strWhere);
            dgv_product.DataSource = dt;
            new PubUtils().ShowNoteOKMsg("查询完成");
        }

        private void dgv_product_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_product, e);
        }
    }
}
