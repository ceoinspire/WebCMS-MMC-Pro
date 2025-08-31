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


        private static readonly string Passphrase = "MySuperSecretPassword"; // keep safe!
        private const int Iterations = 100_000;
        private const int KeySizeBits = 256;

        public static string RandomEncrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = KeySizeBits;

            // Generate salt + IV
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            var kdf = new Rfc2898DeriveBytes(Passphrase, salt, Iterations, HashAlgorithmName.SHA256);
            aes.Key = kdf.GetBytes(KeySizeBits / 8);
            aes.GenerateIV();

            using var ms = new MemoryStream();
            ms.Write(salt, 0, salt.Length);
            ms.Write(aes.IV, 0, aes.IV.Length);

            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            using (var sw = new StreamWriter(cs, Encoding.UTF8))
                sw.Write(plainText);

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string RandomDecrypt(string cipherText)
        {
            byte[] blob = Convert.FromBase64String(cipherText);

            // Extract salt + IV
            byte[] salt = new byte[16];
            byte[] iv = new byte[16];
            Buffer.BlockCopy(blob, 0, salt, 0, 16);
            Buffer.BlockCopy(blob, 16, iv, 0, 16);
            byte[] cipher = new byte[blob.Length - 32];
            Buffer.BlockCopy(blob, 32, cipher, 0, cipher.Length);

            using var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = KeySizeBits;

            var kdf = new Rfc2898DeriveBytes(Passphrase, salt, Iterations, HashAlgorithmName.SHA256);
            aes.Key = kdf.GetBytes(KeySizeBits / 8);
            aes.IV = iv;

            using var ms = new MemoryStream(cipher);
            using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using var sr = new StreamReader(cs, Encoding.UTF8);
            return sr.ReadToEnd();
        }

    }
}
