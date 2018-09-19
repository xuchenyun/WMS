using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class T_Bllb_SecondClass_tbsc
    {
        public string Type { get; set; }
        public string Class { get; set; }
        public string OrderNum { get; set; }
        public int TemperatureMaxTime { get; set; }
        public int TemperatureMinTime { get; set; }
        public int InHouseTime { get; set; }
        public int ExposeTime { get; set; }
        public string SplitTime { get; set; }
        public decimal RoastMaxTemperature { get; set; }
        public decimal RoastMinTemperature { get; set; }
        public int RoastTime { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Remark { get; set; }
        public string Condition { get; set; }
    }
}
