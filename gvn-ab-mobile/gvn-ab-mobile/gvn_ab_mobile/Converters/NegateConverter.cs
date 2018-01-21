using System;
using System.Globalization;
using Xamarin.Forms;

namespace gvn_ab_mobile.Converters
{
    public class NegateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !true.Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !true.Equals(value);
        }
    }
}
