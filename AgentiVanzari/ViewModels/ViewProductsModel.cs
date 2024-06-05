using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AgentiVanzari.Domain;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;

namespace AgentiVanzari.ViewModels;

public class ViewProductsModel : ReactiveObject
{
    private Service.Service serv;
    
    private ObservableCollection<Product> _products;
    public ICommand BackCommand { get; }
    public ObservableCollection<Product> Products {
        get => _products; set => this.RaiseAndSetIfChanged(ref _products, value);
    }

    public ViewProductsModel()
    {
        BackCommand = ReactiveCommand.Create(Back);
        Products = new ObservableCollection<Product>();
        var productsFromOrm = GetProductsFromOrm();
        foreach (var product in productsFromOrm)
        {
            Products.Add(product);
        }
    }

    private IEnumerable<Product> GetProductsFromOrm()
    {
        serv = new Service.Service();
        Console.WriteLine("GetProductsFromOrm");
        Product u1 = new Product(1, "a", 1);
        Product u2 = new Product(2, "b", 2);
        Product u3 = new Product(3, "c", 3);
        return new List<Product> { u1, u2, u3 };
        //return serv.GetAllProducts();
    }

    private void Back()
    {
        var mainWindow = new MainWindow();
        mainWindow.Show();
        (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.Close();
    }
}