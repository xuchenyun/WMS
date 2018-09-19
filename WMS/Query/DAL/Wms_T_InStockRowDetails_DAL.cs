using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT.MES;
using CIT.Wcf.Utils;
using System.Data;

namespace Query.DAL
{
    public class Wms_T_InStockRowDetails_DAL
    {
        public static DataTable Query(string strWhere)
        {
            string strSql = string.Format(@"select BillNo,PartNumber,CreateTime,Creator,LotNo,BoxNo from wms_T_InStockRowDetails {0};", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
