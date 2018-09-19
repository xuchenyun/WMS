using System;

namespace CIT.Client
{
	[Serializable]
	public class TreeListViewEventArgs : EventArgs
	{
		private TreeListViewItem _Item;

		private TreeListViewAction _Action;

		public TreeListViewItem Item => _Item;

		public TreeListViewAction Action => _Action;

		public TreeListViewEventArgs(TreeListViewItem item, TreeListViewAction action)
		{
			_Item = item;
			_Action = action;
		}
	}
}
