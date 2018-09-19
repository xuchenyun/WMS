using System;
namespace Model
{
	/// <summary>
	/// 工厂日历--工作时间表
	/// </summary>
	[Serializable]
	public partial class T_Bllb_facCalWork_tbfcw
	{
		public T_Bllb_facCalWork_tbfcw()
		{}
		#region Model
		private string _tbfcw_id= "newid";
		private string _shift;
		private string _start_time;
		private string _end_time;
		private string _tbfc_id;
		/// <summary>
		/// 工厂日历工作时间ID（全球唯一码）
		/// </summary>
		public string TBFCW_ID
		{
			set{ _tbfcw_id=value;}
			get{return _tbfcw_id;}
		}
		/// <summary>
		/// 班别
		/// </summary>
		public string SHIFT
		{
			set{ _shift=value;}
			get{return _shift;}
		}
		/// <summary>
		/// 开始时间（09:00:00）
		/// </summary>
		public string START_TIME
		{
			set{ _start_time=value;}
			get{return _start_time;}
		}
		/// <summary>
		/// 结束时间（18:00:00）
		/// </summary>
		public string END_TIME
		{
			set{ _end_time=value;}
			get{return _end_time;}
		}
		/// <summary>
		/// 工厂日历主表ID（全球唯一码）
		/// </summary>
		public string TBFC_ID
		{
			set{ _tbfc_id=value;}
			get{return _tbfc_id;}
		}
		#endregion Model

	}
}

