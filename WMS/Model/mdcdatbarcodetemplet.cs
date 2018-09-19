using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Mdcdatbarcodetemplet
    {
        /// <summary>
        /// Fguid
        /// </summary>
        public string FGuid { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Context { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime  Createtime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string Updator { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime  Updatetime { get; set; }
    }
}
