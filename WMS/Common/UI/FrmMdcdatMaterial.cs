using CIT.Client;
using CIT.MES;
using Common.BLL;
using Model;
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

    public partial class FrmMdcdatMaterial : BaseForm
    {
        public delegate void DelRowDataHandler(DataTable dt);
        public DelRowDataHandler _delMdcRowDataHandler;
        BLL_MdcdatMaterial mdcdatMaterial_BLL = new BLL_MdcdatMaterial();
        public FrmMdcdatMaterial()
        {
            InitializeComponent();
            dgv_mdmt.AutoGenerateColumns = false;
        }

        private void FrmMdcdatMaterial_Load(object sender, EventArgs e)
        {
            DataTable dt = mdcdatMaterial_BLL.Select(string.Empty);
            dgv_mdmt.DataSource = dt;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (dgv_mdmt.SelectedRows.Count == 0)
            {
                MsgBox.Error("请先选中行！");
                return;
            }
            else if (dgv_mdmt.SelectedRows.Count > 1)
            {
                MsgBox.Error("请勿选择多行！");
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("MaterialCode");
            dt.Columns.Add("MaterialName");
            dt.Columns.Add("Spec");
            DataRow dr = dt.NewRow();
            dr["MaterialCode"] = dgv_mdmt.SelectedRows[0].Cells[0].Value.ToString().Trim();
            dr["MaterialName"] = dgv_mdmt.SelectedRows[0].Cells[1].Value.ToString().Trim();
            dr["Spec"] = dgv_mdmt.SelectedRows[0].Cells[2].Value.ToString().Trim();
            dt.Rows.Add(dr);
            _delMdcRowDataHandler(dt);
            this.Close();
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            string strWhere = string.Empty;
            if (txt_materialCode.Text != "")
                strWhere += string.Format(" MaterialCode like'{0}%' ", txt_materialCode.Text.ToString().Trim());
            DataTable dt = mdcdatMaterial_BLL.Select(strWhere);
            dgv_mdmt.DataSource = dt;
            new PubUtils().ShowNoteOKMsg("查询完成");
        }

        private void dgv_mdmt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_mdmt, e);
        }
    }
}
