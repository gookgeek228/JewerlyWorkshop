using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using JewerlyWorkshop.Models;

namespace JewerlyWorkshop.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] UserControl pageSwitcher;
        [ObservableProperty] private string previousPage;

        public User? loginedUser;

        public MainWindowViewModel()
        {
            Instance = this;
            PageSwitcher = new AuthView();
            previousPage = pageSwitcher?.GetType().Name;
        }

        public static MainWindowViewModel Instance { get; set; }
    }
}
