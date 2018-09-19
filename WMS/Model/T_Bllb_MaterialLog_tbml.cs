using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class T_Bllb_MaterialLog_tbml
    {
        /// <summary>
        /// 物料SN
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 操作名称
        /// </summary>
        public string OperateType { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string QTY { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
    }
}
