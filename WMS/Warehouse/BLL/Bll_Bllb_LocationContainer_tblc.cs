using CIT.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.BLL
{
    public class Bll_Bllb_LocationContainer_tblc
    {
        /// <summary>
        /// 获取库位所能存放的容器信息
        /// </summary>
        /// <param name="Locatin_SN"></param>
        /// <returns></returns>
        public static DataTable GetListByLocatin_SN(string Locatin_SN)
        {
            string strSql = string.Format(@"select d.DICT_VALUE,d.DICT_CODE ,case when tblc.Container_Type is null then '0' else '1' end as flag,
                                            case when tblc.Container_Type is null then 'FALSE' else 'TRUE' end as checkId,case when tblc.QTY is null then '1' else  convert(varchar(20),tblc.QTY) end as QTY
                                              from 
			                                    T_Sysc_dictionaryType_tsdt as t
                                             inner join 
	                                            T_Sysc_dictionary_tsd  as d 
	                                              on t.TSDT_ID=d.TSDT_ID 
											 LEFT JOIN (SELECT * FROM T_Bllb_LocationContainer_tblc where Location_SN='{0}') tblc
											      on tblc.Container_Type=d.DICT_CODE
                                                     WHERE T.D_TYPECODE='RQLX' ORDER BY d.DICT_VALUE", Locatin_SN);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Insert(Model.T_Bllb_LocationContainer_tblc obj)
        {
            string strSql = string.Format(@"INSERT INTO T_Bllb_LocationContainer_tblc(Location_SN,Container_Type,QTY) VALUES('{0}','{1}',{2})",obj.Location_SN,obj.Container_Type,obj.QTY);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Delete(Model.T_Bllb_LocationContainer_tblc obj)
        {
            string strSql = string.Format(@"DELETE FROM T_Bllb_LocationContainer_tblc WHERE Location_SN='{0}' AND Container_Type='{1}'", obj.Location_SN, obj.Container_Type);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Update(Model.T_Bllb_LocationContainer_tblc obj)
        {
            string strSql = string.Format(@"Update T_Bllb_LocationContainer_tblc set QTY='{2}' WHERE Location_SN='{0}' AND Container_Type='{1}'", obj.Location_SN, obj.Container_Type,obj.QTY);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除By库位SN
        /// </summary>
        /// <param name="Location_SN"></param>
        /// <returns></returns>
        public static bool DeleteByLocation_SN(string Location_SN)
        {
            string strSql = string.Format(@"DELETE FROM T_Bllb_LocationContainer_tblc WHERE Location_SN='{0}'", Location_SN);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除By库区SN
        /// </summary>
        /// <param name="Area_SN"></param>
        /// <returns></returns>
        public static bool DeleteByArea_SN(string Area_SN)
        {
            string strSql = string.Format(@"DELETE FROM T_Bllb_LocationContainer_tblc WHERE Location_SN IN (SELECT Location_SN FROM T_Bllb_StorageLocation_tbsl tbsl where tbsl.Area_SN='{0}')", Area_SN);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
     
    }
}
