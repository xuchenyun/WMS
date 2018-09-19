using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using CIT.MES.DrawItem;

namespace CIT.MES.BarCode
{
    [Serializable()]
    public class DrawBarcodes : DrawItemBase
    {
        private int startYscale = 0;
        public DrawBarcodes(int x, int y)
        {
            barcodeRectangle = new Rectangle(x, y, 116, 44);
            startYscale = y;
            Ibarcodes = barcodefactory.CreateBarcode("CIT.MES.BarCode.Code39,CIT.MES");
            printItem.Add(new DrawItem.PrintItem() { ID = "Code39", Value = "Code39" });
        }


        public override string Name
        {
            get { return Enum.GetName(typeof(BarcodeType), eBarcodeType); }
        }

        public override Image IconImage
        {
            get
            {
                return GetIconImage("barcodeNew.png");
            }
        }

        public override int HandleCount
        {
            get { return 0; }
        }

        /// <summary>
        /// 条码接口通过此接口实现不同类别的条码
        /// </summary>
        private IBarcode Ibarcodes;
        /// <summary>
        /// 要产生的条码类别
        /// Code 39,93,128A,B,C,EAN-13........
        /// </summary>
        protected BarcodeType eBarcodeType = BarcodeType.Code39;
        /// <summary>
        /// 条码的文字对齐方式
        /// </summary>
        protected BarcodeTextAlign eTextAlign = BarcodeTextAlign.Center;
        /// <summary>
        /// 条码的大小
        /// </summary>
        protected BarCodeWeight eBarcodeWeight = BarCodeWeight.Small;
        /// <summary>
        /// 条码的旋转角度
        /// 90,180,270
        /// </summary>
        protected BarcodeRotation eBaroceRotation = BarcodeRotation.Rotation0;
        /// <summary>
        /// 是否显示出条码的文本内容
        /// </summary>
        protected bool bShowValueText = true;
        /// <summary>
        /// 是否是条码的上面显示条码的内容
        /// </summary>
        protected bool bShowValueTextOnTop = false;
        /// <summary>
        /// 条码的值
        /// </summary>
        protected string sValueText = "Code39";
        /// <summary>
        /// 条码内容的字体
        /// </summary>
        protected Font fValueTextFont = new Font("Vendana", 8);
        /// <summary>
        /// 条码的高度
        /// </summary>
        protected int nBarcodeHeight = 32;
        /// <summary>
        /// 绘制条码的区域
        /// </summary>
        protected Rectangle barcodeRectangle;
        /// <summary>
        /// 条码工厂,产生不同类别的条码
        /// </summary>
        [NonSerialized]
        private BarcodeFactory barcodefactory = new BarcodeFactory();
        /// <summary>
        /// 变量名称
        /// </summary>
        private string id = "";

        /// <summary>
        /// 是否需要重新计算条码的绘制构区域
        /// 在条码值改变时重新计算 
        /// </summary>
        #region Attributes
        [Category("Barcode Attribute"), DisplayName("旋转角度"), Description("设置条码的旋转角度")]
        public BarcodeRotation BarRotation
        {
            get { return eBaroceRotation; }
            set
            {
                eBaroceRotation = value;
            }
        }
        [Category("Barcode Attribute"), DisplayName("条码字体大小"), Description("设置条码字体大小不算条码上的文字")]
        public int BarcodeHeight
        {
            get { return (int)CommonSettings.PixelConvertMillimeter(nBarcodeHeight); }
            set
            {
                nBarcodeHeight = CommonSettings.MillimeterConvertPixel(value);
            }
        }
        [Category("Barcode Attribute"), DisplayName("条码类别"), Description("设置条码类别(code39,code128,EAN-13,UPC-A)")]
        public BarcodeType BarcodeType
        {
            get { return eBarcodeType; }
            set
            {
                //建立新的条码接口
                // CreateBarcodeInterFace(BarcodeType.Code39);
                eBarcodeType = value;
                //if (eBarcodeType != BarcodeType.Code39)
                //{
                //    frmNotice fn = new frmNotice();
                //    fn.ShowDialog();
                //}
                printItem.Clear();
                switch (eBarcodeType)
                {
                    case BarcodeType.Code39:
                        CreateBarcodeInterFace(BarcodeType.Code39);
                        nBarcodeHeight = 32;
                        printItem.Add(new DrawItem.PrintItem() { ID = "Code39", Value = "Code39" });
                        break;
                    case BarcodeType.Code93:
                        CreateBarcodeInterFace(BarcodeType.Code93);
                        nBarcodeHeight = 32;
                        printItem.Add(new DrawItem.PrintItem() { ID = "Code93", Value = "Code93" });
                        break;
                    case BarcodeType.QRcode:
                        CreateBarcodeInterFace(BarcodeType.QRcode);
                        nBarcodeHeight = 79;
                        ShowText = false;
                        printItem.Add(new DrawItem.PrintItem() { ID = "QRcode", Value = "QRcode" });
                        break;
                    case BarcodeType.DataMatrix:
                        CreateBarcodeInterFace(BarcodeType.DataMatrix);
                        nBarcodeHeight = 79;
                        ShowText = false;
                        printItem.Add(new DrawItem.PrintItem() { ID = "DataMatrix", Value = "DataMatrix" });
                        break;
                    case BarcodeType.Code128A:
                        CreateBarcodeInterFace(BarcodeType.Code128A);
                        nBarcodeHeight = 32;
                        printItem.Add(new DrawItem.PrintItem() { ID = "CODE128A", Value = "CODE128A" });
                        break;
                    case BarcodeType.Code128B:
                        Ibarcodes = barcodefactory.CreateBarcode("CIT.BarCode.Code128Base,CIT.BarCode", eBarcodeType);
                        Ibarcodes.BarcodeRect = barcodeRectangle;
                        printItem.Add(new DrawItem.PrintItem() { ID = "Code128B", Value = "Code128B" });
                        break;
                    case BarcodeType.Code128C:
                    case BarcodeType.UCC_EAN128:
                        Ibarcodes = barcodefactory.CreateBarcode("CIT.BarCode.Code128Base,CIT.BarCode", eBarcodeType);
                        Ibarcodes.BarcodeRect = barcodeRectangle;
                        printItem.Add(new DrawItem.PrintItem() { ID = "01234567", Value = "01234567" });
                        break;
                    case BarcodeType.EAN13:
                        CreateBarcodeInterFace(BarcodeType.EAN13);
                        printItem.Add(new DrawItem.PrintItem() { ID = "690|8888|88878", Value = "690|8888|88878" });
                        break;
                    case BarcodeType.UPCA:
                        CreateBarcodeInterFace(BarcodeType.UPCA);
                        printItem.Add(new DrawItem.PrintItem() { ID = "9|88888|88888", Value = "9|88888|88888" });
                        break;
                    case BarcodeType.Interleaved2of5:
                        CreateBarcodeInterFace(BarcodeType.Interleaved2of5);
                        printItem.Add(new DrawItem.PrintItem() { ID = "123456", Value = "123456" });
                        break;
                    case BarcodeType.Standard2of5:
                        CreateBarcodeInterFace(BarcodeType.Standard2of5);
                        printItem.Add(new DrawItem.PrintItem() { ID = "0123456", Value = "0123456" });
                        break;
                    case BarcodeType.Code11:
                        CreateBarcodeInterFace(BarcodeType.Code11);
                        printItem.Add(new DrawItem.PrintItem() { ID = "1234-1234", Value = "1234-1234" });
                        break;
                    case BarcodeType.Codabar:
                        CreateBarcodeInterFace(BarcodeType.Codabar);
                        printItem.Add(new DrawItem.PrintItem() { ID = "A123456A", Value = "A123456A" });
                        break;

                }
            }
        }
        [Category("Barcode Attribute"), DisplayName("对齐方式"), Description("设置条码上字符对齐式")]
        public BarcodeTextAlign ValueTextAlign
        {
            get { return eTextAlign; }
            set
            {
                eTextAlign = value;
            }
        }
        [Category("Barcode Attribute"), DisplayName("条码大小"), Description("设置条码的大小")]
        public BarCodeWeight BarcodeWeight
        {
            get { return eBarcodeWeight; }
            set
            {
                eBarcodeWeight = value;
            }
        }
        [Category("Barcode Attribute"), DisplayName("显示文本"), Description("设置条码上字符是否显示(true:显示 false:不显示")]
        public bool ShowText
        {
            get { return bShowValueText; }
            set
            {
                bShowValueText = value;

            }
        }
        [Category("Barcode Attribute"), DisplayName("上方显示文本"), Description("设置条码上字符是否显示在条码的上方(true:显示 false:不显示")]
        public bool ShowTextOnTop
        {
            get { return bShowValueTextOnTop; }
            set
            {
                bShowValueTextOnTop = value;
            }
        }

        [Category("Barcode Attribute"), DisplayName("文本字体"), Description("设置条码文本中的字体")]
        public Font ValueTextFont
        {
            get
            {
                return fValueTextFont;
            }
            set
            {
                fValueTextFont = value; ;
            }
        }

        #endregion

        internal void CreateBarcodeInterFace(BarcodeType be)
        {
            if (barcodefactory == null)
            {
                barcodefactory = new BarcodeFactory();
            }
            Ibarcodes = barcodefactory.CreateBarcode("CIT.MES.BarCode." + Enum.GetName(typeof(BarcodeType), be) + ",CIT.MES");
            Ibarcodes.BarcodeRect = barcodeRectangle;
        }

        /// <summary>
        /// 画出条码
        /// 在画条码时,质量用默认的即可,高质量的可能造成条码扫不出来
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighSpeed;
            try
            {
                if (Ibarcodes == null)
                {
                    return;
                }

                Ibarcodes.BarcodeHeight = nBarcodeHeight;
                Ibarcodes.barcodeRotation = BarRotation;
                Ibarcodes.barcodeTextAlign = ValueTextAlign;
                Ibarcodes.BarcodeWeight = BarcodeWeight;
                Ibarcodes.ShowText = ShowText;
                Ibarcodes.ShowTextOnTop = ShowTextOnTop;
                Ibarcodes.ValueTextFont = fValueTextFont;
                Ibarcodes.BarcodeRect = barcodeRectangle;
                if (GetDataSourceIsNotNullOrEmpty && DataSource.Columns.Contains(ValueColumn))
                {
                    //根据当前的页数,找出在数据源中的第一条记录
                    int i = (CurrentPage - 1) * PageRowsCount;
                    int temp = 0;
                    //依次画出数据源中的相应数据
                    //TO DO
                    for (; i < DataSource.Rows.Count; i++)
                    {
                        Ibarcodes.BarcodeValue = DataSource.Rows[i][ValueColumn].ToString();
                        Rectangle tempRect = Ibarcodes.GetBarcodeRectangle();
                        if (temp > 0)
                        {
                            tempRect = new Rectangle(tempRect.X, tempRect.Y + RowHeight, tempRect.Width, tempRect.Height);
                        }
                        Ibarcodes.BarcodeRect = tempRect;
                        Ibarcodes.CreateBarcode(g);
                        temp++;
                        //画出预先设置的数后退出
                        if (temp == PageRowsCount)
                        {
                            break;
                        }
                    }
                    //重置条码位置
                    Ibarcodes.BarcodeRect = barcodeRectangle;
                }
                else
                {
                    string printStr = "";
                    foreach (var item in printItem)
                    {
                        printStr += (item.StartStr == null ? "" : item.StartStr) + item.Value + (item.EndStr == null ? "" : item.EndStr);
                    }
                    Ibarcodes.BarcodeValue = printStr;
                    barcodeRectangle = Ibarcodes.GetBarcodeRectangle();
                    Ibarcodes.BarcodeRect = barcodeRectangle;
                    Ibarcodes.CreateBarcode(g);
                }

                if (Selected)
                {
                    using (Pen pen = new Pen(Color.SkyBlue))
                    {
                        pen.DashStyle = DashStyle.Custom;
                        pen.DashPattern = new float[] { 3f, 3f };
                        g.DrawRectangle(pen, barcodeRectangle.X - 2, barcodeRectangle.Y - 2, barcodeRectangle.Width + 4, barcodeRectangle.Height + 4);

                        g.DrawLine(pen, 0, barcodeRectangle.Y - 2, barcodeRectangle.X - 2, barcodeRectangle.Y - 2);
                        g.DrawLine(pen, barcodeRectangle.X - 2, 0, barcodeRectangle.X - 2, barcodeRectangle.Y - 2);

                        Point xyNotice;
                        int fontHeight = new Font("Verdana", 7).Height;
                        if (barcodeRectangle.Y < fontHeight)
                        {
                            xyNotice = new Point(barcodeRectangle.X, barcodeRectangle.Y + barcodeRectangle.Height + 2);
                        }
                        else
                        {
                            xyNotice = new Point(barcodeRectangle.X + 2, barcodeRectangle.Y - fontHeight - 2);
                        }
                        g.DrawString(string.Format("[X:{0} Y:{1}][W:{2} H:{3}]", (int)CommonSettings.PixelConvertMillimeter(barcodeRectangle.X), (int)CommonSettings.PixelConvertMillimeter(barcodeRectangle.Y), (int)CommonSettings.PixelConvertMillimeter(barcodeRectangle.Width), (int)CommonSettings.PixelConvertMillimeter(barcodeRectangle.Height)), new Font("Verdana", 7), Brushes.Blue, xyNotice);

                    }
                }
            }
            catch (Exception ex)
            {
                using (Pen pen = new Pen(Color.SkyBlue))
                {
                    g.DrawString(ex.Message + "\n\rValue:[" + sValueText + "]", new Font("Tahoma", 8), Brushes.Red, barcodeRectangle);
                    pen.DashStyle = DashStyle.Custom;
                    pen.DashPattern = new float[] { 5, 2 };
                    g.DrawRectangle(pen, barcodeRectangle.X - 2, barcodeRectangle.Y - 2, barcodeRectangle.Width + 4, barcodeRectangle.Height + 4);
                }
            }
        }



        /// <summary>
        /// 测试鼠标的当前位置有没有在对像上
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override int HitTest(Point point)
        {
            //在对像上但不是在手柄上
            if (PointInObject(point))
            {
                return 0;
            }
            //不在对像上
            return -1;
        }

        /// <summary>
        /// 检查点是否在矩形上
        /// </summary>
        /// <param name="point">要检查的点</param>
        /// <returns></returns>
        protected override bool PointInObject(Point point)
        {
            return barcodeRectangle.Contains(point);
        }

        /// <summary>
        /// 选择的矩形是否包含对像区域
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public override bool IntersectsWith(Rectangle selectRect)
        {
            return selectRect.Contains(barcodeRectangle);
        }

        /// <summary>
        /// 移动对像到坐标点上
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public override void Move(int deltaX, int deltaY)
        {
            barcodeRectangle.X += deltaX;
            barcodeRectangle.Y += deltaY;
        }


    }
}
