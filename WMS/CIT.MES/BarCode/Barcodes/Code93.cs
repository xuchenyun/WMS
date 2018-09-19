using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Specialized;

namespace CIT.MES.BarCode
{
    [Serializable]
    internal class Code93 : IBarcode
    {
        public Code93()
        {
            code0["0"] = "100010100";
            code0["1"] = "101001000";
            code0["2"] = "101000100";
            code0["3"] = "101000010";
            code0["4"] = "100101000";
            code0["5"] = "100100100";
            code0["6"] = "100100010";
            code0["7"] = "101010000";
            code0["8"] = "100010010";
            code0["9"] = "100001010";
            code0["A"] = "110101000";
            code0["B"] = "110100100";
            code0["C"] = "110100010";
            code0["D"] = "110010100";
            code0["E"] = "110010010";
            code0["F"] = "110001010";
            code0["G"] = "101101000";
            code0["H"] = "101100100";
            code0["I"] = "101100010";
            code0["J"] = "100110100";
            code0["K"] = "100011010";
            code0["L"] = "101011000";
            code0["M"] = "101001100";
            code0["N"] = "101000110";
            code0["O"] = "100101100";
            code0["P"] = "100010110";
            code0["Q"] = "110110100";
            code0["R"] = "110110010";
            code0["S"] = "110101100";
            code0["T"] = "110100110";
            code0["U"] = "110010110";
            code0["V"] = "110011010";
            code0["W"] = "101101100";
            code0["X"] = "101100110";
            code0["Y"] = "100110110";
            code0["Z"] = "100111010";
            code0["-"] = "100101110";
            code0["."] = "111010100";
            code0[" "] = "111010010";
            code0["$"] = "111001010";
            code0["/"] = "101101110";
            code0["+"] = "101101110";
            code0["%"] = "110101110";
            code0["SHIFT1"] = "100100110";
            code0["SHIFT2"] = "111011010";
            code0["SHIFT3"] = "111010110";
            code0["SHIFT4"] = "100110010";
            code0["START"] = "101011110";
            code0["STOP"] = "1010111101";

            code1["0"] = "0";
            code1["1"] = "1";
            code1["2"] = "2";
            code1["3"] = "3";
            code1["4"] = "4";
            code1["5"] = "5";
            code1["6"] = "6";
            code1["7"] = "7";
            code1["8"] = "8";
            code1["9"] = "9";
            code1["A"] = "10";
            code1["B"] = "11";
            code1["C"] = "12";
            code1["D"] = "13";
            code1["E"] = "14";
            code1["F"] = "15";
            code1["G"] = "16";
            code1["H"] = "17";
            code1["I"] = "18";
            code1["J"] = "19";
            code1["K"] = "20";
            code1["L"] = "21";
            code1["M"] = "22";
            code1["N"] = "23";
            code1["O"] = "24";
            code1["P"] = "25";
            code1["Q"] = "26";
            code1["R"] = "27";
            code1["S"] = "28";
            code1["T"] = "29";
            code1["U"] = "30";
            code1["V"] = "31";
            code1["W"] = "32";
            code1["X"] = "33";
            code1["Y"] = "34";
            code1["Z"] = "35";
            code1["-"] = "36";
            code1["."] = "37";
            code1[" "] = "38";
            code1["$"] = "39";
            code1["/"] = "40";
            code1["+"] = "41";
            code1["%"] = "42";
            code1["SHIFT1"] = "43";
            code1["SHIFT2"] = "44";
            code1["SHIFT3"] = "45";
            code1["SHIFT4"] = "46";
            code1["START"] = "47";
            code1["STOP"] = "48";

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
        private String code = "DATA";
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
        private int wideToNarrowRatio = 1;
        /// <summary>
        /// 变量名称
        /// </summary>
        private string id = "";
        #endregion

        #region Base String Value
        private NameValueCollection code0 = new NameValueCollection(49);
        private NameValueCollection code1 = new NameValueCollection(49);

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
                String str = code.ToUpper();
                strLength = str.Length;
                encodedString = code0["START"];
                for (int i = 0; i < strLength; i++)
                {
                    encodedString += code0[str[i].ToString()];
                }
                encodedString += GetCheckC_KValue();
                encodedString += code0["STOP"];
            }
            catch
            {
                throw new Exception("无法编码!");
            }

        }
        #endregion

        private string GetCheckC_KValue()
        {
            int sum = 0, cValue = 0;
            int codeLength = code.Length;
            for (int i = 1; i <= code.Length; i++)
            {
                sum += int.Parse(code1[code[i - 1].ToString()]) * codeLength;
                codeLength--;
            }
            cValue = sum % 47;
            GetCheckKValue(cValue);
            return code0[cValue] + GetCheckKValue(cValue);
        }
        private string GetCheckKValue(int cvlaue)
        {
            int sum = 0, kValue = 0;
            int codeLength = code.Length + 1;
            for (int i = 1; i <= code.Length; i++)
            {
                sum += int.Parse(code1[code[i - 1].ToString()]) * codeLength;
                codeLength--;
            }
            kValue = (sum + cvlaue) % 47;
            return code0[kValue];
        }

        #region Create Barcode
        public void CreateBarcode(Graphics g)
        {
            //g.DrawString("Code 39", new Font("Vendana", 9), Brushes.Blue, barcodeRect);
            g.SetClip(barcodeRect);
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

            int encodedStringLength = encodedString.Length;

            int x = (int)barcodeRect.X;
            int wid = 0;
            int yTop = (int)barcodeRect.Y;
            yTop = (int)barcodeRect.Y;

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
                {
                    wid = (int)(wideToNarrowRatio * (int)weight + 0.5);
                    g.FillRectangle(Brushes.Black, x, yTop, wid, height);
                }
                else
                {
                    wid = (int)(wideToNarrowRatio * (int)weight + 0.5);
                }


                x += wid;
            }
            g.Restore(state);
            g.ResetClip();


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
