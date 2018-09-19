using CIT.MES;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData.BLL
{
    public class BLL_SysDatUserMenuMap
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Select(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT 'false' as 'CHK',dmm.MenuCode,dmm.UserID,menu.MenuName FROM SysDatUserMenuMap dmm left join SysdatMenu menu on dmm.MenuCode=menu.MenuCode ");
            if (strWhere != string.Empty)
            {
                strSql.Append(" Where " +strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }


        /// <summary>
        /// 新增
        /// </summary>
        public static bool Insert(string MenuCode, string UserID)
        {
            string strSql = string.Format("Insert into SysDatUserMenuMap(MenuCode,UserID) Values('{0}','{1}')", MenuCode, UserID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
 

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool Delete(string MenuCode, string UserID)
        {
            string strSql = string.Format("Delete from SysDatUserMenuMap WHERE MenuCode={0} AND UserID='{1}'", MenuCode, UserID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        public static bool Delete(string strWhere)
        {
            string strSql = string.Format("Delete from SysDatUserMenuMap {0}", strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 是否已经存在
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool IsExist(string MenuCode, string UserID)
        {
            string strSql = string.Format("Select count(1) from SysDatUserMenuMap WHERE MenuCode={0} AND UserID='{1}'", MenuCode, UserID);
            return NMS.GetTableCount(PubUtils.uContext, strSql) > 0 ? true : false;
        }
    }
}
