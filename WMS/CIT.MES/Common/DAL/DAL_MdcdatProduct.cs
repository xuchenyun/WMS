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
    /// 机种表数据层操作类
    /// </summary>
    public class DAL_MdcdatProduct
    {
        /// <summary>
        /// 获得数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            string strSql = "SELECT Fguid,ProductCode,ProductName FROM MdcdatProduct";
            if (strWhere != string.Empty)
            {
                strSql += string.Format(@" where " + strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
