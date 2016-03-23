using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.EF;
using PerfectSmile.Repository.Abstract;

namespace PerfectSmile.Repository.Implementation
{
    public class LoginRepository : Repository, ILoginRepository
    {
        public bool IsUserValid(string name, string password)
        {
            var user = Context.Users.Where(u => u.Name == name && u.Password == password).ToList();
            return user.Count == 1;
        }
    }
}
