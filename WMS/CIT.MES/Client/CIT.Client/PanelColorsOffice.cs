using System.Collections.Generic;
using System.Drawing;

namespace CIT.Client
{
	public class PanelColorsOffice : PanelColors
	{
		public override PanelStyle PanelStyle => PanelStyle.Office2007;

		public PanelColorsOffice()
		{
		}

		public PanelColorsOffice(BasePanel basePanel)
			: base(basePanel)
		{
		}

		protected override void InitColors(Dictionary<KnownColors, Color> rgbTable)
		{
			base.InitColors(rgbTable);
			rgbTable[KnownColors.PanelCaptionSelectedGradientBegin] = Color.FromArgb(255, 255, 220);
			rgbTable[KnownColors.PanelCaptionSelectedGradientEnd] = Color.FromArgb(247, 193, 94);
			rgbTable[KnownColors.XPanderPanelCheckedCaptionBegin] = Color.FromArgb(255, 217, 170);
			rgbTable[KnownColors.XPanderPanelCheckedCaptionEnd] = Color.FromArgb(254, 225, 122);
			rgbTable[KnownColors.XPanderPanelCheckedCaptionMiddle] = Color.FromArgb(255, 171, 63);
			rgbTable[KnownColors.XPanderPanelPressedCaptionBegin] = Color.FromArgb(255, 189, 105);
			rgbTable[KnownColors.XPanderPanelPressedCaptionEnd] = Color.FromArgb(254, 211, 100);
			rgbTable[KnownColors.XPanderPanelPressedCaptionMiddle] = Color.FromArgb(251, 140, 60);
			rgbTable[KnownColors.XPanderPanelSelectedCaptionBegin] = Color.FromArgb(255, 252, 222);
			rgbTable[KnownColors.XPanderPanelSelectedCaptionEnd] = Color.FromArgb(255, 230, 158);
			rgbTable[KnownColors.XPanderPanelSelectedCaptionMiddle] = Color.FromArgb(255, 215, 103);
			rgbTable[KnownColors.XPanderPanelSelectedCaptionText] = Color.Black;
		}
	}
}
