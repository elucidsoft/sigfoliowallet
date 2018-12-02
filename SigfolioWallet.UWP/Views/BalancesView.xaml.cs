using MvvmCross.Platforms.Uap.Presenters.Attributes;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using SigfolioWallet.Controls;
using SigfolioWallet.Core.ViewModels;
using Windows.UI.Xaml;

namespace SigfolioWallet.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [MvxRegionPresentation("PageContent")]
    [MvxViewFor(typeof(BalancesViewModel))]
    public sealed partial class BalancesView : MvxWindowsPage
    {
        public BalancesView()
        {
            this.InitializeComponent();
        }

        public new BalancesViewModel ViewModel => (BalancesViewModel)base.ViewModel;

        private void AddTrustlineButton_Click(object sender, RoutedEventArgs e)
        {
            BlankContentDialog dialog = new BlankContentDialog();
            TrustlineDialog trustlineDialog = new TrustlineDialog();
            trustlineDialog.viewModel = ViewModel;
            trustlineDialog.dialog = dialog;
            dialog.Content = trustlineDialog;
            dialog.ShowAsync();
        }

        private void TradeAssetsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
