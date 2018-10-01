using MvvmCross.ViewModels;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Core.ViewModels
{
    public class TransactionsViewModel : MvxViewModel
    {
        private readonly ITransactionService _transactionsService;
        private readonly ISettingsService _settingsService;

        private List<Transaction> _transactions;
        private bool _isLoading;
        
        public TransactionsViewModel(ITransactionService transactionsService, ISettingsService settingsService)
        {
            _transactionsService = transactionsService;
            _settingsService = settingsService;
        }

        public override async Task Initialize()
        {
            Transactions = await _transactionsService.GetTransactionsAsync(_settingsService.Wallet.CurrentAccount.PublicKey);
            await base.Initialize();
            
        }

        public override void Start()
        {
            base.Start();
            Filter = "";
            IsLoading = true;
        }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; RaisePropertyChanged(() => IsLoading); }
        }

        private string _filter;
        public string Filter
        {
            get { return _filter; }
            set { _filter = value; RaisePropertyChanged(() => Transactions); }
        }

        public List<Transaction> Transactions
        {
            get //{ return _transactions; }
            {
                if (Filter == "all" || _transactions == null) { return _transactions; }
                else { return _transactions.Where(t => t.TransactionType == Filter).ToList(); }
            }
            set => SetProperty(ref _transactions, value);
            }
    }
}
