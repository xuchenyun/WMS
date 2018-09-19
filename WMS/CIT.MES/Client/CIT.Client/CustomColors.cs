using System;
using System.ComponentModel;
using System.Drawing;

namespace CIT.Client
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[Description("The colors used in a panel")]
	public class CustomColors
	{
		private Color m_borderColor = SkinManager.CurrentSkin.BorderColor;

		private Color m_captionCloseIcon = Color.Red;

		private Color m_captionExpandIcon = SystemColors.ControlText;

		private Color m_captionGradientBegin = Color.FromArgb(100, SkinManager.CurrentSkin.DefaultControlColor.First);

		private Color m_captionGradientEnd = Color.FromArgb(5, SkinManager.CurrentSkin.DefaultControlColor.First);

		private Color m_captionGradientMiddle = SkinManager.CurrentSkin.DefaultControlColor.Second;

		private Color m_captionText = SystemColors.ControlText;

		private Color m_innerBorderColor = SkinManager.CurrentSkin.InnerBorderColor;

		[Description("The border color of a Panel or XPanderPanel.")]
		public virtual Color BorderColor
		{
			get
			{
				return m_borderColor;
			}
			set
			{
				if (!value.Equals(m_borderColor))
				{
					m_borderColor = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The forecolor of a close icon in a Panel or XPanderPanel.")]
		public virtual Color CaptionCloseIcon
		{
			get
			{
				return m_captionCloseIcon;
			}
			set
			{
				if (!value.Equals(m_captionCloseIcon))
				{
					m_captionCloseIcon = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The forecolor of an expand icon in a Panel or XPanderPanel.")]
		public virtual Color CaptionExpandIcon
		{
			get
			{
				return m_captionExpandIcon;
			}
			set
			{
				if (!value.Equals(m_captionExpandIcon))
				{
					m_captionExpandIcon = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The starting color of the gradient at the caption on a Panel or XPanderPanel.")]
		public virtual Color CaptionGradientBegin
		{
			get
			{
				return m_captionGradientBegin;
			}
			set
			{
				if (!value.Equals(m_captionGradientBegin))
				{
					m_captionGradientBegin = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The end color of the gradient at the caption on a Panel or XPanderPanel")]
		public virtual Color CaptionGradientEnd
		{
			get
			{
				return m_captionGradientEnd;
			}
			set
			{
				if (!value.Equals(m_captionGradientEnd))
				{
					m_captionGradientEnd = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The middle color of the gradient at the caption on a Panel or XPanderPanel.")]
		public virtual Color CaptionGradientMiddle
		{
			get
			{
				return m_captionGradientMiddle;
			}
			set
			{
				if (!value.Equals(m_captionGradientMiddle))
				{
					m_captionGradientMiddle = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The text color at the caption on a Panel or XPanderPanel.")]
		public virtual Color CaptionText
		{
			get
			{
				return m_captionText;
			}
			set
			{
				if (!value.Equals(m_captionText))
				{
					m_captionText = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("The inner border color of a Panel.")]
		public virtual Color InnerBorderColor
		{
			get
			{
				return m_innerBorderColor;
			}
			set
			{
				if (!value.Equals(m_innerBorderColor))
				{
					m_innerBorderColor = value;
					OnCustomColorsChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("Occurs when the value of the CustomColors property changes.")]
		public event EventHandler<EventArgs> CustomColorsChanged;

		protected virtual void OnCustomColorsChanged(object sender, EventArgs e)
		{
			if (this.CustomColorsChanged != null)
			{
				this.CustomColorsChanged(sender, e);
			}
		}
	}
}
