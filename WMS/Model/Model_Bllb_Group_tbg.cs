using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Model_Bllb_Group_tbg
    {
        /// <summary>
        /// 工序ID（全球唯一码）
        /// </summary>
        public string TBG_ID { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string GROUP_NAME { get; set; }
        /// <summary>
        /// 工序类型
        /// </summary>
        public string GROUP_TYPE { get; set; }
    }
}
