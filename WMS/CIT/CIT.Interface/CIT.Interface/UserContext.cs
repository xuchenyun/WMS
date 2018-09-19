using System;
using System.Data;

namespace CIT.Interface
{
	[Serializable]
	public class UserContext
	{
		public string Account
		{
			get;
			set;
		}

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

		public string Password
		{
			get;
			set;
		}

		public DateTime Createtime
		{
			get;
			set;
		}

		public DataTable UserList
		{
			get;
			set;
		}

		public string Guid
		{
			get;
			set;
		}

		public string LoginIPAddress
		{
			get;
			set;
		}

		public string LoginMacAddress
		{
			get;
			set;
		}

		public string MachineName
		{
			get;
			set;
		}

		public string CompanyCode
		{
			get;
			set;
		}

		public string CompanyName
		{
			get;
			set;
		}
	}
}
