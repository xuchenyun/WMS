using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
     public class ComputeHelper
    {
        public static object Compute(string expression)
        {
            DataTable dt = new DataTable();
            object obj=  dt.Compute(expression, "");
            return obj;
        }
    }
}
