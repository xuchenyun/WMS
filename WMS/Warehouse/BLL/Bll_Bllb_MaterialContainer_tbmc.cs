using CIT.MES;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.BLL
{
    public class Bll_Bllb_MaterialContainer_tbmc
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select 'false' as 'CHK', MaterialCode,Container_Type,Qty from T_Bllb_MaterialContainer_tbmc");
            if (strWhere != string.Empty)
            {
                strSql.Append(" Where "+ strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 查询容器存放物料的个数
        /// </summary>
        /// <param name="MaterialCode"></param>
        /// <param name="Container_Type"></param>
        /// <returns></returns>
        public static DataTable GetList(string MaterialCode,string Container_Type)
        {
            string  strSql = string.Format(@"Select Qty from T_Bllb_MaterialContainer_tbmc WHERE MaterialCode='{0}' AND Container_Type='{1}'",MaterialCode,Container_Type);
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }

    }
}
