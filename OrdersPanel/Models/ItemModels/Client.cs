using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace OrdersPanel.Models.ItemModels
{
    public partial class Client : ObservableValidator
    {
        public Client() => ValidateAllProperties();
        
        [ObservableProperty]
        [Required]
        [EmailAddress(ErrorMessage = "Некорректный формат")]
        private string? _email;

        [ObservableProperty]
        [Required]
        private int _id;

        [ObservableProperty]
        [Required]
        private string? _name;

        [ObservableProperty]
        [Required]
        private string? _surname;
    }
}