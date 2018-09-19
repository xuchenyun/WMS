using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class T_InventoryCodeCollect_ticc
    {
        /// <summary>
        /// 盘点单号
        /// </summary>
        public  string InventoryCode { get; set; }
        /// <summary>
        /// 盘盈盘亏号
        /// </summary>
        public string InventoryNumber { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        public string Flag { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string PN { get; set; }
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
