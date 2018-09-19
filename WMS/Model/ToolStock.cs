using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ToolStock
    {
        /// <summary>
        /// 制具SN
        /// </summary>
        public string SerialNum { get; set; }
        /// <summary>
        /// 制具料号
        /// </summary>
        public string MaterialNum{ get; set; }
        /// <summary>
        /// 制具类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 制令单
        /// </summary>
        public string SfcNo { get; set; }
        /// <summary>
        /// 机种
        /// </summary>
        public string Product { get; set; }
        /// <summary>
        /// 生产产量
        /// </summary>
        public string ActQty { get; set; }
        /// <summary>
        /// 使用次数
        /// </summary>
        public string UseTimes { get; set; }
        /// <summary>
        /// 唯一标识码
        /// </summary>
        public string Fguid { get; set; }

    }
}
