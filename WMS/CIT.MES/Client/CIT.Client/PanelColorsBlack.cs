using System.Collections.Generic;
using System.Drawing;

namespace CIT.Client
{
	public class PanelColorsBlack : PanelColorsBse
	{
		public PanelColorsBlack()
		{
		}

		public PanelColorsBlack(BasePanel basePanel)
			: base(basePanel)
		{
		}

		protected override void InitColors(Dictionary<KnownColors, Color> rgbTable)
		{
			base.InitColors(rgbTable);
			rgbTable[KnownColors.BorderColor] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.PanelCaptionCloseIcon] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.PanelCaptionExpandIcon] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.PanelCaptionGradientBegin] = Color.FromArgb(122, 122, 122);
			rgbTable[KnownColors.PanelCaptionGradientEnd] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.PanelCaptionGradientMiddle] = Color.FromArgb(80, 80, 80);
			rgbTable[KnownColors.PanelContentGradientBegin] = Color.FromArgb(240, 241, 242);
			rgbTable[KnownColors.PanelContentGradientEnd] = Color.FromArgb(240, 241, 242);
			rgbTable[KnownColors.PanelCaptionText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.PanelCollapsedCaptionText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.InnerBorderColor] = Color.FromArgb(185, 185, 185);
			rgbTable[KnownColors.XPanderPanelBackColor] = Color.FromArgb(240, 241, 242);
			rgbTable[KnownColors.XPanderPanelCaptionCloseIcon] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.XPanderPanelCaptionExpandIcon] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.XPanderPanelCaptionText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.XPanderPanelCaptionGradientBegin] = Color.FromArgb(155, 155, 155);
			rgbTable[KnownColors.XPanderPanelCaptionGradientEnd] = Color.FromArgb(47, 47, 47);
			rgbTable[KnownColors.XPanderPanelCaptionGradientMiddle] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.XPanderPanelFlatCaptionGradientBegin] = Color.FromArgb(90, 90, 90);
			rgbTable[KnownColors.XPanderPanelFlatCaptionGradientEnd] = Color.FromArgb(155, 155, 155);
		}
	}
}
