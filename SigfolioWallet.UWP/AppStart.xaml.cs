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
using Windows.UI.Xaml.Navigation;

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
            UISettings uiSettings = new UISettings();
            uiSettings.ColorValuesChanged += UiSettings_ColorValuesChanged;
            InitializeComponent();

            SetupColors();

            Loaded += AppStart_Loaded;
        }

        private void AppStart_Loaded(object sender, RoutedEventArgs e)
        {
            cbAccounts.DataContext = ViewModel;

            if (ViewModel.Wallet.CurrentAccountId == 0)
            {
                cbAccounts.SelectedValue = ViewModel.Wallet.CurrentAccountId;
            }
        }

        private void SetupColors()
        {
            btnBack.Background = new SolidColorBrush(UIUtility.GetAccentColorLow());
        }

        private async void UiSettings_ColorValuesChanged(UISettings sender, object args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                btnBack.Background = new SolidColorBrush(UIUtility.GetAccentColorLow());
            });
        }

        public new AppStartViewModel ViewModel => (AppStartViewModel)base.ViewModel;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Open(Convert.ToInt32(cbAccounts.SelectedValue));
        }
    }
}
