using LiteDB;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services.Interfaces;

using System;
using System.Threading.Tasks;

namespace SigfolioWallet.Core.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly IStorageService _storageService;
        private readonly IEncryptionService _encryptionService;
        private readonly IAuthenticationService _authenticationService;

        public EventHandler<PasswordEventArgs> OnPasswordRequested;

        private const string WalletCollectionName = "wallet";

        public SettingsService(IStorageService storageService, IEncryptionService encryptionService, IAuthenticationService authenticationService)
        {
            _storageService = storageService;
            _encryptionService = encryptionService;
            _authenticationService = authenticationService;
        }

        public Wallet Wallet { get; private set; }

        public string GetPrivateKey(Account account)
        {
           return _encryptionService.Decrypt(_authenticationService.GetPassword(), account);
        }

        public async Task<Account> CreateAccount(string privateKey)
        {
            var password = _authenticationService.GetPassword();
            var encryptionResults = await _encryptionService.Encrypt(password, privateKey);

            var keyPair = stellar_dotnet_sdk.KeyPair.FromSecretSeed(privateKey);
            var account = new Account
            {
                EncryptedPrivateKey = encryptionResults.EncryptedBytes,
                EncryptionKeys = encryptionResults.EncryptionKeys,
                PublicKey = stellar_dotnet_sdk.StrKey.EncodeStellarAccountId(keyPair.PublicKey)
            };

            return account;
        }

        public async Task<Wallet> LoadWallet()
        {
            using (var stream = await _storageService.GetStorageStream())
            using (var db = new LiteDatabase(stream))
            {
                var walletColl = db.GetCollection<Wallet>(WalletCollectionName);

                if (walletColl.Count() == 0)
                {
                    walletColl.Insert(new Wallet() { IsCurrentWallet = true });
                }

                Wallet = walletColl.FindOne(a => a.IsCurrentWallet);
            }

            return Wallet;
        }

        public async Task SaveWallet(Wallet wallet)
        {
            using (var stream = await _storageService.GetStorageStream())
            using (var db = new LiteDatabase(stream))
            {
                var walletColl = db.GetCollection<Wallet>(WalletCollectionName);
                walletColl.Upsert(wallet);
            }
        }

        public async void ResetSettings()
        {
            using (var stream = await _storageService.GetStorageStream())
            using (var db = new LiteDatabase(stream))
            {
                db.DropCollection(WalletCollectionName);
            }
        }
    }
}
