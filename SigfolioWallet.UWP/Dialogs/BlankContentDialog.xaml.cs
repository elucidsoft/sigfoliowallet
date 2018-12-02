using MvvmCross.Platforms.Uap.Views;

namespace SigfolioWallet.Controls
{
    public sealed partial class BlankContentDialog : MvxWindowsContentDialog
    {
        public BlankContentDialog()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            Content = null;
            base.Dispose(disposing);
        }
    }
}
