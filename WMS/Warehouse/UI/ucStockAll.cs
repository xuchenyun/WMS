using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse.BLL;
using CIT.MES;
using BaseData.DAL;
using System.IO;
using Common.Helper;

namespace Warehouse.UI
{
    public partial class ucStockAll : UserControl
    {

        DataTable dtSource = new DataTable();
        DataTable dt_area = new DataTable();
        DataTable dt_location = new DataTable();
        public ucStockAll()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 库存汇总
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_stockAll_Click(object sender, EventArgs e)
        {
            Query();
            new PubUtils().ShowNoteOKMsg("汇总完成");
        }
        private void Query()
        {
            #region 按所选项汇总 如：只选择仓库就对仓库汇总，只选择仓库库区就对仓库库区汇总
            //StringBuilder strGroup = new StringBuilder();
            //string querywhere = string.Empty;
            //string querycolumn = ",b.Storage_Name";
            //strGroup.Append("b.Storage_Name");
            //if (cbo_stockName.SelectedValue.ToString() != string.Empty)
            //{
            //    querywhere += string.Format(" AND b.Storage_Name='{0}'", cbo_stockName.Text.ToString());
            //}
            //if (SqlInput.ChangeNullToString(cbo_area.SelectedValue) != string.Empty)
            //{
            //    querywhere += string.Format(" AND c.Area_Name='{0}'", cbo_area.Text.ToString());
            //    querycolumn += string.Format(",c.Area_Name");
            //    strGroup.Append(",c.Area_Name");
            //}
            //if (SqlInput.ChangeNullToString(cbo_location.SelectedValue) != string.Empty)
            //{
            //    querywhere += string.Format(" AND d.Location_Name='{0}'", cbo_location.Text.ToString());
            //    querycolumn += string.Format(",d.Location_Name");
            //    strGroup.Append(",d.Location_Name");
            //}
            //if (txt_materialCode.Text.Trim() != string.Empty)
            //{
            //    querywhere += string.Format(" AND a.MaterialCode='{0}'", txt_materialCode.Text.Trim());
            //}
            //querycolumn += string.Format(",a.MaterialCode");
            //strGroup.Append(",a.MaterialCode");
            //DataTable dt_Stock = Bll_Bllb_StockInfo_tbsi.SelectAll(querywhere, querycolumn, strGroup.ToString());
            //if (!dt_Stock.Columns.Contains("Area_Name"))
            //    dt_Stock.Columns.Add("Area_Name");
            //if (!dt_Stock.Columns.Contains("Location_Name"))
            //    dt_Stock.Columns.Add("Location_Name");
            //if (!dt_Stock.Columns.Contains("MaterialCode"))
            //    dt_Stock.Columns.Add("MaterialCode");
            //if (!dt_Stock.Columns.Contains("QTY"))
            //    dt_Stock.Columns.Add("QTY");
            //dtSource = dt_Stock.Copy();
            //dgv_stockAll.DataSource = dtSource;
            #endregion
            #region 仓库库区库位料号都带出来
            string strWhere = " Where 1=1 ";
            if (cbo_stockName.SelectedValue.ToString() != string.Empty)
            {
                strWhere += string.Format(" AND b.Storage_Name='{0}' ", cbo_stockName.Text);                   
            }
            if (SqlInput.ChangeNullToString( cbo_area.SelectedValue) != string.Empty)
            {
                strWhere += string.Format(" AND c.Area_Name='{0}'", cbo_area.Text);
            }
            if (SqlInput.ChangeNullToString( cbo_location.SelectedValue) != string.Empty)
            {
                strWhere += string.Format(" AND d.Location_Name='{0}'", cbo_location.Text);
            }
            if (txt_materialCode.Text.Trim() != string.Empty)
            {
                strWhere += string.Format(" AND a.MaterialCode='{0}'", txt_materialCode.Text.Trim());
            }
            DataTable dt = Bll_Bllb_StockInfo_tbsi.SelectStock(strWhere);
            dgv_stockAll.DataSource = dt;
            #endregion
        }

        private void ucStockAll_Load(object sender, EventArgs e)
        {
            //仓库
            DataTable dt_storage = MdcdatMaterial_DAL.QueryHouseCode();
            DataRow dr_storage = dt_storage.NewRow();
            dr_storage["Storage_Name"] = "";
            dr_storage["Storage_SN"] = "";
            dt_storage.Rows.InsertAt(dr_storage, 0);
            cbo_stockName.DataSource = dt_storage;
            cbo_stockName.DisplayMember = "Storage_Name";
            cbo_stockName.ValueMember = "Storage_SN";

            //库区
            dt_area = Bll_Bllb_StorageArea_tbsa.GetListOfArea();
            DataRow dr_area = dt_area.NewRow();
            dr_area["Area_Name"] = "";
            dr_area["Area_SN"] = "";
            dt_area.Rows.InsertAt(dr_area, 0);
            cbo_area.DataSource = dt_area;
            cbo_area.DisplayMember = "Area_Name";
            cbo_area.ValueMember = "Area_SN";

            //库位
            dt_location = Bll_Bllb_StorageLocation_tbsl.GetLoaction();
            DataRow dr_location = dt_location.NewRow();
            dr_location["Location_SN"] = "";
            dr_location["Location_Name"] = "";
            dt_location.Rows.InsertAt(dr_location, 0);
            cbo_location.DataSource = dt_location;
            cbo_location.DisplayMember = "Location_Name";
            cbo_location.ValueMember = "Location_SN";
        }
        /// <summary>
        /// 双击复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_stockAll_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_stockAll, e);
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
                #region 注释掉 只导出所选项
                //string querywhere = string.Empty;
                //string querycolumn = ",b.Storage_Name as '仓库'";
                //StringBuilder strGroup = new StringBuilder();
                //strGroup.Append("b.Storage_Name");
                //if (cbo_stockName.SelectedValue.ToString() != string.Empty)
                //{
                //    querywhere += string.Format(" AND b.Storage_Name='{0}'", cbo_stockName.Text.ToString());
                //}
                //if (SqlInput.ChangeNullToString(cbo_area.SelectedValue) != string.Empty)
                //{
                //    querywhere += string.Format(" AND c.Area_Name='{0}'", cbo_area.Text.ToString());
                //    querycolumn += string.Format(",c.Area_Name as '库区'");
                //    strGroup.Append(",c.Area_Name");
                //}
                //if (SqlInput.ChangeNullToString(cbo_location.SelectedValue) != string.Empty)
                //{
                //    querywhere += string.Format(" AND d.Location_Name='{0}'", cbo_location.Text.ToString());
                //    querycolumn += string.Format(",d.Location_Name as '库位'");
                //    strGroup.Append(",d.Location_Name");
                //}
                //if (txt_materialCode.Text.Trim() != string.Empty)
                //{
                //    querywhere += string.Format(" AND a.MaterialCode='{0}'", txt_materialCode.Text.Trim());
                //}
                //querycolumn += string.Format(",a.MaterialCode as '料号'");
                //strGroup.Append(",a.MaterialCode");
                //DataTable dt_all = Bll_Bllb_StockInfo_tbsi.QueryExportAll(querywhere, querycolumn, strGroup.ToString());
                //dt_all.Columns["QTY"].SetOrdinal(dt_all.Columns.Count - 1);


                #endregion
                #region 按仓库、库区、库位、料号导出

                string strWhere = " Where 1=1";
                if (cbo_stockName.SelectedValue.ToString() != string.Empty)
                {
                    strWhere += string.Format(" AND b.Storage_Name='{0}' ", cbo_stockName.Text);
                }
                if (SqlInput.ChangeNullToString( cbo_area.SelectedValue) != string.Empty)
                {
                    strWhere += string.Format(" AND c.Area_Name='{0}'", cbo_area.Text);
                }
                if (SqlInput.ChangeNullToString( cbo_location.SelectedValue) != string.Empty)
                {
                    strWhere += string.Format(" AND d.Location_Name='{0}'", cbo_location.Text);
                }
                if (txt_materialCode.Text.Trim() != string.Empty)
                {
                    strWhere += string.Format("AND a.MaterialCode='{0}'", txt_materialCode.Text.Trim());
                }
                DataTable dt_all = Bll_Bllb_StockInfo_tbsi.StockExportAll(strWhere);
                #endregion
                Common.Helper.ExcelHelper.TableToExcel(dt_all, filepath);
                new PubUtils().ShowNoteOKMsg("导出成功");
            }
            catch
            {
                new PubUtils().ShowNoteNGMsg("导出失败", 2, grade.OrdinaryError);
            }
        }

        /// <summary>
        /// 点仓库带出库区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbo_stockName_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string strWhere = " Where 1=1";
            if (cbo_stockName.SelectedValue.ToString() != string.Empty)
            {
                strWhere += string.Format(" AND a.Storage_SN='{0}'", cbo_stockName.SelectedValue.ToString());
            }
            DataTable dt_storage = Bll_Bllb_StockInfo_tbsi.QueryStorage(strWhere);
            if (dt_storage.Rows.Count > 0)//若查到库区则带出库区
            {
                DataRow dr_area = dt_storage.NewRow();
                dr_area["Area_Name"] = "";
                dr_area["Area_SN"] = "";
                dt_storage.Rows.InsertAt(dr_area, 0);
                cbo_area.DataSource = dt_storage;
                cbo_area.DisplayMember = "Area_Name";
                cbo_area.ValueMember = "Area_SN";
                GetLocation();
            }
            else//若查不出库区，则清空库区，再用仓库查询库位
            {
                cbo_area.DataSource = null;
                cbo_location.DataSource = null;
                GetLocation();//

            }
        }
        /// <summary>
        /// 带出库位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbo_area_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetLocation();
        }
        /// <summary>
        /// 根据仓库、库区查询库位
        /// </summary>
        private void GetLocation()
        {
            string strWhere = " Where 1=1";
            if (cbo_stockName.SelectedValue.ToString() != string.Empty)
            {
                strWhere += string.Format(" AND a.Storage_SN='{0}'", cbo_stockName.SelectedValue.ToString());
            }
            if (Common.Helper.SqlInput.ChangeNullToString(cbo_area.SelectedValue) != string.Empty)
            {
                strWhere += string.Format(" AND a.Area_SN='{0}'", cbo_area.SelectedValue.ToString());
            }
            DataTable dt_location = Bll_Bllb_StockInfo_tbsi.QueryLocation(strWhere);
            if (dt_location.Rows.Count > 0)
            {
                DataRow dr_location = dt_location.NewRow();
                dr_location["Location_Name"] = "";
                dr_location["Location_SN"] = "";
                dt_location.Rows.InsertAt(dr_location, 0);
                cbo_location.DataSource = dt_location;
                cbo_location.DisplayMember = "Location_Name";
                cbo_location.ValueMember = "Location_SN";

            }
            else
            {

                cbo_location.DataSource = null;//若查不到库位则清空库位数据源
            }
        }
    }
}
