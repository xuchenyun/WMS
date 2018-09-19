using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CIT.Client
{
	internal class PanelDesigner : ParentControlDesigner
	{
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
				designerActionListCollection.Add(new PanelDesignerActionList(base.Component));
				return designerActionListCollection;
			}
		}

		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
		}

		protected override void OnPaintAdornments(PaintEventArgs e)
		{
			base.OnPaintAdornments(e);
		}
	}
}
