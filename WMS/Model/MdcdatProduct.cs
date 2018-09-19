using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class MdcdatProduct
    {
        //机种表
        /// <summary>
        /// 标识列
        /// </summary>
        public string Fguid { get; set; }
        /// <summary>
        /// 产品代码
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// PCB类型（0：单板，1：大板 ，2：子板，3：炉后拼板，4：无）
        /// </summary>
        public string BarCodeType { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public string Updator { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        public string Remark { get; set; }
        /// <summary>
        /// UPH值
        /// </summary>
        public string UPH { get; set; }
    }
}
