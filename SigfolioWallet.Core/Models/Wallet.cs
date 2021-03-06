﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SigfolioWallet.Core.Models
{
    public class Wallet
    {
        public Wallet()
        {
            Accounts = new List<Account>();
        }

        public int Id { get; set; }

        public int CurrentAccountId { get; set; }

        public bool IsCurrentWallet { get; set; }

        [BsonIgnore]
        public Account CurrentAccount => Accounts.SingleOrDefault(a => a.Id == CurrentAccountId);

        public List<Account> Accounts { get; set; }

        public string WalletName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Wallet wallet &&
                   Accounts.SequenceEqual(wallet.Accounts) &&
                   WalletName == wallet.WalletName;
        }

        public override int GetHashCode()
        {
            var hashCode = -283195593;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Account>>.Default.GetHashCode(Accounts);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(WalletName);
            return hashCode;
        }
    }
}
