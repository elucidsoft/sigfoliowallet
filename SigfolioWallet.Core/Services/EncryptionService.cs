using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Core.Services
{
    public class EncryptionService : IEncryptionService
    {
        private const int Iterations = 1000000;

        public (byte[] EncryptedBytes, EncryptionKeys EncryptionKeys) Encrypt(byte[] password, string secret)
        {
            var salt = new byte[64];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(salt);
            }

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations);

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

                return (EncryptedBytes: memoryStream.ToArray(), new EncryptionKeys(salt, encryptionAlgorithm.IV));
            }
        }

        public string Decrypt(byte[] password, Account account)
        {
            var decryptionAlgorithm = TripleDES.Create();
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, account.EncryptionKeys.SaltBytes, Iterations);

            decryptionAlgorithm.Key = rfc2898DeriveBytes.GetBytes(16);
            decryptionAlgorithm.IV = account.EncryptionKeys.IvBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var encrypt = new CryptoStream(memoryStream, decryptionAlgorithm.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    encrypt.Write(account.EncryptedPrivateKey, 0, account.EncryptedPrivateKey.Length);
                    encrypt.Flush();
                }

                var decrypted = Encoding.UTF8.GetString(memoryStream.ToArray());

                return decrypted;
            }
        }
    }
}