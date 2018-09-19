using System;

namespace CIT.Client
{
	public class PanelStyleChangeEventArgs : EventArgs
	{
		private PanelStyle m_ePanelStyle;

		public PanelStyle PanelStyle => m_ePanelStyle;

		public PanelStyleChangeEventArgs(PanelStyle ePanelStyle)
		{
			m_ePanelStyle = ePanelStyle;
		}
	}
}
