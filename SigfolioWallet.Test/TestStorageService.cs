using System.IO;
using System.Threading.Tasks;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Test
{
    public class TestStorageService : IStorageService
    {
        public Task<Stream> GetStorageStream()
        {
            return Task.FromResult((Stream)new MemoryStream());
        }
    }
}