using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class T_Inventory_ti
    {
        /// <summary>
        /// 盘点单号
        /// </summary>
        public string InventoryCode { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 仓库号
        /// </summary>
        public string HouseCode { get; set; }
        /// <summary>
        /// 仓库名
        /// </summary>
        public string HouseName { get; set; }
        /// <summary>
        /// 库区
        /// </summary>
        public string StorageArea { get; set; }
        /// <summary>
        /// 库位
        /// </summary>
        public string StorageLocation { get; set; }
        public string PN { get; set; }
    }
}
