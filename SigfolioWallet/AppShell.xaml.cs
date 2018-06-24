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
using SigfolioWallet.Models;
using stellar_dotnet_sdk.responses;
using SigfolioWallet.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SigfolioWallet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppShell : Page
    {
        public WalletViewModel Wallet { get; set; }

        public AppShell()
        {
            this.InitializeComponent();
            Window.Current.SetTitleBar(AppTitleBar);
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

            AppFrame.Navigate(navType);

        }
    }
}
