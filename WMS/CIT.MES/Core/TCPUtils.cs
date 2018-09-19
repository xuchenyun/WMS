using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Management;


namespace CIT.MES.Core
{
    public class TCPUtils
    {
        /// <summary>
        /// 获取本地IP地址信息
        /// </summary>
        public static string GetAddressIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                    break;
                }
            }
            return AddressIP;
        }
        public static string GetMacAddress()
        {
            ManagementObjectSearcher nisc = new ManagementObjectSearcher("select * from Win32_NetworkAdapterConfiguration");
            foreach (ManagementObject nic in nisc.Get())
            {
                if (Convert.ToBoolean(nic["ipEnabled"]) == true)
                {
                    return nic["MACAddress"].ToString();
                }
            }
            return "";
        }
    }
}
