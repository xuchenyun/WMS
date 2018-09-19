using System.Runtime.Serialization;

namespace CIT.Interface
{
	[DataContract]
	public struct CmdParameter
	{
		[DataMember]
		public string ParameterName;

		[DataMember]
		public object Value;
	}
}
