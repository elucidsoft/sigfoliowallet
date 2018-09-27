using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace SigfolioWallet.Utilities
{
    public static class UIUtility
    {

        public static void SetTitleBarColor(ApplicationView currentView, Application application)
        {
            ApplicationViewTitleBar titleBar = currentView.TitleBar;
            titleBar.ButtonBackgroundColor = GetAccentColorLow();
        }

        public static Color GetAccentColorLow()
        {
            var correctionFactor = Application.Current.RequestedTheme == ApplicationTheme.Light ?  0.3f : -0.3f;
            return ChangeColorBrightness((Color) Application.Current.Resources["SystemAccentColor"], correctionFactor);
        }

        public static Color GetAccentColorHigh()
        {
            var correctionFactor = Application.Current.RequestedTheme == ApplicationTheme.Light ? -0.3f : 0.3f;
            return ChangeColorBrightness((Color)Application.Current.Resources["SystemAccentColor"], correctionFactor);
        }

        /// <summary>
        /// Creates color with corrected brightness.
        /// </summary>
        /// <param name="color">Color to correct.</param>
        /// <param name="correctionFactor">The brightness correction factor. Must be between -1 and 1. 
        /// Negative values produce darker colors.</param>
        /// <returns>
        /// Corrected <see cref="Color"/> structure.
        /// </returns>
        public static Color ChangeColorBrightness(Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
