using System;

namespace CIT.Client
{
	[Serializable]
	public enum TreeListViewItemBoundsPortion
	{
		Entire = 0,
		Icon = 1,
		ItemOnly = 3,
		Label = 2,
		PlusMinus = 4
	}
}
