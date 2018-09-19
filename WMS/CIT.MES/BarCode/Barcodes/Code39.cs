using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CIT.MES.BarCode
{
    [Serializable]
    internal class Code39 : IBarcode
    {
        public Code39()
        {
            EncodeBarcodeValue();
        }

        #region Variable
        /// <summary>
        /// 是否显示条码的值
        /// </summary>
        private bool bShowText = true;
        /// <summary>
        /// 是否在条码上方显示字符
        /// </summary>
        private bool bShowTextOnTop = false;
        /// <summary>
        /// 条码值的对值的对齐方式
        /// </summary>
        private BarcodeTextAlign align = BarcodeTextAlign.Left;
        /// <summary>
        /// 条码的做图区域
        /// </summary>
        private Rectangle barcodeRect;
        /// <summary>
        /// 条码的值
        /// </summary>
        private String code = "0123456";
        /// <summary>
        /// 条码的高度
        /// </summary>
        private int height = 30;
        /// <summary>
        /// 条码的大小
        /// </summary>
        private BarCodeWeight weight = BarCodeWeight.Small;
        /// <summary>
        /// 旋转
        /// </summary>
        private BarcodeRotation Rotation = BarcodeRotation.Rotation90;
        /// <summary>
        /// 条码的字体
        /// </summary>
        private Font textFont = new Font("Courier", 8);
        /// <summary>
        /// 将条码数据编码
        /// </summary>
        private String encodedString = "";
        /// <summary>
        /// 条码值的长度
        /// </summary>
        private int strLength = 0;
        /// <summary>
        /// 条码的比率
        /// </summary>
        private int wideToNarrowRatio = 2;
        /// <summary>
        /// 变量名称
        /// </summary>
        private string id = "";
        #endregion

        #region Base String Value
        String alphabet39 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*";

        String[] coded39Char = 
		{
			/* 0 */ "000110100", 
			/* 1 */ "100100001", 
			/* 2 */ "001100001", 
			/* 3 */ "101100000",
			/* 4 */ "000110001", 
			/* 5 */ "100110000", 
			/* 6 */ "001110000", 
			/* 7 */ "000100101",
			/* 8 */ "100100100", 
			/* 9 */ "001100100", 
			/* A */ "100001001", 
			/* B */ "001001001",
			/* C */ "101001000", 
			/* D */ "000011001", 
			/* E */ "100011000", 
			/* F */ "001011000",
			/* G */ "000001101", 
			/* H */ "100001100", 
			/* I */ "001001100", 
			/* J */ "000011100",
			/* K */ "100000011", 
			/* L */ "001000011", 
			/* M */ "101000010", 
			/* N */ "000010011",
			/* O */ "100010010", 
			/* P */ "001010010", 
			/* Q */ "000000111", 
			/* R */ "100000110",
			/* S */ "001000110", 
			/* T */ "000010110", 
			/* U */ "110000001", 
			/* V */ "011000001",
			/* W */ "111000000", 
			/* X */ "010010001", 
			/* Y */ "110010000", 
			/* Z */ "011010000",
			/* - */ "010000101", 
			/* . */ "110000100", 
			/*' '*/ "011000100",
			/* $ */ "010101000",
			/* / */ "010100010", 
			/* + */ "010001010", 
			/* % */ "000101010", 
			/* * */ "010010100" 
		};
        #endregion

        #region Barcode attribute

        /// <summary>
        /// get or set Barcode Height
        /// </summary>
        public int BarcodeHeight
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Get or Set Barcode Value
        /// </summary>
        public String BarcodeValue
        {
            get { return code; }
            set
            {
                code = value.ToUpper();
                EncodeBarcodeValue();
            }
        }

        /// <summary>
        /// get or set baroce weight
        /// </summary>
        public BarCodeWeight BarcodeWeight
        {
            get { return weight; }
            set { weight = value; }
        }

        /// <summary>
        /// get or set barocde draw range
        /// </summary>
        public Rectangle BarcodeRect
        {
            get { return barcodeRect; }
            set { barcodeRect = value; }
        }

        /// <summary>
        /// get or set show value text
        /// </summary>
        public bool ShowText
        {
            get { return bShowText; }
            set { bShowText = value; }
        }
        /// <summary>
        /// get or set show value text on barcode top
        /// </summary>
        public bool ShowTextOnTop
        {
            get { return bShowTextOnTop; }
            set { bShowTextOnTop = value; }
        }
        /// <summary>
        /// get or set value text font
        /// </summary>
        public Font ValueTextFont
        {
            get { return textFont; }
            set { textFont = value; }
        }

        /// <summary>
        /// get or set value text align
        /// </summary>
        public BarcodeTextAlign barcodeTextAlign
        {
            get { return align; }
            set { align = value; }
        }
        /// <summary>
        /// get or set barcode rotation
        /// </summary>
        public BarcodeRotation barcodeRotation
        {
            get { return Rotation; }
            set { Rotation = value; }
        }
        /// <summary>
        /// declare temp value
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        #region Encode barcode string
        /// <summary>
        /// 对条码的值进行编码
        /// </summary>
        private void EncodeBarcodeValue()
        {
            try
            {
                String intercharacterGap = "0";
                String str = '*' + code.ToUpper() + '*';
                strLength = str.Length;
                encodedString = "";
                for (int i = 0; i < strLength; i++)
                {
                    if (i > 0)
                        encodedString += intercharacterGap;

                    encodedString += coded39Char[alphabet39.IndexOf(str[i])];
                }
            }
            catch
            {
                throw new Exception("无法编码!");
            }

        }
        #endregion

        #region Create Barcode
        public void CreateBarcode(Graphics g)
        {
            //g.DrawString("Code 39", new Font("Vendana", 9), Brushes.Blue, barcodeRect);
            // g.SetClip(barcodeRect);
            GraphicsState state = g.Save();
            Matrix RotationTransform = new Matrix(1, 0, 0, 1, 1, 1); //rotation matrix

            PointF TheRotationPoint;
            switch (Rotation)
            {
                case BarcodeRotation.Rotation90:
                    TheRotationPoint = new PointF(barcodeRect.X, barcodeRect.Y);
                    RotationTransform.RotateAt(90, TheRotationPoint);
                    g.Transform = RotationTransform;
                    g.TranslateTransform(0, -barcodeRect.Width);
                    break;
                case BarcodeRotation.Rotation270:
                    TheRotationPoint = new PointF(barcodeRect.X, barcodeRect.Y + barcodeRect.Height);
                    RotationTransform.RotateAt(270, TheRotationPoint);
                    g.Transform = RotationTransform;
                    g.TranslateTransform(0, barcodeRect.Height);
                    break;
            }
            bool bchkValueText = false;
            for (int i = 0; i < code.Length; i++)
            {
                if (alphabet39.IndexOf(code[i]) == -1 || code[i] == '*')
                {
                    g.DrawString("条码文本无效!", textFont, Brushes.Red, barcodeRect.X, barcodeRect.Y);
                    bchkValueText = true;
                    break;
                }
            }
            if (!bchkValueText)
            {
                int encodedStringLength = encodedString.Length;

                float x = barcodeRect.X;
                float wid = 0;
                int yTop = (int)barcodeRect.Y;

                if (bShowText)
                {
                    using (StringFormat sf = new StringFormat())
                    {
                        switch (align)
                        {
                            case BarcodeTextAlign.Left:
                                sf.Alignment = StringAlignment.Near;
                                break;
                            case BarcodeTextAlign.Center:
                                sf.Alignment = StringAlignment.Center;
                                break;
                            case BarcodeTextAlign.Right:
                                sf.Alignment = StringAlignment.Far;
                                break;
                        }
                        switch (Rotation)
                        {
                            case BarcodeRotation.Rotation90:
                                break;
                            case BarcodeRotation.Rotation270:
                                break;
                        }
                        if (bShowTextOnTop)
                        {
                            //yTop += height;
                            if (Rotation == BarcodeRotation.Rotation0)
                            {
                                g.DrawString(code, textFont, Brushes.Black, new RectangleF(barcodeRect.X, yTop, barcodeRect.Width, g.MeasureString("s", textFont).Height), sf);
                            }
                            else
                            {
                                g.DrawString(code, textFont, Brushes.Black, new RectangleF(barcodeRect.X, yTop, barcodeRect.Height, g.MeasureString("s", textFont).Height), sf);
                            }
                            yTop += Convert.ToInt32(g.MeasureString("s", textFont).Height);
                        }
                        else
                        {
                            yTop += height;
                            if (Rotation == BarcodeRotation.Rotation0)
                            {
                                g.DrawString(code, textFont, Brushes.Black, new RectangleF(barcodeRect.X, yTop, barcodeRect.Width, barcodeRect.Height - height), sf);
                            }
                            else
                            {
                                g.DrawString(code, textFont, Brushes.Black, new RectangleF(barcodeRect.X, yTop, barcodeRect.Height, barcodeRect.Width), sf);
                            }
                            yTop -= height;

                        }
                    }
                }
                for (int i = 0; i < encodedStringLength; i++)
                {
                    if (encodedString[i] == '1')
                        wid = (wideToNarrowRatio * (int)weight);
                    else
                        wid = (int)weight;

                    g.FillRectangle(i % 2 == 0 ? Brushes.Black : Brushes.White, x, yTop, wid, height);

                    x += wid;
                }
            }
            g.Restore(state);
            //g.ResetClip();


        }
        #endregion

        #region Barcode draw rectangle
        public Rectangle GetBarcodeRectangle()
        {

            int wid = 0, RectW = 0, RectH = 0;
            //for (int i = 0; i < code.Length; i++)
            //{
            //    if (alphabet39.IndexOf(code[i]) == -1 || code[i] == '*')
            //    {                    
            //        return new RectangleF(0, 0, 100, 100);
            //    }
            //}      
            for (int i = 0; i < encodedString.Length; i++)
            {
                if (encodedString[i] == '1')
                    wid = wideToNarrowRatio * (int)weight;
                else
                    wid = (int)weight;
                RectW += wid;
            }

            if (bShowText)
            {
                using (Graphics g = Graphics.FromImage(new Bitmap(10, 10)))
                {
                    RectH = (int)g.MeasureString("S", textFont).Height + height;
                }
            }
            else
            {
                RectH = height;
            }
            switch (Rotation)
            {
                case BarcodeRotation.Rotation90:
                    return new Rectangle(barcodeRect.X, barcodeRect.Y, RectH, RectW);
                // break;
                case BarcodeRotation.Rotation270:
                    return new Rectangle(barcodeRect.X, barcodeRect.Y, RectH, RectW);
                // break;
            }

            return new Rectangle(barcodeRect.X, barcodeRect.Y, RectW, RectH);
        }
        #endregion
    }
}
