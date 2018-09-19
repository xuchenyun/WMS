using System;
namespace Model
{
	/// <summary>
	/// 制具料号信息表
	/// </summary>
	[Serializable]
	public partial class T_Steel_Drawknife_Number
	{
		public T_Steel_Drawknife_Number()
		{}
		#region Model
		private string _materialnum;
		private string _type;
		private string _describe;
		private string _size;
		private decimal _tension;
		private string _usethreshold;
		private string _creator;
		private DateTime _creatime;
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
		/// 类型
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string Describe
		{
			set{ _describe=value;}
			get{return _describe;}
		}
		/// <summary>
		/// 规格大小
		/// </summary>
		public string Size
		{
			set{ _size=value;}
			get{return _size;}
		}
		/// <summary>
		/// 张力
		/// </summary>
		public decimal  Tension
		{
			set{ _tension=value;}
			get{return _tension;}
		}
		/// <summary>
		/// 使用阈值
		/// </summary>
		public string UseThreshold
		{
			set{ _usethreshold=value;}
			get{return _usethreshold;}
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
		public DateTime Creatime
		{
			set{ _creatime=value;}
			get{return _creatime;}
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

