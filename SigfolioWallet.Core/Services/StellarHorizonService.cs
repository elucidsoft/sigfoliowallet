using System;
using System.Collections.Generic;
using System.Text;
using stellar_dotnet_sdk;

namespace SigfolioWallet.Core.Services
{
    public class StellarHorizonService : IStellarHorizonService
    {
        public StellarHorizonService(string horizonUri)
        {
            HorizonUri = horizonUri;
            Server = new Server(horizonUri);
        }

        public  Server Server { get; set;  }

        public String HorizonUri { get; set; }
    }
}
