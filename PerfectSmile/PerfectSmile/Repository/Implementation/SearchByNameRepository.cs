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
    public class SearchByNameRepository  
    {
        public bool IsSearchValid(SearchFormViewModel vm, Patient model)
        {
            return true;
        }
    }
}
