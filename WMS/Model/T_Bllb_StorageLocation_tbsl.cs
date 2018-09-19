using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class T_Bllb_StorageLocation_tbsl
    {
        /// <summary>
        /// 库位SN
        /// </summary>
        public string Location_SN { get; set; }
        /// <summary>
        /// 库位名称
        /// </summary>
        public string Location_Name { get; set; }
        /// <summary>
        /// 库区SN
        /// </summary>
        public string Area_SN { get; set; }
   
        /// <summary>
        /// 库位上存放的容器数量
        /// </summary>
        public int Container_Qty { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 容器类型
        /// </summary>
        public string Container_Type { get; set; }
        /// <summary>
        /// 物料状态1:正常品;2:样品
        /// </summary>
        public string Status_Flag { get; set; }
        /// <summary>
        /// 是否启用（Y/N）
        /// </summary>
        public string Enable_Flag { get; set; }
    }
}
