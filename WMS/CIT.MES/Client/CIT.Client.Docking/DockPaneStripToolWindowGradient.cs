using System.ComponentModel;

namespace CIT.Client.Docking
{
	[TypeConverter(typeof(DockPaneStripGradientConverter))]
	public class DockPaneStripToolWindowGradient : DockPaneStripGradient
	{
		private TabGradient m_activeCaptionGradient;

		private TabGradient m_inactiveCaptionGradient;

		public TabGradient ActiveCaptionGradient
		{
			get
			{
				return m_activeCaptionGradient;
			}
			set
			{
				m_activeCaptionGradient = value;
			}
		}

		public TabGradient InactiveCaptionGradient
		{
			get
			{
				return m_inactiveCaptionGradient;
			}
			set
			{
				m_inactiveCaptionGradient = value;
			}
		}

		public DockPaneStripToolWindowGradient()
		{
			m_activeCaptionGradient = new TabGradient();
			m_inactiveCaptionGradient = new TabGradient();
		}
	}
}
