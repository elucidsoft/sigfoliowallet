using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using MvvmCross.Platforms.Uap.Presenters.Attributes;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using SigfolioWallet.Core;
using SigfolioWallet.Core.ViewModels;
using SigfolioWallet.UWP;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SigfolioWallet.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [MvxRegionPresentation("PageContent")]
    [MvxViewFor(typeof(HomeViewModel))]
    public sealed partial class HomeView : MvxWindowsPage
    {
        public HomeView()
        {
            this.InitializeComponent();
            
            Loaded += HomeView_Loaded;

            Window.Current.SizeChanged += Current_SizeChanged;           
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            CardBarChart.Visibility = e.Size.Width < SigfolioWalletApp.DefaultWindowWidth ? Visibility.Collapsed : Visibility.Visible;

        }

        private void PnlMain_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {

          
        }

       

        public new HomeViewModel ViewModel => (HomeViewModel) base.ViewModel;
    }


}
