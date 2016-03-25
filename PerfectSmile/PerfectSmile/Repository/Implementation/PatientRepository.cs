using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PerfectSmile.EF;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.ViewModels;

namespace PerfectSmile.Repository.Implementation
{
    public class PatientRepository : Repository, IPatientRepository
    {
        public int AddPatientBasicInfo(PatientBasicFormViewModel model)
        {


            var modezl  = Mapper.Map<PatientBasicFormViewModel, Patient>(model);


            return 1;
        }
    }
}
