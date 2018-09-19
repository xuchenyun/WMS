using System;
namespace Model
{
	/// <summary>
	/// 制具检验表
	/// </summary>
	[Serializable]
	public partial class T_Steel_Drawknife_Checkout
	{
		public T_Steel_Drawknife_Checkout()
		{}
		#region Model
		private string _serialnumber;
		private string _materialnum;
		private string _type= "0";
		private string _status= "0";
		private string _creator;
		private DateTime _createtime;
		private string _checkman;
		private DateTime _checktime;
		private string _remark;
		/// <summary>
		/// SN
		/// </summary>
		public string SerialNumber
		{
			set{ _serialnumber=value;}
			get{return _serialnumber;}
		}
		/// <summary>
		/// 料号
		/// </summary>
		public string MaterialNum
		{
			set{ _materialnum=value;}
			get{return _materialnum;}
		}
		/// <summary>
		/// 类型（0---钢网、1---刮刀）
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 状态（0---待检、1---检验OK、2---检验NG）
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public string Creator
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 检验人
		/// </summary>
		public string CheckMan
		{
			set{ _checkman=value;}
			get{return _checkman;}
		}
		/// <summary>
		/// 检验时间
		/// </summary>
		public DateTime CheckTime
		{
			set{ _checktime=value;}
			get{return _checktime;}
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

