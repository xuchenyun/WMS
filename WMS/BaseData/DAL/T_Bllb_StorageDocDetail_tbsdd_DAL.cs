using CIT.MES;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData.DAL
{
    public class T_Bllb_StorageDocDetail_tbsdd_DAL
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Query(string strWhere)
        {
            string strSql = string.Format(@"  select a.S_Doc_NO,a.MaterialCode,a.SerialNumber,a.QTY,u.Creator,a.Create_Time,DateCode, b.TYPE_NAME from T_Bllb_StorageDocDetail_tbsdd  a left join  T_Bllb_DocType_tbdt b  
  on a.S_Doc_NO like (RTRIM(TYPE_HEAD)+'%') left join SysDatUser u on a.Creator=u.UserID {0} ", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext,strSql);
        }
    }
}
