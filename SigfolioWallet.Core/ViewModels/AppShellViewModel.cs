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

        public enum AppShellMenuItem { Home, Transactions, History }

        public AppShellViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        
        public void NavigateMenuItem(AppShellMenuItem menuItem)
        {
            switch(menuItem)
            {
                case AppShellMenuItem.Home:
                    _navigationService.Navigate<HomeViewModel>();
                    break;
                case AppShellMenuItem.History:
                    _navigationService.Navigate<HistoryViewModel>();
                    break;
                case AppShellMenuItem.Transactions:
                    _navigationService.Navigate<TransactionsViewModel, string>("GB72RBWW7YDFUR3UIFZUKOTIETBVMVSC4IR7HHEHGTCDTXZ4AETSQMNF");
                    break;
            }

        }
    }
}
