using CIT.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.BLL
{
    public class Bll_Bllb_Storage_tbs
    {
        /// <summary>
        /// 仓库库区库位信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetListOfAll()
        {
            string strSql = string.Format(@"SELECT tbs.Storage_Name,tbs.Storage_SN,tbs.Storage_Type,tbs.Respons_Person,tbsa.Area_SN,
tbsa.Area_Name,tbsl.Location_SN,tbsl.Location_Name,tbsl.Enable_Flag,tbs.step
FROM T_Bllb_Storage_tbs tbs 
left join t_bllb_storagearea_tbsa tbsa on tbs.Storage_SN=tbsa.Storage_SN
left join T_Bllb_StorageLocation_tbsl tbsl on tbsl.area_sn=tbsa.area_sn
order by tbs.Storage_Name asc,tbsa.Area_Name asc,tbsl.Location_Name asc");
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 仓库信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetListOfStorage(string strWhere)
        {
            string strSql = string.Format(@"SELECT tbs.Storage_Name,tbs.Storage_SN,tbs.Storage_Type
FROM T_Bllb_Storage_tbs tbs  {0}
order by tbs.Storage_Name asc", strWhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Insert(Model.T_Bllb_Storage_tbs obj)
        {
            string strSql = string.Format(@"INSERT INTO T_Bllb_Storage_tbs(Storage_SN,Storage_Name,Storage_Type,Step,Respons_Person) VALUES('{0}','{1}','{2}','{3}','{4}')", obj.Storage_SN, obj.Storage_Name, obj.Storage_Type, obj.Step, obj.Respons_Person);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Update(Model.T_Bllb_Storage_tbs obj)
        {
            string strSql = string.Format(@"UPDATE T_Bllb_Storage_tbs SET Storage_Name='{1}',Storage_Type='{2}',Step='{3}',Respons_Person='{4}' WHERE Storage_SN='{0}'", obj.Storage_SN, obj.Storage_Name, obj.Storage_Type, obj.Step, obj.Respons_Person);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除仓库SN
        /// </summary>
        /// <param name="Storage_SN"></param>
        /// <returns></returns>
        public static bool Delete(string Storage_SN)
        {
            string strSql = string.Format(@"SELECT Area_Name,Area_SN FROM t_bllb_storagearea_tbsa WHERE Storage_SN='{0}'", Storage_SN);
            DataTable dt_area = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
            foreach (DataRow dr in dt_area.Rows)
            {
                //删除库位
                BLL.Bll_Bllb_StorageLocation_tbsl.DeleteByArea_SN(dr["Area_SN"].ToString());
            }
            //删除库区
            BLL.Bll_Bllb_StorageArea_tbsa.DeleteByStorage_SN(Storage_SN);
            //删除仓库
            strSql = string.Format(@"DELETE FROM t_bllb_storage_tbs WHERE Storage_SN='{0}'", Storage_SN);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
    }
}
