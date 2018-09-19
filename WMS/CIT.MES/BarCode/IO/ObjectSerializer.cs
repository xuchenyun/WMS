using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CIT.MES.DrawItem;

namespace CIT.MES.IO
{
    /// <summary>
    ///保存设计器中的信息
    ///在保存文件的时候反它序列化后保存
    /// </summary>
    [Serializable()]
    public class ObjectSerializer
    {
        /// <summary>
        /// 要将设计的对像保存到文件的信息
        /// </summary>
        /// <param name="objectSave">设计器中的对像列表</param>
        /// <param name="width">设计器的宽度</param>
        /// <param name="height">设计器的高度</param>
        /// <param name="pconfig">打印设置</param>
        public ObjectSerializer(DrawItemList objectSave, int width, int height, PrintConfig pconfig, int rowcount, int rowheight)
        {
            itemList = objectSave;
            des_W = width;
            des_H = height;
            printconfig = pconfig;
            _rowcount = rowcount;
            _rowheight = rowheight;
        }

        private DrawItemList itemList;
        private int des_W, des_H, _rowcount, _rowheight;
        private PrintConfig printconfig;

        /// <summary>
        /// 取得或设置每页有多少行
        /// </summary>
        public int RowCount
        {
            get
            {
                return _rowcount;
            }
            set
            {
                _rowcount = value;
            }
        }

        /// <summary>
        /// 取得或设置行高
        /// </summary>
        public int RowHeight
        {
            get
            {
                return _rowheight;
            }
            set
            {
                _rowheight = value;
            }
        }
        /// <summary>
        /// 取得或设计设计器中的对像列表
        /// </summary>
        public DrawItemList ItemList
        {
            get
            {
                return itemList;
            }
            set
            {
                itemList = value;
            }
        }

        /// <summary>
        /// 取得或设置设计器的宽度
        /// </summary>
        public int Width
        {
            get
            {
                return des_W;
            }
            set
            {
                des_W = value;
            }
        }

        /// <summary>
        /// 取得或设置设计器的高度
        /// </summary>
        public int Height
        {
            get
            {
                return des_H;
            }
            set
            {
                des_H = value;
            }
        }

        /// <summary>
        /// 存储打印设置
        /// </summary>
        public PrintConfig PrinterConfig
        {
            get
            {
                return printconfig;
            }
            set
            {
                printconfig = value;
            }
        }

    }
}
