using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HouseLight
    {
        //主板
        public int MainBoardId { get; set; }
        //灯塔边
        public int HouseLightSide { get; set; }
        //灯开关
        public int lightOrder { get; set; }
    }
}
