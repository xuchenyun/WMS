using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class T_Bllb_MaterialReplace_tbmr //替代料关系表
    {
        public string MaterialCode { get; set; }
        public string MaterialReplace { get; set; }
        public string MaterialReplace1 { get; set; }
        public string MaterialReplace2 { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Updator { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
