using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Core.ViewModels.Modal
{
    public class PasswordDialogViewModel : MvxNavigationViewModel
    {
        private string _password;

        public PasswordDialogViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IAuthenticationService authenticationService)
            : base(logProvider, navigationService)
        {
            Cancel = new MvxAsyncCommand(async () => await NavigationService.Close(this));

            Confirm = new MvxAsyncCommand(async () =>
            {
                authenticationService.SetPassword(Password);
                await NavigationService.Close(this);
            });
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public IMvxAsyncCommand Confirm { get; set; }

        public IMvxAsyncCommand Cancel { get; set; }

    }
}
