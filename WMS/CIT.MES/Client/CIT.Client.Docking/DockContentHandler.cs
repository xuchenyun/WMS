using CIT.Client.Docking.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client.Docking
{
	public class DockContentHandler : IDisposable, IDockDragSource, IDragSource
	{
		private Form m_form;

		private IDockContent m_previousActive = null;

		private IDockContent m_nextActive = null;

		private EventHandlerList m_events;

		private bool m_allowEndUserDocking = true;

		private double m_autoHidePortion = 0.25;

		private bool m_closeButton = true;

		private bool m_closeButtonVisible = true;

		private DockAreas m_allowedAreas = DockAreas.Float | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.DockBottom | DockAreas.Document;

		private DockState m_dockState = DockState.Unknown;

		private DockPanel m_dockPanel = null;

		private bool m_isHidden = true;

		private string m_tabText = null;

		private DockState m_visibleState = DockState.Unknown;

		private bool m_isFloat = false;

		private DockPane m_panelPane = null;

		private DockPane m_floatPane = null;

		private int m_countSetDockState = 0;

		private GetPersistStringCallback m_getPersistStringCallback = null;

		private bool m_hideOnClose = false;

		private DockState m_showHint = DockState.Unknown;

		private bool m_isActivated = false;

		private ContextMenu m_tabPageContextMenu = null;

		private string m_toolTipText = null;

		private IntPtr m_activeWindowHandle = IntPtr.Zero;

		private DockPaneStripBase.Tab m_tab = null;

		private IDisposable m_autoHideTab = null;

		private static readonly object DockStateChangedEvent = new object();

		private bool m_flagClipWindow = false;

		private ContextMenuStrip m_tabPageContextMenuStrip = null;

		public Form Form => m_form;

		public IDockContent Content => Form as IDockContent;

		public IDockContent PreviousActive
		{
			get
			{
				return m_previousActive;
			}
			internal set
			{
				m_previousActive = value;
			}
		}

		public IDockContent NextActive
		{
			get
			{
				return m_nextActive;
			}
			internal set
			{
				m_nextActive = value;
			}
		}

		private EventHandlerList Events => m_events;

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

		public double AutoHidePortion
		{
			get
			{
				return m_autoHidePortion;
			}
			set
			{
				if (value <= 0.0)
				{
					throw new ArgumentOutOfRangeException(Strings.DockContentHandler_AutoHidePortion_OutOfRange);
				}
				if (m_autoHidePortion != value)
				{
					m_autoHidePortion = value;
					if (DockPanel != null && DockPanel.ActiveAutoHideContent == Content)
					{
						DockPanel.PerformLayout();
					}
				}
			}
		}

		public bool CloseButton
		{
			get
			{
				return m_closeButton;
			}
			set
			{
				if (m_closeButton != value)
				{
					m_closeButton = value;
					if (Pane != null && Pane.ActiveContent.DockHandler == this)
					{
						Pane.RefreshChanges();
					}
				}
			}
		}

		public bool CloseButtonVisible
		{
			get
			{
				return m_closeButtonVisible;
			}
			set
			{
				m_closeButtonVisible = value;
			}
		}

		private DockState DefaultDockState
		{
			get
			{
				if (ShowHint != 0 && ShowHint != DockState.Hidden)
				{
					return ShowHint;
				}
				if ((DockAreas & DockAreas.Document) != 0)
				{
					return DockState.Document;
				}
				if ((DockAreas & DockAreas.DockRight) != 0)
				{
					return DockState.DockRight;
				}
				if ((DockAreas & DockAreas.DockLeft) != 0)
				{
					return DockState.DockLeft;
				}
				if ((DockAreas & DockAreas.DockBottom) != 0)
				{
					return DockState.DockBottom;
				}
				if ((DockAreas & DockAreas.DockTop) != 0)
				{
					return DockState.DockTop;
				}
				return DockState.Unknown;
			}
		}

		private DockState DefaultShowState
		{
			get
			{
				if (ShowHint != 0)
				{
					return ShowHint;
				}
				if ((DockAreas & DockAreas.Document) != 0)
				{
					return DockState.Document;
				}
				if ((DockAreas & DockAreas.DockRight) != 0)
				{
					return DockState.DockRight;
				}
				if ((DockAreas & DockAreas.DockLeft) != 0)
				{
					return DockState.DockLeft;
				}
				if ((DockAreas & DockAreas.DockBottom) != 0)
				{
					return DockState.DockBottom;
				}
				if ((DockAreas & DockAreas.DockTop) != 0)
				{
					return DockState.DockTop;
				}
				if ((DockAreas & DockAreas.Float) != 0)
				{
					return DockState.Float;
				}
				return DockState.Unknown;
			}
		}

		public DockAreas DockAreas
		{
			get
			{
				return m_allowedAreas;
			}
			set
			{
				if (m_allowedAreas != value)
				{
					if (!DockHelper.IsDockStateValid(DockState, value))
					{
						throw new InvalidOperationException(Strings.DockContentHandler_DockAreas_InvalidValue);
					}
					m_allowedAreas = value;
					if (!DockHelper.IsDockStateValid(ShowHint, m_allowedAreas))
					{
						ShowHint = DockState.Unknown;
					}
				}
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
				if (m_dockState != value)
				{
					DockPanel.SuspendLayout(allWindows: true);
					if (value == DockState.Hidden)
					{
						IsHidden = true;
					}
					else
					{
						SetDockState(isHidden: false, value, Pane);
					}
					DockPanel.ResumeLayout(performLayout: true, allWindows: true);
				}
			}
		}

		public DockPanel DockPanel
		{
			get
			{
				return m_dockPanel;
			}
			set
			{
				if (m_dockPanel != value)
				{
					Pane = null;
					if (m_dockPanel != null)
					{
						m_dockPanel.RemoveContent(Content);
					}
					if (m_tab != null)
					{
						m_tab.Dispose();
						m_tab = null;
					}
					if (m_autoHideTab != null)
					{
						m_autoHideTab.Dispose();
						m_autoHideTab = null;
					}
					m_dockPanel = value;
					if (m_dockPanel != null)
					{
						m_dockPanel.AddContent(Content);
						Form.TopLevel = false;
						Form.FormBorderStyle = FormBorderStyle.None;
						Form.ShowInTaskbar = false;
						Form.WindowState = FormWindowState.Normal;
						NativeMethods.SetWindowPos(Form.Handle, IntPtr.Zero, 0, 0, 0, 0, FlagsSetWindowPos.SWP_NOSIZE | FlagsSetWindowPos.SWP_NOMOVE | FlagsSetWindowPos.SWP_NOZORDER | FlagsSetWindowPos.SWP_NOACTIVATE | FlagsSetWindowPos.SWP_FRAMECHANGED | FlagsSetWindowPos.SWP_NOOWNERZORDER);
					}
				}
			}
		}

		public Icon Icon => Form.Icon;

		public DockPane Pane
		{
			get
			{
				return IsFloat ? FloatPane : PanelPane;
			}
			set
			{
				if (Pane != value)
				{
					DockPanel.SuspendLayout(allWindows: true);
					DockPane pane = Pane;
					SuspendSetDockState();
					FloatPane = ((value == null) ? null : (value.IsFloat ? value : FloatPane));
					PanelPane = ((value == null) ? null : (value.IsFloat ? PanelPane : value));
					ResumeSetDockState(IsHidden, value?.DockState ?? DockState.Unknown, pane);
					DockPanel.ResumeLayout(performLayout: true, allWindows: true);
				}
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
				if (m_isHidden != value)
				{
					SetDockState(value, VisibleState, Pane);
				}
			}
		}

		public string TabText
		{
			get
			{
				return (m_tabText == null || m_tabText == "") ? Form.Text : m_tabText;
			}
			set
			{
				if (!(m_tabText == value))
				{
					m_tabText = value;
					if (Pane != null)
					{
						Pane.RefreshChanges();
					}
				}
			}
		}

		public DockState VisibleState
		{
			get
			{
				return m_visibleState;
			}
			set
			{
				if (m_visibleState != value)
				{
					SetDockState(IsHidden, value, Pane);
				}
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
				if (m_isFloat != value)
				{
					DockState dockState = CheckDockState(value);
					if (dockState == DockState.Unknown)
					{
						throw new InvalidOperationException(Strings.DockContentHandler_IsFloat_InvalidValue);
					}
					SetDockState(IsHidden, dockState, Pane);
				}
			}
		}

		public DockPane PanelPane
		{
			get
			{
				return m_panelPane;
			}
			set
			{
				if (m_panelPane != value)
				{
					if (value != null && (value.IsFloat || value.DockPanel != DockPanel))
					{
						throw new InvalidOperationException(Strings.DockContentHandler_DockPane_InvalidValue);
					}
					DockPane pane = Pane;
					if (m_panelPane != null)
					{
						RemoveFromPane(m_panelPane);
					}
					m_panelPane = value;
					if (m_panelPane != null)
					{
						m_panelPane.AddContent(Content);
						SetDockState(IsHidden, IsFloat ? DockState.Float : m_panelPane.DockState, pane);
					}
					else
					{
						SetDockState(IsHidden, DockState.Unknown, pane);
					}
				}
			}
		}

		public DockPane FloatPane
		{
			get
			{
				return m_floatPane;
			}
			set
			{
				if (m_floatPane != value)
				{
					if (value != null && (!value.IsFloat || value.DockPanel != DockPanel))
					{
						throw new InvalidOperationException(Strings.DockContentHandler_FloatPane_InvalidValue);
					}
					DockPane pane = Pane;
					if (m_floatPane != null)
					{
						RemoveFromPane(m_floatPane);
					}
					m_floatPane = value;
					if (m_floatPane != null)
					{
						m_floatPane.AddContent(Content);
						SetDockState(IsHidden, IsFloat ? DockState.Float : VisibleState, pane);
					}
					else
					{
						SetDockState(IsHidden, DockState.Unknown, pane);
					}
				}
			}
		}

		internal bool IsSuspendSetDockState => m_countSetDockState != 0;

		internal string PersistString => (GetPersistStringCallback == null) ? Form.GetType().ToString() : GetPersistStringCallback();

		public GetPersistStringCallback GetPersistStringCallback
		{
			get
			{
				return m_getPersistStringCallback;
			}
			set
			{
				m_getPersistStringCallback = value;
			}
		}

		public bool HideOnClose
		{
			get
			{
				return m_hideOnClose;
			}
			set
			{
				m_hideOnClose = value;
			}
		}

		public DockState ShowHint
		{
			get
			{
				return m_showHint;
			}
			set
			{
				if (!DockHelper.IsDockStateValid(value, DockAreas))
				{
					throw new InvalidOperationException(Strings.DockContentHandler_ShowHint_InvalidValue);
				}
				if (m_showHint != value)
				{
					m_showHint = value;
				}
			}
		}

		public bool IsActivated
		{
			get
			{
				return m_isActivated;
			}
			internal set
			{
				if (m_isActivated != value)
				{
					m_isActivated = value;
				}
			}
		}

		public ContextMenu TabPageContextMenu
		{
			get
			{
				return m_tabPageContextMenu;
			}
			set
			{
				m_tabPageContextMenu = value;
			}
		}

		public string ToolTipText
		{
			get
			{
				return m_toolTipText;
			}
			set
			{
				m_toolTipText = value;
			}
		}

		internal IntPtr ActiveWindowHandle
		{
			get
			{
				return m_activeWindowHandle;
			}
			set
			{
				m_activeWindowHandle = value;
			}
		}

		internal IDisposable AutoHideTab
		{
			get
			{
				return m_autoHideTab;
			}
			set
			{
				m_autoHideTab = value;
			}
		}

		internal bool FlagClipWindow
		{
			get
			{
				return m_flagClipWindow;
			}
			set
			{
				if (m_flagClipWindow != value)
				{
					m_flagClipWindow = value;
					if (m_flagClipWindow)
					{
						Form.Region = new Region(Rectangle.Empty);
					}
					else
					{
						Form.Region = null;
					}
				}
			}
		}

		public ContextMenuStrip TabPageContextMenuStrip
		{
			get
			{
				return m_tabPageContextMenuStrip;
			}
			set
			{
				m_tabPageContextMenuStrip = value;
			}
		}

		Control IDragSource.DragControl
		{
			get
			{
				return Form;
			}
		}

		public event EventHandler DockStateChanged
		{
			add
			{
				Events.AddHandler(DockStateChangedEvent, value);
			}
			remove
			{
				Events.RemoveHandler(DockStateChangedEvent, value);
			}
		}

		public DockContentHandler(Form form)
			: this(form, null)
		{
		}

		public DockContentHandler(Form form, GetPersistStringCallback getPersistStringCallback)
		{
			if (!(form is IDockContent))
			{
				throw new ArgumentException(Strings.DockContent_Constructor_InvalidForm, "form");
			}
			m_form = form;
			m_getPersistStringCallback = getPersistStringCallback;
			m_events = new EventHandlerList();
			Form.Disposed += Form_Disposed;
			Form.TextChanged += Form_TextChanged;
		}

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
					DockPanel = null;
					if (m_autoHideTab != null)
					{
						m_autoHideTab.Dispose();
					}
					if (m_tab != null)
					{
						m_tab.Dispose();
					}
					Form.Disposed -= Form_Disposed;
					Form.TextChanged -= Form_TextChanged;
					m_events.Dispose();
				}
			}
		}

		public DockState CheckDockState(bool isFloat)
		{
			DockState dockState;
			if (isFloat)
			{
				dockState = (IsDockStateValid(DockState.Float) ? DockState.Float : DockState.Unknown);
			}
			else
			{
				dockState = ((PanelPane != null) ? PanelPane.DockState : DefaultDockState);
				if (dockState != 0 && !IsDockStateValid(dockState))
				{
					dockState = DockState.Unknown;
				}
			}
			return dockState;
		}

		private void RemoveFromPane(DockPane pane)
		{
			pane.RemoveContent(Content);
			SetPane(null);
			if (pane.Contents.Count == 0)
			{
				pane.Dispose();
			}
		}

		private void SuspendSetDockState()
		{
			m_countSetDockState++;
		}

		private void ResumeSetDockState()
		{
			m_countSetDockState--;
			if (m_countSetDockState < 0)
			{
				m_countSetDockState = 0;
			}
		}

		private void ResumeSetDockState(bool isHidden, DockState visibleState, DockPane oldPane)
		{
			ResumeSetDockState();
			SetDockState(isHidden, visibleState, oldPane);
		}

		internal void SetDockState(bool isHidden, DockState visibleState, DockPane oldPane)
		{
			if (!IsSuspendSetDockState)
			{
				if (DockPanel == null && visibleState != 0)
				{
					throw new InvalidOperationException(Strings.DockContentHandler_SetDockState_NullPanel);
				}
				int num;
				switch (visibleState)
				{
				default:
					num = (IsDockStateValid(visibleState) ? 1 : 0);
					break;
				case DockState.Unknown:
					num = 1;
					break;
				case DockState.Hidden:
					num = 0;
					break;
				}
				if (num == 0)
				{
					throw new InvalidOperationException(Strings.DockContentHandler_SetDockState_InvalidState);
				}
				DockPanel dockPanel = DockPanel;
				dockPanel?.SuspendLayout(allWindows: true);
				SuspendSetDockState();
				DockState dockState = DockState;
				if (m_isHidden != isHidden || dockState == DockState.Unknown)
				{
					m_isHidden = isHidden;
				}
				m_visibleState = visibleState;
				m_dockState = (isHidden ? DockState.Hidden : visibleState);
				if (visibleState == DockState.Unknown)
				{
					Pane = null;
				}
				else
				{
					m_isFloat = (m_visibleState == DockState.Float);
					if (Pane == null)
					{
						Pane = DockPanel.DockPaneFactory.CreateDockPane(Content, visibleState, show: true);
					}
					else if (Pane.DockState != visibleState)
					{
						if (Pane.Contents.Count == 1)
						{
							Pane.SetDockState(visibleState);
						}
						else
						{
							Pane = DockPanel.DockPaneFactory.CreateDockPane(Content, visibleState, show: true);
						}
					}
				}
				if (Form.ContainsFocus && (DockState == DockState.Hidden || DockState == DockState.Unknown))
				{
					DockPanel.ContentFocusManager.GiveUpFocus(Content);
				}
				SetPaneAndVisible(Pane);
				if (oldPane != null && !oldPane.IsDisposed && dockState == oldPane.DockState)
				{
					RefreshDockPane(oldPane);
				}
				if (Pane != null && DockState == Pane.DockState && (Pane != oldPane || (Pane == oldPane && dockState != oldPane.DockState)) && (Pane.DockWindow == null || Pane.DockWindow.Visible || Pane.IsHidden) && !Pane.IsAutoHide)
				{
					RefreshDockPane(Pane);
				}
				if (dockState != DockState)
				{
					if (DockState == DockState.Hidden || DockState == DockState.Unknown || DockHelper.IsDockStateAutoHide(DockState))
					{
						DockPanel.ContentFocusManager.RemoveFromList(Content);
					}
					else
					{
						DockPanel.ContentFocusManager.AddToList(Content);
					}
					OnDockStateChanged(EventArgs.Empty);
				}
				ResumeSetDockState();
				dockPanel?.ResumeLayout(performLayout: true, allWindows: true);
			}
		}

		private static void RefreshDockPane(DockPane pane)
		{
			pane.RefreshChanges();
			pane.ValidateActiveContent();
		}

		public bool IsDockStateValid(DockState dockState)
		{
			if (DockPanel != null && dockState == DockState.Document && DockPanel.DocumentStyle == DocumentStyle.SystemMdi)
			{
				return false;
			}
			return DockHelper.IsDockStateValid(dockState, DockAreas);
		}

		public void Activate()
		{
			if (DockPanel == null)
			{
				Form.Activate();
			}
			else if (Pane == null)
			{
				Show(DockPanel);
			}
			else
			{
				IsHidden = false;
				Pane.ActiveContent = Content;
				if (DockState == DockState.Document && DockPanel.DocumentStyle == DocumentStyle.SystemMdi)
				{
					Form.Activate();
				}
				else
				{
					if (DockHelper.IsDockStateAutoHide(DockState))
					{
						DockPanel.ActiveAutoHideContent = Content;
					}
					if (!Form.ContainsFocus)
					{
						DockPanel.ContentFocusManager.Activate(Content);
					}
				}
			}
		}

		public void GiveUpFocus()
		{
			DockPanel.ContentFocusManager.GiveUpFocus(Content);
		}

		public void Hide()
		{
			IsHidden = true;
		}

		internal void SetPaneAndVisible(DockPane pane)
		{
			SetPane(pane);
			SetVisible();
		}

		private void SetPane(DockPane pane)
		{
			if (pane != null && pane.DockState == DockState.Document && DockPanel.DocumentStyle == DocumentStyle.DockingMdi)
			{
				if (Form.Parent is DockPane)
				{
					SetParent(null);
				}
				if (Form.MdiParent != DockPanel.ParentForm)
				{
					FlagClipWindow = true;
					Form.MdiParent = DockPanel.ParentForm;
				}
			}
			else
			{
				FlagClipWindow = true;
				if (Form.MdiParent != null)
				{
					Form.MdiParent = null;
				}
				if (Form.TopLevel)
				{
					Form.TopLevel = false;
				}
				SetParent(pane);
			}
		}

		internal void SetVisible()
		{
			bool flag = !IsHidden && ((Pane != null && Pane.DockState == DockState.Document && DockPanel.DocumentStyle == DocumentStyle.DockingMdi) || (Pane != null && Pane.ActiveContent == Content) || ((Pane == null || Pane.ActiveContent == Content) && Form.Visible));
			if (Form.Visible != flag)
			{
				Form.Visible = flag;
			}
		}

		private void SetParent(Control value)
		{
			if (Form.Parent != value)
			{
				bool flag = false;
				if (Form.ContainsFocus)
				{
					if (value == null && !IsFloat)
					{
						DockPanel.ContentFocusManager.GiveUpFocus(Content);
					}
					else
					{
						DockPanel.SaveFocus();
						flag = true;
					}
				}
				Form.Parent = value;
				if (flag)
				{
					Activate();
				}
			}
		}

		public void Show()
		{
			if (DockPanel == null)
			{
				Form.Show();
			}
			else
			{
				Show(DockPanel);
			}
		}

		public void Show(DockPanel dockPanel)
		{
			if (dockPanel == null)
			{
				throw new ArgumentNullException(Strings.DockContentHandler_Show_NullDockPanel);
			}
			if (DockState == DockState.Unknown)
			{
				Show(dockPanel, DefaultShowState);
			}
			else
			{
				Activate();
			}
		}

		public void Show(DockPanel dockPanel, DockState dockState)
		{
			if (dockPanel == null)
			{
				throw new ArgumentNullException(Strings.DockContentHandler_Show_NullDockPanel);
			}
			if (dockState == DockState.Unknown || dockState == DockState.Hidden)
			{
				throw new ArgumentException(Strings.DockContentHandler_Show_InvalidDockState);
			}
			dockPanel.SuspendLayout(allWindows: true);
			DockPanel = dockPanel;
			if (dockState == DockState.Float && FloatPane == null)
			{
				Pane = DockPanel.DockPaneFactory.CreateDockPane(Content, DockState.Float, show: true);
			}
			else if (PanelPane == null)
			{
				DockPane dockPane = null;
				foreach (DockPane pane in DockPanel.Panes)
				{
					if (pane.DockState == dockState)
					{
						dockPane = pane;
						break;
					}
				}
				if (dockPane == null)
				{
					Pane = DockPanel.DockPaneFactory.CreateDockPane(Content, dockState, show: true);
				}
				else
				{
					Pane = dockPane;
				}
			}
			DockState = dockState;
			dockPanel.ResumeLayout(performLayout: true, allWindows: true);
			Activate();
		}

		public void Show(DockPanel dockPanel, Rectangle floatWindowBounds)
		{
			if (dockPanel == null)
			{
				throw new ArgumentNullException(Strings.DockContentHandler_Show_NullDockPanel);
			}
			dockPanel.SuspendLayout(allWindows: true);
			DockPanel = dockPanel;
			if (FloatPane == null)
			{
				IsHidden = true;
				FloatPane = DockPanel.DockPaneFactory.CreateDockPane(Content, DockState.Float, show: false);
				FloatPane.FloatWindow.StartPosition = FormStartPosition.Manual;
			}
			FloatPane.FloatWindow.Bounds = floatWindowBounds;
			Show(dockPanel, DockState.Float);
			Activate();
			dockPanel.ResumeLayout(performLayout: true, allWindows: true);
		}

		public void Show(DockPane pane, IDockContent beforeContent)
		{
			if (pane == null)
			{
				throw new ArgumentNullException(Strings.DockContentHandler_Show_NullPane);
			}
			if (beforeContent != null && pane.Contents.IndexOf(beforeContent) == -1)
			{
				throw new ArgumentException(Strings.DockContentHandler_Show_InvalidBeforeContent);
			}
			pane.DockPanel.SuspendLayout(allWindows: true);
			DockPanel = pane.DockPanel;
			Pane = pane;
			pane.SetContentIndex(Content, pane.Contents.IndexOf(beforeContent));
			Show();
			pane.DockPanel.ResumeLayout(performLayout: true, allWindows: true);
		}

		public void Show(DockPane previousPane, DockAlignment alignment, double proportion)
		{
			if (previousPane == null)
			{
				throw new ArgumentException(Strings.DockContentHandler_Show_InvalidPrevPane);
			}
			if (DockHelper.IsDockStateAutoHide(previousPane.DockState))
			{
				throw new ArgumentException(Strings.DockContentHandler_Show_InvalidPrevPane);
			}
			previousPane.DockPanel.SuspendLayout(allWindows: true);
			DockPanel = previousPane.DockPanel;
			DockPanel.DockPaneFactory.CreateDockPane(Content, previousPane, alignment, proportion, show: true);
			Show();
			previousPane.DockPanel.ResumeLayout(performLayout: true, allWindows: true);
		}

		public void Close()
		{
			DockPanel dockPanel = DockPanel;
			dockPanel?.SuspendLayout(allWindows: true);
			Form.Close();
			dockPanel?.ResumeLayout(performLayout: true, allWindows: true);
		}

		internal DockPaneStripBase.Tab GetTab(DockPaneStripBase dockPaneStrip)
		{
			if (m_tab == null)
			{
				m_tab = dockPaneStrip.CreateTab(Content);
			}
			return m_tab;
		}

		protected virtual void OnDockStateChanged(EventArgs e)
		{
			((EventHandler)Events[DockStateChangedEvent])?.Invoke(this, e);
		}

		private void Form_Disposed(object sender, EventArgs e)
		{
			Dispose();
		}

		private void Form_TextChanged(object sender, EventArgs e)
		{
			if (DockHelper.IsDockStateAutoHide(DockState))
			{
				DockPanel.RefreshAutoHideStrip();
			}
			else if (Pane != null)
			{
				if (Pane.FloatWindow != null)
				{
					Pane.FloatWindow.SetText();
				}
				Pane.RefreshChanges();
			}
		}

		bool IDockDragSource.CanDockTo(DockPane pane)
		{
			if (!IsDockStateValid(pane.DockState))
			{
				return false;
			}
			if (Pane == pane && pane.DisplayingContents.Count == 1)
			{
				return false;
			}
			return true;
		}

		Rectangle IDockDragSource.BeginDrag(Point ptMouse)
		{
			DockPane floatPane = FloatPane;
			Size size = (DockState != DockState.Float && floatPane != null && floatPane.FloatWindow.NestedPanes.Count == 1) ? floatPane.FloatWindow.Size : DockPanel.DefaultFloatWindowSize;
			Rectangle clientRectangle = Pane.ClientRectangle;
			Point p;
			if (DockState == DockState.Document)
			{
				p = ((Pane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom) ? new Point(clientRectangle.Left, clientRectangle.Bottom - size.Height) : new Point(clientRectangle.Left, clientRectangle.Top));
			}
			else
			{
				p = new Point(clientRectangle.Left, clientRectangle.Bottom);
				p.Y -= size.Height;
			}
			p = Pane.PointToScreen(p);
			if (ptMouse.X > p.X + size.Width)
			{
				p.X += ptMouse.X - (p.X + size.Width) + 4;
			}
			return new Rectangle(p, size);
		}

		public void FloatAt(Rectangle floatWindowBounds)
		{
			DockPane dockPane = DockPanel.DockPaneFactory.CreateDockPane(Content, floatWindowBounds, show: true);
		}

		public void DockTo(DockPane pane, DockStyle dockStyle, int contentIndex)
		{
			if (dockStyle == DockStyle.Fill)
			{
				bool flag = Pane == pane;
				if (!flag)
				{
					Pane = pane;
				}
				if (contentIndex == -1 || !flag)
				{
					pane.SetContentIndex(Content, contentIndex);
				}
				else
				{
					DockContentCollection contents = pane.Contents;
					int num = contents.IndexOf(Content);
					int num2 = contentIndex;
					if (num < num2)
					{
						num2++;
						if (num2 > contents.Count - 1)
						{
							num2 = -1;
						}
					}
					pane.SetContentIndex(Content, num2);
				}
			}
			else
			{
				DockPane dockPane = DockPanel.DockPaneFactory.CreateDockPane(Content, pane.DockState, show: true);
				INestedPanesContainer nestedPanesContainer = pane.NestedPanesContainer;
				switch (dockStyle)
				{
				case DockStyle.Left:
					dockPane.DockTo(nestedPanesContainer, pane, DockAlignment.Left, 0.5);
					break;
				case DockStyle.Right:
					dockPane.DockTo(nestedPanesContainer, pane, DockAlignment.Right, 0.5);
					break;
				case DockStyle.Top:
					dockPane.DockTo(nestedPanesContainer, pane, DockAlignment.Top, 0.5);
					break;
				case DockStyle.Bottom:
					dockPane.DockTo(nestedPanesContainer, pane, DockAlignment.Bottom, 0.5);
					break;
				}
				dockPane.DockState = pane.DockState;
			}
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
			{
				DockPane dockPane = DockPanel.DockPaneFactory.CreateDockPane(Content, DockState.DockTop, show: true);
				break;
			}
			case DockStyle.Bottom:
			{
				DockPane dockPane = DockPanel.DockPaneFactory.CreateDockPane(Content, DockState.DockBottom, show: true);
				break;
			}
			case DockStyle.Left:
			{
				DockPane dockPane = DockPanel.DockPaneFactory.CreateDockPane(Content, DockState.DockLeft, show: true);
				break;
			}
			case DockStyle.Right:
			{
				DockPane dockPane = DockPanel.DockPaneFactory.CreateDockPane(Content, DockState.DockRight, show: true);
				break;
			}
			case DockStyle.Fill:
			{
				DockPane dockPane = DockPanel.DockPaneFactory.CreateDockPane(Content, DockState.Document, show: true);
				break;
			}
			}
		}
	}
}
