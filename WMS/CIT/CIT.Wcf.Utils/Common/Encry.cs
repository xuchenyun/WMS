using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CIT.LUtils.Common
{
	public class Encry
	{
		private static byte[] Keys = Encoding.ASCII.GetBytes("mkKEjiGS");

		private Encry()
		{
		}

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
				StringBuilder stringBuilder = new StringBuilder();
				byte[] array = memoryStream.ToArray();
				foreach (byte b in array)
				{
					stringBuilder.AppendFormat("{0:X2}", b);
				}
				return stringBuilder.ToString();
			}
			catch
			{
				return encryptString;
			}
		}

		public static byte[] EncryptDES(byte[] inputByteArray, string encryptKey)
		{
			StringBuilder stringBuilder = new StringBuilder();
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
				byte[] keys = Keys;
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, keys), CryptoStreamMode.Write);
				cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
				cryptoStream.FlushFinalBlock();
				return memoryStream.ToArray();
			}
			catch
			{
				return inputByteArray;
			}
		}

		public static string DecryptDES(string decryptString, string decryptKey)
		{
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(decryptKey);
				byte[] keys = Keys;
				int num = decryptString.Length / 2 - 1;
				byte[] array = new byte[num + 1];
				for (int i = 0; i <= num; i++)
				{
					int num2 = Convert.ToInt32(decryptString.Substring(i * 2, 2), 16);
					array[i] = (byte)num2;
				}
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

		public static byte[] DecryptDES(byte[] temp, string decryptKey)
		{
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(decryptKey);
				byte[] keys = Keys;
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, keys), CryptoStreamMode.Write);
				cryptoStream.Write(temp, 0, temp.Length);
				cryptoStream.FlushFinalBlock();
				return memoryStream.ToArray();
			}
			catch
			{
				return temp;
			}
		}

		public static string MD5Encrypt(string strText)
		{
			string text = "";
			MD5 mD = MD5.Create();
			byte[] array = mD.ComputeHash(Encoding.UTF8.GetBytes(strText));
			for (int i = 0; i < array.Length; i++)
			{
				text += array[i].ToString("X");
			}
			return text;
		}
	}
}
