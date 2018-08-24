using System;
using System.Collections.Generic;
using System.Text;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public string GetPassword()
        {
            //TODO:
            //This is obviously temporary until the framework can be built out for this, ideally it would call
            //into a view and request the password via a view which would popup a prompt to the user...
            
            return "password";
        }
    }
}
