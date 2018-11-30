using MvvmCross.ViewModels;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services;
using stellar_dotnet_sdk;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

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

        public class TrustlineCard
        {
            public Trustline Trustline { get; set; }
            public string Logo { get; set; }
        }

        private ObservableCollection<AssetCard> _assetsCards = new ObservableCollection<AssetCard>();

        public ObservableCollection<AssetCard> AssetsCards
        {
            get { return this._assetsCards; }
        }

        private ObservableCollection<TrustlineCard> _trustlineCards = new ObservableCollection<TrustlineCard>();

        public ObservableCollection<TrustlineCard> TrustlineCards
        {
            get { return this._trustlineCards; }
        }

        private readonly ISettingsService _settingsService;

        public BalancesViewModel(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public override async Task Initialize()
        {
            CreateBalances();
            FetchAvailableTrustlines();
        }

        private async void CreateBalances()
        {
            //Change this, this should be used with the server the wallet is using and with the account you selected, 
            //not a hard coded one.
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

        private async void FetchAvailableTrustlines()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("https://sigfol.io/api/assets");
                JObject jobject = JObject.Parse(json);
                JArray anchors = (JArray)jobject.GetValue("_embedded").ToObject<JObject>().GetValue("records");
                foreach (JObject anchor in anchors)
                {
                    TrustlineCard trustlineCard = new TrustlineCard();
                    Trustline trustline = new Trustline();

                    trustlineCard.Trustline = trustline;

                    string fullAsset = anchor.GetValue("asset").ToString();
                    string[] assetArray = fullAsset.Split('-');

                    trustline.AssetCode = assetArray[0];
                    trustline.IssuerAddress = assetArray[1];

                    _trustlineCards.Add(trustlineCard);
                }

            }
        }
    }
}
