using System.Collections.Generic;
using System.Drawing;

namespace CIT.Client
{
	public class PanelColorsOffice2007Blue : PanelColorsOffice
	{
		public PanelColorsOffice2007Blue()
		{
		}

		public PanelColorsOffice2007Blue(BasePanel basePanel)
			: base(basePanel)
		{
		}

		protected override void InitColors(Dictionary<KnownColors, Color> rgbTable)
		{
			base.InitColors(rgbTable);
			rgbTable[KnownColors.BorderColor] = Color.FromArgb(101, 147, 207);
			rgbTable[KnownColors.InnerBorderColor] = Color.White;
			rgbTable[KnownColors.PanelCaptionCloseIcon] = Color.Black;
			rgbTable[KnownColors.PanelCaptionExpandIcon] = Color.FromArgb(21, 66, 139);
			rgbTable[KnownColors.PanelCaptionGradientBegin] = Color.FromArgb(227, 239, 255);
			rgbTable[KnownColors.PanelCaptionGradientEnd] = Color.FromArgb(173, 209, 255);
			rgbTable[KnownColors.PanelCaptionGradientMiddle] = Color.FromArgb(199, 224, 255);
			rgbTable[KnownColors.PanelContentGradientBegin] = Color.FromArgb(227, 239, 255);
			rgbTable[KnownColors.PanelContentGradientEnd] = Color.FromArgb(227, 239, 255);
			rgbTable[KnownColors.PanelCaptionText] = Color.FromArgb(22, 65, 139);
			rgbTable[KnownColors.PanelCollapsedCaptionText] = Color.FromArgb(21, 66, 139);
			rgbTable[KnownColors.XPanderPanelBackColor] = SkinManager.CurrentSkin.BaseColor;
			rgbTable[KnownColors.XPanderPanelCaptionCloseIcon] = Color.Red;
			rgbTable[KnownColors.XPanderPanelCaptionExpandIcon] = Color.FromArgb(21, 66, 139);
			rgbTable[KnownColors.XPanderPanelCaptionText] = Color.FromArgb(21, 66, 139);
			rgbTable[KnownColors.XPanderPanelCaptionGradientBegin] = Color.FromArgb(227, 239, 255);
			rgbTable[KnownColors.XPanderPanelCaptionGradientEnd] = Color.FromArgb(199, 224, 255);
			rgbTable[KnownColors.XPanderPanelCaptionGradientMiddle] = Color.FromArgb(173, 209, 255);
			rgbTable[KnownColors.XPanderPanelFlatCaptionGradientBegin] = Color.FromArgb(214, 232, 255);
			rgbTable[KnownColors.XPanderPanelFlatCaptionGradientEnd] = Color.FromArgb(253, 253, 254);
		}
	}
}
