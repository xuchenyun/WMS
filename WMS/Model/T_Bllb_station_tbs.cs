using System;
namespace Model
{
	/// <summary>
	/// 工位表
	/// </summary>
	[Serializable]
	public partial class T_Bllb_station_tbs
	{
		public T_Bllb_station_tbs()
		{}
		#region Model
		private string _tbs_id= "newid";
		private string _workstation_sn;
		private string _workstation_name;
		private string _tbg_id;
		private string _plcode;
		/// <summary>
		/// 工位ID
		/// </summary>
		public string TBS_ID
		{
			set{ _tbs_id=value;}
			get{return _tbs_id;}
		}
		/// <summary>
		/// 工位SN
		/// </summary>
		public string WORKSTATION_SN
		{
			set{ _workstation_sn=value;}
			get{return _workstation_sn;}
		}
		/// <summary>
		/// 工位名称
		/// </summary>
		public string WORKSTATION_NAME
		{
			set{ _workstation_name=value;}
			get{return _workstation_name;}
		}
		/// <summary>
		/// 工序ID（T_Bllb_group_tbg）
		/// </summary>
		public string TBG_ID
		{
			set{ _tbg_id=value;}
			get{return _tbg_id;}
		}
		/// <summary>
		/// 线别代码（MdcDatProductLine）
		/// </summary>
		public string PLCode
		{
			set{ _plcode=value;}
			get{return _plcode;}
		}
		#endregion Model

	}
}

