using SigfolioWallet.Views;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
