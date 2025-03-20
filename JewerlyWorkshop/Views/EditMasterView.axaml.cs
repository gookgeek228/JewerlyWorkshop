using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JewerlyWorkshop.ViewModels;

namespace JewerlyWorkshop;

public partial class EditMasterView : UserControl
{
    public EditMasterView()
    {
        DataContext = new EditMasterViewModel();
        InitializeComponent();
    }
}