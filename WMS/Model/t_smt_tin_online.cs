using System;
namespace Model
{
    /// <summary>
    ///锡膏上线表
    /// </summary>
    [Serializable]
	public partial class t_smt_tin_online
	{
		public t_smt_tin_online()
		{}
		#region Model
		private int _id;
		private string _wocde;
		private string _sfcno;
		private string _produceno;
		private string _line;
		private string _reelid;
		private string _tinmaterial;
		private string _status;
		private DateTime? _onlinetime;
		private string _operaor;
		private string _datecode;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wocde
		{
			set{ _wocde=value;}
			get{return _wocde;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SfcNo
		{
			set{ _sfcno=value;}
			get{return _sfcno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProduceNo
		{
			set{ _produceno=value;}
			get{return _produceno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Line
		{
			set{ _line=value;}
			get{return _line;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReelId
		{
			set{ _reelid=value;}
			get{return _reelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TinMaterial
		{
			set{ _tinmaterial=value;}
			get{return _tinmaterial;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OnLineTime
		{
			set{ _onlinetime=value;}
			get{return _onlinetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Operaor
		{
			set{ _operaor=value;}
			get{return _operaor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DateCode
		{
			set{ _datecode=value;}
			get{return _datecode;}
		}
		#endregion Model

	}
}

