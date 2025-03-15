using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JewerlyWorkshop.ViewModels;

namespace JewerlyWorkshop;

public partial class MainMenuView : UserControl
{
    public MainMenuView()
    {
        DataContext = new MainMenuViewModel();
        InitializeComponent();
    }
}