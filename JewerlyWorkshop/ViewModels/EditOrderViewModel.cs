using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JewerlyWorkshop.Models;
using System;
using System.Collections.Generic;

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

        [ObservableProperty]
        private List<string> statusOptions;

        [ObservableProperty]
        private List<string> paymentStatusOptions;

        public EditOrderViewModel()
        {
            StatusOptions = new List<string> { "В работе", "Завершен" };
            PaymentStatusOptions = new List<string> { "Оплачен", "Не оплачен" };
        }

        public DateTimeOffset? DateTimeOffset1
        {
            get => orderDate.HasValue ? new DateTimeOffset(orderDate.Value) : (DateTimeOffset?)null;
            set => orderDate = value?.DateTime;
        }

        public DateTimeOffset? DateTimeOffset2
        {
            get => completionDate.HasValue ? new DateTimeOffset(completionDate.Value) : (DateTimeOffset?)null;
            set => completionDate = value?.DateTime;
        }


        [RelayCommand]
        public void SaveOrder()
        {
            if (SelectedOrder != null)
            {
                // Обновление данных заказа
                SelectedOrder.Status = Status;
                SelectedOrder.PaymentStatus = PaymentStatus;
                SelectedOrder.OrderDate = OrderDate;
                SelectedOrder.CompletionDate = CompletionDate;

                if (CompletionDate != null) 
                {
                    SelectedOrder.Status = "Завершен";
                }

                Db.Orders.Update(SelectedOrder);
                Db.SaveChanges();

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