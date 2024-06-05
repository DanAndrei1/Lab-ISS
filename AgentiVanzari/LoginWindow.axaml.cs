using AgentiVanzari.ViewModels;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AgentiVanzari
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            DataContext = new LoginViewModel();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}