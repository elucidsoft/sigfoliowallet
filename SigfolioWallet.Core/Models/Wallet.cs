using LiteDB;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace SigfolioWallet.Core.Models
{
    public class Wallet : INotifyPropertyChanged
    {
        private string _walletName;
        private int _currentAccountId = -1;

        public event PropertyChangedEventHandler PropertyChanged;

        public Wallet()
        {
            Accounts = new ObservableCollection<Account>();
            Accounts.CollectionChanged += Accounts_CollectionChanged;
        }

        private void Accounts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentAccount)));
        }

        public int Id { get; set; }

        public int CurrentAccountId
        {
            get => _currentAccountId;
            set
            {
                _currentAccountId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentAccountId)));
            }
        }

        public bool IsCurrentWallet { get; set; }

        [BsonIgnore]
        public Account CurrentAccount => Accounts.SingleOrDefault(a => a.Id == CurrentAccountId);

        public ObservableCollection<Account> Accounts { get; set; }

        public string WalletName
        {
            get => _walletName;
            set
            {
                _walletName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WalletName)));
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Wallet wallet &&
                   Accounts.SequenceEqual(wallet.Accounts) &&
                   WalletName == wallet.WalletName;
        }

        public override int GetHashCode()
        {
            var hashCode = -283195593;
            hashCode = hashCode * -1521134295 + EqualityComparer<ObservableCollection<Account>>.Default.GetHashCode(Accounts);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(WalletName);
            return hashCode;
        }
    }
}
