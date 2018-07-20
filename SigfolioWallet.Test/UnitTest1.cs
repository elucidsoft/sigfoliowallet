using SigfolioWallet.Core.Services;
using System;
using Xunit;

namespace SigfolioWallet.Test
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            IStellarHorizonService service = new StellarHorizonService("https://horizon-testnet.stellar.org/");
            ITransactionService transactionService = new TransactionService(service);


            var transactions = await transactionService.GetTransactionsAsync("GB72RBWW7YDFUR3UIFZUKOTIETBVMVSC4IR7HHEHGTCDTXZ4AETSQMNF");
            Assert.True(transactions.Count > 0);
        }
    }
}
