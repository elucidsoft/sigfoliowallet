using stellar_dotnet_sdk;
using stellar_dotnet_sdk.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigfolioWallet.Data
{
    public class AccountResponseService
    {
        public static AccountResponse GetAccountResponse(string accountId)
        {
            return GetAccountResponseAsync(accountId).Result;

        }

        public static async Task<AccountResponse> GetAccountResponseAsync(string accountId)
        {
            var accountResponse = await StellarHorizonService.server.Accounts.Account(KeyPair.FromAccountId(accountId));

            return accountResponse;
        }
    }
}
