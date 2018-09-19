using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using CIT.MES.DrawItem;
using System.Windows.Forms;

namespace CIT.MES.ToolBox
{
    [ToolAttribute("棱形", "Resources.polygon.gif", Order = 6)]
    public class ToolPloygon:ToolBase
    {
        public ToolPloygon()
        {
            ToolCursor = GetCursor("Rectangle");
        }

        public override void OnMouseDown(Designer designer, System.Windows.Forms.MouseEventArgs e)
        {
            AddNewObject(designer, new DrawPolygon(e.X, e.Y, 1, 1));
        }

        public override void OnMouseMove(Designer designer, System.Windows.Forms.MouseEventArgs e)
        {
            designer.Cursor = ToolCursor;
            if (e.Button == MouseButtons.Left)
            {
                Point point = new Point(e.X, e.Y);
                designer.Items[0].MoveHandleTo(point, 8);
                designer.Refresh();
                //designer.SelectedItem(designer.Items[0]);
            }
        }
    }
}
