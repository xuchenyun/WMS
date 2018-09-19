using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using CIT.MES.DrawItem;

namespace CIT.MES.ToolBox
{
    [ToolAttribute("文本", "Resources.text.png", Order = 3)]
    public class ToolText : ToolBase
    {
        public ToolText()
        {
            ToolCursor = Cursors.Cross;// GetCursor("Rectangle");
        }

        public override void OnMouseDown(Designer designer, System.Windows.Forms.MouseEventArgs e)
        {
            AddNewObject(designer, new DrawText(e.X, e.Y, 1, 1));
        }

        public override void OnMouseMove(Designer designer, MouseEventArgs e)
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

        public override void OnMouseUp(Designer designer, MouseEventArgs e)
        {
            //当添加文本编辑时用文本框进行输入编辑内容
            Rectangle rectangle = DrawRectangle.GetNormalizedRectangle((designer.Items[0] as DrawText).Rectangle);
            designer.textBox.Location = new Point(rectangle.X + 8, rectangle.Y + 7);
            designer.textBox.Size = new Size(rectangle.Width - 14, rectangle.Height - 14);
            designer.textBox.Enabled = true;
            designer.textBox.Visible = true;
            designer.textBox.Text = "";
            designer.textBox.Font = (designer.Items[0] as DrawText).TextFont;
            designer.textBox.Focus();
            //设置当前选中的文本编辑器
            //在多个编辑切换时，可以知道当前编辑的是哪一个
            designer.SelectDrawText = designer.Items[0] as DrawText;
        }
    }
}
