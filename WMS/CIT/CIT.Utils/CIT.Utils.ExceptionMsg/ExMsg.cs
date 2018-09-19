using System;
using System.Threading;

namespace CIT.Utils.ExceptionMsg
{
	public class ExMsg
	{
		public static void Msg(Exception ee)
		{
			Thread thread = new Thread((ThreadStart)delegate
			{
			});
			thread.IsBackground = true;
			thread.Start();
		}
	}
}
