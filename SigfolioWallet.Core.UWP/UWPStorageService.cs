using SigfolioWallet.Core.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.DataProtection;
using Windows.Storage;
using Windows.Storage.Streams;

namespace SigfolioWallet.Core.UWP
{
    public class StorageService : IStorageService
    {
        private readonly DataProtectionProvider _provider = new DataProtectionProvider("LOCAL = user");
        private readonly ApplicationDataContainer _localSettings;
        private readonly StorageFolder _localFolder = ApplicationData.Current.LocalCacheFolder;


        private const string SaltKey = "salt_key";
        private const string IvKey = "iv_key";
        private const string WalletKey = "wallet";

        public StorageService()
        {
            _localSettings = ApplicationData.Current.LocalSettings;
        }

        public StorageService(ApplicationDataContainer applicationDataContainer)
        {
            _localSettings = applicationDataContainer;
        }

        public async Task<(byte[] EncryptedWallet, byte[] Salt, byte[] IV)> GetEncryptedWalletFromStorage()
        {
            IBuffer bufferSalt = CryptographicBuffer.DecodeFromBase64String((string)_localSettings.Values[SaltKey]);
            var unprotectedBufferSalt = await _provider.UnprotectAsync(bufferSalt);

            IBuffer bufferIv = CryptographicBuffer.DecodeFromBase64String((string)_localSettings.Values[IvKey]);
            var unprotectedBufferIv = await _provider.UnprotectAsync(bufferIv);

            CryptographicBuffer.CopyToByteArray(unprotectedBufferSalt, out var saltBytes);
            CryptographicBuffer.CopyToByteArray(unprotectedBufferIv, out var ivBytes);

            var file = await _localFolder.GetFileAsync(WalletKey);
            var stream = await file.OpenAsync(FileAccessMode.Read);

            byte[] encrypedWallet = { };
            using (var readStream = stream.AsStreamForRead())
            {
                readStream.Write(encrypedWallet, 0, (int)readStream.Length);
            }
            
            return (EncryptedWallet: encrypedWallet, Salt: saltBytes, IV: ivBytes);
        }

        public async Task SaveEncryptedWalletToStorage(byte[] encryptedWallet, byte[] salt, byte[] iv)
        {
            await StoreSaltAndInitializationVector(salt, iv);


            var file = await _localFolder.CreateFileAsync(WalletKey, CreationCollisionOption.ReplaceExisting);
            var stream = await file.OpenAsync(FileAccessMode.ReadWrite);

            using (var writeStream = stream.AsStreamForWrite())
            {
                writeStream.Write(encryptedWallet, 0, encryptedWallet.Length);
            }
        }

        public async Task<bool> WalletExists()
        {
            var file = await _localFolder.TryGetItemAsync(WalletKey);
            return file != null;
        }

        private async Task StoreSaltAndInitializationVector(byte[] salt, byte[] iv)
        {
            IBuffer bufferSalt = CryptographicBuffer.CreateFromByteArray(salt);
            var protectedBufferSalt = await _provider.ProtectAsync(bufferSalt);

            IBuffer bufferIv = CryptographicBuffer.CreateFromByteArray(salt);
            var protectedBufferIv = await _provider.ProtectAsync(bufferIv);

            _localSettings.Values[SaltKey] = CryptographicBuffer.EncodeToBase64String(protectedBufferSalt);
            _localSettings.Values[IvKey] = CryptographicBuffer.EncodeToBase64String(protectedBufferIv);
        }
    }
}
