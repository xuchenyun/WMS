using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class T_InventoryDetail_tid
    {
        /// <summary>
        /// 唯一标识码
        /// </summary>
        public string ReelId { get; set; }
        /// <summary>
        /// 盘点单号
        /// </summary>
        public string InventoryCode { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 未盘数
        /// </summary>
        public decimal UnQty { get; set; }
        /// <summary>
        /// 已盘数
        /// </summary>
        public decimal CurrentQty { get; set; }
        /// <summary>
        /// 差异数
        /// </summary>
        public decimal DifferQty { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        
    }
}
