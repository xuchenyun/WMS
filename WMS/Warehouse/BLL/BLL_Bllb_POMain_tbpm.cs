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
    public class Bll_Bllb_POMain_tbpm
    {
        public static DataTable GetList(string PO)
        {
            string strSql = string.Format(@"select B.MaterialCode,B.RowNumber,A.SupplierCode from T_Bllb_POMain_tbpm A 
LEFT JOIN dbo.T_Bllb_PODetail_tbpd B ON A.PO=B.PO
WHERE A.PO='{0}'", PO);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }

        /// <summary>
        /// 绑定采购单(未关闭的单据)
        /// </summary>
        /// <returns></returns>
        public static DataTable DataBindPO()
        {
            string strSql = string.Format(@"SELECT PO,POID FROM dbo.T_Bllb_POMain_tbpm WHERE Status='1' AND PO_TypeCode='1'");
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool Delete(string strWhere)
        {
            string strSql = string.Format(@" DELETE FROM T_Bllb_POMain_tbpm {0}",strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="container_sn"></param>
        /// <param name="container_type"></param>
        /// <returns></returns>
        public static bool Insert(string container_sn,string container_type)
        {
            string strSql = string.Format(@" INSERT INTO T_Bllb_POMain_tbpm(Container_SN,Container_Type) VALUES('{0}','{1}')", container_sn,container_type);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="PO"></param>
        /// <returns></returns>
        public static bool IsExist(string PO)
        {
            string strSql = string.Format("Select count(1) from T_Bllb_POMain_tbpm where PO='{0}'", PO);
            return NMS.GetTableCount(PubUtils.uContext, strSql) > 0 ? true : false;
        }

    }
}
