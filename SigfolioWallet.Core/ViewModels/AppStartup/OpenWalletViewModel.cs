using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services;
using SigfolioWallet.Core.Services.Interfaces;
using SigfolioWallet.Core.ViewModels.Modal;
using System;
using System.Threading.Tasks;

namespace SigfolioWallet.Core.ViewModels.AppStartup
{
    public class OpenWalletViewModel : MvxNavigationViewModel
    {
        private readonly ISettingsService _settingsService;
        private readonly IAuthenticationService _authenticationService;

        private Wallet _wallet;
        private string _test;

        public Wallet Wallet
        {
            get => _wallet;
            set => SetProperty(ref _wallet, value);
        }

        public async override void ViewAppeared()
        {

        }

        public async override Task Initialize()
        {
            //TODO: Stubbed out for now, manual adding accounts, etc. will be done through services and not here...
            _wallet = await _settingsService.LoadWallet();

            await NavigationService.Navigate<PasswordDialogViewModel>();

            _authenticationService.SetPassword("TestP@ssw0rd");

            //PublicKey: GD6L6LCT42ZVODR55IL6MD7NLIPINSSSEOGJFGNVCTXJWNCMQJYVXTSL
            var account = await _settingsService.CreateAccount("SABKP6TWACKPAYZOUHZOIDB4NGL57ZNJXPQF7XPFZXDRDICMHB4QOH65");
            _wallet.Accounts.Add(account);
            _wallet.CurrentAccountId = account.Id;
        }

        public OpenWalletViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, ISettingsService settingsService, IAuthenticationService authenticationService)
            : base(logProvider, navigationService)
        {
            _settingsService = settingsService;
            _authenticationService = authenticationService;

            OpenWallet = new MvxAsyncCommand(async () =>
            {

                await NavigationService.Navigate<AppShellViewModel>();
            });
        }

        public IMvxAsyncCommand OpenWallet { get; }
    }
}
