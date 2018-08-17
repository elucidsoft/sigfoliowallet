using SigfolioWallet.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
using MvvmCross.Platforms.Uap.Presenters.Attributes;
using SigfolioWallet.Core.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SigfolioWallet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [MvxViewFor(typeof(AppShellViewModel))]
    public sealed partial class AppShell : MvxWindowsPage
    {
    //    public static string SelectedAccountId { get; set; }
    //    public static readonly Server server = new Server("https://horizon-testnet.stellar.org/");
        //public static readonly Server server = new Server("https://horizon.stellar.org/");

        public AppShell()
        {
            this.InitializeComponent();
            Window.Current.SetTitleBar(AppTitleBar);

            NavView.AppFrame.Navigated += AppFrame_Navigated;
            NavView.NavView.ItemInvoked += NavView_ItemInvoked;
        }

        private void AppFrame_Navigated(object sender, NavigationEventArgs e)
        {
           // LoadAccountDetails();
        }

        private async void LoadAccountDetails()
        {
            //if (SelectedAccountId != null)
            //{
            //    var details = await server.Accounts.Account(KeyPair.FromAccountId(AppShell.SelectedAccountId));
            //    var balance = details.Balances.Where(b => b.AssetType == "native").FirstOrDefault().BalanceString;

            //    NavView.SetBalanceText(balance);
            //    NavView.SetName(SelectedAccountId);
            //}
        }

        public new AppShellViewModel ViewModel => (AppShellViewModel)base.ViewModel;


        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var appShellMenuItem = Enum.Parse<NavigationPath>(args.InvokedItem.ToString());
            ViewModel.NavigateMenuItem(appShellMenuItem);
        }
    }
}
