using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrdersPanel.Comparers;
using OrdersPanel.Interfaces;
using OrdersPanel.Models;
using OrdersPanel.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersPanel.ViewModels
{
    using Model = OrdersModel;
    partial class FutureOrdersViewModel : ObservableObject, IOrders
    {
        [ObservableProperty] private ObservableCollection<Order> _orders = new();
        [ObservableProperty] private Order _selectedOrder = new();
        [ICommand]
        private void ExcelExport()
        {
            this.ExportFuture();
        }
        private Thread UpdateOrdersThread => new(async () =>
        {
            for (; ; )
                try
                {
                    var orders = new ObservableCollection<Order>((await Model.OrdersAdapter.GetAsync()).GetValue()!);
                    if (!new OrdersComparer().Equals(orders, _orders))
                        Orders = new ObservableCollection<Order>(orders);
                    await Task.Delay(5000);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
        });
        [ICommand]
        private async void Loaded()
        {
            var orders = new ObservableCollection<Order>((await Model.OrdersAdapter.GetAsync()).GetValue()!);
            UpdateOrdersThread.Start();
        }
    }
}
