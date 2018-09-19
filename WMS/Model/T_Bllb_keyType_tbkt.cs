using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 关键件类型实体类
    /// </summary>
    public partial class T_Bllb_keyType_tbkt
    {
        /// <summary>
        /// 关键件类型ID（全球唯一码）
        /// </summary>
        public string TbktId { get; set; }
        /// <summary>
        /// 关键件类型名称
        /// </summary>
        public string KeyName { get; set; }
        /// <summary>
        /// 类型（0：产品，1：关键件，2：随机卡,3:批次）
        /// </summary>
        public string KeyType { get; set; }
      
    }
}
