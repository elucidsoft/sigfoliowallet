using System;
using System.Collections.Generic;
using System.Text;

namespace SigfolioWallet.Core.Models
{
    public class Balance
    {
        public string Amount { get; set; }
        public string AssetCode { get; set; }
        public string AssetType { get; set; }
        public string IssuerAddress { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Balance balance &&
                   Amount == balance.Amount &&
                   AssetCode == balance.AssetCode &&
                   AssetType == balance.AssetType &&
                   IssuerAddress == balance.IssuerAddress;
        }

        public override int GetHashCode()
        {
            var hashCode = -1441087147;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Amount);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AssetCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AssetType);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IssuerAddress);
            return hashCode;
        }
    }
}
