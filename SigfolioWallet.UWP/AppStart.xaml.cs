using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
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
            this.InitializeComponent();

            
        }

        private void AppStart_GotFocus(object sender, RoutedEventArgs e)
        {
            UIUtility.SetTitleBarColor();
        }

        private void AppStart_FocusEngaged(Control sender, FocusEngagedEventArgs args)
        {
            UIUtility.SetTitleBarColor();
        }

        private void AppStart_ActualThemeChanged(FrameworkElement sender, object args)
        {
            AppStart appStart = (AppStart) sender;
        }

        public new AppStartViewModel ViewModel => (AppStartViewModel)base.ViewModel;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           ViewModel.Open();
        }
    }
}
