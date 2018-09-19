using System;
namespace Model
{
	/// <summary>
	/// 制具借归表
	/// </summary>
	[Serializable]
	public partial class T_Steel_Drawknife_Exchange
	{
		public T_Steel_Drawknife_Exchange()
		{}
		#region Model
		private string _docnumber;
		private string _serialnumber;
		private string _materialnumber;
		private string _status= "0";
		private string _customer;
		private DateTime _planreturntime;
		private DateTime _returntime;
		private string _returnman;
		private string _handlerman;
		private DateTime _handlertime;
		private string _remark;
		/// <summary>
		/// 单据号
		/// </summary>
		public string DocNumber
		{
			set{ _docnumber=value;}
			get{return _docnumber;}
		}
		/// <summary>
		/// SN
		/// </summary>
		public string SerialNumber
		{
			set{ _serialnumber=value;}
			get{return _serialnumber;}
		}
		/// <summary>
		/// 料号
		/// </summary>
		public string MaterialNumber
		{
			set{ _materialnumber=value;}
			get{return _materialnumber;}
		}
		/// <summary>
		/// 状态（0---借出、1---借入、2---归还）
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 客户
		/// </summary>
		public string Customer
		{
			set{ _customer=value;}
			get{return _customer;}
		}
		/// <summary>
		/// 计划规划日期
		/// </summary>
		public DateTime PlanReturnTime
		{
			set{ _planreturntime=value;}
			get{return _planreturntime;}
		}
		/// <summary>
		/// 归还日期
		/// </summary>
		public DateTime ReturnTime
		{
			set{ _returntime=value;}
			get{return _returntime;}
		}
		/// <summary>
		/// 归还人
		/// </summary>
		public string ReturnMan
		{
			set{ _returnman=value;}
			get{return _returnman;}
		}
		/// <summary>
		/// 经办人
		/// </summary>
		public string HandlerMan
		{
			set{ _handlerman=value;}
			get{return _handlerman;}
		}
		/// <summary>
		/// 经办时间
		/// </summary>
		public DateTime HandlerTime
		{
			set{ _handlertime=value;}
			get{return _handlertime;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

