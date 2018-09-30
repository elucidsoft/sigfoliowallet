using System;
using SigfolioWallet.Utilities;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SigfolioWallet.Controls
{

    public sealed partial class Card : UserControl
    {


        public Card()
        {
            InitializeComponent();
            Loaded += Card_Loaded;
        }

        private void Card_Loaded(object sender, RoutedEventArgs e)
        {
            if (Application.Current.RequestedTheme == ApplicationTheme.Dark)
            {
                var appShell = UWPUtilities.FindParent<AppShell>(Parent);
                if (appShell != null)
                {
                    appShell.Background = (Brush)Application.Current.Resources["SystemControlBackgroundListLowBrush"];
                }

                CardGrid.Background = (Brush)Application.Current.Resources["SystemControlBackgroundChromeMediumBrush"];
                CardShadow.ShadowOpacity = 0.3f;
            }
            else
            {
                CardGrid.Background = new SolidColorBrush(Colors.White);
                CardShadow.ShadowOpacity = 0.1f;
            }
        }

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(Card), new PropertyMetadata(null));
        public string Label
        {
            get => this.GetValue<string>(LabelProperty);
            set => this.SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty SubTextProperty = DependencyProperty.Register("SubText", typeof(string), typeof(Card), new PropertyMetadata(null));
        public string SubText
        {
            get => this.GetValue<string>(SubTextProperty);
            set => this.SetValue(SubTextProperty, value);
        }

        public static readonly DependencyProperty PrimaryTextProperty = DependencyProperty.Register("PrimaryText", typeof(string), typeof(Card), new PropertyMetadata(null));
        public string PrimaryText
        {
            get => this.GetValue<string>(PrimaryTextProperty);
            set => this.SetValue(PrimaryTextProperty, value);
        }


    }
}
