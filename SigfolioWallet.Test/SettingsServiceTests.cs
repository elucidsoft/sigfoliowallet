using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services;
using System.Collections.Generic;

namespace SigfolioWallet.Test
{
    [TestClass]
    public class SettingsServiceTests
    {
        private AuthenticationService _authenticationService;
        private SettingsService _settingsService;

        private const string PrivateKey = "SABKP6TWACKPAYZOUHZOIDB4NGL57ZNJXPQF7XPFZXDRDICMHB4QOH65";
        private const string PublicKey = "GD6L6LCT42ZVODR55IL6MD7NLIPINSSSEOGJFGNVCTXJWNCMQJYVXTSL";

        private const string Password = "TestP@ssw0rd";

        [TestInitialize]
        public void Initialize()
        {
            _authenticationService = new AuthenticationService();
            _settingsService = new SettingsService(new TestStorageService(), new EncryptionService(), _authenticationService);
        }

        [TestMethod]
        public void TestEncryptAndDecryptPrivateKey()
        {
            _authenticationService.SetPassword(Password);
          
            var account = _settingsService.CreateAccount(PrivateKey);
            var privateKeyRetrievedFromEncryptedLayer = _settingsService.GetPrivateKey(account);

            Assert.AreEqual(PrivateKey, privateKeyRetrievedFromEncryptedLayer);
        }

        [TestMethod]
        public void TestPrivateKeyGeneratesCorrectPublicKey()
        {
            _authenticationService.SetPassword(Password);

            var account = _settingsService.CreateAccount(PrivateKey);

            Assert.AreEqual(PublicKey, account.PublicKey);
        }
    }
}

