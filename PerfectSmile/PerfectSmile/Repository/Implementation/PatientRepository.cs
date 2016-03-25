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
        public int AddPatientBasicInfo(PatientBasicFormViewModel vm)
        {
            var model = Mapper.Map<PatientBasicFormViewModel, Patient>(vm);
            Context.Patients.Add(model);
            var ad = Context.SaveChanges();
            return 1;
        }
    }
}
