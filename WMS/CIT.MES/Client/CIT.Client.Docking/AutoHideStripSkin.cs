using System.ComponentModel;
using System.Drawing;

namespace CIT.Client.Docking
{
	[TypeConverter(typeof(AutoHideStripConverter))]
	public class AutoHideStripSkin
	{
		private DockPanelGradient m_dockStripGradient;

		private TabGradient m_TabGradient;

		public DockPanelGradient DockStripGradient
		{
			get
			{
				return m_dockStripGradient;
			}
			set
			{
				m_dockStripGradient = value;
			}
		}

		public TabGradient TabGradient
		{
			get
			{
				return m_TabGradient;
			}
			set
			{
				m_TabGradient = value;
			}
		}

		public AutoHideStripSkin()
		{
			m_dockStripGradient = new DockPanelGradient();
			m_dockStripGradient.StartColor = SystemColors.ControlLight;
			m_dockStripGradient.EndColor = SystemColors.ControlLight;
			m_TabGradient = new TabGradient();
			m_TabGradient.TextColor = SystemColors.ControlDarkDark;
		}
	}
}
