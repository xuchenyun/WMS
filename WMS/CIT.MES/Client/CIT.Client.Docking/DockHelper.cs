using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client.Docking
{
	internal static class DockHelper
	{
		public static bool IsDockStateAutoHide(DockState dockState)
		{
			if (dockState == DockState.DockLeftAutoHide || dockState == DockState.DockRightAutoHide || dockState == DockState.DockTopAutoHide || dockState == DockState.DockBottomAutoHide)
			{
				return true;
			}
			return false;
		}

		public static bool IsDockStateValid(DockState dockState, DockAreas dockableAreas)
		{
			if ((dockableAreas & DockAreas.Float) == (DockAreas)0 && dockState == DockState.Float)
			{
				return false;
			}
			if ((dockableAreas & DockAreas.Document) == (DockAreas)0 && dockState == DockState.Document)
			{
				return false;
			}
			if ((dockableAreas & DockAreas.DockLeft) == (DockAreas)0 && (dockState == DockState.DockLeft || dockState == DockState.DockLeftAutoHide))
			{
				return false;
			}
			if ((dockableAreas & DockAreas.DockRight) == (DockAreas)0 && (dockState == DockState.DockRight || dockState == DockState.DockRightAutoHide))
			{
				return false;
			}
			if ((dockableAreas & DockAreas.DockTop) == (DockAreas)0 && (dockState == DockState.DockTop || dockState == DockState.DockTopAutoHide))
			{
				return false;
			}
			if ((dockableAreas & DockAreas.DockBottom) == (DockAreas)0 && (dockState == DockState.DockBottom || dockState == DockState.DockBottomAutoHide))
			{
				return false;
			}
			return true;
		}

		public static bool IsDockWindowState(DockState state)
		{
			if (state == DockState.DockTop || state == DockState.DockBottom || state == DockState.DockLeft || state == DockState.DockRight || state == DockState.Document)
			{
				return true;
			}
			return false;
		}

		public static DockState ToggleAutoHideState(DockState state)
		{
			switch (state)
			{
			case DockState.DockLeft:
				return DockState.DockLeftAutoHide;
			case DockState.DockRight:
				return DockState.DockRightAutoHide;
			case DockState.DockTop:
				return DockState.DockTopAutoHide;
			case DockState.DockBottom:
				return DockState.DockBottomAutoHide;
			case DockState.DockLeftAutoHide:
				return DockState.DockLeft;
			case DockState.DockRightAutoHide:
				return DockState.DockRight;
			case DockState.DockTopAutoHide:
				return DockState.DockTop;
			case DockState.DockBottomAutoHide:
				return DockState.DockBottom;
			default:
				return state;
			}
		}

		public static DockPane PaneAtPoint(Point pt, DockPanel dockPanel)
		{
			for (Control control = Win32Helper.ControlAtPoint(pt); control != null; control = control.Parent)
			{
				IDockContent dockContent = control as IDockContent;
				if (dockContent != null && dockContent.DockHandler.DockPanel == dockPanel)
				{
					return dockContent.DockHandler.Pane;
				}
				DockPane dockPane = control as DockPane;
				if (dockPane != null && dockPane.DockPanel == dockPanel)
				{
					return dockPane;
				}
			}
			return null;
		}

		public static FloatWindow FloatWindowAtPoint(Point pt, DockPanel dockPanel)
		{
			for (Control control = Win32Helper.ControlAtPoint(pt); control != null; control = control.Parent)
			{
				FloatWindow floatWindow = control as FloatWindow;
				if (floatWindow != null && floatWindow.DockPanel == dockPanel)
				{
					return floatWindow;
				}
			}
			return null;
		}
	}
}
