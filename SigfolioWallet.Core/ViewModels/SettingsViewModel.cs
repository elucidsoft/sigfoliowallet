using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services;

namespace SigfolioWallet.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ISettingsService _settingsService;
        
        public SettingsViewModel(IMvxNavigationService navigationService, ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _settingsService = settingsService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
        }

        public void ResetSettings()
        {
            _settingsService.ResetSettings();
        }
    }
}
