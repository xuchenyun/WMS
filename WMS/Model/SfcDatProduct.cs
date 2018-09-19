using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 指令单表操作类
    /// </summary>
    public partial class SfcDatProduct
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public string Fguid { get; set; }
        /// <summary>
        /// 工单
        /// </summary>
        public string WoCode { get; set; }
        /// <summary>
        /// 制令单
        /// </summary>
        public string SfcNo { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime ActStart_Min { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime ActStart_Max { get; set; }
    }
}
