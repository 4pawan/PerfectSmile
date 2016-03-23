using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.EF;

namespace PerfectSmile.Repository.Abstract
{
    public interface IRepository
    {
        perfectsmileEntities Context { get; }
    }
}