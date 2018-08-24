using MvvmCross.ViewModels;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services;
using System.Collections.Generic;
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
            IsLoading = true;
        }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; RaisePropertyChanged(() => IsLoading); }
        }

        public List<Transaction> Transactions
        {
            get => _transactions;
            set => SetProperty(ref _transactions, value);
        }
    }
}
