using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class T_Bllb_StockInfo_tbsi
    {
        /// <summary>
        /// 仓库SN
        /// </summary>
        public string Storage_SN { get; set; }
        /// <summary>
        /// 库区SN
        /// </summary>
        public string Area_SN { get; set; }
        /// <summary>
        /// 库位SN
        /// </summary>
        public string Location_SN { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int QTY { get; set; }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public string Is_Locked { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public string Enable { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime In_Time { get; set; }
        /// <summary>
        /// 容器类型
        /// </summary>
        public string Container_Type { get; set; }
        /// <summary>
        /// 物料SN
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 物料状态1:正常品;2:样品
        /// </summary>
        public string Status_Flag { get; set; }
        /// <summary>
        /// 线别代码
        /// </summary>
        public string PLCode { get; set; }
        public string Lock_Flag { get; set; }
    }
}
