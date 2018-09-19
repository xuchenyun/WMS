using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;

namespace CIT.Client.Docking
{
	public abstract class DockPaneCaptionBase : Control
	{
		private DockPane m_dockPane;

		protected DockPane DockPane => m_dockPane;

		protected DockPane.AppearanceStyle Appearance => DockPane.Appearance;

		protected bool HasTabPageContextMenu => DockPane.HasTabPageContextMenu;

		protected internal DockPaneCaptionBase(DockPane pane)
		{
			m_dockPane = pane;
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			SetStyle(ControlStyles.Selectable, value: false);
		}

		protected void ShowTabPageContextMenu(Point position)
		{
			DockPane.ShowTabPageContextMenu(this, position);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (e.Button == MouseButtons.Right)
			{
				ShowTabPageContextMenu(new Point(e.X, e.Y));
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left && DockPane.DockPanel.AllowEndUserDocking && DockPane.AllowDockDragAndDrop && !DockHelper.IsDockStateAutoHide(DockPane.DockState) && DockPane.ActiveContent != null)
			{
				DockPane.DockPanel.BeginDrag(DockPane);
			}
		}

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 515)
			{
				if (DockHelper.IsDockStateAutoHide(DockPane.DockState))
				{
					DockPane.DockPanel.ActiveAutoHideContent = null;
					return;
				}
				if (DockPane.IsFloat)
				{
					DockPane.RestoreToPanel();
				}
				else
				{
					DockPane.Float();
				}
			}
			base.WndProc(ref m);
		}

		internal void RefreshChanges()
		{
			if (!base.IsDisposed)
			{
				OnRefreshChanges();
			}
		}

		protected virtual void OnRightToLeftLayoutChanged()
		{
		}

		protected virtual void OnRefreshChanges()
		{
		}

		protected internal abstract int MeasureHeight();
	}
}
