using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Presenters.Hints;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SigfolioWallet.Core.ViewModels
{
    public class AppShellViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public enum ShellMenuItem { Home, Ledger, History }

        public AppShellViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        
        public void Navigate()
        {
            _navigationService.Navigate<LedgerViewModel>();
        }
    }
}
