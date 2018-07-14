using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SigfolioWallet.Core.Services
{
    public interface IWalletService
    {
        Task<string> GetNativeBalance(string asset);
    }
}
