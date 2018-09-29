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

        public ObservableCollection<Data> data { get; set; }

        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {

           data = new  ObservableCollection<Data>();

            data.Add(new Data() { Value = 2 });
            data.Add(new Data() { Value = 9 });
            data.Add(new Data() { Value = 8 });
            data.Add(new Data() { Value = 2 });
            data.Add(new Data() { Value = 8 });
            data.Add(new Data() { Value = 4 });
            data.Add(new Data() { Value = 4 });
            data.Add(new Data() { Value = 5 });
            data.Add(new Data() { Value = 2 });
            data.Add(new Data() { Value = 3 });
            data.Add(new Data() { Value = 5 });
            data.Add(new Data() { Value = 8 });
            data.Add(new Data() { Value = 5 });
            data.Add(new Data() { Value = 5 });
            data.Add(new Data() { Value = 9 });
            data.Add(new Data() { Value = 12 });
            data.Add(new Data() { Value = 4 });
            data.Add(new Data() { Value = 2 });
            data.Add(new Data() { Value = 8 });
            data.Add(new Data() { Value = 3 });

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            Random rnd = new Random();
            timer.Tick += (o, o1) =>
            {
               Add(rnd.Next(1, 20));
            };

            timer.Start();
            lineSeries.DataContext = data;
        }

        private void Add(double value)
        {
            data.RemoveAt(0);
            data.Add(new Data() { Value = value });
        }

        public new HomeViewModel ViewModel => (HomeViewModel) base.ViewModel;
    }

    public class Data
    {
        public string Category { get; set; }

        public double Value { get; set; }
    }
}
