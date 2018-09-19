using System;
namespace Model
{
	/// <summary>
	/// 制具类型表
	/// </summary>
	[Serializable]
	public partial class T_Steel_Drawknife_Type
	{
		public T_Steel_Drawknife_Type()
		{}
		#region Model
		private string _typecode;
		private string _typename;
		private string _remark;
		/// <summary>
		/// 类型代码
		/// </summary>
		public string TypeCode
		{
			set{ _typecode=value;}
			get{return _typecode;}
		}
		/// <summary>
		/// 类型名称
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

