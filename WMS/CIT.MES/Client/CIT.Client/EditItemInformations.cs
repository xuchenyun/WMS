using System;

namespace CIT.Client
{
	public struct EditItemInformations
	{
		private string _label;

		private TreeListViewItem _item;

		private int _colindex;

		internal DateTime CreationTime;

		public string Label => _label;

		public TreeListViewItem Item => _item;

		public int ColumnIndex => _colindex;

		public EditItemInformations(TreeListViewItem item, int column, string label)
		{
			_item = item;
			_colindex = column;
			_label = label;
			CreationTime = DateTime.Now;
		}
	}
}
