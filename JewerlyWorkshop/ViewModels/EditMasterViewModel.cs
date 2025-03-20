using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JewerlyWorkshop.Models;

namespace JewerlyWorkshop.ViewModels
{
	public partial class EditMasterViewModel : ViewModelBase
	{
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string fio;

        [ObservableProperty]
        private string phone;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private DateTime? startDate;

        [ObservableProperty]
        private DateTime? dissmissialDate;

        [ObservableProperty]
        private Master selectedMaster;

        [RelayCommand]
        public void SaveOrder()
        {
            if (SelectedMaster != null)
            {
                SelectedMaster.Fio = Fio;
                SelectedMaster.Phone = Phone;
                SelectedMaster.Description = Description;
                SelectedMaster.StartDate = StartDate;
                SelectedMaster.DismissialDate = DissmissialDate;

                Db.Masters.Update(SelectedMaster);
                Db.SaveChanges();

                MainWindowViewModel.Instance.PageSwitcher = new MasterListView();
            }
        }

        public DateTimeOffset? DateTimeOffset1
        {
            get => startDate.HasValue ? new DateTimeOffset(startDate.Value) : (DateTimeOffset?)null;
            set => startDate = value?.DateTime;
        }

        public DateTimeOffset? DateTimeOffset2
        {
            get => dissmissialDate.HasValue ? new DateTimeOffset(dissmissialDate.Value) : (DateTimeOffset?)null;
            set => dissmissialDate = value?.DateTime;
        }

        [RelayCommand]
        private void GoBack()
        {
            MainWindowViewModel.Instance.PageSwitcher = new MasterListView();
        }
    }
}