using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using OrdersPanel.Models.ItemModels;

namespace OrdersPanel.Converters
{
    [ValueConversion(typeof(ObservableCollection<Order>), typeof(ObservableCollection<Order>))]
    public class PresentOrdersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new ObservableCollection<Order>(
                (value as ObservableCollection<Order>)?.Where(order =>
                    $"{order.Date:MM/dd/yyyy}" == $"{DateTime.Now:MM/dd/yyyy}") ?? default!);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}