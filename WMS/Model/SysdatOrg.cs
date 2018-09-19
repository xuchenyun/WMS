using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public  class SysdatOrg
    {
        /// <summary>
        /// 节点ID
        /// </summary>
        public int  ID { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// url
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 父节点ID
        /// </summary>
        public int ParentID { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
    }
}
