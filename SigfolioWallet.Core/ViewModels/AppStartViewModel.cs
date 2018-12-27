using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Base;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services;
using SigfolioWallet.Core.ViewModels.AppStartup;

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

        public override void ViewAppeared()
        {
            _navigationService.Navigate<GettingStartedViewModel>();
        }

        //TEMP Fix until new MVVMCross nuget package is released to fix startup hang with async
        public override async Task Initialize()
        {
            var loadWalletTask = Task.Run(() =>
            {
                Task.Delay(500);

                Wallet = _settingsService.LoadWallet().Result;

#if (DEBUG)
                Wallet.Accounts.Add(new Account()
                {
                    PublicKey = "GB72RBWW7YDFUR3UIFZUKOTIETBVMVSC4IR7HHEHGTCDTXZ4AETSQMNF",
                    Name = "Dev Test 1"
                });
#endif
            });

            var initTask = base.Initialize();

            Task.WaitAll(loadWalletTask, initTask);
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
