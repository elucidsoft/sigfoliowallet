using System.IO;
using System.Threading.Tasks;

namespace SigfolioWallet.Core.Services.Interfaces
{
    public interface IStorageService
    {
        Task StoreSaltAndInitializationVector(byte[] salt, byte[] iv);

        Task<(byte[] Salt, byte[] IV)> GetSaltAndInitializationVector();

        Task<byte[]> GetEncryptedWalletFromStorage();

        Task SaveEncryptedWalletToStorage(byte[] encryptedWallet);
    }
}
