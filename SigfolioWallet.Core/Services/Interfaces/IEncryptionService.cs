using System.Threading.Tasks;
using SigfolioWallet.Core.Models;

namespace SigfolioWallet.Core.Services.Interfaces
{
    public interface IEncryptionService
    {
        (byte[] EncryptedBytes, EncryptionKeys EncryptionKeys) Encrypt(byte[] password, string secret);

        string Decrypt(byte[] password, byte[] encryptedData, EncryptionKeys encryptionKeys);
    }
}