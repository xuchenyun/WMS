using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CIT.Client.Docking
{
	internal class VS2005AutoHideStrip : AutoHideStripBase
	{
		private class TabVS2005 : Tab
		{
			private int m_tabX = 0;

			private int m_tabWidth = 0;

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

			internal TabVS2005(IDockContent content)
				: base(content)
			{
			}
		}

		private const int _ImageHeight = 16;

		private const int _ImageWidth = 16;

		private const int _ImageGapTop = 2;

		private const int _ImageGapLeft = 4;

		private const int _ImageGapRight = 2;

		private const int _ImageGapBottom = 2;

		private const int _TextGapLeft = 0;

		private const int _TextGapRight = 0;

		private const int _TabGapTop = 3;

		private const int _TabGapLeft = 4;

		private const int _TabGapBetween = 10;

		private static StringFormat _stringFormatTabHorizontal;

		private static StringFormat _stringFormatTabVertical;

		private static Matrix _matrixIdentity = new Matrix();

		private static DockState[] _dockStates;

		private static GraphicsPath _graphicsPath;

		private static Font TextFont => SystemInformation.MenuFont;

		private StringFormat StringFormatTabHorizontal
		{
			get
			{
				if (_stringFormatTabHorizontal == null)
				{
					_stringFormatTabHorizontal = new StringFormat();
					_stringFormatTabHorizontal.Alignment = StringAlignment.Near;
					_stringFormatTabHorizontal.LineAlignment = StringAlignment.Center;
					_stringFormatTabHorizontal.FormatFlags = StringFormatFlags.NoWrap;
					_stringFormatTabHorizontal.Trimming = StringTrimming.None;
				}
				if (RightToLeft == RightToLeft.Yes)
				{
					_stringFormatTabHorizontal.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
				}
				else
				{
					_stringFormatTabHorizontal.FormatFlags &= ~StringFormatFlags.DirectionRightToLeft;
				}
				return _stringFormatTabHorizontal;
			}
		}

		private StringFormat StringFormatTabVertical
		{
			get
			{
				if (_stringFormatTabVertical == null)
				{
					_stringFormatTabVertical = new StringFormat();
					_stringFormatTabVertical.Alignment = StringAlignment.Near;
					_stringFormatTabVertical.LineAlignment = StringAlignment.Center;
					_stringFormatTabVertical.FormatFlags = (StringFormatFlags.DirectionVertical | StringFormatFlags.NoWrap);
					_stringFormatTabVertical.Trimming = StringTrimming.None;
				}
				if (RightToLeft == RightToLeft.Yes)
				{
					_stringFormatTabVertical.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
				}
				else
				{
					_stringFormatTabVertical.FormatFlags &= ~StringFormatFlags.DirectionRightToLeft;
				}
				return _stringFormatTabVertical;
			}
		}

		private static int ImageHeight => 16;

		private static int ImageWidth => 16;

		private static int ImageGapTop => 2;

		private static int ImageGapLeft => 4;

		private static int ImageGapRight => 2;

		private static int ImageGapBottom => 2;

		private static int TextGapLeft => 0;

		private static int TextGapRight => 0;

		private static int TabGapTop => 3;

		private static int TabGapLeft => 4;

		private static int TabGapBetween => 10;

		private static Pen PenTabBorder => SystemPens.GrayText;

		private static Matrix MatrixIdentity => _matrixIdentity;

		private static DockState[] DockStates
		{
			get
			{
				if (_dockStates == null)
				{
					_dockStates = new DockState[4];
					_dockStates[0] = DockState.DockLeftAutoHide;
					_dockStates[1] = DockState.DockRightAutoHide;
					_dockStates[2] = DockState.DockTopAutoHide;
					_dockStates[3] = DockState.DockBottomAutoHide;
				}
				return _dockStates;
			}
		}

		internal static GraphicsPath GraphicsPath
		{
			get
			{
				if (_graphicsPath == null)
				{
					_graphicsPath = new GraphicsPath();
				}
				return _graphicsPath;
			}
		}

		public VS2005AutoHideStrip(DockPanel panel)
			: base(panel)
		{
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			BackColor = SystemColors.ControlLight;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Color startColor = base.DockPanel.Skin.AutoHideStripSkin.DockStripGradient.StartColor;
			Color endColor = base.DockPanel.Skin.AutoHideStripSkin.DockStripGradient.EndColor;
			LinearGradientMode linearGradientMode = base.DockPanel.Skin.AutoHideStripSkin.DockStripGradient.LinearGradientMode;
			using (LinearGradientBrush brush = new LinearGradientBrush(base.ClientRectangle, startColor, endColor, linearGradientMode))
			{
				graphics.FillRectangle(brush, base.ClientRectangle);
			}
			DrawTabStrip(graphics);
		}

		protected override void OnLayout(LayoutEventArgs levent)
		{
			CalculateTabs();
			base.OnLayout(levent);
		}

		private void DrawTabStrip(Graphics g)
		{
			DrawTabStrip(g, DockState.DockTopAutoHide);
			DrawTabStrip(g, DockState.DockBottomAutoHide);
			DrawTabStrip(g, DockState.DockLeftAutoHide);
			DrawTabStrip(g, DockState.DockRightAutoHide);
		}

		private void DrawTabStrip(Graphics g, DockState dockState)
		{
			Rectangle logicalTabStripRectangle = GetLogicalTabStripRectangle(dockState);
			if (!logicalTabStripRectangle.IsEmpty)
			{
				Matrix transform = g.Transform;
				if (dockState == DockState.DockLeftAutoHide || dockState == DockState.DockRightAutoHide)
				{
					Matrix matrix = new Matrix();
					matrix.RotateAt(90f, new PointF((float)logicalTabStripRectangle.X + (float)logicalTabStripRectangle.Height / 2f, (float)logicalTabStripRectangle.Y + (float)logicalTabStripRectangle.Height / 2f));
					g.Transform = matrix;
				}
				foreach (Pane item in (IEnumerable<Pane>)GetPanes(dockState))
				{
					foreach (TabVS2005 item2 in (IEnumerable<Tab>)item.AutoHideTabs)
					{
						DrawTab(g, item2);
					}
				}
				g.Transform = transform;
			}
		}

		private void CalculateTabs()
		{
			CalculateTabs(DockState.DockTopAutoHide);
			CalculateTabs(DockState.DockBottomAutoHide);
			CalculateTabs(DockState.DockLeftAutoHide);
			CalculateTabs(DockState.DockRightAutoHide);
		}

		private void CalculateTabs(DockState dockState)
		{
			Rectangle logicalTabStripRectangle = GetLogicalTabStripRectangle(dockState);
			int num = logicalTabStripRectangle.Height - ImageGapTop - ImageGapBottom;
			int num2 = ImageWidth;
			if (num > ImageHeight)
			{
				num2 = ImageWidth * (num / ImageHeight);
			}
			int num3 = TabGapLeft + logicalTabStripRectangle.X;
			foreach (Pane item in (IEnumerable<Pane>)GetPanes(dockState))
			{
				foreach (TabVS2005 item2 in (IEnumerable<Tab>)item.AutoHideTabs)
				{
					int num4 = num2 + ImageGapLeft + ImageGapRight + TextRenderer.MeasureText(item2.Content.DockHandler.TabText, TextFont).Width + TextGapLeft + TextGapRight;
					item2.TabX = num3;
					item2.TabWidth = num4;
					num3 += num4;
				}
				num3 += TabGapBetween;
			}
		}

		private Rectangle RtlTransform(Rectangle rect, DockState dockState)
		{
			if (dockState == DockState.DockLeftAutoHide || dockState == DockState.DockRightAutoHide)
			{
				return rect;
			}
			return DrawHelper.RtlTransform(this, rect);
		}

		private GraphicsPath GetTabOutline(TabVS2005 tab, bool transformed, bool rtlTransform)
		{
			DockState dockState = tab.Content.DockHandler.DockState;
			Rectangle rect = GetTabRectangle(tab, transformed);
			if (rtlTransform)
			{
				rect = RtlTransform(rect, dockState);
			}
			bool upCorner = dockState == DockState.DockLeftAutoHide || dockState == DockState.DockBottomAutoHide;
			DrawHelper.GetRoundedCornerTab(GraphicsPath, rect, upCorner);
			return GraphicsPath;
		}

		private void DrawTab(Graphics g, TabVS2005 tab)
		{
			Rectangle tabRectangle = GetTabRectangle(tab);
			if (!tabRectangle.IsEmpty)
			{
				DockState dockState = tab.Content.DockHandler.DockState;
				IDockContent content = tab.Content;
				GraphicsPath tabOutline = GetTabOutline(tab, transformed: false, rtlTransform: true);
				Color startColor = base.DockPanel.Skin.AutoHideStripSkin.TabGradient.StartColor;
				Color endColor = base.DockPanel.Skin.AutoHideStripSkin.TabGradient.EndColor;
				LinearGradientMode linearGradientMode = base.DockPanel.Skin.AutoHideStripSkin.TabGradient.LinearGradientMode;
				g.FillPath(new LinearGradientBrush(tabRectangle, startColor, endColor, linearGradientMode), tabOutline);
				g.DrawPath(PenTabBorder, tabOutline);
				Matrix transform = g.Transform;
				g.Transform = MatrixIdentity;
				Rectangle rect = tabRectangle;
				rect.X += ImageGapLeft;
				rect.Y += ImageGapTop;
				int num = tabRectangle.Height - ImageGapTop - ImageGapBottom;
				int num2 = ImageWidth;
				if (num > ImageHeight)
				{
					num2 = ImageWidth * (num / ImageHeight);
				}
				rect.Height = num;
				rect.Width = num2;
				rect = GetTransformedRectangle(dockState, rect);
				g.DrawIcon(((Form)content).Icon, RtlTransform(rect, dockState));
				Rectangle rect2 = tabRectangle;
				rect2.X += ImageGapLeft + num2 + ImageGapRight + TextGapLeft;
				rect2.Width -= ImageGapLeft + num2 + ImageGapRight + TextGapLeft;
				rect2 = RtlTransform(GetTransformedRectangle(dockState, rect2), dockState);
				Color textColor = base.DockPanel.Skin.AutoHideStripSkin.TabGradient.TextColor;
				if (dockState == DockState.DockLeftAutoHide || dockState == DockState.DockRightAutoHide)
				{
					g.DrawString(content.DockHandler.TabText, TextFont, new SolidBrush(textColor), rect2, StringFormatTabVertical);
				}
				else
				{
					g.DrawString(content.DockHandler.TabText, TextFont, new SolidBrush(textColor), rect2, StringFormatTabHorizontal);
				}
				g.Transform = transform;
			}
		}

		private Rectangle GetLogicalTabStripRectangle(DockState dockState)
		{
			return GetLogicalTabStripRectangle(dockState, transformed: false);
		}

		private Rectangle GetLogicalTabStripRectangle(DockState dockState, bool transformed)
		{
			if (!DockHelper.IsDockStateAutoHide(dockState))
			{
				return Rectangle.Empty;
			}
			int count = GetPanes(DockState.DockLeftAutoHide).Count;
			int count2 = GetPanes(DockState.DockRightAutoHide).Count;
			int count3 = GetPanes(DockState.DockTopAutoHide).Count;
			int count4 = GetPanes(DockState.DockBottomAutoHide).Count;
			int num = MeasureHeight();
			int num2;
			int num3;
			int width;
			if (dockState == DockState.DockLeftAutoHide && count > 0)
			{
				num2 = 0;
				num3 = ((count3 != 0) ? num : 0);
				width = base.Height - ((count3 != 0) ? num : 0) - ((count4 != 0) ? num : 0);
			}
			else if (dockState == DockState.DockRightAutoHide && count2 > 0)
			{
				num2 = base.Width - num;
				if (count != 0 && num2 < num)
				{
					num2 = num;
				}
				num3 = ((count3 != 0) ? num : 0);
				width = base.Height - ((count3 != 0) ? num : 0) - ((count4 != 0) ? num : 0);
			}
			else if (dockState == DockState.DockTopAutoHide && count3 > 0)
			{
				num2 = ((count != 0) ? num : 0);
				num3 = 0;
				width = base.Width - ((count != 0) ? num : 0) - ((count2 != 0) ? num : 0);
			}
			else
			{
				if (dockState != DockState.DockBottomAutoHide || count4 <= 0)
				{
					return Rectangle.Empty;
				}
				num2 = ((count != 0) ? num : 0);
				num3 = base.Height - num;
				if (count3 != 0 && num3 < num)
				{
					num3 = num;
				}
				width = base.Width - ((count != 0) ? num : 0) - ((count2 != 0) ? num : 0);
			}
			if (!transformed)
			{
				return new Rectangle(num2, num3, width, num);
			}
			return GetTransformedRectangle(dockState, new Rectangle(num2, num3, width, num));
		}

		private Rectangle GetTabRectangle(TabVS2005 tab)
		{
			return GetTabRectangle(tab, transformed: false);
		}

		private Rectangle GetTabRectangle(TabVS2005 tab, bool transformed)
		{
			DockState dockState = tab.Content.DockHandler.DockState;
			Rectangle logicalTabStripRectangle = GetLogicalTabStripRectangle(dockState);
			if (logicalTabStripRectangle.IsEmpty)
			{
				return Rectangle.Empty;
			}
			int tabX = tab.TabX;
			int y = logicalTabStripRectangle.Y + ((dockState != DockState.DockTopAutoHide && dockState != DockState.DockRightAutoHide) ? TabGapTop : 0);
			int tabWidth = tab.TabWidth;
			int height = logicalTabStripRectangle.Height - TabGapTop;
			if (!transformed)
			{
				return new Rectangle(tabX, y, tabWidth, height);
			}
			return GetTransformedRectangle(dockState, new Rectangle(tabX, y, tabWidth, height));
		}

		private Rectangle GetTransformedRectangle(DockState dockState, Rectangle rect)
		{
			if (dockState != DockState.DockLeftAutoHide && dockState != DockState.DockRightAutoHide)
			{
				return rect;
			}
			PointF[] array = new PointF[1];
			array[0].X = (float)rect.X + (float)rect.Width / 2f;
			array[0].Y = (float)rect.Y + (float)rect.Height / 2f;
			Rectangle logicalTabStripRectangle = GetLogicalTabStripRectangle(dockState);
			Matrix matrix = new Matrix();
			matrix.RotateAt(90f, new PointF((float)logicalTabStripRectangle.X + (float)logicalTabStripRectangle.Height / 2f, (float)logicalTabStripRectangle.Y + (float)logicalTabStripRectangle.Height / 2f));
			matrix.TransformPoints(array);
			return new Rectangle((int)(array[0].X - (float)rect.Height / 2f + 0.5f), (int)(array[0].Y - (float)rect.Width / 2f + 0.5f), rect.Height, rect.Width);
		}

		protected override IDockContent HitTest(Point ptMouse)
		{
			DockState[] dockStates = DockStates;
			foreach (DockState dockState in dockStates)
			{
				if (GetLogicalTabStripRectangle(dockState, transformed: true).Contains(ptMouse))
				{
					foreach (Pane item in (IEnumerable<Pane>)GetPanes(dockState))
					{
						DockState dockState2 = item.DockPane.DockState;
						foreach (TabVS2005 item2 in (IEnumerable<Tab>)item.AutoHideTabs)
						{
							GraphicsPath tabOutline = GetTabOutline(item2, transformed: true, rtlTransform: true);
							if (tabOutline.IsVisible(ptMouse))
							{
								return item2.Content;
							}
						}
					}
				}
			}
			return null;
		}

		protected internal override int MeasureHeight()
		{
			return Math.Max(ImageGapBottom + ImageGapTop + ImageHeight, TextFont.Height) + TabGapTop;
		}

		protected override void OnRefreshChanges()
		{
			CalculateTabs();
			Invalidate();
		}

		protected override Tab CreateTab(IDockContent content)
		{
			return new TabVS2005(content);
		}
	}
}
