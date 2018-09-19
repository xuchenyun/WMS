using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CIT.Client
{
	internal class XPanderPanelListDesigner : ParentControlDesigner
	{
		private Pen m_borderPen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark));

		private XPanderPanelList m_xpanderPanelList;

		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
				designerActionListCollection.Add(new XPanderPanelListDesignerActionList(base.Component));
				return designerActionListCollection;
			}
		}

		public XPanderPanelListDesigner()
		{
			m_borderPen.DashStyle = DashStyle.Dash;
		}

		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			m_xpanderPanelList = (XPanderPanelList)Control;
			m_xpanderPanelList.AutoScroll = false;
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && m_borderPen != null)
				{
					m_borderPen.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		protected override void OnPaintAdornments(PaintEventArgs e)
		{
			base.OnPaintAdornments(e);
			e.Graphics.DrawRectangle(m_borderPen, 0, 0, m_xpanderPanelList.Width - 2, m_xpanderPanelList.Height - 2);
		}
	}
}
