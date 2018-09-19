/*
  版权:  @Zach.zhong
  生成日期:2018/4/26   
  说明: T_Bllb_StorageDocDetail_tbsdd表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    public class T_Bllb_StorageDocDetail_tbsdd
    {
        /// <summary>
        ///单据号
        /// </summary>
		public string S_Doc_NO { get; set; }
        /// <summary>
        ///料号
        /// </summary>
		public string MaterialCode { get; set; }
        /// <summary>
        ///物料数量/产品数量
        /// </summary>
		public int QTY { get; set; }
        /// <summary>
        ///操作时间
        /// </summary>
		public DateTime Create_Time { get; set; }
        /// <summary>
        ///员工号
        /// </summary>
		public string Creator { get; set; }
        /// <summary>
        ///容器SN
        /// </summary>
		public string SerialNumber { get; set; }
        /// <summary>
        ///物料退料标识（Y/N）
        /// </summary>
		public string Reback_Flag { get; set; }
        /// <summary>
        ///行号（采购单物料行号）
        /// </summary>
		public int RowNumber { get; set; }
        /// <summary>
        ///采购单物料项ID
        /// </summary>
		public string PO_DetailID { get; set; }
        /// <summary>
        /// Lot
        /// </summary>
        public string Lot_NO { get; set; }
    }
}
