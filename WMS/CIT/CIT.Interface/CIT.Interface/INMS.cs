using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.ServiceModel;

namespace CIT.Interface
{
	[ServiceKnownType(typeof(MitBarcode))]
	[ServiceKnownType(typeof(SqlString))]
	[ServiceKnownType(typeof(UserContext))]
	[ServiceContract]
	public interface INMS
	{
		[OperationContract]
		bool LoginUser(UserContext uContext);

		[OperationContract]
		Dictionary<string, string> GetAccList();

		[OperationContract(Name = "GetOnLineUser")]
		List<UserContext> GetOnLineUser();

		[OperationContract(Name = "GetOnLineUser1")]
		UserContext GetOnLineUser(UserContext uContext);

		[OperationContract]
		void LogOffUser(UserContext uContext);

		[OperationContract]
		List<UserContext> AddOnLineUser(UserContext uContext);

		[OperationContract]
		DataTable GetMainMenuList(UserContext uContext, string main = "");

		[OperationContract(Name = "获取所有列名")]
		string GetColumns(UserContext uContext, int pageindex, int pagesize);

		[OperationContract(Name = "获取当前表列名")]
		string GetColumns(UserContext uContext, string TableCode, int pageindex, int pagesize);

		[OperationContract(Name = "获取当前表的当前类型所有列名")]
		string GetColumns(UserContext uContext, string TableCode, string type, int pageindex, int pagesize);

		[OperationContract(Name = "获取当前类的表的当前类型所有列名")]
		string GetColumns(UserContext uContext, string ClassCode, string TableCode, string type, int pageindex, int pagesize);

		[OperationContract(Name = "获取当前表的行数")]
		int GetTableCount(UserContext uContext, string sqlcmd, bool check = true);

		[OperationContract(Name = "执行分页存储过程")]
		DataSet QueryPager(UserContext uContext, string ProName, string tablename, string columnsname, string where, string orderby, string pageindex, string pagesize);

		[OperationContract(Name = "流分页")]
		string QueryPager(UserContext uContext, string sqlcmd, string columns, int pageindex, int pagesize);

		[OperationContract(Name = "流分页带分页")]
		string QueryPager(UserContext uContext, string sqlcmd, string columns, string orderby, int pageindex, int pagesize);

		[OperationContract(Name = "执行存储过程")]
		bool ExecProcedures(UserContext uContext, string ProcName, CommandType type, bool check = true, params CmdParameter[] sqlparameter);

		[OperationContract(Name = "执行存储过程返回json")]
		string ExecProceduresReturnJson(UserContext uContext, string ProcName, CommandType type, bool check = true, params CmdParameter[] sqlparameter);

		[OperationContract(Name = "删除单列条件数据")]
		bool DeleteData(UserContext uContext, string entity, string columnName, string where);

		[OperationContract(Name = "删除自带条件数据")]
		bool DeleteData(UserContext uContext, string entity, string where);

		[OperationContract(Name = "分页精确查询所有列")]
		string ConditionExactAllColumnsQueryPager(UserContext uContext, string entity, string where, int pageindex, int pagesize);

		[OperationContract(Name = "分页查询单列条件")]
		string ConditionExactSingleColumnsQueryPager(UserContext uContext, string entity, string columnName, string where, int pageindex, int pagesize);

		[OperationContract(Name = "分页查询自带条件语句")]
		string ConditionExactQueryPager(UserContext uContext, string entity, string where, int pageindex, int pagesize);

		[OperationContract(Name = "实体查询分页数据根据条件")]
		string ConditionQueryPager(UserContext uContext, string EntityName, string where, int pageindex, int pagesize);

		[OperationContract(Name = "实体查询分页数据自带排序根据条件")]
		string ConditionQueryPager(UserContext uContext, string EntityName, string where, string orderby, int pageindex, int pagesize);

		[OperationContract(Name = "GetTabelReturnJson")]
		string GetTabel(UserContext uContext, string sqlcmd, params CmdParameter[] sqlparameter);

		[OperationContract(Name = "查询当前菜单的工具栏按钮")]
		string GetMenuBtnMap(UserContext uContext, string Menucode, string OrgID);

		[OperationContract(Name = "查询当前组织的菜单")]
		string GetOrgMenuMap(UserContext uContext, string OrgID, string PareantID);

		[OperationContract(Name = "SaveFlowChartWinfrm")]
		bool SaveFlowChartWinfrm(UserContext uContext, string ChartCode, string winfrmID, string winfrmName, string top, string left, string pwincode, string labname, string labcode);

		[OperationContract(Name = "QueryDataTable")]
		DataTable QueryDataTable(UserContext uContext, string sqlcmd, params CmdParameter[] sqlparameter);

		[OperationContract(Name = "Exectransql")]
		bool ExecTransql(UserContext uContext, string sqlcmd, params CmdParameter[] sqlparameter);

		[OperationContract(Name = "FormatBarcode")]
		MitBarcode FormatMitBarCode(string sqlcmd, string UserID);

		[OperationContract(Name = "QueryDataSet")]
		DataSet QueryDataSet(UserContext uContext, string sqlcmd, params CmdParameter[] sqlparameter);
	}
}
