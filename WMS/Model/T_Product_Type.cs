using System;
namespace Model
{
    /// <summary>
    /// 机种面别信息表
    /// </summary>
    [Serializable]
    public partial class T_Product_Type
    {
        public T_Product_Type()
        { }
        #region Model
        private string _productnum;
        private string _facetype;
        private string _remark;
        private string _describe;
        /// <summary>
        /// 编码
        /// </summary>
        public string ProductNum
        {
            set { _productnum = value; }
            get { return _productnum; }
        }
        /// <summary>
        /// 面别
        /// </summary>
        public string FaceType
        {
            set { _facetype = value; }
            get { return _facetype; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string DesCribe
        {
            set { _describe = value; }
            get { return _describe; }
        }
        #endregion Model

    }
}

