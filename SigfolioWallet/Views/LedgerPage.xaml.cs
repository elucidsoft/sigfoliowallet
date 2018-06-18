using stellar_dotnet_sdk;
using stellar_dotnet_sdk.responses.effects;
using stellar_dotnet_sdk.responses.operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SigfolioWallet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LedgerPage : Page
    {      
        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var assetParam = (string)e.Parameter;
            PopulateLedger(assetParam);
        }

        private async void PopulateLedger(string assetParam)
        {
            var assetCode = assetParam == "XLM" ? null : assetParam;

            var transactions = await AppShell.server.Operations
                                     .ForAccount(KeyPair.FromAccountId(AppShell.AccountId))
                                     .Order(stellar_dotnet_sdk.requests.OrderDirection.DESC)
                                     .Limit(20)
                                     .Execute();

            var result = transactions.Records;


            var payments = result.Where(r => r is PaymentOperationResponse && 
                                            ((PaymentOperationResponse)r).AssetCode == assetCode)
                                .Select(r => (PaymentOperationResponse)r);

            var ledger = new List<LedgerItem>();

            //ledger.AddRange(created.Select(c => new LedgerItem() { Date = c.CreatedAt, Account = c.Account.AccountId, Deposits = c.StartingBalance }));
            ledger.AddRange(payments.Where(p => p.To.AccountId == AppShell.AccountId).Select(c => new LedgerItem() { Date = DateTimeOffset.Parse(c.CreatedAt).UtcDateTime, To = c.To.AccountId, From = c.From.AccountId, Deposits = c.Amount }));
            ledger.AddRange(payments.Where(p => p.From.AccountId == AppShell.AccountId).Select(c => new LedgerItem() { Date = DateTimeOffset.Parse(c.CreatedAt).UtcDateTime, To = c.To.AccountId, From = c.From.AccountId, Withdrawals = c.Amount }));

            this.gvTest.ItemsSource = ledger.OrderByDescending(l => l.Date);
            //this.gvTest
        }

        public LedgerPage()
        {
            this.InitializeComponent();


        }
    }

    class LedgerItem
    {
        public DateTime Date { get; set; }
        public String From { get; set; }
        public String To { get; set; }

        public String Withdrawals { get; set; }
        public String Deposits { get; set; }
        public String Balance { get; set; }

        //public String Description { get { return Account; } }

    }
}
