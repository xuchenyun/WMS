using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class T_Inventory_Detail
    {
        /// <summary>
        /// 盘点单号
        /// </summary>
        public string InventoryCode { get; set; }
        /// <summary>
        /// 仓库号
        /// </summary>
        public string HouseCode { get; set; }
        /// <summary>
        /// 仓库名
        /// </summary>
        public string HouseName { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string PN { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Qty { get; set; }
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
        /// 库区
        /// </summary>
        public string StorageArea { get; set; }
        /// <summary>
        /// 库位
        /// </summary>
        public string StorageLocation { get; set; }
        
    }
}
