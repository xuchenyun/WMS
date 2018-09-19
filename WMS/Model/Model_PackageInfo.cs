using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Model_PackageInfo
    {
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SUPPLIER { get; set; }
        /// <summary>
        /// 工单
        /// </summary>
        public string PO { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string SUPPLIER_CODE { get; set; }
        /// <summary>
        /// 产品代码
        /// </summary>
        public string PRODUCTCODE { get; set; }
        /// <summary>
        /// 产品名称（型号规格）
        /// </summary>
        public string PRODUCTNAME { get; set; }
        /// <summary>
        /// 产品代码2
        /// </summary>
        public string P1 { get; set; }
        /// <summary>
        /// 箱条码（工单+日期+四位流水号）
        /// </summary>
        public string BOXID { get; set; }
        /// <summary>
        /// 生产日期：八位日期字符串
        /// </summary>
        public string BEGIN_DATE { get; set; }
        /// <summary>
        /// 到期日期：八位日期字符串
        /// </summary>
        public string END_DATE { get; set; }
        /// <summary>
        /// 到期日期2：八位日期字符串
        /// </summary>
        public string E1{ get; set; }
        /// <summary>
        /// 保质期（例如：12个月）
        /// </summary>
        public string ACTIVE_LENGTH { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string QTY { get; set; }
        #region old
        /// <summary>
        /// 零件编号
        /// </summary>
        public string PARTNUMBER { get; set; }
        /// <summary>
        /// 零件名称
        /// </summary>
        public string PARTNAME { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string PARTSPEC { get; set; }
        /// <summary>
        /// 收获方
        /// </summary>
        public string RECEIVER { get; set; }
        /// <summary>
        /// 批次号，yyyyMMdd
        /// </summary>
        public string LOTNO { get; set; }
        /// <summary>
        /// 二维码信息
        /// </summary>
        public string QRCODE { get; set; }
        #endregion
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
