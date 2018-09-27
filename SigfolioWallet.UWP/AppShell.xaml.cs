using SigfolioWallet.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SigfolioWallet.Utilities;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.ViewModels;
using MvvmCross.Platforms.Uap.Presenters.Attributes;
using SigfolioWallet.Core.Services;


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
        }

        private void AppShell_Loaded(object sender, RoutedEventArgs e)
        {
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

        //private void AppFrame_Navigated(object sender, NavigationEventArgs e)
        //{
        //    ViewModel.NavigateMenuItem(NavigationPath.Home);
        //}

        public new AppShellViewModel ViewModel => (AppShellViewModel)base.ViewModel;


        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var appShellMenuItem = Enum.Parse<NavigationPath>(args.InvokedItem.ToString());
            ViewModel.NavigateMenuItem(appShellMenuItem);
        }
    }
}


