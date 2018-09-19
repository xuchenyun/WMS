using System;
using System.Collections.Generic;

namespace CIT.LUtils.Common
{
	[Serializable]
	public class LicObj
	{
		public string SupplyID
		{
			get;
			set;
		}

		public licType LicType
		{
			get;
			set;
		}

		public DateTime DealLine
		{
			get;
			set;
		}

		public int UserCnt
		{
			get;
			set;
		}

		public useType UseType
		{
			get;
			set;
		}

		public string CompanyID
		{
			get;
			set;
		}

		public string CompanyName
		{
			get;
			set;
		}

		public List<string> CPUNO
		{
			get;
			set;
		}

		public List<string> MACNO
		{
			get;
			set;
		}

		public List<string> HDNO
		{
			get;
			set;
		}

		public List<string> FunList
		{
			get;
			set;
		}
	}
}
