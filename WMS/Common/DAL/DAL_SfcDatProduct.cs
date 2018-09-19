using Model;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CIT.MES;

namespace Common.DAL
{
    /// <summary>
    /// 制令单数据层操作类
    /// </summary>
    public class DAL_SfcDatProduct
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT FGuid,SfcNo,WoCode,TBT_ID,Product FROM SfcDatProduct");
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        public DataTable GetProInfoBySfcno(SfcDatProduct sfcDatPro)
        {
            string strSql = string.Format(@" select E.C_PartNumber, E.Version,SFC.FGuid,SFC.SfcNo,SFC.Product,SFC.ProductName,CONVERT(varchar(100), GETDATE(), 112) NOW_DATE,SFC.WOCODE,SFC.Line,SFC.TBT_ID from SfcDatProduct SFC
               LEFT JOIN dbo.T_Work_Number E ON E.WoCode = SFC.WoCode   where SFC.SfcNo ='{0}'", sfcDatPro.SfcNo);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }

    }
}
