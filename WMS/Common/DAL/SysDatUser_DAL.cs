using CIT.MES;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Common.DAL
{
    /// <summary>
    /// 用户表数据层访问类
    /// </summary>
    public class SysDatUser_DAL
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetList()
        {
            string strSql = "SELECT GUID,UserID,UserName FROM SysDatUser";
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
