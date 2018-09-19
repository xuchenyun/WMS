using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	public class ProfessionalColorTable : System.Windows.Forms.ProfessionalColorTable
	{
		public enum KnownColors
		{
			ButtonPressedBorder = 0,
			ButtonPressedGradientBegin = 1,
			ButtonPressedGradientEnd = 2,
			ButtonPressedGradientMiddle = 3,
			ButtonSelectedGradientBegin = 4,
			ButtonSelectedBorder = 5,
			ButtonSelectedGradientEnd = 6,
			ButtonSelectedGradientMiddle = 7,
			ButtonSelectedHighlightBorder = 8,
			CheckBackground = 9,
			CheckSelectedBackground = 10,
			GripDark = 11,
			GripLight = 12,
			ImageMarginGradientBegin = 13,
			MenuBorder = 14,
			MenuItemBorder = 0xF,
			MenuItemPressedGradientBegin = 0x10,
			MenuItemPressedGradientEnd = 17,
			MenuItemPressedGradientMiddle = 18,
			MenuItemSelected = 19,
			MenuItemSelectedGradientBegin = 20,
			MenuItemSelectedGradientEnd = 21,
			MenuItemText = 22,
			MenuItemTopLevelSelectedBorder = 23,
			MenuItemTopLevelSelectedGradientBegin = 24,
			MenuItemTopLevelSelectedGradientEnd = 25,
			MenuItemTopLevelSelectedGradientMiddle = 26,
			MenuStripGradientBegin = 27,
			MenuStripGradientEnd = 28,
			OverflowButtonGradientBegin = 29,
			OverflowButtonGradientEnd = 30,
			OverflowButtonGradientMiddle = 0x1F,
			RaftingContainerGradientBegin = 0x20,
			RaftingContainerGradientEnd = 33,
			SeparatorDark = 34,
			SeparatorLight = 35,
			StatusStripGradientBegin = 36,
			StatusStripGradientEnd = 37,
			StatusStripText = 38,
			ToolStripBorder = 39,
			ToolStripContentPanelGradientBegin = 40,
			ToolStripContentPanelGradientEnd = 41,
			ToolStripDropDownBackground = 42,
			ToolStripGradientBegin = 43,
			ToolStripGradientEnd = 44,
			ToolStripGradientMiddle = 45,
			ToolStripPanelGradientBegin = 46,
			ToolStripPanelGradientEnd = 47,
			ToolStripText = 48,
			LastKnownColor = 35
		}

		private Dictionary<KnownColors, Color> m_dictionaryRGBTable;

		private PanelColors m_panelColorTable;

		public override Color ButtonPressedBorder => FromKnownColor(KnownColors.ButtonPressedBorder);

		public override Color ButtonPressedGradientBegin => FromKnownColor(KnownColors.ButtonPressedGradientBegin);

		public override Color ButtonPressedGradientEnd => FromKnownColor(KnownColors.ButtonPressedGradientEnd);

		public override Color ButtonPressedGradientMiddle => FromKnownColor(KnownColors.ButtonPressedGradientMiddle);

		public override Color ButtonSelectedBorder => FromKnownColor(KnownColors.ButtonSelectedBorder);

		public override Color ButtonSelectedGradientBegin => FromKnownColor(KnownColors.ButtonSelectedGradientBegin);

		public override Color ButtonSelectedGradientEnd => FromKnownColor(KnownColors.ButtonSelectedGradientEnd);

		public override Color ButtonSelectedGradientMiddle => FromKnownColor(KnownColors.ButtonSelectedGradientMiddle);

		public override Color ButtonSelectedHighlightBorder => FromKnownColor(KnownColors.ButtonSelectedHighlightBorder);

		public override Color CheckBackground => FromKnownColor(KnownColors.CheckBackground);

		public override Color CheckSelectedBackground => FromKnownColor(KnownColors.CheckSelectedBackground);

		public override Color GripDark => FromKnownColor(KnownColors.GripDark);

		public override Color GripLight => FromKnownColor(KnownColors.GripLight);

		public override Color ImageMarginGradientBegin => FromKnownColor(KnownColors.ImageMarginGradientBegin);

		public override Color MenuBorder => FromKnownColor(KnownColors.MenuBorder);

		public override Color MenuItemBorder => FromKnownColor(KnownColors.MenuItemBorder);

		public override Color MenuItemPressedGradientBegin => FromKnownColor(KnownColors.MenuItemPressedGradientBegin);

		public override Color MenuItemPressedGradientEnd => FromKnownColor(KnownColors.MenuItemPressedGradientEnd);

		public override Color MenuItemPressedGradientMiddle => FromKnownColor(KnownColors.MenuItemPressedGradientMiddle);

		public override Color MenuItemSelected => FromKnownColor(KnownColors.MenuItemSelected);

		public virtual Color MenuItemText => FromKnownColor(KnownColors.MenuItemText);

		public virtual Color MenuItemTopLevelSelectedBorder => FromKnownColor(KnownColors.MenuItemTopLevelSelectedBorder);

		public virtual Color MenuItemTopLevelSelectedGradientBegin => FromKnownColor(KnownColors.MenuItemTopLevelSelectedGradientBegin);

		public virtual Color MenuItemTopLevelSelectedGradientEnd => FromKnownColor(KnownColors.MenuItemTopLevelSelectedGradientEnd);

		public virtual Color MenuItemTopLevelSelectedGradientMiddle => FromKnownColor(KnownColors.MenuItemTopLevelSelectedGradientMiddle);

		public override Color MenuItemSelectedGradientBegin => FromKnownColor(KnownColors.MenuItemSelectedGradientBegin);

		public override Color MenuItemSelectedGradientEnd => FromKnownColor(KnownColors.MenuItemSelectedGradientEnd);

		public override Color MenuStripGradientBegin => FromKnownColor(KnownColors.MenuStripGradientBegin);

		public override Color MenuStripGradientEnd => FromKnownColor(KnownColors.MenuStripGradientEnd);

		public override Color OverflowButtonGradientBegin => FromKnownColor(KnownColors.OverflowButtonGradientBegin);

		public override Color OverflowButtonGradientEnd => FromKnownColor(KnownColors.OverflowButtonGradientEnd);

		public override Color OverflowButtonGradientMiddle => FromKnownColor(KnownColors.OverflowButtonGradientMiddle);

		public override Color RaftingContainerGradientBegin => FromKnownColor(KnownColors.RaftingContainerGradientBegin);

		public override Color RaftingContainerGradientEnd => FromKnownColor(KnownColors.RaftingContainerGradientEnd);

		public override Color SeparatorDark => FromKnownColor(KnownColors.SeparatorDark);

		public override Color SeparatorLight => FromKnownColor(KnownColors.SeparatorLight);

		public override Color StatusStripGradientBegin => FromKnownColor(KnownColors.StatusStripGradientBegin);

		public override Color StatusStripGradientEnd => FromKnownColor(KnownColors.StatusStripGradientEnd);

		public virtual Color StatusStripText => FromKnownColor(KnownColors.StatusStripText);

		public override Color ToolStripBorder => FromKnownColor(KnownColors.ToolStripBorder);

		public override Color ToolStripContentPanelGradientBegin => FromKnownColor(KnownColors.ToolStripContentPanelGradientBegin);

		public override Color ToolStripContentPanelGradientEnd => FromKnownColor(KnownColors.ToolStripContentPanelGradientEnd);

		public override Color ToolStripDropDownBackground => FromKnownColor(KnownColors.ToolStripDropDownBackground);

		public override Color ToolStripGradientBegin => FromKnownColor(KnownColors.ToolStripGradientBegin);

		public override Color ToolStripGradientEnd => FromKnownColor(KnownColors.ToolStripGradientEnd);

		public override Color ToolStripGradientMiddle => FromKnownColor(KnownColors.ToolStripGradientMiddle);

		public override Color ToolStripPanelGradientBegin => FromKnownColor(KnownColors.ToolStripPanelGradientBegin);

		public override Color ToolStripPanelGradientEnd => FromKnownColor(KnownColors.ToolStripPanelGradientEnd);

		public virtual Color ToolStripText => FromKnownColor(KnownColors.ToolStripText);

		public virtual PanelColors PanelColorTable
		{
			get
			{
				if (m_panelColorTable == null)
				{
					m_panelColorTable = new PanelColors();
				}
				return m_panelColorTable;
			}
		}

		public new bool UseSystemColors
		{
			get
			{
				return base.UseSystemColors;
			}
			set
			{
				if (!value.Equals(base.UseSystemColors))
				{
					base.UseSystemColors = value;
					if (m_dictionaryRGBTable != null)
					{
						m_dictionaryRGBTable.Clear();
						m_dictionaryRGBTable = null;
					}
				}
			}
		}

		private Dictionary<KnownColors, Color> ColorTable
		{
			get
			{
				if (m_dictionaryRGBTable == null)
				{
					m_dictionaryRGBTable = new Dictionary<KnownColors, Color>(212);
					if (UseSystemColors || !ToolStripManager.VisualStylesEnabled)
					{
						InitBaseColors(m_dictionaryRGBTable);
					}
					else
					{
						InitColors(m_dictionaryRGBTable);
					}
				}
				return m_dictionaryRGBTable;
			}
		}

		internal Color FromKnownColor(KnownColors color)
		{
			return ColorTable[color];
		}

		protected virtual void InitColors(Dictionary<KnownColors, Color> rgbTable)
		{
			InitBaseColors(rgbTable);
		}

		private void InitBaseColors(Dictionary<KnownColors, Color> rgbTable)
		{
			rgbTable[KnownColors.ButtonPressedBorder] = base.ButtonPressedBorder;
			rgbTable[KnownColors.ButtonPressedGradientBegin] = base.ButtonPressedGradientBegin;
			rgbTable[KnownColors.ButtonPressedGradientEnd] = base.ButtonPressedGradientEnd;
			rgbTable[KnownColors.ButtonPressedGradientMiddle] = base.ButtonPressedGradientMiddle;
			rgbTable[KnownColors.ButtonSelectedBorder] = base.ButtonSelectedBorder;
			rgbTable[KnownColors.ButtonSelectedGradientBegin] = base.ButtonSelectedGradientBegin;
			rgbTable[KnownColors.ButtonSelectedGradientEnd] = base.ButtonSelectedGradientEnd;
			rgbTable[KnownColors.ButtonSelectedGradientMiddle] = base.ButtonSelectedGradientMiddle;
			rgbTable[KnownColors.ButtonSelectedHighlightBorder] = base.ButtonSelectedHighlightBorder;
			rgbTable[KnownColors.CheckBackground] = base.CheckBackground;
			rgbTable[KnownColors.CheckSelectedBackground] = base.CheckSelectedBackground;
			rgbTable[KnownColors.GripDark] = base.GripDark;
			rgbTable[KnownColors.GripLight] = base.GripLight;
			rgbTable[KnownColors.ImageMarginGradientBegin] = base.ImageMarginGradientBegin;
			rgbTable[KnownColors.MenuBorder] = base.MenuBorder;
			rgbTable[KnownColors.MenuItemBorder] = base.MenuItemBorder;
			rgbTable[KnownColors.MenuItemPressedGradientBegin] = base.MenuItemPressedGradientBegin;
			rgbTable[KnownColors.MenuItemPressedGradientEnd] = base.MenuItemPressedGradientEnd;
			rgbTable[KnownColors.MenuItemPressedGradientMiddle] = base.MenuItemPressedGradientMiddle;
			rgbTable[KnownColors.MenuItemSelected] = base.MenuItemSelected;
			rgbTable[KnownColors.MenuItemSelectedGradientBegin] = base.MenuItemSelectedGradientBegin;
			rgbTable[KnownColors.MenuItemSelectedGradientEnd] = base.MenuItemSelectedGradientEnd;
			rgbTable[KnownColors.MenuItemText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.MenuItemTopLevelSelectedBorder] = base.MenuItemBorder;
			rgbTable[KnownColors.MenuItemTopLevelSelectedGradientBegin] = base.MenuItemSelected;
			rgbTable[KnownColors.MenuItemTopLevelSelectedGradientEnd] = base.MenuItemSelected;
			rgbTable[KnownColors.MenuItemTopLevelSelectedGradientMiddle] = base.MenuItemSelected;
			rgbTable[KnownColors.MenuStripGradientBegin] = base.MenuStripGradientBegin;
			rgbTable[KnownColors.MenuStripGradientEnd] = base.MenuStripGradientEnd;
			rgbTable[KnownColors.OverflowButtonGradientBegin] = base.OverflowButtonGradientBegin;
			rgbTable[KnownColors.OverflowButtonGradientEnd] = base.OverflowButtonGradientEnd;
			rgbTable[KnownColors.OverflowButtonGradientMiddle] = base.OverflowButtonGradientMiddle;
			rgbTable[KnownColors.RaftingContainerGradientBegin] = base.RaftingContainerGradientBegin;
			rgbTable[KnownColors.RaftingContainerGradientEnd] = base.RaftingContainerGradientEnd;
			rgbTable[KnownColors.SeparatorDark] = base.SeparatorDark;
			rgbTable[KnownColors.SeparatorLight] = base.SeparatorLight;
			rgbTable[KnownColors.StatusStripGradientBegin] = base.StatusStripGradientEnd;
			rgbTable[KnownColors.StatusStripGradientEnd] = base.StatusStripGradientBegin;
			rgbTable[KnownColors.StatusStripText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.ToolStripBorder] = base.ToolStripBorder;
			rgbTable[KnownColors.ToolStripContentPanelGradientBegin] = base.ToolStripContentPanelGradientBegin;
			rgbTable[KnownColors.ToolStripContentPanelGradientEnd] = base.ToolStripContentPanelGradientEnd;
			rgbTable[KnownColors.ToolStripDropDownBackground] = base.ToolStripDropDownBackground;
			rgbTable[KnownColors.ToolStripGradientBegin] = base.ToolStripGradientBegin;
			rgbTable[KnownColors.ToolStripGradientEnd] = base.ToolStripGradientEnd;
			rgbTable[KnownColors.ToolStripGradientMiddle] = base.ToolStripGradientMiddle;
			rgbTable[KnownColors.ToolStripPanelGradientBegin] = base.ToolStripPanelGradientBegin;
			rgbTable[KnownColors.ToolStripPanelGradientEnd] = base.ToolStripPanelGradientEnd;
			rgbTable[KnownColors.ToolStripText] = Color.FromArgb(0, 0, 0);
		}
	}
}
