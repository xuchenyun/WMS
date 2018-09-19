using System.ComponentModel;

namespace CIT.Client.Docking
{
	[TypeConverter(typeof(DockPanelSkinConverter))]
	public class DockPanelSkin
	{
		private AutoHideStripSkin m_autoHideStripSkin;

		private DockPaneStripSkin m_dockPaneStripSkin;

		public AutoHideStripSkin AutoHideStripSkin
		{
			get
			{
				return m_autoHideStripSkin;
			}
			set
			{
				m_autoHideStripSkin = value;
			}
		}

		public DockPaneStripSkin DockPaneStripSkin
		{
			get
			{
				return m_dockPaneStripSkin;
			}
			set
			{
				m_dockPaneStripSkin = value;
			}
		}

		public DockPanelSkin()
		{
			m_autoHideStripSkin = new AutoHideStripSkin();
			m_dockPaneStripSkin = new DockPaneStripSkin();
		}
	}
}
