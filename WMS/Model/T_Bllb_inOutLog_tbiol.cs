using System;
namespace Model
{
    /// <summary>
    /// 产品出入库日志表
    /// </summary>
    [Serializable]
    public partial class T_Bllb_inOutLog_tbiol
    {
        public T_Bllb_inOutLog_tbiol()
        { }
        #region Model
        private string _sfcno;
        private string _tbps_id;
        private string _action_type;
        private DateTime? _create_time;
        private string _userid;
        private string _location_sn;
        /// <summary>
        /// 
        /// </summary>
        public string SFCNO
        {
            set { _sfcno = value; }
            get { return _sfcno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBPS_ID
        {
            set { _tbps_id = value; }
            get { return _tbps_id; }
        }
        /// <summary>
        /// 1：入库操作；2：出库（发货）操作
        /// </summary>
        public string ACTION_TYPE
        {
            set { _action_type = value; }
            get { return _action_type; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? CREATE_TIME
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// 员工号
        /// </summary>
        public string USERID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 库位SN
        /// </summary>
        public string LOCATION_SN
        {
            get
            {
                return _location_sn;
            }

            set
            {
                _location_sn = value;
            }
        }
        #endregion Model

    }
}

