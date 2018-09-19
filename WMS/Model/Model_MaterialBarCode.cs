using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Model_MaterialBarCode
    {
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SUPPLIER { get; set; }
        /// <summary>
        /// 采购单
        /// </summary>
        public string PO { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string SUPPLIER_CODE { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string MaterialDesc { get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        public string RowNumber { get; set; }
        /// <summary>
        /// 唯一码
        /// </summary>
        public string SN { get; set; }
        /// <summary>
        /// 生产日期：八位日期字符串
        /// </summary>
        public string BEGIN_DATE { get; set; }
        /// <summary>
        /// 到期日期：八位日期字符串
        /// </summary>
        public string END_DATE { get; set; }

        /// <summary>
        /// 保质期（例如：12个月）
        /// </summary>
        public string ACTIVE_LENGTH { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string QTY { get; set; }
        /// <summary>
        /// 批次号，yyyyMMdd
        /// </summary>
        public string LOTNO { get; set; }
        /// <summary>
        /// 二维码信息
        /// </summary>
        public string QRCODE { get; set; }
        /// <summary>
        /// 供应商料号
        /// </summary>
        public string MPN { get; set; }
        /// <summary>
        /// 制令单
        /// </summary>
        public string SfcNo { get; set; }
        /// <summary>
        /// 产品暗码
        /// </summary>
        public string ProductSN { get; set; }
        /// <summary>
        /// 产品明码1
        /// </summary>
        public string print1 { get; set; }
        /// <summary>
        /// 产品明码2
        /// </summary>
        public string print2 { get; set; }
        /// <summary>
        /// 产品明码3
        /// </summary>
        public string print3 { get; set; }
        /// <summary>
        /// 产品明码4
        /// </summary>
        public string print4 { get; set; }
        /// <summary>
        /// 产品明码5
        /// </summary>
        public string print5 { get; set; }
        /// <summary>
        /// 产品标签
        /// </summary>
        public string ProductLabel { get; set; }

        public bool PrintOwn(string printTemplateName)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (System.Reflection.PropertyInfo p in this.GetType().GetProperties())
            {
                if (p.GetValue(this, null) != null)
                {
                    dic.Add(p.Name, p.GetValue(this, null).ToString());
                }
            }
            return CIT.MES.IO.InOutPut.PrintTemplet(printTemplateName, dic);
        }
    }
}
