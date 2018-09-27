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

        public static readonly DependencyProperty PrimaryTextProperty = DependencyProperty.Register("PrimaryText", typeof(string), typeof(Card), new PropertyMetadata(null, PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();

            var oldNumber = Convert.ToInt64(e.OldValue);
            var newNumber = Convert.ToInt64(e.NewValue);

            var segment = Math.Max(10, Math.Abs(Math.Max(newNumber, oldNumber) / 100));
            
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);

            long current = oldNumber;

            if (d is Card tb)
            {
                timer.Start();
                timer.Tick += (sender, o) =>
                {
                    if (current == newNumber)
                    {
                        timer.Stop();
                        tb.PrimaryTextBlock.Text = newNumber.ToString();
                        return;
                    }

                    if (oldNumber > newNumber)
                    {
                        if ((current - segment) < newNumber)
                        {
                            timer.Stop();
                            tb.PrimaryTextBlock.Text = newNumber.ToString();
                            return;
                        }

                        current = current - segment;
                    }

                    else
                    {
                        if ((current + segment) > newNumber)
                        {
                            timer.Stop();
                            tb.PrimaryTextBlock.Text = newNumber.ToString();
                            return;
                        }

                        current = current + segment;
                    }

                    tb.PrimaryTextBlock.Text = current.ToString();
                };
            }
        }

        public string PrimaryText
        {
            get => this.GetValue<string>(PrimaryTextProperty);
            set => this.SetValue(PrimaryTextProperty, value);
        }


    }
}
