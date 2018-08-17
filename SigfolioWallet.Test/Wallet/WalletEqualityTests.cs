using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigfolioWallet.Core.Models;

namespace SigfolioWallet.Test.Wallet
{
    [TestClass]
    public class WalletEqualityTests
    {
        [TestMethod]
        public void TestWalletsAreEqual()
        {
            var account1 = CreateAccount("TestAccount1", "1234567890abcdefghijklmnopqrstuvwxyz");
            var account2 = CreateAccount("TestAccount2", "dfsgasdfdfdsalkfsadjrtl;k32j465098235243sfg");

            var wallet1 = CreateWallet("TestWallet", account1, account2);
            var wallet2 = CreateWallet("TestWallet", account1, account2);

            Assert.AreEqual(wallet1, wallet2);
        }

        [TestMethod]
        public void TestWalletsAreNotEqual()
        {
            var account1 = CreateAccount("TestAccount1", "1234567890abcdefghijklmnopqrstuvwxyz");
            var account2 = CreateAccount("TestAccount2", "dfsgasdfdfdsalkfsadjrtl;k32j465098235243sfg");

            var wallet1 = CreateWallet("TestWallet", account1, account2);
            var wallet2 = CreateWallet("dslkfjasdklf", account1, account2);

            Assert.AreNotEqual(wallet1, wallet2);
        }

        private static Core.Models.Wallet CreateWallet(string walletName, Account account1, Account account2)
        {
            var wallet = new Core.Models.Wallet { WalletName = walletName };
            
            wallet.Accounts.Add(account1);
            wallet.Accounts.Add(account2);

            return wallet;
        }

        private static Account CreateAccount(string name, string publicKey)
        {
            var account1 = new Account
            {
                Name = name,
                PublicKey = publicKey
            };
            return account1;
        }
    }
}
