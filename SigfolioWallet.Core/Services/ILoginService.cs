using System.Threading.Tasks;

namespace SigfolioWallet.Core
{
    public interface ILoginService
    {
        Task<bool> IsAuthenticated();
    }
}