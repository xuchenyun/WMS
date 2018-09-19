using CIT.MES;
using CIT.Wcf.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData.BLL
{
    public class BLL_SysdatOrg
    {
        /// <summary>
        /// 新增节点
        /// </summary>
        /// <param name="Org"></param>
        /// <returns></returns>
        public static bool InsertOrg(SysdatOrg Org)
        {
            string strSql=string.Format("insert into SysdatOrg(Guid, ParentID,text,Creator,CreateTime) Values(newid(), '{0}','{1}','{2}',getdate())",Org.ParentID,Org.text,PubUtils.uContext.UserID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改节点
        /// </summary>
        /// <param name="Org"></param>
        /// <returns></returns>
        public static bool UpdateOrg(SysdatOrg Org)
        {
            string strSql = string.Format("update SysdatOrg set text='{0}' where ID='{1}' and ParentID='{2}'", Org.text,Org.ID,Org.ParentID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        public static bool Delete(string ID)
        {
            string strSql = string.Format(@" delete SysdatOrg where ID='{0}' or ParentID='{0}'
                delete [MdcDatOrgUserMap] where orgid='{0}'", ID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
    }
}
