using System;
using System.Globalization;
using System.Windows.Data;

namespace OrdersPanel.Converters
{
    public class IntegerConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value?.ToString() ?? "").Length == 0 ? 0 : value;
        }

        public object? ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value?.ToString() ?? "").Length == 0 ? 0 : value;
        }
    }
}