using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace SigfolioWallet.Utilities
{
    public static class UWPUtilities
    {
        public static T FindControlWithName<T>(String controlName, DependencyObject rootControl) where T : DependencyObject
        {
            IEnumerable<T> controls = FindVisualChildren<T>(rootControl);

            foreach (var control in controls)
                Debug.WriteLine(control.GetValue(FrameworkElement.NameProperty).ToString());

            foreach (var control in controls)
            {
                if(control.GetValue(FrameworkElement.NameProperty).ToString() == controlName)
                {
                    return control;
                }
            }

            return null;
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
