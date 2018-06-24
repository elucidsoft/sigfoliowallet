using stellar_dotnet_sdk;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SigfolioWallet.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginView : Page
    {
        public LoginView()
        {
            this.InitializeComponent();
#if DEBUG
            txtAccountId.Text = "GB72RBWW7YDFUR3UIFZUKOTIETBVMVSC4IR7HHEHGTCDTXZ4AETSQMNF";
#endif
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var details = await AppShell.server.Accounts.Account(KeyPair.FromAccountId(txtAccountId.Text));
            AppShell.AccountDetails = new Models.Account(details);

            AppShell.
            this.Frame.Navigate(typeof(HomeView));
        }
    }
}
