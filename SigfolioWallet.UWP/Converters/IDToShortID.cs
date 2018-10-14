using SigfolioWallet.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace SigfolioWallet.Converters
{
    public class IDToShortID : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //Get Parameters -> StartLength|EndLength|Separator
            int charactersStart = 5;
            int charactersEnd = 4;
            string separator = "...";

            string parameterString = parameter as string;
            if (!string.IsNullOrEmpty(parameterString))
            {
                string[] parameters = parameterString.Split(new char[] { '|' }, StringSplitOptions.None);
                charactersStart = int.Parse(parameters[0]);
                charactersEnd = int.Parse(parameters[1]);
                separator = parameters[2].ToString();
            }

            string id = (string)value;
            string shortedID = StellarSDKExtensions.ShortAddress(id, charactersStart, charactersEnd, separator);
            if(id.Length == 56)
            {
                return shortedID;
            }
            else
            {
                return id;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
