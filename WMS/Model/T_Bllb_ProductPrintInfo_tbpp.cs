
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    [Serializable]
    public class T_Bllb_ProductPrintInfo_tbpp
    {
        /// <summary>
        ///产品代码
        /// </summary>
		public string ProductCode { get; set; }
        /// <summary>
        ///二维码
        /// </summary>
		public string ProductSN { get; set; }
        /// <summary>
        ///打印标签1
        /// </summary>
		public string Print1 { get; set; }
        /// <summary>
        ///打印标签2
        /// </summary>
		public string Print2 { get; set; }
        /// <summary>
        ///打印标签3
        /// </summary>
		public string Print3 { get; set; }
        /// <summary>
        ///打印标签4
        /// </summary>
		public string Print4 { get; set; }
        /// <summary>
        ///打印标签5
        /// </summary>
		public string Print5 { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 箱标签
        /// </summary>
        public string PackLabel { get; set; }
        /// <summary>
        /// 产品标签
        /// </summary>
        public string ProductLabel{get;set;}
        /// <summary>
        /// 箱容量
        /// </summary>
        public int TankPack { get; set; }
        /// <summary>
        /// 箱内小包数
        /// </summary>
        public int SmallInPack { get; set; }
	}
}
