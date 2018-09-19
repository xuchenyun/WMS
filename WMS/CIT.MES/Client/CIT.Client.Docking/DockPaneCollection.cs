using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CIT.Client.Docking
{
	public class DockPaneCollection : ReadOnlyCollection<DockPane>
	{
		internal DockPaneCollection()
			: base((IList<DockPane>)new List<DockPane>())
		{
		}

		internal int Add(DockPane pane)
		{
			if (base.Items.Contains(pane))
			{
				return base.Items.IndexOf(pane);
			}
			base.Items.Add(pane);
			return base.Count - 1;
		}

		internal void AddAt(DockPane pane, int index)
		{
			if (index >= 0 && index <= base.Items.Count - 1 && !Contains(pane))
			{
				base.Items.Insert(index, pane);
			}
		}

		internal void Dispose()
		{
			for (int num = base.Count - 1; num >= 0; num--)
			{
				base[num].Close();
			}
		}

		internal void Remove(DockPane pane)
		{
			base.Items.Remove(pane);
		}
	}
}
