using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	public class PanelColors
	{
		public enum KnownColors
		{
			BorderColor,
			PanelCaptionCloseIcon,
			PanelCaptionExpandIcon,
			PanelCaptionGradientBegin,
			PanelCaptionGradientEnd,
			PanelCaptionGradientMiddle,
			PanelCaptionSelectedGradientBegin,
			PanelCaptionSelectedGradientEnd,
			PanelContentGradientBegin,
			PanelContentGradientEnd,
			PanelCaptionText,
			PanelCollapsedCaptionText,
			InnerBorderColor,
			XPanderPanelBackColor,
			XPanderPanelCaptionCloseIcon,
			XPanderPanelCaptionExpandIcon,
			XPanderPanelCaptionText,
			XPanderPanelCaptionGradientBegin,
			XPanderPanelCaptionGradientEnd,
			XPanderPanelCaptionGradientMiddle,
			XPanderPanelFlatCaptionGradientBegin,
			XPanderPanelFlatCaptionGradientEnd,
			XPanderPanelPressedCaptionBegin,
			XPanderPanelPressedCaptionEnd,
			XPanderPanelPressedCaptionMiddle,
			XPanderPanelCheckedCaptionBegin,
			XPanderPanelCheckedCaptionEnd,
			XPanderPanelCheckedCaptionMiddle,
			XPanderPanelSelectedCaptionBegin,
			XPanderPanelSelectedCaptionEnd,
			XPanderPanelSelectedCaptionMiddle,
			XPanderPanelSelectedCaptionText
		}

		private BasePanel m_basePanel;

		private System.Windows.Forms.ProfessionalColorTable m_professionalColorTable;

		private Dictionary<KnownColors, Color> m_dictionaryRGBTable;

		private bool m_bUseSystemColors;

		public virtual Color BorderColor => FromKnownColor(KnownColors.BorderColor);

		public virtual Color PanelCaptionCloseIcon => FromKnownColor(KnownColors.PanelCaptionCloseIcon);

		public virtual Color PanelCaptionExpandIcon => FromKnownColor(KnownColors.PanelCaptionExpandIcon);

		public virtual Color PanelCaptionGradientBegin => FromKnownColor(KnownColors.PanelCaptionGradientBegin);

		public virtual Color PanelCaptionGradientEnd => FromKnownColor(KnownColors.PanelCaptionGradientEnd);

		public virtual Color PanelCaptionGradientMiddle => FromKnownColor(KnownColors.PanelCaptionGradientMiddle);

		public virtual Color PanelCaptionSelectedGradientBegin => FromKnownColor(KnownColors.PanelCaptionSelectedGradientBegin);

		public virtual Color PanelCaptionSelectedGradientEnd => FromKnownColor(KnownColors.PanelCaptionSelectedGradientEnd);

		public virtual Color PanelCaptionText => FromKnownColor(KnownColors.PanelCaptionText);

		public virtual Color PanelCollapsedCaptionText => FromKnownColor(KnownColors.PanelCollapsedCaptionText);

		public virtual Color PanelContentGradientBegin => FromKnownColor(KnownColors.PanelContentGradientBegin);

		public virtual Color PanelContentGradientEnd => FromKnownColor(KnownColors.PanelContentGradientEnd);

		public virtual Color InnerBorderColor => FromKnownColor(KnownColors.InnerBorderColor);

		public virtual Color XPanderPanelBackColor => FromKnownColor(KnownColors.XPanderPanelBackColor);

		public virtual Color XPanderPanelCaptionCloseIcon => FromKnownColor(KnownColors.XPanderPanelCaptionCloseIcon);

		public virtual Color XPanderPanelCaptionExpandIcon => FromKnownColor(KnownColors.XPanderPanelCaptionExpandIcon);

		public virtual Color XPanderPanelCaptionGradientBegin => FromKnownColor(KnownColors.XPanderPanelCaptionGradientBegin);

		public virtual Color XPanderPanelCaptionGradientEnd => FromKnownColor(KnownColors.XPanderPanelCaptionGradientEnd);

		public virtual Color XPanderPanelCaptionGradientMiddle => FromKnownColor(KnownColors.XPanderPanelCaptionGradientMiddle);

		public virtual Color XPanderPanelCaptionText => FromKnownColor(KnownColors.XPanderPanelCaptionText);

		public virtual Color XPanderPanelFlatCaptionGradientBegin => FromKnownColor(KnownColors.XPanderPanelFlatCaptionGradientBegin);

		public virtual Color XPanderPanelFlatCaptionGradientEnd => FromKnownColor(KnownColors.XPanderPanelFlatCaptionGradientEnd);

		public virtual Color XPanderPanelPressedCaptionBegin => FromKnownColor(KnownColors.XPanderPanelPressedCaptionBegin);

		public virtual Color XPanderPanelPressedCaptionEnd => FromKnownColor(KnownColors.XPanderPanelPressedCaptionEnd);

		public virtual Color XPanderPanelPressedCaptionMiddle => FromKnownColor(KnownColors.XPanderPanelPressedCaptionMiddle);

		public virtual Color XPanderPanelCheckedCaptionBegin => FromKnownColor(KnownColors.XPanderPanelCheckedCaptionBegin);

		public virtual Color XPanderPanelCheckedCaptionEnd => FromKnownColor(KnownColors.XPanderPanelCheckedCaptionEnd);

		public virtual Color XPanderPanelCheckedCaptionMiddle => FromKnownColor(KnownColors.XPanderPanelCheckedCaptionMiddle);

		public virtual Color XPanderPanelSelectedCaptionBegin => FromKnownColor(KnownColors.XPanderPanelSelectedCaptionBegin);

		public virtual Color XPanderPanelSelectedCaptionEnd => FromKnownColor(KnownColors.XPanderPanelSelectedCaptionEnd);

		public virtual Color XPanderPanelSelectedCaptionMiddle => FromKnownColor(KnownColors.XPanderPanelSelectedCaptionMiddle);

		public virtual Color XPanderPanelSelectedCaptionText => FromKnownColor(KnownColors.XPanderPanelSelectedCaptionText);

		public virtual PanelStyle PanelStyle => PanelStyle.Default;

		public bool UseSystemColors
		{
			get
			{
				return m_bUseSystemColors;
			}
			set
			{
				if (!value.Equals(m_bUseSystemColors))
				{
					m_bUseSystemColors = value;
					m_professionalColorTable.UseSystemColors = m_bUseSystemColors;
					Clear();
				}
			}
		}

		public BasePanel Panel
		{
			get
			{
				return m_basePanel;
			}
			set
			{
				m_basePanel = value;
			}
		}

		private Dictionary<KnownColors, Color> ColorTable
		{
			get
			{
				if (m_dictionaryRGBTable == null)
				{
					m_dictionaryRGBTable = new Dictionary<KnownColors, Color>(212);
					if (m_basePanel != null && m_basePanel.ColorScheme == ColorScheme.Professional)
					{
						if (m_bUseSystemColors || !ToolStripManager.VisualStylesEnabled)
						{
							InitBaseColors(m_dictionaryRGBTable);
						}
						else
						{
							InitColors(m_dictionaryRGBTable);
						}
					}
					else
					{
						InitCustomColors(m_dictionaryRGBTable);
					}
				}
				return m_dictionaryRGBTable;
			}
		}

		internal Color FromKnownColor(KnownColors color)
		{
			return ColorTable[color];
		}

		public PanelColors()
		{
			m_professionalColorTable = new System.Windows.Forms.ProfessionalColorTable();
		}

		public PanelColors(BasePanel basePanel)
			: this()
		{
			m_basePanel = basePanel;
		}

		public void Clear()
		{
			ResetRGBTable();
		}

		protected virtual void InitColors(Dictionary<KnownColors, Color> rgbTable)
		{
			InitBaseColors(rgbTable);
		}

		private void InitBaseColors(Dictionary<KnownColors, Color> rgbTable)
		{
			rgbTable[KnownColors.BorderColor] = m_professionalColorTable.GripDark;
			rgbTable[KnownColors.InnerBorderColor] = m_professionalColorTable.GripLight;
			rgbTable[KnownColors.PanelCaptionCloseIcon] = SystemColors.ControlText;
			rgbTable[KnownColors.PanelCaptionExpandIcon] = SystemColors.ControlText;
			rgbTable[KnownColors.PanelCaptionGradientBegin] = m_professionalColorTable.ToolStripGradientBegin;
			rgbTable[KnownColors.PanelCaptionGradientEnd] = m_professionalColorTable.ToolStripGradientEnd;
			rgbTable[KnownColors.PanelCaptionGradientMiddle] = m_professionalColorTable.ToolStripGradientMiddle;
			rgbTable[KnownColors.PanelCaptionSelectedGradientBegin] = m_professionalColorTable.ButtonSelectedGradientBegin;
			rgbTable[KnownColors.PanelCaptionSelectedGradientEnd] = m_professionalColorTable.ButtonSelectedGradientEnd;
			rgbTable[KnownColors.PanelContentGradientBegin] = SkinManager.CurrentSkin.BaseColor;
			rgbTable[KnownColors.PanelContentGradientEnd] = m_professionalColorTable.ToolStripContentPanelGradientEnd;
			rgbTable[KnownColors.PanelCaptionText] = SystemColors.ControlText;
			rgbTable[KnownColors.PanelCollapsedCaptionText] = SystemColors.ControlText;
			rgbTable[KnownColors.XPanderPanelBackColor] = m_professionalColorTable.ToolStripContentPanelGradientBegin;
			rgbTable[KnownColors.XPanderPanelCaptionCloseIcon] = SystemColors.ControlText;
			rgbTable[KnownColors.XPanderPanelCaptionExpandIcon] = SystemColors.ControlText;
			rgbTable[KnownColors.XPanderPanelCaptionText] = SystemColors.ControlText;
			rgbTable[KnownColors.XPanderPanelCaptionGradientBegin] = m_professionalColorTable.ToolStripGradientBegin;
			rgbTable[KnownColors.XPanderPanelCaptionGradientEnd] = m_professionalColorTable.ToolStripGradientEnd;
			rgbTable[KnownColors.XPanderPanelCaptionGradientMiddle] = m_professionalColorTable.ToolStripGradientMiddle;
			rgbTable[KnownColors.XPanderPanelFlatCaptionGradientBegin] = m_professionalColorTable.ToolStripGradientMiddle;
			rgbTable[KnownColors.XPanderPanelFlatCaptionGradientEnd] = m_professionalColorTable.ToolStripGradientBegin;
			rgbTable[KnownColors.XPanderPanelPressedCaptionBegin] = m_professionalColorTable.ButtonPressedGradientBegin;
			rgbTable[KnownColors.XPanderPanelPressedCaptionEnd] = m_professionalColorTable.ButtonPressedGradientEnd;
			rgbTable[KnownColors.XPanderPanelPressedCaptionMiddle] = m_professionalColorTable.ButtonPressedGradientMiddle;
			rgbTable[KnownColors.XPanderPanelCheckedCaptionBegin] = m_professionalColorTable.ButtonCheckedGradientBegin;
			rgbTable[KnownColors.XPanderPanelCheckedCaptionEnd] = m_professionalColorTable.ButtonCheckedGradientEnd;
			rgbTable[KnownColors.XPanderPanelCheckedCaptionMiddle] = m_professionalColorTable.ButtonCheckedGradientMiddle;
			rgbTable[KnownColors.XPanderPanelSelectedCaptionBegin] = m_professionalColorTable.ButtonSelectedGradientBegin;
			rgbTable[KnownColors.XPanderPanelSelectedCaptionEnd] = m_professionalColorTable.ButtonSelectedGradientEnd;
			rgbTable[KnownColors.XPanderPanelSelectedCaptionMiddle] = m_professionalColorTable.ButtonSelectedGradientMiddle;
			rgbTable[KnownColors.XPanderPanelSelectedCaptionText] = SystemColors.ControlText;
		}

		private void InitCustomColors(Dictionary<KnownColors, Color> rgbTable)
		{
			TXPanelFrame tXPanelFrame = m_basePanel as TXPanelFrame;
			if (tXPanelFrame != null)
			{
				rgbTable[KnownColors.BorderColor] = tXPanelFrame.CustomColors.BorderColor;
				rgbTable[KnownColors.InnerBorderColor] = tXPanelFrame.CustomColors.InnerBorderColor;
				rgbTable[KnownColors.PanelCaptionCloseIcon] = tXPanelFrame.CustomColors.CaptionCloseIcon;
				rgbTable[KnownColors.PanelCaptionExpandIcon] = tXPanelFrame.CustomColors.CaptionExpandIcon;
				rgbTable[KnownColors.PanelCaptionGradientBegin] = tXPanelFrame.CustomColors.CaptionGradientBegin;
				rgbTable[KnownColors.PanelCaptionGradientEnd] = tXPanelFrame.CustomColors.CaptionGradientEnd;
				rgbTable[KnownColors.PanelCaptionGradientMiddle] = tXPanelFrame.CustomColors.CaptionGradientMiddle;
				rgbTable[KnownColors.PanelCaptionSelectedGradientBegin] = tXPanelFrame.CustomColors.CaptionSelectedGradientBegin;
				rgbTable[KnownColors.PanelCaptionSelectedGradientEnd] = tXPanelFrame.CustomColors.CaptionSelectedGradientEnd;
				rgbTable[KnownColors.PanelContentGradientBegin] = tXPanelFrame.CustomColors.ContentGradientBegin;
				rgbTable[KnownColors.PanelContentGradientEnd] = tXPanelFrame.CustomColors.ContentGradientEnd;
				rgbTable[KnownColors.PanelCaptionText] = tXPanelFrame.CustomColors.CaptionText;
				rgbTable[KnownColors.PanelCollapsedCaptionText] = tXPanelFrame.CustomColors.CollapsedCaptionText;
			}
			XPanderPanel xPanderPanel = m_basePanel as XPanderPanel;
			if (xPanderPanel != null)
			{
				rgbTable[KnownColors.BorderColor] = xPanderPanel.CustomColors.BorderColor;
				rgbTable[KnownColors.InnerBorderColor] = xPanderPanel.CustomColors.InnerBorderColor;
				rgbTable[KnownColors.XPanderPanelBackColor] = xPanderPanel.CustomColors.BackColor;
				rgbTable[KnownColors.XPanderPanelCaptionCloseIcon] = xPanderPanel.CustomColors.CaptionCloseIcon;
				rgbTable[KnownColors.XPanderPanelCaptionExpandIcon] = xPanderPanel.CustomColors.CaptionExpandIcon;
				rgbTable[KnownColors.XPanderPanelCaptionText] = xPanderPanel.CustomColors.CaptionText;
				rgbTable[KnownColors.XPanderPanelCaptionGradientBegin] = xPanderPanel.CustomColors.CaptionGradientBegin;
				rgbTable[KnownColors.XPanderPanelCaptionGradientEnd] = xPanderPanel.CustomColors.CaptionGradientEnd;
				rgbTable[KnownColors.XPanderPanelCaptionGradientMiddle] = xPanderPanel.CustomColors.CaptionGradientMiddle;
				rgbTable[KnownColors.XPanderPanelFlatCaptionGradientBegin] = xPanderPanel.CustomColors.FlatCaptionGradientBegin;
				rgbTable[KnownColors.XPanderPanelFlatCaptionGradientEnd] = xPanderPanel.CustomColors.FlatCaptionGradientEnd;
				rgbTable[KnownColors.XPanderPanelPressedCaptionBegin] = xPanderPanel.CustomColors.CaptionPressedGradientBegin;
				rgbTable[KnownColors.XPanderPanelPressedCaptionEnd] = xPanderPanel.CustomColors.CaptionPressedGradientEnd;
				rgbTable[KnownColors.XPanderPanelPressedCaptionMiddle] = xPanderPanel.CustomColors.CaptionPressedGradientMiddle;
				rgbTable[KnownColors.XPanderPanelCheckedCaptionBegin] = xPanderPanel.CustomColors.CaptionCheckedGradientBegin;
				rgbTable[KnownColors.XPanderPanelCheckedCaptionEnd] = xPanderPanel.CustomColors.CaptionCheckedGradientEnd;
				rgbTable[KnownColors.XPanderPanelCheckedCaptionMiddle] = xPanderPanel.CustomColors.CaptionCheckedGradientMiddle;
				rgbTable[KnownColors.XPanderPanelSelectedCaptionBegin] = xPanderPanel.CustomColors.CaptionSelectedGradientBegin;
				rgbTable[KnownColors.XPanderPanelSelectedCaptionEnd] = xPanderPanel.CustomColors.CaptionSelectedGradientEnd;
				rgbTable[KnownColors.XPanderPanelSelectedCaptionMiddle] = xPanderPanel.CustomColors.CaptionSelectedGradientMiddle;
				rgbTable[KnownColors.XPanderPanelSelectedCaptionText] = xPanderPanel.CustomColors.CaptionSelectedText;
			}
		}

		private void ResetRGBTable()
		{
			if (m_dictionaryRGBTable != null)
			{
				m_dictionaryRGBTable.Clear();
			}
			m_dictionaryRGBTable = null;
		}
	}
}
