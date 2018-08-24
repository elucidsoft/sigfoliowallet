using System.Threading.Tasks;

namespace SigfolioWallet.Core.Services.Interfaces
{
    public interface IWalletService
    {
        Task<string> GetNativeBalance(string asset);
    }
}
