using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using ZXing;
using ZXing.QrCode;

namespace CIT.MES.BarCode
{
    [Serializable]
    internal class Code128A : IBarcode
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Code128A()
        {

        }
        #region 变量

        private BarcodeTextAlign _barcodeTextAlign = BarcodeTextAlign.Center;
        private int _BarcodeHeight = 1;
        private string _BarcodeValue = "0123456";
        private BarcodeRotation _barcodeRotation = BarcodeRotation.Rotation0;
        private Font _ValueTextFont = new Font("Courier", 8);
        private BarCodeWeight _BarcodeWeight = BarCodeWeight.Medium;
        private Rectangle _BarcodeRect;

        #endregion


        #region 属性
        /// <summary>
        /// 条码的做图区域
        /// </summary>
        public System.Drawing.Rectangle BarcodeRect
        {
            get { return _BarcodeRect; }
            set { _BarcodeRect = value; }
        }

        /// <summary>
        /// 是否显示条码值
        /// </summary>
        public bool ShowText
        {
            get;
            set;
        }
        /// <summary>
        /// 是否在条码上方显示字符
        /// </summary>
        public bool ShowTextOnTop
        {
            get;
            set;
        }

        /// <summary>
        /// 条码值的对值的对齐方式
        /// </summary>
        public BarcodeTextAlign barcodeTextAlign
        {
            get { return _barcodeTextAlign; }
            set { _barcodeTextAlign = value; }
        }

        /// <summary>
        /// 条码的高度
        /// </summary>
        public int BarcodeHeight
        {
            get
            {
                return _BarcodeHeight;
            }
            set
            {
                _BarcodeHeight = value;
            }
        }

        /// <summary>
        /// 条码的值
        /// </summary>
        public string BarcodeValue
        {
            get
            {
                return _BarcodeValue;
            }
            set
            {
                _BarcodeValue = value;
            }
        }

        /// <summary>
        /// 旋转
        /// </summary>
        public BarcodeRotation barcodeRotation
        {
            get
            {
                return _barcodeRotation;
            }
            set
            {
                _barcodeRotation = value;
            }
        }

        /// <summary>
        /// 字体
        /// </summary>
        public System.Drawing.Font ValueTextFont
        {
            get
            {
                return _ValueTextFont;
            }
            set
            {
                _ValueTextFont = value;
            }
        }

        /// <summary>
        /// 条码的大小
        /// </summary>
        public BarCodeWeight BarcodeWeight
        {
            get
            {
                return _BarcodeWeight;
            }
            set
            {
                _BarcodeWeight = value;
            }
        }
        #endregion

        #region 方法
        public void CreateBarcode(System.Drawing.Graphics graphics)
        {
            SizeF sizeF = graphics.MeasureString(BarcodeValue, this.ValueTextFont);

            float strWidth = sizeF.Width, strHeight = sizeF.Height;

            Bitmap bitmap = Create_ImgCode(BarcodeValue, BarcodeHeight);

            bitmap = GetSmall(bitmap, (int)BarcodeWeight);

            float bmpWidth = bitmap.Width, bmpHeight = bitmap.Height;





            if (ShowText)
            {
                if (bmpWidth > strWidth)
                {
                    _BarcodeRect.Width = (int)bmpWidth;
                }
                else
                {
                    _BarcodeRect.Width = (int)strWidth;
                }

                _BarcodeRect.Height = (int)(bmpHeight + strHeight);

                switch (barcodeTextAlign)
                {
                    case BarcodeTextAlign.Left:
                        if (ShowTextOnTop)
                        {
                            graphics.DrawString(BarcodeValue, ValueTextFont, Brushes.Black, _BarcodeRect.Location);
                            graphics.DrawImage(bitmap, new Point(_BarcodeRect.Location.X, (int)(_BarcodeRect.Location.Y + strHeight)));
                        }
                        else
                        {
                            graphics.DrawImage(bitmap, _BarcodeRect.Location);
                            graphics.DrawString(BarcodeValue, ValueTextFont, Brushes.Black, new Point(_BarcodeRect.Location.X, (int)(_BarcodeRect.Location.Y + bmpHeight)));
                        }
                        break;
                    case BarcodeTextAlign.Center:
                        if (ShowTextOnTop)
                        {
                            if (bmpWidth > strWidth)
                            {
                                graphics.DrawString(BarcodeValue, ValueTextFont, Brushes.Black, new Point((int)(_BarcodeRect.Location.X + (bmpWidth - strWidth) / 2), _BarcodeRect.Location.Y));
                                graphics.DrawImage(bitmap, new Point(_BarcodeRect.Location.X, (int)(_BarcodeRect.Location.Y + strHeight)));
                            }
                            else
                            {
                                graphics.DrawString(BarcodeValue, ValueTextFont, Brushes.Black, _BarcodeRect.Location);
                                graphics.DrawImage(bitmap, new Point((int)(_BarcodeRect.Location.X + (strWidth - bmpWidth) / 2), (int)(_BarcodeRect.Location.Y + strHeight)));
                            }
                        }
                        else
                        {
                            if (bmpWidth > strWidth)
                            {
                                graphics.DrawImage(bitmap, _BarcodeRect.Location);
                                graphics.DrawString(BarcodeValue, ValueTextFont, Brushes.Black, new Point((int)(_BarcodeRect.Location.X + (bmpWidth - strWidth) / 2), (int)(_BarcodeRect.Location.Y + bmpHeight)));
                            }
                            else
                            {
                                Point p = new Point((int)(_BarcodeRect.Location.X + (strWidth - bmpWidth) / 2), _BarcodeRect.Location.Y);
                                graphics.DrawImage(bitmap, new Point((int)(_BarcodeRect.Location.X + (strWidth - bmpWidth) / 2), _BarcodeRect.Location.Y));
                                graphics.DrawString(BarcodeValue, ValueTextFont, Brushes.Black, new Point(_BarcodeRect.Location.X, (int)(_BarcodeRect.Location.Y + bmpHeight)));
                            }
                        }
                        break;
                    case BarcodeTextAlign.Right:
                        if (ShowTextOnTop)
                        {
                            if (bmpWidth > strWidth)
                            {
                                graphics.DrawString(BarcodeValue, ValueTextFont, Brushes.Black, new Point((int)(_BarcodeRect.Location.X + (bmpWidth - strWidth)), _BarcodeRect.Location.Y));
                                graphics.DrawImage(bitmap, new Point(_BarcodeRect.Location.X, (int)(_BarcodeRect.Location.Y + strHeight)));
                            }
                            else
                            {
                                graphics.DrawString(BarcodeValue, ValueTextFont, Brushes.Black, _BarcodeRect.Location);
                                graphics.DrawImage(bitmap, new Point((int)(_BarcodeRect.Location.X + (strWidth - bmpWidth)), (int)(_BarcodeRect.Location.Y + strHeight)));
                            }
                        }
                        else
                        {
                            if (bmpWidth > strWidth)
                            {
                                graphics.DrawImage(bitmap, _BarcodeRect.Location);
                                graphics.DrawString(BarcodeValue, ValueTextFont, Brushes.Black, new Point((int)(_BarcodeRect.Location.X + (bmpWidth - strWidth)), (int)(_BarcodeRect.Location.Y + bmpHeight)));
                            }
                            else
                            {
                                graphics.DrawImage(bitmap, new Point((int)(_BarcodeRect.Location.X + (strWidth - bmpWidth)), _BarcodeRect.Location.Y));
                                graphics.DrawString(BarcodeValue, ValueTextFont, Brushes.Black, new Point(_BarcodeRect.Location.X, (int)(_BarcodeRect.Location.Y + bmpHeight)));
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                _BarcodeRect.Height = (int)(bmpHeight);
                _BarcodeRect.Width = (int)(bmpWidth);
                graphics.DrawImage(bitmap, _BarcodeRect.Location);
            }

            //graphics.DrawImage(bitmap, BarcodeRect.Location);

        }

        public System.Drawing.Rectangle GetBarcodeRectangle()
        {
            Bitmap bitmap = Create_ImgCode(BarcodeValue, BarcodeHeight);
            bitmap = GetSmall(bitmap, (int)BarcodeWeight);
            float bmpWidth = bitmap.Width, bmpHeight = bitmap.Height;
            if (ShowText)
            {
                using (Graphics graphics = Graphics.FromImage(new Bitmap(10, 10)))
                {
                    SizeF sizeF = graphics.MeasureString(BarcodeValue, this.ValueTextFont);

                    float strWidth = sizeF.Width, strHeight = sizeF.Height;

                    return new Rectangle(BarcodeRect.Location, new Size((int)(strWidth > bmpWidth ? strWidth : bmpWidth), (int)(strHeight + bmpHeight)));
                }
            }
            else
            {
                return new Rectangle(BarcodeRect.Location, new Size((int)bmpWidth, (int)bmpHeight));
            }
        }

        /// <summary>  
        /// 生成二维码图片  
        /// </summary>  
        /// <param name="codeNumber">要生成二维码的字符串</param>       
        /// <param name="size">大小尺寸</param>  
        /// <returns>二维码图片</returns>  
        public Bitmap Create_ImgCode(string codeNumber, int size)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.CODE_128;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.PureBarcode = true;
            options.DisableECI = true;
            //设置内容编码
            options.CharacterSet = "UTF-8";
            //设置二维码的宽度和高度
            options.Width = size;
            options.Height = size;
            //设置二维码的边距,单位不是固定像素
            options.Margin = 0;
            writer.Options = options;

            Bitmap map = writer.Write(codeNumber);
            return map;
        }


        /// <summary>
        /// 获取缩小后的图片
        /// </summary>
        /// <param name="bm">要缩小的图片</param>
        /// <param name="times">要缩小的倍数</param>
        /// <returns></returns>
        private Bitmap GetSmall(Bitmap bm, double times)
        {
            int nowWidth = (int)(bm.Width * times);
            int nowHeight = (int)(bm.Height * times);
            Bitmap newbm = new Bitmap(nowWidth, nowHeight);//新建一个放大后大小的图片

            Graphics g = Graphics.FromImage(newbm);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.DrawImage(bm, new Rectangle(0, 0, nowWidth, nowHeight), new Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel);
            g.Dispose();

            return newbm;
        }

        #endregion
    }
}
