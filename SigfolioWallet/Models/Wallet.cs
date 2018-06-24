using stellar_dotnet_sdk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigfolioWallet.Models
{
    public class Wallet
    {
        public List<Account> Accounts { get; set; }
        public String WalletName { get; set; }

        public Wallet(string WalletName, FileStream walletFile)
        {
            throw new NotImplementedException();
        }

        public Wallet(string WalletName, string accountId)
        {
            Accounts = new List<Account>
            {
                new Account(accountId)
            };
        }

        public void Add(Account account)
        {
            throw new NotImplementedException();
        }

        public void Delete(Account account)
        {
            throw new NotImplementedException();
        }

        public void Update(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
