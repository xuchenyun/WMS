using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace CIT.Client
{
	internal class XPanderPanelCaptionClickBehavior : Behavior
	{
		private XPanderPanel m_xpanderPanel;

		public XPanderPanelCaptionClickBehavior(XPanderPanel xpanderPanel)
		{
			m_xpanderPanel = xpanderPanel;
		}

		public override bool OnMouseDown(Glyph g, MouseButtons button, Point mouseLoc)
		{
			if (m_xpanderPanel != null && !m_xpanderPanel.Expand)
			{
				XPanderPanelList xPanderPanelList = m_xpanderPanel.Parent as XPanderPanelList;
				if (xPanderPanelList != null)
				{
					xPanderPanelList.Expand(m_xpanderPanel);
					m_xpanderPanel.Invalidate(invalidateChildren: false);
				}
			}
			return true;
		}
	}
}
