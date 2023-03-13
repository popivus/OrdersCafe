using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using OrdersPanel.Models.ItemModels;
using OrdersPanel.Settings;
using OrdersPanel.Views;

namespace OrdersPanel.ViewModels
{
    public partial class TabMenuViewModel : ObservableObject
    {

        [ObservableProperty] 
        [AlsoNotifyChangeFor(nameof(Title))]
        private TabItem? _selectedTabItem;

        [ObservableProperty]
        private ObservableCollection<TabItem> _tabItems = new()
        {
            new TabItem("Все", PackIconKind.ViewListOutline, new AllOrdersView(), "Все заказы"),
            new TabItem("Текущие", PackIconKind.TimerOutline, new NowOrdersView(), "Текущие заказы"),
            new TabItem("Будущие", PackIconKind.AccessTime, new FutureOrdersView(), "Будущие заказы")
        };

        public string Title =>
            $"{AppSettings.Name}{(_selectedTabItem is not null ? " - " : "")}{_selectedTabItem?.PageName ?? ""}";

        [ICommand]
        private void AddProduct()
        {
            var productAddView = new ProductAddView();
            productAddView.ShowDialog();
        }
    }
}