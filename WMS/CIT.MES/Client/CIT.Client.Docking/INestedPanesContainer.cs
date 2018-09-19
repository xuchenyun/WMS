using System.Drawing;

namespace CIT.Client.Docking
{
	public interface INestedPanesContainer
	{
		DockState DockState
		{
			get;
		}

		Rectangle DisplayingRectangle
		{
			get;
		}

		NestedPaneCollection NestedPanes
		{
			get;
		}

		VisibleNestedPaneCollection VisibleNestedPanes
		{
			get;
		}

		bool IsFloat
		{
			get;
		}
	}
}
