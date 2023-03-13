using OrdersPanel.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OrdersPanel.Converters
{
    [ValueConversion(typeof(ObservableCollection<Order>), typeof(ObservableCollection<Order>))]
    public class FutureOrdersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new ObservableCollection<Order>(
                (value as ObservableCollection<Order>)?.Where(order => Math.Floor(order.Date.Subtract(DateTime.Now.Date).TotalDays) > 0 ) ?? default!);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
