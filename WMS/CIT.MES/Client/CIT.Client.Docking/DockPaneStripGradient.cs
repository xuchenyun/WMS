using System.ComponentModel;

namespace CIT.Client.Docking
{
	[TypeConverter(typeof(DockPaneStripGradientConverter))]
	public class DockPaneStripGradient
	{
		private DockPanelGradient m_dockStripGradient;

		private TabGradient m_activeTabGradient;

		private TabGradient m_inactiveTabGradient;

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

		public TabGradient ActiveTabGradient
		{
			get
			{
				return m_activeTabGradient;
			}
			set
			{
				m_activeTabGradient = value;
			}
		}

		public TabGradient InactiveTabGradient
		{
			get
			{
				return m_inactiveTabGradient;
			}
			set
			{
				m_inactiveTabGradient = value;
			}
		}

		public DockPaneStripGradient()
		{
			m_dockStripGradient = new DockPanelGradient();
			m_activeTabGradient = new TabGradient();
			m_inactiveTabGradient = new TabGradient();
		}
	}
}
