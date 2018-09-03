using System.Threading.Tasks;
using SigfolioWallet.Core.Models;

namespace SigfolioWallet.Core.Services.Interfaces
{
    public interface IEncryptionService
    {
        (byte[] EncryptedBytes, EncryptionKeys EncryptionKeys) Encrypt(string password, string secret);

        string Decrypt(string password, byte[] encryptedData, EncryptionKeys encryptionKeys);
    }
}