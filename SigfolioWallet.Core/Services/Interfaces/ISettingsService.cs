using System.IO;
using System.Security;
using System.Threading.Tasks;
using SigfolioWallet.Core.Models;

namespace SigfolioWallet.Core.Services
{
    public interface ISettingsService
    {
        Task<Wallet> LoadWallet();

        Task SaveWallet(Wallet wallet);

        void ResetSettings();
        Wallet Wallet { get; }
    }
}
