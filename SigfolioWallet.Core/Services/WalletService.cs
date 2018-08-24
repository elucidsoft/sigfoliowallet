using stellar_dotnet_sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Core.Services
{
    public class WalletService : IWalletService
    {
        IStellarHorizonService _stellarHorizonService;

        public WalletService(IStellarHorizonService stellarHorizonService)
        {
            _stellarHorizonService = stellarHorizonService;
        }

        public async Task<string> GetNativeBalance(string publicKey)
        {
            var accountResponse = await _stellarHorizonService.Server.Accounts.Account(KeyPair.FromAccountId(publicKey));
            var balances = accountResponse.Balances;

            var nativeBalance = balances.SingleOrDefault(a => a.AssetType == "native");
            var balance = nativeBalance?.BalanceString ?? "0";

            return balance;
        }
    }
}
