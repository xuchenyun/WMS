/*
  版权:  @Zach.zhong
  生成日期:2018/4/26   
  说明: T_Bllb_PODetail_tbpd表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    public class T_Bllb_PODetail_tbpd
    {
        /// <summary>
        ///采购订单ID
        /// </summary>
		public string POID { get; set; }
        /// <summary>
        ///采购明细ID
        /// </summary>
		public string PO_DetailID { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string MaterialCode { get; set; }
        /// <summary>
        ///数量
        /// </summary>
		public int Quantity { get; set; }
        /// <summary>
        ///行号
        /// </summary>
		public string RowNumber { get; set; }

        public string PO { get; set; }
    }
}
