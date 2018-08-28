using System.IO;
using System.Threading.Tasks;

namespace SigfolioWallet.Core.Services.Interfaces
{
    public interface IStorageService
    {
        Task<(byte[] EncryptedWallet, byte[] Salt, byte[] IV)> GetEncryptedWalletFromStorage();

        Task SaveEncryptedWalletToStorage(byte[] encryptedWallet, byte[] salt, byte[] iv);
        Task<bool> WalletExists();
    }
}
