using System;
namespace Model
{
	/// <summary>
	/// PVS_Busi_LoadingList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PVS_Busi_LoadingList
	{
		public PVS_Busi_LoadingList()
		{}
		#region Model
		private int _id;
		private int _lineid;
		private int _machinecode;
		private string _tableno;
		private string _bct;
		private int? _trackno;
		private int? _division;
		private int _pickpos;
		private string _feedertype;
		private string _feederno;
		private string _matrcode;
		private string _matrdescription;
		private int? _partstatus=0;
		private int? _uselevel=0;
		private decimal? _cycletime=0M;
		private string _partpos;
		private int? _placedqty=0;
		private int? _pickerror=0;
		private int? _identerror=0;
		private int? _othererror=0;
		private int? _placedqty2=0;
		private int? _pickerror2=0;
		private int? _identerror2=0;
		private int? _othererror2=0;
		private string _uniquecode="";
		private int? _leftqty=0;
		private string _standbycode="";
		private int? _standbyqty=0;
		private bool _stoptrail= false;
		private string _scanner;
		private DateTime? _scantime;
		private DateTime? _changetime;
		private bool _lane1= true;
		private bool _lane2= false;
		private string _remark;
		private bool _istray= false;
		private int? _deletetag=0;
		private bool _isolc= false;
		private int? _uselevel2=0;
		private decimal? _cycletime2=0M;
		private string _partpos2;
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
		public int LineID
		{
			set{ _lineid=value;}
			get{return _lineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MachineCode
		{
			set{ _machinecode=value;}
			get{return _machinecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TableNo
		{
			set{ _tableno=value;}
			get{return _tableno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BCT
		{
			set{ _bct=value;}
			get{return _bct;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TrackNo
		{
			set{ _trackno=value;}
			get{return _trackno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Division
		{
			set{ _division=value;}
			get{return _division;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PickPos
		{
			set{ _pickpos=value;}
			get{return _pickpos;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FeederType
		{
			set{ _feedertype=value;}
			get{return _feedertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FeederNo
		{
			set{ _feederno=value;}
			get{return _feederno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MatrCode
		{
			set{ _matrcode=value;}
			get{return _matrcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MatrDescription
		{
			set{ _matrdescription=value;}
			get{return _matrdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PartStatus
		{
			set{ _partstatus=value;}
			get{return _partstatus;}
		}
		/// <summary>
		/// 用量
		/// </summary>
		public int? UseLevel
		{
			set{ _uselevel=value;}
			get{return _uselevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CycleTime
		{
			set{ _cycletime=value;}
			get{return _cycletime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartPos
		{
			set{ _partpos=value;}
			get{return _partpos;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlacedQty
		{
			set{ _placedqty=value;}
			get{return _placedqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PickError
		{
			set{ _pickerror=value;}
			get{return _pickerror;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IdentError
		{
			set{ _identerror=value;}
			get{return _identerror;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OtherError
		{
			set{ _othererror=value;}
			get{return _othererror;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlacedQty2
		{
			set{ _placedqty2=value;}
			get{return _placedqty2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PickError2
		{
			set{ _pickerror2=value;}
			get{return _pickerror2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IdentError2
		{
			set{ _identerror2=value;}
			get{return _identerror2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OtherError2
		{
			set{ _othererror2=value;}
			get{return _othererror2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UniqueCode
		{
			set{ _uniquecode=value;}
			get{return _uniquecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LeftQty
		{
			set{ _leftqty=value;}
			get{return _leftqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StandbyCode
		{
			set{ _standbycode=value;}
			get{return _standbycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? StandbyQty
		{
			set{ _standbyqty=value;}
			get{return _standbyqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool StopTrail
		{
			set{ _stoptrail=value;}
			get{return _stoptrail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Scanner
		{
			set{ _scanner=value;}
			get{return _scanner;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ScanTime
		{
			set{ _scantime=value;}
			get{return _scantime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ChangeTime
		{
			set{ _changetime=value;}
			get{return _changetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Lane1
		{
			set{ _lane1=value;}
			get{return _lane1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Lane2
		{
			set{ _lane2=value;}
			get{return _lane2;}
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
		public bool IsTray
		{
			set{ _istray=value;}
			get{return _istray;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DeleteTag
		{
			set{ _deletetag=value;}
			get{return _deletetag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isOLC
		{
			set{ _isolc=value;}
			get{return _isolc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UseLevel2
		{
			set{ _uselevel2=value;}
			get{return _uselevel2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CycleTime2
		{
			set{ _cycletime2=value;}
			get{return _cycletime2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartPos2
		{
			set{ _partpos2=value;}
			get{return _partpos2;}
		}
		#endregion Model

	}
}

