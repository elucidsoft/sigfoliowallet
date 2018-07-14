using MvvmCross.ViewModels;
using SigfolioWallet.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SigfolioWallet.Core.ViewModels
{
    public class WalletViewModel : MvxViewModel
    {
        IWalletService _walletService;
        private string _walletName;

        public string WalletName
        {
            get => _walletName;
            set => _walletName = value;
        }

        public WalletViewModel(IWalletService walletService) => _walletService = walletService;

        public override async Task Initialize()
        {
            await base.Initialize();
        }

        
    }
}