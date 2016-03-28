using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.EF;

namespace PerfectSmile.Repository.Factory
{
    public class ContextFactory
    {
        private static PatientDbContext _context;
        public static PatientDbContext Context
        {
            get { return _context ?? (_context = new PatientDbContext()); }
        }

    }
}
