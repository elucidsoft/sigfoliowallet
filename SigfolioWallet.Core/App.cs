using MvvmCross;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.Services;
using SigfolioWallet.Core.Services.Interfaces;

namespace SigfolioWallet.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterSingleton<IStellarHorizonService>(() => new StellarHorizonService("https://horizon-testnet.stellar.org/"));

            Mvx.RegisterType<INavigationService, NavigationService>();
            Mvx.RegisterType<IWalletService, WalletService>();
            Mvx.RegisterType<ILoginService, LoginService>();
            Mvx.RegisterType<ITransactionService, TransactionService>();
            Mvx.RegisterType<IEncryptionService, EncryptionService>();
            Mvx.RegisterType<IAuthenticationService, AuthenticationService>();

            //StorageService is Registered in the Application itself since its platform specific (UWP, Android, etc.)
            Mvx.RegisterSingleton<ISettingsService>(
                new SettingsService(
                    Mvx.Resolve<IStorageService>(),
                    Mvx.Resolve<IEncryptionService>(),
                    Mvx.Resolve<IAuthenticationService>())
            );

            RegisterCustomAppStart<AppStart>();
        }
    }
}