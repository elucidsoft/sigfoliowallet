using SigfolioWallet.Utilities;
using System;
using System.Collections.ObjectModel;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Color = Windows.UI.Color;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SigfolioWallet.Controls
{

    public sealed partial class CardBarChart : UserControl
    {
        public CardBarChart()
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

            data = new ObservableCollection<Data>();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            Random rnd = new Random();
            timer.Tick += (o, o1) =>
            {
                Add(rnd.Next(1, 200), rnd.Next(1, 200), rnd.Next(2, 200));
            };

            timer.Start();

            for (int i = 0; i <= 30; i++)
            {
                data.Add(new Data()
                {
                    BarCategory = DateTime.Now,
                    BarValue1 = 1,
                    BarValue2 = 1
                });
            }

            chart.DataContext = data;

            var colorLow = UIUtility.GetAccentColorLow();
            var color = UIUtility.GetAccentColor();
            sbLineBrush.Color = color;

            var color1 = colorLow;
            color1.A = 94;

            var color2 = colorLow;
            color2.A = 0;

            gs1Color.Color = color1;
            gs2Color.Color = color2;

            sbColor1.Color = color;
            sbColor2.Color = colorLow;

        }

        //public static readonly DependencyProperty BarsBrushProperty = DependencyProperty.Register("BarsBrush", typeof(SolidColorBrush), typeof(CardBarChart), new PropertyMetadata(null));
        //public SolidColorBrush BarsBrush { get => new SolidColorBrush(Colors.Yellow); }

        //public double? LowValue { get; set; }

        //public double HighValue { get; set; }

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(CardBarChart), new PropertyMetadata(null));
        public string Label
        {
            get => this.GetValue<string>(LabelProperty);
            set => this.SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(CardBarChart), new PropertyMetadata(null));
        public Color Color
        {
            get => this.GetValue<Color>(ColorProperty);
            set => this.SetValue(ColorProperty, value);
        }

        public ObservableCollection<Data> data { get; set; }

        private void Add(double value1, double value2, double lineValue)
        {
            if (data.Count >= 30)
                data.RemoveAt(0);

            data.Add(new Data()
            {
                BarCategory = DateTime.Now,
                BarValue1 = value1,
                BarValue2 = value2,
                LineValue = lineValue
            });
        }

        public class Data
        {
            public string LineCategory { get; set; }

            public DateTime BarCategory { get; set; }

            public double LineValue { get; set; }

            public double BarValue1 { get; set; }


            public double BarValue2 { get; set; }
        }
    }


}
