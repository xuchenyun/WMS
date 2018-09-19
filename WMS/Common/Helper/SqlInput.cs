using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Helper
{

    public class SqlInput
    {

        #region 对SQL查询条件过滤
        /// <summary>
        /// 对SQL查询条件过滤
        /// </summary>
        /// <param name="sqlValue"></param>
        /// <returns></returns>
        public static string InputString(string sqlValue)
        {
            return sqlValue.Replace("'", "''").Trim();
        }
        #endregion

        #region 将Object值转换为字符串,空值则转换为空字符串
        /// <summary>
        /// 将Object值转换为字符串,空值则转换为空字符串
        /// </summary>
        /// <returns></returns>
        public static string ChangeNullToString(object value)
        {
            if(value==null||value==DBNull.Value)
            {
                return "";
            }
            return value.ToString();
        }
        #endregion

        #region 将Object值转换为整型数值,空值则转换为指定的数值
        /// <summary>
        /// 将Object值转换为整型数值,空值则转换为指定的数值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nullValue"></param>
        /// <returns></returns>
        public static int ChangeNullToInt(object value,int nullValue)
        {
            int returnValue;
            try
            {
                returnValue = Convert.ToInt32(value);
            }
            catch
            {
                returnValue = nullValue;
            }
            return returnValue;
        }
        #endregion

        #region 将Object值转换为Decimal数值,空值则转换为指定的数值
        /// <summary>
        /// 将Object值转换为Decimal数值,空值则转换为指定的数值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nullValue"></param>
        /// <returns></returns>
        public static decimal ChangeNullToDecimal(object value, decimal nullValue)
        {
            decimal returnValue;
            try
            {
                returnValue = Convert.ToDecimal(value);
            }
            catch
            {
                returnValue = nullValue;
            }
            return returnValue;
        }
        #endregion

        #region 将Object值转换为Double,空值则转换为指定的数值
        /// <summary>
        /// 将Object值转换为Double,空值则转换为指定的数值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nullValue"></param>
        /// <returns></returns>
        public static double ChangeNullToDouble(object value, double nullValue)
        {
            double returnValue;
            try
            {
                returnValue = Convert.ToDouble(value);
            }
            catch
            {
                returnValue = nullValue;
            }
            return returnValue;
        }
        #endregion

        #region 将Object值转换为字符串,空值或空字符串则转换为指定字符串
        /// <summary>
        /// 将Object值转换为字符串,空值或空字符串则转换为指定字符串
        /// </summary>
        /// <returns></returns>
        public static string ChangeNullToValueString(object value,string strValue)
        {
            if (value == null || value == DBNull.Value || value.ToString()=="")
            {
                return strValue;
            }
            return value.ToString();
        }
        #endregion

        #region 将Object值转为BOOL值,空值或错误值转换为指定BOOL值
        /// <summary>
        /// 将Object值转为BOOL值,空值或错误值转换为指定BOOL值
        /// </summary>
        public static bool ChangeBoolToValue(object value,bool bolValue)
        {
            bool returnValue;
            if (!bool.TryParse(value.ToString(),out returnValue))
            {
                returnValue = bolValue;
            }
            return returnValue;
        }
        #endregion

        #region 将Object值转为DateTime值,空值或错误值转换为指定DateTime值
        /// <summary>
        /// 将Object值转为DateTime值,空值或错误值转换为指定DateTime值
        /// </summary>
        public static DateTime ChangeDateTimeToValue(object value, DateTime dateValue)
        {
            DateTime returnValue;
            try
            {
                returnValue = Convert.ToDateTime(value);
            }
            catch
            {
                returnValue = dateValue;
            }
            return returnValue;
        }
        #endregion

        #region 获取整数部分和小数点后指定位数

        /// <summary>
        /// 获取整数部分和小数点后指定位数
        /// </summary>
        /// <param name="numValue"></param>
        /// <param name="numSmall"></param>
        /// <returns></returns>
        public static decimal GetValueAndSmall(object numValue, int numSmall)
        {
            try
            {
                decimal num = decimal.Parse(numValue.ToString());
            }
            catch
            {
                return 0;
            }
            decimal returnValue=decimal.Parse(numValue.ToString());
            if (numSmall < 0)
            {
                return returnValue;
            }
            string strValue = numValue.ToString();
            int index = strValue.IndexOf('.');
            if (index == -1)
            {
                return returnValue;
            }
            int valueIndex = strValue.Length - index;
            if (valueIndex <= (numSmall + 1))
            {
                return DropSmallZero(returnValue);
            }
            strValue = strValue.Substring(0, (index + numSmall + 1));
            return DropSmallZero(decimal.Parse(strValue));
        }
        #endregion

        #region 去除小数后末尾的0数

        /// <summary>
        /// 去除小数后末尾的0数

        /// </summary>
        /// <param name="dropValue"></param>
        /// <returns></returns>
        public static decimal DropSmallZero(decimal dropValue)
        {
            string smallValue = dropValue.ToString();
            char chValue = smallValue[smallValue.Length - 1];
            while (chValue == '0')
            {
                smallValue = smallValue.Substring(0, smallValue.Length - 1);
                chValue = smallValue[smallValue.Length - 1];
            }
            if (chValue == '.')
            {
                smallValue = smallValue.Substring(0, smallValue.Length - 1);
            }
            return decimal.Parse(smallValue);
        }
        #endregion

    }

}
