using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

using CIT.Wcf.Utils;
using CIT.Interface;

namespace CIT.DAL
{
    /// <summary>
    /// 数据访问类:SfcDatProductProRouteLog
    /// </summary>
    public partial class SfcDatProductProRouteLog
    {
        public SfcDatProductProRouteLog()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PCBCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SfcDatProductProRouteLog");
            strSql.Append(" where  PCBCode=@PCBCode  ");
            SqlParameter[] parameters = {
					new SqlParameter("@PCBCode", SqlDbType.NVarChar,50)	};
            parameters[10].Value = PCBCode;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CIT.Model.SfcDatProductProRouteLog model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into SfcDatProductProRouteLog(");
                strSql.Append("SfcNO,fguid,RepairHouseName,RepairHouse,Wocode,Product,ProductName,PCBCode,ProcessID,ProcessName,RouteID,RouteName,Type,Status,ErrorCode,Fnote,Creator,Createtime,line,msg,station)");
                strSql.Append(" values (");
                strSql.Append("@SfcNO,@Fguid,@RepairHouseName,@RepairHouse,@Wocode,@Product,@ProductName,@PCBCode,@ProcessID,@ProcessName,@RouteID,@RouteName,@Type,@Status,@ErrorCode,@Fnote,@Creator,getdate(),@line,@msg,@station)");
                SqlParameter[] parameters = {
					new SqlParameter("@SfcNO", SqlDbType.NVarChar,50),
					new SqlParameter("@Fguid", SqlDbType.NVarChar,50),
					new SqlParameter("@RepairHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@RepairHouse", SqlDbType.NVarChar,50),
					new SqlParameter("@Wocode", SqlDbType.NVarChar,50),
					new SqlParameter("@Product", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,50),
					new SqlParameter("@PCBCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProcessID", SqlDbType.NVarChar,50),
					new SqlParameter("@ProcessName", SqlDbType.NVarChar,50),
					new SqlParameter("@RouteID", SqlDbType.NVarChar,50),
					new SqlParameter("@RouteName", SqlDbType.NVarChar,50),
					new SqlParameter("@Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.NVarChar,50),
					new SqlParameter("@ErrorCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Fnote", SqlDbType.NVarChar,50),
					new SqlParameter("@Creator", SqlDbType.NVarChar,50),
                    new SqlParameter("@line", SqlDbType.NVarChar,50),
                    new SqlParameter("@msg", SqlDbType.NVarChar,500),
                    new SqlParameter("@station", SqlDbType.NVarChar,500)};
                parameters[0].Value = model.SfcNO;
                parameters[1].Value = model.Fguid;
                parameters[2].Value = model.RepairHouseName;
                parameters[3].Value = model.RepairHouse;
                parameters[4].Value = model.Wocode;
                parameters[5].Value = model.Product;
                parameters[6].Value = model.ProductName;
                parameters[7].Value = model.PCBCode;
                parameters[8].Value = model.ProcessID;
                parameters[9].Value = model.ProcessName;
                parameters[10].Value = model.RouteID;
                parameters[11].Value = model.RouteName;
                parameters[12].Value = model.Type;
                parameters[13].Value = model.Status;
                parameters[14].Value = model.ErrorCode;
                parameters[15].Value = model.Fnote;
                parameters[16].Value = model.Creator;
                parameters[17].Value = model.Line;
                parameters[18].Value = model.Msg;
                parameters[19].Value = model.Station;
                CmdParameter[] cmd = new CmdParameter[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd[i].ParameterName = parameters[i].ParameterName;
                    cmd[i].Value = parameters[i].Value;
                }
                return NMS.ExecTransql(CIT.MES.PubUtils.uContext, strSql.ToString(), cmd);
            }
            catch { return false; }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CIT.Model.SfcDatProductProRouteLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SfcDatProductProRouteLog set ");
            strSql.Append("SfcNO=@SfcNO,");
            strSql.Append("Wocode=@Wocode,");
            strSql.Append("Product=@Product,");
            strSql.Append("ProductName=@ProductName,");
            strSql.Append("PCBCode=@PCBCode,");
            strSql.Append("ProcessID=@ProcessID,");
            strSql.Append("ProcessName=@ProcessName,");
            strSql.Append("RouteID=@RouteID,");
            strSql.Append("RouteName=@RouteName,");
            strSql.Append("Type=@Type,");
            strSql.Append("Status=@Status,");
            strSql.Append("ErrorCode=@ErrorCode,");
            strSql.Append("Fnote=@Fnote,");
            strSql.Append("Creator=@Creator,");
            strSql.Append("Createtime=@Createtime");
            strSql.Append(" where SfcNO=@SfcNO and Type=@Type and Status=@Status and ErrorCode=@ErrorCode and Fnote=@Fnote and Creator=@Creator and Createtime=@Createtime and Wocode=@Wocode and Product=@Product and ProductName=@ProductName and PCBCode=@PCBCode and ProcessID=@ProcessID and ProcessName=@ProcessName and RouteID=@RouteID and RouteName=@RouteName ");
            SqlParameter[] parameters = {
					new SqlParameter("@SfcNO", SqlDbType.NVarChar,50),
					new SqlParameter("@Wocode", SqlDbType.NVarChar,50),
					new SqlParameter("@Product", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,50),
					new SqlParameter("@PCBCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProcessID", SqlDbType.NVarChar,50),
					new SqlParameter("@ProcessName", SqlDbType.NVarChar,50),
					new SqlParameter("@RouteID", SqlDbType.NVarChar,50),
					new SqlParameter("@RouteName", SqlDbType.NVarChar,50),
					new SqlParameter("@Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.NVarChar,50),
					new SqlParameter("@ErrorCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Fnote", SqlDbType.NVarChar,50),
					new SqlParameter("@Creator", SqlDbType.NVarChar,50),
					new SqlParameter("@Createtime", SqlDbType.DateTime)};
            parameters[0].Value = model.SfcNO;
            parameters[1].Value = model.Wocode;
            parameters[2].Value = model.Product;
            parameters[3].Value = model.ProductName;
            parameters[4].Value = model.PCBCode;
            parameters[5].Value = model.ProcessID;
            parameters[6].Value = model.ProcessName;
            parameters[7].Value = model.RouteID;
            parameters[8].Value = model.RouteName;
            parameters[9].Value = model.Type;
            parameters[10].Value = model.Status;
            parameters[11].Value = model.ErrorCode;
            parameters[12].Value = model.Fnote;
            parameters[13].Value = model.Creator;
            parameters[14].Value = model.Createtime;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SfcNO, string Type, string Status, string ErrorCode, string Fnote, string Creator, DateTime Createtime, string Wocode, string Product, string ProductName, string PCBCode, string ProcessID, string ProcessName, string RouteID, string RouteName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SfcDatProductProRouteLog ");
            strSql.Append(" where SfcNO=@SfcNO and Type=@Type and Status=@Status and ErrorCode=@ErrorCode and Fnote=@Fnote and Creator=@Creator and Createtime=@Createtime and Wocode=@Wocode and Product=@Product and ProductName=@ProductName and PCBCode=@PCBCode and ProcessID=@ProcessID and ProcessName=@ProcessName and RouteID=@RouteID and RouteName=@RouteName ");
            SqlParameter[] parameters = {
					new SqlParameter("@SfcNO", SqlDbType.NVarChar,50),
					new SqlParameter("@Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.NVarChar,50),
					new SqlParameter("@ErrorCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Fnote", SqlDbType.NVarChar,50),
					new SqlParameter("@Creator", SqlDbType.NVarChar,50),
					new SqlParameter("@Createtime", SqlDbType.DateTime),
					new SqlParameter("@Wocode", SqlDbType.NVarChar,50),
					new SqlParameter("@Product", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,50),
					new SqlParameter("@PCBCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProcessID", SqlDbType.NVarChar,50),
					new SqlParameter("@ProcessName", SqlDbType.NVarChar,50),
					new SqlParameter("@RouteID", SqlDbType.NVarChar,50),
					new SqlParameter("@RouteName", SqlDbType.NVarChar,50)			};
            parameters[0].Value = SfcNO;
            parameters[1].Value = Type;
            parameters[2].Value = Status;
            parameters[3].Value = ErrorCode;
            parameters[4].Value = Fnote;
            parameters[5].Value = Creator;
            parameters[6].Value = Createtime;
            parameters[7].Value = Wocode;
            parameters[8].Value = Product;
            parameters[9].Value = ProductName;
            parameters[10].Value = PCBCode;
            parameters[11].Value = ProcessID;
            parameters[12].Value = ProcessName;
            parameters[13].Value = RouteID;
            parameters[14].Value = RouteName;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CIT.Model.SfcDatProductProRouteLog GetModel(string SfcNO, string Type, string Status, string ErrorCode, string Fnote, string Creator, DateTime Createtime, string Wocode, string Product, string ProductName, string PCBCode, string ProcessID, string ProcessName, string RouteID, string RouteName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SfcNO,Wocode,Product,ProductName,PCBCode,ProcessID,ProcessName,RouteID,RouteName,Type,Status,ErrorCode,Fnote,Creator,Createtime from SfcDatProductProRouteLog ");
            strSql.Append(" where SfcNO=@SfcNO and Type=@Type and Status=@Status and ErrorCode=@ErrorCode and Fnote=@Fnote and Creator=@Creator and Createtime=@Createtime and Wocode=@Wocode and Product=@Product and ProductName=@ProductName and PCBCode=@PCBCode and ProcessID=@ProcessID and ProcessName=@ProcessName and RouteID=@RouteID and RouteName=@RouteName ");
            SqlParameter[] parameters = {
					new SqlParameter("@SfcNO", SqlDbType.NVarChar,50),
					new SqlParameter("@Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.NVarChar,50),
					new SqlParameter("@ErrorCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Fnote", SqlDbType.NVarChar,50),
					new SqlParameter("@Creator", SqlDbType.NVarChar,50),
					new SqlParameter("@Createtime", SqlDbType.DateTime),
					new SqlParameter("@Wocode", SqlDbType.NVarChar,50),
					new SqlParameter("@Product", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,50),
					new SqlParameter("@PCBCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProcessID", SqlDbType.NVarChar,50),
					new SqlParameter("@ProcessName", SqlDbType.NVarChar,50),
					new SqlParameter("@RouteID", SqlDbType.NVarChar,50),
					new SqlParameter("@RouteName", SqlDbType.NVarChar,50)			};
            parameters[0].Value = SfcNO;
            parameters[1].Value = Type;
            parameters[2].Value = Status;
            parameters[3].Value = ErrorCode;
            parameters[4].Value = Fnote;
            parameters[5].Value = Creator;
            parameters[6].Value = Createtime;
            parameters[7].Value = Wocode;
            parameters[8].Value = Product;
            parameters[9].Value = ProductName;
            parameters[10].Value = PCBCode;
            parameters[11].Value = ProcessID;
            parameters[12].Value = ProcessName;
            parameters[13].Value = RouteID;
            parameters[14].Value = RouteName;

            CIT.Model.SfcDatProductProRouteLog model = new CIT.Model.SfcDatProductProRouteLog();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CIT.Model.SfcDatProductProRouteLog DataRowToModel(DataRow row)
        {
            CIT.Model.SfcDatProductProRouteLog model = new CIT.Model.SfcDatProductProRouteLog();
            if (row != null)
            {
                if (row["SfcNO"] != null)
                {
                    model.SfcNO = row["SfcNO"].ToString();
                }
                if (row["Wocode"] != null)
                {
                    model.Wocode = row["Wocode"].ToString();
                }
                if (row["Product"] != null)
                {
                    model.Product = row["Product"].ToString();
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["PCBCode"] != null)
                {
                    model.PCBCode = row["PCBCode"].ToString();
                }
                if (row["ProcessID"] != null)
                {
                    model.ProcessID = row["ProcessID"].ToString();
                }
                if (row["ProcessName"] != null)
                {
                    model.ProcessName = row["ProcessName"].ToString();
                }
                if (row["RouteID"] != null)
                {
                    model.RouteID = row["RouteID"].ToString();
                }
                if (row["RouteName"] != null)
                {
                    model.RouteName = row["RouteName"].ToString();
                }
                if (row["Type"] != null)
                {
                    model.Type = row["Type"].ToString();
                }
                if (row["Status"] != null)
                {
                    model.Status = row["Status"].ToString();
                }
                if (row["ErrorCode"] != null)
                {
                    model.ErrorCode = row["ErrorCode"].ToString();
                }
                if (row["Fnote"] != null)
                {
                    model.Fnote = row["Fnote"].ToString();
                }
                if (row["Creator"] != null)
                {
                    model.Creator = row["Creator"].ToString();
                }
                if (row["Createtime"] != null && row["Createtime"].ToString() != "")
                {
                    model.Createtime = row["Createtime"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SfcNO,Wocode,Product,ProductName,PCBCode,ProcessID,ProcessName,RouteID,RouteName,Type,Status,ErrorCode,Fnote,Creator,Createtime ");
            strSql.Append(" FROM SfcDatProductProRouteLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" SfcNO,Wocode,Product,ProductName,PCBCode,ProcessID,ProcessName,RouteID,RouteName,Type,Status,ErrorCode,Fnote,Creator,Createtime ");
            strSql.Append(" FROM SfcDatProductProRouteLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM SfcDatProductProRouteLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.RouteName desc");
            }
            strSql.Append(")AS Row, T.*  from SfcDatProductProRouteLog T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "SfcDatProductProRouteLog";
            parameters[1].Value = "RouteName";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

