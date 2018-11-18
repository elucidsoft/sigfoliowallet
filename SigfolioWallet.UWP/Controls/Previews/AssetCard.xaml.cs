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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace SigfolioWallet.Controls
{
    public sealed partial class AssetCard : UserControl
    {
        public AssetCard()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty AmountProperty = DependencyProperty.Register("Amount", typeof(string), typeof(AssetCard), new PropertyMetadata(null));
        public string Amount
        {
            get => (string)this.GetValue(AmountProperty);
            set => this.SetValue(AmountProperty, value);
        }


        public static readonly DependencyProperty AssetCodeProperty = DependencyProperty.Register("AssetCode", typeof(string), typeof(AssetCard), new PropertyMetadata(null));
        public string AssetCode
        {
            get => (string)this.GetValue(AssetCodeProperty);
            set => this.SetValue(AssetCodeProperty, value);
        }

        public static readonly DependencyProperty BgColorProperty = DependencyProperty.Register("BgColor", typeof(string), typeof(AssetCard), new PropertyMetadata(null));
        public string BgColor
        {
            get => (string)this.GetValue(BgColorProperty);
            set => this.SetValue(BgColorProperty, value);
        }

        public static readonly DependencyProperty DomainProperty = DependencyProperty.Register("Domain", typeof(string), typeof(AssetCard), new PropertyMetadata(null));
        public string Domain
        {
            get => (string)this.GetValue(DomainProperty);
            set => this.SetValue(DomainProperty, value);
        }

        public static readonly DependencyProperty IssuerAddressProperty = DependencyProperty.Register("IssuerAddress", typeof(string), typeof(AssetCard), new PropertyMetadata(null));
        public string IssuerAddress
        {
            get => (string)this.GetValue(IssuerAddressProperty);
            set => this.SetValue(IssuerAddressProperty, value);
        }
    }
}
