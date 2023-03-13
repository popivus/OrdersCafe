using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OrdersPanel.Models.ItemModels;

namespace OrdersPanel.Comparers
{
    public class OrdersComparer : IEqualityComparer<ObservableCollection<Order>>
    {
        public bool Equals(ObservableCollection<Order>? x, ObservableCollection<Order>? y)
        {
            if (x == null && y is null) return true;
            if (x is null || y is null) return false;
            if (x.Count != y.Count) return false;

            foreach (var order in x.Zip(y, (order1, order2) => new {order1, order2}))
            {
                if (order.order1.Id != order.order2.Id)
                    return false;
                if (order.order1.ClientId != order.order2.ClientId)
                    return false;
                if (order.order1.StatusId != order.order2.StatusId)
                    return false;
                if ($"{order.order1.Date:MM/dd/yyyy}" != $"{order.order2.Date:MM/dd/yyyy}")
                    return false;
                if (order.order1.Total != order.order2.Total)
                    return false;
                if (order.order1.Client.Id != order.order2.Client.Id)
                    return false;
                if (order.order1.Client.Name != order.order2.Client.Name)
                    return false;
                if (order.order1.Client.Surname != order.order2.Client.Surname)
                    return false;
                if (order.order1.Client.Email != order.order2.Client.Email)
                    return false;

                foreach (var orderContent in order.order1.OrderContents.Zip(order.order2.OrderContents,
                             (orderContent1, orderContent2) => new {orderContent1, orderContent2}))
                {
                    if (orderContent.orderContent1.Id != orderContent.orderContent2.Id)
                        return false;
                    if (orderContent.orderContent1.ProductId != orderContent.orderContent2.ProductId)
                        return false;
                    if (orderContent.orderContent1.Quantity != orderContent.orderContent2.Quantity)
                        return false;
                    if (orderContent.orderContent1.ProductName != orderContent.orderContent2.ProductName)
                        return false;
                    if (orderContent.orderContent1.Product.Id != orderContent.orderContent2.Product.Id)
                        return false;
                    if (orderContent.orderContent1.Product.Name != orderContent.orderContent2.Product.Name)
                        return false;
                    if (orderContent.orderContent1.Product.Price != orderContent.orderContent2.Product.Price)
                        return false;
                    if (orderContent.orderContent1.Product.QuantityAvailable !=
                        orderContent.orderContent2.Product.QuantityAvailable)
                        return false;
                    if (orderContent.orderContent1.Product.Image != orderContent.orderContent2.Product.Image)
                        return false;
                }
            }

            return true;
        }

        public int GetHashCode(ObservableCollection<Order> obj)
        {
            return obj.GetHashCode();
        }
    }
}