using Newtonsoft.Json;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services.Interfaces;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SigfolioWallet.Core.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly IStorageService _storageService;
        private readonly IEncryptionService _encryptionService;
        private readonly IAuthenticationService _authenticationService;

        public SettingsService(IStorageService storageService, IEncryptionService encryptionService, IAuthenticationService authenticationService)
        {
            _storageService = storageService;
            _encryptionService = encryptionService;
            _authenticationService = authenticationService;
        }

        public Wallet Wallet { get; private set; }

        public async Task<Wallet> LoadWallet()
        {
            if (!await _storageService.WalletExists())
                return new Wallet();

            var encryptedWallet = await _storageService.GetEncryptedWalletFromStorage();

            //var decryptedWalletJson = _encryptionService.Decrypt(_authenticationService.GetPassword(), encryptedWallet.EncryptedWallet, encryptedWallet.Salt, encryptedWallet.IV);
            //TODO: Undid this for time being while I think about how I want to handle this behavior...
            var decryptedWalletJson = _encryptionService.Decrypt("password", encryptedWallet.EncryptedWallet, encryptedWallet.Salt, encryptedWallet.IV);
            var wallet = JsonConvert.DeserializeObject<Wallet>(decryptedWalletJson);

            return wallet;
        }

        public async Task SaveWallet(Wallet wallet)
        {
            Wallet = wallet;

            var walletJson = JsonConvert.SerializeObject(wallet);
//var encrypted = _encryptionService.Encrypt(_authenticationService.GetPassword(), walletJson);
            var encrypted = _encryptionService.Encrypt("password", walletJson);

            await _storageService.SaveEncryptedWalletToStorage(encrypted.EncryptedBytes, encrypted.Salt, encrypted.IV);
        }

        public async void ResetSettings()
        {

        }
    }
}
