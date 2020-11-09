using MyWalletApp.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MyWalletApp.Converters
{
    public class NumberToNameCardConverter : BaseCardValidation, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var creditCard = $"{value}";

            if (visaRegex.IsMatch(creditCard))
                return "Visa";
            if (masterRegex.IsMatch(creditCard))
                return "Mastercard";
            if (dinnersRegex.IsMatch(creditCard))
                return "Diners Club International";
            if (discoverRegex.IsMatch(creditCard))
                return "Discover";
            if (jcbRegex.IsMatch(creditCard))
                return "JCB";
            if (amexRegex.IsMatch(creditCard))
                return "American Express";
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
