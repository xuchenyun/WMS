using System;
namespace Model
{
	/// <summary>
	/// 制具管理表
	/// </summary>
	[Serializable]
	public partial class T_Steel_Drawknife_Manage
	{
		public T_Steel_Drawknife_Manage()
		{}
		#region Model
		private string _serialnumber;
		private string _materialnum;
		private string _status= "0";
		private string _updator;
		private DateTime _updatetime;
		private string _remark;
        private string _fguid;
        private string _product;
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
		/// 状态（0---上线待检、1---已检验、2---上线）
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 更新人
		/// </summary>
		public string Updator
		{
			set{ _updator=value;}
			get{return _updator;}
		}
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
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
        /// <summary>
        /// 机种
        /// </summary>
        public string Product
        {
            set { _product = value; }
            get { return _product; }
        }
		#endregion Model

	}
}

