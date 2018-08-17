using System.Security;
using System.Threading.Tasks;
using SigfolioWallet.Core.Models;

namespace SigfolioWallet.Core.Services
{
    public interface ISettingsService
    {
        Task<Wallet> GetCurrentWallet();
        Task SaveWallet(Wallet wallet);
    }
}
