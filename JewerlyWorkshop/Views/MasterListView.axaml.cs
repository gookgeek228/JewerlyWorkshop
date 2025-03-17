using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JewerlyWorkshop.ViewModels;

namespace JewerlyWorkshop;

public partial class MasterListView : UserControl
{
    public MasterListView()
    {
        DataContext = new MasterListViewModel();
        InitializeComponent();
    }
}