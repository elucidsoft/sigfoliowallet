using MvvmCross.Platforms.Uap.Presenters.Attributes;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using SigfolioWallet.Core.ViewModels.Modal;
using SigfolioWallet.Utilities;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SigfolioWallet.Views.Modal
{
    [MvxDialogViewPresentation]
    [MvxViewFor(typeof(PasswordDialogViewModel))]
    public sealed partial class PasswordDialogView : MvxWindowsContentDialog
    {
        public PasswordDialogView()
        {
            this.InitializeComponent();
        }

        public new PasswordDialogViewModel ViewModel => (PasswordDialogViewModel)base.ViewModel;
    }
}
