using MvvmCross.ViewModels;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services;
using stellar_dotnet_sdk;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SigfolioWallet.Core.ViewModels
{
    public class BalancesViewModel : MvxViewModel
    {
        private ObservableCollection<Balance> _balances = new ObservableCollection<Balance>();

        public ObservableCollection<Balance> Balances
        {
            get { return this._balances; }
        }

        private readonly ISettingsService _settingsService;

        public BalancesViewModel(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public override async Task Initialize()
        {
            Console.WriteLine("Enter");
            Server server = new Server("https://horizon-testnet.stellar.org/");
            KeyPair accountKeyPair = KeyPair.FromAccountId("GA6ASBGPYDVGSADNXZ7EWIJLA3I7MT4DQNYTLDIMX33SEYJUNRC74LXR");
            stellar_dotnet_sdk.responses.AccountResponse accountResponse = await server.Accounts.Account(accountKeyPair);

            for (int i = 0; i < accountResponse.Balances.Length; i++)
            {
                stellar_dotnet_sdk.responses.Balance balance = accountResponse.Balances[i];

                Balance balanceCard = new Balance();

                balanceCard.Amount = balance.BalanceString;

                if (balance.AssetType == "native")
                {
                    balanceCard.AssetCode = "XLM";
                    balanceCard.IssuerAddress = "Native Lumens";
                }
                else
                {
                    balanceCard.AssetCode = balance.AssetCode;
                    balanceCard.IssuerAddress = balance.AssetIssuer.AccountId;
                }

                balanceCard.BgColor = "#275AF0";
                _balances.Add(balanceCard);
            }

            /*
            Balance balance = new Balance();
            balance.Amount = "9000";
            balance.AssetCode = "XLM";
            balance.AssetType = new AssetTypeNative();
            balance.BgColor = "#275AF0";
            Balances.Add(balance);
            */
        }

        private async Task Stream(Server server)
        {
            /*await server.Ledgers
                .Cursor("now")
                .Stream((sender, response) => { ShowOperationResponse(server, sender, response); })
                .Connect();*/
        }
    }
}
