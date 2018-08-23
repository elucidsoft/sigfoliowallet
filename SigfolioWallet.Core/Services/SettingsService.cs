using LiteDB;
using SigfolioWallet.Core.Models;
using System.Threading.Tasks;

namespace SigfolioWallet.Core.Services
{
    public class SettingsService : ISettingsService
    {
        private const string WalletCollectionName = "wallet";

        private readonly IStorageService _storageService;

        public SettingsService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public Wallet Wallet { get; set; }

        public async Task<Wallet> LoadWallet()
        {
            using (var stream = await _storageService.GetStorageStream())
            using (var db = new LiteDatabase(stream))
            {
                var walletColl = db.GetCollection<Wallet>(WalletCollectionName);

                if (walletColl.Count() == 0)
                {
                    walletColl.Insert(new Wallet { IsCurrentWallet = true });
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
