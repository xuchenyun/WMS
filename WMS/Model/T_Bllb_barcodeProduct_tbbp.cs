using System;
namespace CIT.Model
{
    /// <summary>
    /// 自动生成条码主表
    /// </summary>
    [Serializable]
    public partial class T_Bllb_barcodeProduct_tbbp
    {
        public T_Bllb_barcodeProduct_tbbp()
        { }
        #region Model
        private string _tbbp_id;
        private string _productcode;
        private DateTime? _create_time;
        private string _creator;
        private string _modifier;
        private DateTime? _modify_time;
        private string _para1;
        private string _partnumber;
        private string _partname;
        private string _partspec;
        private string _lable_Temp;
        /// <summary>
        /// ID
        /// </summary>
        public string TBBP_ID
        {
            set { _tbbp_id = value; }
            get { return _tbbp_id; }
        }
        /// <summary>
        /// 产品代码
        /// </summary>
        public string PRODUCTCODE
        {
            set { _productcode = value; }
            get { return _productcode; }
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
        /// 总成信息
        /// </summary>
        public string PARA1
        {
            set { _para1 = value; }
            get { return _para1; }
        }
        /// <summary>
        /// 零件编号
        /// </summary>
        public string PARTNUMBER
        {
            set { _partnumber = value; }
            get { return _partnumber; }
        }
        /// <summary>
        /// 零件名称
        /// </summary>
        public string PARTNAME
        {
            set { _partname = value; }
            get { return _partname; }
        }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string PARTSPEC
        {
            set { _partspec = value; }
            get { return _partspec; }
        }
        /// <summary>
        /// 外壳标签名称
        /// </summary>
        public string LABLE_TEMP
        {
            get
            {
                return _lable_Temp;
            }

            set
            {
                _lable_Temp = value;
            }
        }
        #endregion Model

    }
}

