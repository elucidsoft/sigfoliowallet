using MvvmCross;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SigfolioWallet.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterSingleton<IStellarHorizonService>(() => new StellarHorizonService("https://horizon-testnet.stellar.org/"));

            Mvx.RegisterType<IWalletService, WalletService>();
            Mvx.RegisterType<ILoginService, LoginService>();
            Mvx.RegisterSingleton<ITransactionService>(() => new TransactionService(Mvx.GetSingleton<IStellarHorizonService>()));

            RegisterCustomAppStart<AppStart>();
        }
    }
}
