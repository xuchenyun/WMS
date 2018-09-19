using System;
namespace Model
{
	/// <summary>
	/// 制具库存表
	/// </summary>
	[Serializable]
	public partial class T_Steel_Drawknife_Stock
	{
		public T_Steel_Drawknife_Stock()
		{}
		#region Model
		private string _materialnum;
		private string _serialnum;
		private string _type= "0";
		private string _status= "0";
		private string _lendback= "0";
		private string _isbeyondvalue= "0";
		private string _location;
		private decimal _tension;
		private decimal _lefttop;
		private decimal _leftbottom;
		private decimal _righttop;
		private decimal _rightbottom;
		private decimal _center;
		private string _usevalue;
		private int _usetimes;
		private string _creator;
		private DateTime _createtime;
		private string _updator;
		private DateTime _updatetime;
		private string _remark;
        private int _earlywaring;
		/// <summary>
		/// 料号
		/// </summary>
		public string MaterialNum
		{
			set{ _materialnum=value;}
			get{return _materialnum;}
		}
		/// <summary>
		/// SN
		/// </summary>
		public string SerialNum
		{
			set{ _serialnum=value;}
			get{return _serialnum;}
		}
		/// <summary>
		/// 类型（0---钢网、1---刮刀）
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 状态（0---待检、1---在库、2---出库、3---报废、4---检验OK、5---检验NG）
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 借归（0---借出、1---借入）
		/// </summary>
		public string LendBack
		{
			set{ _lendback=value;}
			get{return _lendback;}
		}
		/// <summary>
		/// 是否超出阈值（0---正常、1---超出）
		/// </summary>
		public string IsBeyondValue
		{
			set{ _isbeyondvalue=value;}
			get{return _isbeyondvalue;}
		}
		/// <summary>
		/// 库位
		/// </summary>
		public string Location
		{
			set{ _location=value;}
			get{return _location;}
		}
		/// <summary>
		/// 张力
		/// </summary>
		public decimal Tension
		{
			set{ _tension=value;}
			get{return _tension;}
		}
		/// <summary>
		/// 左上
		/// </summary>
		public decimal LeftTop
		{
			set{ _lefttop=value;}
			get{return _lefttop;}
		}
		/// <summary>
		/// 左下
		/// </summary>
		public decimal LeftBottom
		{
			set{ _leftbottom=value;}
			get{return _leftbottom;}
		}
		/// <summary>
		/// 右上
		/// </summary>
		public decimal RightTop
		{
			set{ _righttop=value;}
			get{return _righttop;}
		}
		/// <summary>
		/// 右下
		/// </summary>
		public decimal RightBottom
		{
			set{ _rightbottom=value;}
			get{return _rightbottom;}
		}
		/// <summary>
		/// 中间
		/// </summary>
		public decimal Center
		{
			set{ _center=value;}
			get{return _center;}
		}
		/// <summary>
		/// 使用阈值
		/// </summary>
		public string UseValue
		{
			set{ _usevalue=value;}
			get{return _usevalue;}
		}
		/// <summary>
		/// 使用次数
		/// </summary>
		public int UseTimes
		{
			set{ _usetimes=value;}
			get{return _usetimes;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public string Creator
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
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
        /// <summary>
		/// 预警值
		/// </summary>
		public int EarlyWaring
        {
            set { _earlywaring = value; }
            get { return _earlywaring; }
        }
        #endregion Model

    }
}

