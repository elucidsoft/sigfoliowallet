using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MvvmCross.Platforms.Uap.Presenters.Attributes;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SigfolioWallet.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [MvxViewFor(typeof(SendReceiveViewModel))]
    [MvxRegionPresentation("PageContent")]
    public sealed partial class SendReceive : MvxWindowsPage
    {

        public new TransactionsViewModel ViewModel => (TransactionsViewModel)base.ViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void lvAllTransactions_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

       
    }
}
