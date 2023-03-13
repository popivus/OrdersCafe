using System.Windows;
using System.Windows.Controls;
using OrdersPanel.Interfaces;
using OrdersPanel.ViewModels;

namespace OrdersPanel.Views
{
    public partial class ProductAddView : Window
    {
        public ProductAddView()
        {
            InitializeComponent();
            (DataContext as ProductAddViewModel)!.Close = Close;
        }
    }
}