using System;
using System.ComponentModel;
using System.Drawing;

namespace CIT.Client
{
	public class CustomPanelColors : CustomColors
	{
		private Color m_captionSelectedGradientBegin = SkinManager.CurrentSkin.HeightLightControlColor.First;

		private Color m_captionSelectedGradientEnd = SkinManager.CurrentSkin.HeightLightControlColor.Second;

		private Color m_collapsedCaptionText = SystemColors.ControlText;

		private Color m_contentGradientBegin = SkinManager.CurrentSkin.BaseColor;

		private Color m_contentGradientEnd = SkinManager.CurrentSkin.BaseColor;

		[Description("The starting color of the hover icon in the captionbar on the Panel.")]
		public virtual Color CaptionSelectedGradientBegin
		{
			get
			{
				return m_captionSelectedGradientBegin;
			}
			set
			{
				if (!value.Equals(m_captionSelectedGradientBegin))
				{
					m_captionSelectedGradientBegin = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The end color of the hover icon in the captionbar on the Panel.")]
		public virtual Color CaptionSelectedGradientEnd
		{
			get
			{
				return m_captionSelectedGradientEnd;
			}
			set
			{
				if (!value.Equals(m_captionSelectedGradientEnd))
				{
					m_captionSelectedGradientEnd = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The text color of a Panel when it's collapsed.")]
		public virtual Color CollapsedCaptionText
		{
			get
			{
				return m_collapsedCaptionText;
			}
			set
			{
				if (!value.Equals(m_collapsedCaptionText))
				{
					m_collapsedCaptionText = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The starting color of the gradient used in the Panel.")]
		public virtual Color ContentGradientBegin
		{
			get
			{
				return m_contentGradientBegin;
			}
			set
			{
				if (!value.Equals(m_contentGradientBegin))
				{
					m_contentGradientBegin = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The end color of the gradient used in the Panel.")]
		public virtual Color ContentGradientEnd
		{
			get
			{
				return m_contentGradientEnd;
			}
			set
			{
				if (!value.Equals(m_contentGradientEnd))
				{
					m_contentGradientEnd = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}
	}
}
