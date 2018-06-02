using stellar_dotnet_sdk;
using stellar_dotnet_sdk.responses.effects;
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

namespace StellarNowWallet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LedgerPage : Page
    {
        public string AccountId { get; set; }
        
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            AccountId = (string)e.Parameter;

            txtTitle.Text = String.Format(txtTitle.Text, AccountId);

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                PopulateLedger();
            });
        }

        private async void PopulateLedger()
        {
            Network.UsePublicNetwork();
            var server = new Server("https://horizon.stellar.org/");

            var effects = await server.Effects
                                     .ForAccount(KeyPair.FromAccountId(AccountId))
                                     .Limit(10)
                                     .Execute();

            var result = effects.Records;

            var credits = result.Where(r => r is AccountCreditedEffectResponse).Select(r => (AccountCreditedEffectResponse)r);
            //var debits = effects.Records.Where(r => r is AccountDebitedEffectResponse).Select(r => (AccountDebitedEffectResponse)r); ;


            var ledger = new List<LedgerItem>();

            ledger.AddRange(credits.Select(c => new LedgerItem() { Date = DateTime.Now, Account = c.Account.AccountId, Deposits = c.Amount }));
            //ledger.AddRange(debits.Select(c => new LedgerItem() { Date = DateTime.Now, Account = c.Account.AccountId, Withdrawals = c.Amount }));

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
        public String Account { get; set; }

        public String Withdrawals { get; set; }
        public String Deposits { get; set; }
        public String Balance { get; set; }

        public String Description { get { return Account; } }

    }
}
