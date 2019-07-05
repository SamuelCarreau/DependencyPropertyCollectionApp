using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace DependencyPropertyCollectionApp.Converter
{
    public class TestConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Debugger.Break();
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Debugger.Break();
            return value;
        }
    }
}