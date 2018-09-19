using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace CIT.Client
{
	internal class IniConfig
	{
		private string _FilePath;

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

		public IniConfig(string filePath)
		{
			_FilePath = filePath;
		}

		public void IniWriteValue(string Section, string Key, string Value)
		{
			if (!ExistINIFile())
			{
				throw new Exception("指定的配置文件读写错误！");
			}
			WritePrivateProfileString(Section, Key, Value, _FilePath);
		}

		public string IniReadValue(string Section, string Key, string sdef)
		{
			if (!ExistINIFile())
			{
				throw new Exception("指定的配置文件读写错误！");
			}
			StringBuilder stringBuilder = new StringBuilder(500);
			int privateProfileString = GetPrivateProfileString(Section, Key, sdef, stringBuilder, 500, _FilePath);
			return stringBuilder.ToString().Trim().Replace(",", string.Empty);
		}

		public bool ExistINIFile()
		{
			return File.Exists(_FilePath);
		}
	}
}
