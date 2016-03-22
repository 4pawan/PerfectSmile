﻿using System.Windows;
using System.Windows.Input;
using PerfectSmile.Service;
using PerfectSmile.Views;
using Prism.Commands;

namespace PerfectSmile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
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


        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand<Window>((item) =>
            {
                var isUserValid = LoginService.IsUserValid(Name, Password);
                if (!isUserValid)
                {
                    Message = Constant.Constant.LoginView.LoginErrorMesage ;
                }
                else
                {
                    var shell = new Shell();
                    item.Close();
                    shell.Show();
                }
            });
        }
    }
}