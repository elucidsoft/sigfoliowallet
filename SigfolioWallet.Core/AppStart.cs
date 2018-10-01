using MvvmCross.Exceptions;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.Services.Interfaces;
using SigfolioWallet.Core.ViewModels;
using System;
using System.Threading.Tasks;

namespace SigfolioWallet.Core
{
    public class AppStart : MvxAppStart
    {
        private readonly ILoginService _loginService;

        public AppStart(IMvxApplication app, IMvxNavigationService navigationService, ILoginService loginService)
            : base(app, navigationService)
        {
            _loginService = loginService;
        }

        private async Task NavigateToViewModel<TViewModel>() where TViewModel : MvxViewModel
        {
            try
            {
                await NavigationService.Navigate<TViewModel>();
            }
            catch (Exception ex)
            {
                throw ex.MvxWrap("Problem navigating to ViewModel {0}", typeof(TViewModel).Name);
            }
        }

        protected override async Task NavigateToFirstViewModel(object hint = null)
        {
            await NavigateToViewModel<AppStartViewModel>();
        }

    }
}

