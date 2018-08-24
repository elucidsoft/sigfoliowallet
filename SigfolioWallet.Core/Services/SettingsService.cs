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

        public Wallet Wallet { get; set; }

        public async Task<Wallet> LoadWallet()
        {
            var saltIv = await _storageService.GetSaltAndInitializationVector();
            var encryptedWallet = await _storageService.GetEncryptedWalletFromStorage();

            var decryptedWalletJson = _encryptionService.Decrypt(_authenticationService.GetPassword(), encryptedWallet, saltIv.IV, saltIv.Salt);
            var wallet = JsonConvert.DeserializeObject<Wallet>(decryptedWalletJson);

            return wallet;
        }

        public async Task SaveWallet(Wallet wallet)
        {
            var walletJson = JsonConvert.SerializeObject(wallet);
            var encrypted = _encryptionService.Encrypt(_authenticationService.GetPassword(), walletJson);

            await _storageService.StoreSaltAndInitializationVector(encrypted.Salt, encrypted.IV);
            await _storageService.SaveEncryptedWalletToStorage(encrypted.EncryptedBytes);
        }

        public async void ResetSettings()
        {

        }
    }
}
