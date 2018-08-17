using MvvmCross.Platforms.Uap.Core;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using System;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MvvmCross.Platforms.Uap.Presenters;

namespace SigfolioWallet.UWP
{

    public abstract class SigfolioWalletApp : MvxApplication<Setup, Core.App>
    {
        public SigfolioWalletApp()
        {

        }
        
        protected override void OnLaunched(LaunchActivatedEventArgs activationArgs)
        {
            base.OnLaunched(activationArgs);

            UISettings uiSettings = new UISettings();
            uiSettings.ColorValuesChanged += UiSettings_ColorValuesChanged;

            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            UIUtility.SetTitleBarColor();
        }

        private void UiSettings_ColorValuesChanged(UISettings sender, object args)
        {
            UIUtility.SetTitleBarColor();

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
    sealed partial class App
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