using SigfolioWallet.Data;
using stellar_dotnet_sdk;
using stellar_dotnet_sdk.responses;
using System;
using System.Linq;

namespace SigfolioWallet.Models
{
    public class Account
    {
        private AccountResponse AccountResponse { get; set; }

        public Account()
        {

        }
        public string Name { get; set; }
        public string AccountId { get; }

        public string AccountShortId { get { return AccountId.Substring(0, 4); } }

        public Account(string accountId)
        {
            AccountId = accountId;
            AccountResponse = AccountResponseService.GetAccountResponse(accountId);
        }


        public string GetBalance(string assetCode = "XLM")
        {
            var balance = AccountResponse.Balances.Where(b => b.AssetCode == assetCode || b.AssetCode == string.Empty).FirstOrDefault();

            if (balance != null)
                return balance.BalanceString;

            return "0";
        }


        public void SendAsset(decimal amount, string accountId, string assetCode = "XLM")
        {
            throw new NotImplementedException();
        }

    }
}
