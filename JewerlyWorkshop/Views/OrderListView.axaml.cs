using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JewerlyWorkshop.ViewModels;

namespace JewerlyWorkshop;

public partial class OrderListView : UserControl
{
    public OrderListView()
    {
        DataContext = new OrderListViewModel();
        InitializeComponent();
    }
}