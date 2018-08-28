using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Core.Services
{
    public class EncryptionService : IEncryptionService
    {
        private const int Iterations = 1000000;

        public (byte[] EncryptedBytes, byte[] Salt, byte[] IV) Encrypt(string password, string secret)
        {
            var salt = new byte[64];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(salt);
            }

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes("password", salt, Iterations);

            var encryptionAlgorithm = TripleDES.Create();
            encryptionAlgorithm.Key = rfc2898DeriveBytes.GetBytes(16);

            var dataBytes = Encoding.UTF8.GetBytes(secret);

            using (var memoryStream = new MemoryStream())
            {
                using (var encrypt = new CryptoStream(memoryStream, encryptionAlgorithm.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    encrypt.Write(dataBytes, 0, dataBytes.Length);
                    encrypt.FlushFinalBlock();
                }

                return (EncryptedBytes: memoryStream.ToArray(), Salt: salt, IV: encryptionAlgorithm.IV);
            }
        }

        public string Decrypt(string password, byte[] encryptedData, byte[] salt, byte[] iv)
        {
            var decryptionAlgorithm = TripleDES.Create();
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes("password", salt, Iterations);

            decryptionAlgorithm.Key = rfc2898DeriveBytes.GetBytes(16);
            decryptionAlgorithm.IV = iv;

            using (var memoryStream = new MemoryStream())
            {
                using (var encrypt = new CryptoStream(memoryStream, decryptionAlgorithm.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    encrypt.Write(encryptedData, 0, encryptedData.Length);
                    encrypt.Flush();
                }

                var decrypted = Encoding.UTF8.GetString(memoryStream.ToArray());

                return decrypted;
            }
        }
    }
}