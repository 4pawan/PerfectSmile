using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public long AddPatientBasicInfo(PatientBasicFormViewModel vm)
        {
            try
            {
                using (var contxt = new PatientDbContext())
                {
                    var model = Helper.Helper.ConvertToPatientModel(vm);
                    contxt.Patients.Add(model);
                    contxt.SaveChanges();
                    return model.Id;
                }
            }
            catch (Exception ex)
            {
                Helper.Helper.WriteLogToEventViewer(ex.StackTrace);
                return 0;
            }
        }

        public Patient GetPatientInfoAutoCompleteTextBox(string searchText)
        {
            return null;
        }

        public ObservableCollection<AutoCompleteEntry> GetAllPatient()
        {
            ObservableCollection<AutoCompleteEntry> lst = new ObservableCollection<AutoCompleteEntry>();

            var patient = Context.Patients.ToList();

            foreach (var p in patient)
            {
                lst.Add(new AutoCompleteEntry($"{p.Name}, {p.Phone}, {p.Id}", p.Id.ToString(), p.Name, p.Phone, p.Id.ToString()));
            }
            return lst;
        }


        public ObservableCollection<NextAppointmentItemViewModel> GetNextAppointmentSource()
        {

            DateTime? dt = DateTime.Now.Date;
            return new ObservableCollection<NextAppointmentItemViewModel>(Context.PatientHistories.Where(h => h.NextAppointment.HasValue && h.NextAppointment.Value >= dt).Select(h => new NextAppointmentItemViewModel
            {
                PatientId = h.Patient.Id,
                Name = h.Patient.Name,
                Phone = h.Patient.Phone,
                Balance = h.Balance,
                NextAppointment = h.NextAppointment
            }));
        }

        public ObservableCollection<SearchFormViewModel> GetPatientItemSource()
        {
            DateTime? dt = DateTime.Now.Date;
            return new ObservableCollection<SearchFormViewModel>(Context.PatientHistories.Where(h => h.NextAppointment.HasValue && h.NextAppointment.Value <= dt).OrderByDescending(h => h.CreatedAt).Take(100).Select(h => new SearchFormViewModel
            {
                PatientId = h.Patient.Id,
                Name = h.Patient.Name,
                Phone = h.Patient.Phone,
                Balance = h.Balance,
                LastVisitedOn = h.NextAppointment,
                LastAmountPaid = h.PaymentDone
            }));
        }

        public long AddPatientHistoryDetails(PatientHistoryFormViewModel vm)
        {
            try
            {
                var model = Helper.Helper.ConvertToPatientHistoryModel(vm);

                using (var contxt = new PatientDbContext())
                {
                    contxt.PatientHistories.Add(model);
                    contxt.SaveChanges();
                    return model.Id;
                }

            }
            catch (Exception ex)
            {
                Helper.Helper.WriteLogToEventViewer(ex.StackTrace);
                return 0;
            }
        }


    }
}
