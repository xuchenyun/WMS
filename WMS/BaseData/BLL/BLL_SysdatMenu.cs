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
    public class BLL_SysdatMenu
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static DataTable Select(string UserID)
        {
            string strSql=string.Format(@"SELECT case when um.UserID is null then '0' else '1' end as flag,
                                            case when um.UserID is null then 'FALSE' else 'TRUE' end as CHK, m.MenuCode,m.MenuName FROM SysdatMenu m left join (SELECT * FROM SysDatUserMenuMap WHERE UserID='{0}') um on m.MenuCode=um.MenuCode ",UserID);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增
        /// </summary>
        public static bool Insert(string MenuCode, string MenuName)
        {
            string strSql = string.Format("Insert into SysdatMenu(MenuCode,MenuName) Values('{0}','{1}')", MenuCode, MenuName);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public static bool UpdateMenuName(string MenuCode, string MenuName)
        {
            string strSql = string.Format("Update SysdatMenu set MenuName='{1}' WHERE MenuCode='{0}'", MenuCode, MenuName);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool Delete(string strWhere)
        {
            string strSql = string.Format("Delete from SysdatMenu {0}", strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 是否已经存在
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool IsExist(string strWhere)
        {
            string strSql = string.Format("Select count(1) from SysdatMenu {0}", strWhere);
            return NMS.GetTableCount(PubUtils.uContext, strSql) > 0 ? true : false;
        }
    }
}
