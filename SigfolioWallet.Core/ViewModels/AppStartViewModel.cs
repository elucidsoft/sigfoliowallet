using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SigfolioWallet.Core.ViewModels
{
    public class AppStartViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public AppStartViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public Task Open()
        {
            return _navigationService.Navigate<AppShellViewModel>();
        }
    }
}
