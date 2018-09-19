using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client.Docking
{
	[ToolboxItem(false)]
	public class DockWindow : Panel, INestedPanesContainer, ISplitterDragSource, IDragSource
	{
		private class SplitterControl : SplitterBase
		{
			protected override int SplitterSize => 4;

			protected override void StartDrag()
			{
				DockWindow dockWindow = base.Parent as DockWindow;
				dockWindow?.DockPanel.BeginDrag(dockWindow, dockWindow.RectangleToScreen(base.Bounds));
			}
		}

		private DockPanel m_dockPanel;

		private DockState m_dockState;

		private SplitterControl m_splitter;

		private NestedPaneCollection m_nestedPanes;

		public VisibleNestedPaneCollection VisibleNestedPanes => NestedPanes.VisibleNestedPanes;

		public NestedPaneCollection NestedPanes => m_nestedPanes;

		public DockPanel DockPanel => m_dockPanel;

		public DockState DockState => m_dockState;

		public bool IsFloat => DockState == DockState.Float;

		internal DockPane DefaultPane => (VisibleNestedPanes.Count == 0) ? null : VisibleNestedPanes[0];

		public virtual Rectangle DisplayingRectangle
		{
			get
			{
				Rectangle clientRectangle = base.ClientRectangle;
				if (DockState == DockState.Document)
				{
					clientRectangle.X++;
					clientRectangle.Y++;
					clientRectangle.Width -= 2;
					clientRectangle.Height -= 2;
				}
				else if (DockState == DockState.DockLeft)
				{
					clientRectangle.Width -= 4;
				}
				else if (DockState == DockState.DockRight)
				{
					clientRectangle.X += 4;
					clientRectangle.Width -= 4;
				}
				else if (DockState == DockState.DockTop)
				{
					clientRectangle.Height -= 4;
				}
				else if (DockState == DockState.DockBottom)
				{
					clientRectangle.Y += 4;
					clientRectangle.Height -= 4;
				}
				return clientRectangle;
			}
		}

		bool ISplitterDragSource.IsVertical
		{
			get
			{
				return DockState == DockState.DockLeft || DockState == DockState.DockRight;
			}
		}

		Rectangle ISplitterDragSource.DragLimitBounds
		{
			get
			{
				Rectangle dockArea = DockPanel.DockArea;
				Point point = ((Control.ModifierKeys & Keys.Shift) != 0) ? DockPanel.DockArea.Location : base.Location;
				if (((ISplitterDragSource)this).IsVertical)
				{
					dockArea.X += 24;
					dockArea.Width -= 48;
					dockArea.Y = point.Y;
					if ((Control.ModifierKeys & Keys.Shift) == Keys.None)
					{
						dockArea.Height = base.Height;
					}
				}
				else
				{
					dockArea.Y += 24;
					dockArea.Height -= 48;
					dockArea.X = point.X;
					if ((Control.ModifierKeys & Keys.Shift) == Keys.None)
					{
						dockArea.Width = base.Width;
					}
				}
				return DockPanel.RectangleToScreen(dockArea);
			}
		}

		Control IDragSource.DragControl
		{
			get
			{
				return this;
			}
		}

		internal DockWindow(DockPanel dockPanel, DockState dockState)
		{
			m_nestedPanes = new NestedPaneCollection(this);
			m_dockPanel = dockPanel;
			m_dockState = dockState;
			base.Visible = false;
			SuspendLayout();
			if (DockState == DockState.DockLeft || DockState == DockState.DockRight || DockState == DockState.DockTop || DockState == DockState.DockBottom)
			{
				m_splitter = new SplitterControl();
				base.Controls.Add(m_splitter);
			}
			if (DockState == DockState.DockLeft)
			{
				Dock = DockStyle.Left;
				m_splitter.Dock = DockStyle.Right;
			}
			else if (DockState == DockState.DockRight)
			{
				Dock = DockStyle.Right;
				m_splitter.Dock = DockStyle.Left;
			}
			else if (DockState == DockState.DockTop)
			{
				Dock = DockStyle.Top;
				m_splitter.Dock = DockStyle.Bottom;
			}
			else if (DockState == DockState.DockBottom)
			{
				Dock = DockStyle.Bottom;
				m_splitter.Dock = DockStyle.Top;
			}
			else if (DockState == DockState.Document)
			{
				Dock = DockStyle.Fill;
			}
			ResumeLayout();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (DockState == DockState.Document)
			{
				e.Graphics.DrawRectangle(SystemPens.ControlDark, base.ClientRectangle.X, base.ClientRectangle.Y, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1);
			}
			base.OnPaint(e);
		}

		protected override void OnLayout(LayoutEventArgs levent)
		{
			VisibleNestedPanes.Refresh();
			if (VisibleNestedPanes.Count == 0)
			{
				if (base.Visible)
				{
					base.Visible = false;
				}
			}
			else if (!base.Visible)
			{
				base.Visible = true;
				VisibleNestedPanes.Refresh();
			}
			base.OnLayout(levent);
		}

		void ISplitterDragSource.BeginDrag(Rectangle rectSplitter)
		{
		}

		void ISplitterDragSource.EndDrag()
		{
		}

		void ISplitterDragSource.MoveSplitter(int offset)
		{
			if ((Control.ModifierKeys & Keys.Shift) != 0)
			{
				SendToBack();
			}
			Rectangle dockArea = DockPanel.DockArea;
			if (DockState == DockState.DockLeft && dockArea.Width > 0)
			{
				if (DockPanel.DockLeftPortion > 1.0)
				{
					DockPanel.DockLeftPortion = (double)(base.Width + offset);
				}
				else
				{
					DockPanel.DockLeftPortion += (double)offset / (double)dockArea.Width;
				}
			}
			else if (DockState == DockState.DockRight && dockArea.Width > 0)
			{
				if (DockPanel.DockRightPortion > 1.0)
				{
					DockPanel.DockRightPortion = (double)(base.Width - offset);
				}
				else
				{
					DockPanel.DockRightPortion -= (double)offset / (double)dockArea.Width;
				}
			}
			else if (DockState == DockState.DockBottom && dockArea.Height > 0)
			{
				if (DockPanel.DockBottomPortion > 1.0)
				{
					DockPanel.DockBottomPortion = (double)(base.Height - offset);
				}
				else
				{
					DockPanel.DockBottomPortion -= (double)offset / (double)dockArea.Height;
				}
			}
			else if (DockState == DockState.DockTop && dockArea.Height > 0)
			{
				if (DockPanel.DockTopPortion > 1.0)
				{
					DockPanel.DockTopPortion = (double)(base.Height + offset);
				}
				else
				{
					DockPanel.DockTopPortion += (double)offset / (double)dockArea.Height;
				}
			}
		}
	}
}
