using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CIT.Client.Docking
{
	internal class VS2005DockPaneStrip : DockPaneStripBase
	{
		private class TabVS2005 : Tab
		{
			private int m_tabX;

			private int m_tabWidth;

			private int m_maxWidth;

			private bool m_flag;

			public int TabX
			{
				get
				{
					return m_tabX;
				}
				set
				{
					m_tabX = value;
				}
			}

			public int TabWidth
			{
				get
				{
					return m_tabWidth;
				}
				set
				{
					m_tabWidth = value;
				}
			}

			public int MaxWidth
			{
				get
				{
					return m_maxWidth;
				}
				set
				{
					m_maxWidth = value;
				}
			}

			protected internal bool Flag
			{
				get
				{
					return m_flag;
				}
				set
				{
					m_flag = value;
				}
			}

			public TabVS2005(IDockContent content)
				: base(content)
			{
			}
		}

		private sealed class InertButton : InertButtonBase
		{
			private Bitmap m_image0;

			private Bitmap m_image1;

			private int m_imageCategory = 0;

			public int ImageCategory
			{
				get
				{
					return m_imageCategory;
				}
				set
				{
					if (m_imageCategory != value)
					{
						m_imageCategory = value;
						Invalidate();
					}
				}
			}

			public override Bitmap Image => (ImageCategory == 0) ? m_image0 : m_image1;

			public InertButton(Bitmap image0, Bitmap image1)
			{
				m_image0 = image0;
				m_image1 = image1;
			}
		}

		private const int _ToolWindowStripGapTop = 0;

		private const int _ToolWindowStripGapBottom = 1;

		private const int _ToolWindowStripGapLeft = 0;

		private const int _ToolWindowStripGapRight = 0;

		private const int _ToolWindowImageHeight = 16;

		private const int _ToolWindowImageWidth = 16;

		private const int _ToolWindowImageGapTop = 3;

		private const int _ToolWindowImageGapBottom = 1;

		private const int _ToolWindowImageGapLeft = 2;

		private const int _ToolWindowImageGapRight = 0;

		private const int _ToolWindowTextGapRight = 3;

		private const int _ToolWindowTabSeperatorGapTop = 3;

		private const int _ToolWindowTabSeperatorGapBottom = 3;

		private const int _DocumentStripGapTop = 0;

		private const int _DocumentStripGapBottom = 1;

		private const int _DocumentTabMaxWidth = 200;

		private const int _DocumentButtonGapTop = 4;

		private const int _DocumentButtonGapBottom = 4;

		private const int _DocumentButtonGapBetween = 0;

		private const int _DocumentButtonGapRight = 3;

		private const int _DocumentTabGapTop = 3;

		private const int _DocumentTabGapLeft = 3;

		private const int _DocumentTabGapRight = 3;

		private const int _DocumentIconGapBottom = 2;

		private const int _DocumentIconGapLeft = 8;

		private const int _DocumentIconGapRight = 0;

		private const int _DocumentIconHeight = 16;

		private const int _DocumentIconWidth = 16;

		private const int _DocumentTextGapRight = 3;

		private static Bitmap _imageButtonClose;

		private InertButton m_buttonClose;

		private static Bitmap _imageButtonWindowList;

		private static Bitmap _imageButtonWindowListOverflow;

		private InertButton m_buttonWindowList;

		private IContainer m_components;

		private ToolTip m_toolTip;

		private static string _toolTipClose;

		private static string _toolTipSelect;

		private Font m_font;

		private Font m_boldFont;

		private int m_startDisplayingTab = 0;

		private int m_endDisplayingTab = 0;

		private int m_firstDisplayingTab = 0;

		private bool m_documentTabsOverflow = false;

		private ContextMenuStrip m_selectMenu;

		private static Bitmap ImageButtonClose
		{
			get
			{
				if (_imageButtonClose == null)
				{
					_imageButtonClose = Resources.DockPane_Close;
				}
				return _imageButtonClose;
			}
		}

		private InertButton ButtonClose
		{
			get
			{
				if (m_buttonClose == null)
				{
					m_buttonClose = new InertButton(ImageButtonClose, ImageButtonClose);
					m_toolTip.SetToolTip(m_buttonClose, ToolTipClose);
					m_buttonClose.Click += Close_Click;
					base.Controls.Add(m_buttonClose);
				}
				return m_buttonClose;
			}
		}

		private static Bitmap ImageButtonWindowList
		{
			get
			{
				if (_imageButtonWindowList == null)
				{
					_imageButtonWindowList = Resources.DockPane_Option;
				}
				return _imageButtonWindowList;
			}
		}

		private static Bitmap ImageButtonWindowListOverflow
		{
			get
			{
				if (_imageButtonWindowListOverflow == null)
				{
					_imageButtonWindowListOverflow = Resources.DockPane_OptionOverflow;
				}
				return _imageButtonWindowListOverflow;
			}
		}

		private InertButton ButtonWindowList
		{
			get
			{
				if (m_buttonWindowList == null)
				{
					m_buttonWindowList = new InertButton(ImageButtonWindowList, ImageButtonWindowListOverflow);
					m_toolTip.SetToolTip(m_buttonWindowList, ToolTipSelect);
					m_buttonWindowList.Click += WindowList_Click;
					base.Controls.Add(m_buttonWindowList);
				}
				return m_buttonWindowList;
			}
		}

		private static GraphicsPath GraphicsPath => VS2005AutoHideStrip.GraphicsPath;

		private IContainer Components => m_components;

		private static int ToolWindowStripGapTop => 0;

		private static int ToolWindowStripGapBottom => 1;

		private static int ToolWindowStripGapLeft => 0;

		private static int ToolWindowStripGapRight => 0;

		private static int ToolWindowImageHeight => 16;

		private static int ToolWindowImageWidth => 16;

		private static int ToolWindowImageGapTop => 3;

		private static int ToolWindowImageGapBottom => 1;

		private static int ToolWindowImageGapLeft => 2;

		private static int ToolWindowImageGapRight => 0;

		private static int ToolWindowTextGapRight => 3;

		private static int ToolWindowTabSeperatorGapTop => 3;

		private static int ToolWindowTabSeperatorGapBottom => 3;

		private static string ToolTipClose
		{
			get
			{
				if (_toolTipClose == null)
				{
					_toolTipClose = Strings.DockPaneStrip_ToolTipClose;
				}
				return _toolTipClose;
			}
		}

		private static string ToolTipSelect
		{
			get
			{
				if (_toolTipSelect == null)
				{
					_toolTipSelect = Strings.DockPaneStrip_ToolTipWindowList;
				}
				return _toolTipSelect;
			}
		}

		private TextFormatFlags ToolWindowTextFormat
		{
			get
			{
				TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter;
				if (RightToLeft == RightToLeft.Yes)
				{
					return textFormatFlags | TextFormatFlags.RightToLeft | TextFormatFlags.Right;
				}
				return textFormatFlags;
			}
		}

		private static int DocumentStripGapTop => 0;

		private static int DocumentStripGapBottom => 1;

		private TextFormatFlags DocumentTextFormat
		{
			get
			{
				TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter;
				if (RightToLeft == RightToLeft.Yes)
				{
					return textFormatFlags | TextFormatFlags.RightToLeft;
				}
				return textFormatFlags;
			}
		}

		private static int DocumentTabMaxWidth => 200;

		private static int DocumentButtonGapTop => 4;

		private static int DocumentButtonGapBottom => 4;

		private static int DocumentButtonGapBetween => 0;

		private static int DocumentButtonGapRight => 3;

		private static int DocumentTabGapTop => 3;

		private static int DocumentTabGapLeft => 3;

		private static int DocumentTabGapRight => 3;

		private static int DocumentIconGapBottom => 2;

		private static int DocumentIconGapLeft => 8;

		private static int DocumentIconGapRight => 0;

		private static int DocumentIconWidth => 16;

		private static int DocumentIconHeight => 16;

		private static int DocumentTextGapRight => 3;

		private static Pen PenToolWindowTabBorder => SystemPens.GrayText;

		private static Pen PenDocumentTabActiveBorder => SystemPens.ControlDarkDark;

		private static Pen PenDocumentTabInactiveBorder => SystemPens.GrayText;

		private static Font TextFont => SystemInformation.MenuFont;

		private Font BoldFont
		{
			get
			{
				if (base.IsDisposed)
				{
					return null;
				}
				if (m_boldFont == null)
				{
					m_font = TextFont;
					m_boldFont = new Font(TextFont, FontStyle.Bold);
				}
				else if (m_font != TextFont)
				{
					m_boldFont.Dispose();
					m_font = TextFont;
					m_boldFont = new Font(TextFont, FontStyle.Bold);
				}
				return m_boldFont;
			}
		}

		private int StartDisplayingTab
		{
			get
			{
				return m_startDisplayingTab;
			}
			set
			{
				m_startDisplayingTab = value;
				Invalidate();
			}
		}

		private int EndDisplayingTab
		{
			get
			{
				return m_endDisplayingTab;
			}
			set
			{
				m_endDisplayingTab = value;
			}
		}

		private int FirstDisplayingTab
		{
			get
			{
				return m_firstDisplayingTab;
			}
			set
			{
				m_firstDisplayingTab = value;
			}
		}

		private bool DocumentTabsOverflow
		{
			set
			{
				if (m_documentTabsOverflow != value)
				{
					m_documentTabsOverflow = value;
					if (value)
					{
						ButtonWindowList.ImageCategory = 1;
					}
					else
					{
						ButtonWindowList.ImageCategory = 0;
					}
				}
			}
		}

		private Rectangle TabStripRectangle
		{
			get
			{
				if (base.Appearance == DockPane.AppearanceStyle.Document)
				{
					return TabStripRectangle_Document;
				}
				return TabStripRectangle_ToolWindow;
			}
		}

		private Rectangle TabStripRectangle_ToolWindow
		{
			get
			{
				Rectangle clientRectangle = base.ClientRectangle;
				return new Rectangle(clientRectangle.X, clientRectangle.Top + ToolWindowStripGapTop, clientRectangle.Width, clientRectangle.Height - ToolWindowStripGapTop - ToolWindowStripGapBottom);
			}
		}

		private Rectangle TabStripRectangle_Document
		{
			get
			{
				Rectangle clientRectangle = base.ClientRectangle;
				return new Rectangle(clientRectangle.X, clientRectangle.Top + DocumentStripGapTop, clientRectangle.Width, clientRectangle.Height - DocumentStripGapTop - ToolWindowStripGapBottom);
			}
		}

		private Rectangle TabsRectangle
		{
			get
			{
				if (base.Appearance == DockPane.AppearanceStyle.ToolWindow)
				{
					return TabStripRectangle;
				}
				Rectangle tabStripRectangle = TabStripRectangle;
				int x = tabStripRectangle.X;
				int y = tabStripRectangle.Y;
				int width = tabStripRectangle.Width;
				int height = tabStripRectangle.Height;
				x += DocumentTabGapLeft;
				width -= DocumentTabGapLeft + DocumentTabGapRight + DocumentButtonGapRight + ButtonClose.Width + ButtonWindowList.Width + 2 * DocumentButtonGapBetween;
				return new Rectangle(x, y, width, height);
			}
		}

		private ContextMenuStrip SelectMenu => m_selectMenu;

		protected internal override Tab CreateTab(IDockContent content)
		{
			return new TabVS2005(content);
		}

		public VS2005DockPaneStrip(DockPane pane)
			: base(pane)
		{
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			SuspendLayout();
			m_components = new Container();
			m_toolTip = new ToolTip(Components);
			m_selectMenu = new ContextMenuStrip(Components);
			ResumeLayout();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Components.Dispose();
				if (m_boldFont != null)
				{
					m_boldFont.Dispose();
					m_boldFont = null;
				}
			}
			base.Dispose(disposing);
		}

		protected internal override int MeasureHeight()
		{
			if (base.Appearance == DockPane.AppearanceStyle.ToolWindow)
			{
				return MeasureHeight_ToolWindow();
			}
			return MeasureHeight_Document();
		}

		private int MeasureHeight_ToolWindow()
		{
			if (base.DockPane.IsAutoHide || base.Tabs.Count <= 1)
			{
				return 0;
			}
			return Math.Max(TextFont.Height, ToolWindowImageHeight + ToolWindowImageGapTop + ToolWindowImageGapBottom) + ToolWindowStripGapTop + ToolWindowStripGapBottom;
		}

		private int MeasureHeight_Document()
		{
			return Math.Max(TextFont.Height + DocumentTabGapTop, ButtonClose.Height + DocumentButtonGapTop + DocumentButtonGapBottom) + DocumentStripGapBottom + DocumentStripGapTop;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle tabsRectangle = TabsRectangle;
			if (base.Appearance == DockPane.AppearanceStyle.Document)
			{
				tabsRectangle.X -= DocumentTabGapLeft;
				tabsRectangle.Width += DocumentTabGapLeft + DocumentTabGapRight + DocumentButtonGapRight + ButtonClose.Width + ButtonWindowList.Width;
				if (tabsRectangle.Width > 0 && tabsRectangle.Height > 0)
				{
					GDIHelper.FillRectangle(e.Graphics, tabsRectangle, SkinManager.CurrentSkin.BaseColor);
				}
			}
			else
			{
				Color startColor = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.DockStripGradient.StartColor;
				Color endColor = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.DockStripGradient.EndColor;
				LinearGradientMode linearGradientMode = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.DockStripGradient.LinearGradientMode;
				using (LinearGradientBrush brush = new LinearGradientBrush(tabsRectangle, startColor, endColor, linearGradientMode))
				{
					e.Graphics.FillRectangle(brush, tabsRectangle);
				}
			}
			base.OnPaint(e);
			CalculateTabs();
			if (base.Appearance == DockPane.AppearanceStyle.Document && base.DockPane.ActiveContent != null && EnsureDocumentTabVisible(base.DockPane.ActiveContent, repaint: false))
			{
				CalculateTabs();
			}
			DrawTabStrip(e.Graphics);
		}

		protected override void OnRefreshChanges()
		{
			SetInertButtons();
			Invalidate();
		}

		protected internal override GraphicsPath GetOutline(int index)
		{
			if (base.Appearance == DockPane.AppearanceStyle.Document)
			{
				return GetOutline_Document(index);
			}
			return GetOutline_ToolWindow(index);
		}

		private GraphicsPath GetOutline_Document(int index)
		{
			Rectangle tabRectangle = GetTabRectangle(index);
			tabRectangle.X -= tabRectangle.Height / 2;
			tabRectangle.Intersect(TabsRectangle);
			tabRectangle = RectangleToScreen(DrawHelper.RtlTransform(this, tabRectangle));
			Rectangle rectangle = base.DockPane.RectangleToScreen(base.DockPane.ClientRectangle);
			GraphicsPath graphicsPath = new GraphicsPath();
			GraphicsPath tabOutline_Document = GetTabOutline_Document(base.Tabs[index], rtlTransform: true, toScreen: true, full: true);
			graphicsPath.AddPath(tabOutline_Document, connect: true);
			if (base.DockPane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom)
			{
				graphicsPath.AddLine(tabRectangle.Right, tabRectangle.Top, rectangle.Right, tabRectangle.Top);
				graphicsPath.AddLine(rectangle.Right, tabRectangle.Top, rectangle.Right, rectangle.Top);
				graphicsPath.AddLine(rectangle.Right, rectangle.Top, rectangle.Left, rectangle.Top);
				graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Left, tabRectangle.Top);
				graphicsPath.AddLine(rectangle.Left, tabRectangle.Top, tabRectangle.Right, tabRectangle.Top);
			}
			else
			{
				graphicsPath.AddLine(tabRectangle.Right, tabRectangle.Bottom, rectangle.Right, tabRectangle.Bottom);
				graphicsPath.AddLine(rectangle.Right, tabRectangle.Bottom, rectangle.Right, rectangle.Bottom);
				graphicsPath.AddLine(rectangle.Right, rectangle.Bottom, rectangle.Left, rectangle.Bottom);
				graphicsPath.AddLine(rectangle.Left, rectangle.Bottom, rectangle.Left, tabRectangle.Bottom);
				graphicsPath.AddLine(rectangle.Left, tabRectangle.Bottom, tabRectangle.Right, tabRectangle.Bottom);
			}
			return graphicsPath;
		}

		private GraphicsPath GetOutline_ToolWindow(int index)
		{
			Rectangle tabRectangle = GetTabRectangle(index);
			tabRectangle.Intersect(TabsRectangle);
			tabRectangle = RectangleToScreen(DrawHelper.RtlTransform(this, tabRectangle));
			int top = tabRectangle.Top;
			Rectangle rectangle = base.DockPane.RectangleToScreen(base.DockPane.ClientRectangle);
			GraphicsPath graphicsPath = new GraphicsPath();
			GraphicsPath tabOutline = GetTabOutline(base.Tabs[index], rtlTransform: true, toScreen: true);
			graphicsPath.AddPath(tabOutline, connect: true);
			graphicsPath.AddLine(tabRectangle.Left, tabRectangle.Top, rectangle.Left, tabRectangle.Top);
			graphicsPath.AddLine(rectangle.Left, tabRectangle.Top, rectangle.Left, rectangle.Top);
			graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top);
			graphicsPath.AddLine(rectangle.Right, rectangle.Top, rectangle.Right, tabRectangle.Top);
			graphicsPath.AddLine(rectangle.Right, tabRectangle.Top, tabRectangle.Right, tabRectangle.Top);
			return graphicsPath;
		}

		private void CalculateTabs()
		{
			if (base.Appearance == DockPane.AppearanceStyle.ToolWindow)
			{
				CalculateTabs_ToolWindow();
			}
			else
			{
				CalculateTabs_Document();
			}
		}

		private void CalculateTabs_ToolWindow()
		{
			if (base.Tabs.Count > 1 && !base.DockPane.IsAutoHide)
			{
				Rectangle tabStripRectangle = TabStripRectangle;
				int count = base.Tabs.Count;
				foreach (TabVS2005 item in (IEnumerable<Tab>)base.Tabs)
				{
					item.MaxWidth = GetMaxTabWidth(base.Tabs.IndexOf(item));
					item.Flag = false;
				}
				bool flag = true;
				int num = tabStripRectangle.Width - ToolWindowStripGapLeft - ToolWindowStripGapRight;
				int num2 = 0;
				int num3 = num / count;
				int num4 = count;
				flag = true;
				while (flag && num4 > 0)
				{
					flag = false;
					foreach (TabVS2005 item2 in (IEnumerable<Tab>)base.Tabs)
					{
						if (!item2.Flag && item2.MaxWidth <= num3)
						{
							item2.Flag = true;
							item2.TabWidth = item2.MaxWidth;
							num2 += item2.TabWidth;
							flag = true;
							num4--;
						}
					}
					if (num4 != 0)
					{
						num3 = (num - num2) / num4;
					}
				}
				if (num4 > 0)
				{
					int num5 = num - num2 - num3 * num4;
					foreach (TabVS2005 item3 in (IEnumerable<Tab>)base.Tabs)
					{
						if (!item3.Flag)
						{
							item3.Flag = true;
							if (num5 > 0)
							{
								item3.TabWidth = num3 + 1;
								num5--;
							}
							else
							{
								item3.TabWidth = num3;
							}
						}
					}
				}
				int num6 = tabStripRectangle.X + ToolWindowStripGapLeft;
				foreach (TabVS2005 item4 in (IEnumerable<Tab>)base.Tabs)
				{
					item4.TabX = num6;
					num6 += item4.TabWidth;
				}
			}
		}

		private bool CalculateDocumentTab(Rectangle rectTabStrip, ref int x, int index)
		{
			bool result = false;
			TabVS2005 tabVS = base.Tabs[index] as TabVS2005;
			tabVS.MaxWidth = GetMaxTabWidth(index);
			int num = Math.Min(tabVS.MaxWidth, DocumentTabMaxWidth);
			if (x + num < rectTabStrip.Right || index == StartDisplayingTab)
			{
				tabVS.TabX = x;
				tabVS.TabWidth = num;
				EndDisplayingTab = index;
			}
			else
			{
				tabVS.TabX = 0;
				tabVS.TabWidth = 0;
				result = true;
			}
			x += num;
			return result;
		}

		private void CalculateTabs_Document()
		{
			if (m_startDisplayingTab >= base.Tabs.Count)
			{
				m_startDisplayingTab = 0;
			}
			Rectangle tabsRectangle = TabsRectangle;
			int x = tabsRectangle.X + tabsRectangle.Height / 2;
			bool flag = false;
			if (m_startDisplayingTab > 0)
			{
				int x2 = x;
				TabVS2005 tabVS = base.Tabs[m_startDisplayingTab] as TabVS2005;
				tabVS.MaxWidth = GetMaxTabWidth(m_startDisplayingTab);
				int num = Math.Min(tabVS.MaxWidth, DocumentTabMaxWidth);
				for (int num2 = StartDisplayingTab; num2 >= 0; num2--)
				{
					CalculateDocumentTab(tabsRectangle, ref x2, num2);
				}
				FirstDisplayingTab = EndDisplayingTab;
				x2 = x;
				for (int num2 = EndDisplayingTab; num2 < base.Tabs.Count; num2++)
				{
					flag = CalculateDocumentTab(tabsRectangle, ref x2, num2);
				}
				if (FirstDisplayingTab != 0)
				{
					flag = true;
				}
			}
			else
			{
				for (int num2 = StartDisplayingTab; num2 < base.Tabs.Count; num2++)
				{
					flag = CalculateDocumentTab(tabsRectangle, ref x, num2);
				}
				for (int num2 = 0; num2 < StartDisplayingTab; num2++)
				{
					flag = CalculateDocumentTab(tabsRectangle, ref x, num2);
				}
				FirstDisplayingTab = StartDisplayingTab;
			}
			if (!flag)
			{
				m_startDisplayingTab = 0;
				FirstDisplayingTab = 0;
				x = tabsRectangle.X + tabsRectangle.Height / 2;
				foreach (TabVS2005 item in (IEnumerable<Tab>)base.Tabs)
				{
					item.TabX = x;
					x += item.TabWidth;
				}
			}
			DocumentTabsOverflow = flag;
		}

		protected internal override void EnsureTabVisible(IDockContent content)
		{
			if (base.Appearance == DockPane.AppearanceStyle.Document && base.Tabs.Contains(content))
			{
				CalculateTabs();
				EnsureDocumentTabVisible(content, repaint: true);
			}
		}

		private bool EnsureDocumentTabVisible(IDockContent content, bool repaint)
		{
			int num = base.Tabs.IndexOf(content);
			TabVS2005 tabVS = base.Tabs[num] as TabVS2005;
			if (tabVS.TabWidth != 0)
			{
				return false;
			}
			StartDisplayingTab = num;
			if (repaint)
			{
				Invalidate();
			}
			return true;
		}

		private int GetMaxTabWidth(int index)
		{
			if (base.Appearance == DockPane.AppearanceStyle.ToolWindow)
			{
				return GetMaxTabWidth_ToolWindow(index);
			}
			return GetMaxTabWidth_Document(index);
		}

		private int GetMaxTabWidth_ToolWindow(int index)
		{
			IDockContent content = base.Tabs[index].Content;
			Size size = TextRenderer.MeasureText(content.DockHandler.TabText, TextFont);
			return ToolWindowImageWidth + size.Width + ToolWindowImageGapLeft + ToolWindowImageGapRight + ToolWindowTextGapRight;
		}

		private int GetMaxTabWidth_Document(int index)
		{
			IDockContent content = base.Tabs[index].Content;
			int height = GetTabRectangle_Document(index).Height;
			Size size = TextRenderer.MeasureText(content.DockHandler.TabText, BoldFont, new Size(DocumentTabMaxWidth, height), DocumentTextFormat);
			if (base.DockPane.DockPanel.ShowDocumentIcon)
			{
				return size.Width + DocumentIconWidth + DocumentIconGapLeft + DocumentIconGapRight + DocumentTextGapRight;
			}
			return size.Width + DocumentIconGapLeft + DocumentTextGapRight;
		}

		private void DrawTabStrip(Graphics g)
		{
			if (base.Appearance == DockPane.AppearanceStyle.Document)
			{
				DrawTabStrip_Document(g);
			}
			else
			{
				DrawTabStrip_ToolWindow(g);
			}
		}

		private void DrawTabStrip_Document(Graphics g)
		{
			int count = base.Tabs.Count;
			if (count != 0)
			{
				Rectangle tabStripRectangle = TabStripRectangle;
				Rectangle tabsRectangle = TabsRectangle;
				Rectangle empty = Rectangle.Empty;
				TabVS2005 tabVS = null;
				g.SetClip(DrawHelper.RtlTransform(this, tabsRectangle));
				for (int i = 0; i < count; i++)
				{
					empty = GetTabRectangle(i);
					if (base.Tabs[i].Content == base.DockPane.ActiveContent)
					{
						tabVS = (base.Tabs[i] as TabVS2005);
					}
					else if (empty.IntersectsWith(tabsRectangle))
					{
						DrawTab(g, base.Tabs[i] as TabVS2005, empty);
					}
				}
				g.SetClip(tabStripRectangle);
				if (base.DockPane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom)
				{
					g.DrawLine(PenDocumentTabActiveBorder, tabStripRectangle.Left, tabStripRectangle.Top + 1, tabStripRectangle.Right, tabStripRectangle.Top + 1);
				}
				else
				{
					g.DrawLine(PenDocumentTabActiveBorder, tabStripRectangle.Left, tabStripRectangle.Bottom - 1, tabStripRectangle.Right, tabStripRectangle.Bottom - 1);
				}
				g.SetClip(DrawHelper.RtlTransform(this, tabsRectangle));
				if (tabVS != null)
				{
					empty = GetTabRectangle(base.Tabs.IndexOf(tabVS));
					if (empty.IntersectsWith(tabsRectangle))
					{
						DrawTab(g, tabVS, empty);
					}
				}
			}
		}

		private void DrawTabStrip_ToolWindow(Graphics g)
		{
			Rectangle tabStripRectangle = TabStripRectangle;
			g.DrawLine(PenToolWindowTabBorder, tabStripRectangle.Left, tabStripRectangle.Top, tabStripRectangle.Right, tabStripRectangle.Top);
			for (int i = 0; i < base.Tabs.Count; i++)
			{
				DrawTab(g, base.Tabs[i] as TabVS2005, GetTabRectangle(i));
			}
		}

		private Rectangle GetTabRectangle(int index)
		{
			if (base.Appearance == DockPane.AppearanceStyle.ToolWindow)
			{
				return GetTabRectangle_ToolWindow(index);
			}
			return GetTabRectangle_Document(index);
		}

		private Rectangle GetTabRectangle_ToolWindow(int index)
		{
			Rectangle tabStripRectangle = TabStripRectangle;
			TabVS2005 tabVS = (TabVS2005)base.Tabs[index];
			return new Rectangle(tabVS.TabX, tabStripRectangle.Y, tabVS.TabWidth, tabStripRectangle.Height);
		}

		private Rectangle GetTabRectangle_Document(int index)
		{
			Rectangle tabStripRectangle = TabStripRectangle;
			TabVS2005 tabVS = (TabVS2005)base.Tabs[index];
			Rectangle result = default(Rectangle);
			result.X = tabVS.TabX;
			result.Width = tabVS.TabWidth;
			result.Height = tabStripRectangle.Height - DocumentTabGapTop;
			if (base.DockPane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom)
			{
				result.Y = tabStripRectangle.Y + DocumentStripGapBottom;
			}
			else
			{
				result.Y = tabStripRectangle.Y + DocumentTabGapTop;
			}
			return result;
		}

		private void DrawTab(Graphics g, TabVS2005 tab, Rectangle rect)
		{
			if (base.Appearance == DockPane.AppearanceStyle.ToolWindow)
			{
				DrawTab_ToolWindow(g, tab, rect);
			}
			else
			{
				DrawTab_Document(g, tab, rect);
			}
		}

		private GraphicsPath GetTabOutline(Tab tab, bool rtlTransform, bool toScreen)
		{
			if (base.Appearance == DockPane.AppearanceStyle.ToolWindow)
			{
				return GetTabOutline_ToolWindow(tab, rtlTransform, toScreen);
			}
			return GetTabOutline_Document(tab, rtlTransform, toScreen, full: false);
		}

		private GraphicsPath GetTabOutline_ToolWindow(Tab tab, bool rtlTransform, bool toScreen)
		{
			Rectangle rectangle = GetTabRectangle(base.Tabs.IndexOf(tab));
			if (rtlTransform)
			{
				rectangle = DrawHelper.RtlTransform(this, rectangle);
			}
			if (toScreen)
			{
				rectangle = RectangleToScreen(rectangle);
			}
			DrawHelper.GetRoundedCornerTab(GraphicsPath, rectangle, upCorner: false);
			return GraphicsPath;
		}

		private GraphicsPath GetTabOutline_Document(Tab tab, bool rtlTransform, bool toScreen, bool full)
		{
			int num = 6;
			GraphicsPath.Reset();
			Rectangle rectangle = GetTabRectangle(base.Tabs.IndexOf(tab));
			if (rtlTransform)
			{
				rectangle = DrawHelper.RtlTransform(this, rectangle);
			}
			if (toScreen)
			{
				rectangle = RectangleToScreen(rectangle);
			}
			if (tab.Content == base.DockPane.ActiveContent || full || base.Tabs.IndexOf(tab) == FirstDisplayingTab)
			{
				if (RightToLeft == RightToLeft.Yes)
				{
					if (base.DockPane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom)
					{
						GraphicsPath.AddLine(rectangle.Right + rectangle.Height / 2, rectangle.Top, rectangle.Right - rectangle.Height / 2 + num / 2, rectangle.Bottom - num / 2);
					}
					else
					{
						GraphicsPath.AddLine(rectangle.Right, rectangle.Bottom, rectangle.Right + rectangle.Height / 2, rectangle.Bottom);
						GraphicsPath.AddLine(rectangle.Right + rectangle.Height / 2, rectangle.Bottom, rectangle.Right - rectangle.Height / 2 + num / 2, rectangle.Top + num / 2);
					}
				}
				else if (base.DockPane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom)
				{
					GraphicsPath.AddLine(rectangle.Left - rectangle.Height / 2, rectangle.Top, rectangle.Left + rectangle.Height / 2 - num / 2, rectangle.Bottom - num / 2);
				}
				else
				{
					GraphicsPath.AddLine(rectangle.Left, rectangle.Bottom, rectangle.Left - rectangle.Height / 2, rectangle.Bottom);
					GraphicsPath.AddLine(rectangle.Left - rectangle.Height / 2, rectangle.Bottom, rectangle.Left + rectangle.Height / 2 - num / 2, rectangle.Top + num / 2);
				}
			}
			else if (RightToLeft == RightToLeft.Yes)
			{
				if (base.DockPane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom)
				{
					GraphicsPath.AddLine(rectangle.Right, rectangle.Top, rectangle.Right, rectangle.Top + rectangle.Height / 2);
					GraphicsPath.AddLine(rectangle.Right, rectangle.Top + rectangle.Height / 2, rectangle.Right - rectangle.Height / 2 + num / 2, rectangle.Bottom - num / 2);
				}
				else
				{
					GraphicsPath.AddLine(rectangle.Right, rectangle.Bottom, rectangle.Right, rectangle.Bottom - rectangle.Height / 2);
					GraphicsPath.AddLine(rectangle.Right, rectangle.Bottom - rectangle.Height / 2, rectangle.Right - rectangle.Height / 2 + num / 2, rectangle.Top + num / 2);
				}
			}
			else if (base.DockPane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom)
			{
				GraphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Top + rectangle.Height / 2);
				GraphicsPath.AddLine(rectangle.Left, rectangle.Top + rectangle.Height / 2, rectangle.Left + rectangle.Height / 2 - num / 2, rectangle.Bottom - num / 2);
			}
			else
			{
				GraphicsPath.AddLine(rectangle.Left, rectangle.Bottom, rectangle.Left, rectangle.Bottom - rectangle.Height / 2);
				GraphicsPath.AddLine(rectangle.Left, rectangle.Bottom - rectangle.Height / 2, rectangle.Left + rectangle.Height / 2 - num / 2, rectangle.Top + num / 2);
			}
			if (RightToLeft == RightToLeft.Yes)
			{
				if (base.DockPane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom)
				{
					GraphicsPath.AddLine(rectangle.Right - rectangle.Height / 2 - num / 2, rectangle.Bottom, rectangle.Left + num / 2, rectangle.Bottom);
				}
				else
				{
					GraphicsPath.AddLine(rectangle.Right - rectangle.Height / 2 - num / 2, rectangle.Top, rectangle.Left + num / 2, rectangle.Top);
					GraphicsPath.AddArc(new Rectangle(rectangle.Left, rectangle.Top, num, num), 180f, 90f);
				}
			}
			else if (base.DockPane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom)
			{
				GraphicsPath.AddLine(rectangle.Left + rectangle.Height / 2 + num / 2, rectangle.Bottom, rectangle.Right - num / 2, rectangle.Bottom);
			}
			else
			{
				GraphicsPath.AddLine(rectangle.Left + rectangle.Height / 2 + num / 2, rectangle.Top, rectangle.Right - num / 2, rectangle.Top);
				GraphicsPath.AddArc(new Rectangle(rectangle.Right - num, rectangle.Top, num, num), -90f, 90f);
			}
			if (base.Tabs.IndexOf(tab) != EndDisplayingTab && base.Tabs.IndexOf(tab) != base.Tabs.Count - 1 && base.Tabs[base.Tabs.IndexOf(tab) + 1].Content == base.DockPane.ActiveContent && !full)
			{
				if (RightToLeft == RightToLeft.Yes)
				{
					if (base.DockPane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom)
					{
						GraphicsPath.AddLine(rectangle.Left, rectangle.Bottom - num / 2, rectangle.Left, rectangle.Bottom - rectangle.Height / 2);
						GraphicsPath.AddLine(rectangle.Left, rectangle.Bottom - rectangle.Height / 2, rectangle.Left + rectangle.Height / 2, rectangle.Top);
					}
					else
					{
						GraphicsPath.AddLine(rectangle.Left, rectangle.Top + num / 2, rectangle.Left, rectangle.Top + rectangle.Height / 2);
						GraphicsPath.AddLine(rectangle.Left, rectangle.Top + rectangle.Height / 2, rectangle.Left + rectangle.Height / 2, rectangle.Bottom);
					}
				}
				else if (base.DockPane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom)
				{
					GraphicsPath.AddLine(rectangle.Right, rectangle.Bottom - num / 2, rectangle.Right, rectangle.Bottom - rectangle.Height / 2);
					GraphicsPath.AddLine(rectangle.Right, rectangle.Bottom - rectangle.Height / 2, rectangle.Right - rectangle.Height / 2, rectangle.Top);
				}
				else
				{
					GraphicsPath.AddLine(rectangle.Right, rectangle.Top + num / 2, rectangle.Right, rectangle.Top + rectangle.Height / 2);
					GraphicsPath.AddLine(rectangle.Right, rectangle.Top + rectangle.Height / 2, rectangle.Right - rectangle.Height / 2, rectangle.Bottom);
				}
			}
			else if (RightToLeft == RightToLeft.Yes)
			{
				if (base.DockPane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom)
				{
					GraphicsPath.AddLine(rectangle.Left, rectangle.Bottom - num / 2, rectangle.Left, rectangle.Top);
				}
				else
				{
					GraphicsPath.AddLine(rectangle.Left, rectangle.Top + num / 2, rectangle.Left, rectangle.Bottom);
				}
			}
			else if (base.DockPane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom)
			{
				GraphicsPath.AddLine(rectangle.Right, rectangle.Bottom - num / 2, rectangle.Right, rectangle.Top);
			}
			else
			{
				GraphicsPath.AddLine(rectangle.Right, rectangle.Top + num / 2, rectangle.Right, rectangle.Bottom);
			}
			return GraphicsPath;
		}

		private void DrawTab_ToolWindow(Graphics g, TabVS2005 tab, Rectangle rect)
		{
			Rectangle rectangle = new Rectangle(rect.X + ToolWindowImageGapLeft, rect.Y + rect.Height - 1 - ToolWindowImageGapBottom - ToolWindowImageHeight, ToolWindowImageWidth, ToolWindowImageHeight);
			Rectangle rectangle2 = rectangle;
			rectangle2.X += rectangle.Width + ToolWindowImageGapRight;
			rectangle2.Width = rect.Width - rectangle.Width - ToolWindowImageGapLeft - ToolWindowImageGapRight - ToolWindowTextGapRight;
			Rectangle rect2 = DrawHelper.RtlTransform(this, rect);
			rectangle2 = DrawHelper.RtlTransform(this, rectangle2);
			rectangle = DrawHelper.RtlTransform(this, rectangle);
			GraphicsPath tabOutline = GetTabOutline(tab, rtlTransform: true, toScreen: false);
			if (base.DockPane.ActiveContent == tab.Content)
			{
				Color startColor = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveTabGradient.StartColor;
				Color endColor = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveTabGradient.EndColor;
				LinearGradientMode linearGradientMode = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveTabGradient.LinearGradientMode;
				g.FillPath(new LinearGradientBrush(rect2, startColor, endColor, linearGradientMode), tabOutline);
				g.DrawPath(PenToolWindowTabBorder, tabOutline);
				Color textColor = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveTabGradient.TextColor;
				TextRenderer.DrawText(g, tab.Content.DockHandler.TabText, TextFont, rectangle2, textColor, ToolWindowTextFormat);
			}
			else
			{
				Color startColor = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveTabGradient.StartColor;
				Color endColor = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveTabGradient.EndColor;
				LinearGradientMode linearGradientMode = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveTabGradient.LinearGradientMode;
				g.FillPath(new LinearGradientBrush(rect2, startColor, endColor, linearGradientMode), tabOutline);
				if (base.Tabs.IndexOf(base.DockPane.ActiveContent) != base.Tabs.IndexOf(tab) + 1)
				{
					Point point = new Point(rect.Right, rect.Top + ToolWindowTabSeperatorGapTop);
					Point point2 = new Point(rect.Right, rect.Bottom - ToolWindowTabSeperatorGapBottom);
					g.DrawLine(PenToolWindowTabBorder, DrawHelper.RtlTransform(this, point), DrawHelper.RtlTransform(this, point2));
				}
				Color textColor = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveTabGradient.TextColor;
				TextRenderer.DrawText(g, tab.Content.DockHandler.TabText, TextFont, rectangle2, textColor, ToolWindowTextFormat);
			}
			if (rect2.Contains(rectangle))
			{
				g.DrawIcon(tab.Content.DockHandler.Icon, rectangle);
			}
		}

		private void DrawTab_Document(Graphics g, TabVS2005 tab, Rectangle rect)
		{
			if (tab.TabWidth != 0)
			{
				Rectangle rectangle = new Rectangle(rect.X + DocumentIconGapLeft, rect.Y + rect.Height - 1 - DocumentIconGapBottom - DocumentIconHeight, DocumentIconWidth, DocumentIconHeight);
				Rectangle rectangle2 = rectangle;
				if (base.DockPane.DockPanel.ShowDocumentIcon)
				{
					rectangle2.X += rectangle.Width + DocumentIconGapRight;
					rectangle2.Y = rect.Y;
					rectangle2.Width = rect.Width - rectangle.Width - DocumentIconGapLeft - DocumentIconGapRight - DocumentTextGapRight;
					rectangle2.Height = rect.Height;
				}
				else
				{
					rectangle2.Width = rect.Width - DocumentIconGapLeft - DocumentTextGapRight;
				}
				Rectangle rectangle3 = DrawHelper.RtlTransform(this, rect);
				Rectangle rect2 = DrawHelper.RtlTransform(this, rect);
				rect2.Width += rect.X;
				rect2.X = 0;
				rectangle2 = DrawHelper.RtlTransform(this, rectangle2);
				rectangle = DrawHelper.RtlTransform(this, rectangle);
				GraphicsPath tabOutline = GetTabOutline(tab, rtlTransform: true, toScreen: false);
				if (base.DockPane.ActiveContent == tab.Content)
				{
					GDIHelper.InitializeGraphics(g);
					GDIHelper.FillPath(g, tabOutline, rect2, SkinManager.CurrentSkin.HeightLightControlColor);
					GDIHelper.DrawPathBorder(g, tabOutline, SkinManager.CurrentSkin.BorderColor);
					Color textColor = base.DockPane.DockPanel.Skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.TextColor;
					textColor = SkinManager.CurrentSkin.CaptionFontColor;
					if (base.DockPane.IsActiveDocumentPane)
					{
						TextRenderer.DrawText(g, tab.Content.DockHandler.TabText, BoldFont, rectangle2, textColor, DocumentTextFormat);
					}
					else
					{
						TextRenderer.DrawText(g, tab.Content.DockHandler.TabText, TextFont, rectangle2, textColor, DocumentTextFormat);
					}
				}
				else
				{
					GDIHelper.InitializeGraphics(g);
					GDIHelper.FillPath(g, tabOutline, rect2, SkinManager.CurrentSkin.DefaultControlColor);
					GDIHelper.DrawPathBorder(g, tabOutline, SkinManager.CurrentSkin.BorderColor);
					Color textColor = base.DockPane.DockPanel.Skin.DockPaneStripSkin.DocumentGradient.InactiveTabGradient.TextColor;
					textColor = SkinManager.CurrentSkin.CaptionFontColor;
					TextRenderer.DrawText(g, tab.Content.DockHandler.TabText, TextFont, rectangle2, textColor, DocumentTextFormat);
				}
				if (rectangle3.Contains(rectangle) && base.DockPane.DockPanel.ShowDocumentIcon)
				{
					g.DrawIcon(tab.Content.DockHandler.Icon, rectangle);
				}
			}
		}

		private void WindowList_Click(object sender, EventArgs e)
		{
			int x = 0;
			int y = ButtonWindowList.Location.Y + ButtonWindowList.Height;
			SelectMenu.Items.Clear();
			foreach (TabVS2005 item in (IEnumerable<Tab>)base.Tabs)
			{
				IDockContent content = item.Content;
				ToolStripItem toolStripItem = SelectMenu.Items.Add(content.DockHandler.TabText, content.DockHandler.Icon.ToBitmap());
				toolStripItem.Tag = item.Content;
				toolStripItem.Click += ContextMenuItem_Click;
			}
			SelectMenu.Show(ButtonWindowList, x, y);
		}

		private void ContextMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				IDockContent activeContent = (IDockContent)toolStripMenuItem.Tag;
				base.DockPane.ActiveContent = activeContent;
			}
		}

		private void SetInertButtons()
		{
			if (base.Appearance == DockPane.AppearanceStyle.ToolWindow)
			{
				if (m_buttonClose != null)
				{
					m_buttonClose.Left = -m_buttonClose.Width;
				}
				if (m_buttonWindowList != null)
				{
					m_buttonWindowList.Left = -m_buttonWindowList.Width;
				}
			}
			else
			{
				bool enabled = base.DockPane.ActiveContent == null || base.DockPane.ActiveContent.DockHandler.CloseButton;
				ButtonClose.Enabled = enabled;
				ButtonClose.Visible = (base.DockPane.ActiveContent == null || base.DockPane.ActiveContent.DockHandler.CloseButtonVisible);
				ButtonClose.RefreshChanges();
				ButtonWindowList.RefreshChanges();
			}
		}

		protected override void OnLayout(LayoutEventArgs levent)
		{
			if (base.Appearance != DockPane.AppearanceStyle.Document)
			{
				base.OnLayout(levent);
			}
			else
			{
				Rectangle tabStripRectangle = TabStripRectangle;
				int num = ButtonClose.Image.Width;
				int num2 = ButtonClose.Image.Height;
				int num3 = tabStripRectangle.Height - DocumentButtonGapTop - DocumentButtonGapBottom;
				if (num2 < num3)
				{
					num *= num3 / num2;
					num2 = num3;
				}
				Size size = new Size(num, num2);
				int x = tabStripRectangle.X + tabStripRectangle.Width - DocumentTabGapLeft - DocumentButtonGapRight - num;
				int y = tabStripRectangle.Y + DocumentButtonGapTop;
				Point location = new Point(x, y);
				ButtonClose.Bounds = DrawHelper.RtlTransform(this, new Rectangle(location, size));
				if (ButtonClose.Visible)
				{
					location.Offset(-(DocumentButtonGapBetween + num), 0);
				}
				ButtonWindowList.Bounds = DrawHelper.RtlTransform(this, new Rectangle(location, size));
				OnRefreshChanges();
				base.OnLayout(levent);
			}
		}

		private void Close_Click(object sender, EventArgs e)
		{
			base.DockPane.CloseActiveContent();
		}

		protected internal override int HitTest(Point ptMouse)
		{
			Rectangle tabsRectangle = TabsRectangle;
			if (!TabsRectangle.Contains(ptMouse))
			{
				return -1;
			}
			foreach (Tab item in (IEnumerable<Tab>)base.Tabs)
			{
				GraphicsPath tabOutline = GetTabOutline(item, rtlTransform: true, toScreen: false);
				if (tabOutline.IsVisible(ptMouse))
				{
					return base.Tabs.IndexOf(item);
				}
			}
			return -1;
		}

		protected override void OnMouseHover(EventArgs e)
		{
			int num = HitTest(PointToClient(Control.MousePosition));
			string text = string.Empty;
			base.OnMouseHover(e);
			if (num != -1)
			{
				TabVS2005 tabVS = base.Tabs[num] as TabVS2005;
				if (!string.IsNullOrEmpty(tabVS.Content.DockHandler.ToolTipText))
				{
					text = tabVS.Content.DockHandler.ToolTipText;
				}
				else if (tabVS.MaxWidth > tabVS.TabWidth)
				{
					text = tabVS.Content.DockHandler.TabText;
				}
			}
			if (m_toolTip.GetToolTip(this) != text)
			{
				m_toolTip.Active = false;
				m_toolTip.SetToolTip(this, text);
				m_toolTip.Active = true;
			}
			ResetMouseEventArgs();
		}

		protected override void OnRightToLeftChanged(EventArgs e)
		{
			base.OnRightToLeftChanged(e);
			PerformLayout();
		}
	}
}
