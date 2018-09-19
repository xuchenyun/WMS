using System.Collections.Generic;
using System.Drawing;

namespace CIT.Client
{
	public class PanelColorsBlue : PanelColorsBse
	{
		public PanelColorsBlue()
		{
		}

		public PanelColorsBlue(BasePanel basePanel)
			: base(basePanel)
		{
		}

		protected override void InitColors(Dictionary<KnownColors, Color> rgbTable)
		{
			base.InitColors(rgbTable);
			rgbTable[KnownColors.BorderColor] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.PanelCaptionCloseIcon] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.PanelCaptionExpandIcon] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.PanelCaptionGradientBegin] = Color.FromArgb(128, 128, 255);
			rgbTable[KnownColors.PanelCaptionGradientEnd] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.PanelCaptionGradientMiddle] = Color.FromArgb(0, 0, 139);
			rgbTable[KnownColors.PanelContentGradientBegin] = Color.FromArgb(240, 241, 242);
			rgbTable[KnownColors.PanelContentGradientEnd] = Color.FromArgb(240, 241, 242);
			rgbTable[KnownColors.PanelCaptionText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.PanelCollapsedCaptionText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.InnerBorderColor] = Color.FromArgb(185, 185, 185);
			rgbTable[KnownColors.XPanderPanelBackColor] = Color.FromArgb(240, 241, 242);
			rgbTable[KnownColors.XPanderPanelCaptionCloseIcon] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.XPanderPanelCaptionExpandIcon] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.XPanderPanelCaptionText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.XPanderPanelCaptionGradientBegin] = Color.FromArgb(128, 128, 255);
			rgbTable[KnownColors.XPanderPanelCaptionGradientEnd] = Color.FromArgb(98, 98, 205);
			rgbTable[KnownColors.XPanderPanelCaptionGradientMiddle] = Color.FromArgb(0, 0, 139);
			rgbTable[KnownColors.XPanderPanelFlatCaptionGradientBegin] = Color.FromArgb(111, 145, 255);
			rgbTable[KnownColors.XPanderPanelFlatCaptionGradientEnd] = Color.FromArgb(188, 205, 254);
		}
	}
}
