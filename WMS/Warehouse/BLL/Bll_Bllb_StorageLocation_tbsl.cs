using CIT.MES;
using CIT.Wcf.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.BLL
{
    public class Bll_Bllb_StorageLocation_tbsl
    {
        public static bool IsExist(string Location_SN)
        {
            string strSql = string.Format(@"SELECT count(1) FROM T_Bllb_StorageLocation_tbsl WHERE Location_SN='{0}'", Location_SN);
            return CIT.Wcf.Utils.NMS.GetTableCount(PubUtils.uContext, strSql)>0? true :false;
        }

        /// <summary>
        /// 查询物料可存放的库位信息（**注意需要考虑剔除报废仓库的库位**）(不用)
        /// </summary>
        /// <param name="container_type"></param>
        /// <param name="materialCode"></param>
        /// <returns></returns>
//        public static DataTable GetListOfMaterialLocation(string container_type, string materialCode)
//        {
//            string strSql = string.Format(@"SELECT tbsl.Location_SN,tbsl.Location_Name,QTY-Container_Qty as qty,tbsa.Area_SN,tbsa.Storage_SN FROM T_Bllb_StorageLocation_tbsl tbsl 
//LEFT JOIN T_Bllb_LocationContainer_tblc tblc on tbsl.Location_SN=tblc.Location_SN
//LEFT JOIN T_Bllb_StorageArea_tbsa tbsa on tbsa.Area_SN=tbsl.Area_SN
//WHERE tblc.container_type='{0}' AND tbsl.Container_Qty<tblc.QTY 
//and (tbsl.materialCode is null or tbsl.materialCode ='' or tbsl.materialCode='{1}')
//ORDER BY tbsl.Location_SN ASC", container_type, materialCode);
//            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
//        }
        /// <summary>
        /// 获取一个空闲的库位
        /// </summary>
        /// <param name="container_type"></param>
        /// <param name="materialCode"></param>
        /// <returns></returns>
        public static DataTable GetListOfTop1Location(string container_type, string materialCode,string storage_sn,string status_flag)
        {
            string strSql = string.Format(@"SELECT TOP 1 tbsl.Location_SN,tbsl.Location_Name,QTY-Container_Qty as qty,tbsa.Area_SN,tbsa.Storage_SN,'' as IN_FLAG FROM T_Bllb_StorageLocation_tbsl tbsl 
LEFT JOIN T_Bllb_LocationContainer_tblc tblc on tbsl.Location_SN=tblc.Location_SN
LEFT JOIN T_Bllb_StorageArea_tbsa tbsa on tbsa.Area_SN=tbsl.Area_SN
WHERE tbsl.Enable_Flag='Y' AND tblc.container_type='{0}' AND tbsl.Container_Qty<tblc.QTY and ((tbsl.Container_Qty>0 and tbsl.Status_Flag='{3}') or tbsl.Container_Qty=0)
and ((tbsl.materialCode is null or tbsl.materialCode ='' or tbsl.materialCode='{1}')or tbsl.Container_Qty=0)  and tbsa.Storage_SN='{2}'
ORDER BY tbsl.Location_SN ASC", container_type, materialCode,storage_sn,status_flag);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询库位信息(库位余量、存放的容器类型)
        /// </summary>
        /// <param name="Location_SN"></param>
        /// <returns></returns>
        public static DataTable GetListOfLocationInfo(string Location_SN)
        {
            string strSql = string.Format(@"SELECT tbsl.Container_Qty, tblc.QTY-tbsl.Container_Qty as qty,tblc.Container_Type,MaterialCode
FROM T_Bllb_StorageLocation_tbsl tbsl 
LEFT JOIN T_Bllb_LocationContainer_tblc tblc on tbsl.Location_SN=tblc.Location_SN 
WHERE tbsl.Location_SN ='{0}' order by tbsl.Container_Qty desc", Location_SN);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 获取库位上物料信息()
        /// </summary>
        /// <param name="materialCode"></param>
        /// <returns></returns>
        //        public static DataTable GetListOfMaterial(string materialCode)
        //        {
        //            string strSql = string.Format(@"SELECT *
        //FROM T_Bllb_StockInfo_tbsi tbsi LEFT JOIN (select d.DICT_VALUE,d.DICT_CODE 
        //                                                from 
        //			                                        T_Sysc_dictionaryType_tsdt as t
        //                                                inner join 
        //	                                                T_Sysc_dictionary_tsd  as d 
        //	                                                 on t.TSDT_ID=d.TSDT_ID 
        //                                                WHERE t.D_TYPECODE='RQLX') R ON R.DICT_CODE=tbsi.Container_Type
        //WHERE tbsi.Qty>0 and  tbsi.materialCode='{1}'
        //ORDER BY tbsi.Location_SN ASC", materialCode);
        //            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        //        }
        /// <summary>
        /// 获取库位现在存放的容器数量及类型
        /// </summary>
        /// <param name="Location_SN"></param>
        /// <returns></returns>
        public static DataTable GetListOfLocationContainer(string Location_SN)
        {
            string strSql = string.Format(@"SELECT Container_Type,Container_Qty,DICT_VALUE FROM T_Bllb_StorageLocation_tbsl A LEFT JOIN 
                                                         (select d.DICT_VALUE,d.DICT_CODE 
                                                        from 
        			                                        T_Sysc_dictionaryType_tsdt as t
                                                        inner join 
        	                                                T_Sysc_dictionary_tsd  as d 
        	                                                 on t.TSDT_ID=d.TSDT_ID 
                                                        WHERE t.D_TYPECODE='RQLX') R ON R.DICT_CODE=A.Container_Type
WHERE A.Location_SN='{0}' and A.Container_Qty>0", Location_SN);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public static bool Update(T_Bllb_StorageLocation_tbsl obj)
        {
            string strSql = string.Format(@"UPDATE T_Bllb_StorageLocation_tbsl SET Location_Name='{1}', Area_SN='{2}',Enable_Flag='{3}' WHERE Location_SN='{0}'", obj.Location_SN,obj.Location_Name,obj.Area_SN,obj.Enable_Flag);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改库区上容器数量信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool UpdateContainer_Qty(T_Bllb_StorageLocation_tbsl obj)
        {
            string strSql = string.Format(@"UPDATE T_Bllb_StorageLocation_tbsl SET MaterialCode='{1}', Container_Qty= Container_Qty+{2},Container_Type='{3}',Status_Flag='{4}' WHERE Location_SN='{0}'", obj.Location_SN, obj.MaterialCode, obj.Container_Qty,obj.Container_Type,obj.Status_Flag);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Insert(T_Bllb_StorageLocation_tbsl obj)
        {
            string strSql = string.Format(@"INSERT INTO T_Bllb_StorageLocation_tbsl (Location_SN,Location_Name,Area_SN,Enable_Flag) VALUES('{0}','{1}','{2}','{3}')", obj.Location_SN, obj.Location_Name, obj.Area_SN,obj.Enable_Flag);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除By库区SN
        /// </summary>
        /// <param name="Area_SN"></param>
        /// <returns></returns>
        public static bool DeleteByArea_SN(string Area_SN)
        {
            BLL.Bll_Bllb_LocationContainer_tblc.DeleteByArea_SN(Area_SN);//删除库区下所有库位的库位容器信息
            string strSql = string.Format(@"DELETE FROM T_Bllb_StorageLocation_tbsl WHERE Area_SN='{0}'", Area_SN);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除By库位SN
        /// </summary>
        /// <param name="Location_SN"></param>
        /// <returns></returns>
        public static bool DeleteByLocation_SN(string Location_SN)
        {
            BLL.Bll_Bllb_LocationContainer_tblc.DeleteByLocation_SN(Location_SN);//删除库位容器信息
            string strSql = string.Format(@"DELETE FROM T_Bllb_StorageLocation_tbsl WHERE Location_SN='{0}'", Location_SN);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询库位
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLoaction()
        {
            string strSql = string.Format("SELECT Location_SN,Location_Name FROM T_Bllb_StorageLocation_tbsl ");
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
