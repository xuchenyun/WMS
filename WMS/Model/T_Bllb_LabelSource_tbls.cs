using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class T_Bllb_LabelSource_tbls
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        public string LabelName { get; set; }
        /// <summary>
        /// 标签数据源
        /// </summary>
        public string LabelSQL { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public string Updator { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
