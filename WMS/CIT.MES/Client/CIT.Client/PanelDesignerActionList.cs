using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Windows.Forms;

namespace CIT.Client
{
	public class PanelDesignerActionList : DesignerActionList
	{
		public bool ShowCaptionbar
		{
			get
			{
				return Panel.ShowCaptionbar;
			}
			set
			{
				SetProperty("ShowCaptionbar", value);
			}
		}

		public bool ShowTransparentBackground
		{
			get
			{
				return Panel.ShowTransparentBackground;
			}
			set
			{
				SetProperty("ShowTransparentBackground", value);
			}
		}

		public bool ShowXPanderPanelProfessionalStyle
		{
			get
			{
				return Panel.ShowXPanderPanelProfessionalStyle;
			}
			set
			{
				SetProperty("ShowXPanderPanelProfessionalStyle", value);
			}
		}

		public bool ShowExpandIcon
		{
			get
			{
				return Panel.ShowExpandIcon;
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
				return Panel.ShowCloseIcon;
			}
			set
			{
				SetProperty("ShowCloseIcon", value);
			}
		}

		public PanelStyle PanelStyle
		{
			get
			{
				return Panel.PanelStyle;
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
				return Panel.ColorScheme;
			}
			set
			{
				SetProperty("ColorScheme", value);
			}
		}

		private TXPanelFrame Panel => (TXPanelFrame)base.Component;

		public PanelDesignerActionList(IComponent component)
			: base(component)
		{
			base.AutoShow = true;
		}

		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "ToggleDockStyle", GetDockStyleText(), "Design", "Dock or undock this control in it's parent container.", includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowTransparentBackground", "Show transparent backcolor", GetCategory(Panel, "ShowTransparentBackground")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowXPanderPanelProfessionalStyle", "Show the XPanderPanels professional colorscheme", GetCategory(Panel, "ShowXPanderPanelProfessionalStyle")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowCaptionbar", "Show the captionbar on top of the panel", GetCategory(Panel, "ShowCaptionbar")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowExpandIcon", "Show the expand panel icon (not at DockStyle.None or DockStyle.Fill)", GetCategory(Panel, "ShowExpandIcon")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowCloseIcon", "Show the close panel icon (not at DockStyle.None or DockStyle.Fill)", GetCategory(Panel, "ShowCloseIcon")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PanelStyle", "Select PanelStyle", GetCategory(Panel, "PanelStyle")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ColorScheme", "Select ColorScheme", GetCategory(Panel, "ColorScheme")));
			return designerActionItemCollection;
		}

		public void ToggleDockStyle()
		{
			if (Panel.Dock != DockStyle.Fill)
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
			if (Panel.Dock == DockStyle.Fill)
			{
				return "Undock in parent container";
			}
			return "Dock in parent container";
		}

		private void SetProperty(string propertyName, object value)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(Panel)[propertyName];
			propertyDescriptor.SetValue(Panel, value);
		}

		private static string GetCategory(object source, string propertyName)
		{
			PropertyInfo property = source.GetType().GetProperty(propertyName);
			return ((CategoryAttribute)property.GetCustomAttributes(typeof(CategoryAttribute), inherit: false)[0])?.Category;
		}
	}
}
