using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace CIT.MES.BarCode
{
    public interface IBarcode
    {
        void CreateBarcode(Graphics graphics);
        Rectangle BarcodeRect { get; set; }
        bool ShowText { get; set; }
        bool ShowTextOnTop { get; set; }
        BarcodeTextAlign barcodeTextAlign { get; set; }
        int BarcodeHeight { get; set; }
        string BarcodeValue { get; set; }
        BarcodeRotation barcodeRotation { get; set; }
        Font ValueTextFont { get; set; }
        BarCodeWeight BarcodeWeight { get; set; }
        Rectangle GetBarcodeRectangle();
    }
}
