using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CIT.Client.Docking
{
	public class DockContentCollection : ReadOnlyCollection<IDockContent>
	{
		private static List<IDockContent> _emptyList = new List<IDockContent>(0);

		private DockPane m_dockPane = null;

		private DockPane DockPane => m_dockPane;

		public new IDockContent this[int index]
		{
			get
			{
				if (DockPane == null)
				{
					return base.Items[index];
				}
				return GetVisibleContent(index);
			}
		}

		public new int Count
		{
			get
			{
				if (DockPane == null)
				{
					return base.Count;
				}
				return CountOfVisibleContents;
			}
		}

		private int CountOfVisibleContents
		{
			get
			{
				if (DockPane == null)
				{
					throw new InvalidOperationException();
				}
				int num = 0;
				foreach (IDockContent content in DockPane.Contents)
				{
					if (content.DockHandler.DockState == DockPane.DockState)
					{
						num++;
					}
				}
				return num;
			}
		}

		internal DockContentCollection()
			: base((IList<IDockContent>)new List<IDockContent>())
		{
		}

		internal DockContentCollection(DockPane pane)
			: base((IList<IDockContent>)_emptyList)
		{
			m_dockPane = pane;
		}

		internal int Add(IDockContent content)
		{
			if (DockPane != null)
			{
				throw new InvalidOperationException();
			}
			if (Contains(content))
			{
				return IndexOf(content);
			}
			base.Items.Add(content);
			return Count - 1;
		}

		internal void AddAt(IDockContent content, int index)
		{
			if (DockPane != null)
			{
				throw new InvalidOperationException();
			}
			if (index >= 0 && index <= base.Items.Count - 1 && !Contains(content))
			{
				base.Items.Insert(index, content);
			}
		}

		public new bool Contains(IDockContent content)
		{
			if (DockPane == null)
			{
				return base.Items.Contains(content);
			}
			return GetIndexOfVisibleContents(content) != -1;
		}

		public new int IndexOf(IDockContent content)
		{
			if (DockPane == null)
			{
				if (!Contains(content))
				{
					return -1;
				}
				return base.Items.IndexOf(content);
			}
			return GetIndexOfVisibleContents(content);
		}

		internal void Remove(IDockContent content)
		{
			if (DockPane != null)
			{
				throw new InvalidOperationException();
			}
			if (Contains(content))
			{
				base.Items.Remove(content);
			}
		}

		private IDockContent GetVisibleContent(int index)
		{
			if (DockPane == null)
			{
				throw new InvalidOperationException();
			}
			int num = -1;
			foreach (IDockContent content in DockPane.Contents)
			{
				if (content.DockHandler.DockState == DockPane.DockState)
				{
					num++;
				}
				if (num == index)
				{
					return content;
				}
			}
			throw new ArgumentOutOfRangeException();
		}

		private int GetIndexOfVisibleContents(IDockContent content)
		{
			if (DockPane == null)
			{
				throw new InvalidOperationException();
			}
			if (content == null)
			{
				return -1;
			}
			int num = -1;
			foreach (IDockContent content2 in DockPane.Contents)
			{
				if (content2.DockHandler.DockState == DockPane.DockState)
				{
					num++;
					if (content2 == content)
					{
						return num;
					}
				}
			}
			return -1;
		}
	}
}
