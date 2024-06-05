using AgentiVanzari.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AgentiVanzari;

public partial class OrderWindow : Window
{
    public OrderWindow()
    {
            DataContext = new OrderViewModel();
            InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}