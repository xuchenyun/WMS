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
    public partial class FrmBarcodeRule : BaseForm
    {
        /// <summary>
        /// 条码规则业务层操作对象
        /// </summary>
        BLL_Bllb_BarcodeRule_tbbr t_Bllb_BarcodeRule_tbbr_BLL = new BLL_Bllb_BarcodeRule_tbbr();
        public delegate void DelRowDataHandler(DataTable dt);
        public DelRowDataHandler _delRuleNameRowDataHandler;
        public FrmBarcodeRule()
        {
            InitializeComponent();
            dgv_barcodeRule.AutoGenerateColumns = false;
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            string strWhere = string.Empty;
            if (txt_ruleName.Text != "")
            {
                strWhere += string.Format("  RULE_NAME like '{0}%'", txt_ruleName.Text.Trim());

            }
            DataTable dtTbbr = t_Bllb_BarcodeRule_tbbr_BLL.Select(strWhere);
            dgv_barcodeRule.DataSource = dtTbbr;
            new PubUtils().ShowNoteOKMsg("查询完成");
        }

        private void FrmBarcodeRule_Load(object sender, EventArgs e)
        {
            //初始化料号比对列MATERIAL_FLAG
            DataBindToMaterialFlag();
            //绑定字段值为Y / N的数据源
            DataBindToYN();
            DataTable dtTbbr = t_Bllb_BarcodeRule_tbbr_BLL.Select(string.Empty);
            dgv_barcodeRule.DataSource = dtTbbr;
        }
        /// <summary>
        ///  初始化料号比对列MATERIAL_FLAG
        /// </summary>
        private void DataBindToMaterialFlag()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DisplayValue");
            dt.Columns.Add("Value");
            DataRow dr = dt.NewRow();
            dr["DisplayValue"] = "";
            dr["Value"] = "0";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["DisplayValue"] = "物料代码";
            dr["Value"] = "1";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["DisplayValue"] = "产品代码";
            dr["Value"] = "2";
            dt.Rows.Add(dr);
            MATERIAL_FLAG.DataSource = dt;
            MATERIAL_FLAG.DisplayMember = "DisplayValue";
            MATERIAL_FLAG.ValueMember = "Value";
        }

        /// <summary>
        /// 绑定字段值为Y/N的数据源
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dr"></param>
        private void DataBindToYN()
        {
            DataTable dt_YN = new DataTable();
            dt_YN.Columns.Add("DisplayValue");
            dt_YN.Columns.Add("Value");
            DataRow dr_YN = dt_YN.NewRow();
            dr_YN["DisplayValue"] = "";
            dr_YN["Value"] = "";
            dt_YN.Rows.Add(dr_YN);
            dr_YN = dt_YN.NewRow();
            dr_YN["DisplayValue"] = "是";
            dr_YN["Value"] = "Y";
            dt_YN.Rows.Add(dr_YN);
            dr_YN = dt_YN.NewRow();
            dr_YN["DisplayValue"] = "否";
            dr_YN["Value"] = "N";
            dt_YN.Rows.Add(dr_YN);

            IS_CHECK_SN_LENGTH.DataSource = dt_YN;
            IS_CHECK_SN_LENGTH.DisplayMember = "DisplayValue";
            IS_CHECK_SN_LENGTH.ValueMember = "Value";

            IS_CHECK_SAME_STRING.DataSource = dt_YN;
            IS_CHECK_SAME_STRING.DisplayMember = "DisplayValue";
            IS_CHECK_SAME_STRING.ValueMember = "Value";
        }

        private void dgv_barcodeRule_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_barcodeRule, e);
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (dgv_barcodeRule.SelectedRows.Count == 0)
            {
                MsgBox.Error("请先选中行！");
                return;
            }
            else if (dgv_barcodeRule.SelectedRows.Count > 1)
            {
                MsgBox.Error("请勿选择多行！");
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("TBBR_ID");
            dt.Columns.Add("RULE_NAME");
            dt.Columns.Add("SN_LENGTH");
            dt.Columns.Add("SN_BEGIN");
            dt.Columns.Add("SAME_STRING");
            dt.Columns.Add("SAME_STRING_BEGIN");
            dt.Columns.Add("MATERIAL_FLAG");
            dt.Columns.Add("MATERIAL_LENGTH");
            dt.Columns.Add("MATERIAL_CODE_BEGIN");
            dt.Columns.Add("IS_CHECK_SN_LENGTH");
            dt.Columns.Add("IS_CHECK_SAME_STRING");
            DataRow dr = dt.NewRow();
            dr["TBBR_ID"] = dgv_barcodeRule.SelectedRows[0].Cells["TBBR_ID"].Value.ToString().Trim();
            dr["RULE_NAME"] = dgv_barcodeRule.SelectedRows[0].Cells["RULE_NAME"].Value.ToString().Trim();
            dr["SN_LENGTH"] = dgv_barcodeRule.SelectedRows[0].Cells["SN_LENGTH"].Value.ToString().Trim();
            dr["SN_BEGIN"] = dgv_barcodeRule.SelectedRows[0].Cells["SN_BEGIN"].Value.ToString().Trim();
            dr["SAME_STRING"] = dgv_barcodeRule.SelectedRows[0].Cells["SAME_STRING"].Value.ToString().Trim();
            dr["SAME_STRING_BEGIN"] = dgv_barcodeRule.SelectedRows[0].Cells["SAME_STRING_BEGIN"].Value.ToString().Trim();
            dr["MATERIAL_FLAG"] = dgv_barcodeRule.SelectedRows[0].Cells["MATERIAL_FLAG"].Value.ToString().Trim();
            dr["MATERIAL_LENGTH"] = dgv_barcodeRule.SelectedRows[0].Cells["MATERIAL_LENGTH"].Value.ToString().Trim();
            dr["MATERIAL_CODE_BEGIN"] = dgv_barcodeRule.SelectedRows[0].Cells["MATERIAL_CODE_BEGIN"].Value.ToString().Trim();
            dr["IS_CHECK_SN_LENGTH"] = dgv_barcodeRule.SelectedRows[0].Cells["IS_CHECK_SN_LENGTH"].Value.ToString().Trim();
            dr["IS_CHECK_SAME_STRING"] = dgv_barcodeRule.SelectedRows[0].Cells["IS_CHECK_SAME_STRING"].Value.ToString().Trim();
            dt.Rows.Add(dr);
            _delRuleNameRowDataHandler(dt);
            this.Close();
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
