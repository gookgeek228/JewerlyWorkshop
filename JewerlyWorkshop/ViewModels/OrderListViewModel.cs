using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewerlyWorkshop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using JewerlyWorkshop.ViewModels;

namespace JewerlyWorkshop.ViewModels
{
    public partial class OrderListViewModel : ViewModelBase
    {
        [ObservableProperty] List<Order> orders;
        [ObservableProperty] List<Order> orders0;
        [ObservableProperty] string textFind;
        [ObservableProperty] string selectedSortOrder;
        [ObservableProperty] string selectedSortParametr;

        public OrderListViewModel()
        {
            orders = Db.Orders
                .Include(o => o.IdMasterNavigation)
                .Include(o => o.IdClientNavigation)
                .Include(o => o.IdJevelNavigation)
                .ToList();
            orders0 = orders;
        }

        public void GoBack()
        {
            MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
            MainWindowViewModel.Instance.PageSwitcher = new MainMenuView();
        }

        public void AddOrder()
        {
            MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
            MainWindowViewModel.Instance.PageSwitcher = new AddOrderView();
        }

        public void ApplyFilters()
        {
            orders = orders0;

            //Поисковая строка
            if (!string.IsNullOrEmpty(textFind))
            {
                Orders = Orders.Where(x => x.ServiceName.Contains(textFind, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            //Сортировка по дате
            if (selectedSortOrder == "Старые")
            {
                Orders = Orders.OrderBy(x => x.OrderDate).ToList();
            }
            else if (selectedSortOrder == "Новые")
            {
                Orders = Orders.OrderByDescending(x => x.OrderDate).ToList();
            }

            //Сортировка по статусу
            if (selectedSortParametr == "В работе")
            {
                Orders = Orders.Where(x => x.Status == "В работе").ToList();
            }
            else if (selectedSortParametr == "Завершен")
            {
                Orders = Orders.Where(x => x.Status == "Завершен").ToList();
            }

        }

        partial void OnTextFindChanged(string value)
        {
            ApplyFilters();
        }

        partial void OnSelectedSortOrderChanged(string value)
        {
            ApplyFilters();
        }

        partial void OnSelectedSortParametrChanged(string value)
        {
            ApplyFilters();
        }
    }
}
