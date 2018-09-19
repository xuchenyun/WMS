using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CIT.Utils.LocalAPI
{
	public class NetInfo
	{
		public static List<string> GetLocalIPv4List()
		{
			IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
			List<string> list = new List<string>();
			IPAddress[] array = hostAddresses;
			foreach (IPAddress iPAddress in array)
			{
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					list.Add(iPAddress.ToString());
				}
			}
			return list;
		}

		public static List<string> GetLocalIPv6List()
		{
			IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
			List<string> list = new List<string>();
			IPAddress[] array = hostAddresses;
			foreach (IPAddress iPAddress in array)
			{
				if (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)
				{
					list.Add(iPAddress.ToString());
				}
			}
			return list;
		}

		public static List<string> GetLocalMacList()
		{
			List<string> list = new List<string>();
			ProcessStartInfo processStartInfo = new ProcessStartInfo("ipconfig", "/all");
			processStartInfo.UseShellExecute = false;
			processStartInfo.RedirectStandardInput = true;
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.RedirectStandardError = true;
			processStartInfo.CreateNoWindow = true;
			Process process = Process.Start(processStartInfo);
			StreamReader standardOutput = process.StandardOutput;
			string text = standardOutput.ReadLine();
			while (!standardOutput.EndOfStream)
			{
				if (!string.IsNullOrEmpty(text))
				{
					text = text.Trim();
					if (text.StartsWith("Physical Address"))
					{
						list.Add(text);
					}
				}
				text = standardOutput.ReadLine();
			}
			process.WaitForExit();
			process.Close();
			standardOutput.Close();
			return list;
		}
	}
}
