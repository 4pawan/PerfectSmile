using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.EF;

namespace PerfectSmile.Service
{
    public class LoginService
    {
        public static bool IsUserValid(string name, string password)
        {
            perfectsmileEntities context = new perfectsmileEntities();
            var user = context.Users.Where(u => u.Name == name && u.Password == password).ToList();

            return user.Count == 1;

        }
    }
}
