using System;
using System.Collections.Generic;
using System.Text;
using stellar_dotnet_sdk;

namespace SigfolioWallet.Core.Models
{
    public class Trustline
    {
        public string AssetCode { get; set; }
        public Asset AssetType { get; set; }
        public string IssuerAddress { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Trustline trustline &&
                   AssetCode == trustline.AssetCode &&
                   AssetType == trustline.AssetType &&
                   IssuerAddress == trustline.IssuerAddress;
        }

        public override int GetHashCode()
        {
            var hashCode = -1441087147;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AssetCode);
            hashCode = hashCode * -1521134295 + AssetType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IssuerAddress);
            return hashCode;
        }
    }
}
