using System;
namespace Model
{
	/// <summary>
	/// 关键件替换日志表
	/// </summary>
	[Serializable]
	public partial class T_Bllb_replaceKeyLog_tbrkl
	{
		public T_Bllb_replaceKeyLog_tbrkl()
		{}
		#region Model
		private string _old_key_sn;
		private string _new_key_sn;
		private string _tbps_id;
		private string _replace_man;
		private DateTime? _replace_time;
		/// <summary>
		/// 
		/// </summary>
		public string OLD_KEY_SN
		{
			set{ _old_key_sn=value;}
			get{return _old_key_sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NEW_KEY_SN
		{
			set{ _new_key_sn=value;}
			get{return _new_key_sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TBPS_ID
		{
			set{ _tbps_id=value;}
			get{return _tbps_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string REPLACE_MAN
		{
			set{ _replace_man=value;}
			get{return _replace_man;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? REPLACE_TIME
		{
			set{ _replace_time=value;}
			get{return _replace_time;}
		}
		#endregion Model

	}
}

