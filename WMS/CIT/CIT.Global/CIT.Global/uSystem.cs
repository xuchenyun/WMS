using System.Collections.Generic;
using System.ComponentModel;

namespace CIT.Global
{
	public class uSystem
	{
		public static string UserGUID
		{
			get;
			set;
		}

		public static string UserID
		{
			get;
			set;
		}

		public static string UserName
		{
			get;
			set;
		}

		[Description("本地IP地址")]
		public static string LocalIPAddress
		{
			get;
			set;
		}

		public static int LocalPort
		{
			get;
			set;
		}

		public static Dictionary<string, string> AccountList
		{
			get;
			set;
		}

		public static string HostIPAddress
		{
			get;
			set;
		}

		public static int HostPort
		{
			get;
			set;
		}

		public static List<string> ToUserList
		{
			get;
			set;
		}

		public static List<string> CCUserList
		{
			get;
			set;
		}

		public static bool IsLog
		{
			get;
			set;
		}

		public static bool IsMail
		{
			get;
			set;
		}

		public static string Enc_DecKey
		{
			get;
			set;
		}
	}
}
