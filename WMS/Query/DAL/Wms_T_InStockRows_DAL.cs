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
    public class Wms_T_InStockRows_DAL
    {
        public static DataTable Query(string strWhere)
        {
            string strSql = string.Format(@"select No,PartNumber,PlanQty,Row,RealQty,Unit from wms_T_InStockRows {0};", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
