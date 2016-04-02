using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using PerfectSmile.Common;
using PerfectSmile.Events;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Repository.Implementation;
using PerfectSmile.Service;
using PerfectSmile.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;

namespace PerfectSmile.ViewModels
{
    public class PatientListViewModel : BaseViewModel
    {
        private IPatientRepository _patientRepository;
        private ILog4NetLogger _log4NetLogger;


        public PatientListViewModel(IPatientRepository patientRepository, ILog4NetLogger log4NetLogger, IEventAggregator eventAggregator)
        {
            _patientRepository = patientRepository;
            _log4NetLogger = log4NetLogger;

            NavigateToPatientEditForm = new DelegateCommand<SearchFormViewModel>(NavigateToPatientEditFormEvent);
            DeletePatientBasicInfo = new DelegateCommand<SearchFormViewModel>(DeletePatientBasicInfoEvent);
            NavigateToPatientDetailsView = new DelegateCommand<SearchFormViewModel>(NavigateToPatientDetailsEvent);

            eventAggregator.GetEvent<RaisePatientListEvent>().Subscribe(RaisePatientListEvent);

            CustomPopupDetailsViewRequest = new InteractionRequest<PatientDetailsNotification>();

            RaisePatientListEvent(true);
        }

        private void NavigateToPatientEditFormEvent(SearchFormViewModel obj)
        {
            Debug.WriteLine("-------->:NavigateToPatientEditFormEvent");
        }
        private void DeletePatientBasicInfoEvent(SearchFormViewModel obj)
        {
            Debug.WriteLine("-------->:DeletePatientBasicInfoEvent");
        }
        private void NavigateToPatientDetailsEvent(SearchFormViewModel obj)
        {
            Debug.WriteLine("-------->:NavigateToPatientDetailsEvent");
            RaiseCustomPopupDetailsView(obj);
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

        public InteractionRequest<PatientDetailsNotification> CustomPopupDetailsViewRequest { get; private set; }

        private void RaiseCustomPopupDetailsView(SearchFormViewModel model)
        {
            CustomPopupDetailsViewRequest.Raise(new PatientDetailsNotification
            {
                Title = "Patient Id : " + model.PatientId + " Name : " + model.Name + " : Details View",
                PatientId = model.PatientId,
                PatientDetailsSource = _patientRepository.GetPatientDetailsSource(model.PatientId)

            }, returned =>
            {

            });
        }




    }
}
