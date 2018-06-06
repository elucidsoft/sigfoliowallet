using stellar_dotnet_sdk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SigfolioWallet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomeView : Page
    {
        public HomeView()
        {
            this.InitializeComponent();

            LoadAccountDetails();
        }

        private async void LoadAccountDetails()
        {
            var details = await AppShell.server.Accounts.Account(KeyPair.FromAccountId(AppShell.AccountId));

            var balances = details.Balances.Select(b => new AssetItem()
            {
                Asset = b.AssetType == "native" ? "XLM" : b.AssetCode,
                Amount = b.BalanceString
            });

            gvBalances.ItemsSource = balances;

        }
    }

    class AssetItem
    {
        public string Asset { get; set; }
        public string Amount { get; set; }
    }
}
