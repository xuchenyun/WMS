using CIT.Client.Properties;
using System.Drawing;

namespace CIT.Client
{
	internal class SkinThemeDefault : SkinTheme
	{
		public override void IniSkinTheme()
		{
			base.ThemeStyle = EnumTheme.Default;
			base.ThemeName = "系统默认";
			base.ThemeColor = Color.FromArgb(238, 247, 252);
			base.BackGroundImage = Resources.bg01;
			base.BackGroundImageEnable = false;
			base.BackGroundImageOpacity = 0.8f;
			base.BaseColor = Color.FromArgb(238, 247, 252);
			base.BorderColor = Color.FromArgb(182, 168, 192);
			base.InnerBorderColor = Color.FromArgb(232, 218, 222);
			base.OuterBorderColor = Color.FromArgb(44, 182, 240);
			base.DefaultControlColor = new GradientColor(Color.FromArgb(246, 247, 250), Color.FromArgb(204, 214, 223), null, null);
			base.HeightLightControlColor = new GradientColor(Color.FromArgb(140, 67, 165, 220), Color.FromArgb(67, 165, 220), null, null);
			base.FocusedControlColor = new GradientColor(Color.FromArgb(67, 165, 220), Color.FromArgb(39, 88, 142), null, null);
			base.UselessColor = Color.FromArgb(159, 159, 159);
			base.CaptionColor = new GradientColor(Color.FromArgb(220, 74, 181, 237), Color.FromArgb(1, 19, 174, 233), new float[7]
			{
				0f,
				0.15f,
				0.05f,
				0.2f,
				0.6f,
				0.8f,
				1f
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
			base.CaptionFontColor = Color.FromArgb(25, 5, 255);
			base.CaptionFontColor = Color.Black;
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
