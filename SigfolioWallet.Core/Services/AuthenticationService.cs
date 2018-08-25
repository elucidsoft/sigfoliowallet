using SigfolioWallet.Core.Services.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SigfolioWallet.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public event EventHandler<PasswordEventArgs> RequestPassword;

        public string GetPassword()
        {
            var passwordEventArgs = new PasswordEventArgs();
            OnRequestPassword(passwordEventArgs);

            return DecodePassword(passwordEventArgs.Password);
        }

        public static string DecodePassword(byte[] password)
        {
            return Encoding.UTF8.GetString(password);
        }

        public static byte[] EncodePassword(string password)
        {
            var sha256 = new SHA256Managed();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        protected virtual void OnRequestPassword(PasswordEventArgs e)
        {
            RequestPassword?.Invoke(this, e);
        }
    }
}
