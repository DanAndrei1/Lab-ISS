using Avalonia;
using System;
using System.Linq;
using AgentiVanzari.Repository;
using AgentiVanzari.Service;

namespace AgentiVanzari;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        Service.Service service = new Service.Service();
        RepositoryProducts repositoryProducts = new RepositoryProducts();
        Console.WriteLine(service.Login("admin", "admin"));
        Console.WriteLine(service.Login("admin", "admin1"));
        Console.WriteLine(service.GetAllProducts().Count);
        Console.WriteLine(repositoryProducts.GetById(1).Result.Name);
        Console.WriteLine(repositoryProducts.GetByName("Amorsa").Result.Stock);
        service.OrderProduct("Amorsa", 500);
        service.OrderProduct("Amorsa", 50);
        service.UpdateProduct(4, "Amorsa", 250);
        Console.WriteLine(repositoryProducts.GetByName("Amorsa").Result.Stock);
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}