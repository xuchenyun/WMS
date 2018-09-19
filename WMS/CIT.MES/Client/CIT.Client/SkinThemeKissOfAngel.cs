using CIT.Client.Properties;
using System.Drawing;

namespace CIT.Client
{
	internal class SkinThemeKissOfAngel : SkinTheme
	{
		public override void IniSkinTheme()
		{
			base.ThemeStyle = EnumTheme.KissOfAngel;
			base.ThemeName = "天使之吻";
			base.BackGroundImage = Resources.bg03;
			base.BackGroundImageEnable = false;
			base.BackGroundImageOpacity = 0.8f;
			base.BaseColor = Color.FromArgb(238, 247, 252);
			base.BorderColor = Color.FromArgb(198, 85, 171);
			base.InnerBorderColor = Color.FromArgb(227, 227, 227);
			base.OuterBorderColor = Color.FromArgb(174, 3, 123);
			base.DefaultControlColor = new GradientColor(Color.FromArgb(248, 245, 251), Color.FromArgb(205, 205, 205), new float[7]
			{
				0f,
				0.15f,
				0.05f,
				0.2f,
				0.6f,
				0.8f,
				0.85f
			}, new float[7]
			{
				0f,
				0.2f,
				0.4f,
				0.6f,
				0.8f,
				0.9f,
				1f
			});
			base.HeightLightControlColor = new GradientColor(Color.FromArgb(205, 205, 205), Color.FromArgb(182, 11, 130), new float[3]
			{
				0f,
				0.7f,
				1.5f
			}, new float[3]
			{
				0f,
				0.6f,
				1f
			});
			base.FocusedControlColor = new GradientColor(Color.FromArgb(182, 11, 130), Color.FromArgb(205, 205, 205), new float[5]
			{
				0.2f,
				0.6f,
				0.8f,
				0.4f,
				0.2f
			}, new float[5]
			{
				0f,
				0.3f,
				0.6f,
				0.8f,
				1f
			});
			base.UselessColor = Color.FromArgb(159, 159, 159);
			base.CaptionColor = new GradientColor(Color.FromArgb(240, 228, 73, 170), Color.FromArgb(1, 228, 73, 170), new float[7]
			{
				0f,
				0.15f,
				0.05f,
				0.2f,
				0.6f,
				0.8f,
				0.85f
			}, new float[7]
			{
				0f,
				0.2f,
				0.4f,
				0.6f,
				0.8f,
				0.9f,
				1f
			});
			base.ThemeColor = Color.FromArgb(238, 247, 252);
			base.CaptionFontColor = Color.FromArgb(25, 5, 255);
			base.ControlBoxDefaultColor = new GradientColor(Color.FromArgb(110, 195, 226), Color.FromArgb(0, 110, 195, 226), new float[4]
			{
				0f,
				0.1f,
				0.7f,
				1f
			}, new float[4]
			{
				0f,
				0.3f,
				0.6f,
				1f
			});
			base.ControlBoxHeightLightColor = new GradientColor(Color.FromArgb(40, 183, 236), Color.FromArgb(0, 40, 183, 236), new float[4]
			{
				0f,
				0.1f,
				0.7f,
				1f
			}, new float[4]
			{
				0f,
				0.3f,
				0.6f,
				1f
			});
			base.ControlBoxPressedColor = new GradientColor(Color.FromArgb(33, 154, 202), Color.FromArgb(0, 33, 154, 202), new float[4]
			{
				0f,
				0.7f,
				0.2f,
				0f
			}, new float[4]
			{
				0f,
				0.3f,
				0.6f,
				1f
			});
			base.CloseBoxHeightLightColor = new GradientColor(Color.FromArgb(219, 85, 55), Color.FromArgb(0, 219, 85, 55), new float[4]
			{
				0f,
				0.1f,
				0.7f,
				1f
			}, new float[4]
			{
				0f,
				0.3f,
				0.6f,
				1f
			});
			base.CloseBoxPressedColor = new GradientColor(Color.FromArgb(167, 78, 58), Color.FromArgb(0, 167, 78, 58), new float[4]
			{
				0f,
				0.7f,
				0.2f,
				0f
			}, new float[4]
			{
				0f,
				0.3f,
				0.6f,
				1f
			});
			base.ControlBoxFlagColor = Color.White;
		}
	}
}
