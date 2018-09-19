using System.IO;
using System.Text;

namespace CIT.LUtils
{
	internal class FileUtils
	{
		public static string ReadTempFile(string FilePath)
		{
			if (File.Exists(FilePath))
			{
				using (StreamReader streamReader = new StreamReader(FilePath, Encoding.UTF8))
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append(streamReader.ReadToEnd());
					streamReader.Close();
					return stringBuilder.ToString();
				}
			}
			return "Not Exist File";
		}
	}
}
