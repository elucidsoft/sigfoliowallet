using System.Security;
using System.Threading.Tasks;
using SigfolioWallet.Core.Models;

namespace SigfolioWallet.Core.Services
{
    public interface ISettingsService
    {
        Wallet Wallet { get; }

        Task<Wallet> LoadWallet();

        Task SaveWallet(Wallet wallet);
        void ResetSettings();
    }
}
