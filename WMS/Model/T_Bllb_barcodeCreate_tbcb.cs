using System;
namespace CIT.Model
{
    /// <summary>
    /// 自动生成条码主表
    /// </summary>
    [Serializable]
    public partial class T_Bllb_barcodeCreate_tbcb
    {
        public T_Bllb_barcodeCreate_tbcb()
        { }
        #region Model
        private string _tbbp_id;
        private DateTime? _create_time;
        private string _creator;
        private string _modifier;
        private DateTime? _modify_time;
        private string _item_type;
        private string _item_value;
        private string _tbcb_id;

        /// <summary>
        /// 表T_Bllb_barcodeProduct_tbbp
        /// </summary>
        public string TBBP_ID
        {
            set { _tbbp_id = value; }
            get { return _tbbp_id; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATE_TIME
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// 创建人员工号
        /// </summary>
        public string CREATOR
        {
            set { _creator = value; }
            get { return _creator; }
        }
        /// <summary>
        /// 修改人员工号
        /// </summary>
        public string MODIFIER
        {
            set { _modifier = value; }
            get { return _modifier; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? MODIFY_TIME
        {
            set { _modify_time = value; }
            get { return _modify_time; }
        }
        /// <summary>
        /// 1：固定字符；2：时间；3：流水号；4：SQL语句
        /// </summary>
        public string ITEM_TYPE
        {
            set { _item_type = value; }
            get { return _item_type; }
        }
        /// <summary>
        /// 值
        /// </summary>
        public string ITEM_VALUE
        {
            set { _item_value = value; }
            get { return _item_value; }
        }
        /// <summary>
        /// 表名：T_Bllb_barcodeCreate_tbcb
        /// </summary>
        public string TBCB_ID
        {
            set { _tbcb_id = value; }
            get { return _tbcb_id; }
        }
      
        #endregion Model

    }
}

