using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Twitchdouken
{
    // CODE DERIVED FROM http://www.codeproject.com/Articles/769741/Csharp-AES-bits-Encryption-Library-with-Salt
    public static class Encryption
    {
        private static byte[] AESEncrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // salt bytes must be at least 8 bytes.
            byte[] salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, salt, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (CryptoStream cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private static byte[] AESDecrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // the salt must be at least 8 bytes
            byte[] salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, salt, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (CryptoStream cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        public static string Encrypt(string text, string password)
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(text);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AESEncrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        public static string Decrypt(string text, string password)
        {
            byte[] bytesToBeDecrypted = Convert.FromBase64String(text);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AESDecrypt(bytesToBeDecrypted, passwordBytes);

            string result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }
    }
}
