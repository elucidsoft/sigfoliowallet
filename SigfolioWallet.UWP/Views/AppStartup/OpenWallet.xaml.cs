using MvvmCross.Platforms.Uap.Presenters.Attributes;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.ViewModels.AppStartup;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SigfolioWallet.Views.AppStartup
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [MvxRegionPresentation("AppStartupFrame")]
    [MvxViewFor(typeof(OpenWalletViewModel))]
    public sealed partial class OpenWallet : MvxWindowsPage
    {
        public OpenWallet()
        {
            this.InitializeComponent();
        }

        public new OpenWalletViewModel ViewModel => (OpenWalletViewModel)base.ViewModel;

    }
}
