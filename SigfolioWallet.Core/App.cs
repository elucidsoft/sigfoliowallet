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
            Mvx.RegisterType<IWalletService, WalletService>();
            Mvx.RegisterType<ILoginService, LoginService>();

            RegisterCustomAppStart<AppStart>();
        }
    }
}
