using CommunityToolkit.Mvvm.ComponentModel;

namespace OrdersPanel.Models.ItemModels
{
    public partial class OrderContent : ObservableObject
    {
        [ObservableProperty] private int _id;

        [ObservableProperty] private int _orderId;

        [ObservableProperty] 
        [AlsoNotifyChangeFor(nameof(ProductName))]
        private Product _product = null!;

        [ObservableProperty] private int _productId;

        [ObservableProperty] private int _quantity;

        public string? ProductName => Product.Name;
    }
}