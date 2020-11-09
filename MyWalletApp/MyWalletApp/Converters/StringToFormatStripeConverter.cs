using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MyWalletApp.Converters
{
    public class StringToFormatStripeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var credit = RefactirNumberCredit($"{value}");
            return $"{credit.Substring(0, 4)}-{credit.Substring(4, 4)}-{credit.Substring(8, 4)}-{credit.Substring(12, 4)}";
        }
        string RefactirNumberCredit(string creditCard)
        {
            string a = string.Empty;
            int j = 0;
            for (int i = 0; i < 16; i++)
            {
                if (j != creditCard.Length)
                {
                    for (j = 0; j < creditCard.Length; j++)
                    {

                        a += $"{creditCard[j]}";

                    }
                }

                if (creditCard.Length != 16)
                    a += "0";
            }

            return a;

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
