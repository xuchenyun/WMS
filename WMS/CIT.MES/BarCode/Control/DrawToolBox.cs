using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using  CIT.MES.ToolBox;
using System.Reflection;
using System.ComponentModel;

namespace CIT.MES.Control
{
    public class DrawToolBox:ToolStrip
    {
        /// <summary>
        /// 在使用时一要先绑定事件
        /// 在执行AddButton.
        /// 因为在AddButton时,程序会先查看SelectTool是否有值
        /// 如为null则先创建ToolSelector为默认的工具
        /// </summary>
        public DrawToolBox()
        {
            
            //AddButton();
        }

        private ToolBase selectTool;
        public event EventHandler ToolChanged;

        
        /// <summary>
        /// 当前选中的工具
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolBase SelectTool
        {
            get
            {
                return selectTool;
            }
            set
            {
                if (value != null)
                {
                    selectTool = value;
                    foreach (ToolStripButton tsb in this.Items)
                    {
                        tsb.CheckState = CheckState.Unchecked;
                        if (((Type)tsb.Tag).Name == value.GetType().Name)
                        {
                            tsb.CheckState = CheckState.Indeterminate;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 将工具添加到toolbox中
        /// </summary>
        public void AddButton()
        {
            this.Items.Clear();
            //获得ToolBase组件
            Assembly assembly = Assembly.GetAssembly(typeof(ToolBase));
            Type[] types = assembly.GetTypes();
            //按钮排序,根据ToolAttribute中order进行排序
            SortedList<int ,ToolStripButton> toolbtns = new SortedList<int,ToolStripButton>();
            //遍历组件,找出toolbox类
            //并添加天toolbox中
            foreach(Type t in types)
            {
                object[] attributes = t.GetCustomAttributes(typeof(ToolAttribute), true);
                if (attributes.Length > 0)
                {
                    ToolAttribute toolAttribute = attributes[0] as ToolAttribute;
                    ToolStripButton tsb = new ToolStripButton();
                    tsb.ToolTipText = toolAttribute.Description;//悬浮提示
                    if (toolAttribute.TooBoxImage != null)
                    {
                        tsb.Image = toolAttribute.TooBoxImage;//图标
                    }
                    tsb.CheckOnClick = true;
                    tsb.Tag = t;
                    tsb.Click +=new EventHandler(tsb_Click);
                    toolbtns.Add(toolAttribute.Order,tsb); 
                }
            }

            //添加toolbutton到toolbox容器中
            foreach(ToolStripButton tbtn in toolbtns.Values)
            {
                this.Items.Add(tbtn);
            }

            if (SelectTool == null && this.Items != null && this.Items.Count>0)
            {
                selectTool = (ToolBase)Activator.CreateInstance((Type)((ToolStripButton)this.Items[0]).Tag);
                ((ToolStripButton)this.Items[0]).CheckState = CheckState.Indeterminate;
                if (ToolChanged != null)
                {
                    ToolChanged(this, null);
                }
            }
        }

        void tsb_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton tsb in this.Items)
            {
                //检查用户点的是不是本身,如果是则不进行任何操作
                if (tsb != sender)
                {
                    tsb.Checked = false;
                    selectTool = (ToolBase)Activator.CreateInstance((Type)((ToolStripButton)sender).Tag);
                    if (ToolChanged != null)
                    {
                        ToolChanged(this, e);
                    }
                }
                else
                {
                    tsb.CheckState = CheckState.Indeterminate;
                }

            }
        }
    }
}
