using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectSmile.Authentication
{
    public class AnonymousIdentity : CustomIdentity
    {
      
        public AnonymousIdentity(string name, string email, string[] roles) : base(name, email, roles)
        {
        }
    }
}
