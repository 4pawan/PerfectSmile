using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PerfectSmile.EF;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.ViewModels;
using PerfectSmile.Views.UserControl.AutoCompleteTextBox;

namespace PerfectSmile.Repository.Implementation
{
    public class PatientRepository : Repository, IPatientRepository
    {
        public int AddPatientBasicInfo(PatientBasicFormViewModel vm)
        {
            var model = Helper.Helper.ConvertToPatientModel(vm);
            Context.Patients.Add(model);
            var ad = Context.SaveChanges();
            return ad;
        }

        public Patient GetPatientInfoAutoCompleteTextBox(string searchText)
        {
            return null;
        }

        public ObservableCollection<AutoCompleteEntry> GetAllPatient()
        {
            return new ObservableCollection<AutoCompleteEntry>(Context.Patients.Select(p => new AutoCompleteEntry(p.Name, p.Id.ToString())).ToList());
        }


    }
}
