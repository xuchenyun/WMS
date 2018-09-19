using System;
namespace Model
{
	/// <summary>
	/// PVS_Base_Line:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PVS_Base_Line
	{
		public PVS_Base_Line()
		{}
		#region Model
		private int _lineid;
		private string _linename;
		private string _linetype;
		private string _readfilepath;
		private string _linename2;
		private string _morderno;
		private string _remark;
		private bool _warnning= false;
		private string _warnningstr;
		/// <summary>
		/// 
		/// </summary>
		public int LineID
		{
			set{ _lineid=value;}
			get{return _lineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LineName
		{
			set{ _linename=value;}
			get{return _linename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LineType
		{
			set{ _linetype=value;}
			get{return _linetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReadFilePath
		{
			set{ _readfilepath=value;}
			get{return _readfilepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LineName2
		{
			set{ _linename2=value;}
			get{return _linename2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MOrderNo
		{
			set{ _morderno=value;}
			get{return _morderno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Warnning
		{
			set{ _warnning=value;}
			get{return _warnning;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WarnningStr
		{
			set{ _warnningstr=value;}
			get{return _warnningstr;}
		}
		#endregion Model

	}
}

