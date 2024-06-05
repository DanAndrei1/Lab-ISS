using System.Threading.Tasks;
using System.Windows.Input;
using AgentiVanzari.Repository;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using ReactiveUI;

namespace AgentiVanzari.ViewModels
{
    public class LoginViewModel : ReactiveObject
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private readonly RepositoryUsers _repositoryUsers;

        public ICommand LoginCommand { get; }

        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }
        
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }
        
        public string ErrorMessage
        {
            get => _errorMessage;
            set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
        }

        public LoginViewModel()
        {
            _repositoryUsers = new RepositoryUsers();
            LoginCommand = ReactiveCommand.Create(LoginAsync);
        }

        private async Task LoginAsync()
        {
            var user = await _repositoryUsers.GetByUserNameAndPassword(Username, Password);
            if (user != null)
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.Close();
                });
            }
            else
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    ErrorMessage = "Invalid username or password.";
                });
            }
        }
    }
}