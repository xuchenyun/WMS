using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class T_Bllb_TempletSource_tbts
    {
        //标签模版名称
        /// <summary>
        /// 标签模版名称
        /// </summary>
        public string TempletName { get; set; }
        /// <summary>
        /// SQL语句
        /// </summary>
        public string Sql_Text { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Createtime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public string Updator { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime Updatetime { get; set; }
    }
}
