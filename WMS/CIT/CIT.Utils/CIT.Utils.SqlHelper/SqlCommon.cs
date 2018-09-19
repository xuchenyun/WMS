using CIT.Interface;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CIT.Utils.SqlHelper
{
	public class SqlCommon
	{
		//public static string connStr = "";
        public static string connStr = "server=.;database=AFN;user id=sa;password=Password01!";

        public static int ExecuteNonQuery(string sql, params SqlParameter[] ps)
		{
			using (SqlConnection sqlConnection = new SqlConnection(connStr))
			{
				using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
				{
					sqlCommand.Parameters.AddRange(ps);
					sqlConnection.Open();
					return sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public static object ExecuteScalar(string sql, params SqlParameter[] ps)
		{
			using (SqlConnection sqlConnection = new SqlConnection(connStr))
			{
				using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
				{
					sqlCommand.Parameters.AddRange(ps);
					sqlConnection.Open();
					return sqlCommand.ExecuteScalar();
				}
			}
		}

		public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] ps)
		{
			SqlConnection sqlConnection = new SqlConnection(connStr);
			try
			{
				using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
				{
					sqlCommand.Parameters.AddRange(ps);
					sqlConnection.Open();
					return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				}
			}
			catch (Exception ex)
			{
				sqlConnection.Dispose();
				throw ex;
			}
		}

		public static DataSet GetDataSet(string sql, params SqlParameter[] ps)
		{
			DataSet dataSet = new DataSet();
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, connStr))
			{
				sqlDataAdapter.SelectCommand.Parameters.AddRange(ps);
				sqlDataAdapter.Fill(dataSet);
			}
			return dataSet;
		}

        public static DataSet GetDataSet(string sql, params CmdParameter[] ps)
        {
            DataSet dataSet = new DataSet();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, connStr))
            {
                sqlDataAdapter.SelectCommand.Parameters.AddRange(ps);
                sqlDataAdapter.Fill(dataSet);
            }
            return dataSet;
        }
    }
}
