using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using PerfectSmile.Common;
using PerfectSmile.Events;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Repository.Implementation;
using PerfectSmile.Service;
using PerfectSmile.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;

namespace PerfectSmile.ViewModels
{
    public class PatientListViewModel : BaseViewModel
    {
        private IPatientRepository _patientRepository;
        private ILog4NetLogger _log4NetLogger;
        private IRegionManager _regionManager;

        public PatientListViewModel(IPatientRepository patientRepository, ILog4NetLogger log4NetLogger, IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _patientRepository = patientRepository;
            _log4NetLogger = log4NetLogger;
            _regionManager = regionManager;

            NavigateToPatientEditForm = new DelegateCommand<SearchFormViewModel>(NavigateToPatientEditFormEvent);
            DeletePatientBasicInfo = new DelegateCommand<SearchFormViewModel>(DeletePatientBasicInfoEvent);
            NavigateToPatientDetailsView = new DelegateCommand<SearchFormViewModel>(NavigateToPatientDetailsEvent);

            eventAggregator.GetEvent<RaisePatientListEvent>().Subscribe(RaisePatientListEvent);

            ConfirmDeleteRequest = new InteractionRequest<IConfirmation>();
            CustomPopupDetailsViewRequest = new InteractionRequest<PatientDetailsNotification>();

            RaisePatientListEvent(true);
        }

        private void NavigateToPatientEditFormEvent(SearchFormViewModel obj)
        {
            Debug.WriteLine("-------->:NavigateToPatientEditFormEvent");
            _regionManager.RequestNavigate(Constant.Constant.Region.MainRegion, Constant.Constant.View.PatientBasicForm, new NavigationParameters(obj.PatientId.ToString()));
        }
        private void DeletePatientBasicInfoEvent(SearchFormViewModel obj)
        {
            Debug.WriteLine("-------->:DeletePatientBasicInfoEvent");
            this.ConfirmDeleteRequest.Raise(
               new Confirmation { Content = "Are you sure you want to delete patient " + obj.Name + " ?", Title = "Confirmation" },
                c =>
                {
                    if (c.Confirmed)
                    {
                        bool isPatientDeleted = _patientRepository.DeletePatientForId(obj.PatientId);
                        RaisePatientListEvent(isPatientDeleted);
                    }
                });

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

        public InteractionRequest<IConfirmation> ConfirmDeleteRequest { get; private set; }

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
