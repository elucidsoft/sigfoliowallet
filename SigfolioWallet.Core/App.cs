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
            Mvx.IoCProvider.RegisterSingleton<IStellarHorizonService>(() => new StellarHorizonService("https://horizon-testnet.stellar.org/"));

            Mvx.IoCProvider.RegisterType<INavigationService, NavigationService>();
            Mvx.IoCProvider.RegisterType<IWalletService, WalletService>();
            Mvx.IoCProvider.RegisterType<ILoginService, LoginService>();
            Mvx.IoCProvider.RegisterType<ITransactionService, TransactionService>();
            Mvx.IoCProvider.RegisterType<IEncryptionService, EncryptionService>();
            Mvx.IoCProvider.RegisterType<IAuthenticationService, AuthenticationService>();

            //StorageService is Registered in the Application itself since its platform specific (UWP, Android, etc.)
            Mvx.IoCProvider.RegisterSingleton<ISettingsService>(
                new SettingsService(
                    Mvx.IoCProvider.Resolve<IStorageService>(),
                    Mvx.IoCProvider.Resolve<IEncryptionService>(),
                    Mvx.IoCProvider.Resolve<IAuthenticationService>())
            );

            RegisterCustomAppStart<AppStart>();
        }
    }
}