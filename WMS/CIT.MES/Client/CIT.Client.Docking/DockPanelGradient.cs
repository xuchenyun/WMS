using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CIT.Client.Docking
{
	[TypeConverter(typeof(DockPanelGradientConverter))]
	public class DockPanelGradient
	{
		private Color m_startColor;

		private Color m_endColor;

		private LinearGradientMode m_linearGradientMode;

		[DefaultValue(typeof(SystemColors), "Control")]
		public Color StartColor
		{
			get
			{
				return m_startColor;
			}
			set
			{
				m_startColor = value;
			}
		}

		[DefaultValue(typeof(SystemColors), "Control")]
		public Color EndColor
		{
			get
			{
				return m_endColor;
			}
			set
			{
				m_endColor = value;
			}
		}

		[DefaultValue(LinearGradientMode.Horizontal)]
		public LinearGradientMode LinearGradientMode
		{
			get
			{
				return m_linearGradientMode;
			}
			set
			{
				m_linearGradientMode = value;
			}
		}

		public DockPanelGradient()
		{
			m_startColor = SystemColors.Control;
			m_endColor = SystemColors.Control;
			m_linearGradientMode = LinearGradientMode.Horizontal;
		}
	}
}
