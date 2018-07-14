using System;
using System.Collections.Generic;
using System.Text;

namespace SigfolioWallet.Core.Models
{
    public class Wallet
    {
        public Wallet()
        {
            Accounts = new List<Account>();
        }

        public List<Account> Accounts { get; set; }

        public String WalletName { get; set; }

        public String Balance { get; set; }
    }
}
