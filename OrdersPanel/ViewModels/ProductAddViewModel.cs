using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrdersPanel.Interfaces;
using OrdersPanel.Models;
using OrdersPanel.Models.ItemModels;
using OrdersPanel.Settings;
using RequestHelper.Adapters;
namespace OrdersPanel.ViewModels
{
    using Model = ProductAddModel;
    public partial class ProductAddViewModel : ObservableObject
    {
        [ObservableProperty] private BitmapImage _image = new();

        [ObservableProperty] private Product _product = new();
        
        public ProductAddViewModel() => Model.productAdapter = new ModelAdapter<Product, int>(ref _product!);

        public Action? Close { get; set; }

        [ICommand]
        private void AddImage()
        {
            OpenFileDialog fileDialog = new()
            {
                InitialDirectory = @"c:\",
                Filter = AppSettings.OpenDialogFilter,
                RestoreDirectory = true
            };
            if (fileDialog.ShowDialog() != DialogResult.OK) return;
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(fileDialog.FileName);
            bitmapImage.EndInit();
            Image = bitmapImage;
            this.ImageToByteArray();
        }

        [ICommand]
        private async void AddProduct()
        {
            await Model.productAdapter.AddAsync();
            Close?.Invoke();
        }
    }
}