using SigfolioWallet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace SigfolioWallet.Core.Services
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetTransactionsAsync(string publicKey);
    }
}
