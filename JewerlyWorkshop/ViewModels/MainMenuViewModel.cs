using CommunityToolkit.Mvvm.ComponentModel;
using JewerlyWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWorkshop.ViewModels
{
    public partial class MainMenuViewModel : ViewModelBase
    {
        [ObservableProperty] private string username;
        [ObservableProperty] private User user = MainWindowViewModel.Instance.loginedUser;
        [ObservableProperty] private string message;

        public MainMenuViewModel()
        {
            if (User != null && !string.IsNullOrWhiteSpace(User.Username))
            {
                username = User.Username;
            }
        }



        public void GoToMasters()
        {
            if (User.IdRole == 1)
            {
                MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
                MainWindowViewModel.Instance.PageSwitcher = new MasterListView();
            }
            else
            {
                Message = "Нет доступа. Обратитесь к администратору";
                return;
            }
            
        }

        public void GoToOrders()
        {
            MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
            MainWindowViewModel.Instance.PageSwitcher = new OrderListView();
        }

        public void LogOut()
        {
            MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
            MainWindowViewModel.Instance.PageSwitcher = new AuthView();
        }
    }
}
