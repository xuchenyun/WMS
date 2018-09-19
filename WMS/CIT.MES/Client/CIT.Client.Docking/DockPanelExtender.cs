using System;
using System.Drawing;

namespace CIT.Client.Docking
{
	public sealed class DockPanelExtender
	{
		public interface IDockPaneFactory
		{
			DockPane CreateDockPane(IDockContent content, DockState visibleState, bool show);

			DockPane CreateDockPane(IDockContent content, FloatWindow floatWindow, bool show);

			DockPane CreateDockPane(IDockContent content, DockPane previousPane, DockAlignment alignment, double proportion, bool show);

			DockPane CreateDockPane(IDockContent content, Rectangle floatWindowBounds, bool show);
		}

		public interface IFloatWindowFactory
		{
			FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane);

			FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane, Rectangle bounds);
		}

		public interface IDockPaneCaptionFactory
		{
			DockPaneCaptionBase CreateDockPaneCaption(DockPane pane);
		}

		public interface IDockPaneStripFactory
		{
			DockPaneStripBase CreateDockPaneStrip(DockPane pane);
		}

		public interface IAutoHideStripFactory
		{
			AutoHideStripBase CreateAutoHideStrip(DockPanel panel);
		}

		private class DefaultDockPaneFactory : IDockPaneFactory
		{
			public DockPane CreateDockPane(IDockContent content, DockState visibleState, bool show)
			{
				return new DockPane(content, visibleState, show);
			}

			public DockPane CreateDockPane(IDockContent content, FloatWindow floatWindow, bool show)
			{
				return new DockPane(content, floatWindow, show);
			}

			public DockPane CreateDockPane(IDockContent content, DockPane prevPane, DockAlignment alignment, double proportion, bool show)
			{
				return new DockPane(content, prevPane, alignment, proportion, show);
			}

			public DockPane CreateDockPane(IDockContent content, Rectangle floatWindowBounds, bool show)
			{
				return new DockPane(content, floatWindowBounds, show);
			}
		}

		private class DefaultFloatWindowFactory : IFloatWindowFactory
		{
			public FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane)
			{
				return new FloatWindow(dockPanel, pane);
			}

			public FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane, Rectangle bounds)
			{
				return new FloatWindow(dockPanel, pane, bounds);
			}
		}

		private class DefaultDockPaneCaptionFactory : IDockPaneCaptionFactory
		{
			public DockPaneCaptionBase CreateDockPaneCaption(DockPane pane)
			{
				return new VS2005DockPaneCaption(pane);
			}
		}

		private class DefaultDockPaneStripFactory : IDockPaneStripFactory
		{
			public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
			{
				return new VS2005DockPaneStrip(pane);
			}
		}

		private class DefaultAutoHideStripFactory : IAutoHideStripFactory
		{
			public AutoHideStripBase CreateAutoHideStrip(DockPanel panel)
			{
				return new VS2005AutoHideStrip(panel);
			}
		}

		private DockPanel m_dockPanel;

		private IDockPaneFactory m_dockPaneFactory = null;

		private IFloatWindowFactory m_floatWindowFactory = null;

		private IDockPaneCaptionFactory m_dockPaneCaptionFactory = null;

		private IDockPaneStripFactory m_dockPaneStripFactory = null;

		private IAutoHideStripFactory m_autoHideStripFactory = null;

		private DockPanel DockPanel => m_dockPanel;

		public IDockPaneFactory DockPaneFactory
		{
			get
			{
				if (m_dockPaneFactory == null)
				{
					m_dockPaneFactory = new DefaultDockPaneFactory();
				}
				return m_dockPaneFactory;
			}
			set
			{
				if (DockPanel.Panes.Count > 0)
				{
					throw new InvalidOperationException();
				}
				m_dockPaneFactory = value;
			}
		}

		public IFloatWindowFactory FloatWindowFactory
		{
			get
			{
				if (m_floatWindowFactory == null)
				{
					m_floatWindowFactory = new DefaultFloatWindowFactory();
				}
				return m_floatWindowFactory;
			}
			set
			{
				if (DockPanel.FloatWindows.Count > 0)
				{
					throw new InvalidOperationException();
				}
				m_floatWindowFactory = value;
			}
		}

		public IDockPaneCaptionFactory DockPaneCaptionFactory
		{
			get
			{
				if (m_dockPaneCaptionFactory == null)
				{
					m_dockPaneCaptionFactory = new DefaultDockPaneCaptionFactory();
				}
				return m_dockPaneCaptionFactory;
			}
			set
			{
				if (DockPanel.Panes.Count > 0)
				{
					throw new InvalidOperationException();
				}
				m_dockPaneCaptionFactory = value;
			}
		}

		public IDockPaneStripFactory DockPaneStripFactory
		{
			get
			{
				if (m_dockPaneStripFactory == null)
				{
					m_dockPaneStripFactory = new DefaultDockPaneStripFactory();
				}
				return m_dockPaneStripFactory;
			}
			set
			{
				if (DockPanel.Contents.Count > 0)
				{
					throw new InvalidOperationException();
				}
				m_dockPaneStripFactory = value;
			}
		}

		public IAutoHideStripFactory AutoHideStripFactory
		{
			get
			{
				if (m_autoHideStripFactory == null)
				{
					m_autoHideStripFactory = new DefaultAutoHideStripFactory();
				}
				return m_autoHideStripFactory;
			}
			set
			{
				if (DockPanel.Contents.Count > 0)
				{
					throw new InvalidOperationException();
				}
				if (m_autoHideStripFactory != value)
				{
					m_autoHideStripFactory = value;
					DockPanel.ResetAutoHideStripControl();
				}
			}
		}

		internal DockPanelExtender(DockPanel dockPanel)
		{
			m_dockPanel = dockPanel;
		}
	}
}
