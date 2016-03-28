using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
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

        private ObservableCollection<AutoCompleteEntry> _autoCompleteSource;
        public ObservableCollection<AutoCompleteEntry> AutoCompleteSource
        {
            get { return _autoCompleteSource; }
            set { SetProperty(ref _autoCompleteSource, value); }
        }


        private string _patient;
        public string Patient
        {
            get { return _patient; }
            set { SetProperty(ref _patient, value); }
        }

        private string _treatmentDone;
        public string TreatmentDone
        {
            get { return _treatmentDone; }
            set { SetProperty(ref _treatmentDone, value); }
        }

        private decimal _paymentDone;
        public decimal PaymentDone
        {
            get { return _paymentDone; }
            set { SetProperty(ref _paymentDone, value); }
        }

        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
            set { SetProperty(ref _balance, value); }
        }

        private string _nextAppointment;
        public string NextAppointment
        {
            get { return _nextAppointment; }
            set { SetProperty(ref _nextAppointment, value); }
        }


        private string _additionalComment;
        public string AdditionalComment
        {
            get { return _additionalComment; }
            set { SetProperty(ref _additionalComment, value); }
        }



        public PatientHistoryFormViewModel(IPatientRepository patientRepository, ILog4NetLogger log4NetLogger)
        {
            _patientRepository = patientRepository;
            _log4NetLogger = log4NetLogger;
            SaveCommand = new DelegateCommand(SaveExec, SaveCanExec);

            AutoCompleteSource = _patientRepository.GetAllPatient();
        }

        private bool SaveCanExec()
        {
            return true;
        }

        private void SaveExec()
        {
            var aa = _patientRepository.AddPatientHistoryDetails(this);
        }
    }
}
