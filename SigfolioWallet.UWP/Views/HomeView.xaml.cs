using MvvmCross.Platforms.Uap.Presenters.Attributes;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.ViewModels;
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
    [MvxRegionPresentation("PageContent")]
    [MvxViewFor(typeof(HomeViewModel))]
    public sealed partial class HomeView : MvxWindowsPage
    {
        public HomeView()
        {
            this.InitializeComponent();

            LoadAccountDetails();
        }

        public new HomeViewModel ViewModel => (HomeViewModel)base.ViewModel;


        private async void LoadAccountDetails()
        {
            //var details = await AppShell.server.Accounts.Account(KeyPair.FromAccountId(AppShell.SelectedAccountId));

            ////Currently restricting to XLM only.
            //var balances = details.Balances.Where(b => b.AssetType == "native").Select(b => new AssetItem()
            //{
            //    Asset = b.AssetType == "native" ? "XLM" : b.AssetCode,
            //    Amount = b.BalanceString
            //});

            //gvBalances.ItemsSource = balances;

        }

        private void gvBalances_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rowItem = (AssetItem)e.ClickedItem;

            this.Frame.Navigate(typeof(TransactionsView), rowItem.Asset);
        }
    }

    class AssetItem
    {
        public string Asset { get; set; }
        public string Amount { get; set; }
    }
}
