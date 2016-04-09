using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
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
    public class PatientListViewModel : BaseViewModel, INavigationAware
    {
        private IPatientRepository _patientRepository;
        private ILog4NetLogger _log4NetLogger;
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;

        public PatientListViewModel(IPatientRepository patientRepository, ILog4NetLogger log4NetLogger, IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _patientRepository = patientRepository;
            _log4NetLogger = log4NetLogger;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            NavigateToPatientEditForm = new DelegateCommand<SearchFormViewModel>(NavigateToPatientEditFormEvent);
            DeletePatientBasicInfo = new DelegateCommand<SearchFormViewModel>(DeletePatientBasicInfoEvent);
            NavigateToPatientDetailsView = new DelegateCommand<SearchFormViewModel>(NavigateToPatientDetailsEvent);

            _eventAggregator.GetEvent<RaisePatientListEvent>().Subscribe(RaisePatientListEvent);

            ConfirmDeleteRequest = new InteractionRequest<IConfirmation>();
            CustomPopupDetailsViewRequest = new InteractionRequest<PatientDetailsNotification>();

            RaisePatientListEvent(true);
        }

        private void NavigateToPatientEditFormEvent(SearchFormViewModel model)
        {
            Debug.WriteLine("-------->:NavigateToPatientEditFormEvent");
            NavigationParameters obj = new NavigationParameters { { "SrchFormVM", model } };
            _regionManager.RequestNavigate(Constant.Constant.Region.MainRegion, Constant.Constant.View.PatientBasicForm, obj);
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
                        bool isPatientDeleted = _patientRepository.DeletePatientForId(Helper.Helper.TryParseToLong(obj.PatientId));
                        RaisePatientListEvent(isPatientDeleted);
                        _eventAggregator.GetEvent<RaiseNextAppointmentEvent>().Publish(isPatientDeleted);
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
                PatientId =  Helper.Helper.TryParseToLong(model.PatientId),
                PatientDetailsSource = _patientRepository.GetPatientDetailsSource(Helper.Helper.TryParseToLong(model.PatientId))

            }, returned =>
            {

            });
        }

        /// <summary>
        /// When coming from other vm to this vm, this would be called in last once all initialization done...
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //_shellViewModel = (ShellViewModel)navigationContext.Parameters["model"];
        }
        /// <summary>
        /// When coming from othr vm to this vm, this would be called asking if we can use same instance to initialse or need different one...
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }


        /// <summary>
        /// When loaded fist time, none of method will be called. ie Only constructure will be called. Once, this vm loaded, and if moving to othr vm from this vm thn
        /// OnNavigatedFrom would tell us where it is navigation...  
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
