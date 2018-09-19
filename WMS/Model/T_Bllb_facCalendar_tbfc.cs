using System;
namespace Model
{
	/// <summary>
	/// 工厂日历--主表
	/// </summary>
	[Serializable]
	public partial class T_Bllb_facCalendar_tbfc
	{
		public T_Bllb_facCalendar_tbfc()
		{}
		#region Model
		private string _tbfc_id= "newid";
		private string _tbfc_name;
		private string _start_date;
		private string _end_date;
		/// <summary>
		/// 工厂日历主表ID（全球唯一码）
		/// </summary>
		public string TBFC_ID
		{
			set{ _tbfc_id=value;}
			get{return _tbfc_id;}
		}
		/// <summary>
		/// 日历名称（比如：3月--9月）
		/// </summary>
		public string TBFC_NAME
		{
			set{ _tbfc_name=value;}
			get{return _tbfc_name;}
		}
		/// <summary>
		/// 开始月日（05.22）
		/// </summary>
		public string START_DATE
		{
			set{ _start_date=value;}
			get{return _start_date;}
		}
		/// <summary>
		/// 结束月日（06.12）
		/// </summary>
		public string END_DATE
		{
			set{ _end_date=value;}
			get{return _end_date;}
		}
		#endregion Model

	}
}

