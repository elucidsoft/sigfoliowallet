using System;
using MvvmCross;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.Services;
using SigfolioWallet.Core.UWP;
using SigfolioWallet.Core.ViewModels;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SigfolioWallet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [MvxViewFor(typeof(AppStartViewModel))]
    public sealed partial class AppStart : MvxWindowsPage
    {
        public AppStart()
        {
            Mvx.RegisterSingleton<ISettingsService>(() => new SettingsService());
            UISettings uiSettings = new UISettings();
            uiSettings.ColorValuesChanged += UiSettings_ColorValuesChanged;
            InitializeComponent();

            SetupColors();
        }

        private void SetupColors()
        {
            btnBack.Background = new SolidColorBrush(UIUtility.GetAccentColorLow(Application.Current));
        }

        private async void UiSettings_ColorValuesChanged(UISettings sender, object args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                btnBack.Background = new SolidColorBrush(UIUtility.GetAccentColorLow(Application.Current));
            });
        }

        public new AppStartViewModel ViewModel => (AppStartViewModel)base.ViewModel;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Open();
        }
    }
}
