using System.Collections;
using System.Windows.Forms;

namespace CIT.Client
{
	public interface ITreeListViewItemComparer : IComparer
	{
		SortOrder SortOrder
		{
			get;
			set;
		}

		int Column
		{
			get;
			set;
		}
	}
}
