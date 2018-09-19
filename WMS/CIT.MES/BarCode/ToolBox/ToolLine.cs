using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace CIT.MES.ToolBox
{
    [ToolAttribute("直线", "Resources.line.png", Order = 1)]
    public class ToolLine:ToolBase
    {
        public ToolLine()
        {
            ToolCursor = GetCursor("Line");
        }

        public override void OnMouseDown(Designer designer, System.Windows.Forms.MouseEventArgs e)
        {
            AddNewObject(designer, new DrawItem.DrawLine(new Point(e.X, e.Y), new Point(e.X + 1, e.Y)));
        }

        public override void OnMouseMove(Designer designer, System.Windows.Forms.MouseEventArgs e)
        {
            designer.Cursor = ToolCursor;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                designer.Items[0].MoveHandleTo(new Point(e.X, e.Y+1), 2);
                designer.Refresh();
                //designer.SelectedItem(designer.Items[0]);
            }
        }
    }
}
