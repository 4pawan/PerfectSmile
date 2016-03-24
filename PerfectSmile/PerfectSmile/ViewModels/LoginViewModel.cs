using System.Windows;
using System.Windows.Input;
using PerfectSmile.Common;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Repository.Implementation;
using PerfectSmile.Service;
using PerfectSmile.Views;
using Prism.Commands;

namespace PerfectSmile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ILoginRepository _loginRepository;
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ICommand LoginCommand { get; set; }



        private bool CanExecute(Window item)
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Password);
        }

        private void Execute(Window item)
        {
            var isUserValid = _loginRepository.IsUserValid(Name, Password);
            if (!isUserValid)
            {
                Message = Constant.Constant.Login.LoginErrorMesage;
            }
            else
            {
                var shell = new Shell();
                item.Close();
                shell.Show();
            }
        }

        public LoginViewModel(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
            LoginCommand = new DelegateCommand<Window>(Execute, CanExecute).ObservesProperty(() => Name).ObservesProperty(() => Password);
        }
    }
}
