using System;

namespace CIT.Interface
{
	[Serializable]
	public class ProSQLFile
	{
		public string UserID
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public string SqlCmd
		{
			get;
			set;
		}

		public DateTime Createtime
		{
			get;
			set;
		}
	}
}
