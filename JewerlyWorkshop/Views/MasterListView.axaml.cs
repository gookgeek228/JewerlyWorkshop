using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace JewerlyWorkshop;

public partial class MasterListView : UserControl
{
    public MasterListView()
    {
        DataContext = new MasterListView();
        InitializeComponent();
    }
}