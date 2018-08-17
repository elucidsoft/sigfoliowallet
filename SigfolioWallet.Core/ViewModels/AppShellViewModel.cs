using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Presenters.Hints;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using SigfolioWallet.Core.Services;

namespace SigfolioWallet.Core.ViewModels
{
    public class AppShellViewModel : MvxViewModel
    {
        private readonly INavigationService _navigationService;

        public AppShellViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void NavigateMenuItem(NavigationPath navigationPath)
        {
            _navigationService.NavigatePath(navigationPath);
        }
}
}
