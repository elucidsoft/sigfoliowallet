using System;
using System.Collections.Generic;
using System.Text;

namespace SigfolioWallet.Core.Models
{
    public class Account
    {
        private string _id;

        public Account()
        {

        }

        public string Id {
            get
            {
                if (string.IsNullOrEmpty(_id))
                {
                    _id = Guid.NewGuid().ToString("N");
                }

                return _id;
            }
            set => _id = value;
        }

        public string Name { get; set; }

        public string PublicKey { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Account account &&
                   Id == account.Id &&
                   Name == account.Name &&
                   PublicKey == account.PublicKey;
        }

        public override int GetHashCode()
        {
            var hashCode = -1441087147;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PublicKey);
            return hashCode;
        }
    }
}
