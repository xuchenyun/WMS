using System.ComponentModel;

namespace CIT.LUtils.Common
{
	public enum useType
	{
		[Description("内部人员")]
		Insider,
		[Description("代理商")]
		Agent,
		[Description("最终用户")]
		EndUser
	}
}
