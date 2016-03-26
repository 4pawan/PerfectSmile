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

        private ObservableCollection<AutoCompleteEntry> _autoCompleteSource;
        public ObservableCollection<AutoCompleteEntry> AutoCompleteSource
        {
            get { return _autoCompleteSource; }
            set { SetProperty(ref _autoCompleteSource, value); }
        }


        private Patient _patient;
        public Patient Patient
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

        private DateTime _nextAppointment;
        public DateTime NextAppointment
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



        public PatientHistoryFormViewModel()
        {
            AutoCompleteSource = new ObservableCollection<AutoCompleteEntry>
            {
            new AutoCompleteEntry("Toyota Camry1", "Toyota Camry2", "camry3", "car4", "sedan5"),
            new AutoCompleteEntry("Toyota Corolla", "Toyota Corolla", "corolla", "car", "compact"),
            new AutoCompleteEntry("Toyota Tundra", "Toyota Tundra", "tundra", "truck"),
            new AutoCompleteEntry("Chevy Impala", null),  // null matching string will default with just the name
            new AutoCompleteEntry("Chevy Tahoe", "Chevy Tahoe", "tahoe", "truck", "SUV"),
            new AutoCompleteEntry("Chevrolet Malibu", "Chevrolet Malibu", "malibu", "car", "sedan")
            };
        }
    }
}
