using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services;
using SigfolioWallet.Core.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SigfolioWallet.Test
{
    [TestClass]
    public class SettingsServiceTests
    {
        [TestMethod]
        public async Task SaveWalletTest()
        {
            var testStorageService = new TestStorageService();
            var authenticationService = new AuthenticationService();

            authenticationService.RequestPassword += (sender, args) => { args.SetPassword("password"); };

            var settingsService = new SettingsService(testStorageService, new EncryptionService(), authenticationService);

            var wallet = new Core.Models.Wallet
            {
                WalletName = "test wallet",
                Accounts = new List<Account>(new[]
                {
                    new Account
                    {
                        Name = "One",
                        PublicKey = "1253223sadffdfgasdfadsf"
                    }
                })
            };

            await settingsService.SaveWallet(wallet);
            var loadedWallet = await settingsService.LoadWallet();

            Assert.AreEqual(wallet, loadedWallet);

            var encryptedWallet = testStorageService.GetEncrypedWallet();
            using (var encryptedStream = new MemoryStream(encryptedWallet))
            using (var reader = new StreamReader(encryptedStream))
            {
                var encrypedJson = await reader.ReadToEndAsync();
                Assert.IsFalse(encrypedJson.Contains("test"));
            }
        }
    }

    public class TestStorageService : IStorageService
    {
        private byte[] EncryptedWallet;
        private byte[] Salt;
        private byte[] Iv;

        public byte[] GetEncrypedWallet()
        {
            return EncryptedWallet;
        }

        public Task<(byte[] EncryptedWallet, byte[] Salt, byte[] IV)> GetEncryptedWalletFromStorage()
        {
            return Task.FromResult((EncryptedWallet: EncryptedWallet, Salt: Salt, Iv: Iv));
        }

        public Task SaveEncryptedWalletToStorage(byte[] encryptedWallet, byte[] salt, byte[] iv)
        {
            EncryptedWallet = encryptedWallet;
            Salt = salt;
            Iv = iv;

            return Task.CompletedTask;
        }

        public Task<bool> WalletExists()
        {
            return Task.FromResult(EncryptedWallet.Length > 0);
        }
    }

}

