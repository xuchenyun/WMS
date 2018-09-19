using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace CIT.MES.ToolBox
{
    public class ToolAttribute : Attribute
    {
        private Image _ToolBoxImage;
        private string _description;
        private int _order = 1;
        public ToolAttribute()
        {
        }
        public ToolAttribute(string description, string imagePath)
        {
            Stream ms = System.Reflection.Assembly.GetAssembly(typeof(Designer)).GetManifestResourceStream("CIT.MES." + imagePath);
            if (ms != null)
            {
                TooBoxImage = new Bitmap(ms);
            }
            Description = description;
        }
        //排序
        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }
        //描述
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        //图标内容
        public Image TooBoxImage
        {
            get { return _ToolBoxImage; }
            set { _ToolBoxImage = value; }
        }
    }
}
