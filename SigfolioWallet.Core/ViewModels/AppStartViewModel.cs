using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.ViewModels.AppStartup;

namespace SigfolioWallet.Core.ViewModels
{
    public class AppStartViewModel : MvxNavigationViewModel
    {
        public AppStartViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService)
            : base(logProvider, navigationService)
        {
        }

        public override void ViewAppeared()
        {
            NavigationService.Navigate<GettingStartedViewModel>();
        }
    }
}
