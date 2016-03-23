using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.EF;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Repository.Factory;

namespace PerfectSmile.Repository.Implementation
{
    public class Repository : IRepository
    { 
        public perfectsmileEntities Context { get { return ContextFactory.Context; } }
    }
}
