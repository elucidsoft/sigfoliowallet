using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.Services;
using SigfolioWallet.Core.ViewModels;
using System;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


namespace SigfolioWallet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [MvxViewFor(typeof(AppShellViewModel))]
    public sealed partial class AppShell : MvxWindowsPage
    {

        public AppShell()
        {
            this.InitializeComponent();
            Window.Current.SetTitleBar(AppTitleBar);

            //NavView.AppFrame.Navigated += AppFrame_Navigated;
            NavView.NavView.ItemInvoked += NavView_ItemInvoked;

            Loaded += AppShell_Loaded;
            Unloaded += AppShell_Unloaded;
        }

        private void AppShell_Unloaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Navigated -= ViewModel_Navigated;
        }

        private void ViewModel_Navigated(object sender, NavigationServiceEventArgs e)
        {
            NavView.SetTitle(e.Title);
        }

        private void AppShell_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Navigated += ViewModel_Navigated;
            ViewModel.NavigateMenuItem(NavigationPath.Home);
        }

        public void ChangeBackgroundColor(Color color)
        {
            Background = new SolidColorBrush(color);
        }

        private async void PasswordRequested_Requested(object sender, MvvmCross.Base.MvxValueEventArgs<Core.PasswordEventArgs> e)
        {
            await new MessageDialog(e.Value.Message).ShowAsync();
        }

        public new AppShellViewModel ViewModel => (AppShellViewModel)base.ViewModel;


        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var appShellMenuItem = Enum.Parse<NavigationPath>(args.InvokedItem.ToString());
            ViewModel.NavigateMenuItem(appShellMenuItem);
        }
    }
}


