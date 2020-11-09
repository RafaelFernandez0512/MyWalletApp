using MyWalletApp.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MyWalletApp.Converters
{
    public class NumberToImageTypeCardConverter : BaseCardValidation,IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var creditCard = $"{value}";

            if (visaRegex.IsMatch(creditCard))
                return "";
            if (masterRegex.IsMatch(creditCard))
                return "";
            if (dinnersRegex.IsMatch(creditCard))
                return "";
            if (discoverRegex.IsMatch(creditCard))
                return "";
            if (jcbRegex.IsMatch(creditCard))
                return "";
            if (amexRegex.IsMatch(creditCard))
                return "";
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
