using System.Collections.ObjectModel;
using OrdersPanel.Models.ItemModels;

namespace OrdersPanel.Interfaces
{
    public interface IOrders
    {
        public ObservableCollection<Order> Orders { get; set; }
    }
}