using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

            NavigateToPatientEditForm = new DelegateCommand<dynamic>(NavigateToPatientEditFormEvent);
            DeletePatientBasicInfo = new DelegateCommand<dynamic>(DeletePatientBasicInfoEvent);
            NavigateToPatientDetailsView = new DelegateCommand<dynamic>(NavigateToPatientDetailsEvent);

            RaisePatientListEvent(true);
        }

        private void NavigateToPatientEditFormEvent(dynamic obj)
        {
            Debug.WriteLine("-------->:NavigateToPatientEditFormEvent");
        }
        private void DeletePatientBasicInfoEvent(dynamic obj)
        {
            Debug.WriteLine("-------->:DeletePatientBasicInfoEvent");
        }
        private void NavigateToPatientDetailsEvent(dynamic obj)
        {
            Debug.WriteLine("-------->:NavigateToPatientDetailsEvent");
        }

        public ICommand NavigateToPatientEditForm { get; set; }
        public ICommand DeletePatientBasicInfo { get; set; }
        public ICommand NavigateToPatientDetailsView { get; set; }



        private void RaisePatientListEvent(bool obj = false)
        {
            if (obj)
            {
                PatientItemSource = _patientRepository.GetPatientItemSource();
            }
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
