using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CIT.Wcf.Utils;

namespace CIT.MES.DAL
{
    class Login_DAL
    {
        public static string CheckVersion(string sysCodeString)
        {
            string Version = string.Empty;
            string strSql = string.Format(
                @"SELECT SysVersion 
                    FROM SysDatVersion
                   WHERE SysCode = '{0}'", sysCodeString);
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, strSql);
            if (dt != null && dt.Rows.Count > 0
                && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
            {
                Version = dt.Rows[0][0].ToString();
            }
            return Version;
        }
    }
}
