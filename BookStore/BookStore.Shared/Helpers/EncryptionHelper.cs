using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BookStore.Shared.Helpers
{
    public static class EncryptionHelper
    {
        public static string Encrypt(this string clearText, string key)
        {
            if (clearText.IsNullOrWhiteSpace()) return null;
            var clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var encrypt = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encrypt.Key = pdb.GetBytes(32);
                encrypt.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encrypt.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(this string cipherText, string key)
        {
            try
            {
                if (!cipherText.IsNullOrWhiteSpace())
                {
                    cipherText = cipherText.Replace(" ", "+");
                    var cipherBytes = Convert.FromBase64String(cipherText);
                    using (var encrypt = Aes.Create())
                    {
                        var pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                        encrypt.Key = pdb.GetBytes(32);
                        encrypt.IV = pdb.GetBytes(16);
                        using (var ms = new MemoryStream())
                        {
                            using (var cs = new CryptoStream(ms, encrypt.CreateDecryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(cipherBytes, 0, cipherBytes.Length);
                                cs.Close();
                            }
                            cipherText = Encoding.Unicode.GetString(ms.ToArray());
                        }
                    }
                    return cipherText;
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return null;
        }

        public static Func<string> GenerateSecurityStamp = delegate ()
        {
            var guid = Guid.NewGuid();
            return string.Concat(Array.ConvertAll(guid.ToByteArray(), b => b.ToString("X2")));
        };
    }
}
