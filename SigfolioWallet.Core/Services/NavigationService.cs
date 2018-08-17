using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Navigation;
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

        public void NavigatePath(NavigationPath navigationPath)
        {
            switch (navigationPath)
            {
                case NavigationPath.Home:
                    _navigationService.Navigate<HomeViewModel>();
                    break;
                    case NavigationPath.History:
                    _navigationService.Navigate<HistoryViewModel>();
                    break;
            }
        }

        public void NavigateTransactions(string publicKey)
        {
            _navigationService.Navigate<TransactionsViewModel, string>(publicKey);
        }
    }
}
