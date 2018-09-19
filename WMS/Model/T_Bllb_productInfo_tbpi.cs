using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 产品信息实体类
    /// </summary>
    public partial class T_Bllb_productInfo_tbpi
    {
        /// <summary>
        /// 产品信息ID（全球唯一码）
        /// </summary>
        public string TbptId { get; set; }
        /// <summary>
        /// 产品状态ID（T_Bllb_productStatus_tbps）
        /// </summary>
        public string TbpsId { get; set; }
        /// <summary>
        /// 产品条码
        /// </summary>
        public string SERIAL_NUMBER { get; set; }
        /// <summary>
        /// 制令单(SfcDatProduct)
        /// </summary>
        public string SfcNo { get; set; }
        /// <summary>
        /// 是否不良（Y/N）
        /// </summary>
        public string ERROR_FLAG { get; set; }
        /// <summary>
        /// 产品代码
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 客户料号
        /// </summary>
        public string C_PartNumber { get; set; }
    }
}
