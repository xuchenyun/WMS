using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIT.MES.Common.Helper
{
    public class AnalysisBarCodeHelper
    {
        public static BarcodeUtils BUtils = new BarcodeUtils();
        /// <summary>
        /// 条码解析
        /// </summary>
        /// <param name="varBarCode"></param>
        /// <param name="varReelId"></param>
        /// <returns></returns>
        public static string AnalysisBarCode(string varBarCode, out string varReelId)
        {
            BarcodeUtils.BarObject barobj = new BarcodeUtils.BarObject();
            var AnalysisSerPath = "0.0.0.0";
            System.Data.DataTable dt_barcode = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select val1 from sysdatconfig where key1='barcodeanlysis'");
            if (dt_barcode.Rows.Count > 0 && dt_barcode.Rows[0][0] != null && dt_barcode.Rows[0][0].ToString().Length > 0)
            {
                AnalysisSerPath = dt_barcode.Rows[0][0].ToString();
            }
            if (AnalysisSerPath != "0.0.0.0" && AnalysisSerPath != null)
            {
                barobj = BUtils.AnalysisBarcode(AnalysisSerPath, varBarCode);
                varReelId = barobj.reelId;
            }
            else
            {
                varReelId = string.Empty;
            }
            return varReelId;
        }
    }
}
