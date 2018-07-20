using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SigfolioWallet.Core.ViewModels
{
    public class AppShellViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public AppShellViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public IMvxCommand MyProperty { get; set; }
    }
}
