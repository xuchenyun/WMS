using CIT.MES;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.DAL
{
    public class Wms_T_InStockDAL
    {
        public static DataTable Query(string strWhere)
        {
            string strSql = string.Format(@"select No,BillType,Creator,CreateTime,InstockNo,Status from wms_T_InStock {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
