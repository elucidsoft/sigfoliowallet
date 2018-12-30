using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services;
using System.Threading.Tasks;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Core.ViewModels.AppStartup
{
    public class OpenWalletViewModel : MvxNavigationViewModel
    {
        private readonly ISettingsService _settingsService;
        private readonly IAuthenticationService _authenticationService;

        private Wallet _wallet;

        public Wallet Wallet
        {
            get => _wallet;
            set => SetProperty(ref _wallet, value);
        }

        public override async Task Initialize()
        {
            _wallet = await _settingsService.LoadWallet();

            //TODO: Stubbed out for now, manual adding accounts, etc. will be done through services and not here...
            _authenticationService.SetPassword("TestP@ssw0rd");

            //PublicKey: GD6L6LCT42ZVODR55IL6MD7NLIPINSSSEOGJFGNVCTXJWNCMQJYVXTSL
            var account = _settingsService.CreateAccount("SABKP6TWACKPAYZOUHZOIDB4NGL57ZNJXPQF7XPFZXDRDICMHB4QOH65");
            _wallet.Accounts.Add(account);

            //TODO: Note this requires the SetPassword call above which is stored in memory, etc.
            var privateKey = _settingsService.GetPrivateKey();
        }

        public OpenWalletViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, ISettingsService settingsService, IAuthenticationService authenticationService)
            : base(logProvider, navigationService)
        {
            _wallet = new Wallet();
            _settingsService = settingsService;
            _authenticationService = authenticationService;
            
            OpenWallet = new MvxAsyncCommand(async () => { await NavigationService.Navigate<AppShellViewModel>(); });
        }

        public IMvxAsyncCommand OpenWallet { get; }
    }
}
