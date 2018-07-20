using stellar_dotnet_sdk;
using SigfolioWallet.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SigfolioWallet.Utilities;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SigfolioWallet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [MvxViewFor(typeof(AppShellViewModel))]
    public sealed partial class AppShell : MvxWindowsPage
    {
        public static string SelectedAccountId { get; set; }
        public static readonly Server server = new Server("https://horizon-testnet.stellar.org/");
        //public static readonly Server server = new Server("https://horizon.stellar.org/");

        public AppShell()
        {
            this.InitializeComponent();
            Window.Current.SetTitleBar(AppTitleBar);

            NavView.AppFrame.Navigated += AppFrame_Navigated;
            if (SelectedAccountId == null)
            {
                NavView.AppFrame.Navigate(typeof(LoginView));
            }
            else
            {
                LoadAccountDetails();
                NavView.AppFrame.Navigate(typeof(HomeView));
            }
        }

        private void AppFrame_Navigated(object sender, NavigationEventArgs e)
        {
            LoadAccountDetails();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoadAccountDetails();

        }

        private async void LoadAccountDetails()
        {
            if (SelectedAccountId != null)
            {
                var details = await server.Accounts.Account(KeyPair.FromAccountId(AppShell.SelectedAccountId));
                var balance = details.Balances.Where(b => b.AssetType == "native").FirstOrDefault().BalanceString;

                NavView.SetBalanceText(balance);
                NavView.SetName(SelectedAccountId);
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            Type navType;

            switch (args.InvokedItem)
            {
                case "Home":
                    navType = typeof(HomeView);
                    break;
                case "History":
                    navType = typeof(HistoryView);
                    break;
                default:
                    navType = typeof(HomeView);
                    break;
            }

            NavView.AppFrame.Navigate(navType);

        }
    }
}
