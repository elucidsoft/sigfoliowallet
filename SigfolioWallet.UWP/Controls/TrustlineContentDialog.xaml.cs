using MvvmCross.Base;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SigfolioWallet.Controls
{
    public sealed partial class TrustlineContentDialog : MvxWindowsContentDialog
    {
        public TrustlineContentDialog()
        {
            this.InitializeComponent();
        }
    }
}
