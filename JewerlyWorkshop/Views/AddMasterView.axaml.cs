using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JewerlyWorkshop.ViewModels;

namespace JewerlyWorkshop;

public partial class AddMasterView : UserControl
{
    public AddMasterView()
    {
        DataContext = new AddOrderViewModel();
        InitializeComponent();
    }
}