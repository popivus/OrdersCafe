using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using RequestHelper.Models;

namespace OrdersPanel.Models.ItemModels
{
    public partial class Product : ObservableValidator, IBaseModel<int>
    {
        public Product() => ValidateAllProperties();

        [ObservableProperty] 
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Некорректное значение")]
        private int _id;

        [ObservableProperty] 
        [Required] 
        private string? _image;

        [ObservableProperty] 
        [Required(ErrorMessage = "Поле не должно быть пустым")] 
        [MinLength(2, ErrorMessage = "Длина < 2")]
        [RegularExpression(@"^[А-ЯA-Z]{1}[а-яa-z]{1,}$", ErrorMessage = "Неправильный формат")]
        private string? _name;

        [ObservableProperty] 
        [Required] 
        [Range(1, int.MaxValue, ErrorMessage = "Цена < {1}.")]
        private int _price;

        [ObservableProperty] 
        [Required] 
        [Range(1, int.MaxValue, ErrorMessage = "Цена < {1}.")]
        private int _quantityAvailable;

        [JsonIgnore] public string Path { get; set; } = $"{nameof(Product)}s";
    }
}