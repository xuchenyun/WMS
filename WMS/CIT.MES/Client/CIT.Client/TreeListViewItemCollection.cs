using System;
using System.Collections;
using System.Windows.Forms;

namespace CIT.Client
{
	public class TreeListViewItemCollection : CollectionBase
	{
		private delegate void VoidHandlerSortOrder(SortOrder value);

		public class TreeListViewItemCollectionComparer : ITreeListViewItemComparer, IComparer
		{
			private SortOrder _SortOrder = SortOrder.Ascending;

			private int _Column;

			public SortOrder SortOrder
			{
				get
				{
					return _SortOrder;
				}
				set
				{
					_SortOrder = value;
				}
			}

			public int Column
			{
				get
				{
					return _Column;
				}
				set
				{
					_Column = value;
				}
			}

			public TreeListViewItemCollectionComparer()
				: this(SortOrder.Ascending, 0)
			{
			}

			public TreeListViewItemCollectionComparer(SortOrder order)
				: this(order, 0)
			{
				SortOrder = order;
			}

			public TreeListViewItemCollectionComparer(SortOrder order, int column)
			{
				SortOrder = order;
				_Column = column;
			}

			public int Compare(object x, object y)
			{
				TreeListViewItem treeListViewItem = (TreeListViewItem)x;
				TreeListViewItem treeListViewItem2 = (TreeListViewItem)y;
				int num = 1;
				if (Column < treeListViewItem.SubItems.Count && Column < treeListViewItem2.SubItems.Count)
				{
					num = string.CompareOrdinal(treeListViewItem.SubItems[Column].Text.ToUpper(), treeListViewItem2.SubItems[Column].Text.ToUpper());
				}
				switch (SortOrder)
				{
				case SortOrder.Ascending:
					return num;
				case SortOrder.Descending:
					return -num;
				default:
					return 1;
				}
			}
		}

		private bool _Sortable = true;

		private ITreeListViewItemComparer _Comparer = new TreeListViewItemCollectionComparer(SortOrder.Ascending);

		private TXTreeListView _Owner;

		private TreeListViewItem _Parent;

		public TreeListViewEventHandler ItemAdded;

		public TreeListViewEventHandler ItemRemoved;

		public bool Sortable
		{
			get
			{
				return _Sortable;
			}
			set
			{
				_Sortable = value;
			}
		}

		public SortOrder SortOrder
		{
			get
			{
				return Comparer.SortOrder;
			}
			set
			{
				Comparer.SortOrder = value;
				Sort(recursively: false);
			}
		}

		public ITreeListViewItemComparer Comparer
		{
			get
			{
				return _Comparer;
			}
			set
			{
				_Comparer = value;
			}
		}

		public SortOrder SortOrderRecursively
		{
			set
			{
				if (TreeListView != null && TreeListView.InvokeRequired)
				{
					TreeListView.Invoke(new VoidHandlerSortOrder(SetSortOrderRecursively), value);
				}
				else
				{
					SetSortOrderRecursively(value);
				}
			}
		}

		internal SortOrder SortOrderRecursivelyWithoutSort
		{
			set
			{
				if (TreeListView != null && TreeListView.InvokeRequired)
				{
					throw new Exception("Invoke Required");
				}
				Comparer.SortOrder = value;
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						TreeListViewItem treeListViewItem = (TreeListViewItem)enumerator.Current;
						treeListViewItem.Items.SortOrderRecursivelyWithoutSort = value;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
		}

		public TXTreeListView Owner => _Owner;

		public TreeListViewItem Parent => _Parent;

		private TXTreeListView TreeListView
		{
			get
			{
				if (Owner != null)
				{
					return Owner;
				}
				if (Parent != null)
				{
					return Parent.ListView;
				}
				return null;
			}
		}

		public virtual TreeListViewItem this[int index]
		{
			get
			{
				return (TreeListViewItem)base.List[index];
			}
		}

		public TreeListViewItemCollection(TXTreeListView owner)
		{
			_Owner = owner;
		}

		public TreeListViewItemCollection(TreeListViewItem parent)
		{
			_Parent = parent;
		}

		public TreeListViewItemCollection()
		{
		}

		protected virtual void OnItemAdded(TreeListViewEventArgs e)
		{
			if (ItemAdded != null)
			{
				ItemAdded(this, e);
			}
		}

		protected virtual void OnItemRemoved(TreeListViewEventArgs e)
		{
			if (ItemRemoved != null)
			{
				ItemRemoved(this, e);
			}
		}

		public TreeListViewItem[] ToArray()
		{
			if (TreeListView != null && TreeListView.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			int count = base.Count;
			TreeListViewItem[] array = new TreeListViewItem[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = this[i];
			}
			return array;
		}

		public void Sort(bool recursively)
		{
			if (TreeListView != null)
			{
				TreeListView.BeginUpdate();
			}
			SortInternal(recursively);
			if (TreeListView != null)
			{
				TreeListView.EndUpdate();
			}
		}

		internal void SortInternal(bool recursively)
		{
			if (TreeListView != null && TreeListView.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			if (_Sortable)
			{
				TreeListViewItem[] array = ToArray();
				ClearInternal();
				TreeListViewItem[] array2 = array;
				foreach (TreeListViewItem item in array2)
				{
					Add(item);
				}
			}
			if (recursively)
			{
				{
					IEnumerator enumerator = GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							TreeListViewItem item = (TreeListViewItem)enumerator.Current;
							item.Items.SortInternal(recursively: true);
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
		}

		public virtual bool Contains(TreeListViewItem item)
		{
			if (TreeListView != null && TreeListView.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			bool result = false;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					TreeListViewItem treeListViewItem = (TreeListViewItem)enumerator.Current;
					if (item == treeListViewItem)
					{
						result = true;
						break;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return result;
		}

		private bool ListViewContains(TreeListViewItem item)
		{
			if (TreeListView == null)
			{
				return false;
			}
			if (TreeListView.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			ListView treeListView = TreeListView;
			try
			{
				foreach (ListViewItem item2 in treeListView.Items)
				{
					if (item2 == item)
					{
						return true;
					}
				}
			}
			catch
			{
			}
			return false;
		}

		public virtual int Add(TreeListViewItem item)
		{
			if (TreeListView != null && TreeListView.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			if (TreeListView != null && item.ListView != null)
			{
				throw new Exception("The Item is already in a TreeListView");
			}
			int insertCollectionIndex = GetInsertCollectionIndex(item);
			if (insertCollectionIndex == -1)
			{
				return -1;
			}
			if (Parent != null)
			{
				item.SetParent(Parent);
			}
			item.Items.Comparer = Comparer;
			int insertTreeListViewIndex = GetInsertTreeListViewIndex(item, insertCollectionIndex);
			if (insertTreeListViewIndex > -1)
			{
				ListView treeListView = TreeListView;
				treeListView.Items.Insert(insertTreeListViewIndex, item);
				if (item.IsExpanded)
				{
					item.Expand();
				}
				item.SetIndentation();
			}
			if (insertCollectionIndex > -1)
			{
				base.List.Insert(insertCollectionIndex, item);
			}
			if (insertCollectionIndex > -1)
			{
				OnItemAdded(new TreeListViewEventArgs(item, TreeListViewAction.Unknown));
			}
			if (base.Count == 1 && TreeListView != null && Parent != null && Parent.Visible)
			{
				Parent.Redraw();
			}
			return insertCollectionIndex;
		}

		public virtual TreeListViewItem Add(string value, int imageIndex)
		{
			TreeListViewItem treeListViewItem = new TreeListViewItem(value, imageIndex);
			Add(treeListViewItem);
			return treeListViewItem;
		}

		public virtual TreeListViewItem Add(string value)
		{
			TreeListViewItem treeListViewItem = new TreeListViewItem(value);
			Add(treeListViewItem);
			return treeListViewItem;
		}

		public void AddRange(TreeListViewItemCollection collection)
		{
			if (TreeListView != null)
			{
				TreeListView.BeginUpdate();
			}
			AddRangeInternal(collection);
			if (TreeListView != null)
			{
				TreeListView.BeginUpdate();
			}
		}

		internal void AddRangeInternal(TreeListViewItemCollection collection)
		{
			foreach (TreeListViewItem item in collection)
			{
				Add(item);
			}
		}

		public new void Clear()
		{
			TXTreeListView treeListView = TreeListView;
			treeListView?.BeginUpdate();
			ClearInternal();
			treeListView?.EndUpdate();
		}

		internal void ClearInternal()
		{
			if (TreeListView != null && TreeListView.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			while (base.Count > 0)
			{
				RemoveAtInternal(0);
			}
		}

		public virtual void Remove(TreeListViewItem item)
		{
			TXTreeListView treeListView = TreeListView;
			treeListView?.BeginUpdate();
			RemoveInternal(item);
			treeListView?.EndUpdate();
		}

		internal void RemoveInternal(TreeListViewItem item)
		{
			if (TreeListView != null && TreeListView.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			int indexOf = GetIndexOf(item);
			if (indexOf != -1)
			{
				RemoveAtInternal(indexOf);
			}
		}

		public int GetIndexOf(TreeListViewItem item)
		{
			if (TreeListView != null && TreeListView.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			int result = -1;
			for (int i = 0; i < base.Count; i++)
			{
				if (this[i] == item)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		public new void RemoveAt(int index)
		{
			TXTreeListView treeListView = TreeListView;
			treeListView?.BeginUpdate();
			RemoveAtInternal(index);
			treeListView?.EndUpdate();
		}

		internal void RemoveAtInternal(int index)
		{
			if (TreeListView != null && TreeListView.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			TreeListViewItem treeListViewItem = this[index];
			if (this[index].Visible && TreeListView != null)
			{
				treeListViewItem.Hide();
			}
			base.List.RemoveAt(index);
			treeListViewItem.SetParent(null);
			if (base.Count == 0 && TreeListView != null && Parent != null)
			{
				Parent.Redraw();
			}
			if (base.Count > 0 && TreeListView != null && index == base.Count)
			{
				this[index - 1].Redraw();
			}
			OnItemRemoved(new TreeListViewEventArgs(treeListViewItem, TreeListViewAction.Unknown));
		}

		private int GetInsertTreeListViewIndex(TreeListViewItem item, int collectionindex)
		{
			if (TreeListView == null)
			{
				return -1;
			}
			if (TreeListView != null && TreeListView.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			if (Owner != null)
			{
				int num = 0;
				num++;
			}
			int result = -1;
			if (Owner != null && collectionindex != -1)
			{
				result = ((collectionindex != 0) ? (this[collectionindex - 1].LastChildIndexInListView + 1) : 0);
			}
			else if (Parent != null && collectionindex != -1)
			{
				result = ((Parent.Visible && Parent.IsExpanded) ? ((collectionindex == 0) ? (Parent.Index + 1) : (Parent.Items[collectionindex - 1].LastChildIndexInListView + 1)) : (-1));
			}
			return result;
		}

		private int GetInsertCollectionIndex(TreeListViewItem item)
		{
			if (TreeListView != null && TreeListView.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			int num = -1;
			if (!_Sortable)
			{
				num = base.Count;
			}
			else if (!Contains(item) && !ListViewContains(item))
			{
				if (SortOrder == SortOrder.None)
				{
					num = base.Count;
				}
				else
				{
					for (int i = 0; i < base.Count; i++)
					{
						int num2 = i;
						int num3 = Comparer.Compare(item, this[num2]);
						if (num3 <= 0)
						{
							num = num2;
							break;
						}
					}
					num = ((num == -1) ? base.Count : num);
				}
			}
			return num;
		}

		private void SetSortOrderRecursively(SortOrder value)
		{
			SortOrder = value;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					TreeListViewItem treeListViewItem = (TreeListViewItem)enumerator.Current;
					treeListViewItem.Items.SortOrderRecursively = value;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
	}
}
