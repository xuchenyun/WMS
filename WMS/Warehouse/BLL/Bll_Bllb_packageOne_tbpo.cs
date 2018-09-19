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
    public static class Bll_Bllb_packageOne_tbpo
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Query(string strWhere)
        {
            string strSql = string.Format("select * from T_Bllb_packageOne_tbpo {0}", strWhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryData(string strWhere)
        {
            string strSql = string.Format(@"select s.WoCode,o.SFC_NO,o.CONTAINER_SN_1 AS SN,'一级容器' as SN_TYPE,sum(i.Qty) as  Qty ,i.INOUT_STATUS,PRINT_FLAG 
                            from T_Bllb_packageOne_tbpo  as  o
                            left join T_Bllb_productInfo_tbpi as i on o.TBPS_ID=i.TBPS_ID 
                            left join SfcDatProduct as s on s.SfcNo=o.SFC_NO  {0}
							group by s.WoCode,o.SFC_NO,o.CONTAINER_SN_1,i.INOUT_STATUS,PRINT_FLAG ", strWhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryProductInfo(string strWhere)
        {
            string strSql = string.Format(@"select i.TBPS_ID,o.SFC_NO from T_Bllb_packageOne_tbpo as o
                                left join T_Bllb_productInfo_tbpi as i on o.TBPS_ID=i.TBPS_ID {0}", strWhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 一级包装信息解箱根据TBPS_ID
        /// </summary>
        /// <param name="tbpo"></param>
        /// <returns></returns>
        public static bool RelieveBoxByID(string TBPS_ID)
        {
            string strSql = string.Format("delete from T_Bllb_packageOne_tbpo where TBPS_ID='{0}'", TBPS_ID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 变更一级容器条码
        /// </summary>
        /// <param name="container_SN">一级容器条码</param>
        /// <returns></returns>
        public static bool UpdateContainer_SN_1(string container_SN)
        {
            string strSql = string.Format(@"UPDATE T_Bllb_packageOne_tbpo SET CONTAINER_SN_1=CONTAINER_SN_1+'-'+CONVERT(varchar(100), GETDATE(), 12) WHERE CONTAINER_SN_1='{0}'", container_SN);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }

        /// <summary>
        /// 变更一级容器条码
        /// </summary>
        /// <param name="old_container_SN">旧的一级容器条码</param>
        /// <param name="new_container_SN">新的一级容器条码</param>
        /// <returns></returns>
        public static bool UpdateContainer_SN_1(string old_container_SN, string new_container_SN)
        {
            string strSql = string.Format(@"UPDATE T_Bllb_packageOne_tbpo SET CONTAINER_SN_1='{1}' WHERE CONTAINER_SN_1='{0}'", old_container_SN, new_container_SN);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 通过关键件或产品条码获取容器和产品信息
        /// </summary>
        /// <param name="SN">关键件SN/产品条码</param>
        /// <returns></returns>
        public static DataTable GetList(string SN)
        {
            string strSql = string.Format(@"SELECT tbpi.SERIAL_NUMBER,tbpo.CONTAINER_SN_1,s.product FROM T_Bllb_productInfo_tbpi tbpi left join T_Bllb_productKey_tbpk tbpk
on tbpi.TBPS_ID=tbpk.TBPS_ID inner join T_Bllb_packageOne_tbpo tbpo on tbpo.TBPS_ID=tbpi.TBPS_ID
left join SfcDatProduct as s on tbpi.SfcNo = s.SfcNo WHERE tbpk.KEY_SN='{0}'", SN);
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                strSql = string.Format(@"SELECT tbpi.SERIAL_NUMBER,tbpo.CONTAINER_SN_1,s.product FROM T_Bllb_productInfo_tbpi tbpi 
inner join T_Bllb_packageOne_tbpo tbpo on tbpo.TBPS_ID=tbpi.TBPS_ID
left join SfcDatProduct as s on tbpi.SfcNo = s.SfcNo WHERE tbpi.SERIAL_NUMBER='{0}'", SN);
                return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
            }
        }
    }
}
