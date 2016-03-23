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
        private static perfectsmileEntities _context;
        public static perfectsmileEntities Context
        {
            get { return _context ?? (_context = new perfectsmileEntities()); }
        }

    }
}
