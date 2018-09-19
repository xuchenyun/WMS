using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace CIT.Client
{
	internal class XPanderPanelDesigner : ScrollableControlDesigner
	{
		private Pen m_borderPen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark));

		private Adorner m_adorner;

		public XPanderPanelDesigner()
		{
			m_borderPen.DashStyle = DashStyle.Dash;
		}

		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			XPanderPanel xPanderPanel = Control as XPanderPanel;
			if (xPanderPanel != null)
			{
				m_adorner = new Adorner();
				base.BehaviorService.Adorners.Add(m_adorner);
				m_adorner.Glyphs.Add(new XPanderPanelCaptionGlyph(base.BehaviorService, xPanderPanel));
			}
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing)
				{
					if (m_borderPen != null)
					{
						m_borderPen.Dispose();
					}
					if (m_adorner != null && base.BehaviorService != null)
					{
						base.BehaviorService.Adorners.Remove(m_adorner);
					}
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		protected override void OnPaintAdornments(PaintEventArgs e)
		{
			base.OnPaintAdornments(e);
			e.Graphics.DrawRectangle(m_borderPen, 0, 0, Control.Width - 2, Control.Height - 2);
		}

		protected override void PostFilterProperties(IDictionary properties)
		{
			base.PostFilterProperties(properties);
			properties.Remove("AccessibilityObject");
			properties.Remove("AccessibleDefaultActionDescription");
			properties.Remove("AccessibleDescription");
			properties.Remove("AccessibleName");
			properties.Remove("AccessibleRole");
			properties.Remove("AllowDrop");
			properties.Remove("Anchor");
			properties.Remove("AntiAliasing");
			properties.Remove("AutoScroll");
			properties.Remove("AutoScrollMargin");
			properties.Remove("AutoScrollMinSize");
			properties.Remove("BackColor");
			properties.Remove("BackgroundImage");
			properties.Remove("BackgroundImageLayout");
			properties.Remove("CausesValidation");
			properties.Remove("ContextMenuStrip");
			properties.Remove("Dock");
			properties.Remove("GenerateMember");
			properties.Remove("ImeMode");
			properties.Remove("Location");
			properties.Remove("MaximumSize");
			properties.Remove("MinimumSize");
		}
	}
}
