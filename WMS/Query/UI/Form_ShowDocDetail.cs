using CIT.MES;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Query.UI
{
    public partial class Form_ShowDocDetail : Form
    {
        public List<DataGridViewRow> list_dgvr;

        DataSet ds;
        public Form_ShowDocDetail()
        {
            InitializeComponent();
        }

        private void Form_ShowDocDetail_Load(object sender, EventArgs e)
        {
            StringBuilder strbildLook = new StringBuilder();
            foreach (DataGridViewRow dgvr in list_dgvr)
            {
                string s_doc_no = SqlInput.ChangeNullToString(dgvr.Cells["S_Doc_NO"].Value);
                strbildLook.AppendFormat(@"
SELECT  a.S_Doc_NO AS '单据号' ,
        CASE a.S_Doc_Type
          WHEN c.TYPE_CODE THEN c.TYPE_NAME
        END AS '单据类型' ,
        b.SerialNumber AS '条码' ,
        b.MaterialCode AS '料号' ,
        b.DateCode ,
        b.QTY AS '数量' ,
        b.MPN,
        a.Creator AS '创建人' ,
        a.Create_Time AS '创建时间' ,
        a.Before_Doc_No AS '上游单据' ,
        CASE a.IsAutoCreate
          WHEN 'N' THEN '人工开单'
          WHEN 'Y' THEN '自动生成'
          ELSE '人工开单'
        END '是否自动生成' 
FROM    dbo.T_Bllb_StorageDoc_tbsd AS a
        LEFT JOIN dbo.T_Bllb_StorageDocDetail_tbsdd AS b ON a.S_Doc_NO = b.S_Doc_NO
        LEFT JOIN dbo.T_Bllb_DocType_tbdt AS c ON c.TYPE_CODE = a.S_Doc_Type
WHERE   a.S_Doc_NO = '{0}'", s_doc_no);
            }
            if (strbildLook.Length > 0)
            {
                ds = CIT.Wcf.Utils.NMS.QueryDataSet(CIT.MES.PubUtils.uContext, strbildLook.ToString());
                foreach (DataTable dt in ds.Tables)
                {
                    TabPage tab_Page = new TabPage();
                    tab_Page.Text = SqlInput.ChangeNullToString(dt.Rows[0]["单据号"]);
                    DataGridView t_dgvr = new DataGridView();
                    t_dgvr.DataSource = dt;
                    t_dgvr.ReadOnly = true;
                    t_dgvr.AllowUserToAddRows = false;
                    t_dgvr.Dock = DockStyle.Fill;
                    tab_Page.Controls.Add(t_dgvr);
                    tab_data.TabPages.Add(tab_Page);
                }
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
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
                Common.Helper.ExcelHelper.GetExcelByDataSet(ds, filepath);
                new PubUtils().ShowNoteOKMsg("导出成功");
            }
            catch
            {
                new PubUtils().ShowNoteNGMsg("导出失败", 2, grade.OrdinaryError);
            }
        }
    }
}
