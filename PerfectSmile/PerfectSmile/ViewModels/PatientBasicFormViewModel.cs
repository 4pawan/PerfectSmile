using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using Prism.Regions;

namespace PerfectSmile.ViewModels
{
    public class PatientBasicFormViewModel : BaseViewModel, INavigationAware
    {

        private IPatientRepository _patientRepository;
        private ILog4NetLogger _log4NetLogger;
        private IEventAggregator _eventAggregator;

        private ShellViewModel _shellViewModel;

        private string _name;

        [StringLength(250, ErrorMessage = "Name cant be more than 250 char")]
        [Required(ErrorMessage = "Please enter name")]
        public string Name
        {
            get { return _name; }
            set
            {
                ValidateProperty(value);
                SetProperty(ref _name, value);
                Message = "";
            }
        }

        private string _phone;

        [RegularExpression("((\\(\\d{3}\\)?)|(\\d{3}))([\\s-./]?)(\\d{3})([\\s-./]?)(\\d{4})", ErrorMessage = "Phone no is not valid")]
        public string Phone
        {
            get { return _phone; }
            set
            {
                ValidateProperty(value);
                SetProperty(ref _phone, value);
                Message = "";
            }
        }


        private string _remark;
        [StringLength(4000, ErrorMessage = "Remark cant be more than 4000 char")]
        public string Remark
        {
            get { return _remark; }
            set
            {
                ValidateProperty(value);
                SetProperty(ref _remark, value);
                Message = "";
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }


        public ICommand SaveCommand { get; set; }
        public ICommand ClearCommand { get; set; }


        public PatientBasicFormViewModel(IPatientRepository patientRepository, ILog4NetLogger log4NetLogger, IEventAggregator eventAggregator)
        {
            _patientRepository = patientRepository;
            _log4NetLogger = log4NetLogger;
            _eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand(() =>
            {
                ValidateAllProperty(new MessageArgs { { "Name", Name }, { "Phone", Phone }, { "Remark", Remark } });
                if (IsValid)
                {
                    long id = _patientRepository.AddPatientBasicInfo(this);
                    _log4NetLogger.Info(string.Format("Patient with name {0} and Id {1}saved in db successfully.", Name, id));
                    if (id > 0)
                    {
                        Message = string.Format("Patient record with name : {0} saved successfully with new Id : {1} !", Name, id);
                        _eventAggregator.GetEvent<RaiseAutoCompleteEvent>().Publish(true);
                    }
                    else
                    {
                        Message = "There could be issue while saving...Please check logs";
                    }
                }
                else
                {
                    Message = "Please enter valid information and try again !";
                }
            });

            ClearCommand = new DelegateCommand(ClearExec);
            _eventAggregator.GetEvent<RaiseShellContextEvent>().Subscribe(RaiseShellContextEvent);
        }

        private void RaiseShellContextEvent(ShellViewModel obj)
        {
            _shellViewModel = obj;
        }

        private void ClearExec()
        {
            Remark = Phone = Name = Message = "";
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters["PatientId"] != null)
            {
                var patientId = (long)navigationContext.Parameters["PatientId"];
                Name = "--->" + patientId;
            }

            //_shellViewModel.IsPatientBasicFormSelected = true;

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
