﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
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
    [MvxViewFor(typeof(TransactionsViewModel))]
    [MvxRegionPresentation("PageContent")]
    public sealed partial class TransactionsView : MvxWindowsPage
    {

        public new TransactionsViewModel ViewModel => (TransactionsViewModel)base.ViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            
            this.SplitView.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, IsPaneOpenPropertyChanged);

            DataContext = ViewModel;
        }

        private void IsPaneOpenPropertyChanged(DependencyObject sender, DependencyProperty dp)
        {
            //if (this.SplitView.IsPaneOpen)
            //{
            //    this.SplitView.OpenPaneLength = this.SplitView.Parent. * .8;
            //}
        }

        public TransactionsView()
        {
            this.InitializeComponent();
        }

        private void lvAllTransactions_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pivot = (Pivot)sender;

            var pivotItem = (PivotItem)pivot.SelectedItem;

            if(pivotItem.Name == "piSent")
            {
                ViewModel.Filter = "debit";
            }
            else if(pivotItem.Name == "piReceived")
            {
                ViewModel.Filter = "credit";
            }
            else
            {
                ViewModel.Filter = "all";
            }
            
        }

        private void Pivot_PivotItemLoading(Pivot sender, PivotItemEventArgs args)
        {

        }
    }
}
