using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;

namespace CIT.MES.DrawItem
{

    [Serializable()]
    public class DrawItemList:List<DrawItemBase>
    {
        public DrawItemList()
        { 
        }


        //将对像插入列表
        public new void Add(DrawItemBase itemBase)
        {
            base.Insert(0, itemBase);
        }

        public void Draw(Graphics g)
        {
            for (int i = this.Count-1; i >-1; i--)
            {
                //判定是否绑定了数据源
                if (!string.IsNullOrEmpty(this[i].ValueColumn) && CheckDataTabelIsNoteNullOrEmpty(dataTable))
                {
                    //设定数据源打印时的属性
                    this[i].DataSource = dataTable;
                    this[i].CurrentPage = currentPage;
                    this[i].RowHeight = rowsHeight;
                    this[i].PageRowsCount = pageRowsCount;
                    this[i].Selected = false;
                }

                this[i].Draw(g);
                //如果对像是选中状态,则画出手柄
                if (this[i].Selected)
                {
                    this[i].DrawTracker(g);
                }
            }
        }

        //数据源
        private DataTable dataTable;
        //当前是哪一页
        private int currentPage = 1;
        //每页有多少行
        private int pageRowsCount = 3;
        //每行行高
        private int rowsHeight = 15;

        /// <summary>
        /// 在数据源打印时的行高.默认15
        /// </summary>
        public int RowsHeight
        {
            get
            {
                return rowsHeight;
            }
            set
            {
                rowsHeight = value;
            }
        }

        /// <summary>
        /// 设定每页中有多少条记录
        /// </summary>
        public int PageRowsCount
        {
            get
            {
                return pageRowsCount;
            }
            set
            {
                pageRowsCount = value;
            }
        }

        /// <summary>
        /// 当前要显示的是哪一页
        /// </summary>
        public int CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
            }
        }

        public DataTable DataSource
        {
            get
            {
                return dataTable;
            }
            set
            {
                dataTable = value;
            }
        }

        /// <summary>
        /// 检查DataTable是否为空
        /// </summary>
        /// <param name="dt">要检查的DataTable</param>
        /// <returns>False:为空 True:不为空</returns>
        protected bool CheckDataTabelIsNoteNullOrEmpty(DataTable dt)
        {
            bool IsNotNull = true;
            if (DataSource == null)
            {
                IsNotNull = false;
            }
            else if (DataSource.Rows.Count == 0)
            {
                IsNotNull = false;
            }
            return IsNotNull;
        }


        /// <summary>
        /// 获取对像列中选定的对像
        /// </summary>
        /// <param name="index">选中的是第几个</param>
        /// <returns></returns>
        public DrawItemBase GetSelectItem(int index)
        {
            int i = -1;
            foreach (DrawItemBase o in this)
            {
                if (o.Selected)
                {
                   i++;
                    if (i == index)
                        return o;
                }
            }

            return null;
        }

        /// <summary>
        /// 选择所有对像
        /// </summary>
        public void SelectAll()
        {
            foreach (DrawItemBase item in this)
            {
                item.Selected = true;
            }
        }

        /// <summary>
        /// 将所选中第一个对像放到最后
        /// </summary>
        /// <param name="selectindex"></param>
        public void SendBlow()
        {
            if (this.Count > 1)
            {
                DrawItemBase dib = GetSelectItem(0);
                this.Remove(dib);
                this.Insert(this.Count, dib);
            } 
        }
        /// <summary>
        /// 将选中的第一个对像放到最前面
        /// </summary>
        /// <param name="selectindex"></param>
        public void SendFront()
        {
            if (this.Count > 1)
            {
                DrawItemBase dib = GetSelectItem(0);
                this.Remove(dib);
                this.Insert(0, dib);
            }
 
        }

        /// <summary>
        /// 取消选择所有对像
        /// </summary>
        public void UnSelectAll()
        {
            foreach (DrawItemBase item in this)
            {
                item.Selected = false;
            }
        }

        /// <summary>
        /// 选择矩形中的对像
        /// </summary>
        /// <param name="rect"></param>
        public void SelectInRectangle(Rectangle rect)
        {
            foreach (DrawItemBase item in this)
            {
                if (item.IntersectsWith(rect))
                {
                    item.Selected = true ;
                }
            }
        }
        /// <summary>
        /// 获取有多少个选中的对像
        /// </summary>
        public int SelectionCount
        {
            get
            {
                int n = 0;

                foreach (DrawItemBase o in this)
                {
                    if (o.Selected)
                        n++;
                }

                return n;
            }
        }

        /// <summary>
        /// 获取选中对像列表中第一个对像在列表中的索引号
        /// </summary>
        public int GetSelectedIndex
        {
            get
            {
                int n = -1;
                foreach (DrawItemBase o in this)
                {
                    n++;
                    if (o.Selected)
                    {
                        break;
                    }
                }

                return n;
            }
        }
       
    }
}
