using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using PerfectSmile.Common;
using PerfectSmile.Events;
using PerfectSmile.Helper;
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


        private long  _patientId;
        public long PatientId
        {
            get { return _patientId; }
            set { SetProperty(ref _patientId, value); }
        }


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
                    long id = PatientId > 0 ? _patientRepository.UpdatePatientBasicInfo(this) : _patientRepository.AddPatientBasicInfo(this);
                    _log4NetLogger.Info(string.Format("Patient with name {0} and Id {1}saved in db successfully.", Name, id));
                    if (id > 0)
                    {
                        Message = string.Format("Patient record with name : {0} saved successfully with Id : {1} !", Name, id);
                        _eventAggregator.GetEvent<RaiseAutoCompleteEvent>().Publish(true);
                        _eventAggregator.GetEvent<RaisePatientListEvent>().Publish(true);
                        _eventAggregator.GetEvent<RaiseNextAppointmentEvent>().Publish(true);
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
        }


        private void ClearExec()
        {
            Remark = Phone = Name = Message = "";
            PatientId = 0;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters["SrchFormVM"] != null)
            {
                var model = (SearchFormViewModel)navigationContext.Parameters["SrchFormVM"];

                Name = model.Name;
                Phone = model.Phone;
                Remark = model.Remark;
                PatientId = Helper.Helper.TryParseToLong(model.PatientId) ;

                var shellContext = StorageManager.Get<ShellViewModel>(Constant.Constant.DictionaryKey.ShellContext);
                shellContext.IsNextAppintmentSelected = false;
                shellContext.IsPatientListSelected = false;
                shellContext.IsPatientBasicFormSelected = true;
                shellContext.IsPatientHistoryFormSelected = false;
                shellContext.IsPatientFormGroupTabSelected = true;
            }
            else
            {
                ClearExec();
            }
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
