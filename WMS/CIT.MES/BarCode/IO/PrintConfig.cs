using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;

namespace CIT.MES.IO
{
    [Serializable()]
    public class PrintConfig
    {
        public PrintConfig()
        { 
        }

        private string printName = string.Empty;
        private int copies = 1;
        private int xoffset = 0;
        private int yoffset = 0;
        private float zoom = 1;

        /// <summary>
        /// 打印机名称
        /// 如果不设置则使用默认打印机
        /// </summary>
        public string PrintName
        {
            get 
            {
                if (string.IsNullOrEmpty(printName))
                {
                    printName = new PrintDocument().PrinterSettings.PrinterName;
                }

                return printName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    printName = new PrintDocument().PrinterSettings.PrinterName;
                }
                else
                {
                    printName = value;
                }
            }
        }

        /// <summary>
        /// 打印的数量
        /// </summary>
        public int Copies
        {
            get
            {
                return copies;
            }
            set
            {
                copies = value;
            }
        }
        /// <summary>
        /// x偏移量
        /// </summary>
        public int XOFFSET
        {
            get
            {
                return xoffset;
            }
            set
            {
                xoffset = value;
            }
        }
        /// <summary>
        /// Y偏移量
        /// </summary>
        public int YOFFSET
        {
            get
            {
                return yoffset;
            }
            set
            {
                yoffset = value;
            }
        }
        /// <summary>
        /// 缩放率
        /// </summary>
        public float ZOOM
        {
            get
            {
                return zoom;
            }
            set
            {
                zoom = value;
            }
        }


    }
}
