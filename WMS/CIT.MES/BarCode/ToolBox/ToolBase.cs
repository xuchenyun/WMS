using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

using System.Drawing;
using CIT.MES.DrawItem;

namespace CIT.MES.ToolBox
{
    public class ToolBase
    {
        public ToolBase()
        {
        }

        private Dictionary<string, Cursor> cursor = new Dictionary<string, Cursor>();
        private Cursor _cursor;

        /// <summary>
        /// 从资源文件里读取光标文件
        /// 如果在没有加载过的光标，则先从资源文件里读取
        /// 加载过的直接从dictionary中返回
        /// </summary>
        /// <param name="name">光标的名称,不带扩展名</param>
        /// <returns></returns>
        protected Cursor GetCursor(string name)
        {
            if (cursor.ContainsKey(name))
            {
                return cursor[name];
            }
            return Cursors.Default;
            using (Stream fs = Assembly.GetAssembly(typeof(ToolBase)).GetManifestResourceStream("CIT.MES.BarCode.Resources." + name + ".cur"))
            {
                Cursor c = new Cursor(fs);
                cursor.Add(name, c);
                return c;
            }

        }

        protected void AddNewObject(Designer designer, CIT.MES.DrawItem.DrawItemBase drawitem)
        {
            //在设计器对像列表中加入新的对像
            designer.Items.Add(drawitem);
            //将原来选中的对像设计为未选中
            designer.Items.UnSelectAll();
            //设置新添加的对像为选中状态
            drawitem.Selected = true;

            designer.Capture = true;
            designer.Refresh();
            //new PubUtils().ShowNoteOKMsg(((CIT.MES.DrawItem.DrawText)(drawitem)).TextRectangle.Width.ToString());
            designer.ChangeFlage = true;
        }

        /// <summary>
        /// 设置所选择工具的光标
        /// </summary>
        public Cursor ToolCursor
        {
            get
            {
                return _cursor;
            }
            set
            {
                _cursor = value;
            }
        }

        public virtual void OnMouseDown(Designer designer, MouseEventArgs e)
        {
        }

        public virtual void OnMouseMove(Designer designer, MouseEventArgs e)
        {
        }

        public virtual void OnMouseUp(Designer designer, MouseEventArgs e)
        {

        }

        public virtual void OnDoubleClick(Designer designer, MouseEventArgs e)
        {

        }

    }
}
