using System;
using System.Security.Cryptography;
using System.Text;
using SigfolioWallet.Core.Services;

namespace SigfolioWallet.Core
{
    public class PasswordEventArgs : EventArgs
    {
        public byte[] Password { get; private set; }

        public void SetPassword(string password)
        {
            Password = AuthenticationService.EncodePassword(password);
        }

        public string Message => "Please type in your password to unlock the wallet.";
    }
}