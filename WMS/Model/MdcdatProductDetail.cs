using System;
namespace Model
{
	/// <summary>
	/// MdcdatProductDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MdcdatProductDetail
	{
		public MdcdatProductDetail()
		{}
		#region Model
		private Guid _fguid;
		private string _productcode;
		private string _key1;
		private string _key2;
		private string _key3;
		private string _key4;
		private string _key5;
		private string _value1;
		private string _value2;
		private string _value3;
		private string _value4;
		private string _value5;
		private string _creator;
		private DateTime? _createtime;
		private string _updator;
		private DateTime? _updatetime;
		/// <summary>
		/// 
		/// </summary>
		public Guid Fguid
		{
			set{ _fguid=value;}
			get{return _fguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductCode
		{
			set{ _productcode=value;}
			get{return _productcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string key1
		{
			set{ _key1=value;}
			get{return _key1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string key2
		{
			set{ _key2=value;}
			get{return _key2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string key3
		{
			set{ _key3=value;}
			get{return _key3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string key4
		{
			set{ _key4=value;}
			get{return _key4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string key5
		{
			set{ _key5=value;}
			get{return _key5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value1
		{
			set{ _value1=value;}
			get{return _value1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value2
		{
			set{ _value2=value;}
			get{return _value2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value3
		{
			set{ _value3=value;}
			get{return _value3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value4
		{
			set{ _value4=value;}
			get{return _value4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value5
		{
			set{ _value5=value;}
			get{return _value5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Creator
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Updator
		{
			set{ _updator=value;}
			get{return _updator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

