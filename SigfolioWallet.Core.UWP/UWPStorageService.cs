using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.DataProtection;
using Windows.Storage;
using Windows.Storage.Streams;
using Newtonsoft.Json;
using SigfolioWallet.Core.Services;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Core.UWP
{
    public class StorageService : IStorageService
    {
        private readonly DataProtectionProvider _provider = new DataProtectionProvider("LOCAL = user");
        private readonly ApplicationDataContainer _localSettings;

        private const string SaltKey = "salt";
        private const string IvKey = "iv";

        public StorageService()
        {
            _localSettings = ApplicationData.Current.LocalSettings;
        }

        public StorageService(ApplicationDataContainer applicationDataContainer)
        {
            _localSettings = applicationDataContainer;
        }

        public async Task SaveEncryptedWalletToStorage(byte[] encryptedWallet)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalCacheFolder;
            var file = await localFolder.CreateFileAsync("wallet", CreationCollisionOption.ReplaceExisting);
            var stream = await file.OpenAsync(FileAccessMode.ReadWrite);

            using (var writeStream = stream.AsStreamForWrite())
            {
                writeStream.Write(encryptedWallet, 0, encryptedWallet.Length);
            }
        }

        public async Task StoreSaltAndInitializationVector(byte[] salt, byte[] iv)
        {
            IBuffer bufferSalt = CryptographicBuffer.CreateFromByteArray(salt);
            var protectedBufferSalt = await _provider.ProtectAsync(bufferSalt);

            IBuffer bufferIv = CryptographicBuffer.CreateFromByteArray(salt);
            var protectedBufferIv = await _provider.ProtectAsync(bufferIv);

            _localSettings.Values[SaltKey] = CryptographicBuffer.EncodeToBase64String(protectedBufferSalt);
            _localSettings.Values[IvKey] = CryptographicBuffer.EncodeToBase64String(protectedBufferIv);
        }

        public async Task<(byte[] Salt, byte[] IV)> GetSaltAndInitializationVector()
        {
            IBuffer bufferSalt = CryptographicBuffer.DecodeFromBase64String((string)_localSettings.Values[SaltKey]);
            var unprotectedBufferSalt = await _provider.UnprotectAsync(bufferSalt);

            IBuffer bufferIv = CryptographicBuffer.DecodeFromBase64String((string)_localSettings.Values[IvKey]);
            var unprotectedBufferIv = await _provider.UnprotectAsync(bufferIv);

            CryptographicBuffer.CopyToByteArray(unprotectedBufferSalt, out var saltBytes);
            CryptographicBuffer.CopyToByteArray(unprotectedBufferIv, out var ivBytes);

            return (Salt: saltBytes, IV: ivBytes);
        }

        public Task<byte[]> GetEncryptedWalletFromStorage()
        {
            throw new NotImplementedException();
        }
    }
}
