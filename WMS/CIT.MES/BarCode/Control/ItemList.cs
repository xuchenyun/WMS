using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CIT.MES.DrawItem;
using System.Drawing;
using System.ComponentModel;

namespace CIT.MES.Control
{
    public class ItemList : ListBox
    {
        public ItemList()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.ItemHeight = 20;
            this.MouseDown += new MouseEventHandler(ItemList_MouseClick);
            //this.KeyUp += new KeyEventHandler(ItemList_KeyUp);

        }
        const int WM_KEYDOWN = 0x0100;

        /// <summary>
        /// 在选择item改变时,重绘控伯状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemList_MouseClick(object sender, MouseEventArgs e)
        {
            this.Refresh();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_KEYDOWN)
            {
                this.Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DrawItemList DrawItems
        {
            get
            {
                DrawItemList templist = new DrawItemList();
                foreach (object item in Items)
                {
                    templist.Add(item as DrawItemBase);
                }
                return templist;
            }
            set
            {

                if (value != null)
                {
                    if (Items.Count > 0)
                    {
                        Items.Clear();
                    }
                    foreach (DrawItemBase dib in value)
                    {
                        this.Items.Add(dib);
                    }
                    if (this.Items.Count > 0)
                    {
                        this.SelectedIndex = 0;

                        this.Refresh();
                    }
                }
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index > -1 && this.Items.Count > 0)
            {
                e.DrawBackground();

                e.DrawFocusRectangle();
                DrawItemBase item = this.Items[e.Index] as DrawItemBase;
                Graphics g = e.Graphics;
                g.DrawImage(item.IconImage, new Rectangle(e.Bounds.X + 15, e.Bounds.Y + 2, 16, 16));


                if (this.SelectedIndex == e.Index)
                {
                    g.DrawString(item.Name + " - " + (e.Index + 1).ToString(), new Font("Verdana", 9), Brushes.White, e.Bounds.X + 36, e.Bounds.Y + 3);
                }
                else
                {
                    g.DrawString(item.Name + " - " + (e.Index + 1).ToString(), new Font("Verdana", 9), Brushes.Blue, e.Bounds.X + 36, e.Bounds.Y + 3);
                }
            }
            // base.OnDrawItem(e);
        }


    }
}
