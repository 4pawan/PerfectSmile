using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.EF;
using PerfectSmile.Repository.Abstract;

namespace PerfectSmile.Repository.Implementation
{
    public class LoginRepository : IRepository
    {
        private static perfectsmileEntities _context = new perfectsmileEntities();

        static perfectsmileEntities Context
        {
            get { return _context ?? (_context = new perfectsmileEntities()); }
        }


        perfectsmileEntities IRepository.Context { get; set; }
    }
}
