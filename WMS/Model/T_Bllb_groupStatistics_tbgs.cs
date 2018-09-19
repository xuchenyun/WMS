using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
  public partial  class T_Bllb_groupStatistics_tbgs
    {
        //过站统计表
        /// <summary>
        /// 制令单
        /// </summary>
        public string SfcNo { get; set; }
        /// <summary>
        /// 工艺工序ID
        /// </summary>
        public string TBTG_ID { get; set; }
        /// <summary>
        /// 过站次数
        /// </summary>
        public string PASS_NUM { get; set; }
        /// <summary>
        /// 打不良次数
        /// </summary>
        public string ERROR_NUM { get; set; }
    }
}
