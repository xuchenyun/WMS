using System.Drawing;

namespace CIT.Client
{
	internal class SkinTheme
	{
		public EnumTheme ThemeStyle
		{
			get;
			set;
		}

		public string ThemeName
		{
			get;
			set;
		}

		public Bitmap BackGroundImage
		{
			get;
			set;
		}

		public float BackGroundImageOpacity
		{
			get;
			set;
		}

		public bool BackGroundImageEnable
		{
			get;
			set;
		}

		public Color BaseColor
		{
			get;
			set;
		}

		public Color BorderColor
		{
			get;
			set;
		}

		public Color InnerBorderColor
		{
			get;
			set;
		}

		public Color OuterBorderColor
		{
			get;
			set;
		}

		public GradientColor DefaultControlColor
		{
			get;
			set;
		}

		public GradientColor HeightLightControlColor
		{
			get;
			set;
		}

		public GradientColor FocusedControlColor
		{
			get;
			set;
		}

		public Color UselessColor
		{
			get;
			set;
		}

		public GradientColor CaptionColor
		{
			get;
			set;
		}

		public Color CaptionFontColor
		{
			get;
			set;
		}

		public Color ThemeColor
		{
			get;
			set;
		}

		public GradientColor CloseBoxHeightLightColor
		{
			get;
			set;
		}

		public GradientColor CloseBoxPressedColor
		{
			get;
			set;
		}

		public GradientColor ControlBoxDefaultColor
		{
			get;
			set;
		}

		public GradientColor ControlBoxHeightLightColor
		{
			get;
			set;
		}

		public GradientColor ControlBoxPressedColor
		{
			get;
			set;
		}

		public Color ControlBoxFlagColor
		{
			get;
			set;
		}

		public SkinTheme()
		{
			IniSkinTheme();
		}

		public virtual void IniSkinTheme()
		{
		}
	}
}
