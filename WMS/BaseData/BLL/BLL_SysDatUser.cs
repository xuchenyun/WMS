using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CIT.MES;
using CIT.Client;
using CIT.Wcf.Utils;
using Model;

namespace BaseData.BLL
{
    public class BLL_SysDatUser
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Select(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT 'false' as 'CHK',UserID,UserName,Password FROM SysDatUser ");
            if (strWhere != string.Empty)
            {
                strSql.Append(strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        public static bool Insert(string UserID, string UserName, string pwd)
        {
            string strSql = string.Format("Insert into SysDatUser(UserID,UserName,Password) Values('{0}','{1}','{2}')", UserID, UserName, Common.Helper.Encrypt.Encryption(pwd + UserID));
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改用户名
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        public static bool UpdateUserName(string UserID, string UserName)
        {
            string strSql = string.Format("Update SysDatUser set UserName='{1}' WHERE UserID='{0}'", UserID, UserName);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool UpdatePassword(string UserID, string Password)
        {
            string strSql = string.Format("Update SysDatUser set Password='{1}' WHERE UserID='{0}'", UserID, Common.Helper.Encrypt.Encryption(Password + UserID));
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool Delete(string strWhere)
        {
            string strSql = string.Format("Delete from SysDatUser {0}", strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 用户是否已经存在
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool IsExist(string strWhere)
        {
            string strSql = string.Format("Select count(1) from SysDatUser {0}", strWhere);
            return NMS.GetTableCount(PubUtils.uContext, strSql) > 0 ? true : false;
        }
        /// <summary>
        /// 查询用户所属部门
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryUserOrg(string strWhere)
        {
            string strSql = string.Format(" select a.UserID,a.UserName,c.text  from SysDatUser as a left join [MdcDatOrgUserMap] as b on a.UserID=b.UserID left join SysdatOrg as c on b.OrgID=c.ID {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增用户表和用户组织表
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool InsertUserOrg(SysDatUser user, SysdatOrg Org)
        {
            string strSql = string.Format(@"insert into SysDatUser(UserID,UserName,Creator,CreateTime,Password) Values('{0}','{1}','{2}',getdate(),'{4}')
insert into MdcDatOrgUserMap(UserID,OrgID,Creator,CreateTime) Values('{0}','{3}','{2}',getdate())", user.UserID, user.UserName, PubUtils.uContext.UserID, Org.ID, Common.Helper.Encrypt_DES.Encryption("123456" + user.UserID));
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改用户表和用户组织表
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Org"></param>
        /// <returns></returns>
        public static bool UpdateUserOrg(SysDatUser user, SysdatOrg Org)
        {
            string strSql = string.Format(@"update SysDatUser set UserName='{2}' where UserID='{1}'
update MdcDatOrgUserMap set OrgID='{0}',updator='{3}',updateTime=getdate() where UserID='{1}'", Org.ID, user.UserID, user.UserName, PubUtils.uContext.UserID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        public static bool DeleteUserOrg(string userID)
        {
            string strSql = string.Format(@"delete SysDatUser where UserID='{0}'
delete MdcDatOrgUserMap where UserID='{0}'", userID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);

        }
    }
}
