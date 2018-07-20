using System;
using System.Collections.Generic;
using System.Text;

namespace SigfolioWallet.Core.Models
{
    public class Transaction
    {
        public Transaction()
        {

        }

        public string Hash { get; set; }
        public string Amount { get; set; }
        public DateTime Date { get; set; }
        public string AssetType { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
