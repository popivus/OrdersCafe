using System;
using System.IO;
using System.Windows.Media.Imaging;
using OrdersPanel.Models.ItemModels;
using OrdersPanel.ViewModels;
using RequestHelper.Adapters;

namespace OrdersPanel.Models
{
    public static class ProductAddModel
    {
        public static ModelAdapter<Product, int> productAdapter = new();

        public static void ImageToByteArray(this ProductAddViewModel productAddViewModel)
        {
            JpegBitmapEncoder encoder = new();
            encoder.Frames.Add(BitmapFrame.Create(productAddViewModel.Image));
            using (var memoryStream = new MemoryStream())
            {
                encoder.Save(memoryStream);
                productAddViewModel.Product.Image = Convert.ToBase64String(memoryStream.ToArray());
            }
        }
    }
}