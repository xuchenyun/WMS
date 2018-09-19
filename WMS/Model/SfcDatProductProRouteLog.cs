using System;
namespace Model
{
    /// <summary>
    /// SfcDatProductProRouteLog:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SfcDatProductProRouteLog
    {
        public SfcDatProductProRouteLog()
        { }
        #region Model
        private string _fguid;
        private string _repairHouse;
        private string _repairHouseName;
        private string _sfcno;
        private string _wocode;
        private string _product;
        private string _productname;
        private string _pcbcode;
        private string _processid;
        private string _processname;
        private string _line; 
        private string _routeid;
        private string _routename;
        private string _type;
        private string _status;
        private string _errorcode;
        private string _fnote;
        private string _creator;
        private string _createtime;
        private string _msg;
        private string _station;
        /// <summary>
        /// 
        /// </summary>
        public string SfcNO
        {
            set { _sfcno = value; }
            get { return _sfcno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Wocode
        {
            set { _wocode = value; }
            get { return _wocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Line
        {
            set { _line = value; }
            get { return _line; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Product
        {
            set { _product = value; }
            get { return _product; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PCBCode
        {
            set { _pcbcode = value; }
            get { return _pcbcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessID
        {
            set { _processid = value; }
            get { return _processid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessName
        {
            set { _processname = value; }
            get { return _processname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RouteID
        {
            set { _routeid = value; }
            get { return _routeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RouteName
        {
            set { _routename = value; }
            get { return _routename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ErrorCode
        {
            set { _errorcode = value; }
            get { return _errorcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fnote
        {
            set { _fnote = value; }
            get { return _fnote; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Creator
        {
            set { _creator = value; }
            get { return _creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public string Fguid
        {
            set { _fguid = value; }
            get { return _fguid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string RepairHouseName
        {
            set { _repairHouseName = value; }
            get { return _repairHouseName; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string RepairHouse
        {
            set { _repairHouse = value; }
            get { return _repairHouse; }
        }
        public string Msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public string Station
        {
            set { _station = value; }
            get { return _station; }
        }
    }
}

