using System;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.Services;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Core.ViewModels
{
    public class AppShellViewModel : MvxViewModel
    {
        private readonly INavigationService _navigationService;

        public event EventHandler<NavigationServiceEventArgs> Navigated; 

        public AppShellViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
        {
            _navigationService = navigationService;
        }

        public void NavigateMenuItem(NavigationPath navigationPath)
        {
            _navigationService.NavigatePath(navigationPath);
            Navigated?.Invoke(this, new NavigationServiceEventArgs(_navigationService.Title));
        }

    }

    public class NavigationServiceEventArgs : EventArgs
    {
        public NavigationServiceEventArgs(string title) => Title = title;

        public string Title { get; set; }   
    }
}
