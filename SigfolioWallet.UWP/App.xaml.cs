using System;
using MvvmCross.Platforms.Uap.Core;
using MvvmCross.Platforms.Uap.Presenters;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace SigfolioWallet.UWP
{

    public abstract class SigfolioWalletApp : MvxApplication<Setup, Core.App>
    {
        private ApplicationView _currentView;
        private Application _application;
        private CoreApplicationView _coreApplicationView;

        protected override void OnLaunched(LaunchActivatedEventArgs activationArgs)
        {
            base.OnLaunched(activationArgs);

            UISettings uiSettings = new UISettings();
            uiSettings.ColorValuesChanged += UiSettings_ColorValuesChanged;

            _coreApplicationView = CoreApplication.GetCurrentView();
            _coreApplicationView.TitleBar.ExtendViewIntoTitleBar = true;

            _currentView = ApplicationView.GetForCurrentView();
            _application = Current;

            UIUtility.SetTitleBarColor(_currentView, _application);
        }

        private async void UiSettings_ColorValuesChanged(UISettings sender, object args)
        {
            await _coreApplicationView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                UIUtility.SetTitleBarColor(_currentView, _application);
            });
        }
    }

    public class Setup : MvxWindowsSetup<Core.App>
    {
        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxWindowsViewPresenter CreateViewPresenter(IMvxWindowsFrame rootFrame)
        {
            return new ClearBackStackPresenter(rootFrame);
        }
    }



    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }
    }
}