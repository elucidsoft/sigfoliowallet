using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using SigfolioWallet.Core.Services;

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
