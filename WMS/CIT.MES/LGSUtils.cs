using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Data;
using System.Data.SqlClient;
using CIT.Wcf.Utils;

namespace CIT.MES
{
    public class SendInfoPanacim
    {
        public static void SendDataToPancim(string line, string reelid, string partNumber, string supplNo, string batch, int qty)
        {
            string DBName, Ip, Users, Password = null;
            DataTable dt_sysdatline_UAES = NMS.QueryDataTable(PubUtils.uContext, @"SELECT * FROM SysDatConfig WHERE key1='" + line + "'");
            if (dt_sysdatline_UAES == null || dt_sysdatline_UAES.Rows.Count == 0)
            {
                CIT.Client.MsgBox.Error("在Line:" + line + "未维护Pancim信息,不能发料");
                return;
            }
            DBName = dt_sysdatline_UAES.Rows[0]["val4"].ToString();
            Ip = dt_sysdatline_UAES.Rows[0]["val1"].ToString();
            Users = dt_sysdatline_UAES.Rows[0]["val2"].ToString();
            Password = dt_sysdatline_UAES.Rows[0]["val3"].ToString();
            if (EXECSP(DBName, Ip, Users, Password, reelid, partNumber, supplNo, batch, qty))
            {

            }
            else
            {
                //执行失败，界面提示
                CIT.Client.MsgBox.Error("写入Panacim数据时失败");
                return;
            }

        }
        static bool EXECSP(string DBName, string Ip, string Users, string Password, string reelid, string partNumber, string supplNo, string batch, int qty)
        {
            string connstr = @"Server=" + Ip + ";database=" + DBName + ";User ID=" + Users + ";Password=" + Password + "";
            using (SqlConnection sqlconn = new SqlConnection(connstr))
            {
                sqlconn.Open();
                //判断物料是否存在
                string cmd = "select count(*) from reel_data where reel_barcode='" + reelid + "'";
                using (SqlDataAdapter sqldata = new SqlDataAdapter(cmd, sqlconn))
                {
                    DataTable dt = new DataTable();
                    sqldata.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "0")
                    {
                        //执行存储过程
                        //reelid partno supplNo batch qty
                        cmd = "exec usp_panacim_transfer_reel_data '" + reelid + "','" + partNumber + "','" + supplNo + "','" + batch + "','" + PubUtils.uContext.UserName + "','" + qty + "','','','','',''";
                        using (SqlCommand sqlcmd = new SqlCommand(cmd, sqlconn))
                        {
                            sqlcmd.ExecuteNonQuery();
                            cmd = "select count(*) from reel_data where reel_barcode='" + reelid + "'";
                            dt.Clear();
                            using (SqlDataAdapter _sqldata = new SqlDataAdapter(cmd, sqlconn))
                            {
                                _sqldata.Fill(dt);
                                if (dt.Rows[0][0].ToString() == "0")
                                {
                                    //注册到panacim失败
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        string exce = " delete from reel_data where reel_barcode='" + reelid + "'";
                        exce += "exec usp_panacim_transfer_reel_data '" + reelid + "','" + partNumber + "','" + supplNo + "','" + batch + "','" + PubUtils.uContext.UserID + "','" + qty + "','','','','',''";
                        using (SqlCommand sqlcmd = new SqlCommand(exce, sqlconn))
                        {
                            sqlcmd.ExecuteNonQuery();
                            cmd = "select count(*) from reel_data where reel_barcode='" + reelid + "'";
                            dt.Clear();
                            using (SqlDataAdapter _sqldata = new SqlDataAdapter(cmd, sqlconn))
                            {
                                _sqldata.Fill(dt);
                                if (dt.Rows[0][0].ToString() != "1")
                                {
                                    //注册到panacim失败
                                    return false;
                                }
                            }

                        }
                        //存在不执行任何操做
                    }
                    return true;
                }
            }
        }
    }
    //多灯
    public class LGS
    {
        public int ContinuedTime { get; set; }
        public string MainBoardId { get; set; }
        public string RackPositionId { get; set; }
        public int lightOrder { get; set; }
    }
    public class LGSReturnCode
    {
        public string IsOK { get; set; }
        public string Msg { get; set; }
    }
    //全亮全灭
    public class AllLight
    {
        //主板
        public string MainBoardId { get; set; }
        //灯开关
        public string lightOrder { get; set; }
    }
    //灯塔
    public class LightHouse
    {
        public string HouseLightSide { get; set; }
        public string MainBoardId { get; set; }
        public string lightOrder { get; set; }
    }
    public class HttpHelper
    {
        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        public static string CreatePostHttpResponse(string url, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "text/json;charset=utf-8";
            request.ContentLength = Encoding.UTF8.GetByteCount(data);
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream);
            myStreamWriter.Write(data);
            myStreamWriter.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        /// <summary>
        /// 获取请求的数据
        /// </summary>
        public static string GetResponseString(HttpWebResponse webresponse)
        {
            using (Stream s = webresponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                return reader.ReadToEnd();

            }
        }

        /// <summary>
        /// 验证证书
        /// </summary>
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if (errors == SslPolicyErrors.None)
                return true;
            return false;
        }

        public static string Obj2Json<T>(List<T> data)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, data);
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch
            {
                return null;
            }
        }
        public static Object Json2Obj(String json, Type t)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(t);
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {

                    return serializer.ReadObject(ms);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
