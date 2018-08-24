using System.Threading.Tasks;

namespace SigfolioWallet.Core.Services.Interfaces
{
    public interface ILoginService
    {
        Task<bool> IsAuthenticated();
    }
}