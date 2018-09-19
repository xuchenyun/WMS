using System;
namespace Model
{
	/// <summary>
	/// 不良记录表
	/// </summary>
	[Serializable]
	public partial class T_Bllb_productError_tbpe
	{
		public T_Bllb_productError_tbpe()
		{}
		#region Model
		private string _tbpe_id= "newid";
		private string _tbps_id;
		private string _tbec_id;
		private string _error_man;
		private DateTime? _error_time;
		private string _tber_id;
		private string _tbrm_id;
		private string _no_error;
		private string _repair_man;
		private DateTime? _repair_time;
		private string _tbg_id;
		private string _tbs_id;
		private string _tbep_id;
		private string _remarks;
		private string _part_num;
		private string _tbef_id;
		private string _check_resust="1";
		private string _check_man;
		private DateTime? _check_time;
		private string _check_desc;
		/// <summary>
		/// 不良记录ID（全球唯一码）
		/// </summary>
		public string TBPE_ID
		{
			set{ _tbpe_id=value;}
			get{return _tbpe_id;}
		}
		/// <summary>
		/// 产品状态ID（全球唯一码）
		/// </summary>
		public string TBPS_ID
		{
			set{ _tbps_id=value;}
			get{return _tbps_id;}
		}
		/// <summary>
		/// 不良代码ID（T_Bllb_errorCode_tbec）
		/// </summary>
		public string TBEC_ID
		{
			set{ _tbec_id=value;}
			get{return _tbec_id;}
		}
		/// <summary>
		/// 检测人
		/// </summary>
		public string ERROR_MAN
		{
			set{ _error_man=value;}
			get{return _error_man;}
		}
		/// <summary>
		/// 检测时间
		/// </summary>
		public DateTime? ERROR_TIME
		{
			set{ _error_time=value;}
			get{return _error_time;}
		}
		/// <summary>
		/// 不良原因ID（T_Bllb_errorReason_tber）
		/// </summary>
		public string TBER_ID
		{
			set{ _tber_id=value;}
			get{return _tber_id;}
		}
		/// <summary>
		/// 维修方法ID（T_Bllb_repairMethod_tbrm）
		/// </summary>
		public string TBRM_ID
		{
			set{ _tbrm_id=value;}
			get{return _tbrm_id;}
		}
		/// <summary>
		/// 是否误判（Y/N）
		/// </summary>
		public string NO_ERROR
		{
			set{ _no_error=value;}
			get{return _no_error;}
		}
		/// <summary>
		/// 维修人
		/// </summary>
		public string REPAIR_MAN
		{
			set{ _repair_man=value;}
			get{return _repair_man;}
		}
		/// <summary>
		/// 维修时间
		/// </summary>
		public DateTime? REPAIR_TIME
		{
			set{ _repair_time=value;}
			get{return _repair_time;}
		}
		/// <summary>
		/// 检测工序ID(T_Bllb_group_tbg)
		/// </summary>
		public string TBG_ID
		{
			set{ _tbg_id=value;}
			get{return _tbg_id;}
		}
		/// <summary>
		/// 检测工位ID(T_Bllb_station_tbs)
		/// </summary>
		public string TBS_ID
		{
			set{ _tbs_id=value;}
			get{return _tbs_id;}
		}
		/// <summary>
		/// 不良部件ID（T_Bllb_errorParts_tbep）
		/// </summary>
		public string TBEP_ID
		{
			set{ _tbep_id=value;}
			get{return _tbep_id;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string REMARKS
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		/// <summary>
		/// 不良部件料号
		/// </summary>
		public string PART_NUM
		{
			set{ _part_num=value;}
			get{return _part_num;}
		}
		/// <summary>
		/// 不良因素ID（T_Bllb_errorFactor_tbef）
		/// </summary>
		public string TBEF_ID
		{
			set{ _tbef_id=value;}
			get{return _tbef_id;}
		}
		/// <summary>
		/// 审核结果(1:待审核；2:通过；3:不通过)
		/// </summary>
		public string CHECK_RESUST
		{
			set{ _check_resust=value;}
			get{return _check_resust;}
		}
		/// <summary>
		/// 审核人员工号
		/// </summary>
		public string CHECK_MAN
		{
			set{ _check_man=value;}
			get{return _check_man;}
		}
		/// <summary>
		/// 审核时间
		/// </summary>
		public DateTime? CHECK_TIME
		{
			set{ _check_time=value;}
			get{return _check_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CHECK_DESC
		{
			set{ _check_desc=value;}
			get{return _check_desc;}
		}
		#endregion Model

	}
}

