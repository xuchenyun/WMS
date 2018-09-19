using System;
namespace Model
{
	/// <summary>
	/// MdcDatVStorage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MdcDatVStorage
	{
		public MdcDatVStorage()
		{}
		#region Model
		private Guid _cguid;
		private string _pocode;
		private string _wocode;
		private string _sfcno;
		private string _housecode;
		private string _reelid;
		private string _partnumber;
		private string _mpn;
		private decimal? _qty=0M;
		private string _type;
		private string _supplier;
		private string _supplierid;
		private string _suppliernumber;
		private string _packid;
		private int? _findex;
		private string _ftype;
		private string _mtype;
		private string _status= "1";
		private int? _batchcnt;
		private string _datecode;
		private string _batch1;
		private string _batch2;
		private string _localid;
		private string _shelfid;
		private DateTime? _productdate;
		private DateTime? _expirationdate;
		private string _descride;
		private string _series;
		private string _productname;
		private string _line;
		private string _laneno;
		private string _machid;
		private string _slot;
		private string _side;
		private int? _isusing;
		private int? _isenable=0;
		private int? _statu;
		private int _ttype=0;
		private int? _lockstatus=0;
		private DateTime? _shelftime;
		private int _msdtime=0;
		private DateTime? _grtime;
		private decimal? _grqty=0M;
		private string _creator;
		private DateTime? _createtime;
		private string _updator;
		private DateTime? _updatetime;
		private string _tables;
		/// <summary>
		/// 
		/// </summary>
		public Guid CGUID
		{
			set{ _cguid=value;}
			get{return _cguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PoCode
		{
			set{ _pocode=value;}
			get{return _pocode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WoCode
		{
			set{ _wocode=value;}
			get{return _wocode;}
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
		public string HouseCode
		{
			set{ _housecode=value;}
			get{return _housecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReelID
		{
			set{ _reelid=value;}
			get{return _reelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartNumber
		{
			set{ _partnumber=value;}
			get{return _partnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MPN
		{
			set{ _mpn=value;}
			get{return _mpn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Supplier
		{
			set{ _supplier=value;}
			get{return _supplier;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SupplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SupplierNumber
		{
			set{ _suppliernumber=value;}
			get{return _suppliernumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PackID
		{
			set{ _packid=value;}
			get{return _packid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Findex
		{
			set{ _findex=value;}
			get{return _findex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ftype
		{
			set{ _ftype=value;}
			get{return _ftype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mtype
		{
			set{ _mtype=value;}
			get{return _mtype;}
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
		public int? BatchCnt
		{
			set{ _batchcnt=value;}
			get{return _batchcnt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DateCode
		{
			set{ _datecode=value;}
			get{return _datecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Batch1
		{
			set{ _batch1=value;}
			get{return _batch1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Batch2
		{
			set{ _batch2=value;}
			get{return _batch2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LocalID
		{
			set{ _localid=value;}
			get{return _localid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShelfID
		{
			set{ _shelfid=value;}
			get{return _shelfid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ProductDate
		{
			set{ _productdate=value;}
			get{return _productdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ExpirationDate
		{
			set{ _expirationdate=value;}
			get{return _expirationdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Descride
		{
			set{ _descride=value;}
			get{return _descride;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Series
		{
			set{ _series=value;}
			get{return _series;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
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
		public string LaneNo
		{
			set{ _laneno=value;}
			get{return _laneno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachID
		{
			set{ _machid=value;}
			get{return _machid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Slot
		{
			set{ _slot=value;}
			get{return _slot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string side
		{
			set{ _side=value;}
			get{return _side;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsUsing
		{
			set{ _isusing=value;}
			get{return _isusing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsEnable
		{
			set{ _isenable=value;}
			get{return _isenable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? statu
		{
			set{ _statu=value;}
			get{return _statu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Ttype
		{
			set{ _ttype=value;}
			get{return _ttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LockStatus
		{
			set{ _lockstatus=value;}
			get{return _lockstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ShelfTime
		{
			set{ _shelftime=value;}
			get{return _shelftime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MSDtime
		{
			set{ _msdtime=value;}
			get{return _msdtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? GRTime
		{
			set{ _grtime=value;}
			get{return _grtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? GRQty
		{
			set{ _grqty=value;}
			get{return _grqty;}
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
		public DateTime? Createtime
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
		public DateTime? Updatetime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tables
		{
			set{ _tables=value;}
			get{return _tables;}
		}
		#endregion Model

	}
}

