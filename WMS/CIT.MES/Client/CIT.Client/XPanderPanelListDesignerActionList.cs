using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;

namespace CIT.Client
{
	public class XPanderPanelListDesignerActionList : DesignerActionList
	{
		[Editor(typeof(XPanderPanelCollectionEditor), typeof(UITypeEditor))]
		public XPanderPanelCollection XPanderPanels
		{
			get
			{
				return XPanderPanelList.XPanderPanels;
			}
		}

		public PanelStyle PanelStyle
		{
			get
			{
				return XPanderPanelList.PanelStyle;
			}
			set
			{
				SetProperty("PanelStyle", value);
			}
		}

		public ColorScheme ColorScheme
		{
			get
			{
				return XPanderPanelList.ColorScheme;
			}
			set
			{
				SetProperty("ColorScheme", value);
			}
		}

		public CaptionStyle CaptionStyle
		{
			get
			{
				return XPanderPanelList.CaptionStyle;
			}
			set
			{
				SetProperty("CaptionStyle", value);
			}
		}

		public bool ShowBorder
		{
			get
			{
				return XPanderPanelList.ShowBorder;
			}
			set
			{
				SetProperty("ShowBorder", value);
			}
		}

		public bool ShowExpandIcon
		{
			get
			{
				return XPanderPanelList.ShowExpandIcon;
			}
			set
			{
				SetProperty("ShowExpandIcon", value);
			}
		}

		public bool ShowCloseIcon
		{
			get
			{
				return XPanderPanelList.ShowCloseIcon;
			}
			set
			{
				SetProperty("ShowCloseIcon", value);
			}
		}

		private XPanderPanelList XPanderPanelList => (XPanderPanelList)base.Component;

		public XPanderPanelListDesignerActionList(IComponent component)
			: base(component)
		{
			base.AutoShow = true;
		}

		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "ToggleDockStyle", GetDockStyleText(), "Design", "Dock or undock this control in it's parent container.", includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowBorder", "Show Border", GetCategory(XPanderPanelList, "ShowBorder")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowExpandIcon", "Show ExpandIcon", GetCategory(XPanderPanelList, "ShowExpandIcon")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowCloseIcon", "Show CloseIcon", GetCategory(XPanderPanelList, "ShowCloseIcon")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PanelStyle", "Select PanelStyle", GetCategory(XPanderPanelList, "PanelStyle")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ColorScheme", "Select ColorScheme", GetCategory(XPanderPanelList, "ColorScheme")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("CaptionStyle", "Select CaptionStyle", GetCategory(XPanderPanelList, "CaptionStyle")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("XPanderPanels", "Edit XPanderPanels", GetCategory(XPanderPanelList, "XPanderPanels")));
			return designerActionItemCollection;
		}

		public void ToggleDockStyle()
		{
			if (XPanderPanelList.Dock != DockStyle.Fill)
			{
				SetProperty("Dock", DockStyle.Fill);
			}
			else
			{
				SetProperty("Dock", DockStyle.None);
			}
		}

		private string GetDockStyleText()
		{
			if (XPanderPanelList.Dock == DockStyle.Fill)
			{
				return "Undock in parent container";
			}
			return "Dock in parent container";
		}

		private void SetProperty(string propertyName, object value)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(XPanderPanelList)[propertyName];
			propertyDescriptor.SetValue(XPanderPanelList, value);
		}

		private static string GetCategory(object source, string propertyName)
		{
			PropertyInfo property = source.GetType().GetProperty(propertyName);
			return ((CategoryAttribute)property.GetCustomAttributes(typeof(CategoryAttribute), inherit: false)[0])?.Category;
		}
	}
}
