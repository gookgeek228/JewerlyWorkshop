using CommunityToolkit.Mvvm.ComponentModel;
using JewerlyWorkshop.Models;

namespace JewerlyWorkshop.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty] JewerlyStoreContext db = new JewerlyStoreContext();
    }
}
