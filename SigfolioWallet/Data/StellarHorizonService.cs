using stellar_dotnet_sdk;
using stellar_dotnet_sdk.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigfolioWallet.Data
{
    public class StellarHorizonService
    {
        public const string HorizonURI = "https://horizon-testnet.stellar.org/"; //Need to make this configurable.
        public static Server server = new Server(HorizonURI);

    }
}
