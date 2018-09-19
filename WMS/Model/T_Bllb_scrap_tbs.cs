using System;
namespace Model
{
	/// <summary>
	/// T_Bllb_scrap_tbs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Bllb_scrap_tbs
	{
		public T_Bllb_scrap_tbs()
		{}
		#region Model
		private string _tbs_id= "";
		private string _tbps_id;
		private DateTime _tbpi_time = DateTime.Now;
        private string _userid;
		private string _memo;
        private DateTime _tbpi_time_min = DateTime.Now;
        private DateTime _tbpi_time_max=DateTime.Now;
        /// <summary>
        /// 报废ID（全球唯一码）
        /// </summary>
        public string TBS_ID
		{
			set{ _tbs_id=value;}
			get{return _tbs_id;}
		}
		/// <summary>
		/// 产品状态ID(T_Bllb_productStatus_tbps)
		/// </summary>
		public string TBPS_ID
		{
			set{ _tbps_id=value;}
			get{return _tbps_id;}
		}
		/// <summary>
		/// 报废时间
		/// </summary>
		public DateTime TBPI_TIME
		{
			set{ _tbpi_time=value;}
			get{return _tbpi_time;}
		}
		/// <summary>
		/// 员工号
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 报废原因
		/// </summary>
		public string MEMO
		{
			set{ _memo=value;}
			get{return _memo;}
		}
        /// <summary>
        ///  起始时间
        /// </summary>
        public DateTime TBPI_TIME_MIN
        {
            set { _tbpi_time_min = value; }
            get { return _tbpi_time_min; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime TBPI_TIME_MAX
        {
            set { _tbpi_time_max = value; }
            get { return _tbpi_time_max; }
        }
        #endregion Model

    }
}

