using System;
using System.Globalization;
using Xamarin.Forms;

namespace gvn_ab_mobile.Converters
{
    public class YesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true.Equals(value) ? "Yes" : "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Yes".Equals(value);
        }
    }
}
