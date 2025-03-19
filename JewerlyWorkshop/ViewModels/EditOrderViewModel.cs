using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JewerlyWorkshop.Models;
using System;

namespace JewerlyWorkshop.ViewModels
{
    public partial class EditOrderViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private Order selectedOrder;

        [ObservableProperty]
        private string status;

        [ObservableProperty]
        private string paymentStatus;

        [ObservableProperty]
        private DateTime? orderDate;

        [ObservableProperty]
        private DateTime? completionDate;

        public EditOrderViewModel()
        {
            // Инициализация свойств при создании ViewModel
            if (SelectedOrder != null)
            {
                Status = SelectedOrder.Status;
                PaymentStatus = SelectedOrder.PaymentStatus;
                OrderDate = SelectedOrder.OrderDate;
                CompletionDate = SelectedOrder.CompletionDate;
            }
        }

        [RelayCommand]
        private void SaveOrder()
        {
            if (SelectedOrder != null)
            {
                // Обновление данных заказа
                SelectedOrder.Status = Status;
                SelectedOrder.PaymentStatus = PaymentStatus;
                SelectedOrder.OrderDate = OrderDate;
                SelectedOrder.CompletionDate = CompletionDate;

                // Сохранение изменений в базе данных
                Db.SaveChanges();

                // Возврат на предыдущую страницу
                MainWindowViewModel.Instance.PageSwitcher = new OrderListView();
            }
        }

        [RelayCommand]
        private void GoBack()
        {
            MainWindowViewModel.Instance.PageSwitcher = new OrderListView();
        }
    }
}