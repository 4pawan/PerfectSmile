using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using PerfectSmile.Service;

namespace PerfectSmile.ViewModel
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

        public ICommand LoginCommand { get; set; }


        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(() =>
            {
                var isUserValid = LoginService.IsUserValid(Name, Password);
            });


        }
    }
}
