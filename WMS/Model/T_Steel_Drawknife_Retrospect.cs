using System;
namespace Model
{
	/// <summary>
	/// 制具追溯表
	/// </summary>
	[Serializable]
	public partial class T_Steel_Drawknife_Retrospect
	{
		public T_Steel_Drawknife_Retrospect()
		{}
		#region Model
		private string _sfcno;
		private string _product;
		private string _serialnumber;
		private string _materialnum;
		private string _onlineman;
		private DateTime _onlinetime;
		private string _remark;
        public string _fguid;
		/// <summary>
		/// 制令单
		/// </summary>
		public string SfcNo
		{
			set{ _sfcno=value;}
			get{return _sfcno;}
		}
		/// <summary>
		/// 机种
		/// </summary>
		public string Product
		{
			set{ _product=value;}
			get{return _product;}
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
		public string MaterialNum
		{
			set{ _materialnum=value;}
			get{return _materialnum;}
		}
		/// <summary>
		/// 上线人
		/// </summary>
		public string OnLineMan
		{
			set{ _onlineman=value;}
			get{return _onlineman;}
		}
		/// <summary>
		/// 上线时间
		/// </summary>
		public DateTime OnLineTime
		{
			set{ _onlinetime=value;}
			get{return _onlinetime;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
        public string Fguid
        {
            set { _fguid = value; }
            get { return _fguid; }
        }
		#endregion Model

	}
}

