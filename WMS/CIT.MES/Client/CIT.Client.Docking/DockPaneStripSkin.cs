using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CIT.Client.Docking
{
	[TypeConverter(typeof(DockPaneStripConverter))]
	public class DockPaneStripSkin
	{
		private DockPaneStripGradient m_DocumentGradient;

		private DockPaneStripToolWindowGradient m_ToolWindowGradient;

		public DockPaneStripGradient DocumentGradient
		{
			get
			{
				return m_DocumentGradient;
			}
			set
			{
				m_DocumentGradient = value;
			}
		}

		public DockPaneStripToolWindowGradient ToolWindowGradient
		{
			get
			{
				return m_ToolWindowGradient;
			}
			set
			{
				m_ToolWindowGradient = value;
			}
		}

		public DockPaneStripSkin()
		{
			m_DocumentGradient = new DockPaneStripGradient();
			m_DocumentGradient.DockStripGradient.StartColor = SystemColors.Control;
			m_DocumentGradient.DockStripGradient.EndColor = SystemColors.Control;
			m_DocumentGradient.ActiveTabGradient.StartColor = SystemColors.ControlLightLight;
			m_DocumentGradient.ActiveTabGradient.EndColor = SystemColors.ControlLightLight;
			m_DocumentGradient.InactiveTabGradient.StartColor = SystemColors.ControlLight;
			m_DocumentGradient.InactiveTabGradient.EndColor = SystemColors.ControlLight;
			m_ToolWindowGradient = new DockPaneStripToolWindowGradient();
			m_ToolWindowGradient.DockStripGradient.StartColor = SystemColors.ControlLight;
			m_ToolWindowGradient.DockStripGradient.EndColor = SystemColors.ControlLight;
			m_ToolWindowGradient.ActiveTabGradient.StartColor = SystemColors.Control;
			m_ToolWindowGradient.ActiveTabGradient.EndColor = SystemColors.Control;
			m_ToolWindowGradient.InactiveTabGradient.StartColor = Color.Transparent;
			m_ToolWindowGradient.InactiveTabGradient.EndColor = Color.Transparent;
			m_ToolWindowGradient.InactiveTabGradient.TextColor = SystemColors.ControlDarkDark;
			m_ToolWindowGradient.ActiveCaptionGradient.StartColor = SystemColors.GradientActiveCaption;
			m_ToolWindowGradient.ActiveCaptionGradient.EndColor = SystemColors.ActiveCaption;
			m_ToolWindowGradient.ActiveCaptionGradient.LinearGradientMode = LinearGradientMode.Vertical;
			m_ToolWindowGradient.ActiveCaptionGradient.TextColor = SystemColors.ActiveCaptionText;
			m_ToolWindowGradient.InactiveCaptionGradient.StartColor = SystemColors.GradientInactiveCaption;
			m_ToolWindowGradient.InactiveCaptionGradient.EndColor = SystemColors.GradientInactiveCaption;
			m_ToolWindowGradient.InactiveCaptionGradient.LinearGradientMode = LinearGradientMode.Vertical;
			m_ToolWindowGradient.InactiveCaptionGradient.TextColor = SystemColors.ControlText;
		}
	}
}
