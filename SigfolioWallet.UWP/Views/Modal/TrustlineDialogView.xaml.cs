using MvvmCross.Platforms.Uap.Presenters.Attributes;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.ViewModels.Modal;
using Windows.UI.Xaml.Controls;

namespace SigfolioWallet.Views.Modal
{
    [MvxDialogViewPresentation]
    [MvxViewFor(typeof(TrustlineDialogViewModel))]
    public sealed partial class TrustlineDialogView : MvxWindowsContentDialog
    {
        public TrustlineDialogView()
        {
            this.InitializeComponent();
        }

        public TrustlineDialogViewModel ViewModel => (TrustlineDialogViewModel)base.ViewModel;
    }
}
