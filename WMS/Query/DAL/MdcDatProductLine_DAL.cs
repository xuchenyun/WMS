using Model;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CIT.MES;

namespace Query.DAL
{
    /// <summary>
    /// 线别表数据层访问类
    /// </summary>
    public class MdcDatProductLine_DAL
    {
        /// <summary>
        /// 查询产品在线信息
        /// </summary>
        /// <param name="sfc"></param>
        /// <param name="line"></param>
        /// <param name="Pro"></param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT sfc.SfcNo,sfc.WoCode,sfc.Product,sfc.ProductName,line.PLName,sfc.ActStart,sfc.PlanQty,sfc.ActQty
                                     FROM SfcDatProduct AS sfc LEFT JOIN MdcDatProductLine AS line ON sfc.Line=line.plcode  ");
            if (strWhere != string.Empty)
            {
                strSql.Append(strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
 
    }
}
