using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PerfectSmile.Common
{
    public class AddEditDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (long)value == 0 ? "Add mode" : "Edit mode";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
