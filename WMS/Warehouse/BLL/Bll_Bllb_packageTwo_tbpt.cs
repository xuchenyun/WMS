using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT.MES;
using System.Data;

namespace Warehouse.BLL
{
    public static class Bll_Bllb_packageTwo_tbpt
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Query(string strWhere)
        {
            string strSql = string.Format("select * from T_Bllb_packageTwo_tbpt {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryData(string strWhere)
        {
            string strSql = string.Format(@"select s.WoCode,o.SFC_NO,t.CONTAINER_SN_2 AS SN,'二级容器' as SN_TYPE,sum(i.Qty) as  Qty ,i.INOUT_STATUS 
                            from T_Bllb_packageTwo_tbpt as t
							left join T_Bllb_packageOne_tbpo  as  o on t.CONTAINER_SN_1=o.CONTAINER_SN_1
                            left join T_Bllb_productInfo_tbpi as i on o.TBPS_ID=i.TBPS_ID 
                            left join SfcDatProduct as s on s.SfcNo=o.SFC_NO {0}
							group by s.WoCode,o.SFC_NO,t.CONTAINER_SN_2,i.INOUT_STATUS", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询二级容器中产品的信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryProductInfo(string strWhere)
        {
            string strSql = string.Format(@"select i.TBPS_ID,o.SFC_NO from T_Bllb_packageTwo_tbpt as t
                            left join T_Bllb_packageOne_tbpo as o on t.CONTAINER_SN_1=o.CONTAINER_SN_1
                            left join T_Bllb_productInfo_tbpi as i on o.TBPS_ID=i.TBPS_ID {0}", strWhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 二级包装解箱根据一级容器SN（解除某一个一级容器SN与二级容器SN之间的关系）
        /// </summary>
        /// <param name="CONTAINER_SN_1">一级容器SN</param>
        /// <returns></returns>
        public static bool RelieveBoxBySN(string CONTAINER_SN_1)
        {
            string strSql = string.Format("delete from T_Bllb_packageTwo_tbpt where CONTAINER_SN_1='{0}'", CONTAINER_SN_1);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 变更二级容器下所有一级容器条码
        /// </summary>
        /// <param name="container_SN"></param>
        /// <returns></returns>
        public static bool UpdateContainer(string container_SN)
        {
            //修改一级容器表中一级容器条码
            string strSql = string.Format(@"UPDATE T_Bllb_packageOne_tbpo SET CONTAINER_SN_1=CONTAINER_SN_1+'-'+CONVERT(varchar(100), GETDATE(), 12) WHERE CONTAINER_SN_1 IN (SELECT CONTAINER_SN_1 FROM T_Bllb_packageTwo_tbpt WHERE CONTAINER_SN_2='{0}')", container_SN);
            NMS.ExecTransql(PubUtils.uContext, strSql);
            strSql = string.Format(@"UPDATE T_Bllb_packageTwo_tbpt SET CONTAINER_SN_1=CONTAINER_SN_1+'-'+CONVERT(varchar(100), GETDATE(), 12) WHERE CONTAINER_SN_2='{0}'", container_SN);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
    }
}
