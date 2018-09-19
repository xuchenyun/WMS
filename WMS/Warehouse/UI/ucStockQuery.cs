using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseData.DAL;
using Warehouse.BLL;
using CIT.MES;
using System.IO;

namespace Warehouse.UI
{
    public partial class ucStockQuery : UserControl
    {
        public ucStockQuery()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            Query();
            new PubUtils().ShowNoteOKMsg("查询成功");

        }
        private void Query()
        {
            string strWhere = "";
            if (cbo_stockName.SelectedValue.ToString() != string.Empty)
            {
                strWhere += string.Format(" AND a.Storage_SN='{0}'", cbo_stockName.SelectedValue.ToString());
            }
            if (txt_materialCode.Text != string.Empty)
            {
                strWhere += string.Format(" And a.MaterialCode='{0}'", txt_materialCode.Text.Trim());
            }
            if (txt_serialNumber.Text != string.Empty)
            {
                strWhere += string.Format(" And a.SerialNumber='{0}'", txt_serialNumber.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtLocation.Text.Trim()))
            {
                strWhere += string.Format(" And d.Location_Name='{0}'", txtLocation.Text.Trim());
            }
            DataTable dt_Stock = Bll_Bllb_StockInfo_tbsi.Select(strWhere);
            dgv_Stock.DataSource = dt_Stock;
        }

        private void uc_Load(object sender, EventArgs e)
        {
            DataTable dt = MdcdatMaterial_DAL.QueryHouseCode();
            DataRow dr = dt.NewRow();
            dr["Storage_Name"] = "";
            dr["Storage_SN"] = "";
            dt.Rows.InsertAt(dr, 0);
            cbo_stockName.DataSource = dt;
            cbo_stockName.DisplayMember = "Storage_Name";
            cbo_stockName.ValueMember = "Storage_SN";
        }
        /// <summary>
        /// 双击复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Stock_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_Stock, e);
        }

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
                StringBuilder strbid = new StringBuilder("AND 1=1 ");
                if (cbo_stockName.SelectedValue.ToString() != string.Empty)
                {
                    strbid.AppendFormat(" AND a.Storage_SN='{0}'", cbo_stockName.SelectedValue.ToString());
                }
                if (!string.IsNullOrEmpty(txt_materialCode.Text))
                {
                    strbid.AppendFormat(" AND a.MaterialCode='{0}'", txt_materialCode.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txt_serialNumber.Text))
                {
                    strbid.AppendFormat(" AND a.SerialNumber='{0}'", txt_serialNumber.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtLocation.Text.Trim()))
                {
                    strbid.AppendFormat(" AND d.Location_Name='{0}'", txtLocation.Text.Trim());
                }
                DataTable dt_export = Bll_Bllb_StockInfo_tbsi.QueryExportDetail(strbid.ToString());
                Common.Helper.ExcelHelper.TableToExcel(dt_export, filepath);
                new PubUtils().ShowNoteOKMsg("导出成功");
            }
            catch
            {

                new PubUtils().ShowNoteNGMsg("导出失败", 2, grade.OrdinaryError);
            }
        }
        #region 按Enter键查询
        private void txt_materialCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("查询成功");
            }
        }

        private void txt_serialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("查询成功");
            }
        }

        private void txtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("查询成功");
            }
        }

        private void cbo_stockName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Query();
            new PubUtils().ShowNoteOKMsg("查询成功");
        }
        #endregion
    }
}
