using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.EF;
using PerfectSmile.Repository.Abstract;

namespace PerfectSmile.Service
{
    public class LoginService
    {
        private  ILoginRepository loginRepository;

        public LoginService(ILoginRepository _loginRepository)
        {
            loginRepository = _loginRepository;
        }

        public  bool IsUserValid(string name, string password)
        {
            return loginRepository.IsUserValid(name, password);
        }
    }
}
