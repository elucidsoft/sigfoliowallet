using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using stellar_dotnet_sdk;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Core.Services
{
    public class StellarHorizonService : IStellarHorizonService
    {
        public StellarHorizonService(string horizonUri)
        {
            HorizonUri = horizonUri;
            Server = new Server(horizonUri);
        }

        public StellarHorizonService(string horizonUri, HttpClient httpClient)
        {
            HorizonUri = horizonUri;
            Server = new Server(horizonUri, httpClient);
        }

        public  Server Server { get; set;  }

        public String HorizonUri { get; set; }
    }
}
