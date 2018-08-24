using stellar_dotnet_sdk;

namespace SigfolioWallet.Core.Services.Interfaces
{
    public interface IStellarHorizonService
    {
        Server Server { get; set; }
    }
}
