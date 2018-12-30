using SigfolioWallet.Core.Services.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SigfolioWallet.Core.Services
{
    //TODO: I need to redo how this is done, but for now its stubbed out like this...
    public class AuthenticationService : IAuthenticationService
    {
        public event EventHandler<PasswordEventArgs> RequestPassword;

        private byte[] _password;

        public byte[] GetPassword()
        {
            if (_password.Length == 0)
            {
                var passwordEventArgs = new PasswordEventArgs();
                OnRequestPassword(passwordEventArgs);

                _password = passwordEventArgs.Password;
            }

            return _password;
        }

        public void SetPassword(string password)
        {
            _password = EncodePassword(password);
        }

        public static byte[] EncodePassword(string password)
        {
            var sha256 = new SHA256Managed();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public void ClearPassword()
        {
            Array.Clear(_password, 0, _password.Length);
        }

        public bool IsAuthenticated => _password.Length > 0;

        protected virtual void OnRequestPassword(PasswordEventArgs e)
        {
            RequestPassword?.Invoke(this, e);
        }
    }
}
