using System;
namespace Model
{
	/// <summary>
	/// 一级包装信息表
	/// </summary>
	[Serializable]
	public partial class T_Bllb_packageOne_tbpo
	{
		public T_Bllb_packageOne_tbpo()
		{}
		#region Model
		private string _tbpo_id= "newid";
		private string _container_sn_1;
		private string _tbps_id;
		private string _sfc_no;
		private string _tbs_id;
		private string _userid;
		private DateTime? _do_time;
		private int? _plan_qty;
		private string _over_flag;
        private string _old_container_sn_1;
        /// <summary>
        /// 一级包装ID
        /// </summary>
        public string TBPO_ID
		{
			set{ _tbpo_id=value;}
			get{return _tbpo_id;}
		}
		/// <summary>
		/// 1级容器SN
		/// </summary>
		public string CONTAINER_SN_1
		{
			set{ _container_sn_1=value;}
			get{return _container_sn_1;}
		}
        /// 1级容器SN
        /// </summary>
        public string OLD_CONTAINER_SN_1
        {
            set { _old_container_sn_1 = value; }
            get { return _old_container_sn_1; }
        }
        /// <summary>
        /// 产品状态ID（T_Bllb_productStatus_tbps）
        /// </summary>
        public string TBPS_ID
		{
			set{ _tbps_id=value;}
			get{return _tbps_id;}
		}
		/// <summary>
		/// 制令单
		/// </summary>
		public string SFC_NO
		{
			set{ _sfc_no=value;}
			get{return _sfc_no;}
		}
		/// <summary>
		/// 工位ID
		/// </summary>
		public string TBS_ID
		{
			set{ _tbs_id=value;}
			get{return _tbs_id;}
		}
		/// <summary>
		/// 员工号
		/// </summary>
		public string USERID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime? DO_TIME
		{
			set{ _do_time=value;}
			get{return _do_time;}
		}
		/// <summary>
		/// 容量
		/// </summary>
		public int? PLAN_QTY
		{
			set{ _plan_qty=value;}
			get{return _plan_qty;}
		}
		/// <summary>
		/// 包装结束（Y/N）
		/// </summary>
		public string OVER_FLAG
		{
			set{ _over_flag=value;}
			get{return _over_flag;}
		}
		#endregion Model

	}
}

