using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JewerlyWorkshop.ViewModels;

namespace JewerlyWorkshop;

public partial class AddOrderView : UserControl
{
    public AddOrderView()
    {
        DataContext = new AddOrderViewModel();
        InitializeComponent();
    }
}