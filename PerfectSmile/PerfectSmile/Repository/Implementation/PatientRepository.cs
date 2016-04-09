using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
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
                    model.CreatedAt = DateTime.Now;
                    model.CreatedBy = Helper.Helper.LoggedInUser;

                    contxt.Patients.Add(model);
                    contxt.SaveChanges();
                    return model.Id;
                }
            }
            catch (System.Exception ex)
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
            ObservableCollection<SearchFormViewModel> result = new ObservableCollection<SearchFormViewModel>();

            using (var contxt = new PatientDbContext())
            {
                var list = contxt.PatientHistories.OrderByDescending(h => h.Id);

                foreach (var item in list)
                {
                    var flag = result.Any(p => Helper.Helper.TryParseToLong(p.PatientId) == item.PatientId);

                    if (!flag)
                    {
                        result.Add(new SearchFormViewModel
                        {
                            PatientId = item.Patient.Id.ToString(),
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
            catch (System.Exception ex)
            {
                Helper.Helper.WriteLogToEventViewer("Patient deletion error for patient Id :" + patientId + " StackTrace" +
                                                    ex.StackTrace);
                return false;
            }
            return true;
        }

        public long UpdatePatientBasicInfo(PatientBasicFormViewModel vm)
        {
            try
            {
                var model = Helper.Helper.ConvertToPatientModel(vm);

                using (var contxt = new PatientDbContext())
                {
                    var obj = contxt.Patients.SingleOrDefault(p => p.Id == model.Id);
                    if (obj == null) throw new ArgumentNullException(nameof(obj), "Id :" + model.Id + " could not found in Patient table while updating");
                    model.CreatedBy = obj.CreatedBy;
                    model.CreatedAt = obj.CreatedAt;

                    contxt.Entry(obj).CurrentValues.SetValues(model);
                    contxt.SaveChanges();
                    return model.Id;
                }

            }
            catch (System.Exception ex)
            {
                Helper.Helper.WriteLogToEventViewer("Message :" + ex.Message + " StackTrace :" + ex.StackTrace);
                return 0;
            }
        }

        public ObservableCollection<SearchFormViewModel> SearchByColumeName(SearchFormViewModel vm)
        {
            using (var contxt = new PatientDbContext())
            {
                var list = contxt.Patients.Where(p =>
                        (vm.PatientId == null || vm.PatientId == p.Id.ToString()) &&
                        (string.IsNullOrEmpty(vm.Name) || p.Name.ToLower().Contains(vm.Name.ToLower())) &&
                        (string.IsNullOrEmpty(vm.Phone) || p.Phone.ToLower().Contains(vm.Phone.ToLower()))).SelectMany(p => p.PatientHistories).ToList();

                var result = new ObservableCollection<SearchFormViewModel>(list.Where(h =>
                           string.IsNullOrEmpty(vm.VisitedOn) ||
                            (h.CreatedAt.HasValue && h.CreatedAt.Value.ToShortDateString() == vm.VisitedOn)).Select(h => new SearchFormViewModel
                            {
                                PatientId = h.Patient.Id.ToString(),
                                Name = h.Patient.Name,
                                Phone = h.Patient.Phone,
                                Balance = h.Balance,
                                LastVisitedOn = h.CreatedAt,
                                LastAmountPaid = h.PaymentDone,
                                Remark = h.Patient.Remark
                            }));
                return result;
            }
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
            catch (System.Exception ex)
            {
                Helper.Helper.WriteLogToEventViewer(ex.StackTrace);
                return 0;
            }
        }


    }
}
