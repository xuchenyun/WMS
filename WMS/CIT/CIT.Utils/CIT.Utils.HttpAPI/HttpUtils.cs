using System.IO;
using System.Net;
using System.Text;

namespace CIT.Utils.HttpAPI
{
	public class HttpUtils
	{
		public static string HttpGet(string Url, string postDataStr)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url + postDataStr);
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			Stream responseStream = httpWebResponse.GetResponseStream();
			StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			responseStream.Close();
			return result;
		}

		public static string HttpPost(string Url, string postDataStr)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
			httpWebRequest.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
			Stream requestStream = httpWebRequest.GetRequestStream();
			StreamWriter streamWriter = new StreamWriter(requestStream, Encoding.GetEncoding("gb2312"));
			streamWriter.Write(postDataStr);
			streamWriter.Close();
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			Stream responseStream = httpWebResponse.GetResponseStream();
			StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			responseStream.Close();
			return result;
		}
	}
}
