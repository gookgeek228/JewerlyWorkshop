using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JewerlyWorkshop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace JewerlyWorkshop.ViewModels
{
    public partial class AddOrderViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string serviceName;

        [ObservableProperty]
        private DateTime orderDate = DateTime.Now;

        [ObservableProperty]
        private string status;

        [ObservableProperty]
        private int? cost;

        [ObservableProperty]
        private Material selectedMaterial;

        [ObservableProperty]
        private Service selectedService;

        [ObservableProperty]
        private Master selectedMaster;

        [ObservableProperty]
        private Client selectedClient;

        [ObservableProperty]
        private Jevel selectedJevel;

        [ObservableProperty]
        private string clientFio;

        [ObservableProperty]
        private string phone;

        [ObservableProperty]
        private string jevelName;

        [ObservableProperty]
        private string jevelType;

        [ObservableProperty]
        private int? weight;

        [ObservableProperty]
        private List<JevelType> jevelTypes;

        [ObservableProperty]
        private List<Material> materials;

        [ObservableProperty]
        private List<Master> masters;

        [ObservableProperty]
        private List<Client> clients;

        [ObservableProperty]
        private List<Jevel> jevels;

        [ObservableProperty]
        private List<Service> services;

        [ObservableProperty]
        string message;

        public AddOrderViewModel()
        {
            LoadData();
        }

        public void GoBack()
        {
            MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
            MainWindowViewModel.Instance.PageSwitcher = new OrderListView();
        }

        public DateTimeOffset DateTimeOffset
        {
            get => new DateTimeOffset(orderDate);
            set => orderDate = value.DateTime;
        }

        private void LoadData()
        {
            materials = Db.Materials.ToList();
            jevelTypes = Db.JevelTypes.ToList();
            services = Db.Services.ToList();
            masters = Db.Masters.ToList();
            clients = Db.Clients.ToList();
            jevels = Db.Jevels
                .Include(x => x.IdMaterialNavigation)
                .Include(x => x.JevelTypeNavigation)
                .ToList();
        }

        [RelayCommand]
        private void SaveOrder()
        {
            try
            {
                var newOrder = new Order
                {
                    ServiceName = SelectedService?.ServiceName,
                    OrderDate = OrderDate,
                    Status = "В работе",
                    Cost = Cost,
                    IdMaster = SelectedMaster?.IdMaster ?? 0, // Извлекаем Id мастера
                    IdClient = SelectedClient?.IdClient ?? 0, // Извлекаем Id клиента
                    IdJevel = SelectedJevel?.IdJevel ?? 0 // Извлекаем Id изделия
                };

                Db.Orders.Add(newOrder);
                Db.SaveChanges();

                // Очистка полей после сохранения
                ServiceName = string.Empty;
                Status = string.Empty;
                Cost = null;
                SelectedMaster = null;
                SelectedClient = null;
                SelectedJevel = null;
                SelectedService = null;

                Message = "Заказ успешно сохранен!";
                LoadData();
            }
            catch (DbUpdateException ex)
            {
                // Обработка ошибок базы данных
                Message = $"Ошибка при сохранении заказа: {ex.InnerException?.Message ?? ex.Message}";
            }

        }

        [RelayCommand]
        private void SaveJevel()
        {
            try
            {
                var newJevel = new Jevel
                {
                    JevelName = JevelName,
                    JevelType = JevelType,
                    IdMaterial = SelectedMaterial?.IdMaterial ?? 0,
                    Weight = Weight,
                };

                JevelName = string.Empty;
                JevelType = string.Empty;
                SelectedMaterial = null;
                Weight = null;

                Message = "Изделие успешно сохранено!";
                LoadData();
            }
            catch (DbUpdateException ex)
            {
                // Обработка ошибок базы данных
                Message = $"Ошибка при сохранении изделия: {ex.InnerException?.Message ?? ex.Message}";
            }
        }

        [RelayCommand]
        private void SaveClient()
        {
            try 
            {
                var newClient = new Client
                {
                    Fio = ClientFio,
                    Phone = Phone,
                };

                Db.Clients.Add(newClient);
                Db.SaveChanges();

                ClientFio = string.Empty;
                Phone = string.Empty;

                Message = "Клиент успешно сохранен!";
                LoadData();
            }
            catch (DbUpdateException ex)
            {
                // Обработка ошибок базы данных
                Message = $"Ошибка при сохранении клиента: {ex.InnerException?.Message ?? ex.Message}";
            }
        }
    }
}