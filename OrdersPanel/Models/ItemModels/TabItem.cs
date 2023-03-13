using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using MaterialDesignThemes.Wpf;

namespace OrdersPanel.Models.ItemModels
{
    /// <summary>
    ///     Класс модели для работы с <see cref="System.Windows.Controls.TabItem" />
    /// </summary>
    public partial class TabItem : ObservableObject
    {

        [ObservableProperty] private Page _content;

        [ObservableProperty] private string _header;

        [ObservableProperty] private string _pageName;

        [ObservableProperty] private PackIconKind _tabIconKind;

        public TabItem()
        {
            _pageName = "Имя страницы не задано.";
            _header = "Заголовок не задан задан.";
            _tabIconKind = PackIconKind.None;
            _content = new Page
            {
                VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
                Title = "Заголовок не задан.",
                Content = new TextBlock
                {
                    VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center,
                    Text = "Контент не задан."
                }
            };
        }
        public TabItem(string header, PackIconKind tabIconKind, Page content, string pageName)
        {
            _header = header;
            _content = content;
            _tabIconKind = tabIconKind;
            _pageName = pageName;
        }
    }
}