using System;
using System.Windows.Forms;
using System.Drawing;
using CIT.MES.DrawItem;
using System.Diagnostics;

namespace CIT.MES.ToolBox
{
    [ToolAttribute("矩形", "Resources.rectangle.png", Order = 2)]
    public class ToolRectangle : ToolBase
    {
        public ToolRectangle()
        {
            ToolCursor = GetCursor("Rectangle");
        }

        private int x, y;

        public override void OnMouseDown(Designer designer, MouseEventArgs e)
        {
            AddNewObject(designer, new DrawRectangle(e.X, e.Y, 50, 20));
            x = e.X;
            y = e.Y;
        }

        public override void OnMouseMove(Designer designer, MouseEventArgs e)
        {
            designer.Cursor = ToolCursor;
            if (e.Button == MouseButtons.Left)
            {
                /*根据鼠标当前的坐标点与起始坐标点
                 * 确定移动移动的方向获取不同的手柄
                 *1--2--3
                 *|     |                 
                 *4     5
                 *|     |
                 *6--7--8
                 */
                //Point point = new Point(e.X, e.Y);
                //if (point != ptold)
                //{
                //    Debug.WriteLine("NowPoint:" + point.ToString());
                //    Debug.WriteLine("OldPoint:" + ptold.ToString());
                //int handle = 8;
                //if (x > e.X && y > e.Y)
                //{
                //    handle = 1;
                //}
                //else if (x > e.X && y < e.Y)
                //{
                //    handle = 6;
                //}
                //else if (x < e.X && y < e.Y)
                //{
                //    handle = 8;
                //}
                //else if (x < e.X && y > e.Y)
                //{
                //    handle = 3;
                //}

                //designer.Items[0].MoveHandleTo(point, handle);
                Point point = new Point(e.X, e.Y);
                designer.Items[0].MoveHandleTo(point, 8);
                designer.Refresh();
                //designer.SelectedItem(designer.Items[0]);
                //}
                //ptold = new Point(e.X, e.Y);
            }
        }
    }
}
