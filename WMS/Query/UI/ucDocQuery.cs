using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Query.DAL;
using CIT.MES;
using CIT.Wcf.Utils;
using BaseData.DAL;
using System.IO;

namespace Query.UI
{
    public partial class ucDocQuery : UserControl
    {
        public ucDocQuery()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            string strWhere = " Where 1=1";
            if (txt_Doc_NO.Text != string.Empty)
            {
                strWhere += string.Format(" AND a.S_Doc_NO='{0}'", txt_Doc_NO.Text.Trim());//单据号
            }
            if (txt_MaterialCode.Text != string.Empty)
            {
                strWhere += string.Format(" AND a.MaterialCode='{0}'", txt_MaterialCode.Text.Trim());//料号
            }
            if (txt_SerialNumber.Text != string.Empty)
            {
                strWhere += string.Format(" AND a.SerialNumber='{0}'", txt_SerialNumber.Text.Trim());//类型
            }
            if (cbo_Type.SelectedValue.ToString() != string.Empty)
            {
                strWhere += string.Format(" ANd TYPE_NAME='{0}'", cbo_Type.SelectedValue.ToString());
            }
            DataTable dt = T_Bllb_StorageDocDetail_tbsdd_DAL.Query(strWhere);
            dgv_barCode.DataSource = dt;
        }
       

        private void uc_Load(object sender, EventArgs e)
        {
            string strSql = string.Format("select TYPE_NAME from T_Bllb_DocType_tbdt where Enable='Y'");
            DataTable dt_Type = NMS.QueryDataTable(PubUtils.uContext, strSql);
            DataRow dr_Type = dt_Type.NewRow();
            dr_Type["TYPE_NAME"] = "";
            dt_Type.Rows.InsertAt(dr_Type, 0);
            cbo_Type.DataSource = dt_Type;
            cbo_Type.DisplayMember = "TYPE_NAME";
            cbo_Type.ValueMember = "TYPE_NAME";
        }
        /// <summary>
        /// 双击复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_barCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_barCode, e);
        }
        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string filepath = string.Empty;
                SaveFileDialog sd = new SaveFileDialog();
                sd.Title = "保存EXECL文件";
                sd.Filter = "*.xls|*.xls";
                sd.FilterIndex = 1;
                if (sd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                filepath = sd.FileName;
                if (File.Exists(filepath))
                    File.Delete(filepath);
                string strWhere = "Where 1=1";
                if (txt_Doc_NO.Text!= string.Empty)
                {
                    strWhere += string.Format(" AND a.S_Doc_NO='{0}'", txt_Doc_NO.Text);
                }
                if (txt_MaterialCode.Text != string.Empty)
                {
                    strWhere += string.Format(" AND a.MaterialCode='{0}'", txt_MaterialCode.Text.Trim());
                }
                if (txt_SerialNumber.Text != string.Empty)
                {
                    strWhere += string.Format(" AND a.SerialNumber='{0}'", txt_SerialNumber.Text);
                }
                if (cbo_Type.SelectedValue.ToString() != string.Empty)
                {
                    strWhere += string.Format(" AND  TYPE_NAME='{0}'", cbo_Type.SelectedValue.ToString());
                }
                DataTable dt_all = T_Bllb_StorageDocDetail_tbsdd_DAL.QueryALL(strWhere);
                Common.Helper.ExcelHelper.TableToExcel(dt_all, filepath);
                new PubUtils().ShowNoteOKMsg("导出成功");
            }
            catch
            {
                new PubUtils().ShowNoteNGMsg("导出失败", 2, grade.OrdinaryError);
            }
        }
    }
}
