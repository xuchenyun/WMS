/*
  版权:  @Zach.zhong
  生成日期:2018/4/26   
  说明: T_Bllb_StorageDocMaterial_tsdm表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    public class T_Bllb_StorageDocMaterial_tsdm
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
        ///汇总数量
        /// </summary>
		public int QTY { get; set; }
        /// <summary>
        ///行号（采购单物料行号）
        /// </summary>
		public int RowNumber { get; set; }
        /// <summary>
        ///采购单物料项ID
        /// </summary>
		public string PO_DetailID { get; set; }
        /// <summary>
        /// 计划数量
        /// </summary>
        public int Plan_Qty { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string Ver { get; set; }
    }
}
