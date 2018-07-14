using SigfolioWallet.Utilities;
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            AppShell.SelectedAccountId = txtAccountId.Text;

            this.Frame.Navigate(typeof(HomeView));
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
