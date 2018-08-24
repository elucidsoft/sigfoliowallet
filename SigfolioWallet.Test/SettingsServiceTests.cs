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
            var settingsService = new SettingsService(testStorageService, new EncryptionService(), new AuthenticationService());

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

            using (var encryptedStream = new MemoryStream(testStorageService.EncryptedWallet))
            using (var reader = new StreamReader(encryptedStream))
            {
                var encrypedJson = await reader.ReadToEndAsync();
                Assert.IsFalse(encrypedJson.Contains("test"));
            }
        }
    }

    public class TestStorageService : IStorageService
    {
        public byte[] EncryptedWallet;
        public byte[] Salt;
        public byte[] Iv;

        public Task StoreSaltAndInitializationVector(byte[] salt, byte[] iv)
        {
            Salt = salt;
            Iv = iv;
            return Task.CompletedTask;
        }

        public Task<(byte[] Salt, byte[] IV)> GetSaltAndInitializationVector()
        {
            return Task.FromResult((Salt: Salt, Iv: Iv));
        }

        public Task<byte[]> GetEncryptedWalletFromStorage()
        {
            return Task.FromResult(EncryptedWallet);
        }

        public async Task SaveEncryptedWalletToStorage(byte[] encryptedWallet)
        {
            EncryptedWallet = encryptedWallet;
            await Task.CompletedTask;
        }
    }

}

