using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;
using PerfectSmile.Attributes;
using PerfectSmile.Common;
using PerfectSmile.EF;
using PerfectSmile.Events;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Repository.Implementation;
using PerfectSmile.Service;
using PerfectSmile.Views;
using PerfectSmile.Views.UserControl.AutoCompleteTextBox;
using Prism.Commands;
using Prism.Events;

namespace PerfectSmile.ViewModels
{
    public class PatientHistoryFormViewModel : BaseViewModel
    {
        private IPatientRepository _patientRepository;
        private ILog4NetLogger _log4NetLogger;
        private IEventAggregator _eventAggregator;

        public ICommand SaveCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        private ObservableCollection<AutoCompleteEntry> _autoCompleteSource;
        public ObservableCollection<AutoCompleteEntry> AutoCompleteSource
        {
            get { return _autoCompleteSource; }
            set { SetProperty(ref _autoCompleteSource, value); }
        }


        private string _patientId;
        [Required(ErrorMessage = "Patient Id cant be empty.")]
        [RemotePatientId(ErrorMessage = "Patient Id does not exist.")]
        public string PatientId
        {
            get { return _patientId; }
            set
            {
                ValidateProperty(value);
                SetProperty(ref _patientId, value);
                Message = "";
            }
        }

        private string _treatmentDone;
        //[Required(ErrorMessage = "Please enter Treatment done")]
        public string TreatmentDone
        {
            get { return _treatmentDone; }
            set
            {
                ValidateProperty(value);
                SetProperty(ref _treatmentDone, value);
                Message = "";
            }
        }

        private string _paymentDone;
        [RegularExpression("\\d*\\.?\\d*", ErrorMessage = @"Please enter valid value")]
        [Required(ErrorMessage = @"Please enter Payment")]
        public string PaymentDone
        {
            get { return _paymentDone; }
            set
            {
                ValidateProperty(value);
                SetProperty(ref _paymentDone, value);
                Message = "";
            }
        }

        private string _balance;
        [RegularExpression("\\d*\\.?\\d*", ErrorMessage = @"Please enter valid value")]
        [Required(ErrorMessage = @"Please enter Balance")]
        public string Balance
        {
            get { return _balance; }
            set
            {
                ValidateProperty(value);
                SetProperty(ref _balance, value);
                Message = "";
            }
        }

        private string _nextAppointment;
        [DisablePastDate(ErrorMessage = @"Next Appointment cant be past dates")]
        public string NextAppointment
        {
            get { return _nextAppointment; }
            set
            {
                ValidateProperty(value);
                SetProperty(ref _nextAppointment, value);
                Message = "";
            }
        }


        private string _additionalComment;
        public string AdditionalComment
        {
            get { return _additionalComment; }
            set
            {
                ValidateProperty(value);
                SetProperty(ref _additionalComment, value);
                Message = "";
            }
        }


        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }


        private DateTime _displayDateStart;
        public DateTime DisplayDateStart
        {
            get { return _displayDateStart; }
            set { SetProperty(ref _displayDateStart, value); }
        }




        public PatientHistoryFormViewModel(IPatientRepository patientRepository, ILog4NetLogger log4NetLogger, IEventAggregator eventAggregator)
        {
            DisplayDateStart = DateTime.Now;
            _patientRepository = patientRepository;
            _log4NetLogger = log4NetLogger;
            _eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand(SaveExec, SaveCanExec);
            ClearCommand = new DelegateCommand(ClearExec);

            _eventAggregator.GetEvent<RaiseAutoCompleteEvent>().Subscribe(RaiseAutoCompleteEvent);

            RaiseAutoCompleteEvent(true);
        }

        private void RaiseAutoCompleteEvent(bool obj = false)
        {
            if (obj)
            {
                AutoCompleteSource = _patientRepository.GetAllPatient();
            }
        }

        private void ClearExec()
        {
            AdditionalComment = "";
            Balance = "";
            PaymentDone = "";
            PatientId = "";
            TreatmentDone = "";
            NextAppointment = "";
            Message = "";
        }

        private bool SaveCanExec()
        {
            return true;
        }

        private void SaveExec()
        {
            ValidateAllProperty(new MessageArgs { { "PatientId", PatientId },
                { "PaymentDone", PaymentDone } ,{ "Balance",  Balance },
                { "TreatmentDone", TreatmentDone }, { "NextAppointment", NextAppointment } });

            if (IsValid)
            {
                long id = _patientRepository.AddPatientHistoryDetails(this);
                _log4NetLogger.Info("Patient history with id" + id + "saved in db successfully.");
                if (id > 0)
                {
                    Message = string.Format("Patient's history saved successfully with Id : {0} !", id);
                    _eventAggregator.GetEvent<RaisePatientListEvent>().Publish(true);
                    if (!string.IsNullOrEmpty(NextAppointment))
                        _eventAggregator.GetEvent<RaiseNextAppointmentEvent>().Publish(true);
                }
                else
                {
                    Message = "There could be issue while saving.Please check logs !";
                }
            }
            else
            {
                Message = "Please enter valid information and try again !";
            }
        }
    }


}
