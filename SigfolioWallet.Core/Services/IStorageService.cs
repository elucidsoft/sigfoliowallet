using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SigfolioWallet.Core.Services
{
    public interface IStorageService
    {
        Task<Stream> GetStorageStream();
    }
}
