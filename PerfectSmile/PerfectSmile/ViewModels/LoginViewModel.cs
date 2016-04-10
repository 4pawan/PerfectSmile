using System;
using System.Windows;
using System.Windows.Input;
using PerfectSmile.Common;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Repository.Implementation;
using PerfectSmile.Service;
using PerfectSmile.Views;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace PerfectSmile.ViewModels
{
    public class LoginViewModel : BaseViewModel, IInteractionRequestAware
    {
        private readonly ILoginRepository _loginRepository;
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                Message = "";
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
                Message = "";
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
            }
        }

        public ICommand LoginCommand { get; set; }



        private bool CanExecute(Window item)
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Password);
        }

        private void Execute(Window item)
        {
            var isUserValid = true;//_loginRepository.IsUserValid(Name, Password);
            if (!isUserValid)
            {
                Message = Constant.Constant.Login.LoginErrorMesage;
            }
            else
            {
                if (this._notification != null)
                {
                    _notification.IsAuthenticatedUser = true;
                    _notification.Confirmed = true;
                    _notification.UserName = Name;
                    FinishInteraction();
                }

            }
        }

        public LoginViewModel(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
            LoginCommand = new DelegateCommand<Window>(Execute, CanExecute).ObservesProperty(() => Name).ObservesProperty(() => Password);
        }

        private LoginNotification _notification;

        public INotification Notification
        {
            get
            {
                return this._notification;
            }
            set
            {
                if (value is LoginNotification)
                {
                    this._notification = value as LoginNotification;
                    this.OnPropertyChanged(() => this.Notification);
                }
            }
        }
        public Action FinishInteraction { get; set; }
    }

    public class LoginNotification : Confirmation
    {
        public bool IsAuthenticatedUser { get; set; }
        public string UserName { get; set; }
    }


}
