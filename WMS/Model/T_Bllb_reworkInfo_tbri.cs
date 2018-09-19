using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 返工信息表实体类
    /// </summary>
    public partial class T_Bllb_reworkInfo_tbri
    {
        /// <summary>
        /// 唯一码
        /// </summary>
        public string TbriId { get; set; }
        /// <summary>
        /// 产品状态ID（T_Bllb_productInfo_tbpi）  
        /// </summary>
        public string TbpsId { get; set; }
        /// <summary>
        /// 返工人
        /// </summary>
        public string ReworkMan { get; set; }
        /// <summary>
        /// 返工时间
        /// </summary>
        public DateTime ReworkTime { get; set; }
        /// <summary>
        /// 旧制令单（SfcDatProduct） 
        /// </summary>
        public string OldSfcno { get; set; }
        /// <summary>
        /// 新制令单（SfcDatProduct）
        /// </summary>
        public string NewSfcno { get; set; }
        /// <summary>
        /// 返工原因
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 返工投入工艺工序ID（T_Bllb_technologyGroup_tbtg）
        /// </summary>
        public string TbtgId { get; set; }
        /// <summary>
        /// 是否已返工（Y/N）
        /// </summary>
        public string ReworkFlag { get; set; }
        /// <summary>
        /// 查询时判定时间最小值
        /// </summary>
        public DateTime ReworkTimeMin { get; set; }
        /// <summary>
        /// 查询时判定时间最大值
        /// </summary>
        public DateTime ReworkTimeMax { get; set; }
        /// <summary>
        /// 工艺ID
        /// </summary>
        public string TBT_ID { get; set; }
    }
}
