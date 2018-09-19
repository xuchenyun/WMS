using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CIT.MES.WMS
{
    class ImportExcel
    {
        public ImportExcel()
        {
        }
        public DataSet ReadExcel()
        {
            OpenFileDialog frm = new OpenFileDialog();
            frm.Filter = "Excel文件(*.xls,xlsx)|*.xls;*.xlsx";
            string filePath = "";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                filePath = frm.FileName;
            }
            else
                return null;
            string connStr = "";
            string fileType = Path.GetExtension(filePath);
            if (string.IsNullOrEmpty(fileType))
            {
                return null;
            }
            if (fileType == ".xls")
            {
                connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            }
            else
            {
                connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filePath + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            }
            string sql_F = "Select * FROM [{0}]";
            OleDbConnection conn = null;
            OleDbDataAdapter da = null;
            DataTable dtSheetName = null;
            DataSet ds = new DataSet();
            try
            {
                conn = new OleDbConnection(connStr);
                conn.Open();
                string SheetName = "";
                //获取Sheet名称及相关信息
                dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                da = new OleDbDataAdapter();
                for (int i = 0; i < dtSheetName.Rows.Count; i++)
                {
                    SheetName = (string)dtSheetName.Rows[i]["TABLE_NAME"];

                    if (SheetName.Contains("$") && !SheetName.Replace("'", "").EndsWith("$"))
                    {
                        continue;
                    }

                    da.SelectCommand = new OleDbCommand(String.Format(sql_F, SheetName), conn);
                    DataSet dsItem = new DataSet();
                    //da.Fill(dsItem, tblName);
                    da.Fill(dsItem, SheetName);

                    ds.Tables.Add(dsItem.Tables[0].Copy());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    da.Dispose();
                    conn.Dispose();
                }
            }
            return ds;
        }

        public void ImportSql(DataSet ds)
        {
            if (ds == null && ds.Tables[0] == null)
            {
                return;
            }
            DataTable dt = ds.Tables[0];
            //if (dt.Select("物料编号 is null").Length > 0 || dt.Select("convert(物料编号,'System.String')='" + string.Empty + "'").Length > 0 || dt.Select("是否多包装 is null").Length > 0 || dt.Select("convert(是否多包装,'System.String')='" + string.Empty + "'").Length > 0)
            //{
            //    CIT.Client.MsgBox.Error("导入文件的物料编号或是否有多包装有空值或空格，不能导入");
            //    return;
            //}
            int dsrows = dt.Rows.Count;
            string insertSql = "";
            for (int i = 0; i < dsrows; i++)
            {
                if (dt.Rows[i][0].ToString().Trim() != "" && dt.Rows[i][0].ToString().Trim() != "null")
                {
                    //insertSql += @"insert into MdcDatMPN(newPN,GuaranteePeriod,SupplierID,SupplierName,ManufacturerLocation,MaterialType,Purchase)values('" + dt.Rows[i][0].ToString().Trim() + "','" + dt.Rows[i][1].ToString().Trim() + "','" + dt.Rows[i][2].ToString().Trim() + "','" + dt.Rows[i][3].ToString().Trim() + "','" + dt.Rows[i][4].ToString().Trim() + "','" + dt.Rows[i][5].ToString().Trim() + "','"+dt.Rows[i][6].ToString().Trim()+"')";
                    insertSql += string.Format(@" if exists (select newPN from MdcDatMPN where newPN='{0}')
begin
update MdcDatMPN set [oldPN]='{1}',[MaterialMinCount]='{2}',[MorePack]='{3}',[CustomerType]='{4}',[SupplierName]='{5}',[ManufacturerLocation]='{6}',[MaterialType]='{7}',MSDLevel='{8}',
ShelfType='{9}',IsEnable='{10}',[Purchase]='{11}',[PartCode1]='{12}',[PartCode2]='{13}',[PartCode3]='{14}',[PartCode4]='{15}',[PartCode5]='{16}',[PartCode6]='{17}',[PartCode7]='{18}',
[PartCode8]='{19}',[PartCode9]='{20}',[PartCode10]='{21}',[PartCode11]='{22}',[PartCode12]='{23}',[PartCode13]='{24}',[PartCode14]='{25}',[PartCode15]='{26}',Creator='{27}',IsBing='{28}',
[Recordtime]=GETDATE() where newPN='{0}'
end
else begin
	INSERT INTO [dbo].[MdcDatMPN]
           ([newPN]
           ,[oldPN]
           ,[MaterialMinCount]
           ,[MorePack]
           ,[CustomerType]
		   ,[SupplierName]
           ,[ManufacturerLocation]
           ,[MaterialType],MSDLevel,ShelfType,IsEnable
           ,[Purchase]
           ,[PartCode1]
           ,[PartCode2]
           ,[PartCode3]
           ,[PartCode4]
           ,[PartCode5]
           ,[PartCode6]
           ,[PartCode7]
           ,[PartCode8]
           ,[PartCode9]
           ,[PartCode10]
           ,[PartCode11]
           ,[PartCode12]
           ,[PartCode13]
           ,[PartCode14]
           ,[PartCode15]
           ,[Recordtime]
           ,[Type]
           ,[PNYorN]
           ,[Creator])
     VALUES
           ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}',GETDATE(),0,'N','{27}','{28}') 
end
", dt.Rows[i][0].ToString().Trim(), dt.Rows[i][1].ToString().Trim(), dt.Rows[i][2].ToString().Trim(), dt.Rows[i][3].ToString().Trim(), dt.Rows[i][4].ToString().Trim(),
     dt.Rows[i][5].ToString().Trim(), dt.Rows[i][6].ToString().Trim(), dt.Rows[i][7].ToString().Trim(), dt.Rows[i][8].ToString().Trim(), dt.Rows[i][9].ToString().Trim(),
     dt.Rows[i][10].ToString().Trim(), dt.Rows[i][11].ToString().Trim(), dt.Rows[i][12].ToString().Trim(), dt.Rows[i][13].ToString().Trim(), dt.Rows[i][14].ToString().Trim(),
     dt.Rows[i][15].ToString().Trim(), dt.Rows[i][16].ToString().Trim(), dt.Rows[i][17].ToString().Trim(), dt.Rows[i][18].ToString().Trim(), dt.Rows[i][19].ToString().Trim(),
     dt.Rows[i][20].ToString().Trim(), dt.Rows[i][21].ToString().Trim(), dt.Rows[i][22].ToString().Trim(), dt.Rows[i][23].ToString().Trim(), dt.Rows[i][24].ToString().Trim(),
     dt.Rows[i][25].ToString().Trim(), dt.Rows[i][26].ToString().Trim(), PubUtils.uContext.UserName, dt.Rows[i][27].ToString().Trim()
    );
                    if (dsrows - i > 100 && dsrows % 100 == 0)
                    {
                        //DBUtils.ExecTranSQL(insertSql);
                        NMS.ExecTransql(CIT.MES.PubUtils.uContext, insertSql);
                        insertSql = "";
                    }
                    else if (dsrows - i < 100 && dsrows - i == 1)
                    {
                        //DBUtils.ExecTranSQL(insertSql);
                        NMS.ExecTransql(CIT.MES.PubUtils.uContext, insertSql);
                        insertSql = "";
                    }
                }
            }
            CIT.Client.MsgBox.Info("导入完成");
            //int tablecount = ds.Tables.Count;
            //int PNColumnindex = 100000;
            //int supplierIDIndex = 100000;
            //int supplierNameIndex = 100000;
            //int manufacturerLocationIndex = 100000;
            //int materialTypeIndex = 100000;
            //int guaranteePeriodIndex = 100000;
            //foreach (DataColumn item in ds.Tables[0].Columns)
            //{
            //    if (item.ColumnName=="物料编号")
            //    {

            //    }
            //}
        }
    }
}
