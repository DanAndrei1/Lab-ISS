using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;

namespace AgentiVanzari.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        public ICommand ViewProductsCommand { get; }
        public ICommand OrderProductCommand { get; }
        public ICommand LogoutCommand { get; }

        public MainViewModel()
        {
            ViewProductsCommand = ReactiveCommand.Create(ViewProducts);
            OrderProductCommand = ReactiveCommand.Create(OrderProduct);
            LogoutCommand = ReactiveCommand.Create(Logout);
        }

        private void ViewProducts()
        {
            var productsWindow = new ProductsWindow();
            productsWindow.Show();
            (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.Close();
        }

        private void OrderProduct()
        {
            var orderProductWindow = new OrderWindow();
            orderProductWindow.Show();
            (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.Close();
        }

        private void Logout()
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.Close();
        }
    }
}