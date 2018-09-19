using System;
namespace Model
{
	/// <summary>
	/// 产品状态表
	/// </summary>
	[Serializable]
	public partial class T_Bllb_productStatus_tbps
	{
		public T_Bllb_productStatus_tbps()
		{}
		#region Model
		private string _tbps_id;
		private string _tbtg_id;
		private string _plcode;
		private string _sfcno;
		private DateTime? _pass_time;
		private string _re_tbtg_id;

        private string _before_tbtg_id;
		/// <summary>
		/// 产品状态ID（唯一码）
		/// </summary>
		public string TBPS_ID
		{
			set{ _tbps_id=value;}
			get{return _tbps_id;}
		}
		/// <summary>
		/// 最后过站工艺工序ID（T_Bllb_technologyGroup_tbtg）
		/// </summary>
		public string TBTG_ID
		{
			set{ _tbtg_id=value;}
			get{return _tbtg_id;}
		}
		/// <summary>
		/// 线别代码（MdcDatProductLine）
		/// </summary>
		public string PLCode
		{
			set{ _plcode=value;}
			get{return _plcode;}
		}
		/// <summary>
		/// 制令单（SfcDatProduct)
		/// </summary>
		public string SfcNo
		{
			set{ _sfcno=value;}
			get{return _sfcno;}
		}
		/// <summary>
		/// 过站时间
		/// </summary>
		public DateTime? PASS_TIME
		{
			set{ _pass_time=value;}
			get{return _pass_time;}
		}
		/// <summary>
		/// 指定回流工序
		/// </summary>
		public string RE_TBTG_ID
		{
			set{ _re_tbtg_id=value;}
			get{return _re_tbtg_id;}
		}
        /// <summary>
        /// 进入维修前的工艺工序ID
        /// </summary>
        public string BEFORE_TBTG_ID
        {
            set { _before_tbtg_id = value; }
            get { return _before_tbtg_id; }
        }
        #endregion Model

    }
}

