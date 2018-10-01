using SigfolioWallet.Core.Models;
using stellar_dotnet_sdk;
using stellar_dotnet_sdk.responses.operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Core.Services
{
    public class TransactionService : ITransactionService
    {
        readonly IStellarHorizonService _stellarHorizonService;

        public TransactionService(IStellarHorizonService stellarHorizonService)
        {
            _stellarHorizonService = stellarHorizonService;
        }

        public async Task<TransactionDetails> GetTransactionDetails(long operationId)
        {
            var operation = await _stellarHorizonService.Server.Operations.Operation(operationId).Execute();
            

            var operationDetail = operation.Records.FirstOrDefault();
            
          
            if( operationDetail is PaymentOperationResponse)
            {
                return GetPaymentOperationReponseTransactionDetails(operationDetail);
            }
            //TODO: Eventually implement the other operationResponses here.
            else
            {
                return null;
            }

        }

        private TransactionDetails GetPaymentOperationReponseTransactionDetails(OperationResponse operationDetail)
        {
            var paymentOpResp = (PaymentOperationResponse)operationDetail;

            //Get some other transaction details we might need, like the Memo if there is one.
            var transTask = _stellarHorizonService.Server.Transactions.Transaction(operationDetail.TransactionHash);
            var transResult = transTask.Result;

            var transDetails = new TransactionDetails()
            {
                CreatedAt = DateTimeOffset.Parse(paymentOpResp.CreatedAt).UtcDateTime,
                Id = paymentOpResp.Id,
                Memo = transResult.MemoStr,
                Payee = paymentOpResp.To.AccountId,
                Payor = paymentOpResp.SourceAccount.AccountId,
                TransactionType = paymentOpResp.Type
            };

            return transDetails;

        }

        public async Task<List<Models.Transaction>> GetTransactionsAsync(string publicKey)
        {
            var operations = await _stellarHorizonService.Server.Operations
                                     .ForAccount(KeyPair.FromAccountId(publicKey))
                                     .Order(stellar_dotnet_sdk.requests.OrderDirection.DESC)
                                     //.Limit(20)
                                     .Execute();


            var result = operations.Records;

            var payments = result.Where(r => r is PaymentOperationResponse &&
                                               ((PaymentOperationResponse)r).AssetCode == null)
                                   .Select(r => (PaymentOperationResponse)r);


            var transactions = new List<Models.Transaction>();


            //Credits
            transactions.AddRange(payments.Where(p => p.To.AccountId == publicKey).Select(c => new Models.Transaction() { TransactionType = "credit",  Id = c.Id,  Date = DateTimeOffset.Parse(c.CreatedAt).UtcDateTime, To = c.To.AccountId, From = c.From.AccountId, Amount = c.Amount }));

            //Debits
            transactions.AddRange(payments.Where(p => p.From.AccountId == publicKey).Select(c => new Models.Transaction() { TransactionType = "debit", Id = c.Id, Date = DateTimeOffset.Parse(c.CreatedAt).UtcDateTime, To = c.To.AccountId, From = c.From.AccountId, Amount = c.Amount }));


            return transactions;
        }

    }
}
