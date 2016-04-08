using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.EF;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.ViewModels;

namespace PerfectSmile.Repository.Implementation
{
    public class SearchByVisitedOnRepository<T> : Repository, ISearch<T>
    {
        public bool IsSearchValid(SearchFormViewModel model, T context)
        {
            return true;
        }
    }
}
