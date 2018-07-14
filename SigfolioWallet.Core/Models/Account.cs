using System;
using System.Collections.Generic;
using System.Text;

namespace SigfolioWallet.Core.Models
{
    public class Account
    {
        public Account()
        {

        }

        public string Name { get; set; }

        public string PublicKey { get; set; }
    }
}
