using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CIT.Wcf.Utils;
using CIT.MES;
using Model;

namespace Warehouse.BLL
{
    public class Bll_Bllb_StorageDocMaterial_tsdm
    {
      
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool InsertOrUpdate(Model.T_Bllb_StorageDocMaterial_tsdm obj)
        {
            string strSql = string.Format(@" SELECT COUNT(1) FROM T_Bllb_StorageDocMaterial_tsdm WHERE S_Doc_NO='{0}' AND MaterialCode='{1}'", obj.S_Doc_NO, obj.MaterialCode);
            if(NMS.GetTableCount(PubUtils.uContext, strSql)==0)
            {
                strSql = string.Format(@"INSERT INTO T_Bllb_StorageDocMaterial_tsdm(S_Doc_NO,MaterialCode,QTY) VALUES('{0}','{1}',{2})", obj.S_Doc_NO, obj.MaterialCode, obj.QTY);
            }
            else
            {
                strSql = string.Format(@"UPDATE T_Bllb_StorageDocMaterial_tsdm SET QTY =QTY+{2} WHERE S_Doc_NO='{0}' AND MaterialCode='{1}'", obj.S_Doc_NO, obj.MaterialCode, obj.QTY);
            }
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 往库存料号表新增调拨数据
        /// </summary>
        /// <param name="lstAddEntity"></param>
        /// <returns></returns>
        public static bool InsertMaterial(List<T_Bllb_StorageDocMaterial_tsdm> lstAddEntity)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (T_Bllb_StorageDocMaterial_tsdm SCD in lstAddEntity)
            {
                strSql.Append(string.Format(@" insert into T_Bllb_StorageDocMaterial_tsdm(S_Doc_NO, RowNumber, MaterialCode,  Plan_Qty) Values('{0}','{1}','{2}','{3}')", SCD.S_Doc_NO,SCD.RowNumber, SCD.MaterialCode, SCD.Plan_Qty));

            }
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        public static DataTable Select(string strWhere)
        {
            //string strSql = string.Format(@"select MaterialCode,QTY,Plan_Qty,RowNumber  from T_Bllb_StorageDocMaterial_tsdm where {0} ", strWhere);
            //return NMS.QueryDataTable(PubUtils.uContext, strSql);
            string strSql = string.Format(@"SELECT a.MaterialCode, sum (a.QTY) as QTY,b.Plan_Qty,b.RowNumber FROM T_Bllb_StockInfo_tbsi a
 LEFT JOIN T_Bllb_StorageDocMaterial_tsdm b ON a.MaterialCode=b.MaterialCode
 {0} and Lock_Flag='0' GROUP BY a.MaterialCode,b.Plan_Qty,b.RowNumber  ", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        public static DataTable Query(string strWhere)
        {
            string strSql = string.Format(@"select MaterialCode,QTY,Plan_Qty,RowNumber  from T_Bllb_StorageDocMaterial_tsdm where {0} ", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        public static bool DeleteMaterial(string strWhere)
        {
            string strSql = string.Format("delete T_Bllb_StorageDocMaterial_tsdm where {0}", strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        public static DataTable SelectSDocMatr(string strWhere)
        {
            string strSql = string.Format(@"select S_Doc_NO,MaterialCode,QTY from T_Bllb_StorageDocMaterial_tsdm where {0} ", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }

    }
}
