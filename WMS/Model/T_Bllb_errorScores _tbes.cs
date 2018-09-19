using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 不良标准分数表实体类
    /// </summary>
    public partial class T_Bllb_errorScores_tbes
    {
        /// <summary>
        /// 不良标准分数ID
        /// </summary>
        public string TbesId { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string TbesName { get; set; }
        /// <summary>
        /// 轻微缺陷5分，一般缺陷10分，严重缺陷50分，致命缺陷100分
        /// </summary>
        public int TbesScores { get; set; }
    }
}
