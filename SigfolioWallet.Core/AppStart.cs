using MvvmCross.Exceptions;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SigfolioWallet.Core.Services.Interfaces;

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

        private void NavigateToViewModel<TViewModel>() where TViewModel : MvxViewModel
        {
            try
            {
                NavigationService.Navigate<TViewModel>().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw ex.MvxWrap("Problem navigating to ViewModel {0}", typeof(TViewModel).Name);
            }
        }

        protected override void NavigateToFirstViewModel(object hint = null)
        {
            var tcs = new TaskCompletionSource<bool>();
            Task.Run(async () => tcs.SetResult(await _loginService.IsAuthenticated()));
            var isAuthenticated = tcs.Task.Result;

            if (isAuthenticated)
            {
                NavigateToViewModel<AppShellViewModel>();
            }
            else
            {
                NavigateToViewModel<AppStartViewModel>();
            }
        }
    }
}
