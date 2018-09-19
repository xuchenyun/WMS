using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class T_Bllb_PrintLog_tbpl
    {
        /// <summary>
        /// 制令单
        /// </summary>
        public string SFCNO { get; set; }
        /// <summary>
        /// 打印条码
        /// </summary>
        public string PRINT_SN { get; set; }
        /// <summary>
        /// 打印时间
        /// </summary>
        public DateTime PRINT_TIME { get; set; }
        /// <summary>
        /// 打印人
        /// </summary>
        public string PRINTER { get; set; }
    }
}
