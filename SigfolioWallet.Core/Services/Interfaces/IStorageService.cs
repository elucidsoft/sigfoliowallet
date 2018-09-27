using System.IO;
using System.Threading.Tasks;
using SigfolioWallet.Core.Models;

namespace SigfolioWallet.Core.Services.Interfaces
{
    public interface IStorageService
    {
        Task<Stream> GetStorageStream();
    }
}
