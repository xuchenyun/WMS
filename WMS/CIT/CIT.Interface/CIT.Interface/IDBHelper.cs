using System.ServiceModel;

namespace CIT.Interface
{
	[ServiceContract]
	[ServiceKnownType(typeof(UserContext))]
	public interface IDBHelper
	{
	}
}
