using SigfolioWallet.Utilities;
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
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SigfolioWallet
{
    public sealed partial class CustomNavView : UserControl
    {
        Ellipse ellName;
        Grid ccNameGrid;
        ContentControl ccName;
        TextBlock txtName;
        FontIcon txtNameChevron;
        TextBlock txtAsset;
        TextBlock txtAmount;

        Thickness txtNameChevronOriginalMargin;
        Visibility txtNameChevronOriginalVisibility;
        HorizontalAlignment ccNameGridOriginalHorizontalAlignment;
        HorizontalAlignment ccNameOriginalHorizontalAlignment;
        Thickness ccNameOriginalMargin;
        double ellNameOriginalWidth;
        double ellNameOriginalHeight;
        double txtNameOriginalFontSize;
        Visibility txtAssetOriginalVisibility;
        Visibility txtAmountOriginalVisibility;

        public CustomNavView()
        {
            this.InitializeComponent();

            NavView.Loaded += NavView_Loaded;
        }

        private void NavView_PaneOpening(NavigationView sender, object args)
        {
            TogglePane(false);
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            ellName = UWPUtilities.FindControlWithName<Ellipse>("ellName", MyNavView);
            ccNameGrid = UWPUtilities.FindControlWithName<Grid>("ccNameGrid", MyNavView);
            ccName = UWPUtilities.FindControlWithName<ContentControl>("ccName", MyNavView);
            txtName = UWPUtilities.FindControlWithName<TextBlock>("txtName", MyNavView);
            txtNameChevron = UWPUtilities.FindControlWithName<FontIcon>("txtNameChevron", MyNavView);
            txtAsset = UWPUtilities.FindControlWithName<TextBlock>("txtAsset", MyNavView);
            txtAmount = UWPUtilities.FindControlWithName<TextBlock>("txtAmount", MyNavView);

            txtNameChevronOriginalMargin = txtNameChevron.Margin;
            txtNameChevronOriginalVisibility = txtNameChevron.Visibility;
            ccNameGridOriginalHorizontalAlignment = ccNameGrid.HorizontalAlignment;
            ccNameOriginalHorizontalAlignment = ccName.HorizontalAlignment;
            ccNameOriginalMargin = ccName.Margin;
            ellNameOriginalWidth = ellName.Width;
            ellNameOriginalHeight = ellName.Height;
            txtNameOriginalFontSize = txtName.FontSize;
            txtAssetOriginalVisibility = txtAsset.Visibility;
            txtAmountOriginalVisibility = txtAmount.Visibility;

            NavView.PaneClosing += NavView_PaneClosing;
            NavView.PaneOpening += NavView_PaneOpening;
        }

        private void NavView_PaneClosing(NavigationView sender, NavigationViewPaneClosingEventArgs args)
        {
            TogglePane(true);
        }

        private void TogglePane(bool closing)
        {
            if (closing)
            {
                txtNameChevron.Margin = new Thickness(0, 18, 0, 0);
                txtNameChevron.Visibility = Visibility.Collapsed;

                ccNameGrid.HorizontalAlignment = HorizontalAlignment.Left;
                ccName.HorizontalAlignment = HorizontalAlignment.Left;
                ccName.Margin = new Thickness(7, 0, 16, 0);

                ellName.Width = 30;
                ellName.Height = 30;

                txtName.FontSize = 10;

                txtAsset.Visibility = Visibility.Collapsed;
                txtAmount.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtNameChevron.Margin = txtNameChevronOriginalMargin;
                txtNameChevron.Visibility = txtNameChevronOriginalVisibility;

                ccNameGrid.HorizontalAlignment = ccNameGridOriginalHorizontalAlignment;
                ccName.HorizontalAlignment = ccNameOriginalHorizontalAlignment;
                ccName.Margin = ccNameOriginalMargin;

                ellName.Width = ellNameOriginalWidth;
                ellName.Height = ellNameOriginalHeight;

                txtName.FontSize = txtNameOriginalFontSize;

                txtAsset.Visibility = txtAssetOriginalVisibility;
                txtAmount.Visibility = txtAmountOriginalVisibility;
            }
        }

        public void SetBalanceText(string amount)
        {
            var txtAmount = UWPUtilities.FindControlWithName<TextBlock>("txtAmount", MyNavView);
            txtAmount.Text = amount;
        }

        public void SetName(string publicKey)
        {
            var txtName = UWPUtilities.FindControlWithName<TextBlock>("txtName", MyNavView);
            txtName.Text = publicKey.Substring(publicKey.Length - 4);
        }

        public Frame AppFrame { get { return PageContent; } }

        public NavigationView NavView { get => MyNavView; }
    }
}
