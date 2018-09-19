using System;
namespace Model
{
	/// <summary>
	/// 系统参数表（字典表）
	/// </summary>
	[Serializable]
	public partial class T_Sysc_dictionaryType_tsdt
	{
		public T_Sysc_dictionaryType_tsdt()
		{}
		#region Model
		private string _tsdt_id= "newid";
		private string _d_typename;
		private string _d_typecode;
		private string _is_show="Y";
		private string _d_typedesc;
		/// <summary>
		/// 全球唯一码
		/// </summary>
		public string TSDT_ID
		{
			set{ _tsdt_id=value;}
			get{return _tsdt_id;}
		}
		/// <summary>
		/// 参数类型名称
		/// </summary>
		public string D_TYPENAME
		{
			set{ _d_typename=value;}
			get{return _d_typename;}
		}
		/// <summary>
		/// 参数类型代码
		/// </summary>
		public string D_TYPECODE
		{
			set{ _d_typecode=value;}
			get{return _d_typecode;}
		}
		/// <summary>
		/// 是否显示(Y/N)
		/// </summary>
		public string IS_SHOW
		{
			set{ _is_show=value;}
			get{return _is_show;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string D_TYPEDESC
		{
			set{ _d_typedesc=value;}
			get{return _d_typedesc;}
		}
		#endregion Model

	}
}

