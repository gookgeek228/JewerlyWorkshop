using CommunityToolkit.Mvvm.ComponentModel;
using JewerlyWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWorkshop.ViewModels
{
    public partial class MasterListViewModel : ViewModelBase
    {
        [ObservableProperty] List<Master> masters;
        [ObservableProperty] List<Master> masters0;
        [ObservableProperty] string textFind;
        [ObservableProperty] string selectedSortOrder;
        [ObservableProperty] string selectedSortParametr;

        public MasterListViewModel()
        {
            masters = Db.Masters.ToList();
            masters0 = masters;
        }

        public void ApplyFilters()
        {
            masters = masters0;

            if (!string.IsNullOrEmpty(TextFind))
            {
                Masters = Masters.Where(x => x.Fio.Contains(textFind, StringComparison.OrdinalIgnoreCase)).ToList();
            }

        }

        partial void OnTextFindChanged(string value)
        {
            ApplyFilters();
        }
    }
}
