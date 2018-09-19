using CIT.Client;
using CIT.MES;
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
    public partial class FrmWoCode : BaseForm
    {
        public delegate void DelRowDataHandler(DataTable dt);
        public DelRowDataHandler _delWoCodeRowDataHandler;
        BLL_SfcDatProduct sfcDatProduct_BLL = new BLL_SfcDatProduct();//制令单业务层操作类
        public FrmWoCode()
        {
            InitializeComponent();
            dgv_woCode.AutoGenerateColumns = false;
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (dgv_woCode.SelectedRows.Count == 0)
            {
                MsgBox.Error("请先选中行！");
                return;
            }
            else if (dgv_woCode.SelectedRows.Count > 1)
            {
                MsgBox.Error("请勿选择多行 ");
                return;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("FGuid");
                dt.Columns.Add("SfcNo");
                dt.Columns.Add("WoCode");
                DataRow dr = dt.NewRow();
                dr["FGuid"] = dgv_woCode.SelectedRows[0].Cells[0].Value.ToString().Trim();
                dr["SfcNo"] = dgv_woCode.SelectedRows[0].Cells[1].Value.ToString().Trim();
                dr["WoCode"] = dgv_woCode.SelectedRows[0].Cells[2].Value.ToString().Trim();
                dt.Rows.Add(dr);
                _delWoCodeRowDataHandler(dt);
                this.Close();
            }
        }

        private void FrmWoCode_Load(object sender, EventArgs e)
        {
            DataTable dt = sfcDatProduct_BLL.Select(string.Empty);
            dgv_woCode.DataSource = dt;

        }
        private void btn_query_Click(object sender, EventArgs e)
        {
            string strWhere = string.Empty;
            if (txt_sfcno.Text != string.Empty)
            {
                strWhere += string.Format(" SfcNo like'{0}%' ", txt_sfcno.Text.Trim());
            }
            DataTable dt = sfcDatProduct_BLL.Select(strWhere);
            dgv_woCode.DataSource = dt;
            new PubUtils().ShowNoteOKMsg("查询成功");
        }

        private void dgv_woCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_woCode, e);
        }
    }
}
