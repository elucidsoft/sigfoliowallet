using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Navigation;
using SigfolioWallet.Core.Services.Interfaces;
using SigfolioWallet.Core.ViewModels;

namespace SigfolioWallet.Core.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IMvxNavigationService _navigationService;

        public NavigationService(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string Title { get; set; }

        public void NavigatePath(NavigationPath navigationPath)
        {
            switch (navigationPath)
            {
                case NavigationPath.Home:
                    Title = "Dashboard";
                    _navigationService.Navigate<HomeViewModel>();
                    break;
                case NavigationPath.Balances:
                    Title = "Balances";
                    _navigationService.Navigate<BalancesViewModel>();
                    break;
                case NavigationPath.Transactions:
                    Title = "Transactions";
                    _navigationService.Navigate<TransactionsViewModel>();
                    break;
                case NavigationPath.SendReceive:
                    Title = "Send or Receive";
                    _navigationService.Navigate<SendReceiveViewModel>();
                    break;
                case NavigationPath.History:
                    Title = "History";
                    _navigationService.Navigate<HistoryViewModel>();
                    break;
                case NavigationPath.Settings:
                    Title = "Settings";
                    _navigationService.Navigate<SettingsViewModel>();
                    break;
            }
        }

        public void NavigateTransactions(string publicKey)
        {
            
        }
    }
}
