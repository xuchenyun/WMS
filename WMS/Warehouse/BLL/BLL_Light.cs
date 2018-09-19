using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.IO;

namespace Warehouse.BLL
{
   public class BLL_Light
    {
        //public static LightMsg HouseLight(List<HouseLight> House)
        //{
        //    LightMsg lightMsg = new LightMsg();
        //    try
        //    {
        //        string ip = ConfigurationManager.AppSettings["LightIP"].ToString();
        //        string port = ConfigurationManager.AppSettings["LightPort"].ToString(); ;
        //        string result = PostDataToUrl(string.Format("http://{0}:{1}/LightService.svc/HouseOrder", ip, port), JsonConvert.SerializeObject(House));
        //        lightMsg = JsonConvert.DeserializeObject<LightMsg>(result);
        //    }
        //    catch (Exception ee)
        //    {
        //        lightMsg.IsOK = false;
        //        lightMsg.Msg = ee.Message;
        //    }
        //    return lightMsg;
        //}
        public static string PostDataToUrl(string url, string jsonData)
        {
            string strResult = "";
            try
            {
                byte[] postBytes = Encoding.UTF8.GetBytes(jsonData);
                HttpWebRequest request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "text/json;charset=utf-8";
                //request.Timeout = 3000;
                request.ContentLength = postBytes.Length;
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(postBytes, 0, postBytes.Length);
                }
                using (WebResponse wr = request.GetResponse())
                {
                    //在这里对接收到的页面内容进行处理
                    Stream st = wr.GetResponseStream();
                    StreamReader streamReader = new StreamReader(st, Encoding.GetEncoding("utf-8"));
                    strResult = streamReader.ReadToEnd();
                }
            }
            catch (Exception ee)
            {
                strResult = ee.Message;
                return strResult;
            }
            return "OK";
        }
    }
}
