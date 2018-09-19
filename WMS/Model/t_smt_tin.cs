using System;
namespace Model
{
	/// <summary>
	/// 锡膏管理表
	/// </summary>
	[Serializable]
	public partial class t_smt_tin
	{
		public t_smt_tin()
		{}
		#region Model
		private string _doc_num;
		private string _reel_id;
		private string _materials_num;
		private string _materials_des;
		private string _datecode;
		private DateTime? _begin_backtemp_time;
		private string _back_time_length;
		private string _back_temp_man;
		private DateTime? _scrap_time;
		private string _scrap_man;
		private string _leave_house_flag= "0";
		private string _is_available= "0";
		private DateTime? _out_house_time;
		private string _out_house_man;
		private DateTime? _leave_house_time;
		private string _status;
		/// <summary>
		/// 单据号（出库单）
		/// </summary>
		public string Doc_Num
		{
			set{ _doc_num=value;}
			get{return _doc_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Reel_ID
		{
			set{ _reel_id=value;}
			get{return _reel_id;}
		}
		/// <summary>
		/// 锡膏料号
		/// </summary>
		public string Materials_Num
		{
			set{ _materials_num=value;}
			get{return _materials_num;}
		}
		/// <summary>
		/// 物料描述
		/// </summary>
		public string Materials_Des
		{
			set{ _materials_des=value;}
			get{return _materials_des;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DateCode
		{
			set{ _datecode=value;}
			get{return _datecode;}
		}
		/// <summary>
		/// 开始回温时间
		/// </summary>
		public DateTime? Begin_BackTemp_Time
		{
			set{ _begin_backtemp_time=value;}
			get{return _begin_backtemp_time;}
		}
		/// <summary>
		/// 回温时长
		/// </summary>
		public string Back_Time_Length
		{
			set{ _back_time_length=value;}
			get{return _back_time_length;}
		}
		/// <summary>
		/// 回温人
		/// </summary>
		public string Back_Temp_Man
		{
			set{ _back_temp_man=value;}
			get{return _back_temp_man;}
		}
		/// <summary>
		/// 报废时间
		/// </summary>
		public DateTime? Scrap_Time
		{
			set{ _scrap_time=value;}
			get{return _scrap_time;}
		}
		/// <summary>
		/// 报废人
		/// </summary>
		public string Scrap_Man
		{
			set{ _scrap_man=value;}
			get{return _scrap_man;}
		}
		/// <summary>
		/// 退库标识位（默认0，退库操作标识为1）
		/// </summary>
		public string Leave_House_Flag
		{
			set{ _leave_house_flag=value;}
			get{return _leave_house_flag;}
		}
		/// <summary>
		/// 是否可用（默认0，达到最小回温时间可上线1）
		/// </summary>
		public string Is_Available
		{
			set{ _is_available=value;}
			get{return _is_available;}
		}
		/// <summary>
		/// 出库时间
		/// </summary>
		public DateTime? Out_House_Time
		{
			set{ _out_house_time=value;}
			get{return _out_house_time;}
		}
		/// <summary>
		/// 出库人
		/// </summary>
		public string Out_House_Man
		{
			set{ _out_house_man=value;}
			get{return _out_house_man;}
		}
		/// <summary>
		/// 退库时间
		/// </summary>
		public DateTime? Leave_House_Time
		{
			set{ _leave_house_time=value;}
			get{return _leave_house_time;}
		}
		/// <summary>
		/// 0-线边库/退库、1-上线、2-回温中、3-达到回温时间可用、4-超出回温时间、5-报废 6-搅拌中
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

