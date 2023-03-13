using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using OrdersPanel.Interfaces;
using OrdersPanel.Models.ItemModels;
using RequestHelper.Adapters;

namespace OrdersPanel.Models
{
    public static class OrdersModel
    {
        public static ModelAdapter<Order, int> OrderAdapter = new();
        public static ModelsAdapter<Order, int> OrdersAdapter = new();

        public static void Export<T>(this T allOrdersViewModel) where T : IOrders, new()
        {
            var orders = new List<Order>();
            foreach (var order in allOrdersViewModel.Orders)
            {
                foreach (var orderContent in order.OrderContents) orderContent.Product.Image = null;
                orders.Add(order);
            }

            var folderBrowserDialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.MyComputer,
                Description = "Куда сохранить?"
            };
            var res = folderBrowserDialog.ShowDialog();
            if (res is DialogResult.None or DialogResult.Cancel) return;

            using (var file = new FileStream(
                       $@"{folderBrowserDialog.SelectedPath}\{DateTime.Now:dd-MM-yyyy hh_mm_ss}.csv",
                       FileMode.Create))
            {
                using (var streamWriter = new StreamWriter(file, Encoding.UTF8))
                {
                    var a = orders.Select(x => JsonConvert.SerializeObject(x)).ToList();
                    a.ForEach(userLine => streamWriter.Write($"{userLine}{streamWriter.NewLine}"));
                }
            }
        }
        public static void ExportFuture<T>(this T allOrdersViewModel) where T : IOrders, new()
        {
            var orders = new List<Order>();
            foreach (var order in allOrdersViewModel.Orders.Where(order => Math.Floor(order.Date.Subtract(DateTime.Now.Date).TotalDays) > 0))
            {
                foreach (var orderContent in order.OrderContents) orderContent.Product.Image = null;
                orders.Add(order);
            }
            var folderBrowserDialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.MyComputer,
                Description = "Куда сохранить?"
            };
            var res = folderBrowserDialog.ShowDialog();
            if (res is DialogResult.None or DialogResult.Cancel) return;

            using (var file = new FileStream(
                       $@"{folderBrowserDialog.SelectedPath}\{DateTime.Now:dd-MM-yyyy hh_mm_ss}.csv",
                       FileMode.Create))
            {
                using (var streamWriter = new StreamWriter(file, Encoding.UTF8))
                {
                    foreach (var order in orders)
                    {
                        foreach (var orderContent in order.OrderContents)
                        {
                            streamWriter.Write($"{order.Fio} {orderContent.ProductName} {orderContent.Quantity} {streamWriter.NewLine}");
                        }
                    }
                }
            }
        }
    }
}