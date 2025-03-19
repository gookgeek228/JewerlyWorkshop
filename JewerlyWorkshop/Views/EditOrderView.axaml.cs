using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JewerlyWorkshop.ViewModels;

namespace JewerlyWorkshop;

public partial class EditOrderView : UserControl
{
    public EditOrderView()
    {
        DataContext = new EditOrderViewModel();
        InitializeComponent();
    }
}