using SigfolioWallet.Core.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace SigfolioWallet.Core.UWP
{
    public class StorageService : IStorageService
    {
        public async Task<Stream> GetStorageStream()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalCacheFolder;
            var file = await localFolder.CreateFileAsync("wallet", CreationCollisionOption.ReplaceExisting);
            var stream = await file.OpenAsync(FileAccessMode.ReadWrite);
            return stream.AsStream();
        }
    }
}

