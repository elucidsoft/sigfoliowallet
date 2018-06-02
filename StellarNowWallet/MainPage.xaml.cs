using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StellarNowWallet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            Window.Current.CoreWindow.SizeChanged += (s, e) => UpdateAppTitle();
            coreTitleBar.LayoutMetricsChanged += (s, e) => UpdateAppTitle();


        }

        void UpdateAppTitle()
        {
            var full = (ApplicationView.GetForCurrentView().IsFullScreenMode);
            var left = 12 + (full ? 0 : CoreApplication.GetCurrentView().TitleBar.SystemOverlayLeftInset);
            AppTitle.Margin = new Thickness(left, 8, 0, 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fContent.Navigate(typeof(LedgerPage), txtAccountId.Text);

            //CoreApplicationView newView = CoreApplication.CreateNewView();
            //int newViewId = 0;
            //await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            //{
            //    Frame frame = new Frame();
            //    frame.Navigate(typeof(LedgerPage), txtAccountId.Text);
            //    Window.Current.Content = frame;
            //    // You have to activate the window in order to show it later.
            //    Window.Current.Activate();

            //    newViewId = ApplicationView.GetForCurrentView().Id;
            //});
            //bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
        }
    }
}
