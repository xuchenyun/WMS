using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace CIT.LUtils.Common
{
	public class Utils
	{
		private static string keys = "C.I.t.ks";

		public static byte[] SerializeObject(object obj)
		{
			if (obj == null)
			{
				return null;
			}
			MemoryStream memoryStream = new MemoryStream();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(memoryStream, obj);
			memoryStream.Position = 0L;
			byte[] array = new byte[memoryStream.Length];
			memoryStream.Read(array, 0, array.Length);
			memoryStream.Close();
			return array;
		}

		public static void Serial(string FilePath, LicObj obj)
		{
			using (FileStream fileStream = new FileStream(FilePath, FileMode.Create))
			{
				byte[] inputByteArray = SerializeObject(obj);
				inputByteArray = Encry.EncryptDES(inputByteArray, keys);
				fileStream.Write(inputByteArray, 0, inputByteArray.Length);
			}
		}

		public static LicObj DeserializeObject(string Filepath)
		{
			using (FileStream fileStream = new FileStream(Filepath, FileMode.Open))
			{
				fileStream.Seek(0L, SeekOrigin.Begin);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				array = Encry.DecryptDES(array, "C.I.t.ks");
				LicObj result = null;
				if (array != null)
				{
					using (MemoryStream memoryStream = new MemoryStream(array))
					{
						memoryStream.Position = 0L;
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						result = (binaryFormatter.Deserialize(memoryStream) as LicObj);
						memoryStream.Close();
						return result;
					}
				}
				return result;
			}
		}

		public static void ShowUCControl(Panel parentFrm, UserControl chiFrm)
		{
			parentFrm.Controls.Clear();
			parentFrm.Controls.Add(chiFrm);
			chiFrm.Dock = DockStyle.Fill;
			chiFrm.Show();
		}

		public static void WriteNewTempFile(string filepath, string loginfo, string context)
		{
			if (!Directory.Exists(filepath))
			{
				Directory.CreateDirectory(filepath);
			}
			FileStream fileStream = null;
			try
			{
				using (fileStream = new FileStream(filepath + loginfo, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
				{
					using (StreamWriter streamWriter = new StreamWriter(fileStream))
					{
						streamWriter.WriteLine(context);
						streamWriter.Close();
					}
				}
			}
			catch
			{
			}
			finally
			{
				try
				{
					fileStream.Close();
				}
				catch
				{
				}
			}
		}
	}
}
