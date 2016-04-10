using System.Collections.ObjectModel;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.ViewModels;
using PerfectSmile.Views;
using PerfectSmile.Views.UserControl.AutoCompleteTextBox;

namespace PerfectSmile.Repository.Fakes
{
    public class PatientRepositoryFake : Implementation.Repository, IPatientRepository
    {
        public long AddPatientBasicInfo(PatientBasicFormViewModel vm)
        {
            var model = Helper.Helper.ConvertToPatientModel(vm);
            TestPatientList.PatientList.Add(model);
            return 1;
        }

        public ObservableCollection<AutoCompleteEntry> GetAllPatient()
        {
            return new ObservableCollection<AutoCompleteEntry> {
            new AutoCompleteEntry("Toyota Camry1", "Toyota Camry2", "camry3", "car4", "sedan5"),
            new AutoCompleteEntry("Toyota Corolla", "Toyota Corolla", "corolla", "car", "compact"),
            new AutoCompleteEntry("Toyota Tundra", "Toyota Tundra", "tundra", "truck"),
            new AutoCompleteEntry("Chevy Impala", null),  // null matching string will default with just the name
            new AutoCompleteEntry("Chevy Tahoe", "Chevy Tahoe", "tahoe", "truck", "SUV"),
            new AutoCompleteEntry("Chevrolet Malibu", "Chevrolet Malibu", "malibu", "car", "sedan")
            };
        }

        public long AddPatientHistoryDetails(PatientHistoryFormViewModel patientHistoryFormViewModel)
        {
            throw new System.NotImplementedException();
        }

        public ObservableCollection<NextAppointmentItemViewModel> GetNextAppointmentSource()
        {
            throw new System.NotImplementedException();
        }

        public ObservableCollection<SearchFormViewModel> GetPatientItemSource()
        {
            throw new System.NotImplementedException();
        }

        public ObservableCollection<PatientHistoryViewModel> GetPatientDetailsSource(long patientId)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePatientForId(long patientId)
        {
            throw new System.NotImplementedException();
        }

        public long UpdatePatientBasicInfo(PatientBasicFormViewModel patientBasicFormViewModel)
        {
            throw new System.NotImplementedException();
        }

        public ObservableCollection<SearchFormViewModel> SearchByColumeName(SearchFormViewModel searchFormViewModel)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePatientHistoryForId(long patientId)
        {
            throw new System.NotImplementedException();
        }
    }
}
