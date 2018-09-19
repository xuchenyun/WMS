#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;

namespace CIT.Client.Docking
{
	[ToolboxItem(false)]
	public class DockPane : UserControl, IDockDragSource, IDragSource
	{
		public enum AppearanceStyle
		{
			ToolWindow,
			Document
		}

		private enum HitTestArea
		{
			Caption,
			TabStrip,
			Content,
			None
		}

		private struct HitTestResult
		{
			public HitTestArea HitArea;

			public int Index;

			public HitTestResult(HitTestArea hitTestArea, int index)
			{
				HitArea = hitTestArea;
				Index = index;
			}
		}

		private class SplitterControl : Control, ISplitterDragSource, IDragSource
		{
			private DockPane m_pane;

			private DockAlignment m_alignment;

			public DockPane DockPane => m_pane;

			public DockAlignment Alignment
			{
				get
				{
					return m_alignment;
				}
				set
				{
					m_alignment = value;
					if (m_alignment == DockAlignment.Left || m_alignment == DockAlignment.Right)
					{
						Cursor = Cursors.VSplit;
					}
					else if (m_alignment == DockAlignment.Top || m_alignment == DockAlignment.Bottom)
					{
						Cursor = Cursors.HSplit;
					}
					else
					{
						Cursor = Cursors.Default;
					}
					if (DockPane.DockState == DockState.Document)
					{
						Invalidate();
					}
				}
			}

			bool ISplitterDragSource.IsVertical
			{
				get
				{
					NestedDockingStatus nestedDockingStatus = DockPane.NestedDockingStatus;
					return nestedDockingStatus.DisplayingAlignment == DockAlignment.Left || nestedDockingStatus.DisplayingAlignment == DockAlignment.Right;
				}
			}

			Rectangle ISplitterDragSource.DragLimitBounds
			{
				get
				{
					NestedDockingStatus nestedDockingStatus = DockPane.NestedDockingStatus;
					Rectangle result = base.Parent.RectangleToScreen(nestedDockingStatus.LogicalBounds);
					if (((ISplitterDragSource)this).IsVertical)
					{
						result.X += 24;
						result.Width -= 48;
					}
					else
					{
						result.Y += 24;
						result.Height -= 48;
					}
					return result;
				}
			}

			Control IDragSource.DragControl
			{
				get
				{
					return this;
				}
			}

			public SplitterControl(DockPane pane)
			{
				SetStyle(ControlStyles.Selectable, value: false);
				m_pane = pane;
			}

			protected override void OnPaint(PaintEventArgs e)
			{
				base.OnPaint(e);
				if (DockPane.DockState == DockState.Document)
				{
					Graphics graphics = e.Graphics;
					Rectangle clientRectangle = base.ClientRectangle;
					if (Alignment == DockAlignment.Top || Alignment == DockAlignment.Bottom)
					{
						graphics.DrawLine(SystemPens.ControlDark, clientRectangle.Left, clientRectangle.Bottom - 1, clientRectangle.Right, clientRectangle.Bottom - 1);
					}
					else if (Alignment == DockAlignment.Left || Alignment == DockAlignment.Right)
					{
						graphics.DrawLine(SystemPens.ControlDarkDark, clientRectangle.Right - 1, clientRectangle.Top, clientRectangle.Right - 1, clientRectangle.Bottom);
					}
				}
			}

			protected override void OnMouseDown(MouseEventArgs e)
			{
				base.OnMouseDown(e);
				if (e.Button == MouseButtons.Left)
				{
					DockPane.DockPanel.BeginDrag(this, base.Parent.RectangleToScreen(base.Bounds));
				}
			}

			void ISplitterDragSource.BeginDrag(Rectangle rectSplitter)
			{
			}

			void ISplitterDragSource.EndDrag()
			{
			}

			void ISplitterDragSource.MoveSplitter(int offset)
			{
				NestedDockingStatus nestedDockingStatus = DockPane.NestedDockingStatus;
				double proportion = nestedDockingStatus.Proportion;
				if (nestedDockingStatus.LogicalBounds.Width > 0 && nestedDockingStatus.LogicalBounds.Height > 0)
				{
					proportion = ((nestedDockingStatus.DisplayingAlignment == DockAlignment.Left) ? (proportion + (double)offset / (double)nestedDockingStatus.LogicalBounds.Width) : ((nestedDockingStatus.DisplayingAlignment == DockAlignment.Right) ? (proportion - (double)offset / (double)nestedDockingStatus.LogicalBounds.Width) : ((nestedDockingStatus.DisplayingAlignment != DockAlignment.Top) ? (proportion - (double)offset / (double)nestedDockingStatus.LogicalBounds.Height) : (proportion + (double)offset / (double)nestedDockingStatus.LogicalBounds.Height))));
					DockPane.SetNestedDockingProportion(proportion);
				}
			}
		}

		private DockPaneCaptionBase m_captionControl;

		private DockPaneStripBase m_tabStripControl;

		private IDockContent m_activeContent = null;

		private bool m_allowDockDragAndDrop = true;

		private IDisposable m_autoHidePane = null;

		private object m_autoHideTabs = null;

		private DockContentCollection m_contents;

		private DockContentCollection m_displayingContents;

		private DockPanel m_dockPanel;

		private bool m_isActivated = false;

		private bool m_isActiveDocumentPane = false;

		private bool m_isHidden = true;

		private static readonly object DockStateChangedEvent = new object();

		private static readonly object IsActivatedChangedEvent = new object();

		private static readonly object IsActiveDocumentPaneChangedEvent = new object();

		private NestedDockingStatus m_nestedDockingStatus;

		private bool m_isFloat;

		private DockState m_dockState = DockState.Unknown;

		private int m_countRefreshStateChange = 0;

		private SplitterControl m_splitter;

		private DockPaneCaptionBase CaptionControl => m_captionControl;

		internal DockPaneStripBase TabStripControl => m_tabStripControl;

		public virtual IDockContent ActiveContent
		{
			get
			{
				return m_activeContent;
			}
			set
			{
				if (ActiveContent != value)
				{
					if (value != null)
					{
						if (!DisplayingContents.Contains(value))
						{
							throw new InvalidOperationException(Strings.DockPane_ActiveContent_InvalidValue);
						}
					}
					else if (DisplayingContents.Count != 0)
					{
						throw new InvalidOperationException(Strings.DockPane_ActiveContent_InvalidValue);
					}
					IDockContent activeContent = m_activeContent;
					if (DockPanel.ActiveAutoHideContent == activeContent)
					{
						DockPanel.ActiveAutoHideContent = null;
					}
					m_activeContent = value;
					if (DockPanel.DocumentStyle == DocumentStyle.DockingMdi && DockState == DockState.Document)
					{
						if (m_activeContent != null)
						{
							m_activeContent.DockHandler.Form.BringToFront();
						}
					}
					else
					{
						if (m_activeContent != null)
						{
							m_activeContent.DockHandler.SetVisible();
						}
						if (activeContent != null && DisplayingContents.Contains(activeContent))
						{
							activeContent.DockHandler.SetVisible();
						}
						if (IsActivated && m_activeContent != null)
						{
							m_activeContent.DockHandler.Activate();
						}
					}
					if (FloatWindow != null)
					{
						FloatWindow.SetText();
					}
					if (DockPanel.DocumentStyle == DocumentStyle.DockingMdi && DockState == DockState.Document)
					{
						RefreshChanges(performLayout: false);
					}
					else
					{
						RefreshChanges();
					}
					if (m_activeContent != null)
					{
						TabStripControl.EnsureTabVisible(m_activeContent);
					}
				}
			}
		}

		public virtual bool AllowDockDragAndDrop
		{
			get
			{
				return m_allowDockDragAndDrop;
			}
			set
			{
				m_allowDockDragAndDrop = value;
			}
		}

		internal IDisposable AutoHidePane
		{
			get
			{
				return m_autoHidePane;
			}
			set
			{
				m_autoHidePane = value;
			}
		}

		internal object AutoHideTabs
		{
			get
			{
				return m_autoHideTabs;
			}
			set
			{
				m_autoHideTabs = value;
			}
		}

		private object TabPageContextMenu
		{
			get
			{
				IDockContent activeContent = ActiveContent;
				if (activeContent == null)
				{
					return null;
				}
				if (activeContent.DockHandler.TabPageContextMenuStrip != null)
				{
					return activeContent.DockHandler.TabPageContextMenuStrip;
				}
				if (activeContent.DockHandler.TabPageContextMenu != null)
				{
					return activeContent.DockHandler.TabPageContextMenu;
				}
				return null;
			}
		}

		internal bool HasTabPageContextMenu => TabPageContextMenu != null;

		private Rectangle CaptionRectangle
		{
			get
			{
				if (!HasCaption)
				{
					return Rectangle.Empty;
				}
				Rectangle displayingRectangle = DisplayingRectangle;
				int x = displayingRectangle.X;
				int y = displayingRectangle.Y;
				int width = displayingRectangle.Width;
				int height = CaptionControl.MeasureHeight();
				return new Rectangle(x, y, width, height);
			}
		}

		internal Rectangle ContentRectangle
		{
			get
			{
				Rectangle displayingRectangle = DisplayingRectangle;
				Rectangle captionRectangle = CaptionRectangle;
				Rectangle tabStripRectangle = TabStripRectangle;
				int x = displayingRectangle.X;
				int num = displayingRectangle.Y + ((!captionRectangle.IsEmpty) ? captionRectangle.Height : 0);
				if (DockState == DockState.Document && DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Top)
				{
					num += tabStripRectangle.Height;
				}
				int width = displayingRectangle.Width;
				int height = displayingRectangle.Height - captionRectangle.Height - tabStripRectangle.Height;
				return new Rectangle(x, num, width, height);
			}
		}

		internal Rectangle TabStripRectangle
		{
			get
			{
				if (Appearance == AppearanceStyle.ToolWindow)
				{
					return TabStripRectangle_ToolWindow;
				}
				return TabStripRectangle_Document;
			}
		}

		private Rectangle TabStripRectangle_ToolWindow
		{
			get
			{
				if (DisplayingContents.Count <= 1 || IsAutoHide)
				{
					return Rectangle.Empty;
				}
				Rectangle displayingRectangle = DisplayingRectangle;
				int width = displayingRectangle.Width;
				int num = TabStripControl.MeasureHeight();
				int x = displayingRectangle.X;
				int y = displayingRectangle.Bottom - num;
				Rectangle captionRectangle = CaptionRectangle;
				if (captionRectangle.Contains(x, y))
				{
					y = captionRectangle.Y + captionRectangle.Height;
				}
				return new Rectangle(x, y, width, num);
			}
		}

		private Rectangle TabStripRectangle_Document
		{
			get
			{
				if (DisplayingContents.Count == 0)
				{
					return Rectangle.Empty;
				}
				if (DisplayingContents.Count == 1 && DockPanel.DocumentStyle == DocumentStyle.DockingSdi)
				{
					return Rectangle.Empty;
				}
				Rectangle displayingRectangle = DisplayingRectangle;
				int x = displayingRectangle.X;
				int width = displayingRectangle.Width;
				int num = TabStripControl.MeasureHeight();
				int num2 = 0;
				num2 = ((DockPanel.DocumentTabStripLocation != DocumentTabStripLocation.Bottom) ? displayingRectangle.Y : (displayingRectangle.Height - num));
				return new Rectangle(x, num2, width, num);
			}
		}

		public virtual string CaptionText => (ActiveContent == null) ? string.Empty : ActiveContent.DockHandler.TabText;

		public DockContentCollection Contents => m_contents;

		public DockContentCollection DisplayingContents => m_displayingContents;

		public DockPanel DockPanel => m_dockPanel;

		private bool HasCaption
		{
			get
			{
				if (DockState == DockState.Document || DockState == DockState.Hidden || DockState == DockState.Unknown || (DockState == DockState.Float && FloatWindow.VisibleNestedPanes.Count <= 1))
				{
					return false;
				}
				return true;
			}
		}

		public bool IsActivated => m_isActivated;

		public bool IsActiveDocumentPane => m_isActiveDocumentPane;

		public bool IsAutoHide => DockHelper.IsDockStateAutoHide(DockState);

		public AppearanceStyle Appearance => (DockState == DockState.Document) ? AppearanceStyle.Document : AppearanceStyle.ToolWindow;

		internal Rectangle DisplayingRectangle => base.ClientRectangle;

		public bool IsHidden => m_isHidden;

		public DockWindow DockWindow
		{
			get
			{
				return (m_nestedDockingStatus.NestedPanes == null) ? null : (m_nestedDockingStatus.NestedPanes.Container as DockWindow);
			}
			set
			{
				DockWindow dockWindow = DockWindow;
				if (dockWindow != value)
				{
					DockTo(value);
				}
			}
		}

		public FloatWindow FloatWindow
		{
			get
			{
				return (m_nestedDockingStatus.NestedPanes == null) ? null : (m_nestedDockingStatus.NestedPanes.Container as FloatWindow);
			}
			set
			{
				FloatWindow floatWindow = FloatWindow;
				if (floatWindow != value)
				{
					DockTo(value);
				}
			}
		}

		public NestedDockingStatus NestedDockingStatus => m_nestedDockingStatus;

		public bool IsFloat => m_isFloat;

		public INestedPanesContainer NestedPanesContainer
		{
			get
			{
				if (NestedDockingStatus.NestedPanes == null)
				{
					return null;
				}
				return NestedDockingStatus.NestedPanes.Container;
			}
		}

		public DockState DockState
		{
			get
			{
				return m_dockState;
			}
			set
			{
				SetDockState(value);
			}
		}

		private bool IsRefreshStateChangeSuspended => m_countRefreshStateChange != 0;

		Control IDragSource.DragControl
		{
			get
			{
				return this;
			}
		}

		private SplitterControl Splitter => m_splitter;

		internal Rectangle SplitterBounds
		{
			set
			{
				Splitter.Bounds = value;
			}
		}

		internal DockAlignment SplitterAlignment
		{
			set
			{
				Splitter.Alignment = value;
			}
		}

		public event EventHandler DockStateChanged
		{
			add
			{
				base.Events.AddHandler(DockStateChangedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(DockStateChangedEvent, value);
			}
		}

		public event EventHandler IsActivatedChanged
		{
			add
			{
				base.Events.AddHandler(IsActivatedChangedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(IsActivatedChangedEvent, value);
			}
		}

		public event EventHandler IsActiveDocumentPaneChanged
		{
			add
			{
				base.Events.AddHandler(IsActiveDocumentPaneChangedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(IsActiveDocumentPaneChangedEvent, value);
			}
		}

		protected internal DockPane(IDockContent content, DockState visibleState, bool show)
		{
			InternalConstruct(content, visibleState, flagBounds: false, Rectangle.Empty, null, DockAlignment.Right, 0.5, show);
		}

		protected internal DockPane(IDockContent content, FloatWindow floatWindow, bool show)
		{
			if (floatWindow == null)
			{
				throw new ArgumentNullException("floatWindow");
			}
			InternalConstruct(content, DockState.Float, flagBounds: false, Rectangle.Empty, floatWindow.NestedPanes.GetDefaultPreviousPane(this), DockAlignment.Right, 0.5, show);
		}

		protected internal DockPane(IDockContent content, DockPane previousPane, DockAlignment alignment, double proportion, bool show)
		{
			if (previousPane == null)
			{
				throw new ArgumentNullException("previousPane");
			}
			InternalConstruct(content, previousPane.DockState, flagBounds: false, Rectangle.Empty, previousPane, alignment, proportion, show);
		}

		protected internal DockPane(IDockContent content, Rectangle floatWindowBounds, bool show)
		{
			InternalConstruct(content, DockState.Float, flagBounds: true, floatWindowBounds, null, DockAlignment.Right, 0.5, show);
		}

		private void InternalConstruct(IDockContent content, DockState dockState, bool flagBounds, Rectangle floatWindowBounds, DockPane prevPane, DockAlignment alignment, double proportion, bool show)
		{
			if (dockState == DockState.Hidden || dockState == DockState.Unknown)
			{
				throw new ArgumentException(Strings.DockPane_SetDockState_InvalidState);
			}
			if (content == null)
			{
				throw new ArgumentNullException(Strings.DockPane_Constructor_NullContent);
			}
			if (content.DockHandler.DockPanel == null)
			{
				throw new ArgumentException(Strings.DockPane_Constructor_NullDockPanel);
			}
			SuspendLayout();
			SetStyle(ControlStyles.Selectable, value: false);
			m_isFloat = (dockState == DockState.Float);
			m_contents = new DockContentCollection();
			m_displayingContents = new DockContentCollection(this);
			m_dockPanel = content.DockHandler.DockPanel;
			m_dockPanel.AddPane(this);
			m_splitter = new SplitterControl(this);
			m_nestedDockingStatus = new NestedDockingStatus(this);
			m_captionControl = DockPanel.DockPaneCaptionFactory.CreateDockPaneCaption(this);
			m_tabStripControl = DockPanel.DockPaneStripFactory.CreateDockPaneStrip(this);
			base.Controls.AddRange(new Control[2]
			{
				m_captionControl,
				m_tabStripControl
			});
			DockPanel.SuspendLayout(allWindows: true);
			if (flagBounds)
			{
				FloatWindow = DockPanel.FloatWindowFactory.CreateFloatWindow(DockPanel, this, floatWindowBounds);
			}
			else if (prevPane != null)
			{
				DockTo(prevPane.NestedPanesContainer, prevPane, alignment, proportion);
			}
			SetDockState(dockState);
			if (show)
			{
				content.DockHandler.Pane = this;
			}
			else if (IsFloat)
			{
				content.DockHandler.FloatPane = this;
			}
			else
			{
				content.DockHandler.PanelPane = this;
			}
			ResumeLayout();
			DockPanel.ResumeLayout(performLayout: true, allWindows: true);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				m_dockState = DockState.Unknown;
				if (NestedPanesContainer != null)
				{
					NestedPanesContainer.NestedPanes.Remove(this);
				}
				if (DockPanel != null)
				{
					DockPanel.RemovePane(this);
					m_dockPanel = null;
				}
				Splitter.Dispose();
				if (m_autoHidePane != null)
				{
					m_autoHidePane.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		internal void ShowTabPageContextMenu(Control control, Point position)
		{
			object tabPageContextMenu = TabPageContextMenu;
			if (tabPageContextMenu != null)
			{
				ContextMenuStrip contextMenuStrip = tabPageContextMenu as ContextMenuStrip;
				if (contextMenuStrip != null)
				{
					contextMenuStrip.Show(control, position);
				}
				else
				{
					(tabPageContextMenu as ContextMenu)?.Show(this, position);
				}
			}
		}

		internal void SetIsActivated(bool value)
		{
			if (m_isActivated != value)
			{
				m_isActivated = value;
				if (DockState != DockState.Document)
				{
					RefreshChanges(performLayout: false);
				}
				OnIsActivatedChanged(EventArgs.Empty);
			}
		}

		internal void SetIsActiveDocumentPane(bool value)
		{
			if (m_isActiveDocumentPane != value)
			{
				m_isActiveDocumentPane = value;
				if (DockState == DockState.Document)
				{
					RefreshChanges();
				}
				OnIsActiveDocumentPaneChanged(EventArgs.Empty);
			}
		}

		public bool IsDockStateValid(DockState dockState)
		{
			foreach (IDockContent content in Contents)
			{
				if (!content.DockHandler.IsDockStateValid(dockState))
				{
					return false;
				}
			}
			return true;
		}

		public void Activate()
		{
			if (DockHelper.IsDockStateAutoHide(DockState) && DockPanel.ActiveAutoHideContent != ActiveContent)
			{
				DockPanel.ActiveAutoHideContent = ActiveContent;
			}
			else if (!IsActivated && ActiveContent != null)
			{
				ActiveContent.DockHandler.Activate();
			}
		}

		internal void AddContent(IDockContent content)
		{
			if (!Contents.Contains(content))
			{
				Contents.Add(content);
			}
		}

		internal void Close()
		{
			Dispose();
		}

		public void CloseActiveContent()
		{
			CloseContent(ActiveContent);
		}

		internal void CloseContent(IDockContent content)
		{
			DockPanel dockPanel = DockPanel;
			dockPanel.SuspendLayout(allWindows: true);
			if (content != null && content.DockHandler.CloseButton)
			{
				if (content.DockHandler.HideOnClose)
				{
					content.DockHandler.Hide();
				}
				else
				{
					content.DockHandler.Close();
				}
				dockPanel.ResumeLayout(performLayout: true, allWindows: true);
			}
		}

		private HitTestResult GetHitTest(Point ptMouse)
		{
			Point pt = PointToClient(ptMouse);
			if (CaptionRectangle.Contains(pt))
			{
				return new HitTestResult(HitTestArea.Caption, -1);
			}
			if (ContentRectangle.Contains(pt))
			{
				return new HitTestResult(HitTestArea.Content, -1);
			}
			if (TabStripRectangle.Contains(pt))
			{
				return new HitTestResult(HitTestArea.TabStrip, TabStripControl.HitTest(TabStripControl.PointToClient(ptMouse)));
			}
			return new HitTestResult(HitTestArea.None, -1);
		}

		private void SetIsHidden(bool value)
		{
			if (m_isHidden != value)
			{
				m_isHidden = value;
				if (DockHelper.IsDockStateAutoHide(DockState))
				{
					DockPanel.RefreshAutoHideStrip();
					DockPanel.PerformLayout();
				}
				else if (NestedPanesContainer != null)
				{
					((Control)NestedPanesContainer).PerformLayout();
				}
			}
		}

		protected override void OnLayout(LayoutEventArgs levent)
		{
			SetIsHidden(DisplayingContents.Count == 0);
			if (!IsHidden)
			{
				CaptionControl.Bounds = CaptionRectangle;
				TabStripControl.Bounds = TabStripRectangle;
				SetContentBounds();
				foreach (IDockContent content in Contents)
				{
					if (DisplayingContents.Contains(content) && content.DockHandler.FlagClipWindow && content.DockHandler.Form.Visible)
					{
						content.DockHandler.FlagClipWindow = false;
					}
				}
			}
			base.OnLayout(levent);
		}

		internal void SetContentBounds()
		{
			Rectangle rectangle = ContentRectangle;
			if (DockState == DockState.Document && DockPanel.DocumentStyle == DocumentStyle.DockingMdi)
			{
				rectangle = DockPanel.RectangleToMdiClient(RectangleToScreen(rectangle));
			}
			Rectangle bounds = new Rectangle(-rectangle.Width, rectangle.Y, rectangle.Width, rectangle.Height);
			foreach (IDockContent content in Contents)
			{
				if (content.DockHandler.Pane == this)
				{
					if (content == ActiveContent)
					{
						content.DockHandler.Form.Bounds = rectangle;
					}
					else
					{
						content.DockHandler.Form.Bounds = bounds;
					}
				}
			}
		}

		internal void RefreshChanges()
		{
			RefreshChanges(performLayout: true);
		}

		private void RefreshChanges(bool performLayout)
		{
			if (!base.IsDisposed)
			{
				CaptionControl.RefreshChanges();
				TabStripControl.RefreshChanges();
				if (DockState == DockState.Float)
				{
					FloatWindow.RefreshChanges();
				}
				if (DockHelper.IsDockStateAutoHide(DockState) && DockPanel != null)
				{
					DockPanel.RefreshAutoHideStrip();
					DockPanel.PerformLayout();
				}
				if (performLayout)
				{
					PerformLayout();
				}
			}
		}

		internal void RemoveContent(IDockContent content)
		{
			if (Contents.Contains(content))
			{
				Contents.Remove(content);
			}
		}

		public void SetContentIndex(IDockContent content, int index)
		{
			int num = Contents.IndexOf(content);
			if (num == -1)
			{
				throw new ArgumentException(Strings.DockPane_SetContentIndex_InvalidContent);
			}
			if ((index < 0 || index > Contents.Count - 1) && index != -1)
			{
				throw new ArgumentOutOfRangeException(Strings.DockPane_SetContentIndex_InvalidIndex);
			}
			if (num != index && (num != Contents.Count - 1 || index != -1))
			{
				Contents.Remove(content);
				if (index == -1)
				{
					Contents.Add(content);
				}
				else if (num < index)
				{
					Contents.AddAt(content, index - 1);
				}
				else
				{
					Contents.AddAt(content, index);
				}
				RefreshChanges();
			}
		}

		private void SetParent()
		{
			if (DockState == DockState.Unknown || DockState == DockState.Hidden)
			{
				SetParent(null);
				Splitter.Parent = null;
			}
			else if (DockState == DockState.Float)
			{
				SetParent(FloatWindow);
				Splitter.Parent = FloatWindow;
			}
			else if (DockHelper.IsDockStateAutoHide(DockState))
			{
				SetParent(DockPanel.AutoHideControl);
				Splitter.Parent = null;
			}
			else
			{
				SetParent(DockPanel.DockWindows[DockState]);
				Splitter.Parent = base.Parent;
			}
		}

		private void SetParent(Control value)
		{
			if (base.Parent != value)
			{
				IDockContent focusedContent = GetFocusedContent();
				if (focusedContent != null)
				{
					DockPanel.SaveFocus();
				}
				base.Parent = value;
				focusedContent?.DockHandler.Activate();
			}
		}

		public new void Show()
		{
			Activate();
		}

		internal void TestDrop(IDockDragSource dragSource, DockOutlineBase dockOutline)
		{
			if (dragSource.CanDockTo(this))
			{
				Point mousePosition = Control.MousePosition;
				HitTestResult hitTest = GetHitTest(mousePosition);
				if (hitTest.HitArea == HitTestArea.Caption)
				{
					dockOutline.Show(this, -1);
				}
				else if (hitTest.HitArea == HitTestArea.TabStrip && hitTest.Index != -1)
				{
					dockOutline.Show(this, hitTest.Index);
				}
			}
		}

		internal void ValidateActiveContent()
		{
			if (ActiveContent == null)
			{
				if (DisplayingContents.Count != 0)
				{
					ActiveContent = DisplayingContents[0];
				}
			}
			else if (DisplayingContents.IndexOf(ActiveContent) < 0)
			{
				IDockContent dockContent = null;
				for (int num = Contents.IndexOf(ActiveContent) - 1; num >= 0; num--)
				{
					if (Contents[num].DockHandler.DockState == DockState)
					{
						dockContent = Contents[num];
						break;
					}
				}
				IDockContent dockContent2 = null;
				for (int num = Contents.IndexOf(ActiveContent) + 1; num < Contents.Count; num++)
				{
					if (Contents[num].DockHandler.DockState == DockState)
					{
						dockContent2 = Contents[num];
						break;
					}
				}
				if (dockContent != null)
				{
					ActiveContent = dockContent;
				}
				else if (dockContent2 != null)
				{
					ActiveContent = dockContent2;
				}
				else
				{
					ActiveContent = null;
				}
			}
		}

		protected virtual void OnDockStateChanged(EventArgs e)
		{
			((EventHandler)base.Events[DockStateChangedEvent])?.Invoke(this, e);
		}

		protected virtual void OnIsActivatedChanged(EventArgs e)
		{
			((EventHandler)base.Events[IsActivatedChangedEvent])?.Invoke(this, e);
		}

		protected virtual void OnIsActiveDocumentPaneChanged(EventArgs e)
		{
			((EventHandler)base.Events[IsActiveDocumentPaneChangedEvent])?.Invoke(this, e);
		}

		public DockPane SetDockState(DockState value)
		{
			if (value == DockState.Unknown || value == DockState.Hidden)
			{
				throw new InvalidOperationException(Strings.DockPane_SetDockState_InvalidState);
			}
			if (value == DockState.Float == IsFloat)
			{
				InternalSetDockState(value);
				return this;
			}
			if (DisplayingContents.Count == 0)
			{
				return null;
			}
			IDockContent dockContent = null;
			for (int i = 0; i < DisplayingContents.Count; i++)
			{
				IDockContent dockContent2 = DisplayingContents[i];
				if (dockContent2.DockHandler.IsDockStateValid(value))
				{
					dockContent = dockContent2;
					break;
				}
			}
			if (dockContent == null)
			{
				return null;
			}
			dockContent.DockHandler.DockState = value;
			DockPane pane = dockContent.DockHandler.Pane;
			DockPanel.SuspendLayout(allWindows: true);
			for (int i = 0; i < DisplayingContents.Count; i++)
			{
				IDockContent dockContent2 = DisplayingContents[i];
				if (dockContent2.DockHandler.IsDockStateValid(value))
				{
					dockContent2.DockHandler.Pane = pane;
				}
			}
			DockPanel.ResumeLayout(performLayout: true, allWindows: true);
			return pane;
		}

		private void InternalSetDockState(DockState value)
		{
			if (m_dockState != value)
			{
				DockState dockState = m_dockState;
				INestedPanesContainer nestedPanesContainer = NestedPanesContainer;
				m_dockState = value;
				SuspendRefreshStateChange();
				IDockContent focusedContent = GetFocusedContent();
				if (focusedContent != null)
				{
					DockPanel.SaveFocus();
				}
				if (!IsFloat)
				{
					DockWindow = DockPanel.DockWindows[DockState];
				}
				else if (FloatWindow == null)
				{
					FloatWindow = DockPanel.FloatWindowFactory.CreateFloatWindow(DockPanel, this);
				}
				if (focusedContent != null)
				{
					DockPanel.ContentFocusManager.Activate(focusedContent);
				}
				ResumeRefreshStateChange(nestedPanesContainer, dockState);
			}
		}

		private void SuspendRefreshStateChange()
		{
			m_countRefreshStateChange++;
			DockPanel.SuspendLayout(allWindows: true);
		}

		private void ResumeRefreshStateChange()
		{
			m_countRefreshStateChange--;
			Debug.Assert(m_countRefreshStateChange >= 0);
			DockPanel.ResumeLayout(performLayout: true, allWindows: true);
		}

		private void ResumeRefreshStateChange(INestedPanesContainer oldContainer, DockState oldDockState)
		{
			ResumeRefreshStateChange();
			RefreshStateChange(oldContainer, oldDockState);
		}

		private void RefreshStateChange(INestedPanesContainer oldContainer, DockState oldDockState)
		{
			lock (this)
			{
				if (IsRefreshStateChangeSuspended)
				{
					return;
				}
				SuspendRefreshStateChange();
			}
			DockPanel.SuspendLayout(allWindows: true);
			IDockContent focusedContent = GetFocusedContent();
			if (focusedContent != null)
			{
				DockPanel.SaveFocus();
			}
			SetParent();
			if (ActiveContent != null)
			{
				ActiveContent.DockHandler.SetDockState(ActiveContent.DockHandler.IsHidden, DockState, ActiveContent.DockHandler.Pane);
			}
			foreach (IDockContent content in Contents)
			{
				if (content.DockHandler.Pane == this)
				{
					content.DockHandler.SetDockState(content.DockHandler.IsHidden, DockState, content.DockHandler.Pane);
				}
			}
			if (oldContainer != null)
			{
				Control control = (Control)oldContainer;
				if (oldContainer.DockState == oldDockState && !control.IsDisposed)
				{
					control.PerformLayout();
				}
			}
			if (DockHelper.IsDockStateAutoHide(oldDockState))
			{
				DockPanel.RefreshActiveAutoHideContent();
			}
			if (NestedPanesContainer.DockState == DockState)
			{
				((Control)NestedPanesContainer).PerformLayout();
			}
			if (DockHelper.IsDockStateAutoHide(DockState))
			{
				DockPanel.RefreshActiveAutoHideContent();
			}
			if (DockHelper.IsDockStateAutoHide(oldDockState) || DockHelper.IsDockStateAutoHide(DockState))
			{
				DockPanel.RefreshAutoHideStrip();
				DockPanel.PerformLayout();
			}
			ResumeRefreshStateChange();
			focusedContent?.DockHandler.Activate();
			DockPanel.ResumeLayout(performLayout: true, allWindows: true);
			if (oldDockState != DockState)
			{
				OnDockStateChanged(EventArgs.Empty);
			}
		}

		private IDockContent GetFocusedContent()
		{
			IDockContent result = null;
			foreach (IDockContent content in Contents)
			{
				if (content.DockHandler.Form.ContainsFocus)
				{
					result = content;
					break;
				}
			}
			return result;
		}

		public DockPane DockTo(INestedPanesContainer container)
		{
			if (container == null)
			{
				throw new InvalidOperationException(Strings.DockPane_DockTo_NullContainer);
			}
			return DockTo(alignment: (container.DockState != DockState.DockLeft && container.DockState != DockState.DockRight) ? DockAlignment.Right : DockAlignment.Bottom, container: container, previousPane: container.NestedPanes.GetDefaultPreviousPane(this), proportion: 0.5);
		}

		public DockPane DockTo(INestedPanesContainer container, DockPane previousPane, DockAlignment alignment, double proportion)
		{
			if (container == null)
			{
				throw new InvalidOperationException(Strings.DockPane_DockTo_NullContainer);
			}
			if (container.IsFloat == IsFloat)
			{
				InternalAddToDockList(container, previousPane, alignment, proportion);
				return this;
			}
			IDockContent firstContent = GetFirstContent(container.DockState);
			if (firstContent == null)
			{
				return null;
			}
			DockPanel.DummyContent.DockPanel = DockPanel;
			DockPane dockPane = (!container.IsFloat) ? DockPanel.DockPaneFactory.CreateDockPane(DockPanel.DummyContent, container.DockState, show: true) : DockPanel.DockPaneFactory.CreateDockPane(DockPanel.DummyContent, (FloatWindow)container, show: true);
			dockPane.DockTo(container, previousPane, alignment, proportion);
			SetVisibleContentsToPane(dockPane);
			DockPanel.DummyContent.DockPanel = null;
			return dockPane;
		}

		private void SetVisibleContentsToPane(DockPane pane)
		{
			SetVisibleContentsToPane(pane, ActiveContent);
		}

		private void SetVisibleContentsToPane(DockPane pane, IDockContent activeContent)
		{
			for (int i = 0; i < DisplayingContents.Count; i++)
			{
				IDockContent dockContent = DisplayingContents[i];
				if (dockContent.DockHandler.IsDockStateValid(pane.DockState))
				{
					dockContent.DockHandler.Pane = pane;
					i--;
				}
			}
			if (activeContent.DockHandler.Pane == pane)
			{
				pane.ActiveContent = activeContent;
			}
		}

		private void InternalAddToDockList(INestedPanesContainer container, DockPane prevPane, DockAlignment alignment, double proportion)
		{
			if (container.DockState == DockState.Float != IsFloat)
			{
				throw new InvalidOperationException(Strings.DockPane_DockTo_InvalidContainer);
			}
			int num = container.NestedPanes.Count;
			if (container.NestedPanes.Contains(this))
			{
				num--;
			}
			if (prevPane == null && num > 0)
			{
				throw new InvalidOperationException(Strings.DockPane_DockTo_NullPrevPane);
			}
			if (prevPane != null && !container.NestedPanes.Contains(prevPane))
			{
				throw new InvalidOperationException(Strings.DockPane_DockTo_NoPrevPane);
			}
			if (prevPane == this)
			{
				throw new InvalidOperationException(Strings.DockPane_DockTo_SelfPrevPane);
			}
			INestedPanesContainer nestedPanesContainer = NestedPanesContainer;
			DockState dockState = DockState;
			container.NestedPanes.Add(this);
			NestedDockingStatus.SetStatus(container.NestedPanes, prevPane, alignment, proportion);
			if (DockHelper.IsDockWindowState(DockState))
			{
				m_dockState = container.DockState;
			}
			RefreshStateChange(nestedPanesContainer, dockState);
		}

		public void SetNestedDockingProportion(double proportion)
		{
			NestedDockingStatus.SetStatus(NestedDockingStatus.NestedPanes, NestedDockingStatus.PreviousPane, NestedDockingStatus.Alignment, proportion);
			if (NestedPanesContainer != null)
			{
				((Control)NestedPanesContainer).PerformLayout();
			}
		}

		public DockPane Float()
		{
			DockPanel.SuspendLayout(allWindows: true);
			IDockContent activeContent = ActiveContent;
			DockPane dockPane = GetFloatPaneFromContents();
			if (dockPane == null)
			{
				IDockContent firstContent = GetFirstContent(DockState.Float);
				if (firstContent == null)
				{
					DockPanel.ResumeLayout(performLayout: true, allWindows: true);
					return null;
				}
				dockPane = DockPanel.DockPaneFactory.CreateDockPane(firstContent, DockState.Float, show: true);
			}
			SetVisibleContentsToPane(dockPane, activeContent);
			DockPanel.ResumeLayout(performLayout: true, allWindows: true);
			return dockPane;
		}

		private DockPane GetFloatPaneFromContents()
		{
			DockPane dockPane = null;
			for (int i = 0; i < DisplayingContents.Count; i++)
			{
				IDockContent dockContent = DisplayingContents[i];
				if (dockContent.DockHandler.IsDockStateValid(DockState.Float))
				{
					if (dockPane != null && dockContent.DockHandler.FloatPane != dockPane)
					{
						return null;
					}
					dockPane = dockContent.DockHandler.FloatPane;
				}
			}
			return dockPane;
		}

		private IDockContent GetFirstContent(DockState dockState)
		{
			for (int i = 0; i < DisplayingContents.Count; i++)
			{
				IDockContent dockContent = DisplayingContents[i];
				if (dockContent.DockHandler.IsDockStateValid(dockState))
				{
					return dockContent;
				}
			}
			return null;
		}

		public void RestoreToPanel()
		{
			DockPanel.SuspendLayout(allWindows: true);
			IDockContent activeContent = DockPanel.ActiveContent;
			for (int num = DisplayingContents.Count - 1; num >= 0; num--)
			{
				IDockContent dockContent = DisplayingContents[num];
				if (dockContent.DockHandler.CheckDockState(isFloat: false) != 0)
				{
					dockContent.DockHandler.IsFloat = false;
				}
			}
			DockPanel.ResumeLayout(performLayout: true, allWindows: true);
		}

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 33)
			{
				Activate();
			}
			base.WndProc(ref m);
		}

		bool IDockDragSource.IsDockStateValid(DockState dockState)
		{
			return IsDockStateValid(dockState);
		}

		bool IDockDragSource.CanDockTo(DockPane pane)
		{
			if (!IsDockStateValid(pane.DockState))
			{
				return false;
			}
			if (pane == this)
			{
				return false;
			}
			return true;
		}

		Rectangle IDockDragSource.BeginDrag(Point ptMouse)
		{
			Point location = PointToScreen(new Point(0, 0));
			DockPane floatPane = ActiveContent.DockHandler.FloatPane;
			Size size = (DockState != DockState.Float && floatPane != null && floatPane.FloatWindow.NestedPanes.Count == 1) ? floatPane.FloatWindow.Size : DockPanel.DefaultFloatWindowSize;
			if (ptMouse.X > location.X + size.Width)
			{
				location.X += ptMouse.X - (location.X + size.Width) + 4;
			}
			return new Rectangle(location, size);
		}

		public void FloatAt(Rectangle floatWindowBounds)
		{
			if (FloatWindow == null || FloatWindow.NestedPanes.Count != 1)
			{
				FloatWindow = DockPanel.FloatWindowFactory.CreateFloatWindow(DockPanel, this, floatWindowBounds);
			}
			else
			{
				FloatWindow.Bounds = floatWindowBounds;
			}
			DockState = DockState.Float;
		}

		public void DockTo(DockPane pane, DockStyle dockStyle, int contentIndex)
		{
			switch (dockStyle)
			{
			case DockStyle.Fill:
			{
				IDockContent activeContent = ActiveContent;
				for (int num = Contents.Count - 1; num >= 0; num--)
				{
					IDockContent dockContent = Contents[num];
					if (dockContent.DockHandler.DockState == DockState)
					{
						dockContent.DockHandler.Pane = pane;
						if (contentIndex != -1)
						{
							pane.SetContentIndex(dockContent, contentIndex);
						}
					}
				}
				pane.ActiveContent = activeContent;
				return;
			}
			case DockStyle.Left:
				DockTo(pane.NestedPanesContainer, pane, DockAlignment.Left, 0.5);
				break;
			case DockStyle.Right:
				DockTo(pane.NestedPanesContainer, pane, DockAlignment.Right, 0.5);
				break;
			case DockStyle.Top:
				DockTo(pane.NestedPanesContainer, pane, DockAlignment.Top, 0.5);
				break;
			case DockStyle.Bottom:
				DockTo(pane.NestedPanesContainer, pane, DockAlignment.Bottom, 0.5);
				break;
			}
			DockState = pane.DockState;
		}

		public void DockTo(DockPanel panel, DockStyle dockStyle)
		{
			if (panel != DockPanel)
			{
				throw new ArgumentException(Strings.IDockDragSource_DockTo_InvalidPanel, "panel");
			}
			switch (dockStyle)
			{
			case DockStyle.Top:
				DockState = DockState.DockTop;
				break;
			case DockStyle.Bottom:
				DockState = DockState.DockBottom;
				break;
			case DockStyle.Left:
				DockState = DockState.DockLeft;
				break;
			case DockStyle.Right:
				DockState = DockState.DockRight;
				break;
			case DockStyle.Fill:
				DockState = DockState.Document;
				break;
			}
		}
	}
}
