using System;
namespace Model
{
	/// <summary>
	/// 机种&制具料号关系表
	/// </summary>
	[Serializable]
	public partial class T_Steel_Drawknife_Product
	{
		public T_Steel_Drawknife_Product()
		{}
		#region Model
		private string _product;
		private string _face_type;
		private string _tool_type;
		private string _tool_materialnum;
		private string _remark;
		/// <summary>
		/// 机种
		/// </summary>
		public string Product
		{
			set{ _product=value;}
			get{return _product;}
		}
		/// <summary>
		/// 面别
		/// </summary>
		public string Face_Type
		{
			set{ _face_type=value;}
			get{return _face_type;}
		}
		/// <summary>
		/// 制具类型
		/// </summary>
		public string Tool_Type
		{
			set{ _tool_type=value;}
			get{return _tool_type;}
		}
		/// <summary>
		/// 制具料号
		/// </summary>
		public string Tool_MaterialNum
		{
			set{ _tool_materialnum=value;}
			get{return _tool_materialnum;}
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

