using System;
using System.ComponentModel;
using System.Drawing;

namespace CIT.Client
{
	public class CustomXPanderPanelColors : CustomColors
	{
		private Color m_backColor = SkinManager.CurrentSkin.BaseColor;

		private Color m_flatCaptionGradientBegin = Color.FromArgb(150, SkinManager.CurrentSkin.DefaultControlColor.Second);

		private Color m_flatCaptionGradientEnd = SkinManager.CurrentSkin.DefaultControlColor.Second;

		private Color m_captionPressedGradientBegin = SkinManager.CurrentSkin.HeightLightControlColor.First;

		private Color m_captionPressedGradientEnd = SkinManager.CurrentSkin.HeightLightControlColor.Second;

		private Color m_captionPressedGradientMiddle = SkinManager.CurrentSkin.HeightLightControlColor.Second;

		private Color m_captionCheckedGradientBegin = SkinManager.CurrentSkin.HeightLightControlColor.First;

		private Color m_captionCheckedGradientEnd = SkinManager.CurrentSkin.HeightLightControlColor.Second;

		private Color m_captionCheckedGradientMiddle = SkinManager.CurrentSkin.HeightLightControlColor.Second;

		private Color m_captionSelectedGradientBegin = SkinManager.CurrentSkin.HeightLightControlColor.First;

		private Color m_captionSelectedGradientEnd = SkinManager.CurrentSkin.HeightLightControlColor.First;

		private Color m_captionSelectedGradientMiddle = SkinManager.CurrentSkin.HeightLightControlColor.Second;

		private Color m_captionSelectedText = SystemColors.ControlText;

		[Description("The backcolor of a XPanderPanel.")]
		public virtual Color BackColor
		{
			get
			{
				return m_backColor;
			}
			set
			{
				if (!value.Equals(m_backColor))
				{
					m_backColor = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The starting color of the gradient on a flat XPanderPanel captionbar.")]
		public virtual Color FlatCaptionGradientBegin
		{
			get
			{
				return m_flatCaptionGradientBegin;
			}
			set
			{
				if (!value.Equals(m_flatCaptionGradientBegin))
				{
					m_flatCaptionGradientBegin = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The end color of the gradient on a flat XPanderPanel captionbar.")]
		public virtual Color FlatCaptionGradientEnd
		{
			get
			{
				return m_flatCaptionGradientEnd;
			}
			set
			{
				if (!value.Equals(m_flatCaptionGradientEnd))
				{
					m_flatCaptionGradientEnd = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The starting color of the gradient used when the XPanderPanel is pressed down.")]
		public virtual Color CaptionPressedGradientBegin
		{
			get
			{
				return m_captionPressedGradientBegin;
			}
			set
			{
				if (!value.Equals(m_captionPressedGradientBegin))
				{
					m_captionPressedGradientBegin = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The end color of the gradient used when the XPanderPanel is pressed down.")]
		public virtual Color CaptionPressedGradientEnd
		{
			get
			{
				return m_captionPressedGradientEnd;
			}
			set
			{
				if (!value.Equals(m_captionPressedGradientEnd))
				{
					m_captionPressedGradientEnd = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The middle color of the gradient used when the XPanderPanel is pressed down.")]
		public virtual Color CaptionPressedGradientMiddle
		{
			get
			{
				return m_captionPressedGradientMiddle;
			}
			set
			{
				if (!value.Equals(m_captionPressedGradientMiddle))
				{
					m_captionPressedGradientMiddle = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The starting color of the gradient used when the XPanderPanel is checked.")]
		public virtual Color CaptionCheckedGradientBegin
		{
			get
			{
				return m_captionCheckedGradientBegin;
			}
			set
			{
				if (!value.Equals(m_captionCheckedGradientBegin))
				{
					m_captionCheckedGradientBegin = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The end color of the gradient used when the XPanderPanel is checked.")]
		public virtual Color CaptionCheckedGradientEnd
		{
			get
			{
				return m_captionCheckedGradientEnd;
			}
			set
			{
				if (!value.Equals(m_captionCheckedGradientEnd))
				{
					m_captionCheckedGradientEnd = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The middle color of the gradient used when the XPanderPanel is checked.")]
		public virtual Color CaptionCheckedGradientMiddle
		{
			get
			{
				return m_captionCheckedGradientMiddle;
			}
			set
			{
				if (!value.Equals(m_captionCheckedGradientMiddle))
				{
					m_captionCheckedGradientMiddle = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The starting color of the gradient used when the XPanderPanel is selected.")]
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

		[Description("The end color of the gradient used when the XPanderPanel is selected.")]
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

		[Description("The middle color of the gradient used when the XPanderPanel is selected.")]
		public virtual Color CaptionSelectedGradientMiddle
		{
			get
			{
				return m_captionSelectedGradientMiddle;
			}
			set
			{
				if (!value.Equals(m_captionSelectedGradientMiddle))
				{
					m_captionSelectedGradientMiddle = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The text color used when the XPanderPanel is selected.")]
		public virtual Color CaptionSelectedText
		{
			get
			{
				return m_captionSelectedText;
			}
			set
			{
				if (!value.Equals(m_captionSelectedText))
				{
					m_captionSelectedText = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}
	}
}
