using System.Collections.Generic;
using System.Drawing;

namespace CIT.Client
{
	public class PanelColorsOffice2007Black : PanelColorsOffice
	{
		public PanelColorsOffice2007Black()
		{
		}

		public PanelColorsOffice2007Black(BasePanel basePanel)
			: base(basePanel)
		{
		}

		protected override void InitColors(Dictionary<KnownColors, Color> rgbTable)
		{
			base.InitColors(rgbTable);
			rgbTable[KnownColors.BorderColor] = Color.FromArgb(76, 83, 92);
			rgbTable[KnownColors.InnerBorderColor] = Color.White;
			rgbTable[KnownColors.PanelCaptionCloseIcon] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.PanelCaptionExpandIcon] = Color.FromArgb(101, 104, 112);
			rgbTable[KnownColors.PanelCaptionGradientBegin] = Color.FromArgb(240, 241, 242);
			rgbTable[KnownColors.PanelCaptionGradientEnd] = Color.FromArgb(189, 193, 200);
			rgbTable[KnownColors.PanelCaptionGradientMiddle] = Color.FromArgb(216, 219, 223);
			rgbTable[KnownColors.PanelContentGradientBegin] = Color.FromArgb(240, 241, 242);
			rgbTable[KnownColors.PanelContentGradientEnd] = Color.FromArgb(240, 241, 242);
			rgbTable[KnownColors.PanelCaptionText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.PanelCollapsedCaptionText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.XPanderPanelBackColor] = Color.Transparent;
			rgbTable[KnownColors.XPanderPanelCaptionCloseIcon] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.XPanderPanelCaptionExpandIcon] = Color.FromArgb(101, 104, 112);
			rgbTable[KnownColors.XPanderPanelCaptionText] = Color.FromArgb(55, 60, 67);
			rgbTable[KnownColors.XPanderPanelCaptionGradientBegin] = Color.FromArgb(248, 248, 249);
			rgbTable[KnownColors.XPanderPanelCaptionGradientEnd] = Color.FromArgb(219, 222, 226);
			rgbTable[KnownColors.XPanderPanelCaptionGradientMiddle] = Color.FromArgb(200, 204, 209);
			rgbTable[KnownColors.XPanderPanelFlatCaptionGradientBegin] = Color.FromArgb(212, 215, 219);
			rgbTable[KnownColors.XPanderPanelFlatCaptionGradientEnd] = Color.FromArgb(253, 253, 254);
		}
	}
}
