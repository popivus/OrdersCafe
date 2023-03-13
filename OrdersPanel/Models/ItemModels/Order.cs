using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using RequestHelper.Models;

namespace OrdersPanel.Models.ItemModels
{
    using Model = OrdersModel;

    public partial class Order : ObservableObject, IBaseModel<int>
    {
        [ObservableProperty] 
        [AlsoNotifyChangeFor(nameof(Fio))]
        private Client _client = null!;

        [ObservableProperty] private int _clientId;
        [ObservableProperty] private DateTime _date;
        [ObservableProperty] private int _id;
        [ObservableProperty] private int _employeeID = 2;
        [ObservableProperty] private ObservableCollection<OrderContent> _orderContents = new();

        private Status _status = Status.Создан;
        private int _statusId;
        [ObservableProperty] private decimal _total;

        public int StatusId
        {
            get => _statusId;
            set
            {
                if (_statusId == value) return;
                SetProperty(ref _statusId, value);
                if (_status != (Status) value)
                    Status = (Status) value;
            }
        }

        [JsonIgnore]
        public Status Status
        {
            get => _status;
            set
            {
                if (_status == value) return;
                SetProperty(ref _status, value);
                if (_statusId == (int) value) return;
                StatusId = (int) value;
                Task.Run(async () => await Model.OrderAdapter.SetValue(this).SetAsync());
            }
        }

        [JsonIgnore] public string Fio => $"{Client.Surname} {Client.Name}";

        [JsonIgnore] public string Path { get; set; } = $"{nameof(Order)}s";

        [ICommand]
        private void ChangeStatus(object? obj)
        {
            Status = (Status) int.Parse(obj?.ToString() ?? "1");
        }
    }
}