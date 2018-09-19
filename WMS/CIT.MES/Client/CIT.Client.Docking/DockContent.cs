using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client.Docking
{
	public class DockContent : Form, IDockContent
	{
		private DockContentHandler m_dockHandler = null;

		[DefaultValue(null)]
		[LocalizedCategory("Category_Docking")]
		[LocalizedDescription("DockContent_TabText_Description")]
		[Localizable(true)]
		private string m_tabText = null;

		private static readonly object DockStateChangedEvent = new object();

		[Browsable(false)]
		public DockContentHandler DockHandler
		{
			get
			{
				return m_dockHandler;
			}
		}

		[LocalizedDescription("DockContent_AllowEndUserDocking_Description")]
		[LocalizedCategory("Category_Docking")]
		[DefaultValue(true)]
		public bool AllowEndUserDocking
		{
			get
			{
				return DockHandler.AllowEndUserDocking;
			}
			set
			{
				DockHandler.AllowEndUserDocking = value;
			}
		}

		[LocalizedDescription("DockContent_DockAreas_Description")]
		[LocalizedCategory("Category_Docking")]
		[DefaultValue(DockAreas.Float | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.DockBottom | DockAreas.Document)]
		public DockAreas DockAreas
		{
			get
			{
				return DockHandler.DockAreas;
			}
			set
			{
				DockHandler.DockAreas = value;
			}
		}

		[DefaultValue(0.25)]
		[LocalizedCategory("Category_Docking")]
		[LocalizedDescription("DockContent_AutoHidePortion_Description")]
		public double AutoHidePortion
		{
			get
			{
				return DockHandler.AutoHidePortion;
			}
			set
			{
				DockHandler.AutoHidePortion = value;
			}
		}

		public string TabText
		{
			get
			{
				return m_tabText;
			}
			set
			{
				DockHandler.TabText = (m_tabText = value);
			}
		}

		[LocalizedDescription("DockContent_CloseButton_Description")]
		[DefaultValue(true)]
		[LocalizedCategory("Category_Docking")]
		public bool CloseButton
		{
			get
			{
				return DockHandler.CloseButton;
			}
			set
			{
				DockHandler.CloseButton = value;
			}
		}

		[LocalizedCategory("Category_Docking")]
		[DefaultValue(true)]
		[LocalizedDescription("DockContent_CloseButtonVisible_Description")]
		public bool CloseButtonVisible
		{
			get
			{
				return DockHandler.CloseButtonVisible;
			}
			set
			{
				DockHandler.CloseButtonVisible = value;
			}
		}

		[Browsable(false)]
		public DockPanel DockPanel
		{
			get
			{
				return DockHandler.DockPanel;
			}
			set
			{
				DockHandler.DockPanel = value;
			}
		}

		[Browsable(false)]
		public DockState DockState
		{
			get
			{
				return DockHandler.DockState;
			}
			set
			{
				DockHandler.DockState = value;
			}
		}

		[Browsable(false)]
		public DockPane Pane
		{
			get
			{
				return DockHandler.Pane;
			}
			set
			{
				DockHandler.Pane = value;
			}
		}

		[Browsable(false)]
		public bool IsHidden
		{
			get
			{
				return DockHandler.IsHidden;
			}
			set
			{
				DockHandler.IsHidden = value;
			}
		}

		[Browsable(false)]
		public DockState VisibleState
		{
			get
			{
				return DockHandler.VisibleState;
			}
			set
			{
				DockHandler.VisibleState = value;
			}
		}

		[Browsable(false)]
		public bool IsFloat
		{
			get
			{
				return DockHandler.IsFloat;
			}
			set
			{
				DockHandler.IsFloat = value;
			}
		}

		[Browsable(false)]
		public DockPane PanelPane
		{
			get
			{
				return DockHandler.PanelPane;
			}
			set
			{
				DockHandler.PanelPane = value;
			}
		}

		[Browsable(false)]
		public DockPane FloatPane
		{
			get
			{
				return DockHandler.FloatPane;
			}
			set
			{
				DockHandler.FloatPane = value;
			}
		}

		[LocalizedDescription("DockContent_HideOnClose_Description")]
		[LocalizedCategory("Category_Docking")]
		[DefaultValue(false)]
		public bool HideOnClose
		{
			get
			{
				return DockHandler.HideOnClose;
			}
			set
			{
				DockHandler.HideOnClose = value;
			}
		}

		[DefaultValue(DockState.Unknown)]
		[LocalizedCategory("Category_Docking")]
		[LocalizedDescription("DockContent_ShowHint_Description")]
		public DockState ShowHint
		{
			get
			{
				return DockHandler.ShowHint;
			}
			set
			{
				DockHandler.ShowHint = value;
			}
		}

		[Browsable(false)]
		public bool IsActivated
		{
			get
			{
				return DockHandler.IsActivated;
			}
		}

		[DefaultValue(null)]
		[LocalizedDescription("DockContent_TabPageContextMenu_Description")]
		[LocalizedCategory("Category_Docking")]
		public ContextMenu TabPageContextMenu
		{
			get
			{
				return DockHandler.TabPageContextMenu;
			}
			set
			{
				DockHandler.TabPageContextMenu = value;
			}
		}

		[LocalizedCategory("Category_Docking")]
		[LocalizedDescription("DockContent_TabPageContextMenuStrip_Description")]
		[DefaultValue(null)]
		public ContextMenuStrip TabPageContextMenuStrip
		{
			get
			{
				return DockHandler.TabPageContextMenuStrip;
			}
			set
			{
				DockHandler.TabPageContextMenuStrip = value;
			}
		}

		[Localizable(true)]
		[LocalizedDescription("DockContent_ToolTipText_Description")]
		[DefaultValue(null)]
		[Category("Appearance")]
		public string ToolTipText
		{
			get
			{
				return DockHandler.ToolTipText;
			}
			set
			{
				DockHandler.ToolTipText = value;
			}
		}

		[LocalizedCategory("Category_PropertyChanged")]
		[LocalizedDescription("Pane_DockStateChanged_Description")]
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

		public DockContent()
		{
			m_dockHandler = new DockContentHandler(this, GetPersistString);
			m_dockHandler.DockStateChanged += DockHandler_DockStateChanged;
			base.ParentChanged += DockContent_ParentChanged;
		}

		private void DockContent_ParentChanged(object Sender, EventArgs e)
		{
			if (base.Parent != null)
			{
				Font = base.Parent.Font;
			}
		}

		private bool ShouldSerializeTabText()
		{
			return m_tabText != null;
		}

		protected virtual string GetPersistString()
		{
			return GetType().ToString();
		}

		public bool IsDockStateValid(DockState dockState)
		{
			return DockHandler.IsDockStateValid(dockState);
		}

		public new void Activate()
		{
			DockHandler.Activate();
		}

		public void RealHide()
		{
			base.Hide();
		}

		public new void Hide()
		{
			DockHandler.Hide();
		}

		public new void Show()
		{
			DockHandler.Show();
		}

		public void Show(DockPanel dockPanel)
		{
			DockHandler.Show(dockPanel);
		}

		public void Show(DockPanel dockPanel, DockState dockState)
		{
			DockHandler.Show(dockPanel, dockState);
		}

		public void Show(DockPanel dockPanel, Rectangle floatWindowBounds)
		{
			DockHandler.Show(dockPanel, floatWindowBounds);
		}

		public void Show(DockPane pane, IDockContent beforeContent)
		{
			DockHandler.Show(pane, beforeContent);
		}

		public void Show(DockPane previousPane, DockAlignment alignment, double proportion)
		{
			DockHandler.Show(previousPane, alignment, proportion);
		}

		public void FloatAt(Rectangle floatWindowBounds)
		{
			DockHandler.FloatAt(floatWindowBounds);
		}

		public void DockTo(DockPane paneTo, DockStyle dockStyle, int contentIndex)
		{
			DockHandler.DockTo(paneTo, dockStyle, contentIndex);
		}

		public void DockTo(DockPanel panel, DockStyle dockStyle)
		{
			DockHandler.DockTo(panel, dockStyle);
		}

		void IDockContent.OnActivated(EventArgs e)
		{
			OnActivated(e);
		}

		void IDockContent.OnDeactivate(EventArgs e)
		{
			OnDeactivate(e);
		}

		private void DockHandler_DockStateChanged(object sender, EventArgs e)
		{
			OnDockStateChanged(e);
		}

		protected virtual void OnDockStateChanged(EventArgs e)
		{
			((EventHandler)base.Events[DockStateChangedEvent])?.Invoke(this, e);
		}

		private void InitializeComponent()
		{
			SuspendLayout();
			base.ClientSize = new System.Drawing.Size(284, 262);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "DockContent";
			ResumeLayout(performLayout: false);
		}
	}
}
