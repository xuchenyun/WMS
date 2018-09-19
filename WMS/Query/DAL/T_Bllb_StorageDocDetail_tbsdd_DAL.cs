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
            string strSql = string.Format(@"
select a.S_Doc_NO,a.MaterialCode,a.SerialNumber,a.QTY,a.Lot_No,
CASE  a.Creator WHEN u.UserID THEN u.UserName END 'Creator',a.Create_Time,DateCode, b.TYPE_NAME,
CASE a.Receive_Flag WHEN 'Y' THEN '是' WHEN 'N' THEN '否' END AS 'Receive_Flag'
FROM T_Bllb_StorageDocDetail_tbsdd  a left join  T_Bllb_DocType_tbdt b  
on a.S_Doc_NO like (RTRIM(TYPE_HEAD)+'%') 
LEFT join SysDatUser u on a.Creator=u.UserID {0} ", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext,strSql);
        }
        public static DataTable QueryALL(string strWhere)
        {
            string strSql = string.Format(@"
select a.S_Doc_NO as '单据号',a.MaterialCode as '料号',a.SerialNumber as '唯一码',b.TYPE_NAME as '类型',
a.QTY as '数量',a.Lot_No as 'Lot_No',
CASE  a.Creator WHEN u.UserID THEN u.UserName END '创建人',a.Create_Time as '创建时间',DateCode as 'DateCode', 
CASE a.Receive_Flag WHEN 'Y' THEN '是' WHEN 'N' THEN '否' END AS '是否交接'
FROM T_Bllb_StorageDocDetail_tbsdd  a left join  T_Bllb_DocType_tbdt b  
on a.S_Doc_NO like (RTRIM(TYPE_HEAD)+'%') 
LEFT join SysDatUser u on a.Creator=u.UserID {0} ", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
