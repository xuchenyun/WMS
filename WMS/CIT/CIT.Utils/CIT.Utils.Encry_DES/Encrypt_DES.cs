using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CIT.Utils.Encry_DES
{
	public class Encrypt_DES
	{
		private static byte[] Keys = new byte[8]
		{
			18,
			52,
			86,
			120,
			144,
			171,
			205,
			239
		};

		public static string EncryptDES(string encryptString, string encryptKey)
		{
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
				byte[] keys = Keys;
				byte[] bytes2 = Encoding.UTF8.GetBytes(encryptString);
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, keys), CryptoStreamMode.Write);
				cryptoStream.Write(bytes2, 0, bytes2.Length);
				cryptoStream.FlushFinalBlock();
				return Convert.ToBase64String(memoryStream.ToArray());
			}
			catch
			{
				return encryptString;
			}
		}

		public static string DecryptDES(string decryptString, string decryptKey)
		{
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(decryptKey);
				byte[] keys = Keys;
				byte[] array = Convert.FromBase64String(decryptString);
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, keys), CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
				return Encoding.UTF8.GetString(memoryStream.ToArray());
			}
			catch
			{
				return decryptString;
			}
		}
	}
}
