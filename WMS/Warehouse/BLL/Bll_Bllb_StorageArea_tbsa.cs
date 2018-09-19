using CIT.MES;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.BLL
{
    public class Bll_Bllb_StorageArea_tbsa
    {
     
        /// <summary>
        /// 仓库信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetListOfArea()
        {
            string strSql = string.Format(@"SELECT Area_Name,Area_SN
FROM t_bllb_storagearea_tbsa
order by Area_Name asc");
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public static bool Update(T_Bllb_StorageArea_tbsa obj)
        {
            string strSql = string.Format(@"UPDATE t_bllb_storagearea_tbsa SET Area_Name='{1}', Storage_SN='{2}' WHERE Area_SN='{0}'",obj.Area_SN,obj.Area_Name,obj.Storage_SN);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Insert(T_Bllb_StorageArea_tbsa obj)
        {
            string strSql = string.Format(@"INSERT INTO t_bllb_storagearea_tbsa (Area_SN,Area_Name,Storage_SN) VALUES('{0}','{1}','{2}')", obj.Area_SN, obj.Area_Name, obj.Storage_SN);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除By仓库SN
        /// </summary>
        /// <param name="Storage_SN"></param>
        /// <returns></returns>
        public static bool DeleteByStorage_SN(string Storage_SN)
        {
            string strSql = string.Format(@"DELETE FROM  t_bllb_storagearea_tbsa WHERE Storage_SN='{0}'",Storage_SN);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除By库区SN
        /// </summary>
        /// <param name="Area_SN"></param>
        /// <returns></returns>
        public static bool DeleteByArea_SN(string Area_SN)
        {
            //删除库位
            BLL.Bll_Bllb_StorageLocation_tbsl.DeleteByArea_SN(Area_SN);
            //删除库区
            string strSql = string.Format(@"DELETE FROM  t_bllb_storagearea_tbsa WHERE Area_SN='{0}'", Area_SN);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
    }
}
