using System;
using System.Collections.Generic;
using System.Text;

namespace CIT.MES
{
    /// <summary>
    /// 设计从数据源取数据的时候
    /// 如果是Label:则只取X页中第一行中的数据
    /// 如果是Column:则根据当前行中的数据
    /// </summary>
    public enum DrawType
    {
        Label=0,
        Column
    }

    /// <summary>
    /// 设定条码的类型
    /// </summary>
    public enum BarcodeType : int
    {
        Code39 = 0,
        Code93,
        #region 2017.03.10 Simon.Li 添加QRCode
        QRcode, 
        #endregion
        Code128A,
        Code128B,
        Code128C,
        UCC_EAN128,
        EAN13,
        UPCA,
        Interleaved2of5,
        Standard2of5,
        Code11,
        Codabar,
        //UPC_E0,
        //UPC_E1,
        //UPC_SUPP2,
        //UPC_SUPP5,
        //Japan_Postal,
        //PDF417,
        DataMatrix
    }

    /// <summary>
    /// 条码文字的对齐方式 
    /// </summary>
    public enum BarcodeTextAlign : int
    {
        Left = 0,
        Center,
        Right
    }

    /// <summary>
    /// 二维码文字的对齐方式 
    /// </summary>
    public enum QRcodeTextAlign : int
    {
        Left = 0,
        Center,
        Right
    }

    /// <summary>
    /// 二维码的旋转角度
    /// </summary>
    public enum QRcodeRotation : int
    {
        Rotation0 = 0,
        Rotation90 = 90,
        Rotation270 = 270
    }

    /// <summary>
    /// 条码的旋转角度
    /// </summary>
    public enum BarcodeRotation : int
    {
        Rotation0 = 0,
        Rotation90 = 90,
        Rotation270 = 270
    }

    /// <summary>
    /// 条码的大小
    /// </summary>
    public enum QRCodeWeight : int
    {
        Small = 1, Medium, Large
    }

    /// <summary>
    /// 条码的大小
    /// </summary>
    public enum BarCodeWeight : int
    {
        Small = 1, Medium, Large
    }

    /// <summary>
    /// 标尺是水平的还是垂直的
    /// </summary>
    public enum Orientation
    {
        Horizontal=0,
        Vertical
    }

}
