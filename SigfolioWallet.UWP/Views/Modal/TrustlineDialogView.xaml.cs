using MvvmCross.Platforms.Uap.Presenters.Attributes;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.ViewModels;
using SigfolioWallet.Core.ViewModels.Modal;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace SigfolioWallet.Views.Modal
{
    [MvxDialogViewPresentation]
    [MvxViewFor(typeof(TrustlineDialogViewModel))]
    public sealed partial class TrustlineDialogView : MvxWindowsContentDialog, INotifyPropertyChanged
    {
        //To be changed
        public BalancesViewModel viewModel;
        public new TrustlineDialogViewModel ViewModel => (TrustlineDialogViewModel)base.ViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<BalancesViewModel.TrustlineCard> _filteredTrustlines;

        public ObservableCollection<BalancesViewModel.TrustlineCard> FilteredTrustlines
        {
            get { return _filteredTrustlines; }
            set { _filteredTrustlines = value; NotifyPropertyChanged("FilteredTrustlines"); }
        }

        public TrustlineDialogView()
        {
            this.InitializeComponent();
        }

        public void Setup()
        {
            FilteredTrustlines = viewModel.TrustlineCards;
        }

        private void OnFilterTextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            RefreshFilteredTrustlines(sender.Text);
        }

        private void RefreshFilteredTrustlines(string filterString)
        {
           var tc = viewModel.TrustlineCards.Where(item => item.Trustline.AssetCode.Contains(filterString));         
           FilteredTrustlines = new ObservableCollection<BalancesViewModel.TrustlineCard>(tc);
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
