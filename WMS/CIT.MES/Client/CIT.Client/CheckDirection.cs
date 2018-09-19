using System;

namespace CIT.Client
{
	[Serializable]
	[Flags]
	internal enum CheckDirection
	{
		None = 0x0,
		Upwards = 0x1,
		Downwards = 0x2,
		All = 0x3
	}
}
