using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace SigfolioWallet.Core.ViewModels.AppStartup
{
    public class GettingStartedViewModel : MvxNavigationViewModel
    {
        public GettingStartedViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) :
            base(logProvider, navigationService)
        {
            Next = new MvxAsyncCommand(async () =>
            {
                await NavigationService.Navigate<OpenWalletViewModel>();
            });
        }
        
        public IMvxAsyncCommand Next { get; }

    }



}
