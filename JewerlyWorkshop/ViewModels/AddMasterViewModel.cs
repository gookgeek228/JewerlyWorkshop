using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JewerlyWorkshop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWorkshop.ViewModels
{
    public partial class AddMasterViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string masterFio;

        [ObservableProperty]
        private string masterPhone;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private DateTime startDate = DateTime.Now;

        [ObservableProperty]
        string message;

        [ObservableProperty]
        private List<Master> masters;

        public AddMasterViewModel()
        {
           masters = Db.Masters.ToList();
        }

        public void GoBack()
        {
            MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
            MainWindowViewModel.Instance.PageSwitcher = new MasterListView();
        }

        public DateTimeOffset DateTimeOffset
        {
            get => new DateTimeOffset(startDate);
            set => startDate = value.DateTime;
        }

        [RelayCommand]
        private void SaveMaster()
        {
            try 
            {
                if (MasterFio == null)
                {
                    Message = "Введите ФИО мастера!";
                    return;
                }

                var newMaster = new Master
                {
                    Fio = MasterFio,
                    Phone = MasterPhone,
                    Description = Description,
                    StartDate = StartDate,
                };

                Db.Masters.Add(newMaster);
                Db.SaveChanges();

                MasterFio = string.Empty;
                MasterPhone = string.Empty;
                Description = string.Empty;

                Message = "Мастер успешно сохранен!";
            }
            catch (DbUpdateException ex)
            {
                // Обработка ошибок базы данных
                Message = $"Ошибка при сохранении мастера: {ex.InnerException?.Message ?? ex.Message}";
            }
        }
    }
}
