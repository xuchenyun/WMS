using System.Collections.Generic;
using System.Drawing;

namespace CIT.Client
{
	public class PanelColorsBse : PanelColors
	{
		public override PanelStyle PanelStyle => PanelStyle.Office2007;

		public PanelColorsBse()
		{
		}

		public PanelColorsBse(BasePanel basePanel)
			: base(basePanel)
		{
		}

		protected override void InitColors(Dictionary<KnownColors, Color> rgbTable)
		{
			base.InitColors(rgbTable);
			rgbTable[KnownColors.PanelCaptionSelectedGradientBegin] = Color.FromArgb(156, 163, 254);
			rgbTable[KnownColors.PanelCaptionSelectedGradientEnd] = Color.FromArgb(90, 98, 254);
			rgbTable[KnownColors.XPanderPanelCheckedCaptionBegin] = Color.FromArgb(136, 144, 254);
			rgbTable[KnownColors.XPanderPanelCheckedCaptionEnd] = Color.FromArgb(111, 145, 255);
			rgbTable[KnownColors.XPanderPanelCheckedCaptionMiddle] = Color.FromArgb(42, 52, 254);
			rgbTable[KnownColors.XPanderPanelPressedCaptionBegin] = Color.FromArgb(106, 109, 228);
			rgbTable[KnownColors.XPanderPanelPressedCaptionEnd] = Color.FromArgb(88, 111, 226);
			rgbTable[KnownColors.XPanderPanelPressedCaptionMiddle] = Color.FromArgb(39, 39, 217);
			rgbTable[KnownColors.XPanderPanelSelectedCaptionBegin] = Color.FromArgb(156, 163, 254);
			rgbTable[KnownColors.XPanderPanelSelectedCaptionEnd] = Color.FromArgb(139, 164, 255);
			rgbTable[KnownColors.XPanderPanelSelectedCaptionMiddle] = Color.FromArgb(90, 98, 254);
			rgbTable[KnownColors.XPanderPanelSelectedCaptionText] = Color.White;
		}
	}
}
