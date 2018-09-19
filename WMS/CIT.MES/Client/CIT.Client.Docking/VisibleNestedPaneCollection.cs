using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace CIT.Client.Docking
{
	public sealed class VisibleNestedPaneCollection : ReadOnlyCollection<DockPane>
	{
		private NestedPaneCollection m_nestedPanes;

		public NestedPaneCollection NestedPanes => m_nestedPanes;

		public INestedPanesContainer Container => NestedPanes.Container;

		public DockState DockState => NestedPanes.DockState;

		public bool IsFloat => NestedPanes.IsFloat;

		internal VisibleNestedPaneCollection(NestedPaneCollection nestedPanes)
			: base((IList<DockPane>)new List<DockPane>())
		{
			m_nestedPanes = nestedPanes;
		}

		internal void Refresh()
		{
			base.Items.Clear();
			for (int i = 0; i < NestedPanes.Count; i++)
			{
				DockPane dockPane = NestedPanes[i];
				NestedDockingStatus nestedDockingStatus = dockPane.NestedDockingStatus;
				nestedDockingStatus.SetDisplayingStatus(isDisplaying: true, nestedDockingStatus.PreviousPane, nestedDockingStatus.Alignment, nestedDockingStatus.Proportion);
				base.Items.Add(dockPane);
			}
			foreach (DockPane nestedPane in NestedPanes)
			{
				if (nestedPane.DockState != DockState || nestedPane.IsHidden)
				{
					nestedPane.Bounds = Rectangle.Empty;
					nestedPane.SplitterBounds = Rectangle.Empty;
					Remove(nestedPane);
				}
			}
			CalculateBounds();
			using (IEnumerator<DockPane> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DockPane dockPane = enumerator.Current;
					NestedDockingStatus nestedDockingStatus = dockPane.NestedDockingStatus;
					dockPane.Bounds = nestedDockingStatus.PaneBounds;
					dockPane.SplitterBounds = nestedDockingStatus.SplitterBounds;
					dockPane.SplitterAlignment = nestedDockingStatus.Alignment;
				}
			}
		}

		private void Remove(DockPane pane)
		{
			if (Contains(pane))
			{
				NestedDockingStatus nestedDockingStatus = pane.NestedDockingStatus;
				DockPane dockPane = null;
				for (int num = base.Count - 1; num > IndexOf(pane); num--)
				{
					if (base[num].NestedDockingStatus.PreviousPane == pane)
					{
						dockPane = base[num];
						break;
					}
				}
				if (dockPane != null)
				{
					int num2 = IndexOf(dockPane);
					base.Items.Remove(dockPane);
					base.Items[IndexOf(pane)] = dockPane;
					NestedDockingStatus nestedDockingStatus2 = dockPane.NestedDockingStatus;
					nestedDockingStatus2.SetDisplayingStatus(isDisplaying: true, nestedDockingStatus.DisplayingPreviousPane, nestedDockingStatus.DisplayingAlignment, nestedDockingStatus.DisplayingProportion);
					for (int num = num2 - 1; num > IndexOf(dockPane); num--)
					{
						NestedDockingStatus nestedDockingStatus3 = base[num].NestedDockingStatus;
						if (nestedDockingStatus3.PreviousPane == pane)
						{
							nestedDockingStatus3.SetDisplayingStatus(isDisplaying: true, dockPane, nestedDockingStatus3.DisplayingAlignment, nestedDockingStatus3.DisplayingProportion);
						}
					}
				}
				else
				{
					base.Items.Remove(pane);
				}
				nestedDockingStatus.SetDisplayingStatus(isDisplaying: false, null, DockAlignment.Left, 0.5);
			}
		}

		private void CalculateBounds()
		{
			if (base.Count != 0)
			{
				base[0].NestedDockingStatus.SetDisplayingBounds(Container.DisplayingRectangle, Container.DisplayingRectangle, Rectangle.Empty);
				for (int i = 1; i < base.Count; i++)
				{
					DockPane dockPane = base[i];
					NestedDockingStatus nestedDockingStatus = dockPane.NestedDockingStatus;
					DockPane displayingPreviousPane = nestedDockingStatus.DisplayingPreviousPane;
					NestedDockingStatus nestedDockingStatus2 = displayingPreviousPane.NestedDockingStatus;
					Rectangle paneBounds = nestedDockingStatus2.PaneBounds;
					bool flag = nestedDockingStatus.DisplayingAlignment == DockAlignment.Left || nestedDockingStatus.DisplayingAlignment == DockAlignment.Right;
					Rectangle paneBounds2 = paneBounds;
					Rectangle paneBounds3 = paneBounds;
					Rectangle splitterBounds = paneBounds;
					if (nestedDockingStatus.DisplayingAlignment == DockAlignment.Left)
					{
						paneBounds2.Width = (int)((double)paneBounds.Width * nestedDockingStatus.DisplayingProportion) - 2;
						splitterBounds.X = paneBounds2.X + paneBounds2.Width;
						splitterBounds.Width = 4;
						paneBounds3.X = splitterBounds.X + splitterBounds.Width;
						paneBounds3.Width = paneBounds.Width - paneBounds2.Width - splitterBounds.Width;
					}
					else if (nestedDockingStatus.DisplayingAlignment == DockAlignment.Right)
					{
						paneBounds3.Width = paneBounds.Width - (int)((double)paneBounds.Width * nestedDockingStatus.DisplayingProportion) - 2;
						splitterBounds.X = paneBounds3.X + paneBounds3.Width;
						splitterBounds.Width = 4;
						paneBounds2.X = splitterBounds.X + splitterBounds.Width;
						paneBounds2.Width = paneBounds.Width - paneBounds3.Width - splitterBounds.Width;
					}
					else if (nestedDockingStatus.DisplayingAlignment == DockAlignment.Top)
					{
						paneBounds2.Height = (int)((double)paneBounds.Height * nestedDockingStatus.DisplayingProportion) - 2;
						splitterBounds.Y = paneBounds2.Y + paneBounds2.Height;
						splitterBounds.Height = 4;
						paneBounds3.Y = splitterBounds.Y + splitterBounds.Height;
						paneBounds3.Height = paneBounds.Height - paneBounds2.Height - splitterBounds.Height;
					}
					else if (nestedDockingStatus.DisplayingAlignment == DockAlignment.Bottom)
					{
						paneBounds3.Height = paneBounds.Height - (int)((double)paneBounds.Height * nestedDockingStatus.DisplayingProportion) - 2;
						splitterBounds.Y = paneBounds3.Y + paneBounds3.Height;
						splitterBounds.Height = 4;
						paneBounds2.Y = splitterBounds.Y + splitterBounds.Height;
						paneBounds2.Height = paneBounds.Height - paneBounds3.Height - splitterBounds.Height;
					}
					else
					{
						paneBounds2 = Rectangle.Empty;
					}
					splitterBounds.Intersect(paneBounds);
					paneBounds2.Intersect(paneBounds);
					paneBounds3.Intersect(paneBounds);
					nestedDockingStatus.SetDisplayingBounds(paneBounds, paneBounds2, splitterBounds);
					nestedDockingStatus2.SetDisplayingBounds(nestedDockingStatus2.LogicalBounds, paneBounds3, nestedDockingStatus2.SplitterBounds);
				}
			}
		}
	}
}
