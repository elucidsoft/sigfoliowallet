using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SigfolioWallet.Core.ViewModels.Modal
{
    public class TrustlineDialogViewModel : MvxNavigationViewModel<BalancesViewModel>, IMvxNotifyPropertyChanged
    {
        private BalancesViewModel _balancesViewModel;

        private ObservableCollection<BalancesViewModel.TrustlineCard> _filteredTrustlines;

        public ObservableCollection<BalancesViewModel.TrustlineCard> FilteredTrustlines
        {
            get { return _filteredTrustlines; }
            set { _filteredTrustlines = value; RaisePropertyChanged("FilteredTrustlines"); }
        }

        public TrustlineDialogViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IAuthenticationService authenticationService)
            : base(logProvider, navigationService)
        {
            Close = new MvxAsyncCommand(async () => await NavigationService.Close(this));
        }

        public override void Prepare(BalancesViewModel parameter)
        {
            _balancesViewModel = parameter;
            FilteredTrustlines = _balancesViewModel.TrustlineCards;
        }

        public IMvxAsyncCommand Close { get; set; }

        public void RefreshFilteredTrustlines(string filterString)
        {
            var tc = _balancesViewModel.TrustlineCards.Where(item => item.Trustline.AssetCode.Contains(filterString));
            FilteredTrustlines = new ObservableCollection<BalancesViewModel.TrustlineCard>(tc);
        }
    }
}