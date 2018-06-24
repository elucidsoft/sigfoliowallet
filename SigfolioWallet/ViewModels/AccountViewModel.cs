using SigfolioWallet.Models;

namespace SigfolioWallet.ViewModels
{
    public class AccountViewModel : NotificationBase<Account>
    {
        public AccountViewModel(Account account = null) : base(account)
        {
        }

        public string Name
        {
            get { return This.Name; }
            set { SetProperty(This.Name, value, () => This.Name = value); }
        }

        public string ShortName
        {
            get { return This.AccountShortId; }
        }

        public string AccountId => This.AccountId;
    }
}
