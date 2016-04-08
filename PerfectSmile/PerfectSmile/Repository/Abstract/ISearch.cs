using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.EF;
using PerfectSmile.ViewModels;

namespace PerfectSmile.Repository.Abstract
{
    public interface ISearch<T> : IRepository
    {
        bool IsSearchValid(SearchFormViewModel vm,T model);
    }
}