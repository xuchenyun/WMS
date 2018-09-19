using System;
using System.ComponentModel;

namespace CIT.Client
{
	[Serializable]
	public class TreeListViewLabelEditEventArgs : CancelEventArgs
	{
		private TreeListViewItem _Item;

		internal int _columnIndex;

		private string _Label;

		public string Label => _Label;

		public TreeListViewItem Item => _Item;

		public int ColumnIndex => _columnIndex;

		public TreeListViewLabelEditEventArgs(TreeListViewItem item, int column, string label)
		{
			_Item = item;
			_columnIndex = column;
			_Label = label;
		}
	}
}
