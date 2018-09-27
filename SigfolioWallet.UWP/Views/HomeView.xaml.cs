using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using MvvmCross.Platforms.Uap.Presenters.Attributes;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.ViewModels;

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
        }

        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        public new HomeViewModel ViewModel => (HomeViewModel) base.ViewModel;

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            var num = rnd.Next(0, 5000);

            Number.Text = num.ToString();
            Card1.PrimaryText = num.ToString();
        }
    }
}
