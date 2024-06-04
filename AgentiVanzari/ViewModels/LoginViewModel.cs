using System.Windows.Input;
using ReactiveUI;
using AgentiVanzari.Repository;
using Avalonia.Controls;
using Avalonia.Threading;
using System.Reactive;
using System;
using System.Threading.Tasks;

namespace AgentiVanzari
{
    public class LoginViewModel : ReactiveObject
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private readonly RepositoryUsers _repositoryUsers;
        private readonly Window _window;

        public ICommand LoginCommand { get; }

        // public string Username
        // {
        //     get => _username;
        //     set => this.RaiseAndSetIfChanged(ref _username, value);
        // }
        //
        // public string Password
        // {
        //     get => _password;
        //     set => this.RaiseAndSetIfChanged(ref _password, value);
        // }
        //
        // public string ErrorMessage
        // {
        //     get => _errorMessage;
        //     set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
        // }

        public LoginViewModel(Window window)
        {
            //_window = window;
            //_repositoryUsers = new RepositoryUsers();
            LoginCommand = ReactiveCommand.Create(() => { } );
        }

        private void LoginAsync()
        {
            // var user = await _repositoryUsers.GetByUserNameAndPassword(Username, Password);
            // if (user != null)
            // {
            //     await Dispatcher.UIThread.InvokeAsync(() =>
            //     {
            //         var mainWindow = new MainWindow();
            //         mainWindow.Show();
            //         _window.Close();
            //     });
            // }
            // else
            // {
            //     await Dispatcher.UIThread.InvokeAsync(() =>
            //     {
            //         ErrorMessage = "Invalid username or password.";
            //     });
            // }
        }
    }
}