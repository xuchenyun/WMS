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
    public partial class FrmMaterial : BaseForm
    {
        /// <summary>
        /// 委托
        /// </summary>
        /// <param name="dt"></param>
        public delegate void DellRowDataHandler(DataTable dt);
        /// <summary>
        /// 委托变量
        /// </summary>
        public DellRowDataHandler _delMaterialRowDataHandler;
        BLL_MdcdatMaterial mdcdatMaterial_BLL = new BLL_MdcdatMaterial();
        BLL_Bllb_materialRule_tbmb t_Bllb_materialRule_tbmb_BLL = new BLL_Bllb_materialRule_tbmb();
        public FrmMaterial()
        {
            InitializeComponent();
            dgv_materialRule.AutoGenerateColumns = false;
        }
        private void FrmMaterial_Load(object sender, EventArgs e)
        {
            DataTable dt = mdcdatMaterial_BLL.SelectCodeAndRule(string.Empty);
            dgv_materialRule.DataSource = dt;
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (dgv_materialRule.SelectedRows.Count == 0)
            {
                MsgBox.Error("请先选中行!");
                return;
            }
            if (dgv_materialRule.SelectedRows.Count > 1)
            {
                MsgBox.Error("请勿选中多行！");
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("MaterialCode");
            dt.Columns.Add("TBBR_ID");
            dt.Columns.Add("RULE_NAME");
            DataRow dr = dt.NewRow();
            dr["MaterialCode"] = dgv_materialRule.SelectedRows[0].Cells["MaterialCode"].Value.ToString().Trim();
            dr["TBBR_ID"] = dgv_materialRule.SelectedRows[0].Cells["TBBR_ID"].Value.ToString().Trim();
            dr["RULE_NAME"] = dgv_materialRule.SelectedRows[0].Cells["RULE_NAME"].Value.ToString().Trim();
            dt.Rows.Add(dr);
            _delMaterialRowDataHandler(dt);
            this.Close();
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            {
                strWhere += string.Format(" MaterialCode like'{0}%'", txt_materialCode.Text);
            }
            DataTable dtmaterial = mdcdatMaterial_BLL.SelectCodeAndRule(strWhere);
            dgv_materialRule.DataSource = dtmaterial;
            new PubUtils().ShowNoteOKMsg("查询完成");
        }

        private void dgv_materialRule_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_materialRule, e);
        }
    }
}
