using stellar_dotnet_sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace SigfolioWallet.Core.Services
{
    public interface IStellarHorizonService
    {
        Server Server { get; set; }
    }
}
