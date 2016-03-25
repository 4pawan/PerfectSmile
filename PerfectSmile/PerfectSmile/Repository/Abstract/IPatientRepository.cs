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
    public interface IPatientRepository : IRepository
    {
        int AddPatientBasicInfo(PatientBasicFormViewModel model) ;
    }
}