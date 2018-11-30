using System;
using System.Collections.Generic;
using System.Text;

namespace SigfolioWallet.Core.Services.Interfaces
{
    public interface IAuthenticationService
    {
        byte[] GetPassword();

        void SetPassword(string password);

        bool IsAuthenticated { get; }
    }
}
