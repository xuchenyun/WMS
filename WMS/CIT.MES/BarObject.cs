using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CIT.MES
{
    public class BarObject
    {
        public string CAT { get; set; }
        public string HUE { get; set; }
        public string REF { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string vision { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        public string partNo { get; set; }
        /// <summary>
        /// 制造商料号
        /// </summary>
        public string manufacturerTypeNo { get; set; }
        /// <summary>
        /// 订购代码
        /// </summary>
        public string orderNo { get; set; }
        /// <summary>
        /// 制造商编号
        /// </summary>
        public string supplierId { get; set; }
        /// <summary>
        /// 制造商位置
        /// </summary>
        public string supplierLoc { get; set; }
        /// <summary>
        /// 修订版本/索引号
        /// </summary>
        public string index { get; set; }
        /// <summary>
        /// 补充的零部件信息
        /// </summary>
        public string addInfo { get; set; }
        /// <summary>
        /// 制造日期
        /// </summary>
        public string makeDate { get; set; }
        /// <summary>
        /// 过期日期
        /// </summary>
        public string expDate { get; set; }
        /// <summary>
        /// 环保标志
        /// </summary>
        public string roHs { get; set; }
        /// <summary>
        /// 湿度敏感等级
        /// </summary>
        public string msLevel { get; set; }
        /// <summary>
        /// 采购订单号
        /// </summary>
        public string purchaseNo { get; set; }
        /// <summary>
        /// 托运单
        /// </summary>
        public string shippingNote { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string supplNo { get; set; }
        /// <summary>
        /// 包装标识号
        /// </summary>
        public string packageId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal quantity { get; set; }
        /// <summary>
        /// 批量计数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 批次1
        /// </summary>
        public string batch1 { get; set; }
        /// <summary>
        /// 批次2
        /// </summary>
        public string batch2 { get; set; }
        /// <summary>
        /// 供应商数据
        /// </summary>
        public string supplierData { get; set; }

        public string reelId { get; set; }

        public string GUID { get; set; }

        public string ExpirationDate { get; set; }

        #region 重庆宇隆
        /// <summary>
        /// 要打印的条码
        /// </summary>
        public string BarCode { get; set; } 
        /// <summary>
        /// 单盘数量
        /// </summary>
        public int SingleNumber { get; set; }
        #endregion

        #region 福州宇隆光电包装外箱条码属性
        /// <summary>
        /// 物料描述
        /// </summary>
        public string MaterialDescription { get; set; }
        /// <summary>
        /// 保质期
        /// </summary>
        public string ShelfLife { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string SupplierCode { get; set; }
        /// <summary>
        /// 外箱SN
        /// </summary>
        public string Box { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public string ProductionTime { get; set; }
        /// <summary>
        /// 到期日期
        /// </summary>
        public string ExpirationTime { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 二维码条码
        /// </summary>
        public string QRcode { get; set; }
        #endregion

        public bool PrintOwn(string printTemplateName)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (System.Reflection.PropertyInfo p in this.GetType().GetProperties())
            {
                if ( p.GetValue(this, null)!=null)
                {
                    dic.Add(p.Name, p.GetValue(this, null).ToString()); 
                }
            }
            return CIT.MES.IO.InOutPut.PrintTemplet(printTemplateName, dic);
        }
    }

    public class UAESBarcodeHead
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public const string Vision = "12S";
        /// <summary>
        /// 客户零部件编号
        /// </summary>
        public const string PartNo = "P";
        /// <summary>
        /// 制造商零部件编号
        /// </summary>
        public const string ManufacturerTypeNo = "1P";
        /// <summary>
        /// 订购代码
        /// </summary>
        public const string OrderNo = "31P";
        /// <summary>
        /// 制造商编号
        /// </summary>
        public const string SupplierId = "12V";
        /// <summary>
        /// 制造商位置
        /// </summary>
        public const string SupplierLoc = "10V";
        /// <summary>
        /// 修订版本/索引号
        /// </summary>
        public const string Index = "2P";
        /// <summary>
        /// 补充的零部件信息
        /// </summary>
        public const string AddInfo = "20P";
        /// <summary>
        /// 制造日期
        /// </summary>
        public const string MakeDate = "6D";
        /// <summary>
        /// 过期日期
        /// </summary>
        public const string ExpDate = "14D";
        /// <summary>
        /// 环保标志
        /// </summary>
        public const string RoHs = "30P";
        /// <summary>
        /// 湿度敏感等级 默认为N
        /// </summary>
        public const string MsLevel = "Z";
        /// <summary>
        /// 采购订单编号
        /// </summary>
        public const string PurchaseNo = "K";
        /// <summary>
        /// 托运单
        /// </summary>
        public const string ShippingNote = "16K";
        /// <summary>
        /// 供应商编号
        /// </summary>
        public const string SupplNo = "V";
        /// <summary>
        /// 包装标示
        /// </summary>
        public const string PackageId = "3S";
        /// <summary>
        /// 数量
        /// </summary>
        public const string Quantity = "Q";
        /// <summary>
        /// 批量计算
        /// </summary>
        public const string Count = "20T";
        /// <summary>
        /// 批量编号 #1
        /// </summary>
        public const string Batch1 = "1T";
        /// <summary>
        /// 批量编号 #2
        /// </summary>
        public const string Batch2 = "2T";
        /// <summary>
        /// 供应商数据
        /// </summary>
        public const string SupplierData = "1Z";

    }

    public class BarUtils
    {
        bool RegBarHead(string head, string barcode)
        {
            Regex reg = new Regex("^" + head);
            var mat = reg.Match(barcode);
            return mat.Success;
        }

        /// <summary>
        /// 二维码解析
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public BarObject MatchBarcode_UAES(string barcode)
        {

            BarObject obj = new BarObject();
            string[] listbar = barcode.Split('@');
            foreach (string item in listbar)
            {
                /// <summary>
                /// 标签版本
                /// </summary>
                if (RegBarHead(UAESBarcodeHead.Vision, item))
                {
                    obj.vision = item.Remove(0, UAESBarcodeHead.Vision.Length);
                }
                /// <summary>
                /// 客户零部件编号
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.PartNo, item))
                {
                    obj.partNo = item.Remove(0, UAESBarcodeHead.PartNo.Length);
                    obj.partNo = obj.partNo.Substring(0, 10);
                }
                /// <summary>
                /// 制造商零部件编号
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.ManufacturerTypeNo, item))
                {
                    obj.manufacturerTypeNo = item.Remove(0, UAESBarcodeHead.ManufacturerTypeNo.Length);
                }
                /// <summary>
                /// 订购代码
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.OrderNo, item))
                {
                    obj.orderNo = item.Remove(0, UAESBarcodeHead.OrderNo.Length);
                }
                /// <summary>
                /// 制造商编号
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.SupplierId, item))
                {
                    obj.supplierId = item.Remove(0, UAESBarcodeHead.SupplierId.Length);
                }
                /// <summary>
                /// 制造商位置
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.SupplierLoc, item))
                {
                    obj.supplierLoc = item.Remove(0, UAESBarcodeHead.SupplierLoc.Length);
                }
                /// <summary>
                /// 修订版本/索引号
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.Index, item))
                {
                    obj.index = item.Remove(0, UAESBarcodeHead.Index.Length);
                }

                /// <summary>
                /// 补充的零部件信息
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.AddInfo, item))
                {
                    obj.addInfo = item.Remove(0, UAESBarcodeHead.AddInfo.Length);
                }
                /// <summary>
                /// 制造日期
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.MakeDate, item))
                {
                    obj.makeDate = item.Remove(0, UAESBarcodeHead.MakeDate.Length);
                }
                /// <summary>
                /// 过期日期
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.ExpDate, item))
                {
                    obj.expDate = item.Remove(0, UAESBarcodeHead.ExpDate.Length);
                }
                /// <summary>
                /// 环保标志
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.RoHs, item))
                {
                    obj.roHs = item.Remove(0, UAESBarcodeHead.RoHs.Length);
                }
                /// <summary>
                /// 湿度敏感等级 默认为N
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.MsLevel, item))
                {
                    string mslevel = item.Remove(0, UAESBarcodeHead.MsLevel.Length).Trim();
                    obj.msLevel = string.IsNullOrEmpty(mslevel) ? "N" : mslevel;
                }
                /// <summary>
                /// 采购订单编号
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.PurchaseNo, item))
                {
                    obj.purchaseNo = item.Remove(0, UAESBarcodeHead.PurchaseNo.Length);
                }
                /// <summary>
                /// 托运单
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.ShippingNote, item))
                {
                    obj.shippingNote = item.Remove(0, UAESBarcodeHead.ShippingNote.Length);
                }
                /// <summary>
                /// 供应商编号
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.SupplNo, item))
                {
                    string temp = item.Remove(0, UAESBarcodeHead.SupplNo.Length);
                    if (temp.Length == 0)
                    {
                        temp = "000000";
                    }
                    obj.supplNo = temp;
                }
                /// <summary>
                /// 包装标示
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.PackageId, item))
                {
                    obj.packageId = item.Remove(0, UAESBarcodeHead.PackageId.Length);
                }
                /// <summary>
                /// 数量
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.Quantity, item))
                {
                    string qty = item.Remove(0, UAESBarcodeHead.Quantity.Length).Trim();
                    qty = string.IsNullOrEmpty(qty) ? "0" : qty.Replace("NAR", "@").Split('@')[0];
                    obj.quantity = int.Parse(qty);
                }
                /// <summary>
                /// 批量计数
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.Count, item))
                {
                    obj.count = int.Parse(item.Remove(0, UAESBarcodeHead.Count.Length));
                }
                /// <summary>
                /// 批量编号 #1
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.Batch1, item))
                {
                    obj.batch1 = item.Remove(0, UAESBarcodeHead.Batch1.Length);
                }
                /// <summary>
                /// 批量编号 #2
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.Batch2, item))
                {
                    obj.batch2 = item.Remove(0, UAESBarcodeHead.Batch2.Length);
                }
                /// <summary>
                /// 供应商数据
                /// </summary>
                else if (RegBarHead(UAESBarcodeHead.SupplierData, item))
                {
                    obj.supplierData = item.Remove(0, UAESBarcodeHead.SupplierData.Length);
                }
            }
            return obj;
        }

    }
}
