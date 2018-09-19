using CIT.LUtils.Common;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Threading;

namespace CIT.LUtils
{
	public class Utils
	{
		public static string GetCPUSN()
		{
			try
			{
				string result = "";
				ManagementClass managementClass = new ManagementClass("Win32_Processor");
				ManagementObjectCollection instances = managementClass.GetInstances();
				using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = instances.GetEnumerator())
				{
					if (managementObjectEnumerator.MoveNext())
					{
						ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
						result = managementObject.Properties["ProcessorId"].Value.ToString();
					}
				}
				return result;
			}
			catch
			{
				return "";
			}
		}

		public static List<string> GetLocalMac()
		{
			List<string> list = new List<string>();
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			foreach (ManagementObject item in managementObjectCollection)
			{
				if (item["IPEnabled"].ToString() == "True")
				{
					list.Add(item["MacAddress"].ToString().ToUpper());
				}
			}
			return list;
		}

		public static List<string> GetCPUSNList()
		{
			try
			{
				List<string> list = new List<string>();
				ManagementClass managementClass = new ManagementClass("Win32_Processor");
				ManagementObjectCollection instances = managementClass.GetInstances();
				foreach (ManagementObject item in instances)
				{
					list.Add(item.Properties["ProcessorId"].Value.ToString());
				}
				return list;
			}
			catch
			{
				return null;
			}
		}

		public static string GetHardDiskSN()
		{
			try
			{
				ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
				return managementObject.Properties["VolumeSerialNumber"].Value.ToString();
			}
			catch
			{
				try
				{
					ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"d:\"");
					return managementObject.Properties["VolumeSerialNumber"].Value.ToString();
				}
				catch
				{
					return "";
				}
			}
		}

		public static void Check()
		{
			Thread thread = new Thread((ThreadStart)delegate
			{
				while (true)
				{
					bool flag = true;
					Thread.Sleep(5000);
					DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
					FileInfo[] files = directoryInfo.GetFiles();
					string text = "";
					FileInfo[] array = files;
					foreach (FileInfo fileInfo in array)
					{
						if (Path.GetExtension(fileInfo.FullName) == ".cer")
						{
							text = fileInfo.FullName;
							break;
						}
					}
					if (!File.Exists(text))
					{
						break;
					}
					LicObj licObj = CIT.LUtils.Common.Utils.DeserializeObject(text);
					Encry.LinceseInfo.Licobj = licObj;
					string companyID = licObj.CompanyID;
					DateTime dealLine = licObj.DealLine;
					TimeSpan timeSpan = dealLine - DateTime.Now;
					Encry.LinceseInfo.DeadMsg = "剩余天数:" + timeSpan.Days;
					Encry.LinceseInfo.DeadDay = timeSpan.Days;
					if (licObj.LicType == licType.Temp)
					{
						if (timeSpan.TotalDays > 0.0)
						{
							Encry.LinceseInfo.DeadLine = false;
						}
						else
						{
							Encry.LinceseInfo.DeadDay = 0;
							Encry.LinceseInfo.DeadLine = true;
						}
					}
					else
					{
						Encry.LinceseInfo.DeadLine = false;
					}
					if (licObj.CPUNO == null)
					{
						Encry.LinceseInfo.DeadMsg = "证书不正确,请联系供应商";
						Encry.LinceseInfo.DeadLine = true;
						return;
					}
					if (licObj.CPUNO.Count > 0)
					{
						if (!GetCPUSNList().Contains(licObj.CPUNO[0].ToUpper()))
						{
							Encry.LinceseInfo.DeadMsg = "证书不正确,请联系供应商";
							Encry.LinceseInfo.DeadLine = true;
						}
					}
					else
					{
						Encry.LinceseInfo.DeadMsg = "证书不正确,请联系供应商";
						Encry.LinceseInfo.DeadLine = true;
					}
					if (licObj.MACNO == null)
					{
						Encry.LinceseInfo.DeadMsg = "证书不正确,请联系供应商.";
						Encry.LinceseInfo.DeadLine = true;
					}
					else if (licObj.MACNO.Count > 0)
					{
						if (!GetLocalMac().Contains(licObj.MACNO[0].ToUpper()))
						{
							Encry.LinceseInfo.DeadMsg = "证书不正确,请联系供应商.";
							Encry.LinceseInfo.DeadLine = true;
						}
					}
					else
					{
						Encry.LinceseInfo.DeadMsg = "证书不正确,请联系供应商.";
						Encry.LinceseInfo.DeadLine = true;
					}
					WriteRegKey();
					Thread.Sleep(600000);
				}
				throw new Exception("尚未找到证书文件,注册证书后方可使用");
			});
			thread.IsBackground = true;
			thread.Start();
		}

		public static bool WriteRegKey()
		{
			RegistryKey registryKey = null;
			if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft").SubKeyCount <= 0)
			{
				Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft");
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft");
				registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", writable: true);
				registryKey.SetValue("CITSM", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				registryKey.Close();
			}
			else
			{
				registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", writable: true);
				string value = registryKey.GetValue("CITSM", DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss")).ToString();
				registryKey.Close();
				if (Convert.ToDateTime(value) >= DateTime.Now)
				{
					Encry.LinceseInfo.DeadMsg = "不可随意篡改服务器时间";
					Encry.LinceseInfo.DeadLine = true;
				}
				else
				{
					registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", writable: true);
					registryKey.SetValue("CITSM", DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss"));
					registryKey.Close();
				}
			}
			return true;
		}

		public static string ReadRegKey()
		{
			RegistryKey registryKey = null;
			if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft").SubKeyCount <= 0)
			{
				Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft");
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft");
			}
			registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", writable: true);
			string result = registryKey.GetValue("CITSM", DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss")).ToString();
			registryKey.Close();
			return result;
		}
	}
}
