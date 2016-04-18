using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PerfectSmile.Common
{
    public class DateToMonthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
                return "";

            DateTime dt = DateTime.Parse(value.ToString());
            Debug.WriteLine("---->DateToMonthConverter :" + dt.Month.ToString());
            return dt.Date.Month.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
