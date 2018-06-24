using SigfolioWallet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigfolioWallet.ViewModels
{
    public class WalletViewModel : NotificationBase
    {
        readonly Wallet wallet;

        public WalletViewModel(String walletName, String accountId)
        {
            wallet = new Wallet(walletName, accountId);
            _SelectedIndex = -1;

            foreach( var account in wallet.Accounts)
            {
                var aVM = new AccountViewModel(account);
                aVM.PropertyChanged += Account_OnNotifyPropertyChanged;
                _Accounts.Add(aVM);
            }
        }

        public WalletViewModel(String walletName, FileStream fileName)
        {
            throw new NotImplementedException();
        }

        ObservableCollection<AccountViewModel> _Accounts = new ObservableCollection<AccountViewModel>();
        public ObservableCollection<AccountViewModel> Accounts
        {
            get { return _Accounts; }
            set { SetProperty(ref _Accounts, value); }
        }

        String _WalletName;
        public String WalletName
        {
            get
            {
                return wallet.WalletName;
            }
        }

        int _SelectedIndex;
        public int SelectIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (SetProperty(ref _SelectedIndex, value))
                {
                    RaisePropertyChanged(nameof(SelectedAccount));
                }
            }
        }

        public AccountViewModel SelectedAccount
        {
            get { return (_SelectedIndex >= 0) ? _Accounts[_SelectedIndex] : null; }
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        void Account_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            wallet.Update((AccountViewModel)sender);
        }
    }
}
