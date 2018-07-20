using stellar_dotnet_sdk;
using stellar_dotnet_sdk.responses.operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SigfolioWallet.Core.Services
{
    public class TransactionService : ITransactionService
    {
        readonly IStellarHorizonService _stellarHorizonService;

        public TransactionService(IStellarHorizonService stellarHorizonService)
        {
            _stellarHorizonService = stellarHorizonService;
        }

        public async Task<List<Models.Transaction>> GetTransactionsAsync(string publicKey)
        {
            var operations = await _stellarHorizonService.Server.Operations
                                     .ForAccount(KeyPair.FromAccountId(publicKey))
                                     .Order(stellar_dotnet_sdk.requests.OrderDirection.DESC)
                                     .Limit(20)
                                     .Execute();


            var result = operations.Records;

            var payments = result.Where(r => r is PaymentOperationResponse &&
                                               ((PaymentOperationResponse)r).AssetCode == null)
                                   .Select(r => (PaymentOperationResponse)r);


            var transactions = new List<Models.Transaction>();

            transactions.AddRange(payments.Where(p => p.To.AccountId == publicKey).Select(c => new Models.Transaction() { Date = DateTimeOffset.Parse(c.CreatedAt).UtcDateTime, To = c.To.AccountId, From = c.From.AccountId, Amount = c.Amount }));
            transactions.AddRange(payments.Where(p => p.From.AccountId == publicKey).Select(c => new Models.Transaction() { Date = DateTimeOffset.Parse(c.CreatedAt).UtcDateTime, To = c.To.AccountId, From = c.From.AccountId, Amount = c.Amount }));


            return transactions;
        }

    }
}
