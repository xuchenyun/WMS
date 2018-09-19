using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CIT.BLL
{
	public class DBUtils
	{
		private static object obj = new object();

		public static string ToJson(SqlCommand sqlcmd, int pageindex, int pagesize)
		{
			try
			{
				using (sqlcmd)
				{
					StringBuilder stringBuilder = new StringBuilder();
					int num = 0;
					int num2 = 0;
					int num3 = 0;
					if (pagesize != -1)
					{
						string text = "";
						text = ((!sqlcmd.CommandText.Contains(" order ")) ? ("select count(*) from (" + sqlcmd.CommandText + ") abc") : ("select count(*) from (" + sqlcmd.CommandText.Substring(0, sqlcmd.CommandText.LastIndexOf("order")) + ") abc"));
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(text, sqlcmd.Connection);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						if (dataTable.Rows.Count == 0)
						{
							return "";
						}
						string str = dataTable.Rows[0][0].ToString();
						stringBuilder.Append("{");
						stringBuilder.Append("\"");
						stringBuilder.Append("total\"");
						stringBuilder.Append(":" + str);
						stringBuilder.Append(",");
						stringBuilder.Append("\"");
						stringBuilder.Append("rows\"");
						stringBuilder.Append(":");
						num2 = (pageindex - 1) * pagesize + pagesize;
						num3 = (pageindex - 1) * pagesize;
					}
					else
					{
						num2 = 2147483647;
						num3 = 0;
					}
					stringBuilder.Append("[");
					SqlDataReader sqlDataReader = sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);
					using (sqlDataReader)
					{
						while (sqlDataReader.Read() && num <= num2)
						{
							if (num3 <= num && num < num2)
							{
								stringBuilder.Append("{");
								for (int i = 0; i < sqlDataReader.FieldCount; i++)
								{
									Type fieldType = sqlDataReader.GetFieldType(i);
									string name = sqlDataReader.GetName(i);
									string str2 = sqlDataReader[i].ToString();
									stringBuilder.Append("\"" + name.ToLower() + "\":");
									str2 = StringFormat(str2, fieldType);
									if (i < sqlDataReader.FieldCount - 1)
									{
										stringBuilder.Append(str2 + ",");
									}
									else
									{
										stringBuilder.Append(str2);
									}
								}
								stringBuilder.Append("},");
							}
							num++;
						}
						sqlcmd?.Cancel();
						if (!sqlDataReader.IsClosed)
						{
							sqlDataReader.Close();
						}
						try
						{
							sqlDataReader.Dispose();
						}
						catch
						{
						}
						stringBuilder.Remove(stringBuilder.Length - 1, 1);
						if (pagesize == -1)
						{
							stringBuilder.Append("]");
						}
						else
						{
							stringBuilder.Append("]}");
						}
						if (stringBuilder.Length == 1)
						{
							return "[]";
						}
						return stringBuilder.ToString();
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private static string StringFormat(string str, Type type)
		{
			if (type != typeof(string) && string.IsNullOrEmpty(str))
			{
				str = "\"" + str + "\"";
			}
			else if (type == typeof(string))
			{
				str = String2Json(str);
				str = "\"" + str + "\"";
			}
			else if (type == typeof(DateTime))
			{
				str = "\"" + str + "\"";
			}
			else if (type == typeof(bool))
			{
				str = ((str != null && str.Length != 0) ? str.ToLower() : "false");
			}
			else if (type == typeof(byte[]))
			{
				str = "\"" + str + "\"";
			}
			else if (type == typeof(Guid))
			{
				str = "\"" + str + "\"";
			}
			return str;
		}

		public static string String2Json(string s)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < s.Length; i++)
			{
				char c = s.ToCharArray()[i];
				switch (c)
				{
				case '"':
					stringBuilder.Append("\\\"");
					break;
				case '\\':
					stringBuilder.Append("\\\\");
					break;
				case '/':
					stringBuilder.Append("\\/");
					break;
				case '\b':
					stringBuilder.Append("\\b");
					break;
				case '\f':
					stringBuilder.Append("\\f");
					break;
				case '\n':
					stringBuilder.Append("\\n");
					break;
				case '\r':
					stringBuilder.Append("\\r");
					break;
				case '\t':
					stringBuilder.Append("\\t");
					break;
				case '\v':
					stringBuilder.Append("\\v");
					break;
				case '\0':
					stringBuilder.Append("\\0");
					break;
				default:
					stringBuilder.Append(c);
					break;
				}
			}
			return stringBuilder.ToString();
		}

		public static string DataTableToJson(DataTable dt)
		{
			List<string> list = new List<string>();
			StringBuilder stringBuilder = new StringBuilder();
			if (dt.Rows.Count > 0)
			{
				stringBuilder.Append("{");
				stringBuilder.Append("\"total\":" + dt.Rows.Count.ToString());
				stringBuilder.Append(",");
				stringBuilder.Append("\"rows\":");
				stringBuilder.Append("[");
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					list = new List<string>();
					for (int j = 0; j < dt.Columns.Count; j++)
					{
						list.Add("\"" + dt.Rows[i][j].ToString() + "\"");
					}
					if (i == dt.Rows.Count - 1)
					{
						AddNewJson(stringBuilder, list, dt);
					}
					else
					{
						AddNewJson(stringBuilder, list, dt);
						stringBuilder.Append(",");
					}
				}
				stringBuilder.Append("]");
				stringBuilder.Append("}");
			}
			return stringBuilder.ToString();
		}

		private static void AddNewJson(StringBuilder Json, List<string> result, DataTable dt)
		{
			Json.Append("{");
			for (int i = 0; i < dt.Columns.Count; i++)
			{
				Json.Append("\"");
				Json.Append(dt.Columns[i].ColumnName.ToLower());
				Json.Append("\":");
				if (result[i].Contains(","))
				{
					Json.Append(result[i]);
				}
				else
				{
					Json.Append(result[i]);
					if (i != dt.Columns.Count - 1)
					{
						Json.Append(",");
					}
				}
			}
			Json.Append("}");
		}
	}
}
