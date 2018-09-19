using CIT.BLL;
using CIT.BLL.NMS;
using CIT.BLL.NMS.FlowChart;
using CIT.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace CIT.Wcf.Utils
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall, IncludeExceptionDetailInFaults = true)]
    public class NMS : INMS
    {
        public static Dictionary<string, string> AccountList = new Dictionary<string, string>();

        public static List<UserContext> OnLineUser = new List<UserContext>();

        public string CheckVer()
        {
            try
            {
                ConfigurationManager.RefreshSection("appSettings");
                return ConfigurationManager.AppSettings["ver"].ToString();
            }
            catch
            {
                throw new Exception("服务端未知版本信息");
            }
        }

        public string GetPnUniqueCode(UserContext uContext, string barcode)
        {
            try
            {
                bool flag = false;
                if (barcode.Length <= 3)
                {
                    throw new Exception("条码长度异常");
                }
                if (barcode.Substring(0, 2).Contains(":"))
                {
                    flag = true;
                }
                if (flag)
                {
                    DataTable dataTable = new DBHelper().Querydt(uContext, "select val3,val4,val5,val6 from sysdatconfig where cguid='" + barcode.Substring(0, 2) + "'", true);
                    if (dataTable.Rows.Count <= 0)
                    {
                        throw new Exception("不存在模板ID");
                    }
                    Assembly assembly = Assembly.LoadFile(dataTable.Rows[0]["val5"].ToString());
                    Type type = assembly.GetType(Path.GetFileNameWithoutExtension(dataTable.Rows[0]["val5"].ToString()) + "." + dataTable.Rows[0]["val6"].ToString());
                    object obj = assembly.CreateInstance(Path.GetFileNameWithoutExtension(dataTable.Rows[0]["val5"].ToString()) + "." + dataTable.Rows[0]["val6"].ToString());
                    List<string> list = new List<string>();
                    if (dataTable.Rows[0]["val3"].ToString().Length > 0)
                    {
                        list.Add(dataTable.Rows[0]["val3"].ToString());
                    }
                    if (dataTable.Rows[0]["val4"].ToString().Length > 0)
                    {
                        list.Add(dataTable.Rows[0]["val4"].ToString());
                    }
                    barcode = barcode.Remove(0, 2);
                    object[] parameters = new object[2]
                    {
                        barcode,
                        list
                    };
                    object obj2 = type.GetMethod("GetUniqueCode").Invoke(obj, parameters);
                    return obj2.ToString();
                }
                return barcode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool LoginUser(UserContext uContext)
        {
            return Login.LoginUser(uContext);
        }

        public DataTable GetMainMenuList(UserContext uContext, string main = "")
        {
            return Menu.GetMainMenuList(uContext, main);
        }

        public string GetColumns(UserContext uContext, int pageindex, int pagesize)
        {
            return SysDatFormColumns.GetColumns(uContext, pageindex, pagesize);
        }

        public string GetColumns(UserContext uContext, string TableCode, int pageindex, int pagesize)
        {
            return SysDatFormColumns.GetColumns(uContext, TableCode, pageindex, pagesize);
        }

        public string GetColumns(UserContext uContext, string TableCode, string type, int pageindex, int pagesize)
        {
            return SysDatFormColumns.GetColumns(uContext, TableCode, type, pageindex, pagesize);
        }

        public string GetColumns(UserContext uContext, string ClassCode, string TableCode, string type, int pageindex, int pagesize)
        {
            return SysDatFormColumns.GetColumns(uContext, ClassCode, TableCode, type, pageindex, pagesize);
        }

        public int GetTableCount(UserContext uContext, string sqlcmd, bool check = true)
        {
            return DBHelper.GetTableCounts(uContext, sqlcmd, check);
        }

        public DataSet QueryPager(UserContext uContext, string ProName, string tablename, string columnsname, string where, string orderby, string pageindex, string pagesize)
        {
            return Pager.QueryPager(uContext, ProName, tablename, columnsname, where, orderby, pageindex, pagesize);
        }

        public string QueryPager(UserContext uContext, string sqlcmd, string columns, int pageindex, int pagesize)
        {
            return Pager.QueryPager(uContext, sqlcmd, columns, pageindex, pagesize);
        }

        public string QueryPager(UserContext uContext, string sqlcmd, string columns, string orderby, int pageindex, int pagesize)
        {
            return Pager.QueryPager(uContext, sqlcmd, columns, orderby, pageindex, pagesize);
        }

        public string ConditionQueryPager(UserContext uContext, string EntityName, string where, string orderby, int pageindex, int pagesize)
        {
            return Pager.ConditionQueryPager(uContext, EntityName, where, orderby, pageindex, pagesize);
        }

        public string ConditionQueryPager(UserContext uContext, string EntityName, string where, int pageindex, int pagesize)
        {
            return Pager.ConditionQueryPager(uContext, EntityName, where, pageindex, pagesize);
        }

        public bool ExecProcedures(UserContext uContext, string ProcName, CommandType type, bool check = true, params CmdParameter[] sqlparameter)
        {
            return DBHelper.ExecProcedures(uContext, ProcName, type, check, sqlparameter);
        }

        public string ExecProceduresReturnJson(UserContext uContext, string ProcName, CommandType type, bool check = true, params CmdParameter[] sqlparameter)
        {
            return DBHelper.ExecProceduresReturnJson(uContext, ProcName, type, check, sqlparameter);
        }

        public string ConditionExactAllColumnsQueryPager(UserContext uContext, string entity, string where, int pageindex, int pagesize)
        {
            return Pager.ConditionExactAllColumnsQueryPager(uContext, entity, where, pageindex, pagesize);
        }

        public string ConditionExactSingleColumnsQueryPager(UserContext uContext, string entity, string columnName, string where, int pageindex, int pagesize)
        {
            return Pager.ConditionExactSingleColumnsQueryPager(uContext, entity, columnName, where, pageindex, pagesize);
        }

        public string ConditionExactQueryPager(UserContext uContext, string entity, string where, int pageindex, int pagesize)
        {
            return Pager.ConditionExactQueryPager(uContext, entity, where, pageindex, pagesize);
        }

        public string GetMenuBtnMap(UserContext uContext, string Menucode, string Orgid)
        {
            return Menu.GetMenuBtnMap(uContext, Menucode, Orgid);
        }

        public string GetOrgMenuMap(UserContext uContext, string OrgID, string PareantID)
        {
            return Menu.GetOrgMenuMap(uContext, OrgID, PareantID);
        }

        public string GetTabel(UserContext uContext, string sqlcmd, params CmdParameter[] sqlparameter)
        {
            SqlCommand sqlcmd2 = new DBHelper().SqlCommands(uContext, sqlcmd, true, sqlparameter);
            return DBUtils.ToJson(sqlcmd2, 0, -1);
        }

        public bool DeleteData(UserContext uContext, string entity, string columnName, string where)
        {
            return Pager.DeleteData(uContext, entity, columnName, where);
        }

        public bool DeleteData(UserContext uContext, string entity, string where)
        {
            return Pager.DeleteData(uContext, entity, where);
        }

        public Dictionary<string, string> GetAccList()
        {
            return AccountList;
        }

        public List<UserContext> GetOnLineUser()
        {
            return OnLineUser;
        }

        public UserContext GetOnLineUser(UserContext uContext)
        {
            IEnumerable<UserContext> enumerable = from n in OnLineUser.AsEnumerable()
                                                  where n.Account == uContext.Account && n.UserID == uContext.UserID && (DateTime.Now - n.Createtime).TotalSeconds < 15.0
                                                  select n into a
                                                  select (a);
            using (IEnumerator<UserContext> enumerator = enumerable.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    return enumerator.Current;
                }
            }
            return null;
        }

        public void LogOffUser(UserContext uContext)
        {
            IEnumerable<UserContext> enumerable = from n in OnLineUser.AsEnumerable()
                                                  where n.Account == uContext.Account && n.UserID == uContext.UserID
                                                  select n into a
                                                  select (a);
            using (IEnumerator<UserContext> enumerator = enumerable.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    UserContext current = enumerator.Current;
                    OnLineUser.Remove(current);
                }
            }
            IEnumerable<UserContext> source = from n in OnLineUser.AsEnumerable()
                                              where n.Account == uContext.Account && n.UserID == uContext.UserID && (DateTime.Now - n.Createtime).TotalSeconds > 60.0
                                              select n into a
                                              select (a);
            List<UserContext> list = source.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                OnLineUser.Remove(list[i]);
            }
        }

        public List<UserContext> AddOnLineUser(UserContext uContext)
        {
            IEnumerable<UserContext> enumerable = from n in OnLineUser.AsEnumerable()
                                                  where n.Account == uContext.Account && n.UserID == uContext.UserID
                                                  select n into a
                                                  select (a);
            bool flag = true;
            using (IEnumerator<UserContext> enumerator = enumerable.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    UserContext current = enumerator.Current;
                    OnLineUser.Remove(current);
                    uContext.Createtime = DateTime.Now;
                    OnLineUser.Add(uContext);
                    flag = false;
                }
            }
            if (flag)
            {
                OnLineUser.Add(uContext);
            }
            return OnLineUser;
        }

        public bool SaveFlowChartWinfrm(UserContext uContext, string ChartCode, string winfrmID, string winfrmName, string top, string left, string pwincode, string labname, string labcode)
        {
            return FlowChart.SaveFlowChartWinfrm(uContext, ChartCode, winfrmID, winfrmName, top, left, pwincode, labname, labcode);
        }

        public MitBarcode FormatMitBarCode(string sqlcmd, string UserID)
        {
            try
            {
                object obj = BarUtils._methodInfo.Invoke(BarUtils.EntityObj, new object[2]
                {
                    sqlcmd,
                    UserID
                });
                return (MitBarcode)obj;
            }
            catch
            {
                throw;
            }
        }

        public DataTable QueryDataTable(UserContext uContext, string sqlcmd, params CmdParameter[] sqlparameter)
        {
            return new DBHelper().Querydt(uContext, sqlcmd, true, sqlparameter);
        }

        public bool ExecTransql(UserContext uContext, string sqlcmd, params CmdParameter[] sqlparameter)
        {
            return new DBHelper().ExecSqlTrans(uContext, sqlcmd, sqlparameter);
        }

        public DataSet QueryDataSet(UserContext uContext, string sqlcmd, params CmdParameter[] sqlparameter)
        {
            return new DBHelper().Queryds(uContext, sqlcmd, sqlparameter);
        }
    }
}
