
using System;
namespace Model
{
	/// <summary>
	/// 检验单产品测试项表
	/// </summary>
	[Serializable]
	public partial class T_Bllb_IQCCheckItem_tbici
    {
		public T_Bllb_IQCCheckItem_tbici()
		{}
		#region Model
		private string _tbici_id;
		private string _tbci_id;
		private string _test_value;
		private string _is_ok;
		private string _seiral_number;
		private string _iqc_no;
        private int _test_qty;
		/// <summary>
		/// 检验单产品测试项ID
		/// </summary>
		public string TBICI_ID
		{
			set{ _tbici_id=value;}
			get{return _tbici_id;}
		}
		/// <summary>
		/// 检测项目ID（T_Bllb_checkItem_tbci）
		/// </summary>
		public string TBCI_ID
		{
			set{ _tbci_id=value;}
			get{return _tbci_id;}
		}
		/// <summary>
		/// 测试值
		/// </summary>
		public string TEST_VALUE
		{
			set{ _test_value=value;}
			get{return _test_value;}
		}
		/// <summary>
		/// （Y/N）是否合格
		/// </summary>
		public string IS_OK
		{
			set{ _is_ok=value;}
			get{return _is_ok;}
		}
		/// <summary>
		/// 物料SN
		/// </summary>
		public string SERIAL_NUMBER
		{
			set{ _seiral_number=value;}
			get{return _seiral_number;}
		}
		/// <summary>
		/// IQC检验单号
		/// </summary>
		public string IQC_NO
		{
			set{ _iqc_no=value;}
			get{return _iqc_no;}
		}
        /// <summary>
        /// 检测数量
        /// </summary>
        public int TEST_QTY
        {
            get
            {
                return _test_qty;
            }

            set
            {
                _test_qty = value;
            }
        }
        #endregion Model

    }
}

