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
    public class T_Bllb_StorageDoc_tbsd_DAL
    {
        /// <summary>
        /// 单据汇总查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryDoc(string strWhere)
        {
            string strSql = string.Format(@"select a.S_Doc_NO,a.PO,u.UserName, a.Create_Time,b.MaterialCode,b.QTY,b.RowNumber,c.TYPE_NAME from  T_Bllb_StorageDoc_tbsd a
left join T_Bllb_StorageDocMaterial_tsdm b on a.S_Doc_NO=b.S_Doc_NO
left join T_Bllb_DocType_tbdt c on a.S_Doc_Type=c.TYPE_CODE
left join SysDatUser u on a.Creator=u.UserID {0}",strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
