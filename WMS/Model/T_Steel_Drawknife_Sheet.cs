using System;
namespace Model
{
	/// <summary>
	/// 制令单&制具使用次数关系表
	/// </summary>
	[Serializable]
	public partial class T_Steel_Drawknife_Sheet
	{
		public T_Steel_Drawknife_Sheet()
		{}
		#region Model
		private string _sfcno;
		private string _currentproduction;
		private string _serialnumber;
		private string _usetimes;
		private string _remark;
		/// <summary>
		/// 制令单
		/// </summary>
		public string SfcNo
		{
			set{ _sfcno=value;}
			get{return _sfcno;}
		}
		/// <summary>
		/// 制令单当前产量
		/// </summary>
		public string CurrentProduction
		{
			set{ _currentproduction=value;}
			get{return _currentproduction;}
		}
		/// <summary>
		/// SN（制具SN）
		/// </summary>
		public string SerialNumber
		{
			set{ _serialnumber=value;}
			get{return _serialnumber;}
		}
		/// <summary>
		/// 制具使用次数
		/// </summary>
		public string UseTimes
		{
			set{ _usetimes=value;}
			get{return _usetimes;}
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

