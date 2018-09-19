using System.Windows.Forms;

namespace CIT.Client
{
	public class SelectedTreeListViewItemCollection : ListView.SelectedListViewItemCollection
	{
		public new TreeListViewItem this[int index]
		{
			get
			{
				return (TreeListViewItem)base[index];
			}
		}

		public SelectedTreeListViewItemCollection(TXTreeListView TreeListView)
			: base(TreeListView)
		{
		}

		public bool Contains(TreeListViewItem item)
		{
			return Contains((ListViewItem)item);
		}

		public int IndexOf(TreeListViewItem item)
		{
			return IndexOf((ListViewItem)item);
		}
	}
}
