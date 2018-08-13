using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using MvvmCross.Platforms.Uap.Presenters;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SigfolioWallet
{
    public class ClearBackStackPresenter : MvxWindowsViewPresenter
    {

        public ClearBackStackPresenter(IMvxWindowsFrame rootFrame)
            : base(rootFrame)
        {
            RootFrame = (Frame) rootFrame.UnderlyingControl;
        }

        public Frame RootFrame { get; }

        public override void ChangePresentation(MvxPresentationHint hint)
        {

            if (RootFrame.BackStack.Any())
                RootFrame.BackStack.Clear();

            base.ChangePresentation(hint);
        }


        protected override void HandleBackButtonVisibility()
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }
    }
}
