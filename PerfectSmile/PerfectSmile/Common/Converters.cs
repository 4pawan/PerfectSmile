﻿using System;
using System.Windows;
using System.Windows.Data;

namespace PerfectSmile.Common
{
    public class BoolVisibilityConverter : IValueConverter // same as BooleanToVisibilityConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
