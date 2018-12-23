using SigfolioWallet.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SigfolioWallet.Controls
{
    public sealed partial class TrustlineDialog : UserControl, INotifyPropertyChanged
    {
        public BalancesViewModel viewModel;
        public BlankContentDialog dialog;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<BalancesViewModel.TrustlineCard> _filteredTrustlines;

        public ObservableCollection<BalancesViewModel.TrustlineCard> FilteredTrustlines
        {
            get { return _filteredTrustlines; }
            set { _filteredTrustlines = value; NotifyPropertyChanged("FilteredTrustlines"); }
        }

        public TrustlineDialog()
        {
            this.InitializeComponent();
        }

        public void Setup()
        {
            FilteredTrustlines = viewModel.TrustlineCards;
        }

        private void OnClickExit(object sender, PointerRoutedEventArgs e)
        {
            dialog.Hide();
            dialog.Dispose();
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
