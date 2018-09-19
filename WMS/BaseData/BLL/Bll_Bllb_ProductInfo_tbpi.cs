using CIT.MES;
using CIT.Wcf.Utils;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData.BLL
{
    public class Bll_Bllb_ProductInfo_tbpi
    {
        /// <summary>
        /// 产品初始化
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public static bool Init(string SN,string sfcno,ref string msg)
        {
            string strSql = string.Format(@"SELECT A.TBPS_ID,B.OVER_FLAG FROM T_Bllb_productKey_tbpk A LEFT JOIN dbo.T_Bllb_productInfo_tbpi B ON B.TBPS_ID = A.TBPS_ID
WHERE A.KEY_SN='{0}' AND B.SfcNo='{1}'", SN, sfcno);
            DataTable dt_ID= NMS.QueryDataTable(PubUtils.uContext, strSql);
            if (dt_ID.Rows.Count == 0)
            {
                strSql = string.Format(@"SELECT TBPS_ID,OVER_FLAG FROM dbo.T_Bllb_productInfo_tbpi WHERE SERIAL_NUMBER='{0}'  AND SfcNo='{1}' AND LAST_FLAG='Y' ORDER BY INPUT_TIME DESC", SN, sfcno);
                dt_ID = NMS.QueryDataTable(PubUtils.uContext, strSql);
            }
            if (dt_ID.Rows.Count == 0)
            {
                msg = "当前制令单中未找到此产品SN";
                return false;
            }
            strSql = string.Format(@"DELETE FROM dbo.T_Bllb_productInfo_tbpi WHERE TBPS_ID='{0}'
DELETE FROM dbo.T_Bllb_productKey_tbpk WHERE TBPS_ID='{0}'
DELETE FROM dbo.T_Bllb_productStatus_tbps WHERE TBPS_ID='{0}'
",dt_ID.Rows[0][0].ToString());
            if (SqlInput.ChangeNullToString(dt_ID.Rows[0]["OVER_FLAG"]) == "Y")
            {
                strSql += string.Format(@" UPDATE dbo.SfcDatProduct SET InputQty=InputQty-1,ActQty=ActQty-1 WHERE SfcNo='{0}'", sfcno);
            }
            else
            {
                strSql += string.Format(@" UPDATE dbo.SfcDatProduct SET InputQty=InputQty-1 WHERE SfcNo='{0}'", sfcno);
            }
            return NMS.ExecTransql(PubUtils.uContext, strSql);

        }
    }
}
