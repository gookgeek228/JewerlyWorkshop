using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JewerlyWorkshop.ViewModels;

namespace JewerlyWorkshop;

public partial class AuthView : UserControl
{
    public AuthView()
    {
        DataContext = new AuthViewModel();
        InitializeComponent();
    }
}