using MvvmCross.ViewModels;
using SigfolioWallet.Core.Services;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Core.ViewModels
{
    public class AppShellViewModel : MvxViewModel
    {
        private readonly INavigationService _navigationService;

        public MvxInteraction<PasswordEventArgs> PasswordRequested = new MvxInteraction<PasswordEventArgs>();

        public AppShellViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
        {
            _navigationService = navigationService;

           // authenticationService.RequestPassword += _authenticationService_RequestPassword;
        }

        //private void _authenticationService_RequestPassword(object sender, PasswordEventArgs e)
        //{
        //    var passwordEventArgs = new PasswordEventArgs();
        //        PasswordRequested.Raise(passwordEventArgs);
        //}

        //public void UnlockWallet()
        //{
        //    var passwordEventArgs = new PasswordEventArgs();
        //    PasswordRequested.Raise(passwordEventArgs);
        //}

        public void NavigateMenuItem(NavigationPath navigationPath)
        {
            _navigationService.NavigatePath(navigationPath);
        }
    }
}
