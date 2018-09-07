using System;
using System.Collections.Generic;
using System.Text;

namespace SigfolioWallet.Core.Models
{
    public class TransactionDetails
    {
        public long Id { get; set; }

        public string TransactionType { get; set; }

        /// <summary>
        /// Account that recieves the transaction.
        /// </summary>
        public string Payee { get; set; }

        /// <summary>
        /// Account that sends the transaction.
        /// </summary>
        public string Payor { get; set; }



        public DateTime CreatedAt { get; set; }


        public string Memo { get; set; }

    }
}
