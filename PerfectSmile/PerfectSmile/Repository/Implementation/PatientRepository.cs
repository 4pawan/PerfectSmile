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
            //DateTime? dt = DateTime.Now.Date;
            var list = Context.PatientHistories.OrderByDescending(h => h.Id);
            ObservableCollection<SearchFormViewModel> result = new ObservableCollection<SearchFormViewModel>();

            foreach (var item in list)
            {
                var flag = result.Any(p => p.PatientId == item.PatientId);

                if (!flag)
                {
                    result.Add(new SearchFormViewModel
                    {
                        PatientId = item.Patient.Id,
                        Name = item.Patient.Name,
                        Phone = item.Patient.Phone,
                        Balance = item.Balance,
                        LastVisitedOn = item.CreatedAt,
                        LastAmountPaid = item.PaymentDone,
                        Remark = item.Patient.Remark
                    });
                }

                if (result.Count == 100)
                {
                    break;
                }
            }

            return result;
        }

        public ObservableCollection<PatientHistoryViewModel> GetPatientDetailsSource(long patientId)
        {
            return new ObservableCollection<PatientHistoryViewModel>(Context.PatientHistories.Where(h => h.PatientId == patientId).Select(h => new PatientHistoryViewModel
            {
                PatientId = h.Patient.Id,
                Name = h.Patient.Name,
                Phone = h.Patient.Phone,
                Balance = h.Balance,
                NextAppointment = h.NextAppointment,
                TreatmentDone = h.TreatmentDone,
                AdditionalComment = h.AdditionalComment,
                PaymentDone = h.PaymentDone,
                VisitedOn = h.CreatedAt
            }));
        }

        public bool DeletePatientForId(long patientId)
        {
            try
            {
                using (var contxt = new PatientDbContext())
                {
                    var patientToBeDeleted = contxt.Patients.SingleOrDefault(p => p.Id == patientId);
                    if (patientToBeDeleted != null)
                    {
                        contxt.Patients.Remove(patientToBeDeleted);
                        var id = contxt.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.Helper.WriteLogToEventViewer("Patient deletion error for patient Id :" + patientId + " StackTrace" +
                                                    ex.StackTrace);
                return false;
            }
            return true;
        }

        public ObservableCollection<SearchFormViewModel> SearchByColumeName(SearchFormViewModel searchFormViewModel)
        {
            ObservableCollection<SearchFormViewModel> list;

            using (var contxt = new PatientDbContext())
            {

            }

            return null;
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
