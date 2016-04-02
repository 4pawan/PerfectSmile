using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using PerfectSmile.Common;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Repository.Implementation;
using PerfectSmile.Service;
using PerfectSmile.Views;
using Prism.Commands;

namespace PerfectSmile.ViewModels
{
    public class PatientListViewModel : BaseViewModel
    {
        private IPatientRepository _patientRepository;
        private ILog4NetLogger _log4NetLogger;


        public PatientListViewModel(IPatientRepository patientRepository, ILog4NetLogger log4NetLogger)
        {
            _patientRepository = patientRepository;
            _log4NetLogger = log4NetLogger;

            PatientItemSource = _patientRepository.GetPatientItemSource();

        }


        private ObservableCollection<SearchFormViewModel> _patientItemSource;
        public ObservableCollection<SearchFormViewModel> PatientItemSource
        {
            get { return _patientItemSource; }
            set
            {
                SetProperty(ref _patientItemSource, value);
            }
        }

    }
}
