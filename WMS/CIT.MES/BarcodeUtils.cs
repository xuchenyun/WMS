using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace CIT.MES
{
    public class BarcodeUtils
    {
        public BarObject AnalysisBarcode(string Url, string barcode)
        {
            if (Url == "0.0.0.0")
            {
                BarObject obj = new BarObject();
                obj.reelId = barcode;
                return obj;
            }
            barcode = HttpPost(Url + barcode, "");

            //barcode = barcode.Replace("\\", "");
            //barcode = barcode.Remove(0, 1);
            //barcode = barcode.Remove(barcode.Length - 1, 1);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<BarObject>(barcode);
        }
        private string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            //request.CookieContainer = cookie;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //response.Cookies = cookie.GetCookies(response.ResponseUri);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        public string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

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
        }

    }
}
