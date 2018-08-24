using System.Threading.Tasks;

namespace SigfolioWallet.Core.Services.Interfaces
{
    public interface IEncryptionService
    {
        (byte[] EncryptedBytes, byte[] Salt, byte[] IV) Encrypt(string password, string secret);

        string Decrypt(string password, byte[] encryptedData, byte[] iv, byte[] salt);
    }
}