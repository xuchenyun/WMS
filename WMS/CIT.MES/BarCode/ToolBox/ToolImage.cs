using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CIT.MES.DrawItem;
using System.Windows.Forms;

namespace CIT.MES.ToolBox
{
    [ToolAttribute("图片", "Resources.image.gif", Order = 5)]
    public class ToolImage : ToolBase
    {
        public ToolImage()
        {
            ToolCursor = Cursors.Cross;
        }

        public override void OnMouseDown(Designer designer, MouseEventArgs e)
        {
            AddNewObject(designer, new DrawImage(e.X, e.Y, 1, 1));
        }

        public override void OnMouseMove(Designer designer, MouseEventArgs e)
        {
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
