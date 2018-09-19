using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public class Encrypt
    {
        #region MD5加密
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="ucons">账套信息</param>
        /// <param name="sqlcmd">SQL语句</param>
        /// <param name="sqlparameter">参数值</param>
        /// <returns></returns>
        public static string Encryption(string md5str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(md5str));
            string bytestr = null;
            for (int i = 0; i < result.Length; i++)
            {
                bytestr += result[i];
            }
            return bytestr;
        }
        #endregion
    }
}
