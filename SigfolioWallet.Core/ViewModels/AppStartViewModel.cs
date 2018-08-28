using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services;

namespace SigfolioWallet.Core.ViewModels
{
    public class AppStartViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ISettingsService _settingsService;

        private Wallet _wallet;

        public Wallet Wallet {
            get => _wallet;
            set => SetProperty(ref _wallet, value);
        }
        
        public AppStartViewModel(IMvxNavigationService navigationService, ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _settingsService = settingsService;
        }

        public override async Task Initialize()
        {
            Wallet = await _settingsService.LoadWallet();

#if (DEBUG)
            Wallet.Accounts.Add(new Account()
            {
                PublicKey = "GB72RBWW7YDFUR3UIFZUKOTIETBVMVSC4IR7HHEHGTCDTXZ4AETSQMNF",
                Name = "Dev Test 1"
            });
#endif

            await base.Initialize();
        }

        public Task Open(int selectedAccount)
        {
            Wallet.CurrentAccountId = selectedAccount;

            //TODO: TestWallet is stubbed out for now, need to implement wallet selection logic
            _settingsService.SaveWallet(Wallet);

            return _navigationService.Navigate<AppShellViewModel>();
        }
    }
}
