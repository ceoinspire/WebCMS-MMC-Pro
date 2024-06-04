using System.Security.Cryptography;
using System.Text;

namespace MMC_Pro_Edition.Classes
{
	public static class EncryptionPasses
	{

		public static string Encrypt(string plainText, string INIT_VECTOR, string PASS_PHRASE, int KEY_SIZE)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(INIT_VECTOR);
			byte[] bytes2 = Encoding.UTF8.GetBytes(plainText);
			byte[] bytes3 = new PasswordDeriveBytes(PASS_PHRASE, null).GetBytes(KEY_SIZE / 8);
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateEncryptor(bytes3, bytes);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes2, 0, bytes2.Length);
			cryptoStream.FlushFinalBlock();
			byte[] inArray = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(inArray);
		}

		public static string Decrypt(string cipherText, string INIT_VECTOR, string PASS_PHRASE, int KEY_SIZE)
		{
			try
			{
				byte[] bytes = Encoding.ASCII.GetBytes(INIT_VECTOR);
				byte[] array = Convert.FromBase64String(cipherText);
				byte[] bytes2 = new PasswordDeriveBytes(PASS_PHRASE, null).GetBytes(KEY_SIZE / 8);
				ICryptoTransform transform = new RijndaelManaged
				{
					Mode = CipherMode.CBC
				}.CreateDecryptor(bytes2, bytes);
				MemoryStream memoryStream = new MemoryStream(array);
				CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
				byte[] array2 = new byte[array.Length];
				int count = cryptoStream.Read(array2, 0, array2.Length);
				memoryStream.Close();
				cryptoStream.Close();
				return Encoding.UTF8.GetString(array2, 0, count);
			}
			catch
			{
				return "";
			}
		}
	}
}
