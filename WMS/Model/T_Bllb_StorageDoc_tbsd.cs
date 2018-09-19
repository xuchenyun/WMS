/*
  版权:  @Zach.zhong
  生成日期:2018/4/26   
  说明: T_Bllb_StorageDoc_tbsd表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    public class T_Bllb_StorageDoc_tbsd
    {
        /// <summary>
        ///单据号
        /// </summary>
		public string S_Doc_NO { get; set; }
        /// <summary>
        ///1:入库单；2:发料单；3:退料单
        /// </summary>
		public string S_Doc_Type { get; set; }
        /// <summary>
        ///创建时间
        /// </summary>
		public DateTime Create_Time { get; set; }
        /// <summary>
        ///员工号
        /// </summary>
		public string Creator { get; set; }
        /// <summary>
        ///备注
        /// </summary>
		public string Memo { get; set; }
        /// <summary>
        ///线别代码
        /// </summary>
		public string PLCode { get; set; }
        /// <summary>
        ///批次号（料号+日期）
        /// </summary>
		public string LotNo { get; set; }
        /// <summary>
        ///退料结束（Y/N）
        /// </summary>
		public string Reback_Over { get; set; }
        /// <summary>
        ///采购单号
        /// </summary>
		public string PO { get; set; }
        /// <summary>
        ///采购单ID
        /// </summary>
		public string POID { get; set; }
        /// <summary>
        ///ERP回传的到货单
        /// </summary>
		public string Arrival_NO { get; set; }
        /// <summary>
        ///ERP回传的到货单ID
        /// </summary>
		public string Arrival_ID { get; set; }
        /// <summary>
        /// 原仓库
        /// </summary>
        public string Source_Storage { get; set; }
        /// <summary>
        /// 目的仓库
        /// </summary>
        public string Target_Storage { get; set; }
        /// <summary>
        /// 上游单据
        /// </summary>
        public string Before_Doc_NO { get; set; }
        /// <summary>
        /// 工单号
        /// </summary>
        public string WoCode { get; set; }
        /// <summary>
        /// 制令单
        /// </summary>
        public string SfcNo { get; set; }
    }
}
