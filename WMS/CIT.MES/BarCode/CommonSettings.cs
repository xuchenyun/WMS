using System;
using System.Collections.Generic;
using System.Text;

namespace CIT.MES
{
    public class CommonSettings
    {
        /// <summary>
        /// 把像素换算成毫米
        /// </summary>
        /// <param name="Pixel">多少像素</param>
        /// <returns>多少毫米</returns>
        public static float PixelConvertMillimeter(float Pixel)
        {
            return Pixel / 96 * 25.4f;
        }
        
        /// <summary>
        /// 把毫米换算成像素
        /// </summary>
        /// <param name="Millimeter">多少毫米</param>
        /// <returns>多少像素</returns>
        public static int MillimeterConvertPixel(float Millimeter)
        {
            return ((int)(Millimeter / 25.4 * 96)+1);
        }
    }
}
