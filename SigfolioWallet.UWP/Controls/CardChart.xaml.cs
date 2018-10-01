using SigfolioWallet.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Color = Windows.UI.Color;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SigfolioWallet.Controls
{

    public sealed partial class CardChart : UserControl
    {
        public CardChart()
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
                Add(rnd.Next(2, 100));
            };

            timer.Start();

            for (int i = 0; i <= 60; i++)
            {
                data.Add(new Data() { Value = 0 });
            }
            lineSeries.DataContext = data;

            sasSeries.Stroke = new SolidColorBrush(Color);

            var color1 = Color;
            color1.A = 94;

            var color2 = Color;
            color2.A = 0;

            gs1Color.Color = color1;
            gs2Color.Color = color2;
            
            data.CollectionChanged += Data_CollectionChanged;
        }

        private void Data_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var firstValue = data[0].Value.ToString(CultureInfo.InvariantCulture);

                var newValue = data[e.NewStartingIndex - 1].Value;

                LowValue = data.Min(a => a.Value);
                HighValue = data.Max(a => a.Value);

                if(LowValue != ((Data)e.NewItems[0]).Value)
                    LowTextBlock.Text = $"{LowValue}/{newValue}";

                if(HighValue != ((Data)e.NewItems[0]).Value)
                    HighTextBlock.Text = $"{firstValue}/{HighValue}";
                
            }
        }

        public double? LowValue { get; set; }

        public double HighValue { get; set; }

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(CardChart), new PropertyMetadata(null));
        public string Label
        {
            get => this.GetValue<string>(LabelProperty);
            set => this.SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(CardChart), new PropertyMetadata(null));
        public Color Color
        {
            get => this.GetValue<Color>(ColorProperty);
            set => this.SetValue(ColorProperty, value);
        }

        public ObservableCollection<Data> data { get; set; }

        private void Add(double value)
        {
            if (data.Count >= 60)
                data.RemoveAt(0);

            data.Add(new Data() { Value = value });
        }
    }

    public class Data
    {
        public double Value { get; set; }
    }
}
