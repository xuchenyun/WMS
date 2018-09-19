using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace CIT.Client
{
	internal class XPanderPanelCaptionGlyph : Glyph
	{
		private XPanderPanel m_xpanderPanel;

		private BehaviorService m_behaviorService;

		public override Rectangle Bounds
		{
			get
			{
				Point point = m_behaviorService.ControlToAdornerWindow(m_xpanderPanel);
				return new Rectangle(point.X, point.Y, m_xpanderPanel.Width, m_xpanderPanel.CaptionHeight);
			}
		}

		public XPanderPanelCaptionGlyph(BehaviorService behaviorService, XPanderPanel xpanderPanel)
			: base(new XPanderPanelCaptionClickBehavior(xpanderPanel))
		{
			m_behaviorService = behaviorService;
			m_xpanderPanel = xpanderPanel;
		}

		public override Cursor GetHitTest(Point p)
		{
			if (m_xpanderPanel != null && !m_xpanderPanel.Expand && Bounds.Contains(p))
			{
				return Cursors.Hand;
			}
			return null;
		}

		public override void Paint(PaintEventArgs pe)
		{
		}
	}
}
