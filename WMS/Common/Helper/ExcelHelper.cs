using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Data.OleDb;
using System.Web;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using NPOI.HSSF.UserModel;
using Aspose.Cells;

namespace Common.Helper
{
    /// <summary>
    /// Excel操作类
    /// </summary>
    /// Microsoft Excel 11.0 Object Library
    public class ExcelHelper
    {
        public ExcelHelper()
        {

        }
        public static string OpenDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel文件(*.xls,xlsx)|*.xls;*.xlsx";
            ofd.Title = "请选择Excel文件";
            ofd.Multiselect = false;
            string filePath = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            return filePath;
        }
        /// <summary>
        /// Excel导入成Datable
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static DataTable ExcelToTable(string file)
        {
            DataTable dt = new DataTable();
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                //XSSFWorkbook 适用XLSX格式，HSSFWorkbook 适用XLS格式
                if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(fs); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(fs); } else { workbook = null; }
                if (workbook == null) { return null; }
                ISheet sheet = workbook.GetSheetAt(0);

                //表头  
                IRow header = sheet.GetRow(sheet.FirstRowNum);
                List<int> columns = new List<int>();
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = GetValueType(header.GetCell(i));
                    if (obj == null || obj.ToString() == string.Empty)
                    {
                        dt.Columns.Add(new DataColumn("Columns" + i.ToString().Trim()));
                    }
                    else
                        dt.Columns.Add(new DataColumn(obj.ToString().Trim()));
                    columns.Add(i);
                }
                //数据  
                for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {
                    DataRow dr = dt.NewRow();
                    bool hasValue = false;
                    foreach (int j in columns)
                    {
                        dr[j] = GetValueType(sheet.GetRow(i).GetCell(j));
                        if (dr[j] != null && dr[j].ToString() != string.Empty)
                        {
                            hasValue = true;
                        }
                    }
                    if (hasValue)
                    {
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Datable导出成Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file"></param>
        public static void TableToExcel(DataTable dt, string file)
        {
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(); } else { workbook = null; }
            if (workbook == null) { return; }
            ISheet sheet = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("Sheet1") : workbook.CreateSheet(dt.TableName);

            //表头  
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            //数据  
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            //转为字节数组  
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            var buf = stream.ToArray();

            //保存为Excel文件  
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Length);
                fs.Flush();
            }
        }
        /// <summary>
        /// 获取单元格类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.BLANK: //BLANK:  
                    return null;
                case CellType.BOOLEAN: //BOOLEAN:  
                    return cell.BooleanCellValue;
                case CellType.NUMERIC: //NUMERIC:  
                    return cell.NumericCellValue;
                case CellType.STRING: //STRING:  
                    return cell.StringCellValue;
                case CellType.ERROR: //ERROR:  
                    return cell.ErrorCellValue;
                case CellType.FORMULA: //FORMULA:  
                default:
                    return "=" + cell.CellFormula;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="lst_Type">列名|数据类型（1：Int;2:Decimal;3:string）</param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool DataGridViewToExcel(DataGridView dgv, Dictionary<string, int> dic_Type, out string error)
        {
            error = "";
            string filepath = string.Empty;
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXECL文件";
            kk.Filter = "*.xls|*.xls";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            filepath = kk.FileName;
            if (File.Exists(filepath))
                File.Delete(filepath);
            Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
            try
            {
                if (dgv == null)
                {
                    error = "DataTableToExcel:datatable 为空";
                    return false;
                }

                //为单元格添加样式    
                Aspose.Cells.Style style = wb.Styles[wb.Styles.Add()];
                //设置居中
                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
                //设置背景颜色
                style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0);
                style.Pattern = BackgroundType.Solid;
                style.Font.IsBold = true;
                int columnsIndex = 0;
                int rowIndex = 0;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible == true & dgv.Columns[i].HeaderText != string.Empty)
                    {
                        wb.Worksheets[0].Cells[rowIndex, columnsIndex].PutValue(dgv.Columns[i].HeaderText);
                        wb.Worksheets[0].Cells[rowIndex, columnsIndex].SetStyle(style);
                        columnsIndex++;
                    }
                }
                rowIndex++;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    columnsIndex = 0;
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (row.Cells[i].Visible == true & row.Cells[i].OwningColumn.HeaderText != string.Empty)
                        {
                            if (dic_Type.ContainsKey(dgv.Columns[i].HeaderText))
                            {
                                switch (dic_Type[dgv.Columns[i].HeaderText])
                                {
                                    case 1:
                                        wb.Worksheets[0].Cells[rowIndex, columnsIndex].PutValue(int.Parse(row.Cells[i].FormattedValue.ToString()));
                                        break;
                                    case 2:
                                        wb.Worksheets[0].Cells[rowIndex, columnsIndex].PutValue(decimal.Parse(row.Cells[i].FormattedValue.ToString()));
                                        break;
                                    case 3:
                                        wb.Worksheets[0].Cells[rowIndex, columnsIndex].PutValue(row.Cells[i].FormattedValue.ToString());
                                        break;
                                }

                            }
                            else
                            {
                                wb.Worksheets[0].Cells[rowIndex, columnsIndex].PutValue(row.Cells[i].FormattedValue);
                            }
                            columnsIndex++;
                        }

                    }
                    rowIndex++;
                }
                columnsIndex = 0;
                for (int k = 0; k < dgv.Columns.Count; k++)
                {
                    if (dgv.Columns[k].Visible == true & dgv.Columns[k].HeaderText != string.Empty)
                    {
                        wb.Worksheets[0].AutoFitColumn(columnsIndex, 0, 150);
                        columnsIndex++;
                    }

                }
                wb.Worksheets[0].FreezePanes(1, 0, 1, columnsIndex);
                wb.Save(filepath);
                return true;
            }
            catch (Exception e)
            {
                error = error + " DataTableToExcel: " + e.Message;
                return false;
            }

        }

        /// <summary>
        /// 根据DataSet导出Excel
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="file">保存地址</param>
        public static void GetExcelByDataSet(DataSet ds, string file)
        {
            IWorkbook fileWorkbook = new HSSFWorkbook();
            int index = 0;
            foreach (DataTable dt in ds.Tables)
            {
                index++;
                ISheet sheet = fileWorkbook.CreateSheet("Sheet" + index);

                //表头
                IRow row = sheet.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = row.CreateCell(i);
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                }

                //数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row1 = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }
            }

            //转为字节数组
            MemoryStream stream = new MemoryStream();
            fileWorkbook.Write(stream);
            var buf = stream.ToArray();

            //保存为Excel文件
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Length);
                fs.Flush();
            }
        }
    }
}