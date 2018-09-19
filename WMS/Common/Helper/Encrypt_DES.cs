using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
namespace Common.Helper
{
    public class Encrypt_DES
    {
        // Fields
        private static byte[] Keys = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };

        // Methods
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(decryptKey);
                byte[] keys = Keys;
                byte[] buffer = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(bytes, keys), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] keys = Keys;
                byte[] buffer = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(bytes, keys), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                return Convert.ToBase64String(stream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }
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
    }


}
