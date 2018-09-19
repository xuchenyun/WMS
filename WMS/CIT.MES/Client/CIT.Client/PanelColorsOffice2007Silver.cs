using System.Collections.Generic;
using System.Drawing;

namespace CIT.Client
{
	public class PanelColorsOffice2007Silver : PanelColorsOffice
	{
		public PanelColorsOffice2007Silver()
		{
		}

		public PanelColorsOffice2007Silver(BasePanel basePanel)
			: base(basePanel)
		{
		}

		protected override void InitColors(Dictionary<KnownColors, Color> rgbTable)
		{
			base.InitColors(rgbTable);
			rgbTable[KnownColors.BorderColor] = Color.FromArgb(111, 112, 116);
			rgbTable[KnownColors.InnerBorderColor] = Color.White;
			rgbTable[KnownColors.PanelCaptionCloseIcon] = Color.FromArgb(75, 79, 85);
			rgbTable[KnownColors.PanelCaptionExpandIcon] = Color.FromArgb(101, 104, 112);
			rgbTable[KnownColors.PanelCaptionGradientBegin] = Color.FromArgb(248, 248, 248);
			rgbTable[KnownColors.PanelCaptionGradientEnd] = Color.FromArgb(199, 203, 209);
			rgbTable[KnownColors.PanelCaptionGradientMiddle] = Color.FromArgb(218, 219, 231);
			rgbTable[KnownColors.PanelContentGradientBegin] = Color.FromArgb(240, 241, 242);
			rgbTable[KnownColors.PanelContentGradientEnd] = Color.FromArgb(240, 241, 242);
			rgbTable[KnownColors.PanelCaptionText] = Color.FromArgb(21, 66, 139);
			rgbTable[KnownColors.PanelCollapsedCaptionText] = Color.FromArgb(21, 66, 139);
			rgbTable[KnownColors.XPanderPanelBackColor] = Color.Transparent;
			rgbTable[KnownColors.XPanderPanelCaptionCloseIcon] = Color.FromArgb(75, 79, 85);
			rgbTable[KnownColors.XPanderPanelCaptionExpandIcon] = Color.FromArgb(101, 104, 112);
			rgbTable[KnownColors.XPanderPanelCaptionText] = Color.FromArgb(76, 83, 92);
			rgbTable[KnownColors.XPanderPanelCaptionGradientBegin] = Color.FromArgb(235, 238, 250);
			rgbTable[KnownColors.XPanderPanelCaptionGradientEnd] = Color.FromArgb(212, 216, 226);
			rgbTable[KnownColors.XPanderPanelCaptionGradientMiddle] = Color.FromArgb(197, 199, 209);
			rgbTable[KnownColors.XPanderPanelFlatCaptionGradientBegin] = Color.FromArgb(213, 219, 231);
			rgbTable[KnownColors.XPanderPanelFlatCaptionGradientEnd] = Color.FromArgb(253, 253, 254);
		}
	}
}
