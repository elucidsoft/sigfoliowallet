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
        public class AssetCard
        {
            public Balance Balance { get; set; }
            public string BgColor { get; set; }
            public string Logo { get; set; }
            public bool IsAddCard { get; set; }
        }

        private ObservableCollection<AssetCard> _assetsCards = new ObservableCollection<AssetCard>();

        public ObservableCollection<AssetCard> AssetsCards
        {
            get { return this._assetsCards; }
        }

        private readonly ISettingsService _settingsService;

        public BalancesViewModel(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public override async Task Initialize()
        {
            //TODO
            //Change this

            Server server = new Server("https://horizon-testnet.stellar.org/");
            KeyPair accountKeyPair = KeyPair.FromAccountId("GDLIITOORUA7DN3DDFEGNCGNFVRFKJKFOXJOE2FO4FYMFQF5LRT5YL7U");
            stellar_dotnet_sdk.responses.AccountResponse accountResponse = await server.Accounts.Account(accountKeyPair);

            for (int i = 0; i < accountResponse.Balances.Length; i++)
            {
                stellar_dotnet_sdk.responses.Balance balance = accountResponse.Balances[i];

                AssetCard assetCard = new AssetCard();

                //Set AssetCard Balance
                Balance assetCardBalance = new Balance();
                assetCard.Balance = assetCardBalance;
                assetCardBalance.Amount = balance.BalanceString;

                //Check if it's native or not
                if (balance.AssetType == "native")
                {
                    assetCardBalance.AssetCode = "XLM";
                    assetCardBalance.IssuerAddress = "Native Lumens";
                }
                else
                {
                    assetCardBalance.AssetCode = balance.AssetCode;
                    assetCardBalance.IssuerAddress = balance.AssetIssuer.AccountId;
                }

                //Set AssetCard Other
                
                assetCard.BgColor = "#275AF0";

                //Add it to the list
                _assetsCards.Add(assetCard);
            }
        }
    }
}
