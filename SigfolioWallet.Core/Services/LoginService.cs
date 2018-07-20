using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SigfolioWallet.Core.Services
{
    public class LoginService : ILoginService
    {
        public Task<bool> IsAuthenticated()
        {
            return Task.FromResult(false);
        }
    }
}
