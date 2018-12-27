using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace SigfolioWallet.Core.ViewModels.AppStartup
{
    public class OpenWalletViewModel : MvxNavigationViewModel
    {
        public OpenWalletViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : 
            base(logProvider, navigationService)
        {   
        }
    }
}
