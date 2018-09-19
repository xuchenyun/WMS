using CIT.Interface;
using CIT.LUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CIT.BLL
{
	public class DBHelper
	{
		public static Dictionary<string, string> accList = new Dictionary<string, string>();

		private Random ran = new Random();

		private string GetAccount(string account)
		{
            //if (!accList.Keys.Contains(account))
            //{
            //	throw new Exception("账套[" + account + "]不存在或未设置数据库连接方式");
            //}
            //return accList[account];

            return "server=.;database=WMS;user id=sa;password=Password01!";

        }

		private bool CheckPermission(UserContext uContext, string sqlcmd, CmdParameter[] sqlparameter = null)
		{
			if (Encry.LinceseInfo.DeadLine)
			{
				if (Encry.LinceseInfo.DeadDay <= 0)
				{
					throw new Exception("Licese已经到期,请联系供应商.");
				}
				throw new Exception(Encry.LinceseInfo.DeadMsg);
			}
			if (Common.StartPro)
			{
				ProSQLFile proSQLFile = new ProSQLFile();
				proSQLFile.UserID = uContext.UserID;
				proSQLFile.UserName = uContext.UserName;
				proSQLFile.SqlCmd = sqlcmd;
				proSQLFile.Createtime = DateTime.Now;
				Common.ProFileSqlList.Add(proSQLFile);
			}
			return true;
		}

		private void GetProfileSql(string sql, string userID)
		{
		}

		private DataTable QueryUserList(UserContext uContext)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(GetAccount(uContext.Account)))
				{
					sqlConnection.Open();
					using (SqlCommand selectCommand = new SqlCommand("select count(*) from sysdatuser where userid='" + uContext.UserID + "'", sqlConnection))
					{
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						return dataTable;
					}
				}
			}
			catch
			{
				throw;
			}
		}

		public int GetTableCount(UserContext uContext, string sqlcmd, bool check = true)
		{
			try
			{
				CheckPermission(uContext, sqlcmd);
				using (SqlConnection sqlConnection = new SqlConnection(GetAccount(uContext.Account)))
				{
					sqlConnection.Open();
					using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcmd, sqlConnection))
					{
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						if (dataTable != null)
						{
							if (dataTable.Rows.Count > 0)
							{
								return Convert.ToInt32(dataTable.Rows[0][0].ToString());
							}
							return 0;
						}
						return 0;
					}
				}
			}
			catch
			{
				return 0;
			}
		}

		public object GetSingle(UserContext uContext, string sqlcmd, bool check = true, params CmdParameter[] sqlparameter)
		{
			try
			{
				if (check)
				{
					CheckPermission(uContext, sqlcmd, sqlparameter);
				}
				using (SqlConnection sqlConnection = new SqlConnection(GetAccount(uContext.Account)))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand(sqlcmd, sqlConnection))
					{
						for (int i = 0; i < sqlparameter.Length; i++)
						{
							sqlCommand.Parameters.Add(sqlparameter[i].ParameterName, sqlparameter[i].Value);
						}
						object obj = sqlCommand.ExecuteScalar();
						sqlCommand.Transaction = sqlConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
						sqlCommand.Connection = sqlConnection;
						sqlCommand.CommandText = sqlcmd;
						sqlCommand.Transaction.Commit();
						sqlCommand.Parameters.Clear();
						if (object.Equals(obj, null) || object.Equals(obj, DBNull.Value))
						{
							return null;
						}
						return obj;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public DataTable Querydt(UserContext uContext, string sqlcmd, bool Check = true, params CmdParameter[] sqlparameter)
		{
			try
			{
				if (Check)
				{
					CheckPermission(uContext, sqlcmd, sqlparameter);
				}
				using (SqlConnection sqlConnection = new SqlConnection(GetAccount(uContext.Account)))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand(sqlcmd, sqlConnection))
					{
						for (int i = 0; i < sqlparameter.Length; i++)
						{
							sqlCommand.Parameters.Add(sqlparameter[i].ParameterName, sqlparameter[i].Value);
						}
						using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
						{
							DataTable dataTable = new DataTable();
							dataTable.TableName = "datatable";
							sqlDataAdapter.Fill(dataTable);
							sqlCommand.Parameters.Clear();
							return dataTable;
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public DataSet Queryds(UserContext uContext, string sqlcmd, params CmdParameter[] sqlparameter)
		{
			try
			{
				CheckPermission(uContext, sqlcmd, sqlparameter);
				using (SqlConnection sqlConnection = new SqlConnection(GetAccount(uContext.Account)))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand(sqlcmd, sqlConnection))
					{
						for (int i = 0; i < sqlparameter.Length; i++)
						{
							sqlCommand.Parameters.Add(sqlparameter[i].ParameterName, sqlparameter[i].Value);
						}
						using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
						{
							DataSet dataSet = new DataSet();
							sqlDataAdapter.Fill(dataSet, "ds");
							sqlCommand.Parameters.Clear();
							return dataSet;
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public IDataReader DataReader(UserContext uContext, string sqlcmd, out SqlCommand cmd, bool check = true, params CmdParameter[] sqlparameter)
		{
			try
			{
				CheckPermission(uContext, sqlcmd, sqlparameter);
				SqlConnection sqlConnection = new SqlConnection(GetAccount(uContext.Account));
				cmd = new SqlCommand(sqlcmd, sqlConnection);
				sqlConnection.Open();
				for (int i = 0; i < sqlparameter.Length; i++)
				{
					cmd.Parameters.Add(sqlparameter[i].ParameterName, sqlparameter[i].Value);
				}
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public SqlCommand SqlCommands(UserContext uContext, string sqlcmd, bool check = true, params CmdParameter[] sqlparameter)
		{
			try
			{
				CheckPermission(uContext, sqlcmd, sqlparameter);
				SqlConnection sqlConnection = new SqlConnection(GetAccount(uContext.Account));
				SqlCommand sqlCommand = new SqlCommand(sqlcmd, sqlConnection);
				sqlConnection.Open();
				for (int i = 0; i < sqlparameter.Length; i++)
				{
					sqlCommand.Parameters.Add(sqlparameter[i].ParameterName, sqlparameter[i].Value);
				}
				return sqlCommand;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool ExecProcedure(UserContext uContext, string ProcName, CommandType type, bool check = true, params CmdParameter[] sqlparameter)
		{
			try
			{
				CheckPermission(uContext, ProcName, sqlparameter);
				bool result = false;
				using (SqlConnection sqlConnection = new SqlConnection(GetAccount(uContext.Account)))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand())
					{
						sqlCommand.Connection = sqlConnection;
						sqlCommand.CommandText = ProcName;
						sqlCommand.CommandType = type;
						if (sqlparameter != null)
						{
							for (int i = 0; i < sqlparameter.Length; i++)
							{
								sqlCommand.Parameters.Add(sqlparameter[i].ParameterName, sqlparameter[i].Value);
							}
						}
						int num = sqlCommand.ExecuteNonQuery();
						if (num > 0)
						{
							result = true;
						}
					}
				}
				return result;
			}
			catch
			{
				throw;
			}
		}

		public string ExecProcedureReturnJson(UserContext uContext, string ProcName, CommandType type, bool check = true, params CmdParameter[] sqlparameter)
		{
			try
			{
				CheckPermission(uContext, ProcName, sqlparameter);
				DataTable dataTable = new DataTable();
				using (SqlConnection sqlConnection = new SqlConnection(GetAccount(uContext.Account)))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand())
					{
						sqlCommand.Connection = sqlConnection;
						sqlCommand.CommandText = ProcName;
						sqlCommand.CommandType = type;
						if (sqlparameter != null)
						{
							for (int i = 0; i < sqlparameter.Length; i++)
							{
								sqlCommand.Parameters.Add(sqlparameter[i].ParameterName, sqlparameter[i].Value);
							}
						}
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						dataTable.TableName = "procTable";
						sqlDataAdapter.Fill(dataTable);
					}
				}
				return DBUtils.DataTableToJson(dataTable);
			}
			catch
			{
				throw;
			}
		}

		public bool ExecSql(UserContext uContext, string sqlcmd, bool check = true, params CmdParameter[] sqlparameter)
		{
			try
			{
				CheckPermission(uContext, sqlcmd, sqlparameter);
				using (SqlConnection sqlConnection = new SqlConnection(GetAccount(uContext.Account)))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand(sqlcmd, sqlConnection))
					{
						for (int i = 0; i < sqlparameter.Length; i++)
						{
							sqlCommand.Parameters.Add(sqlparameter[i].ParameterName, sqlparameter[i].Value);
						}
						sqlCommand.ExecuteNonQuery();
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int ExecSqlInt(UserContext uContext, string sqlcmd, params CmdParameter[] sqlparameter)
		{
			try
			{
				CheckPermission(uContext, sqlcmd, sqlparameter);
				using (SqlConnection sqlConnection = new SqlConnection(GetAccount(uContext.Account)))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand(sqlcmd, sqlConnection))
					{
						for (int i = 0; i < sqlparameter.Length; i++)
						{
							sqlCommand.Parameters.Add(sqlparameter[i].ParameterName, sqlparameter[i].Value);
						}
						return sqlCommand.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool ExecSqlTrans(UserContext uContext, string sqlcmd, params CmdParameter[] sqlparameter)
		{
			try
			{
				CheckPermission(uContext, sqlcmd, sqlparameter);
				using (SqlConnection sqlConnection = new SqlConnection(GetAccount(uContext.Account)))
				{
					SqlTransaction sqlTransaction = null;
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand(sqlcmd, sqlConnection))
					{
						for (int i = 0; i < sqlparameter.Length; i++)
						{
							sqlCommand.Parameters.Add(sqlparameter[i].ParameterName, sqlparameter[i].Value);
						}
						sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
						sqlCommand.Connection = sqlConnection;
						sqlCommand.Transaction = sqlTransaction;
						sqlCommand.CommandText = sqlcmd;
						sqlCommand.ExecuteNonQuery();
						sqlTransaction.Commit();
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool DataExists(UserContext uContext, string sqlcmd, bool check = true, params CmdParameter[] sqlparameter)
		{
			object single = GetSingle(uContext, sqlcmd, check, sqlparameter);
			if (single != null && single != DBNull.Value)
			{
				return single.ToString() != "0";
			}
			return false;
		}

		public static DataTable QueryDataTable(UserContext uContext, string sqlcmd, bool check = true, params CmdParameter[] sqlparameter)
		{
			return new DBHelper().Querydt(uContext, sqlcmd, check, sqlparameter);
		}

		public static DataSet QueryDataSet(UserContext uContext, string sqlcmd, params CmdParameter[] sqlparameter)
		{
			return new DBHelper().Queryds(uContext, sqlcmd, sqlparameter);
		}

		public static bool ExecBool(UserContext uContext, string sqlcmd, bool check = true, params CmdParameter[] sqlparameter)
		{
			return new DBHelper().ExecSql(uContext, sqlcmd, check, sqlparameter);
		}

		public static int ExecReturnInt(UserContext uContext, string sqlcmd, params CmdParameter[] sqlparameter)
		{
			return new DBHelper().ExecSqlInt(uContext, sqlcmd, sqlparameter);
		}

		public static bool ExecTransRbool(UserContext uContext, string sqlcmd, params CmdParameter[] sqlparameter)
		{
			return new DBHelper().ExecSqlTrans(uContext, sqlcmd, sqlparameter);
		}

		public static bool DataExistsBool(UserContext uContext, string sqlcmd, bool check = true, params CmdParameter[] sqlparameter)
		{
			return new DBHelper().DataExists(uContext, sqlcmd, check, sqlparameter);
		}

		public static int GetTableCounts(UserContext uContext, string sqlcmd, bool check = true)
		{
			return new DBHelper().GetTableCount(uContext, sqlcmd, check);
		}

		public static bool ExecProcedures(UserContext uContext, string ProcName, CommandType type, bool check = true, params CmdParameter[] sqlparameter)
		{
			return new DBHelper().ExecProcedure(uContext, ProcName, type, check, sqlparameter);
		}

		public static string ExecProceduresReturnJson(UserContext uContext, string ProcName, CommandType type, bool check = true, params CmdParameter[] sqlparameter)
		{
			return new DBHelper().ExecProcedureReturnJson(uContext, ProcName, type, check, sqlparameter);
		}
	}
}
