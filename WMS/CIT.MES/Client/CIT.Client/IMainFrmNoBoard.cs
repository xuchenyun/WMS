using System.Drawing;

namespace CIT.Client
{
	public class IMainFrmNoBoard : BaseForm
	{
		private void InitializeComponent()
		{
			base.CaptionHeight = 0;
			SuspendLayout();
			base.ClientSize = new System.Drawing.Size(516, 388);
			Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Location = new System.Drawing.Point(0, 0);
			base.Name = "IMainFrmNoBoard";
			ResumeLayout(performLayout: false);
		}
	}
}
