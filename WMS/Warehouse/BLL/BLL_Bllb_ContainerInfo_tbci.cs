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
    public class Bll_Bllb_ContainerInfo_tbci
    {
        public static DataTable GetList(string strWhere)
        {
            string strSql = string.Format(@"select 'FALSE' as checkId,Container_SN,Container_Type
                                              from T_Bllb_ContainerInfo_tbci {0}", strWhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool Delete(string strWhere)
        {
            string strSql = string.Format(@" DELETE FROM T_Bllb_ContainerInfo_tbci {0}",strWhere);
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
            string strSql = string.Format(@" INSERT INTO T_Bllb_ContainerInfo_tbci(Container_SN,Container_Type) VALUES('{0}','{1}')", container_sn,container_type);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="Container_SN"></param>
        /// <returns></returns>
        public static bool IsExist(string Container_SN)
        {
            string strSql = string.Format("Select count(1) from T_Bllb_ContainerInfo_tbci where Container_SN='{0}'", Container_SN);
            return NMS.GetTableCount(PubUtils.uContext, strSql) > 0 ? true : false;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="container_sn"></param>
        /// <param name="container_type"></param>
        /// <returns></returns>
        public static bool Update(string container_sn, string container_type)
        {
            string strSql = string.Format(@" UPDATE T_Bllb_ContainerInfo_tbci SET Container_Type='{1}' WHERE Container_SN='{0}'", container_sn, container_type);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
    }
}
