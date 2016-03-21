using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
//using PerfectSmile.EF;

namespace PerfectSmile.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            var users = new PerfectSmile.EF.perfectsmileEntities().Users.ToList();
            var aa = users;
        }
    }
}
