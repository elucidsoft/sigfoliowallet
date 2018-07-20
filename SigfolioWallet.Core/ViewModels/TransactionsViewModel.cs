using MvvmCross.ViewModels;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SigfolioWallet.Core.ViewModels
{
    public class TransactionsViewModel : MvxViewModel<string>
    {
        private string PubKey
        {
            get; set;
        }

        readonly ITransactionService _transactionsService;

        public TransactionsViewModel(ITransactionService transactionsService) => _transactionsService = transactionsService;

        public override async Task Initialize()
        {
            Transactions = await _transactionsService.GetTransactionsAsync(PubKey);
            await base.Initialize();

            
        }

        public override void Prepare(string parameter)
        {
            PubKey = parameter;
        }


        public override void Start()
        {
            base.Start();
            IsLoading = true;

        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(() => IsLoading); }
        }

        private List<Transaction> _transactions;
        public List<Transaction> Transactions
        {
            get { return _transactions; }
            set
            {
                SetProperty(ref _transactions, value);
            }
        }
    }
}
