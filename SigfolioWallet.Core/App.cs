using MvvmCross;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.IoC;
using SigfolioWallet.Core.Models;

namespace SigfolioWallet.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterSingleton<IStellarHorizonService>(() => new StellarHorizonService("https://horizon-testnet.stellar.org/"));

            Mvx.RegisterType<INavigationService, NavigationService>();
            Mvx.RegisterType<IWalletService, WalletService>();
            Mvx.RegisterType<ILoginService, LoginService>();
            Mvx.RegisterType<ITransactionService, TransactionService>();

            Mvx.RegisterSingleton<ISettingsService>(new SettingsService(Mvx.Resolve<IStorageService>()));

            RegisterCustomAppStart<AppStart>();
        }
    }
}
