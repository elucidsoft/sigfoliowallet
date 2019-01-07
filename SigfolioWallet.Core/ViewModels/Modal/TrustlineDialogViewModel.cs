using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Core.ViewModels.Modal
{
    public class TrustlineDialogViewModel : MvxNavigationViewModel
    {
        public TrustlineDialogViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IAuthenticationService authenticationService)
            : base(logProvider, navigationService)
        {
            Close = new MvxAsyncCommand(async () => await NavigationService.Close(this));
        }

        public IMvxAsyncCommand Close { get; set; }
    }
}