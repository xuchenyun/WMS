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
    public partial class FrmSfcNo : BaseForm
    {
        public delegate void DelRowDataHandler(DataTable dt);
        public DelRowDataHandler _delSfcNoRowDataHandler;
        BLL_SfcDatProduct sfcDatProduct_BLL = new BLL_SfcDatProduct();//制令单业务层操作类
        public FrmSfcNo()
        {
            InitializeComponent();
            dgv_sfcNo.AutoGenerateColumns = false;
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (dgv_sfcNo.SelectedRows.Count == 0)
            {
                MsgBox.Error("请先选中行！");
                return;
            }
            else if (dgv_sfcNo.SelectedRows.Count > 1)
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
                dr["FGuid"] = dgv_sfcNo.SelectedRows[0].Cells["FGuid"].Value.ToString().Trim();
                dr["SfcNo"] = dgv_sfcNo.SelectedRows[0].Cells["SfcNo"].Value.ToString().Trim();
                dr["WoCode"] = dgv_sfcNo.SelectedRows[0].Cells["WoCode"].Value.ToString().Trim();
                dt.Rows.Add(dr);
                _delSfcNoRowDataHandler(dt);
                this.Close();
            }
        }
        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSfcNo_Load(object sender, EventArgs e)
        {
            DataTable dt = sfcDatProduct_BLL.Select(string.Empty);
            dgv_sfcNo.DataSource = dt;
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            string strWhere = string.Empty;
            if (txt_sfcno.Text != string.Empty)
            {
                strWhere += string.Format(" SfcNo like'{0}%'",txt_sfcno.Text.Trim());
            }
            DataTable dt = sfcDatProduct_BLL.Select(strWhere);
            dgv_sfcNo.DataSource = dt;
            new PubUtils().ShowNoteOKMsg("查询完成");
        }

        private void dgv_sfcNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_sfcNo, e);
        }
    }
}
