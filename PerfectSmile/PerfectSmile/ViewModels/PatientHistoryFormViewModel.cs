using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;
using PerfectSmile.Attributes;
using PerfectSmile.Common;
using PerfectSmile.EF;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Repository.Implementation;
using PerfectSmile.Service;
using PerfectSmile.Views;
using PerfectSmile.Views.UserControl.AutoCompleteTextBox;
using Prism.Commands;

namespace PerfectSmile.ViewModels
{
    public class PatientHistoryFormViewModel : BaseViewModel
    {
        private IPatientRepository _patientRepository;
        private ILog4NetLogger _log4NetLogger;
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

        private decimal _paymentDone;
        public decimal PaymentDone
        {
            get { return _paymentDone; }
            set
            {
                ValidateProperty(value);
                SetProperty(ref _paymentDone, value);
                Message = "";
            }
        }

        private decimal _balance;
        public decimal Balance
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
        [DisablePastDate(ErrorMessage ="Next Appointment cant be past dates")]
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




        public PatientHistoryFormViewModel(IPatientRepository patientRepository, ILog4NetLogger log4NetLogger)
        {
            DisplayDateStart = DateTime.Now;
            _patientRepository = patientRepository;
            _log4NetLogger = log4NetLogger;
            SaveCommand = new DelegateCommand(SaveExec, SaveCanExec);
            ClearCommand = new DelegateCommand(ClearExec);
            AutoCompleteSource = _patientRepository.GetAllPatient();
        }

        private void ClearExec()
        {
            AdditionalComment = "";
            Balance = 0;
            PaymentDone = 0;
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
            ValidateAllProperty(new MessageArgs { { "PatientId", PatientId }, { "TreatmentDone", TreatmentDone }, { "NextAppointment", NextAppointment } });

            if (IsValid)
            {
                long id = _patientRepository.AddPatientHistoryDetails(this);
                _log4NetLogger.Info("Patient history with id" + id + "saved in db successfully.");
                Message = id > 0 ? "Patient's history saved successfully with new Id : " + id + " !" : "There could be issue while saving.Please check logs !";
            }
            else
            {
                Message = "Please enter valid information and try again !";
            }
        }
    }
}
