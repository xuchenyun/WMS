
using System;
namespace Model
{
	/// <summary>
	/// 检验单产品测试项表
	/// </summary>
	[Serializable]
	public partial class T_Bllb_sampleCheckItem_tbsci
	{
		public T_Bllb_sampleCheckItem_tbsci()
		{}
		#region Model
		private string _tbsci_id;
		private string _tbci_id;
		private string _test_value;
		private string _is_ok;
		private string _tbps_id;
		private string _doc_no;
		/// <summary>
		/// 检验单产品测试项ID
		/// </summary>
		public string TBSCI_ID
		{
			set{ _tbsci_id=value;}
			get{return _tbsci_id;}
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
		/// 产品状态ID（T_Bllb_productStatus_tbps）
		/// </summary>
		public string TBPS_ID
		{
			set{ _tbps_id=value;}
			get{return _tbps_id;}
		}
		/// <summary>
		/// 检验单号
		/// </summary>
		public string DOC_NO
		{
			set{ _doc_no=value;}
			get{return _doc_no;}
		}
		#endregion Model

	}
}

