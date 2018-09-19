using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
  public partial  class T_Bllb_group_tbg
    {
        //工序表
        /// <summary>
        /// 工序ID（全球唯一码）
        /// </summary>
        public string TBG_ID { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string GROUP_NAME { get; set; }
        /// <summary>
        /// 类型：0：正常，1：维修
        /// </summary>
        public string GROUP_TYPE { get; set; }
    }
}
