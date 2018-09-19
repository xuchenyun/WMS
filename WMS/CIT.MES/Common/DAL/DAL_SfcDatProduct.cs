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
            string strSql = string.Format(" select FGuid,SfcNo,Product,ProductName,CONVERT(varchar(100), GETDATE(), 112) NOW_DATE,WOCODE,Line,TBT_ID from SfcDatProduct where SfcNo ='{0}'", sfcDatPro.SfcNo);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }

    }
}
