using MvvmCross.ViewModels;
using stellar_dotnet_sdk;
using stellar_dotnet_sdk.responses;
using System;
using System.Threading.Tasks;

namespace SigfolioWallet.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public EventHandler<EventArgs> StreamEvent;

        private string _transactions;

        public string Transactions
        {
            get => _transactions;
            set => SetProperty(ref _transactions, value);
        }

        public override async Task Initialize()
        {
            using (var server = new Server("https://horizon.stellar.org"))
            {
                await Stream(server);
            }
        }

        private async Task Stream(Server server)
        {
            await server.Ledgers
                .Cursor("now")
                .Stream((sender, response) => { ShowOperationResponse(server, sender, response); })
                .Connect();
        }

        private async void ShowOperationResponse(Server server, object sender, LedgerResponse lr)
        {
            var operationRequestBuilder = server.Operations.ForLedger(lr.Sequence);
            var operations = await operationRequestBuilder.Execute();

            var accts = 0;
            var payments = 0;
            var offers = 0;
            var options = 0;

            foreach (var op in operations.Records)
                switch (op.Type)
                {
                    case "create_account":
                        accts++;
                        break;
                    case "payment":
                        payments++;
                        break;
                    case "manage_offer":
                        offers++;
                        break;
                    case "set_options":
                        options++;
                        break;
                }

            var ledgerCloseTime = Math.Round((DateTime.Now - DateTime.Parse(lr.ClosedAt)).TotalSeconds);
            Transactions = lr.TransactionCount.ToString();

            StreamEvent?.Invoke(this, EventArgs.Empty);
            //Console.WriteLine($"id: {lr.Sequence}, lct: {ledgerCloseTime}, tx/ops: {lr.TransactionCount + "/" + lr.OperationCount}, accts: {accts}, payments: {payments}, offers: {offers}, options: {options}");
            //Console.WriteLine($"Uri: {((LedgersRequestBuilder)sender).Uri}");
        }
    }
}
