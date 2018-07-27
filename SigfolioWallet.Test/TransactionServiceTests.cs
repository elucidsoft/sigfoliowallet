using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SigfolioWallet.Core.Services;
using stellar_dotnet_sdk.federation;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SigfolioWallet.Test
{
    [TestClass]
    public class TransactionServiceTests
    {
        private Mock<FakeHttpMessageHandler> _fakeHttpMessageHandler;
        private HttpClient _httpClient;
        private FederationServer _server;

        IStellarHorizonService _stellarHorizonservice;

        [TestInitialize]
        public void Setup()
        {
            _server = new FederationServer("https://api.stellar.org/federation", "stellar.org");

            _fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler> { CallBase = true };
            _httpClient = new HttpClient(_fakeHttpMessageHandler.Object);
            _server.HttpClient = _httpClient;

            _stellarHorizonservice = new StellarHorizonService("https://horizon-testnet.stellar.org/", _httpClient);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _httpClient.Dispose();
            _server.Dispose();
        }

        [TestMethod]
        public async Task TestGetTransactionsAsync()
        {
            ITransactionService transactionService = new TransactionService(_stellarHorizonservice);
            var json = File.ReadAllText(Path.Combine("testdata", "operationsPayment.json"));

            When(HttpStatusCode.OK, json);

            var transactions = await transactionService.GetTransactionsAsync("GB72RBWW7YDFUR3UIFZUKOTIETBVMVSC4IR7HHEHGTCDTXZ4AETSQMNF");
            Assert.IsTrue(transactions.Count > 0);
        }

        private void When(HttpStatusCode httpStatusCode, string content)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = httpStatusCode,
                Content = new StringContent(content),

            };

            httpResponseMessage.Headers.Add("X-Ratelimit-Limit", "-1");
            httpResponseMessage.Headers.Add("X-Ratelimit-Remaining", "-1");
            httpResponseMessage.Headers.Add("X-Ratelimit-Reset", "-1");

            _fakeHttpMessageHandler.Setup(a => a.Send(It.IsAny<HttpRequestMessage>())).Returns(httpResponseMessage);
        }
    }

    public abstract class FakeHttpMessageHandler : HttpMessageHandler
    {
        public Uri RequestUri { get; private set; }

        public virtual HttpResponseMessage Send(HttpRequestMessage request)
        {
            throw new NotImplementedException();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            RequestUri = request.RequestUri;
            return await Task.FromResult(Send(request));
        }
    }
}
