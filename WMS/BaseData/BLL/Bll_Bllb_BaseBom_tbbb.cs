using CIT.MES;
using CIT.Wcf.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData.BLL
{
    public class Bll_Bllb_BaseBom_tbbb
    {
        /// <summary>
        /// 新增料号Bom
        /// </summary>
        /// <param name="lstBomAdd"></param>
        /// <returns></returns>
        public static bool InsertBom(List<T_Bllb_BaseBom_tbbb> lstBomAdd)
        {
            StringBuilder strB = new StringBuilder();
            foreach (T_Bllb_BaseBom_tbbb Bom in lstBomAdd)
            {
                strB.Append(string.Format("insert into T_Bllb_BaseBom_tbbb(TBPC_ID,MaterialCode,BOM_QTY,BaseQtyN,BaseQtyD) values('{0}','{1}','{2}','{3}','{4}')", Bom.TBPC_ID, Bom.MaterialCode, Bom.BOM_QTY, Bom.BaseQtyN, Bom.BaseQtyD));

            }
            return NMS.ExecTransql(PubUtils.uContext, strB.ToString());
        }
        /// <summary>
        /// 查询Bom
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable SelectBom(string strWhere)
        {
            string strSql = string.Format("select MaterialCode,BOM_QTY,BaseQtyN,BaseQtyD from  T_Bllb_BaseBom_tbbb where {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        public static bool Delete(string strWhere)
        {
            string strSql = string.Format("delete T_Bllb_BaseBom_tbbb where  {0}", strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        //public static DataTable Select(string strWhere)
        //{
        //    string strSql=string.Format("select ")
        //}
    }
}
