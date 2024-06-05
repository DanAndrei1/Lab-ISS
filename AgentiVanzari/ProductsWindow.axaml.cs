using AgentiVanzari.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AgentiVanzari;

public partial class ProductsWindow : Window
{
    public ProductsWindow()
    {
        DataContext = new ViewProductsModel();
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}