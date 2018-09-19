using CIT.Client.Docking.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;

namespace CIT.Client.Docking
{
	[Designer(typeof(ControlDesigner))]
	[LocalizedDescription("DockPanel_Description")]
	[ToolboxBitmap(typeof(resfinder), "CIT.Client.Docking.DockPanel.bmp")]
	[DefaultProperty("DocumentStyle")]
	[DefaultEvent("ActiveContentChanged")]
	public class DockPanel : Panel
	{
		private class AutoHideWindowControl : Panel, ISplitterDragSource, IDragSource
		{
			private class SplitterControl : SplitterBase
			{
				private AutoHideWindowControl m_autoHideWindow;

				private AutoHideWindowControl AutoHideWindow => m_autoHideWindow;

				protected override int SplitterSize => 4;

				public SplitterControl(AutoHideWindowControl autoHideWindow)
				{
					m_autoHideWindow = autoHideWindow;
				}

				protected override void StartDrag()
				{
					AutoHideWindow.DockPanel.BeginDrag(AutoHideWindow, AutoHideWindow.RectangleToScreen(base.Bounds));
				}
			}

			private const int ANIMATE_TIME = 100;

			private Timer m_timerMouseTrack;

			private SplitterControl m_splitter;

			private DockPanel m_dockPanel = null;

			private DockPane m_activePane = null;

			private IDockContent m_activeContent = null;

			private bool m_flagAnimate = true;

			private bool m_flagDragging = false;

			public DockPanel DockPanel => m_dockPanel;

			public DockPane ActivePane => m_activePane;

			public IDockContent ActiveContent
			{
				get
				{
					return m_activeContent;
				}
				set
				{
					if (value != m_activeContent)
					{
						if (value != null && (!DockHelper.IsDockStateAutoHide(value.DockHandler.DockState) || value.DockHandler.DockPanel != DockPanel))
						{
							throw new InvalidOperationException(Strings.DockPanel_ActiveAutoHideContent_InvalidValue);
						}
						DockPanel.SuspendLayout();
						if (m_activeContent != null)
						{
							if (m_activeContent.DockHandler.Form.ContainsFocus)
							{
								DockPanel.ContentFocusManager.GiveUpFocus(m_activeContent);
							}
							AnimateWindow(show: false);
						}
						m_activeContent = value;
						SetActivePane();
						if (ActivePane != null)
						{
							ActivePane.ActiveContent = m_activeContent;
						}
						if (m_activeContent != null)
						{
							AnimateWindow(show: true);
						}
						DockPanel.ResumeLayout();
						DockPanel.RefreshAutoHideStrip();
						SetTimerMouseTrack();
					}
				}
			}

			public DockState DockState => (ActiveContent != null) ? ActiveContent.DockHandler.DockState : DockState.Unknown;

			private bool FlagAnimate
			{
				get
				{
					return m_flagAnimate;
				}
				set
				{
					m_flagAnimate = value;
				}
			}

			internal bool FlagDragging
			{
				get
				{
					return m_flagDragging;
				}
				set
				{
					if (m_flagDragging != value)
					{
						m_flagDragging = value;
						SetTimerMouseTrack();
					}
				}
			}

			protected virtual Rectangle DisplayingRectangle
			{
				get
				{
					Rectangle clientRectangle = base.ClientRectangle;
					if (DockState == DockState.DockBottomAutoHide)
					{
						clientRectangle.Y += 6;
						clientRectangle.Height -= 6;
					}
					else if (DockState == DockState.DockRightAutoHide)
					{
						clientRectangle.X += 6;
						clientRectangle.Width -= 6;
					}
					else if (DockState == DockState.DockTopAutoHide)
					{
						clientRectangle.Height -= 6;
					}
					else if (DockState == DockState.DockLeftAutoHide)
					{
						clientRectangle.Width -= 6;
					}
					return clientRectangle;
				}
			}

			bool ISplitterDragSource.IsVertical
			{
				get
				{
					return DockState == DockState.DockLeftAutoHide || DockState == DockState.DockRightAutoHide;
				}
			}

			Rectangle ISplitterDragSource.DragLimitBounds
			{
				get
				{
					Rectangle dockArea = DockPanel.DockArea;
					if (((ISplitterDragSource)this).IsVertical)
					{
						dockArea.X += 24;
						dockArea.Width -= 48;
					}
					else
					{
						dockArea.Y += 24;
						dockArea.Height -= 48;
					}
					return DockPanel.RectangleToScreen(dockArea);
				}
			}

			Control IDragSource.DragControl
			{
				get
				{
					return this;
				}
			}

			public AutoHideWindowControl(DockPanel dockPanel)
			{
				m_dockPanel = dockPanel;
				m_timerMouseTrack = new Timer();
				m_timerMouseTrack.Tick += TimerMouseTrack_Tick;
				base.Visible = false;
				m_splitter = new SplitterControl(this);
				base.Controls.Add(m_splitter);
			}

			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					m_timerMouseTrack.Dispose();
				}
				base.Dispose(disposing);
			}

			private void SetActivePane()
			{
				DockPane dockPane = (ActiveContent == null) ? null : ActiveContent.DockHandler.Pane;
				if (dockPane != m_activePane)
				{
					m_activePane = dockPane;
				}
			}

			private void AnimateWindow(bool show)
			{
				if (!FlagAnimate && base.Visible != show)
				{
					base.Visible = show;
				}
				else
				{
					base.Parent.SuspendLayout();
					Rectangle rectangle = GetRectangle(!show);
					Rectangle rectangle2 = GetRectangle(show);
					int num3;
					int num2;
					int num;
					int num4 = num3 = (num2 = (num = 0));
					if (DockState == DockState.DockTopAutoHide)
					{
						num = (show ? 1 : (-1));
					}
					else if (DockState == DockState.DockLeftAutoHide)
					{
						num2 = (show ? 1 : (-1));
					}
					else if (DockState == DockState.DockRightAutoHide)
					{
						num4 = ((!show) ? 1 : (-1));
						num2 = (show ? 1 : (-1));
					}
					else if (DockState == DockState.DockBottomAutoHide)
					{
						num3 = ((!show) ? 1 : (-1));
						num = (show ? 1 : (-1));
					}
					if (show)
					{
						base.Bounds = DockPanel.GetAutoHideWindowBounds(new Rectangle(-rectangle2.Width, -rectangle2.Height, rectangle2.Width, rectangle2.Height));
						if (!base.Visible)
						{
							base.Visible = true;
						}
						PerformLayout();
					}
					SuspendLayout();
					LayoutAnimateWindow(rectangle);
					if (!base.Visible)
					{
						base.Visible = true;
					}
					int num5 = 1;
					int num6 = (rectangle.Width != rectangle2.Width) ? Math.Abs(rectangle.Width - rectangle2.Width) : Math.Abs(rectangle.Height - rectangle2.Height);
					int num7 = num6;
					DateTime now = DateTime.Now;
					while (rectangle != rectangle2)
					{
						DateTime now2 = DateTime.Now;
						rectangle.X += num4 * num5;
						rectangle.Y += num3 * num5;
						rectangle.Width += num2 * num5;
						rectangle.Height += num * num5;
						if (Math.Sign(rectangle2.X - rectangle.X) != Math.Sign(num4))
						{
							rectangle.X = rectangle2.X;
						}
						if (Math.Sign(rectangle2.Y - rectangle.Y) != Math.Sign(num3))
						{
							rectangle.Y = rectangle2.Y;
						}
						if (Math.Sign(rectangle2.Width - rectangle.Width) != Math.Sign(num2))
						{
							rectangle.Width = rectangle2.Width;
						}
						if (Math.Sign(rectangle2.Height - rectangle.Height) != Math.Sign(num))
						{
							rectangle.Height = rectangle2.Height;
						}
						LayoutAnimateWindow(rectangle);
						if (base.Parent != null)
						{
							base.Parent.Update();
						}
						num7 -= num5;
						do
						{
							bool flag = true;
							TimeSpan t = new TimeSpan(0, 0, 0, 0, 100);
							TimeSpan timeSpan = DateTime.Now - now2;
							TimeSpan t2 = DateTime.Now - now;
							if ((int)(t - t2).TotalMilliseconds <= 0)
							{
								num5 = num7;
								break;
							}
							num5 = num7 * (int)timeSpan.TotalMilliseconds / (int)(t - t2).TotalMilliseconds;
						}
						while (num5 < 1);
					}
					ResumeLayout();
					base.Parent.ResumeLayout();
				}
			}

			private void LayoutAnimateWindow(Rectangle rect)
			{
				base.Bounds = DockPanel.GetAutoHideWindowBounds(rect);
				Rectangle clientRectangle = base.ClientRectangle;
				if (DockState == DockState.DockLeftAutoHide)
				{
					ActivePane.Location = new Point(clientRectangle.Right - 2 - 4 - ActivePane.Width, ActivePane.Location.Y);
				}
				else if (DockState == DockState.DockTopAutoHide)
				{
					ActivePane.Location = new Point(ActivePane.Location.X, clientRectangle.Bottom - 2 - 4 - ActivePane.Height);
				}
			}

			private Rectangle GetRectangle(bool show)
			{
				if (DockState == DockState.Unknown)
				{
					return Rectangle.Empty;
				}
				Rectangle autoHideWindowRectangle = DockPanel.AutoHideWindowRectangle;
				if (show)
				{
					return autoHideWindowRectangle;
				}
				if (DockState == DockState.DockLeftAutoHide)
				{
					autoHideWindowRectangle.Width = 0;
				}
				else if (DockState == DockState.DockRightAutoHide)
				{
					autoHideWindowRectangle.X += autoHideWindowRectangle.Width;
					autoHideWindowRectangle.Width = 0;
				}
				else if (DockState == DockState.DockTopAutoHide)
				{
					autoHideWindowRectangle.Height = 0;
				}
				else
				{
					autoHideWindowRectangle.Y += autoHideWindowRectangle.Height;
					autoHideWindowRectangle.Height = 0;
				}
				return autoHideWindowRectangle;
			}

			private void SetTimerMouseTrack()
			{
				if (ActivePane == null || ActivePane.IsActivated || FlagDragging)
				{
					m_timerMouseTrack.Enabled = false;
				}
				else
				{
					int num = SystemInformation.MouseHoverTime;
					if (num <= 0)
					{
						num = 400;
					}
					m_timerMouseTrack.Interval = 2 * num;
					m_timerMouseTrack.Enabled = true;
				}
			}

			protected override void OnLayout(LayoutEventArgs levent)
			{
				base.DockPadding.All = 0;
				if (DockState == DockState.DockLeftAutoHide)
				{
					base.DockPadding.Right = 2;
					m_splitter.Dock = DockStyle.Right;
				}
				else if (DockState == DockState.DockRightAutoHide)
				{
					base.DockPadding.Left = 2;
					m_splitter.Dock = DockStyle.Left;
				}
				else if (DockState == DockState.DockTopAutoHide)
				{
					base.DockPadding.Bottom = 2;
					m_splitter.Dock = DockStyle.Bottom;
				}
				else if (DockState == DockState.DockBottomAutoHide)
				{
					base.DockPadding.Top = 2;
					m_splitter.Dock = DockStyle.Top;
				}
				Rectangle displayingRectangle = DisplayingRectangle;
				Rectangle bounds = new Rectangle(-displayingRectangle.Width, displayingRectangle.Y, displayingRectangle.Width, displayingRectangle.Height);
				foreach (Control control in base.Controls)
				{
					DockPane dockPane = control as DockPane;
					if (dockPane != null)
					{
						if (dockPane == ActivePane)
						{
							dockPane.Bounds = displayingRectangle;
						}
						else
						{
							dockPane.Bounds = bounds;
						}
					}
				}
				base.OnLayout(levent);
			}

			protected override void OnPaint(PaintEventArgs e)
			{
				Graphics graphics = e.Graphics;
				if (DockState == DockState.DockBottomAutoHide)
				{
					graphics.DrawLine(SystemPens.ControlLightLight, 0, 1, base.ClientRectangle.Right, 1);
				}
				else if (DockState == DockState.DockRightAutoHide)
				{
					graphics.DrawLine(SystemPens.ControlLightLight, 1, 0, 1, base.ClientRectangle.Bottom);
				}
				else if (DockState == DockState.DockTopAutoHide)
				{
					graphics.DrawLine(SystemPens.ControlDark, 0, base.ClientRectangle.Height - 2, base.ClientRectangle.Right, base.ClientRectangle.Height - 2);
					graphics.DrawLine(SystemPens.ControlDarkDark, 0, base.ClientRectangle.Height - 1, base.ClientRectangle.Right, base.ClientRectangle.Height - 1);
				}
				else if (DockState == DockState.DockLeftAutoHide)
				{
					graphics.DrawLine(SystemPens.ControlDark, base.ClientRectangle.Width - 2, 0, base.ClientRectangle.Width - 2, base.ClientRectangle.Bottom);
					graphics.DrawLine(SystemPens.ControlDarkDark, base.ClientRectangle.Width - 1, 0, base.ClientRectangle.Width - 1, base.ClientRectangle.Bottom);
				}
				base.OnPaint(e);
			}

			public void RefreshActiveContent()
			{
				if (ActiveContent != null && !DockHelper.IsDockStateAutoHide(ActiveContent.DockHandler.DockState))
				{
					FlagAnimate = false;
					ActiveContent = null;
					FlagAnimate = true;
				}
			}

			public void RefreshActivePane()
			{
				SetTimerMouseTrack();
			}

			private void TimerMouseTrack_Tick(object sender, EventArgs e)
			{
				if (!base.IsDisposed)
				{
					if (ActivePane == null || ActivePane.IsActivated)
					{
						m_timerMouseTrack.Enabled = false;
					}
					else
					{
						DockPane activePane = ActivePane;
						Point pt = PointToClient(Control.MousePosition);
						Point pt2 = DockPanel.PointToClient(Control.MousePosition);
						Rectangle tabStripRectangle = DockPanel.GetTabStripRectangle(activePane.DockState);
						if (!base.ClientRectangle.Contains(pt) && !tabStripRectangle.Contains(pt2))
						{
							ActiveContent = null;
							m_timerMouseTrack.Enabled = false;
						}
					}
				}
			}

			void ISplitterDragSource.BeginDrag(Rectangle rectSplitter)
			{
				FlagDragging = true;
			}

			void ISplitterDragSource.EndDrag()
			{
				FlagDragging = false;
			}

			void ISplitterDragSource.MoveSplitter(int offset)
			{
				Rectangle dockArea = DockPanel.DockArea;
				IDockContent activeContent = ActiveContent;
				if (DockState == DockState.DockLeftAutoHide && dockArea.Width > 0)
				{
					if (activeContent.DockHandler.AutoHidePortion < 1.0)
					{
						activeContent.DockHandler.AutoHidePortion += (double)offset / (double)dockArea.Width;
					}
					else
					{
						activeContent.DockHandler.AutoHidePortion = (double)(base.Width + offset);
					}
				}
				else if (DockState == DockState.DockRightAutoHide && dockArea.Width > 0)
				{
					if (activeContent.DockHandler.AutoHidePortion < 1.0)
					{
						activeContent.DockHandler.AutoHidePortion -= (double)offset / (double)dockArea.Width;
					}
					else
					{
						activeContent.DockHandler.AutoHidePortion = (double)(base.Width - offset);
					}
				}
				else if (DockState == DockState.DockBottomAutoHide && dockArea.Height > 0)
				{
					if (activeContent.DockHandler.AutoHidePortion < 1.0)
					{
						activeContent.DockHandler.AutoHidePortion -= (double)offset / (double)dockArea.Height;
					}
					else
					{
						activeContent.DockHandler.AutoHidePortion = (double)(base.Height - offset);
					}
				}
				else if (DockState == DockState.DockTopAutoHide && dockArea.Height > 0)
				{
					if (activeContent.DockHandler.AutoHidePortion < 1.0)
					{
						activeContent.DockHandler.AutoHidePortion += (double)offset / (double)dockArea.Height;
					}
					else
					{
						activeContent.DockHandler.AutoHidePortion = (double)(base.Height + offset);
					}
				}
			}
		}

		private abstract class DragHandlerBase : NativeWindow, IMessageFilter
		{
			private Point m_startMousePosition = Point.Empty;

			protected abstract Control DragControl
			{
				get;
			}

			protected Point StartMousePosition
			{
				get
				{
					return m_startMousePosition;
				}
				private set
				{
					m_startMousePosition = value;
				}
			}

			protected bool BeginDrag()
			{
				lock (this)
				{
					if (DragControl == null)
					{
						return false;
					}
					StartMousePosition = Control.MousePosition;
					if (!NativeMethods.DragDetect(DragControl.Handle, StartMousePosition))
					{
						return false;
					}
					DragControl.FindForm().Capture = true;
					AssignHandle(DragControl.FindForm().Handle);
					Application.AddMessageFilter(this);
					return true;
				}
			}

			protected abstract void OnDragging();

			protected abstract void OnEndDrag(bool abort);

			private void EndDrag(bool abort)
			{
				ReleaseHandle();
				Application.RemoveMessageFilter(this);
				DragControl.FindForm().Capture = false;
				OnEndDrag(abort);
			}

			bool IMessageFilter.PreFilterMessage(ref Message m)
			{
				if (m.Msg == 512)
				{
					OnDragging();
				}
				else if (m.Msg == 514)
				{
					EndDrag(abort: false);
				}
				else if (m.Msg == 533)
				{
					EndDrag(abort: true);
				}
				else if (m.Msg == 256 && (int)m.WParam == 27)
				{
					EndDrag(abort: true);
				}
				return OnPreFilterMessage(ref m);
			}

			protected virtual bool OnPreFilterMessage(ref Message m)
			{
				return false;
			}

			protected sealed override void WndProc(ref Message m)
			{
				if (m.Msg == 31 || m.Msg == 533)
				{
					EndDrag(abort: true);
				}
				base.WndProc(ref m);
			}
		}

		private abstract class DragHandler : DragHandlerBase
		{
			private DockPanel m_dockPanel;

			private IDragSource m_dragSource;

			public DockPanel DockPanel => m_dockPanel;

			protected IDragSource DragSource
			{
				get
				{
					return m_dragSource;
				}
				set
				{
					m_dragSource = value;
				}
			}

			protected sealed override Control DragControl => (DragSource == null) ? null : DragSource.DragControl;

			protected DragHandler(DockPanel dockPanel)
			{
				m_dockPanel = dockPanel;
			}

			protected sealed override bool OnPreFilterMessage(ref Message m)
			{
				if ((m.Msg == 256 || m.Msg == 257) && ((int)m.WParam == 17 || (int)m.WParam == 16))
				{
					OnDragging();
				}
				return base.OnPreFilterMessage(ref m);
			}
		}

		private sealed class DockDragHandler : DragHandler
		{
			private class DockIndicator : DragForm
			{
				private interface IHitTest
				{
					DockStyle Status
					{
						get;
						set;
					}

					DockStyle HitTest(Point pt);
				}

				private class PanelIndicator : PictureBox, IHitTest
				{
					private static Image _imagePanelLeft = Resources.DockIndicator_PanelLeft;

					private static Image _imagePanelRight = Resources.DockIndicator_PanelRight;

					private static Image _imagePanelTop = Resources.DockIndicator_PanelTop;

					private static Image _imagePanelBottom = Resources.DockIndicator_PanelBottom;

					private static Image _imagePanelFill = Resources.DockIndicator_PanelFill;

					private static Image _imagePanelLeftActive = Resources.DockIndicator_PanelLeft_Active;

					private static Image _imagePanelRightActive = Resources.DockIndicator_PanelRight_Active;

					private static Image _imagePanelTopActive = Resources.DockIndicator_PanelTop_Active;

					private static Image _imagePanelBottomActive = Resources.DockIndicator_PanelBottom_Active;

					private static Image _imagePanelFillActive = Resources.DockIndicator_PanelFill_Active;

					private DockStyle m_dockStyle;

					private DockStyle m_status;

					private bool m_isActivated = false;

					private DockStyle DockStyle => m_dockStyle;

					public DockStyle Status
					{
						get
						{
							return m_status;
						}
						set
						{
							if (value != DockStyle && value != 0)
							{
								throw new InvalidEnumArgumentException();
							}
							if (m_status != value)
							{
								m_status = value;
								IsActivated = (m_status != DockStyle.None);
							}
						}
					}

					private Image ImageInactive
					{
						get
						{
							if (DockStyle == DockStyle.Left)
							{
								return _imagePanelLeft;
							}
							if (DockStyle == DockStyle.Right)
							{
								return _imagePanelRight;
							}
							if (DockStyle == DockStyle.Top)
							{
								return _imagePanelTop;
							}
							if (DockStyle == DockStyle.Bottom)
							{
								return _imagePanelBottom;
							}
							if (DockStyle == DockStyle.Fill)
							{
								return _imagePanelFill;
							}
							return null;
						}
					}

					private Image ImageActive
					{
						get
						{
							if (DockStyle == DockStyle.Left)
							{
								return _imagePanelLeftActive;
							}
							if (DockStyle == DockStyle.Right)
							{
								return _imagePanelRightActive;
							}
							if (DockStyle == DockStyle.Top)
							{
								return _imagePanelTopActive;
							}
							if (DockStyle == DockStyle.Bottom)
							{
								return _imagePanelBottomActive;
							}
							if (DockStyle == DockStyle.Fill)
							{
								return _imagePanelFillActive;
							}
							return null;
						}
					}

					private bool IsActivated
					{
						get
						{
							return m_isActivated;
						}
						set
						{
							m_isActivated = value;
							base.Image = (IsActivated ? ImageActive : ImageInactive);
						}
					}

					public PanelIndicator(DockStyle dockStyle)
					{
						m_dockStyle = dockStyle;
						base.SizeMode = PictureBoxSizeMode.AutoSize;
						base.Image = ImageInactive;
					}

					public DockStyle HitTest(Point pt)
					{
						return (base.Visible && base.ClientRectangle.Contains(PointToClient(pt))) ? DockStyle : DockStyle.None;
					}
				}

				private class PaneIndicator : PictureBox, IHitTest
				{
					private struct HotSpotIndex
					{
						private int m_x;

						private int m_y;

						private DockStyle m_dockStyle;

						public int X => m_x;

						public int Y => m_y;

						public DockStyle DockStyle => m_dockStyle;

						public HotSpotIndex(int x, int y, DockStyle dockStyle)
						{
							m_x = x;
							m_y = y;
							m_dockStyle = dockStyle;
						}
					}

					private static Bitmap _bitmapPaneDiamond = Resources.DockIndicator_PaneDiamond;

					private static Bitmap _bitmapPaneDiamondLeft = Resources.DockIndicator_PaneDiamond_Left;

					private static Bitmap _bitmapPaneDiamondRight = Resources.DockIndicator_PaneDiamond_Right;

					private static Bitmap _bitmapPaneDiamondTop = Resources.DockIndicator_PaneDiamond_Top;

					private static Bitmap _bitmapPaneDiamondBottom = Resources.DockIndicator_PaneDiamond_Bottom;

					private static Bitmap _bitmapPaneDiamondFill = Resources.DockIndicator_PaneDiamond_Fill;

					private static Bitmap _bitmapPaneDiamondHotSpot = Resources.DockIndicator_PaneDiamond_HotSpot;

					private static Bitmap _bitmapPaneDiamondHotSpotIndex = Resources.DockIndicator_PaneDiamond_HotSpotIndex;

					private static HotSpotIndex[] _hotSpots = new HotSpotIndex[5]
					{
						new HotSpotIndex(1, 0, DockStyle.Top),
						new HotSpotIndex(0, 1, DockStyle.Left),
						new HotSpotIndex(1, 1, DockStyle.Fill),
						new HotSpotIndex(2, 1, DockStyle.Right),
						new HotSpotIndex(1, 2, DockStyle.Bottom)
					};

					private static GraphicsPath _displayingGraphicsPath = DrawHelper.CalculateGraphicsPathFromBitmap(_bitmapPaneDiamond);

					private DockStyle m_status = DockStyle.None;

					public static GraphicsPath DisplayingGraphicsPath => _displayingGraphicsPath;

					public DockStyle Status
					{
						get
						{
							return m_status;
						}
						set
						{
							m_status = value;
							if (m_status == DockStyle.None)
							{
								base.Image = _bitmapPaneDiamond;
							}
							else if (m_status == DockStyle.Left)
							{
								base.Image = _bitmapPaneDiamondLeft;
							}
							else if (m_status == DockStyle.Right)
							{
								base.Image = _bitmapPaneDiamondRight;
							}
							else if (m_status == DockStyle.Top)
							{
								base.Image = _bitmapPaneDiamondTop;
							}
							else if (m_status == DockStyle.Bottom)
							{
								base.Image = _bitmapPaneDiamondBottom;
							}
							else if (m_status == DockStyle.Fill)
							{
								base.Image = _bitmapPaneDiamondFill;
							}
						}
					}

					public PaneIndicator()
					{
						base.SizeMode = PictureBoxSizeMode.AutoSize;
						base.Image = _bitmapPaneDiamond;
						base.Region = new Region(DisplayingGraphicsPath);
					}

					public DockStyle HitTest(Point pt)
					{
						if (!base.Visible)
						{
							return DockStyle.None;
						}
						pt = PointToClient(pt);
						if (!base.ClientRectangle.Contains(pt))
						{
							return DockStyle.None;
						}
						for (int i = _hotSpots.GetLowerBound(0); i <= _hotSpots.GetUpperBound(0); i++)
						{
							if (_bitmapPaneDiamondHotSpot.GetPixel(pt.X, pt.Y) == _bitmapPaneDiamondHotSpotIndex.GetPixel(_hotSpots[i].X, _hotSpots[i].Y))
							{
								return _hotSpots[i].DockStyle;
							}
						}
						return DockStyle.None;
					}
				}

				private int _PanelIndicatorMargin = 10;

				private DockDragHandler m_dragHandler;

				private PaneIndicator m_paneDiamond = null;

				private PanelIndicator m_panelLeft = null;

				private PanelIndicator m_panelRight = null;

				private PanelIndicator m_panelTop = null;

				private PanelIndicator m_panelBottom = null;

				private PanelIndicator m_panelFill = null;

				private bool m_fullPanelEdge = false;

				private DockPane m_dockPane = null;

				private IHitTest m_hitTest = null;

				private PaneIndicator PaneDiamond
				{
					get
					{
						if (m_paneDiamond == null)
						{
							m_paneDiamond = new PaneIndicator();
						}
						return m_paneDiamond;
					}
				}

				private PanelIndicator PanelLeft
				{
					get
					{
						if (m_panelLeft == null)
						{
							m_panelLeft = new PanelIndicator(DockStyle.Left);
						}
						return m_panelLeft;
					}
				}

				private PanelIndicator PanelRight
				{
					get
					{
						if (m_panelRight == null)
						{
							m_panelRight = new PanelIndicator(DockStyle.Right);
						}
						return m_panelRight;
					}
				}

				private PanelIndicator PanelTop
				{
					get
					{
						if (m_panelTop == null)
						{
							m_panelTop = new PanelIndicator(DockStyle.Top);
						}
						return m_panelTop;
					}
				}

				private PanelIndicator PanelBottom
				{
					get
					{
						if (m_panelBottom == null)
						{
							m_panelBottom = new PanelIndicator(DockStyle.Bottom);
						}
						return m_panelBottom;
					}
				}

				private PanelIndicator PanelFill
				{
					get
					{
						if (m_panelFill == null)
						{
							m_panelFill = new PanelIndicator(DockStyle.Fill);
						}
						return m_panelFill;
					}
				}

				public bool FullPanelEdge
				{
					get
					{
						return m_fullPanelEdge;
					}
					set
					{
						if (m_fullPanelEdge != value)
						{
							m_fullPanelEdge = value;
							RefreshChanges();
						}
					}
				}

				public DockDragHandler DragHandler => m_dragHandler;

				public DockPanel DockPanel => DragHandler.DockPanel;

				public DockPane DockPane
				{
					get
					{
						return m_dockPane;
					}
					internal set
					{
						if (m_dockPane != value)
						{
							DockPane displayingPane = DisplayingPane;
							m_dockPane = value;
							if (displayingPane != DisplayingPane)
							{
								RefreshChanges();
							}
						}
					}
				}

				private IHitTest HitTestResult
				{
					get
					{
						return m_hitTest;
					}
					set
					{
						if (m_hitTest != value)
						{
							if (m_hitTest != null)
							{
								m_hitTest.Status = DockStyle.None;
							}
							m_hitTest = value;
						}
					}
				}

				private DockPane DisplayingPane => ShouldPaneDiamondVisible() ? DockPane : null;

				public DockIndicator(DockDragHandler dragHandler)
				{
					m_dragHandler = dragHandler;
					base.Controls.AddRange(new Control[6]
					{
						PaneDiamond,
						PanelLeft,
						PanelRight,
						PanelTop,
						PanelBottom,
						PanelFill
					});
					base.Region = new Region(Rectangle.Empty);
				}

				private void RefreshChanges()
				{
					Region region = new Region(Rectangle.Empty);
					Rectangle r = FullPanelEdge ? DockPanel.DockArea : DockPanel.DocumentWindowBounds;
					r = RectangleToClient(DockPanel.RectangleToScreen(r));
					if (ShouldPanelIndicatorVisible(DockState.DockLeft))
					{
						PanelLeft.Location = new Point(r.X + _PanelIndicatorMargin, r.Y + (r.Height - PanelRight.Height) / 2);
						PanelLeft.Visible = true;
						region.Union(PanelLeft.Bounds);
					}
					else
					{
						PanelLeft.Visible = false;
					}
					if (ShouldPanelIndicatorVisible(DockState.DockRight))
					{
						PanelRight.Location = new Point(r.X + r.Width - PanelRight.Width - _PanelIndicatorMargin, r.Y + (r.Height - PanelRight.Height) / 2);
						PanelRight.Visible = true;
						region.Union(PanelRight.Bounds);
					}
					else
					{
						PanelRight.Visible = false;
					}
					if (ShouldPanelIndicatorVisible(DockState.DockTop))
					{
						PanelTop.Location = new Point(r.X + (r.Width - PanelTop.Width) / 2, r.Y + _PanelIndicatorMargin);
						PanelTop.Visible = true;
						region.Union(PanelTop.Bounds);
					}
					else
					{
						PanelTop.Visible = false;
					}
					if (ShouldPanelIndicatorVisible(DockState.DockBottom))
					{
						PanelBottom.Location = new Point(r.X + (r.Width - PanelBottom.Width) / 2, r.Y + r.Height - PanelBottom.Height - _PanelIndicatorMargin);
						PanelBottom.Visible = true;
						region.Union(PanelBottom.Bounds);
					}
					else
					{
						PanelBottom.Visible = false;
					}
					if (ShouldPanelIndicatorVisible(DockState.Document))
					{
						Rectangle rectangle = RectangleToClient(DockPanel.RectangleToScreen(DockPanel.DocumentWindowBounds));
						PanelFill.Location = new Point(rectangle.X + (rectangle.Width - PanelFill.Width) / 2, rectangle.Y + (rectangle.Height - PanelFill.Height) / 2);
						PanelFill.Visible = true;
						region.Union(PanelFill.Bounds);
					}
					else
					{
						PanelFill.Visible = false;
					}
					if (ShouldPaneDiamondVisible())
					{
						Rectangle rectangle2 = RectangleToClient(DockPane.RectangleToScreen(DockPane.ClientRectangle));
						PaneDiamond.Location = new Point(rectangle2.Left + (rectangle2.Width - PaneDiamond.Width) / 2, rectangle2.Top + (rectangle2.Height - PaneDiamond.Height) / 2);
						PaneDiamond.Visible = true;
						using (GraphicsPath graphicsPath = PaneIndicator.DisplayingGraphicsPath.Clone() as GraphicsPath)
						{
							Point[] plgpts = new Point[3]
							{
								new Point(PaneDiamond.Left, PaneDiamond.Top),
								new Point(PaneDiamond.Right, PaneDiamond.Top),
								new Point(PaneDiamond.Left, PaneDiamond.Bottom)
							};
							using (Matrix matrix = new Matrix(PaneDiamond.ClientRectangle, plgpts))
							{
								graphicsPath.Transform(matrix);
							}
							region.Union(graphicsPath);
						}
					}
					else
					{
						PaneDiamond.Visible = false;
					}
					base.Region = region;
				}

				private bool ShouldPanelIndicatorVisible(DockState dockState)
				{
					if (!base.Visible)
					{
						return false;
					}
					if (DockPanel.DockWindows[dockState].Visible)
					{
						return false;
					}
					return DragHandler.DragSource.IsDockStateValid(dockState);
				}

				private bool ShouldPaneDiamondVisible()
				{
					if (DockPane == null)
					{
						return false;
					}
					if (!DockPanel.AllowEndUserNestedDocking)
					{
						return false;
					}
					return DragHandler.DragSource.CanDockTo(DockPane);
				}

				public override void Show(bool bActivate)
				{
					base.Show(bActivate);
					base.Bounds = SystemInformation.VirtualScreen;
					RefreshChanges();
				}

				public void TestDrop()
				{
					Point mousePosition = Control.MousePosition;
					DockPane = DockHelper.PaneAtPoint(mousePosition, DockPanel);
					if (TestDrop(PanelLeft, mousePosition) != 0)
					{
						HitTestResult = PanelLeft;
					}
					else if (TestDrop(PanelRight, mousePosition) != 0)
					{
						HitTestResult = PanelRight;
					}
					else if (TestDrop(PanelTop, mousePosition) != 0)
					{
						HitTestResult = PanelTop;
					}
					else if (TestDrop(PanelBottom, mousePosition) != 0)
					{
						HitTestResult = PanelBottom;
					}
					else if (TestDrop(PanelFill, mousePosition) != 0)
					{
						HitTestResult = PanelFill;
					}
					else if (TestDrop(PaneDiamond, mousePosition) != 0)
					{
						HitTestResult = PaneDiamond;
					}
					else
					{
						HitTestResult = null;
					}
					if (HitTestResult != null)
					{
						if (HitTestResult is PaneIndicator)
						{
							DragHandler.Outline.Show(DockPane, HitTestResult.Status);
						}
						else
						{
							DragHandler.Outline.Show(DockPanel, HitTestResult.Status, FullPanelEdge);
						}
					}
				}

				private static DockStyle TestDrop(IHitTest hitTest, Point pt)
				{
					return hitTest.Status = hitTest.HitTest(pt);
				}
			}

			private class DockOutline : DockOutlineBase
			{
				private DragForm m_dragForm;

				private DragForm DragForm => m_dragForm;

				public DockOutline()
				{
					m_dragForm = new DragForm();
					SetDragForm(Rectangle.Empty);
					DragForm.BackColor = SystemColors.ActiveCaption;
					DragForm.Opacity = 0.5;
					DragForm.Show(bActivate: false);
				}

				protected override void OnShow()
				{
					CalculateRegion();
				}

				protected override void OnClose()
				{
					DragForm.Close();
				}

				private void CalculateRegion()
				{
					if (!base.SameAsOldValue)
					{
						if (!base.FloatWindowBounds.IsEmpty)
						{
							SetOutline(base.FloatWindowBounds);
						}
						else if (base.DockTo is DockPanel)
						{
							SetOutline(base.DockTo as DockPanel, base.Dock, base.ContentIndex != 0);
						}
						else if (base.DockTo is DockPane)
						{
							SetOutline(base.DockTo as DockPane, base.Dock, base.ContentIndex);
						}
						else
						{
							SetOutline();
						}
					}
				}

				private void SetOutline()
				{
					SetDragForm(Rectangle.Empty);
				}

				private void SetOutline(Rectangle floatWindowBounds)
				{
					SetDragForm(floatWindowBounds);
				}

				private void SetOutline(DockPanel dockPanel, DockStyle dock, bool fullPanelEdge)
				{
					Rectangle dragForm = fullPanelEdge ? dockPanel.DockArea : dockPanel.DocumentWindowBounds;
					dragForm.Location = dockPanel.PointToScreen(dragForm.Location);
					switch (dock)
					{
					case DockStyle.Top:
					{
						int dockWindowSize2 = dockPanel.GetDockWindowSize(DockState.DockTop);
						dragForm = new Rectangle(dragForm.X, dragForm.Y, dragForm.Width, dockWindowSize2);
						break;
					}
					case DockStyle.Bottom:
					{
						int dockWindowSize2 = dockPanel.GetDockWindowSize(DockState.DockBottom);
						dragForm = new Rectangle(dragForm.X, dragForm.Bottom - dockWindowSize2, dragForm.Width, dockWindowSize2);
						break;
					}
					case DockStyle.Left:
					{
						int dockWindowSize = dockPanel.GetDockWindowSize(DockState.DockLeft);
						dragForm = new Rectangle(dragForm.X, dragForm.Y, dockWindowSize, dragForm.Height);
						break;
					}
					case DockStyle.Right:
					{
						int dockWindowSize = dockPanel.GetDockWindowSize(DockState.DockRight);
						dragForm = new Rectangle(dragForm.Right - dockWindowSize, dragForm.Y, dockWindowSize, dragForm.Height);
						break;
					}
					case DockStyle.Fill:
						dragForm = dockPanel.DocumentWindowBounds;
						dragForm.Location = dockPanel.PointToScreen(dragForm.Location);
						break;
					}
					SetDragForm(dragForm);
				}

				private void SetOutline(DockPane pane, DockStyle dock, int contentIndex)
				{
					if (dock != DockStyle.Fill)
					{
						Rectangle displayingRectangle = pane.DisplayingRectangle;
						if (dock == DockStyle.Right)
						{
							displayingRectangle.X += displayingRectangle.Width / 2;
						}
						if (dock == DockStyle.Bottom)
						{
							displayingRectangle.Y += displayingRectangle.Height / 2;
						}
						if (dock == DockStyle.Left || dock == DockStyle.Right)
						{
							displayingRectangle.Width -= displayingRectangle.Width / 2;
						}
						if (dock == DockStyle.Top || dock == DockStyle.Bottom)
						{
							displayingRectangle.Height -= displayingRectangle.Height / 2;
						}
						displayingRectangle.Location = pane.PointToScreen(displayingRectangle.Location);
						SetDragForm(displayingRectangle);
					}
					else if (contentIndex == -1)
					{
						Rectangle displayingRectangle = pane.DisplayingRectangle;
						displayingRectangle.Location = pane.PointToScreen(displayingRectangle.Location);
						SetDragForm(displayingRectangle);
					}
					else
					{
						using (GraphicsPath graphicsPath = pane.TabStripControl.GetOutline(contentIndex))
						{
							RectangleF bounds = graphicsPath.GetBounds();
							Rectangle displayingRectangle = new Rectangle((int)bounds.X, (int)bounds.Y, (int)bounds.Width, (int)bounds.Height);
							using (Matrix matrix = new Matrix(displayingRectangle, new Point[3]
							{
								new Point(0, 0),
								new Point(displayingRectangle.Width, 0),
								new Point(0, displayingRectangle.Height)
							}))
							{
								graphicsPath.Transform(matrix);
							}
							Region region = new Region(graphicsPath);
							SetDragForm(displayingRectangle, region);
						}
					}
				}

				private void SetDragForm(Rectangle rect)
				{
					DragForm.Bounds = rect;
					if (rect == Rectangle.Empty)
					{
						DragForm.Region = new Region(Rectangle.Empty);
					}
					else if (DragForm.Region != null)
					{
						DragForm.Region = null;
					}
				}

				private void SetDragForm(Rectangle rect, Region region)
				{
					DragForm.Bounds = rect;
					DragForm.Region = region;
				}
			}

			private DockOutlineBase m_outline;

			private DockIndicator m_indicator;

			private Rectangle m_floatOutlineBounds;

			public new IDockDragSource DragSource
			{
				get
				{
					return base.DragSource as IDockDragSource;
				}
				set
				{
					base.DragSource = value;
				}
			}

			public DockOutlineBase Outline
			{
				get
				{
					return m_outline;
				}
				private set
				{
					m_outline = value;
				}
			}

			private DockIndicator Indicator
			{
				get
				{
					return m_indicator;
				}
				set
				{
					m_indicator = value;
				}
			}

			private Rectangle FloatOutlineBounds
			{
				get
				{
					return m_floatOutlineBounds;
				}
				set
				{
					m_floatOutlineBounds = value;
				}
			}

			public DockDragHandler(DockPanel panel)
				: base(panel)
			{
			}

			public void BeginDrag(IDockDragSource dragSource)
			{
				DragSource = dragSource;
				if (!BeginDrag())
				{
					DragSource = null;
				}
				else
				{
					Outline = new DockOutline();
					Indicator = new DockIndicator(this);
					Indicator.Show(bActivate: false);
					FloatOutlineBounds = DragSource.BeginDrag(base.StartMousePosition);
				}
			}

			protected override void OnDragging()
			{
				TestDrop();
			}

			protected override void OnEndDrag(bool abort)
			{
				base.DockPanel.SuspendLayout(allWindows: true);
				Outline.Close();
				Indicator.Close();
				EndDrag(abort);
				base.DockPanel.PerformMdiClientLayout();
				base.DockPanel.ResumeLayout(performLayout: true, allWindows: true);
				DragSource = null;
			}

			private void TestDrop()
			{
				Outline.FlagTestDrop = false;
				Indicator.FullPanelEdge = ((Control.ModifierKeys & Keys.Shift) != Keys.None);
				if ((Control.ModifierKeys & Keys.Control) == Keys.None)
				{
					Indicator.TestDrop();
					if (!Outline.FlagTestDrop)
					{
						DockPane dockPane = DockHelper.PaneAtPoint(Control.MousePosition, base.DockPanel);
						if (dockPane != null && DragSource.IsDockStateValid(dockPane.DockState))
						{
							dockPane.TestDrop(DragSource, Outline);
						}
					}
					if (!Outline.FlagTestDrop && DragSource.IsDockStateValid(DockState.Float))
					{
						DockHelper.FloatWindowAtPoint(Control.MousePosition, base.DockPanel)?.TestDrop(DragSource, Outline);
					}
				}
				else
				{
					Indicator.DockPane = DockHelper.PaneAtPoint(Control.MousePosition, base.DockPanel);
				}
				if (!Outline.FlagTestDrop && DragSource.IsDockStateValid(DockState.Float))
				{
					Rectangle floatOutlineBounds = FloatOutlineBounds;
					floatOutlineBounds.Offset(Control.MousePosition.X - base.StartMousePosition.X, Control.MousePosition.Y - base.StartMousePosition.Y);
					Outline.Show(floatOutlineBounds);
				}
				if (!Outline.FlagTestDrop)
				{
					Cursor.Current = Cursors.No;
					Outline.Show();
				}
				else
				{
					Cursor.Current = DragControl.Cursor;
				}
			}

			private void EndDrag(bool abort)
			{
				if (!abort)
				{
					if (!Outline.FloatWindowBounds.IsEmpty)
					{
						DragSource.FloatAt(Outline.FloatWindowBounds);
					}
					else if (Outline.DockTo is DockPane)
					{
						DockPane pane = Outline.DockTo as DockPane;
						DragSource.DockTo(pane, Outline.Dock, Outline.ContentIndex);
					}
					else if (Outline.DockTo is DockPanel)
					{
						DockPanel dockPanel = Outline.DockTo as DockPanel;
						dockPanel.UpdateDockWindowZOrder(Outline.Dock, Outline.FlagFullEdge);
						DragSource.DockTo(dockPanel, Outline.Dock);
					}
				}
			}
		}

		private interface IFocusManager
		{
			bool IsFocusTrackingSuspended
			{
				get;
			}

			IDockContent ActiveContent
			{
				get;
			}

			DockPane ActivePane
			{
				get;
			}

			IDockContent ActiveDocument
			{
				get;
			}

			DockPane ActiveDocumentPane
			{
				get;
			}

			void SuspendFocusTracking();

			void ResumeFocusTracking();
		}

		private class FocusManagerImpl : Component, IContentFocusManager, IFocusManager
		{
			private class HookEventArgs : EventArgs
			{
				public int HookCode;

				public IntPtr wParam;

				public IntPtr lParam;
			}

			private class LocalWindowsHook : IDisposable
			{
				public delegate void HookEventHandler(object sender, HookEventArgs e);

				private IntPtr m_hHook = IntPtr.Zero;

				private NativeMethods.HookProc m_filterFunc = null;

				private HookType m_hookType;

				public event HookEventHandler HookInvoked;

				protected void OnHookInvoked(HookEventArgs e)
				{
					if (this.HookInvoked != null)
					{
						this.HookInvoked(this, e);
					}
				}

				public LocalWindowsHook(HookType hook)
				{
					m_hookType = hook;
					m_filterFunc = CoreHookProc;
				}

				public IntPtr CoreHookProc(int code, IntPtr wParam, IntPtr lParam)
				{
					if (code < 0)
					{
						return NativeMethods.CallNextHookEx(m_hHook, code, wParam, lParam);
					}
					HookEventArgs hookEventArgs = new HookEventArgs();
					hookEventArgs.HookCode = code;
					hookEventArgs.wParam = wParam;
					hookEventArgs.lParam = lParam;
					OnHookInvoked(hookEventArgs);
					return NativeMethods.CallNextHookEx(m_hHook, code, wParam, lParam);
				}

				public void Install()
				{
					if (m_hHook != IntPtr.Zero)
					{
						Uninstall();
					}
					int currentThreadId = NativeMethods.GetCurrentThreadId();
					m_hHook = NativeMethods.SetWindowsHookEx(m_hookType, m_filterFunc, IntPtr.Zero, currentThreadId);
				}

				public void Uninstall()
				{
					if (m_hHook != IntPtr.Zero)
					{
						NativeMethods.UnhookWindowsHookEx(m_hHook);
						m_hHook = IntPtr.Zero;
					}
				}

				~LocalWindowsHook()
				{
					Dispose(disposing: false);
				}

				public void Dispose()
				{
					Dispose(disposing: true);
					GC.SuppressFinalize(this);
				}

				protected virtual void Dispose(bool disposing)
				{
					Uninstall();
				}
			}

			private LocalWindowsHook m_localWindowsHook;

			private LocalWindowsHook.HookEventHandler m_hookEventHandler;

			private DockPanel m_dockPanel;

			private bool m_disposed = false;

			private IDockContent m_contentActivating = null;

			private List<IDockContent> m_listContent = new List<IDockContent>();

			private IDockContent m_lastActiveContent = null;

			private int m_countSuspendFocusTracking = 0;

			private bool m_inRefreshActiveWindow = false;

			private DockPane m_activePane = null;

			private IDockContent m_activeContent = null;

			private DockPane m_activeDocumentPane = null;

			private IDockContent m_activeDocument = null;

			public DockPanel DockPanel => m_dockPanel;

			private IDockContent ContentActivating
			{
				get
				{
					return m_contentActivating;
				}
				set
				{
					m_contentActivating = value;
				}
			}

			private List<IDockContent> ListContent => m_listContent;

			private IDockContent LastActiveContent
			{
				get
				{
					return m_lastActiveContent;
				}
				set
				{
					m_lastActiveContent = value;
				}
			}

			public bool IsFocusTrackingSuspended => m_countSuspendFocusTracking != 0;

			private bool InRefreshActiveWindow => m_inRefreshActiveWindow;

			public DockPane ActivePane => m_activePane;

			public IDockContent ActiveContent => m_activeContent;

			public DockPane ActiveDocumentPane => m_activeDocumentPane;

			public IDockContent ActiveDocument => m_activeDocument;

			public FocusManagerImpl(DockPanel dockPanel)
			{
				m_dockPanel = dockPanel;
				m_localWindowsHook = new LocalWindowsHook(HookType.WH_CALLWNDPROCRET);
				m_hookEventHandler = HookEventHandler;
				m_localWindowsHook.HookInvoked += m_hookEventHandler;
				m_localWindowsHook.Install();
			}

			protected override void Dispose(bool disposing)
			{
				lock (this)
				{
					if (!m_disposed && disposing)
					{
						m_localWindowsHook.Dispose();
						m_disposed = true;
					}
					base.Dispose(disposing);
				}
			}

			public void Activate(IDockContent content)
			{
				if (IsFocusTrackingSuspended)
				{
					ContentActivating = content;
				}
				else if (content != null)
				{
					DockContentHandler dockHandler = content.DockHandler;
					if (!dockHandler.Form.IsDisposed)
					{
						if (ContentContains(content, dockHandler.ActiveWindowHandle))
						{
							NativeMethods.SetFocus(dockHandler.ActiveWindowHandle);
						}
						if (!dockHandler.Form.ContainsFocus && !dockHandler.Form.SelectNextControl(dockHandler.Form.ActiveControl, forward: true, tabStopOnly: true, nested: true, wrap: true))
						{
							NativeMethods.SetFocus(dockHandler.Form.Handle);
						}
					}
				}
			}

			public void AddToList(IDockContent content)
			{
				if (!ListContent.Contains(content) && !IsInActiveList(content))
				{
					ListContent.Add(content);
				}
			}

			public void RemoveFromList(IDockContent content)
			{
				if (IsInActiveList(content))
				{
					RemoveFromActiveList(content);
				}
				if (ListContent.Contains(content))
				{
					ListContent.Remove(content);
				}
			}

			private bool IsInActiveList(IDockContent content)
			{
				return content.DockHandler.NextActive != null || LastActiveContent == content;
			}

			private void AddLastToActiveList(IDockContent content)
			{
				IDockContent lastActiveContent = LastActiveContent;
				if (lastActiveContent != content)
				{
					DockContentHandler dockHandler = content.DockHandler;
					if (IsInActiveList(content))
					{
						RemoveFromActiveList(content);
					}
					dockHandler.PreviousActive = lastActiveContent;
					dockHandler.NextActive = null;
					LastActiveContent = content;
					if (lastActiveContent != null)
					{
						lastActiveContent.DockHandler.NextActive = LastActiveContent;
					}
				}
			}

			private void RemoveFromActiveList(IDockContent content)
			{
				if (LastActiveContent == content)
				{
					LastActiveContent = content.DockHandler.PreviousActive;
				}
				IDockContent previousActive = content.DockHandler.PreviousActive;
				IDockContent nextActive = content.DockHandler.NextActive;
				if (previousActive != null)
				{
					previousActive.DockHandler.NextActive = nextActive;
				}
				if (nextActive != null)
				{
					nextActive.DockHandler.PreviousActive = previousActive;
				}
				content.DockHandler.PreviousActive = null;
				content.DockHandler.NextActive = null;
			}

			public void GiveUpFocus(IDockContent content)
			{
				DockContentHandler dockHandler = content.DockHandler;
				if (dockHandler.Form.ContainsFocus)
				{
					if (IsFocusTrackingSuspended)
					{
						DockPanel.DummyControl.Focus();
					}
					if (LastActiveContent == content)
					{
						IDockContent previousActive = dockHandler.PreviousActive;
						if (previousActive != null)
						{
							Activate(previousActive);
						}
						else if (ListContent.Count > 0)
						{
							Activate(ListContent[ListContent.Count - 1]);
						}
					}
					else if (LastActiveContent != null)
					{
						Activate(LastActiveContent);
					}
					else if (ListContent.Count > 0)
					{
						Activate(ListContent[ListContent.Count - 1]);
					}
				}
			}

			private static bool ContentContains(IDockContent content, IntPtr hWnd)
			{
				Control control = Control.FromChildHandle(hWnd);
				for (Control control2 = control; control2 != null; control2 = control2.Parent)
				{
					if (control2 == content.DockHandler.Form)
					{
						return true;
					}
				}
				return false;
			}

			public void SuspendFocusTracking()
			{
				m_countSuspendFocusTracking++;
				m_localWindowsHook.HookInvoked -= m_hookEventHandler;
			}

			public void ResumeFocusTracking()
			{
				if (m_countSuspendFocusTracking > 0)
				{
					m_countSuspendFocusTracking--;
				}
				if (m_countSuspendFocusTracking == 0)
				{
					if (ContentActivating != null)
					{
						Activate(ContentActivating);
						ContentActivating = null;
					}
					m_localWindowsHook.HookInvoked += m_hookEventHandler;
					if (!InRefreshActiveWindow)
					{
						RefreshActiveWindow();
					}
				}
			}

			private void HookEventHandler(object sender, HookEventArgs e)
			{
				switch (Marshal.ReadInt32(e.lParam, IntPtr.Size * 3))
				{
				case 8:
				{
					IntPtr hWnd = Marshal.ReadIntPtr(e.lParam, IntPtr.Size * 2);
					DockPane paneFromHandle = GetPaneFromHandle(hWnd);
					if (paneFromHandle == null)
					{
						RefreshActiveWindow();
					}
					break;
				}
				case 7:
					RefreshActiveWindow();
					break;
				}
			}

			private DockPane GetPaneFromHandle(IntPtr hWnd)
			{
				Control control = Control.FromChildHandle(hWnd);
				IDockContent dockContent = null;
				DockPane dockPane = null;
				while (control != null)
				{
					dockContent = (control as IDockContent);
					if (dockContent != null)
					{
						dockContent.DockHandler.ActiveWindowHandle = hWnd;
					}
					if (dockContent != null && dockContent.DockHandler.DockPanel == DockPanel)
					{
						return dockContent.DockHandler.Pane;
					}
					dockPane = (control as DockPane);
					if (dockPane != null && dockPane.DockPanel == DockPanel)
					{
						break;
					}
					control = control.Parent;
				}
				return dockPane;
			}

			private void RefreshActiveWindow()
			{
				SuspendFocusTracking();
				m_inRefreshActiveWindow = true;
				DockPane activePane = ActivePane;
				IDockContent activeContent = ActiveContent;
				IDockContent activeDocument = ActiveDocument;
				SetActivePane();
				SetActiveContent();
				SetActiveDocumentPane();
				SetActiveDocument();
				DockPanel.AutoHideWindow.RefreshActivePane();
				ResumeFocusTracking();
				m_inRefreshActiveWindow = false;
				if (activeContent != ActiveContent)
				{
					DockPanel.OnActiveContentChanged(EventArgs.Empty);
				}
				if (activeDocument != ActiveDocument)
				{
					DockPanel.OnActiveDocumentChanged(EventArgs.Empty);
				}
				if (activePane != ActivePane)
				{
					DockPanel.OnActivePaneChanged(EventArgs.Empty);
				}
			}

			private void SetActivePane()
			{
				DockPane paneFromHandle = GetPaneFromHandle(NativeMethods.GetFocus());
				if (m_activePane != paneFromHandle)
				{
					if (m_activePane != null)
					{
						m_activePane.SetIsActivated(value: false);
					}
					m_activePane = paneFromHandle;
					if (m_activePane != null)
					{
						m_activePane.SetIsActivated(value: true);
					}
				}
			}

			internal void SetActiveContent()
			{
				IDockContent dockContent = (ActivePane == null) ? null : ActivePane.ActiveContent;
				if (m_activeContent != dockContent)
				{
					if (m_activeContent != null)
					{
						m_activeContent.DockHandler.IsActivated = false;
					}
					m_activeContent = dockContent;
					if (m_activeContent != null)
					{
						m_activeContent.DockHandler.IsActivated = true;
						if (!DockHelper.IsDockStateAutoHide(m_activeContent.DockHandler.DockState))
						{
							AddLastToActiveList(m_activeContent);
						}
					}
				}
			}

			private void SetActiveDocumentPane()
			{
				DockPane dockPane = null;
				if (ActivePane != null && ActivePane.DockState == DockState.Document)
				{
					dockPane = ActivePane;
				}
				if (dockPane == null && DockPanel.DockWindows != null)
				{
					dockPane = ((ActiveDocumentPane == null) ? DockPanel.DockWindows[DockState.Document].DefaultPane : ((ActiveDocumentPane.DockPanel == DockPanel && ActiveDocumentPane.DockState == DockState.Document) ? ActiveDocumentPane : DockPanel.DockWindows[DockState.Document].DefaultPane));
				}
				if (m_activeDocumentPane != dockPane)
				{
					if (m_activeDocumentPane != null)
					{
						m_activeDocumentPane.SetIsActiveDocumentPane(value: false);
					}
					m_activeDocumentPane = dockPane;
					if (m_activeDocumentPane != null)
					{
						m_activeDocumentPane.SetIsActiveDocumentPane(value: true);
					}
				}
			}

			private void SetActiveDocument()
			{
				IDockContent dockContent = (ActiveDocumentPane == null) ? null : ActiveDocumentPane.ActiveContent;
				if (m_activeDocument != dockContent)
				{
					m_activeDocument = dockContent;
				}
			}
		}

		private class MdiClientController : NativeWindow, IComponent, IDisposable
		{
			private bool m_autoScroll = true;

			private BorderStyle m_borderStyle = BorderStyle.Fixed3D;

			private MdiClient m_mdiClient = null;

			private Form m_parentForm = null;

			private ISite m_site = null;

			public bool AutoScroll
			{
				get
				{
					return m_autoScroll;
				}
				set
				{
					m_autoScroll = value;
					if (MdiClient != null)
					{
						UpdateStyles();
					}
				}
			}

			public BorderStyle BorderStyle
			{
				set
				{
					if (!Enum.IsDefined(typeof(BorderStyle), value))
					{
						throw new InvalidEnumArgumentException();
					}
					m_borderStyle = value;
					if (MdiClient != null && (Site == null || !Site.DesignMode))
					{
						int num = NativeMethods.GetWindowLong(MdiClient.Handle, -16);
						int num2 = NativeMethods.GetWindowLong(MdiClient.Handle, -20);
						switch (m_borderStyle)
						{
						case BorderStyle.Fixed3D:
							num2 |= 0x200;
							num &= -8388609;
							break;
						case BorderStyle.FixedSingle:
							num2 &= -513;
							num |= 0x800000;
							break;
						case BorderStyle.None:
							num &= -8388609;
							num2 &= -513;
							break;
						}
						NativeMethods.SetWindowLong(MdiClient.Handle, -16, num);
						NativeMethods.SetWindowLong(MdiClient.Handle, -20, num2);
						UpdateStyles();
					}
				}
			}

			public MdiClient MdiClient => m_mdiClient;

			[Browsable(false)]
			public Form ParentForm
			{
				get
				{
					return m_parentForm;
				}
				set
				{
					if (m_parentForm != null)
					{
						m_parentForm.HandleCreated -= ParentFormHandleCreated;
						m_parentForm.MdiChildActivate -= ParentFormMdiChildActivate;
					}
					m_parentForm = value;
					if (m_parentForm != null)
					{
						if (m_parentForm.IsHandleCreated)
						{
							InitializeMdiClient();
							RefreshProperties();
						}
						else
						{
							m_parentForm.HandleCreated += ParentFormHandleCreated;
						}
						m_parentForm.MdiChildActivate += ParentFormMdiChildActivate;
					}
				}
			}

			public ISite Site
			{
				get
				{
					return m_site;
				}
				set
				{
					m_site = value;
					if (m_site != null)
					{
						IDesignerHost designerHost = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
						if (designerHost != null)
						{
							Form form = designerHost.RootComponent as Form;
							if (form != null)
							{
								ParentForm = form;
							}
						}
					}
				}
			}

			public event EventHandler Disposed;

			public event EventHandler HandleAssigned;

			public event EventHandler MdiChildActivate;

			public event LayoutEventHandler Layout;

			public event PaintEventHandler Paint;

			public void Dispose()
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (disposing)
				{
					lock (this)
					{
						if (Site != null && Site.Container != null)
						{
							Site.Container.Remove(this);
						}
						if (this.Disposed != null)
						{
							this.Disposed(this, EventArgs.Empty);
						}
					}
				}
			}

			public void RenewMdiClient()
			{
				InitializeMdiClient();
				RefreshProperties();
			}

			protected virtual void OnHandleAssigned(EventArgs e)
			{
				if (this.HandleAssigned != null)
				{
					this.HandleAssigned(this, e);
				}
			}

			protected virtual void OnMdiChildActivate(EventArgs e)
			{
				if (this.MdiChildActivate != null)
				{
					this.MdiChildActivate(this, e);
				}
			}

			protected virtual void OnLayout(LayoutEventArgs e)
			{
				if (this.Layout != null)
				{
					this.Layout(this, e);
				}
			}

			protected virtual void OnPaint(PaintEventArgs e)
			{
				if (this.Paint != null)
				{
					this.Paint(this, e);
				}
			}

			protected override void WndProc(ref Message m)
			{
				int msg = m.Msg;
				if (msg == 131 && !AutoScroll)
				{
					NativeMethods.ShowScrollBar(m.HWnd, 3, 0);
				}
				base.WndProc(ref m);
			}

			private void ParentFormHandleCreated(object sender, EventArgs e)
			{
				m_parentForm.HandleCreated -= ParentFormHandleCreated;
				InitializeMdiClient();
				RefreshProperties();
			}

			private void ParentFormMdiChildActivate(object sender, EventArgs e)
			{
				OnMdiChildActivate(e);
			}

			private void MdiClientLayout(object sender, LayoutEventArgs e)
			{
				OnLayout(e);
			}

			private void MdiClientHandleDestroyed(object sender, EventArgs e)
			{
				if (m_mdiClient != null)
				{
					m_mdiClient.HandleDestroyed -= MdiClientHandleDestroyed;
					m_mdiClient = null;
				}
				ReleaseHandle();
			}

			private void InitializeMdiClient()
			{
				if (MdiClient != null)
				{
					MdiClient.HandleDestroyed -= MdiClientHandleDestroyed;
					MdiClient.Layout -= MdiClientLayout;
				}
				if (ParentForm != null)
				{
					foreach (Control control in ParentForm.Controls)
					{
						m_mdiClient = (control as MdiClient);
						if (m_mdiClient != null)
						{
							ReleaseHandle();
							AssignHandle(MdiClient.Handle);
							OnHandleAssigned(EventArgs.Empty);
							MdiClient.HandleDestroyed += MdiClientHandleDestroyed;
							MdiClient.Layout += MdiClientLayout;
							break;
						}
					}
				}
			}

			private void RefreshProperties()
			{
				BorderStyle = m_borderStyle;
				AutoScroll = m_autoScroll;
			}

			private void UpdateStyles()
			{
				NativeMethods.SetWindowPos(MdiClient.Handle, IntPtr.Zero, 0, 0, 0, 0, FlagsSetWindowPos.SWP_NOSIZE | FlagsSetWindowPos.SWP_NOMOVE | FlagsSetWindowPos.SWP_NOZORDER | FlagsSetWindowPos.SWP_NOACTIVATE | FlagsSetWindowPos.SWP_FRAMECHANGED | FlagsSetWindowPos.SWP_NOOWNERZORDER);
			}
		}

		private static class Persistor
		{
			private class DummyContent : DockContent
			{
			}

			private struct DockPanelStruct
			{
				private double m_dockLeftPortion;

				private double m_dockRightPortion;

				private double m_dockTopPortion;

				private double m_dockBottomPortion;

				private int m_indexActiveDocumentPane;

				private int m_indexActivePane;

				public double DockLeftPortion
				{
					get
					{
						return m_dockLeftPortion;
					}
					set
					{
						m_dockLeftPortion = value;
					}
				}

				public double DockRightPortion
				{
					get
					{
						return m_dockRightPortion;
					}
					set
					{
						m_dockRightPortion = value;
					}
				}

				public double DockTopPortion
				{
					get
					{
						return m_dockTopPortion;
					}
					set
					{
						m_dockTopPortion = value;
					}
				}

				public double DockBottomPortion
				{
					get
					{
						return m_dockBottomPortion;
					}
					set
					{
						m_dockBottomPortion = value;
					}
				}

				public int IndexActiveDocumentPane
				{
					get
					{
						return m_indexActiveDocumentPane;
					}
					set
					{
						m_indexActiveDocumentPane = value;
					}
				}

				public int IndexActivePane
				{
					get
					{
						return m_indexActivePane;
					}
					set
					{
						m_indexActivePane = value;
					}
				}
			}

			private struct ContentStruct
			{
				private string m_persistString;

				private double m_autoHidePortion;

				private bool m_isHidden;

				private bool m_isFloat;

				public string PersistString
				{
					get
					{
						return m_persistString;
					}
					set
					{
						m_persistString = value;
					}
				}

				public double AutoHidePortion
				{
					get
					{
						return m_autoHidePortion;
					}
					set
					{
						m_autoHidePortion = value;
					}
				}

				public bool IsHidden
				{
					get
					{
						return m_isHidden;
					}
					set
					{
						m_isHidden = value;
					}
				}

				public bool IsFloat
				{
					get
					{
						return m_isFloat;
					}
					set
					{
						m_isFloat = value;
					}
				}
			}

			private struct PaneStruct
			{
				private DockState m_dockState;

				private int m_indexActiveContent;

				private int[] m_indexContents;

				private int m_zOrderIndex;

				public DockState DockState
				{
					get
					{
						return m_dockState;
					}
					set
					{
						m_dockState = value;
					}
				}

				public int IndexActiveContent
				{
					get
					{
						return m_indexActiveContent;
					}
					set
					{
						m_indexActiveContent = value;
					}
				}

				public int[] IndexContents
				{
					get
					{
						return m_indexContents;
					}
					set
					{
						m_indexContents = value;
					}
				}

				public int ZOrderIndex
				{
					get
					{
						return m_zOrderIndex;
					}
					set
					{
						m_zOrderIndex = value;
					}
				}
			}

			private struct NestedPane
			{
				private int m_indexPane;

				private int m_indexPrevPane;

				private DockAlignment m_alignment;

				private double m_proportion;

				public int IndexPane
				{
					get
					{
						return m_indexPane;
					}
					set
					{
						m_indexPane = value;
					}
				}

				public int IndexPrevPane
				{
					get
					{
						return m_indexPrevPane;
					}
					set
					{
						m_indexPrevPane = value;
					}
				}

				public DockAlignment Alignment
				{
					get
					{
						return m_alignment;
					}
					set
					{
						m_alignment = value;
					}
				}

				public double Proportion
				{
					get
					{
						return m_proportion;
					}
					set
					{
						m_proportion = value;
					}
				}
			}

			private struct DockWindowStruct
			{
				private DockState m_dockState;

				private int m_zOrderIndex;

				private NestedPane[] m_nestedPanes;

				public DockState DockState
				{
					get
					{
						return m_dockState;
					}
					set
					{
						m_dockState = value;
					}
				}

				public int ZOrderIndex
				{
					get
					{
						return m_zOrderIndex;
					}
					set
					{
						m_zOrderIndex = value;
					}
				}

				public NestedPane[] NestedPanes
				{
					get
					{
						return m_nestedPanes;
					}
					set
					{
						m_nestedPanes = value;
					}
				}
			}

			private struct FloatWindowStruct
			{
				private Rectangle m_bounds;

				private int m_zOrderIndex;

				private NestedPane[] m_nestedPanes;

				public Rectangle Bounds
				{
					get
					{
						return m_bounds;
					}
					set
					{
						m_bounds = value;
					}
				}

				public int ZOrderIndex
				{
					get
					{
						return m_zOrderIndex;
					}
					set
					{
						m_zOrderIndex = value;
					}
				}

				public NestedPane[] NestedPanes
				{
					get
					{
						return m_nestedPanes;
					}
					set
					{
						m_nestedPanes = value;
					}
				}
			}

			private const string ConfigFileVersion = "1.0";

			private static string[] CompatibleConfigFileVersions = new string[0];

			public static void SaveAsXml(DockPanel dockPanel, string fileName)
			{
				SaveAsXml(dockPanel, fileName, Encoding.Unicode);
			}

			public static void SaveAsXml(DockPanel dockPanel, string fileName, Encoding encoding)
			{
				FileStream fileStream = new FileStream(fileName, FileMode.Create);
				try
				{
					SaveAsXml(dockPanel, fileStream, encoding);
				}
				finally
				{
					fileStream.Close();
				}
			}

			public static void SaveAsXml(DockPanel dockPanel, Stream stream, Encoding encoding)
			{
				SaveAsXml(dockPanel, stream, encoding, upstream: false);
			}

			public static void SaveAsXml(DockPanel dockPanel, Stream stream, Encoding encoding, bool upstream)
			{
				XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, encoding);
				xmlTextWriter.Formatting = Formatting.Indented;
				if (!upstream)
				{
					xmlTextWriter.WriteStartDocument();
				}
				xmlTextWriter.WriteComment(Strings.DockPanel_Persistor_XmlFileComment1);
				xmlTextWriter.WriteComment(Strings.DockPanel_Persistor_XmlFileComment2);
				xmlTextWriter.WriteStartElement("DockPanel");
				xmlTextWriter.WriteAttributeString("FormatVersion", "1.0");
				xmlTextWriter.WriteAttributeString("DockLeftPortion", dockPanel.DockLeftPortion.ToString(CultureInfo.InvariantCulture));
				xmlTextWriter.WriteAttributeString("DockRightPortion", dockPanel.DockRightPortion.ToString(CultureInfo.InvariantCulture));
				xmlTextWriter.WriteAttributeString("DockTopPortion", dockPanel.DockTopPortion.ToString(CultureInfo.InvariantCulture));
				xmlTextWriter.WriteAttributeString("DockBottomPortion", dockPanel.DockBottomPortion.ToString(CultureInfo.InvariantCulture));
				xmlTextWriter.WriteAttributeString("ActiveDocumentPane", dockPanel.Panes.IndexOf(dockPanel.ActiveDocumentPane).ToString(CultureInfo.InvariantCulture));
				xmlTextWriter.WriteAttributeString("ActivePane", dockPanel.Panes.IndexOf(dockPanel.ActivePane).ToString(CultureInfo.InvariantCulture));
				xmlTextWriter.WriteStartElement("Contents");
				xmlTextWriter.WriteAttributeString("Count", dockPanel.Contents.Count.ToString(CultureInfo.InvariantCulture));
				foreach (IDockContent content in dockPanel.Contents)
				{
					xmlTextWriter.WriteStartElement("Content");
					xmlTextWriter.WriteAttributeString("ID", dockPanel.Contents.IndexOf(content).ToString(CultureInfo.InvariantCulture));
					xmlTextWriter.WriteAttributeString("PersistString", content.DockHandler.PersistString);
					xmlTextWriter.WriteAttributeString("AutoHidePortion", content.DockHandler.AutoHidePortion.ToString(CultureInfo.InvariantCulture));
					xmlTextWriter.WriteAttributeString("IsHidden", content.DockHandler.IsHidden.ToString(CultureInfo.InvariantCulture));
					xmlTextWriter.WriteAttributeString("IsFloat", content.DockHandler.IsFloat.ToString(CultureInfo.InvariantCulture));
					xmlTextWriter.WriteEndElement();
				}
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteStartElement("Panes");
				xmlTextWriter.WriteAttributeString("Count", dockPanel.Panes.Count.ToString(CultureInfo.InvariantCulture));
				foreach (DockPane pane in dockPanel.Panes)
				{
					xmlTextWriter.WriteStartElement("Pane");
					xmlTextWriter.WriteAttributeString("ID", dockPanel.Panes.IndexOf(pane).ToString(CultureInfo.InvariantCulture));
					xmlTextWriter.WriteAttributeString("DockState", pane.DockState.ToString());
					xmlTextWriter.WriteAttributeString("ActiveContent", dockPanel.Contents.IndexOf(pane.ActiveContent).ToString(CultureInfo.InvariantCulture));
					xmlTextWriter.WriteStartElement("Contents");
					xmlTextWriter.WriteAttributeString("Count", pane.Contents.Count.ToString(CultureInfo.InvariantCulture));
					foreach (IDockContent content2 in pane.Contents)
					{
						xmlTextWriter.WriteStartElement("Content");
						xmlTextWriter.WriteAttributeString("ID", pane.Contents.IndexOf(content2).ToString(CultureInfo.InvariantCulture));
						xmlTextWriter.WriteAttributeString("RefID", dockPanel.Contents.IndexOf(content2).ToString(CultureInfo.InvariantCulture));
						xmlTextWriter.WriteEndElement();
					}
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteEndElement();
				}
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteStartElement("DockWindows");
				int num = 0;
				foreach (DockWindow dockWindow in dockPanel.DockWindows)
				{
					xmlTextWriter.WriteStartElement("DockWindow");
					xmlTextWriter.WriteAttributeString("ID", num.ToString(CultureInfo.InvariantCulture));
					num++;
					xmlTextWriter.WriteAttributeString("DockState", dockWindow.DockState.ToString());
					xmlTextWriter.WriteAttributeString("ZOrderIndex", dockPanel.Controls.IndexOf(dockWindow).ToString(CultureInfo.InvariantCulture));
					xmlTextWriter.WriteStartElement("NestedPanes");
					xmlTextWriter.WriteAttributeString("Count", dockWindow.NestedPanes.Count.ToString(CultureInfo.InvariantCulture));
					foreach (DockPane nestedPane in dockWindow.NestedPanes)
					{
						xmlTextWriter.WriteStartElement("Pane");
						xmlTextWriter.WriteAttributeString("ID", dockWindow.NestedPanes.IndexOf(nestedPane).ToString(CultureInfo.InvariantCulture));
						xmlTextWriter.WriteAttributeString("RefID", dockPanel.Panes.IndexOf(nestedPane).ToString(CultureInfo.InvariantCulture));
						NestedDockingStatus nestedDockingStatus = nestedPane.NestedDockingStatus;
						xmlTextWriter.WriteAttributeString("PrevPane", dockPanel.Panes.IndexOf(nestedDockingStatus.PreviousPane).ToString(CultureInfo.InvariantCulture));
						xmlTextWriter.WriteAttributeString("Alignment", nestedDockingStatus.Alignment.ToString());
						xmlTextWriter.WriteAttributeString("Proportion", nestedDockingStatus.Proportion.ToString(CultureInfo.InvariantCulture));
						xmlTextWriter.WriteEndElement();
					}
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteEndElement();
				}
				xmlTextWriter.WriteEndElement();
				RectangleConverter rectangleConverter = new RectangleConverter();
				xmlTextWriter.WriteStartElement("FloatWindows");
				xmlTextWriter.WriteAttributeString("Count", dockPanel.FloatWindows.Count.ToString(CultureInfo.InvariantCulture));
				foreach (FloatWindow floatWindow in dockPanel.FloatWindows)
				{
					xmlTextWriter.WriteStartElement("FloatWindow");
					xmlTextWriter.WriteAttributeString("ID", dockPanel.FloatWindows.IndexOf(floatWindow).ToString(CultureInfo.InvariantCulture));
					xmlTextWriter.WriteAttributeString("Bounds", rectangleConverter.ConvertToInvariantString(floatWindow.Bounds));
					xmlTextWriter.WriteAttributeString("ZOrderIndex", floatWindow.DockPanel.FloatWindows.IndexOf(floatWindow).ToString(CultureInfo.InvariantCulture));
					xmlTextWriter.WriteStartElement("NestedPanes");
					xmlTextWriter.WriteAttributeString("Count", floatWindow.NestedPanes.Count.ToString(CultureInfo.InvariantCulture));
					foreach (DockPane nestedPane2 in floatWindow.NestedPanes)
					{
						xmlTextWriter.WriteStartElement("Pane");
						xmlTextWriter.WriteAttributeString("ID", floatWindow.NestedPanes.IndexOf(nestedPane2).ToString(CultureInfo.InvariantCulture));
						xmlTextWriter.WriteAttributeString("RefID", dockPanel.Panes.IndexOf(nestedPane2).ToString(CultureInfo.InvariantCulture));
						NestedDockingStatus nestedDockingStatus = nestedPane2.NestedDockingStatus;
						xmlTextWriter.WriteAttributeString("PrevPane", dockPanel.Panes.IndexOf(nestedDockingStatus.PreviousPane).ToString(CultureInfo.InvariantCulture));
						xmlTextWriter.WriteAttributeString("Alignment", nestedDockingStatus.Alignment.ToString());
						xmlTextWriter.WriteAttributeString("Proportion", nestedDockingStatus.Proportion.ToString(CultureInfo.InvariantCulture));
						xmlTextWriter.WriteEndElement();
					}
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteEndElement();
				}
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteEndElement();
				if (!upstream)
				{
					xmlTextWriter.WriteEndDocument();
					xmlTextWriter.Close();
				}
				else
				{
					xmlTextWriter.Flush();
				}
			}

			public static void LoadFromXml(DockPanel dockPanel, string fileName, DeserializeDockContent deserializeContent)
			{
				FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
				try
				{
					LoadFromXml(dockPanel, fileStream, deserializeContent);
				}
				finally
				{
					fileStream.Close();
				}
			}

			public static void LoadFromXml(DockPanel dockPanel, Stream stream, DeserializeDockContent deserializeContent)
			{
				LoadFromXml(dockPanel, stream, deserializeContent, closeStream: true);
			}

			private static ContentStruct[] LoadContents(XmlTextReader xmlIn)
			{
				int num = Convert.ToInt32(xmlIn.GetAttribute("Count"), CultureInfo.InvariantCulture);
				ContentStruct[] array = new ContentStruct[num];
				MoveToNextElement(xmlIn);
				for (int i = 0; i < num; i++)
				{
					int num2 = Convert.ToInt32(xmlIn.GetAttribute("ID"), CultureInfo.InvariantCulture);
					if (xmlIn.Name != "Content" || num2 != i)
					{
						throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
					}
					array[i].PersistString = xmlIn.GetAttribute("PersistString");
					array[i].AutoHidePortion = Convert.ToDouble(xmlIn.GetAttribute("AutoHidePortion"), CultureInfo.InvariantCulture);
					array[i].IsHidden = Convert.ToBoolean(xmlIn.GetAttribute("IsHidden"), CultureInfo.InvariantCulture);
					array[i].IsFloat = Convert.ToBoolean(xmlIn.GetAttribute("IsFloat"), CultureInfo.InvariantCulture);
					MoveToNextElement(xmlIn);
				}
				return array;
			}

			private static PaneStruct[] LoadPanes(XmlTextReader xmlIn)
			{
				EnumConverter enumConverter = new EnumConverter(typeof(DockState));
				int num = Convert.ToInt32(xmlIn.GetAttribute("Count"), CultureInfo.InvariantCulture);
				PaneStruct[] array = new PaneStruct[num];
				MoveToNextElement(xmlIn);
				for (int i = 0; i < num; i++)
				{
					int num2 = Convert.ToInt32(xmlIn.GetAttribute("ID"), CultureInfo.InvariantCulture);
					if (xmlIn.Name != "Pane" || num2 != i)
					{
						throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
					}
					array[i].DockState = (DockState)enumConverter.ConvertFrom(xmlIn.GetAttribute("DockState"));
					array[i].IndexActiveContent = Convert.ToInt32(xmlIn.GetAttribute("ActiveContent"), CultureInfo.InvariantCulture);
					array[i].ZOrderIndex = -1;
					MoveToNextElement(xmlIn);
					if (xmlIn.Name != "Contents")
					{
						throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
					}
					int num3 = Convert.ToInt32(xmlIn.GetAttribute("Count"), CultureInfo.InvariantCulture);
					array[i].IndexContents = new int[num3];
					MoveToNextElement(xmlIn);
					for (int j = 0; j < num3; j++)
					{
						int num4 = Convert.ToInt32(xmlIn.GetAttribute("ID"), CultureInfo.InvariantCulture);
						if (xmlIn.Name != "Content" || num4 != j)
						{
							throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
						}
						array[i].IndexContents[j] = Convert.ToInt32(xmlIn.GetAttribute("RefID"), CultureInfo.InvariantCulture);
						MoveToNextElement(xmlIn);
					}
				}
				return array;
			}

			private static DockWindowStruct[] LoadDockWindows(XmlTextReader xmlIn, DockPanel dockPanel)
			{
				EnumConverter enumConverter = new EnumConverter(typeof(DockState));
				EnumConverter enumConverter2 = new EnumConverter(typeof(DockAlignment));
				int count = dockPanel.DockWindows.Count;
				DockWindowStruct[] array = new DockWindowStruct[count];
				MoveToNextElement(xmlIn);
				for (int i = 0; i < count; i++)
				{
					int num = Convert.ToInt32(xmlIn.GetAttribute("ID"), CultureInfo.InvariantCulture);
					if (xmlIn.Name != "DockWindow" || num != i)
					{
						throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
					}
					array[i].DockState = (DockState)enumConverter.ConvertFrom(xmlIn.GetAttribute("DockState"));
					array[i].ZOrderIndex = Convert.ToInt32(xmlIn.GetAttribute("ZOrderIndex"), CultureInfo.InvariantCulture);
					MoveToNextElement(xmlIn);
					if (xmlIn.Name != "DockList" && xmlIn.Name != "NestedPanes")
					{
						throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
					}
					int num2 = Convert.ToInt32(xmlIn.GetAttribute("Count"), CultureInfo.InvariantCulture);
					array[i].NestedPanes = new NestedPane[num2];
					MoveToNextElement(xmlIn);
					for (int j = 0; j < num2; j++)
					{
						int num3 = Convert.ToInt32(xmlIn.GetAttribute("ID"), CultureInfo.InvariantCulture);
						if (xmlIn.Name != "Pane" || num3 != j)
						{
							throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
						}
						array[i].NestedPanes[j].IndexPane = Convert.ToInt32(xmlIn.GetAttribute("RefID"), CultureInfo.InvariantCulture);
						array[i].NestedPanes[j].IndexPrevPane = Convert.ToInt32(xmlIn.GetAttribute("PrevPane"), CultureInfo.InvariantCulture);
						array[i].NestedPanes[j].Alignment = (DockAlignment)enumConverter2.ConvertFrom(xmlIn.GetAttribute("Alignment"));
						array[i].NestedPanes[j].Proportion = Convert.ToDouble(xmlIn.GetAttribute("Proportion"), CultureInfo.InvariantCulture);
						MoveToNextElement(xmlIn);
					}
				}
				return array;
			}

			private static FloatWindowStruct[] LoadFloatWindows(XmlTextReader xmlIn)
			{
				EnumConverter enumConverter = new EnumConverter(typeof(DockAlignment));
				RectangleConverter rectangleConverter = new RectangleConverter();
				int num = Convert.ToInt32(xmlIn.GetAttribute("Count"), CultureInfo.InvariantCulture);
				FloatWindowStruct[] array = new FloatWindowStruct[num];
				MoveToNextElement(xmlIn);
				for (int i = 0; i < num; i++)
				{
					int num2 = Convert.ToInt32(xmlIn.GetAttribute("ID"), CultureInfo.InvariantCulture);
					if (xmlIn.Name != "FloatWindow" || num2 != i)
					{
						throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
					}
					array[i].Bounds = (Rectangle)rectangleConverter.ConvertFromInvariantString(xmlIn.GetAttribute("Bounds"));
					array[i].ZOrderIndex = Convert.ToInt32(xmlIn.GetAttribute("ZOrderIndex"), CultureInfo.InvariantCulture);
					MoveToNextElement(xmlIn);
					if (xmlIn.Name != "DockList" && xmlIn.Name != "NestedPanes")
					{
						throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
					}
					int num3 = Convert.ToInt32(xmlIn.GetAttribute("Count"), CultureInfo.InvariantCulture);
					array[i].NestedPanes = new NestedPane[num3];
					MoveToNextElement(xmlIn);
					for (int j = 0; j < num3; j++)
					{
						int num4 = Convert.ToInt32(xmlIn.GetAttribute("ID"), CultureInfo.InvariantCulture);
						if (xmlIn.Name != "Pane" || num4 != j)
						{
							throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
						}
						array[i].NestedPanes[j].IndexPane = Convert.ToInt32(xmlIn.GetAttribute("RefID"), CultureInfo.InvariantCulture);
						array[i].NestedPanes[j].IndexPrevPane = Convert.ToInt32(xmlIn.GetAttribute("PrevPane"), CultureInfo.InvariantCulture);
						array[i].NestedPanes[j].Alignment = (DockAlignment)enumConverter.ConvertFrom(xmlIn.GetAttribute("Alignment"));
						array[i].NestedPanes[j].Proportion = Convert.ToDouble(xmlIn.GetAttribute("Proportion"), CultureInfo.InvariantCulture);
						MoveToNextElement(xmlIn);
					}
				}
				return array;
			}

			public static void LoadFromXml(DockPanel dockPanel, Stream stream, DeserializeDockContent deserializeContent, bool closeStream)
			{
				if (dockPanel.Contents.Count != 0)
				{
					throw new InvalidOperationException(Strings.DockPanel_LoadFromXml_AlreadyInitialized);
				}
				XmlTextReader xmlTextReader = new XmlTextReader(stream);
				xmlTextReader.WhitespaceHandling = WhitespaceHandling.None;
				xmlTextReader.MoveToContent();
				while (!xmlTextReader.Name.Equals("DockPanel"))
				{
					if (!MoveToNextElement(xmlTextReader))
					{
						throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
					}
				}
				string attribute = xmlTextReader.GetAttribute("FormatVersion");
				if (!IsFormatVersionValid(attribute))
				{
					throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidFormatVersion);
				}
				DockPanelStruct dockPanelStruct = default(DockPanelStruct);
				dockPanelStruct.DockLeftPortion = Convert.ToDouble(xmlTextReader.GetAttribute("DockLeftPortion"), CultureInfo.InvariantCulture);
				dockPanelStruct.DockRightPortion = Convert.ToDouble(xmlTextReader.GetAttribute("DockRightPortion"), CultureInfo.InvariantCulture);
				dockPanelStruct.DockTopPortion = Convert.ToDouble(xmlTextReader.GetAttribute("DockTopPortion"), CultureInfo.InvariantCulture);
				dockPanelStruct.DockBottomPortion = Convert.ToDouble(xmlTextReader.GetAttribute("DockBottomPortion"), CultureInfo.InvariantCulture);
				dockPanelStruct.IndexActiveDocumentPane = Convert.ToInt32(xmlTextReader.GetAttribute("ActiveDocumentPane"), CultureInfo.InvariantCulture);
				dockPanelStruct.IndexActivePane = Convert.ToInt32(xmlTextReader.GetAttribute("ActivePane"), CultureInfo.InvariantCulture);
				MoveToNextElement(xmlTextReader);
				if (xmlTextReader.Name != "Contents")
				{
					throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
				}
				ContentStruct[] array = LoadContents(xmlTextReader);
				if (xmlTextReader.Name != "Panes")
				{
					throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
				}
				PaneStruct[] array2 = LoadPanes(xmlTextReader);
				if (xmlTextReader.Name != "DockWindows")
				{
					throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
				}
				DockWindowStruct[] array3 = LoadDockWindows(xmlTextReader, dockPanel);
				if (xmlTextReader.Name != "FloatWindows")
				{
					throw new ArgumentException(Strings.DockPanel_LoadFromXml_InvalidXmlFormat);
				}
				FloatWindowStruct[] array4 = LoadFloatWindows(xmlTextReader);
				if (closeStream)
				{
					xmlTextReader.Close();
				}
				dockPanel.SuspendLayout(allWindows: true);
				dockPanel.DockLeftPortion = dockPanelStruct.DockLeftPortion;
				dockPanel.DockRightPortion = dockPanelStruct.DockRightPortion;
				dockPanel.DockTopPortion = dockPanelStruct.DockTopPortion;
				dockPanel.DockBottomPortion = dockPanelStruct.DockBottomPortion;
				int num = 2147483647;
				for (int i = 0; i < array3.Length; i++)
				{
					int num2 = -1;
					int num3 = -1;
					for (int j = 0; j < array3.Length; j++)
					{
						if (array3[j].ZOrderIndex > num2 && array3[j].ZOrderIndex < num)
						{
							num2 = array3[j].ZOrderIndex;
							num3 = j;
						}
					}
					dockPanel.DockWindows[array3[num3].DockState].BringToFront();
					num = num2;
				}
				for (int i = 0; i < array.Length; i++)
				{
					IDockContent dockContent = deserializeContent(array[i].PersistString);
					if (dockContent == null)
					{
						dockContent = new DummyContent();
					}
					dockContent.DockHandler.DockPanel = dockPanel;
					dockContent.DockHandler.AutoHidePortion = array[i].AutoHidePortion;
					dockContent.DockHandler.IsHidden = true;
					dockContent.DockHandler.IsFloat = array[i].IsFloat;
				}
				for (int i = 0; i < array2.Length; i++)
				{
					DockPane dockPane = null;
					for (int j = 0; j < array2[i].IndexContents.Length; j++)
					{
						IDockContent dockContent = dockPanel.Contents[array2[i].IndexContents[j]];
						if (j == 0)
						{
							dockPane = dockPanel.DockPaneFactory.CreateDockPane(dockContent, array2[i].DockState, show: false);
						}
						else if (array2[i].DockState == DockState.Float)
						{
							dockContent.DockHandler.FloatPane = dockPane;
						}
						else
						{
							dockContent.DockHandler.PanelPane = dockPane;
						}
					}
				}
				for (int i = 0; i < array3.Length; i++)
				{
					for (int j = 0; j < array3[i].NestedPanes.Length; j++)
					{
						DockWindow dockWindow = dockPanel.DockWindows[array3[i].DockState];
						int indexPane = array3[i].NestedPanes[j].IndexPane;
						DockPane dockPane = dockPanel.Panes[indexPane];
						int indexPrevPane = array3[i].NestedPanes[j].IndexPrevPane;
						DockPane previousPane = (indexPrevPane == -1) ? dockWindow.NestedPanes.GetDefaultPreviousPane(dockPane) : dockPanel.Panes[indexPrevPane];
						DockAlignment alignment = array3[i].NestedPanes[j].Alignment;
						double proportion = array3[i].NestedPanes[j].Proportion;
						dockPane.DockTo(dockWindow, previousPane, alignment, proportion);
						if (array2[indexPane].DockState == dockWindow.DockState)
						{
							array2[indexPane].ZOrderIndex = array3[i].ZOrderIndex;
						}
					}
				}
				for (int i = 0; i < array4.Length; i++)
				{
					FloatWindow floatWindow = null;
					for (int j = 0; j < array4[i].NestedPanes.Length; j++)
					{
						int indexPane = array4[i].NestedPanes[j].IndexPane;
						DockPane dockPane = dockPanel.Panes[indexPane];
						if (j == 0)
						{
							floatWindow = dockPanel.FloatWindowFactory.CreateFloatWindow(dockPanel, dockPane, array4[i].Bounds);
						}
						else
						{
							int indexPrevPane = array4[i].NestedPanes[j].IndexPrevPane;
							DockPane previousPane = (indexPrevPane == -1) ? null : dockPanel.Panes[indexPrevPane];
							DockAlignment alignment = array4[i].NestedPanes[j].Alignment;
							double proportion = array4[i].NestedPanes[j].Proportion;
							dockPane.DockTo(floatWindow, previousPane, alignment, proportion);
						}
						if (array2[indexPane].DockState == floatWindow.DockState)
						{
							array2[indexPane].ZOrderIndex = array4[i].ZOrderIndex;
						}
					}
				}
				int[] array5 = null;
				if (array.Length > 0)
				{
					array5 = new int[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						array5[i] = i;
					}
					int num4 = array.Length;
					for (int i = 0; i < array.Length - 1; i++)
					{
						for (int j = i + 1; j < array.Length; j++)
						{
							DockPane pane = dockPanel.Contents[array5[i]].DockHandler.Pane;
							int num5 = (pane != null) ? array2[dockPanel.Panes.IndexOf(pane)].ZOrderIndex : 0;
							DockPane pane2 = dockPanel.Contents[array5[j]].DockHandler.Pane;
							int num6 = (pane2 != null) ? array2[dockPanel.Panes.IndexOf(pane2)].ZOrderIndex : 0;
							if (num5 > num6)
							{
								int num7 = array5[i];
								array5[i] = array5[j];
								array5[j] = num7;
							}
						}
					}
				}
				for (int i = 0; i < array.Length; i++)
				{
					IDockContent dockContent = dockPanel.Contents[array5[i]];
					if (dockContent.DockHandler.Pane != null && dockContent.DockHandler.Pane.DockState != DockState.Document)
					{
						dockContent.DockHandler.IsHidden = array[array5[i]].IsHidden;
					}
				}
				for (int i = 0; i < array.Length; i++)
				{
					IDockContent dockContent = dockPanel.Contents[array5[i]];
					if (dockContent.DockHandler.Pane != null && dockContent.DockHandler.Pane.DockState == DockState.Document)
					{
						dockContent.DockHandler.IsHidden = array[array5[i]].IsHidden;
					}
				}
				for (int i = 0; i < array2.Length; i++)
				{
					dockPanel.Panes[i].ActiveContent = ((array2[i].IndexActiveContent == -1) ? null : dockPanel.Contents[array2[i].IndexActiveContent]);
				}
				if (dockPanelStruct.IndexActiveDocumentPane != -1)
				{
					dockPanel.Panes[dockPanelStruct.IndexActiveDocumentPane].Activate();
				}
				if (dockPanelStruct.IndexActivePane != -1)
				{
					dockPanel.Panes[dockPanelStruct.IndexActivePane].Activate();
				}
				for (int i = dockPanel.Contents.Count - 1; i >= 0; i--)
				{
					if (dockPanel.Contents[i] is DummyContent)
					{
						dockPanel.Contents[i].DockHandler.Form.Close();
					}
				}
				dockPanel.ResumeLayout(performLayout: true, allWindows: true);
			}

			private static bool MoveToNextElement(XmlTextReader xmlIn)
			{
				if (!xmlIn.Read())
				{
					return false;
				}
				while (xmlIn.NodeType == XmlNodeType.EndElement)
				{
					if (!xmlIn.Read())
					{
						return false;
					}
				}
				return true;
			}

			private static bool IsFormatVersionValid(string formatVersion)
			{
				if (formatVersion == "1.0")
				{
					return true;
				}
				string[] compatibleConfigFileVersions = CompatibleConfigFileVersions;
				foreach (string a in compatibleConfigFileVersions)
				{
					if (a == formatVersion)
					{
						return true;
					}
				}
				return false;
			}
		}

		private sealed class SplitterDragHandler : DragHandler
		{
			private class SplitterOutline
			{
				private DragForm m_dragForm;

				private DragForm DragForm => m_dragForm;

				public SplitterOutline()
				{
					m_dragForm = new DragForm();
					SetDragForm(Rectangle.Empty);
					DragForm.BackColor = Color.Black;
					DragForm.Opacity = 0.7;
					DragForm.Show(bActivate: false);
				}

				public void Show(Rectangle rect)
				{
					SetDragForm(rect);
				}

				public void Close()
				{
					DragForm.Close();
				}

				private void SetDragForm(Rectangle rect)
				{
					DragForm.Bounds = rect;
					if (rect == Rectangle.Empty)
					{
						DragForm.Region = new Region(Rectangle.Empty);
					}
					else if (DragForm.Region != null)
					{
						DragForm.Region = null;
					}
				}
			}

			private SplitterOutline m_outline;

			private Rectangle m_rectSplitter;

			public new ISplitterDragSource DragSource
			{
				get
				{
					return base.DragSource as ISplitterDragSource;
				}
				private set
				{
					base.DragSource = value;
				}
			}

			private SplitterOutline Outline
			{
				get
				{
					return m_outline;
				}
				set
				{
					m_outline = value;
				}
			}

			private Rectangle RectSplitter
			{
				get
				{
					return m_rectSplitter;
				}
				set
				{
					m_rectSplitter = value;
				}
			}

			public SplitterDragHandler(DockPanel dockPanel)
				: base(dockPanel)
			{
			}

			public void BeginDrag(ISplitterDragSource dragSource, Rectangle rectSplitter)
			{
				DragSource = dragSource;
				RectSplitter = rectSplitter;
				if (!BeginDrag())
				{
					DragSource = null;
				}
				else
				{
					Outline = new SplitterOutline();
					Outline.Show(rectSplitter);
					DragSource.BeginDrag(rectSplitter);
				}
			}

			protected override void OnDragging()
			{
				Outline.Show(GetSplitterOutlineBounds(Control.MousePosition));
			}

			protected override void OnEndDrag(bool abort)
			{
				base.DockPanel.SuspendLayout(allWindows: true);
				Outline.Close();
				if (!abort)
				{
					DragSource.MoveSplitter(GetMovingOffset(Control.MousePosition));
				}
				DragSource.EndDrag();
				base.DockPanel.ResumeLayout(performLayout: true, allWindows: true);
			}

			private int GetMovingOffset(Point ptMouse)
			{
				Rectangle splitterOutlineBounds = GetSplitterOutlineBounds(ptMouse);
				if (DragSource.IsVertical)
				{
					return splitterOutlineBounds.X - RectSplitter.X;
				}
				return splitterOutlineBounds.Y - RectSplitter.Y;
			}

			private Rectangle GetSplitterOutlineBounds(Point ptMouse)
			{
				Rectangle dragLimitBounds = DragSource.DragLimitBounds;
				Rectangle rectSplitter = RectSplitter;
				if (dragLimitBounds.Width <= 0 || dragLimitBounds.Height <= 0)
				{
					return rectSplitter;
				}
				if (DragSource.IsVertical)
				{
					rectSplitter.X += ptMouse.X - base.StartMousePosition.X;
					rectSplitter.Height = dragLimitBounds.Height;
				}
				else
				{
					rectSplitter.Y += ptMouse.Y - base.StartMousePosition.Y;
					rectSplitter.Width = dragLimitBounds.Width;
				}
				if (rectSplitter.Left < dragLimitBounds.Left)
				{
					rectSplitter.X = dragLimitBounds.X;
				}
				if (rectSplitter.Top < dragLimitBounds.Top)
				{
					rectSplitter.Y = dragLimitBounds.Y;
				}
				if (rectSplitter.Right > dragLimitBounds.Right)
				{
					rectSplitter.X -= rectSplitter.Right - dragLimitBounds.Right;
				}
				if (rectSplitter.Bottom > dragLimitBounds.Bottom)
				{
					rectSplitter.Y -= rectSplitter.Bottom - dragLimitBounds.Bottom;
				}
				return rectSplitter;
			}
		}

		private FocusManagerImpl m_focusManager;

		private DockPanelExtender m_extender;

		private DockPaneCollection m_panes;

		private FloatWindowCollection m_floatWindows;

		private AutoHideWindowControl m_autoHideWindow;

		private DockWindowCollection m_dockWindows;

		private DockContent m_dummyContent;

		private Control m_dummyControl;

		private Color m_BackColor;

		private AutoHideStripBase m_autoHideStripControl = null;

		private bool m_disposed = false;

		private bool m_allowEndUserDocking = true;

		private bool m_allowEndUserNestedDocking = true;

		private DockContentCollection m_contents = new DockContentCollection();

		private bool m_rightToLeftLayout = false;

		private bool m_showDocumentIcon = false;

		private DockPanelSkin m_dockPanelSkin = new DockPanelSkin();

		private DocumentTabStripLocation m_documentTabStripLocation = DocumentTabStripLocation.Top;

		private double m_dockBottomPortion = 0.25;

		private double m_dockLeftPortion = 0.25;

		private double m_dockRightPortion = 0.25;

		private double m_dockTopPortion = 0.25;

		private Size m_defaultFloatWindowSize = new Size(300, 300);

		private DocumentStyle m_documentStyle = DocumentStyle.DockingMdi;

		private PaintEventHandler m_dummyControlPaintEventHandler = null;

		private Rectangle[] m_clipRects = null;

		private static readonly object ContentAddedEvent = new object();

		private static readonly object ContentRemovedEvent = new object();

		private DockDragHandler m_dockDragHandler = null;

		private static readonly object ActiveDocumentChangedEvent = new object();

		private static readonly object ActiveContentChangedEvent = new object();

		private static readonly object ActivePaneChangedEvent = new object();

		private MdiClientController m_mdiClientController = null;

		private SplitterDragHandler m_splitterDragHandler = null;

		private AutoHideWindowControl AutoHideWindow => m_autoHideWindow;

		internal Control AutoHideControl => m_autoHideWindow;

		internal Rectangle AutoHideWindowRectangle
		{
			get
			{
				DockState dockState = AutoHideWindow.DockState;
				Rectangle dockArea = DockArea;
				if (ActiveAutoHideContent == null)
				{
					return Rectangle.Empty;
				}
				if (base.Parent == null)
				{
					return Rectangle.Empty;
				}
				Rectangle empty = Rectangle.Empty;
				double num = ActiveAutoHideContent.DockHandler.AutoHidePortion;
				switch (dockState)
				{
				case DockState.DockLeftAutoHide:
					if (num < 1.0)
					{
						num = (double)dockArea.Width * num;
					}
					if (num > (double)(dockArea.Width - 24))
					{
						num = (double)(dockArea.Width - 24);
					}
					empty.X = dockArea.X;
					empty.Y = dockArea.Y;
					empty.Width = (int)num;
					empty.Height = dockArea.Height;
					break;
				case DockState.DockRightAutoHide:
					if (num < 1.0)
					{
						num = (double)dockArea.Width * num;
					}
					if (num > (double)(dockArea.Width - 24))
					{
						num = (double)(dockArea.Width - 24);
					}
					empty.X = dockArea.X + dockArea.Width - (int)num;
					empty.Y = dockArea.Y;
					empty.Width = (int)num;
					empty.Height = dockArea.Height;
					break;
				case DockState.DockTopAutoHide:
					if (num < 1.0)
					{
						num = (double)dockArea.Height * num;
					}
					if (num > (double)(dockArea.Height - 24))
					{
						num = (double)(dockArea.Height - 24);
					}
					empty.X = dockArea.X;
					empty.Y = dockArea.Y;
					empty.Width = dockArea.Width;
					empty.Height = (int)num;
					break;
				case DockState.DockBottomAutoHide:
					if (num < 1.0)
					{
						num = (double)dockArea.Height * num;
					}
					if (num > (double)(dockArea.Height - 24))
					{
						num = (double)(dockArea.Height - 24);
					}
					empty.X = dockArea.X;
					empty.Y = dockArea.Y + dockArea.Height - (int)num;
					empty.Width = dockArea.Width;
					empty.Height = (int)num;
					break;
				}
				return empty;
			}
		}

		public Color DockBackColor
		{
			get
			{
				return (!m_BackColor.IsEmpty) ? m_BackColor : base.BackColor;
			}
			set
			{
				m_BackColor = value;
			}
		}

		internal AutoHideStripBase AutoHideStripControl
		{
			get
			{
				if (m_autoHideStripControl == null)
				{
					m_autoHideStripControl = AutoHideStripFactory.CreateAutoHideStrip(this);
					base.Controls.Add(m_autoHideStripControl);
				}
				return m_autoHideStripControl;
			}
		}

		[Browsable(false)]
		public IDockContent ActiveAutoHideContent
		{
			get
			{
				return AutoHideWindow.ActiveContent;
			}
			set
			{
				AutoHideWindow.ActiveContent = value;
			}
		}

		[LocalizedDescription("DockPanel_AllowEndUserDocking_Description")]
		[DefaultValue(true)]
		[LocalizedCategory("Category_Docking")]
		public bool AllowEndUserDocking
		{
			get
			{
				return m_allowEndUserDocking;
			}
			set
			{
				m_allowEndUserDocking = value;
			}
		}

		[LocalizedCategory("Category_Docking")]
		[LocalizedDescription("DockPanel_AllowEndUserNestedDocking_Description")]
		[DefaultValue(true)]
		public bool AllowEndUserNestedDocking
		{
			get
			{
				return m_allowEndUserNestedDocking;
			}
			set
			{
				m_allowEndUserNestedDocking = value;
			}
		}

		[Browsable(false)]
		public DockContentCollection Contents
		{
			get
			{
				return m_contents;
			}
		}

		internal DockContent DummyContent => m_dummyContent;

		[LocalizedDescription("DockPanel_RightToLeftLayout_Description")]
		[LocalizedCategory("Appearance")]
		[DefaultValue(false)]
		public bool RightToLeftLayout
		{
			get
			{
				return m_rightToLeftLayout;
			}
			set
			{
				if (m_rightToLeftLayout != value)
				{
					m_rightToLeftLayout = value;
					foreach (FloatWindow floatWindow in FloatWindows)
					{
						floatWindow.RightToLeftLayout = value;
					}
				}
			}
		}

		[LocalizedDescription("DockPanel_ShowDocumentIcon_Description")]
		[DefaultValue(false)]
		[LocalizedCategory("Category_Docking")]
		public bool ShowDocumentIcon
		{
			get
			{
				return m_showDocumentIcon;
			}
			set
			{
				if (m_showDocumentIcon != value)
				{
					m_showDocumentIcon = value;
					Refresh();
				}
			}
		}

		[LocalizedDescription("DockPanel_DockPanelSkin")]
		[LocalizedCategory("Category_Docking")]
		public DockPanelSkin Skin
		{
			get
			{
				return m_dockPanelSkin;
			}
			set
			{
				m_dockPanelSkin = value;
			}
		}

		[DefaultValue(DocumentTabStripLocation.Top)]
		[LocalizedCategory("Category_Docking")]
		[LocalizedDescription("DockPanel_DocumentTabStripLocation")]
		public DocumentTabStripLocation DocumentTabStripLocation
		{
			get
			{
				return m_documentTabStripLocation;
			}
			set
			{
				m_documentTabStripLocation = value;
			}
		}

		[Browsable(false)]
		public DockPanelExtender Extender
		{
			get
			{
				return m_extender;
			}
		}

		public DockPanelExtender.IDockPaneFactory DockPaneFactory => Extender.DockPaneFactory;

		public DockPanelExtender.IFloatWindowFactory FloatWindowFactory => Extender.FloatWindowFactory;

		internal DockPanelExtender.IDockPaneCaptionFactory DockPaneCaptionFactory => Extender.DockPaneCaptionFactory;

		internal DockPanelExtender.IDockPaneStripFactory DockPaneStripFactory => Extender.DockPaneStripFactory;

		internal DockPanelExtender.IAutoHideStripFactory AutoHideStripFactory => Extender.AutoHideStripFactory;

		[Browsable(false)]
		public DockPaneCollection Panes
		{
			get
			{
				return m_panes;
			}
		}

		internal Rectangle DockArea => new Rectangle(base.DockPadding.Left, base.DockPadding.Top, base.ClientRectangle.Width - base.DockPadding.Left - base.DockPadding.Right, base.ClientRectangle.Height - base.DockPadding.Top - base.DockPadding.Bottom);

		[LocalizedDescription("DockPanel_DockBottomPortion_Description")]
		[DefaultValue(0.25)]
		[LocalizedCategory("Category_Docking")]
		public double DockBottomPortion
		{
			get
			{
				return m_dockBottomPortion;
			}
			set
			{
				if (value <= 0.0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				if (value != m_dockBottomPortion)
				{
					m_dockBottomPortion = value;
					if (m_dockBottomPortion < 1.0 && m_dockTopPortion < 1.0 && m_dockTopPortion + m_dockBottomPortion > 1.0)
					{
						m_dockTopPortion = 1.0 - m_dockBottomPortion;
					}
					PerformLayout();
				}
			}
		}

		[LocalizedCategory("Category_Docking")]
		[DefaultValue(0.25)]
		[LocalizedDescription("DockPanel_DockLeftPortion_Description")]
		public double DockLeftPortion
		{
			get
			{
				return m_dockLeftPortion;
			}
			set
			{
				if (value <= 0.0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				if (value != m_dockLeftPortion)
				{
					m_dockLeftPortion = value;
					if (m_dockLeftPortion < 1.0 && m_dockRightPortion < 1.0 && m_dockLeftPortion + m_dockRightPortion > 1.0)
					{
						m_dockRightPortion = 1.0 - m_dockLeftPortion;
					}
					PerformLayout();
				}
			}
		}

		[LocalizedDescription("DockPanel_DockRightPortion_Description")]
		[LocalizedCategory("Category_Docking")]
		[DefaultValue(0.25)]
		public double DockRightPortion
		{
			get
			{
				return m_dockRightPortion;
			}
			set
			{
				if (value <= 0.0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				if (value != m_dockRightPortion)
				{
					m_dockRightPortion = value;
					if (m_dockLeftPortion < 1.0 && m_dockRightPortion < 1.0 && m_dockLeftPortion + m_dockRightPortion > 1.0)
					{
						m_dockLeftPortion = 1.0 - m_dockRightPortion;
					}
					PerformLayout();
				}
			}
		}

		[LocalizedCategory("Category_Docking")]
		[LocalizedDescription("DockPanel_DockTopPortion_Description")]
		[DefaultValue(0.25)]
		public double DockTopPortion
		{
			get
			{
				return m_dockTopPortion;
			}
			set
			{
				if (value <= 0.0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				if (value != m_dockTopPortion)
				{
					m_dockTopPortion = value;
					if (m_dockTopPortion < 1.0 && m_dockBottomPortion < 1.0 && m_dockTopPortion + m_dockBottomPortion > 1.0)
					{
						m_dockBottomPortion = 1.0 - m_dockTopPortion;
					}
					PerformLayout();
				}
			}
		}

		[Browsable(false)]
		public DockWindowCollection DockWindows
		{
			get
			{
				return m_dockWindows;
			}
		}

		public int DocumentsCount
		{
			get
			{
				int num = 0;
				foreach (IDockContent document in Documents)
				{
					num++;
				}
				return num;
			}
		}

		public IEnumerable<IDockContent> Documents
		{
			get
			{
				foreach (IDockContent content in Contents)
				{
					if (content.DockHandler.DockState == DockState.Document)
					{
						yield return content;
					}
				}
			}
		}

		private Rectangle DocumentRectangle
		{
			get
			{
				Rectangle dockArea = DockArea;
				if (DockWindows[DockState.DockLeft].VisibleNestedPanes.Count != 0)
				{
					dockArea.X += (int)((double)DockArea.Width * DockLeftPortion);
					dockArea.Width -= (int)((double)DockArea.Width * DockLeftPortion);
				}
				if (DockWindows[DockState.DockRight].VisibleNestedPanes.Count != 0)
				{
					dockArea.Width -= (int)((double)DockArea.Width * DockRightPortion);
				}
				if (DockWindows[DockState.DockTop].VisibleNestedPanes.Count != 0)
				{
					dockArea.Y += (int)((double)DockArea.Height * DockTopPortion);
					dockArea.Height -= (int)((double)DockArea.Height * DockTopPortion);
				}
				if (DockWindows[DockState.DockBottom].VisibleNestedPanes.Count != 0)
				{
					dockArea.Height -= (int)((double)DockArea.Height * DockBottomPortion);
				}
				return dockArea;
			}
		}

		private Control DummyControl => m_dummyControl;

		[Browsable(false)]
		public FloatWindowCollection FloatWindows
		{
			get
			{
				return m_floatWindows;
			}
		}

		[Category("Layout")]
		[LocalizedDescription("DockPanel_DefaultFloatWindowSize_Description")]
		public Size DefaultFloatWindowSize
		{
			get
			{
				return m_defaultFloatWindowSize;
			}
			set
			{
				m_defaultFloatWindowSize = value;
			}
		}

		[LocalizedCategory("Category_Docking")]
		[DefaultValue(DocumentStyle.DockingMdi)]
		[LocalizedDescription("DockPanel_DocumentStyle_Description")]
		public DocumentStyle DocumentStyle
		{
			get
			{
				return m_documentStyle;
			}
			set
			{
				if (value != m_documentStyle)
				{
					if (!Enum.IsDefined(typeof(DocumentStyle), value))
					{
						throw new InvalidEnumArgumentException();
					}
					if (value == DocumentStyle.SystemMdi && DockWindows[DockState.Document].VisibleNestedPanes.Count > 0)
					{
						throw new InvalidEnumArgumentException();
					}
					m_documentStyle = value;
					SuspendLayout(allWindows: true);
					SetAutoHideWindowParent();
					SetMdiClient();
					InvalidateWindowRegion();
					foreach (IDockContent content in Contents)
					{
						if (content.DockHandler.DockState == DockState.Document)
						{
							content.DockHandler.SetPaneAndVisible(content.DockHandler.Pane);
						}
					}
					PerformMdiClientLayout();
					ResumeLayout(performLayout: true, allWindows: true);
				}
			}
		}

		internal Form ParentForm
		{
			get
			{
				if (!IsParentFormValid())
				{
					throw new InvalidOperationException(Strings.DockPanel_ParentForm_Invalid);
				}
				return GetMdiClientController().ParentForm;
			}
		}

		private Rectangle SystemMdiClientBounds
		{
			get
			{
				if (!IsParentFormValid() || !base.Visible)
				{
					return Rectangle.Empty;
				}
				return ParentForm.RectangleToClient(RectangleToScreen(DocumentWindowBounds));
			}
		}

		internal Rectangle DocumentWindowBounds
		{
			get
			{
				Rectangle displayRectangle = DisplayRectangle;
				if (DockWindows[DockState.DockLeft].Visible)
				{
					displayRectangle.X += DockWindows[DockState.DockLeft].Width;
					displayRectangle.Width -= DockWindows[DockState.DockLeft].Width;
				}
				if (DockWindows[DockState.DockRight].Visible)
				{
					displayRectangle.Width -= DockWindows[DockState.DockRight].Width;
				}
				if (DockWindows[DockState.DockTop].Visible)
				{
					displayRectangle.Y += DockWindows[DockState.DockTop].Height;
					displayRectangle.Height -= DockWindows[DockState.DockTop].Height;
				}
				if (DockWindows[DockState.DockBottom].Visible)
				{
					displayRectangle.Height -= DockWindows[DockState.DockBottom].Height;
				}
				return displayRectangle;
			}
		}

		private IFocusManager FocusManager => m_focusManager;

		internal IContentFocusManager ContentFocusManager => m_focusManager;

		[Browsable(false)]
		public IDockContent ActiveContent
		{
			get
			{
				return FocusManager.ActiveContent;
			}
		}

		[Browsable(false)]
		public DockPane ActivePane
		{
			get
			{
				return FocusManager.ActivePane;
			}
		}

		[Browsable(false)]
		public IDockContent ActiveDocument
		{
			get
			{
				return FocusManager.ActiveDocument;
			}
		}

		[Browsable(false)]
		public DockPane ActiveDocumentPane
		{
			get
			{
				return FocusManager.ActiveDocumentPane;
			}
		}

		private bool MdiClientExists => GetMdiClientController().MdiClient != null;

		[LocalizedDescription("DockPanel_ContentAdded_Description")]
		[LocalizedCategory("Category_DockingNotification")]
		public event EventHandler<DockContentEventArgs> ContentAdded
		{
			add
			{
				base.Events.AddHandler(ContentAddedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(ContentAddedEvent, value);
			}
		}

		[LocalizedDescription("DockPanel_ContentRemoved_Description")]
		[LocalizedCategory("Category_DockingNotification")]
		public event EventHandler<DockContentEventArgs> ContentRemoved
		{
			add
			{
				base.Events.AddHandler(ContentRemovedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(ContentRemovedEvent, value);
			}
		}

		[LocalizedDescription("DockPanel_ActiveDocumentChanged_Description")]
		[LocalizedCategory("Category_PropertyChanged")]
		public event EventHandler ActiveDocumentChanged
		{
			add
			{
				base.Events.AddHandler(ActiveDocumentChangedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(ActiveDocumentChangedEvent, value);
			}
		}

		[LocalizedCategory("Category_PropertyChanged")]
		[LocalizedDescription("DockPanel_ActiveContentChanged_Description")]
		public event EventHandler ActiveContentChanged
		{
			add
			{
				base.Events.AddHandler(ActiveContentChangedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(ActiveContentChangedEvent, value);
			}
		}

		[LocalizedDescription("DockPanel_ActivePaneChanged_Description")]
		[LocalizedCategory("Category_PropertyChanged")]
		public event EventHandler ActivePaneChanged
		{
			add
			{
				base.Events.AddHandler(ActivePaneChangedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(ActivePaneChangedEvent, value);
			}
		}

		internal void RefreshActiveAutoHideContent()
		{
			AutoHideWindow.RefreshActiveContent();
		}

		internal Rectangle GetAutoHideWindowBounds(Rectangle rectAutoHideWindow)
		{
			if (DocumentStyle == DocumentStyle.SystemMdi || DocumentStyle == DocumentStyle.DockingMdi)
			{
				return (base.Parent == null) ? Rectangle.Empty : base.Parent.RectangleToClient(RectangleToScreen(rectAutoHideWindow));
			}
			return rectAutoHideWindow;
		}

		internal void RefreshAutoHideStrip()
		{
			AutoHideStripControl.RefreshChanges();
		}

		public DockPanel()
		{
			m_focusManager = new FocusManagerImpl(this);
			m_extender = new DockPanelExtender(this);
			m_panes = new DockPaneCollection();
			m_floatWindows = new FloatWindowCollection();
			SuspendLayout();
			m_autoHideWindow = new AutoHideWindowControl(this);
			m_autoHideWindow.Visible = false;
			SetAutoHideWindowParent();
			m_dummyControl = new DummyControl();
			m_dummyControl.Bounds = new Rectangle(0, 0, 1, 1);
			base.Controls.Add(m_dummyControl);
			m_dockWindows = new DockWindowCollection(this);
			base.Controls.AddRange(new Control[5]
			{
				DockWindows[DockState.Document],
				DockWindows[DockState.DockLeft],
				DockWindows[DockState.DockRight],
				DockWindows[DockState.DockTop],
				DockWindows[DockState.DockBottom]
			});
			m_dummyContent = new DockContent();
			ResumeLayout();
		}

		internal void ResetAutoHideStripControl()
		{
			if (m_autoHideStripControl != null)
			{
				m_autoHideStripControl.Dispose();
			}
			m_autoHideStripControl = null;
		}

		private void MdiClientHandleAssigned(object sender, EventArgs e)
		{
			SetMdiClient();
			PerformLayout();
		}

		private void MdiClient_Layout(object sender, LayoutEventArgs e)
		{
			if (DocumentStyle == DocumentStyle.DockingMdi)
			{
				foreach (DockPane pane in Panes)
				{
					if (pane.DockState == DockState.Document)
					{
						pane.SetContentBounds();
					}
				}
				InvalidateWindowRegion();
			}
		}

		protected override void Dispose(bool disposing)
		{
			lock (this)
			{
				if (!m_disposed && disposing)
				{
					m_focusManager.Dispose();
					if (m_mdiClientController != null)
					{
						m_mdiClientController.HandleAssigned -= MdiClientHandleAssigned;
						m_mdiClientController.MdiChildActivate -= ParentFormMdiChildActivate;
						m_mdiClientController.Layout -= MdiClient_Layout;
						m_mdiClientController.Dispose();
					}
					FloatWindows.Dispose();
					Panes.Dispose();
					DummyContent.Dispose();
					m_disposed = true;
				}
				base.Dispose(disposing);
			}
		}

		protected override void OnRightToLeftChanged(EventArgs e)
		{
			base.OnRightToLeftChanged(e);
			foreach (FloatWindow floatWindow in FloatWindows)
			{
				if (floatWindow.RightToLeft != RightToLeft)
				{
					floatWindow.RightToLeft = RightToLeft;
				}
			}
		}

		public void UpdateDockWindowZOrder(DockStyle dockStyle, bool fullPanelEdge)
		{
			switch (dockStyle)
			{
			case DockStyle.Left:
				if (fullPanelEdge)
				{
					DockWindows[DockState.DockLeft].SendToBack();
				}
				else
				{
					DockWindows[DockState.DockLeft].BringToFront();
				}
				break;
			case DockStyle.Right:
				if (fullPanelEdge)
				{
					DockWindows[DockState.DockRight].SendToBack();
				}
				else
				{
					DockWindows[DockState.DockRight].BringToFront();
				}
				break;
			case DockStyle.Top:
				if (fullPanelEdge)
				{
					DockWindows[DockState.DockTop].SendToBack();
				}
				else
				{
					DockWindows[DockState.DockTop].BringToFront();
				}
				break;
			case DockStyle.Bottom:
				if (fullPanelEdge)
				{
					DockWindows[DockState.DockBottom].SendToBack();
				}
				else
				{
					DockWindows[DockState.DockBottom].BringToFront();
				}
				break;
			}
		}

		public IDockContent[] DocumentsToArray()
		{
			int documentsCount = DocumentsCount;
			IDockContent[] array = new IDockContent[documentsCount];
			int num = 0;
			foreach (IDockContent document in Documents)
			{
				IDockContent dockContent = array[num] = document;
				num++;
			}
			return array;
		}

		private bool ShouldSerializeDefaultFloatWindowSize()
		{
			return DefaultFloatWindowSize != new Size(300, 300);
		}

		private int GetDockWindowSize(DockState dockState)
		{
			if (dockState == DockState.DockLeft || dockState == DockState.DockRight)
			{
				int num = base.ClientRectangle.Width - base.DockPadding.Left - base.DockPadding.Right;
				int num2 = (m_dockLeftPortion >= 1.0) ? ((int)m_dockLeftPortion) : ((int)((double)num * m_dockLeftPortion));
				int num3 = (m_dockRightPortion >= 1.0) ? ((int)m_dockRightPortion) : ((int)((double)num * m_dockRightPortion));
				if (num2 < 24)
				{
					num2 = 24;
				}
				if (num3 < 24)
				{
					num3 = 24;
				}
				if (num2 + num3 > num - 24)
				{
					int num4 = num2 + num3 - (num - 24);
					num2 -= num4 / 2;
					num3 -= num4 / 2;
				}
				return (dockState == DockState.DockLeft) ? num2 : num3;
			}
			if (dockState == DockState.DockTop || dockState == DockState.DockBottom)
			{
				int num5 = base.ClientRectangle.Height - base.DockPadding.Top - base.DockPadding.Bottom;
				int num6 = (m_dockTopPortion >= 1.0) ? ((int)m_dockTopPortion) : ((int)((double)num5 * m_dockTopPortion));
				int num7 = (m_dockBottomPortion >= 1.0) ? ((int)m_dockBottomPortion) : ((int)((double)num5 * m_dockBottomPortion));
				if (num6 < 24)
				{
					num6 = 24;
				}
				if (num7 < 24)
				{
					num7 = 24;
				}
				if (num6 + num7 > num5 - 24)
				{
					int num4 = num6 + num7 - (num5 - 24);
					num6 -= num4 / 2;
					num7 -= num4 / 2;
				}
				return (dockState == DockState.DockTop) ? num6 : num7;
			}
			return 0;
		}

		protected override void OnLayout(LayoutEventArgs levent)
		{
			SuspendLayout(allWindows: true);
			AutoHideStripControl.Bounds = base.ClientRectangle;
			CalculateDockPadding();
			DockWindows[DockState.DockLeft].Width = GetDockWindowSize(DockState.DockLeft);
			DockWindows[DockState.DockRight].Width = GetDockWindowSize(DockState.DockRight);
			DockWindows[DockState.DockTop].Height = GetDockWindowSize(DockState.DockTop);
			DockWindows[DockState.DockBottom].Height = GetDockWindowSize(DockState.DockBottom);
			AutoHideWindow.Bounds = GetAutoHideWindowBounds(AutoHideWindowRectangle);
			DockWindows[DockState.Document].BringToFront();
			AutoHideWindow.BringToFront();
			base.OnLayout(levent);
			if (DocumentStyle == DocumentStyle.SystemMdi && MdiClientExists)
			{
				SetMdiClientBounds(SystemMdiClientBounds);
				InvalidateWindowRegion();
			}
			else if (DocumentStyle == DocumentStyle.DockingMdi)
			{
				InvalidateWindowRegion();
			}
			ResumeLayout(performLayout: true, allWindows: true);
		}

		internal Rectangle GetTabStripRectangle(DockState dockState)
		{
			return AutoHideStripControl.GetTabStripRectangle(dockState);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (!(DockBackColor == BackColor))
			{
				Graphics graphics = e.Graphics;
				SolidBrush brush = new SolidBrush(DockBackColor);
				graphics.FillRectangle(brush, base.ClientRectangle);
			}
		}

		internal void AddContent(IDockContent content)
		{
			if (content == null)
			{
				throw new ArgumentNullException();
			}
			if (!Contents.Contains(content))
			{
				Contents.Add(content);
				OnContentAdded(new DockContentEventArgs(content));
			}
		}

		internal void AddPane(DockPane pane)
		{
			if (!Panes.Contains(pane))
			{
				Panes.Add(pane);
			}
		}

		internal void AddFloatWindow(FloatWindow floatWindow)
		{
			if (!FloatWindows.Contains(floatWindow))
			{
				FloatWindows.Add(floatWindow);
			}
		}

		private void CalculateDockPadding()
		{
			base.DockPadding.All = 0;
			int num = AutoHideStripControl.MeasureHeight();
			if (AutoHideStripControl.GetNumberOfPanes(DockState.DockLeftAutoHide) > 0)
			{
				base.DockPadding.Left = num;
			}
			if (AutoHideStripControl.GetNumberOfPanes(DockState.DockRightAutoHide) > 0)
			{
				base.DockPadding.Right = num;
			}
			if (AutoHideStripControl.GetNumberOfPanes(DockState.DockTopAutoHide) > 0)
			{
				base.DockPadding.Top = num;
			}
			if (AutoHideStripControl.GetNumberOfPanes(DockState.DockBottomAutoHide) > 0)
			{
				base.DockPadding.Bottom = num;
			}
		}

		internal void RemoveContent(IDockContent content)
		{
			if (content == null)
			{
				throw new ArgumentNullException();
			}
			if (Contents.Contains(content))
			{
				Contents.Remove(content);
				OnContentRemoved(new DockContentEventArgs(content));
			}
		}

		internal void RemovePane(DockPane pane)
		{
			if (Panes.Contains(pane))
			{
				Panes.Remove(pane);
			}
		}

		internal void RemoveFloatWindow(FloatWindow floatWindow)
		{
			if (FloatWindows.Contains(floatWindow))
			{
				FloatWindows.Remove(floatWindow);
			}
		}

		public void SetPaneIndex(DockPane pane, int index)
		{
			int num = Panes.IndexOf(pane);
			if (num == -1)
			{
				throw new ArgumentException(Strings.DockPanel_SetPaneIndex_InvalidPane);
			}
			if ((index < 0 || index > Panes.Count - 1) && index != -1)
			{
				throw new ArgumentOutOfRangeException(Strings.DockPanel_SetPaneIndex_InvalidIndex);
			}
			if (num != index && (num != Panes.Count - 1 || index != -1))
			{
				Panes.Remove(pane);
				if (index == -1)
				{
					Panes.Add(pane);
				}
				else if (num < index)
				{
					Panes.AddAt(pane, index - 1);
				}
				else
				{
					Panes.AddAt(pane, index);
				}
			}
		}

		public void SuspendLayout(bool allWindows)
		{
			FocusManager.SuspendFocusTracking();
			SuspendLayout();
			if (allWindows)
			{
				SuspendMdiClientLayout();
			}
		}

		public void ResumeLayout(bool performLayout, bool allWindows)
		{
			FocusManager.ResumeFocusTracking();
			ResumeLayout(performLayout);
			if (allWindows)
			{
				ResumeMdiClientLayout(performLayout);
			}
		}

		private bool IsParentFormValid()
		{
			if (DocumentStyle == DocumentStyle.DockingSdi || DocumentStyle == DocumentStyle.DockingWindow)
			{
				return true;
			}
			if (!MdiClientExists)
			{
				GetMdiClientController().RenewMdiClient();
			}
			return MdiClientExists;
		}

		protected override void OnParentChanged(EventArgs e)
		{
			SetAutoHideWindowParent();
			GetMdiClientController().ParentForm = (base.Parent as Form);
			base.OnParentChanged(e);
		}

		private void SetAutoHideWindowParent()
		{
			Control control = (DocumentStyle != 0 && DocumentStyle != DocumentStyle.SystemMdi) ? this : base.Parent;
			if (AutoHideWindow.Parent != control)
			{
				AutoHideWindow.Parent = control;
				AutoHideWindow.BringToFront();
			}
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if (base.Visible)
			{
				SetMdiClient();
			}
		}

		private void InvalidateWindowRegion()
		{
			if (!base.DesignMode)
			{
				if (m_dummyControlPaintEventHandler == null)
				{
					m_dummyControlPaintEventHandler = DummyControl_Paint;
				}
				DummyControl.Paint += m_dummyControlPaintEventHandler;
				DummyControl.Invalidate();
			}
		}

		private void DummyControl_Paint(object sender, PaintEventArgs e)
		{
			DummyControl.Paint -= m_dummyControlPaintEventHandler;
			UpdateWindowRegion();
		}

		private void UpdateWindowRegion()
		{
			if (DocumentStyle == DocumentStyle.DockingMdi)
			{
				UpdateWindowRegion_ClipContent();
			}
			else if (DocumentStyle == DocumentStyle.DockingSdi || DocumentStyle == DocumentStyle.DockingWindow)
			{
				UpdateWindowRegion_FullDocumentArea();
			}
			else if (DocumentStyle == DocumentStyle.SystemMdi)
			{
				UpdateWindowRegion_EmptyDocumentArea();
			}
		}

		private void UpdateWindowRegion_FullDocumentArea()
		{
			SetRegion(null);
		}

		private void UpdateWindowRegion_EmptyDocumentArea()
		{
			Rectangle documentWindowBounds = DocumentWindowBounds;
			SetRegion(new Rectangle[1]
			{
				documentWindowBounds
			});
		}

		private void UpdateWindowRegion_ClipContent()
		{
			int num = 0;
			foreach (DockPane pane in Panes)
			{
				if (pane.Visible && pane.DockState == DockState.Document)
				{
					num++;
				}
			}
			if (num == 0)
			{
				SetRegion(null);
			}
			else
			{
				Rectangle[] array = new Rectangle[num];
				int num2 = 0;
				foreach (DockPane pane2 in Panes)
				{
					if (pane2.Visible && pane2.DockState == DockState.Document)
					{
						array[num2] = RectangleToClient(pane2.RectangleToScreen(pane2.ContentRectangle));
						num2++;
					}
				}
				SetRegion(array);
			}
		}

		private void SetRegion(Rectangle[] clipRects)
		{
			if (IsClipRectsChanged(clipRects))
			{
				m_clipRects = clipRects;
				if (m_clipRects == null || m_clipRects.GetLength(0) == 0)
				{
					base.Region = null;
				}
				else
				{
					Region region = new Region(new Rectangle(0, 0, base.Width, base.Height));
					Rectangle[] clipRects2 = m_clipRects;
					foreach (Rectangle rect in clipRects2)
					{
						region.Exclude(rect);
					}
					base.Region = region;
				}
			}
		}

		private bool IsClipRectsChanged(Rectangle[] clipRects)
		{
			if (clipRects == null && m_clipRects == null)
			{
				return false;
			}
			if (clipRects == null != (m_clipRects == null))
			{
				return true;
			}
			foreach (Rectangle left in clipRects)
			{
				bool flag = false;
				Rectangle[] clipRects2 = m_clipRects;
				foreach (Rectangle right in clipRects2)
				{
					if (left == right)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return true;
				}
			}
			Rectangle[] clipRects3 = m_clipRects;
			foreach (Rectangle right in clipRects3)
			{
				bool flag = false;
				foreach (Rectangle left in clipRects)
				{
					if (left == right)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return true;
				}
			}
			return false;
		}

		protected virtual void OnContentAdded(DockContentEventArgs e)
		{
			((EventHandler<DockContentEventArgs>)base.Events[ContentAddedEvent])?.Invoke(this, e);
		}

		protected virtual void OnContentRemoved(DockContentEventArgs e)
		{
			((EventHandler<DockContentEventArgs>)base.Events[ContentRemovedEvent])?.Invoke(this, e);
		}

		private DockDragHandler GetDockDragHandler()
		{
			if (m_dockDragHandler == null)
			{
				m_dockDragHandler = new DockDragHandler(this);
			}
			return m_dockDragHandler;
		}

		internal void BeginDrag(IDockDragSource dragSource)
		{
			GetDockDragHandler().BeginDrag(dragSource);
		}

		internal void SaveFocus()
		{
			DummyControl.Focus();
		}

		protected virtual void OnActiveDocumentChanged(EventArgs e)
		{
			((EventHandler)base.Events[ActiveDocumentChangedEvent])?.Invoke(this, e);
		}

		protected void OnActiveContentChanged(EventArgs e)
		{
			((EventHandler)base.Events[ActiveContentChangedEvent])?.Invoke(this, e);
		}

		protected virtual void OnActivePaneChanged(EventArgs e)
		{
			((EventHandler)base.Events[ActivePaneChangedEvent])?.Invoke(this, e);
		}

		private MdiClientController GetMdiClientController()
		{
			if (m_mdiClientController == null)
			{
				m_mdiClientController = new MdiClientController();
				m_mdiClientController.HandleAssigned += MdiClientHandleAssigned;
				m_mdiClientController.MdiChildActivate += ParentFormMdiChildActivate;
				m_mdiClientController.Layout += MdiClient_Layout;
			}
			return m_mdiClientController;
		}

		private void ParentFormMdiChildActivate(object sender, EventArgs e)
		{
			if (GetMdiClientController().ParentForm != null)
			{
				IDockContent dockContent = GetMdiClientController().ParentForm.ActiveMdiChild as IDockContent;
				if (dockContent != null && dockContent.DockHandler.DockPanel == this && dockContent.DockHandler.Pane != null)
				{
					dockContent.DockHandler.Pane.ActiveContent = dockContent;
				}
			}
		}

		private void SetMdiClientBounds(Rectangle bounds)
		{
			GetMdiClientController().MdiClient.Bounds = bounds;
		}

		private void SuspendMdiClientLayout()
		{
			if (GetMdiClientController().MdiClient != null)
			{
				GetMdiClientController().MdiClient.SuspendLayout();
			}
		}

		private void ResumeMdiClientLayout(bool perform)
		{
			if (GetMdiClientController().MdiClient != null)
			{
				GetMdiClientController().MdiClient.ResumeLayout(perform);
			}
		}

		private void PerformMdiClientLayout()
		{
			if (GetMdiClientController().MdiClient != null)
			{
				GetMdiClientController().MdiClient.PerformLayout();
			}
		}

		private void SetMdiClient()
		{
			MdiClientController mdiClientController = GetMdiClientController();
			if (DocumentStyle == DocumentStyle.DockingMdi)
			{
				mdiClientController.AutoScroll = false;
				mdiClientController.BorderStyle = BorderStyle.None;
				if (MdiClientExists)
				{
					mdiClientController.MdiClient.Dock = DockStyle.Fill;
				}
			}
			else if (DocumentStyle == DocumentStyle.DockingSdi || DocumentStyle == DocumentStyle.DockingWindow)
			{
				mdiClientController.AutoScroll = true;
				mdiClientController.BorderStyle = BorderStyle.Fixed3D;
				if (MdiClientExists)
				{
					mdiClientController.MdiClient.Dock = DockStyle.Fill;
				}
			}
			else if (DocumentStyle == DocumentStyle.SystemMdi)
			{
				mdiClientController.AutoScroll = true;
				mdiClientController.BorderStyle = BorderStyle.Fixed3D;
				if (mdiClientController.MdiClient != null)
				{
					mdiClientController.MdiClient.Dock = DockStyle.None;
					mdiClientController.MdiClient.Bounds = SystemMdiClientBounds;
				}
			}
		}

		internal Rectangle RectangleToMdiClient(Rectangle rect)
		{
			if (MdiClientExists)
			{
				return GetMdiClientController().MdiClient.RectangleToClient(rect);
			}
			return Rectangle.Empty;
		}

		public void SaveAsXml(string fileName)
		{
			Persistor.SaveAsXml(this, fileName);
		}

		public void SaveAsXml(string fileName, Encoding encoding)
		{
			Persistor.SaveAsXml(this, fileName, encoding);
		}

		public void SaveAsXml(Stream stream, Encoding encoding)
		{
			Persistor.SaveAsXml(this, stream, encoding);
		}

		public void SaveAsXml(Stream stream, Encoding encoding, bool upstream)
		{
			Persistor.SaveAsXml(this, stream, encoding, upstream);
		}

		public void LoadFromXml(string fileName, DeserializeDockContent deserializeContent)
		{
			Persistor.LoadFromXml(this, fileName, deserializeContent);
		}

		public void LoadFromXml(Stream stream, DeserializeDockContent deserializeContent)
		{
			Persistor.LoadFromXml(this, stream, deserializeContent);
		}

		public void LoadFromXml(Stream stream, DeserializeDockContent deserializeContent, bool closeStream)
		{
			Persistor.LoadFromXml(this, stream, deserializeContent, closeStream);
		}

		private SplitterDragHandler GetSplitterDragHandler()
		{
			if (m_splitterDragHandler == null)
			{
				m_splitterDragHandler = new SplitterDragHandler(this);
			}
			return m_splitterDragHandler;
		}

		internal void BeginDrag(ISplitterDragSource dragSource, Rectangle rectSplitter)
		{
			GetSplitterDragHandler().BeginDrag(dragSource, rectSplitter);
		}
	}
}
