using System;
namespace Model
{
	/// <summary>
	/// 参数明细表（字典明细表）
	/// </summary>
	[Serializable]
	public partial class T_Sysc_dictionary_tsd
	{
		public T_Sysc_dictionary_tsd()
		{}
		#region Model
		private string _tsd_id= "newid";
		private string _tsdt_id;
		private string _dict_code;
		private string _dict_value;
		private int? _sort;
		private string _dict_desc;
		/// <summary>
		/// 参数ID（全球唯一码）
		/// </summary>
		public string TSD_ID
		{
			set{ _tsd_id=value;}
			get{return _tsd_id;}
		}
		/// <summary>
		/// 参数类型ID(T_Sysc_dictionaryType_tsdt)
		/// </summary>
		public string TSDT_ID
		{
			set{ _tsdt_id=value;}
			get{return _tsdt_id;}
		}
		/// <summary>
		/// 参数代码
		/// </summary>
		public string DICT_CODE
		{
			set{ _dict_code=value;}
			get{return _dict_code;}
		}
		/// <summary>
		/// 参数值
		/// </summary>
		public string DICT_VALUE
		{
			set{ _dict_value=value;}
			get{return _dict_value;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? SORT
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string DICT_DESC
		{
			set{ _dict_desc=value;}
			get{return _dict_desc;}
		}
		#endregion Model

	}
}

