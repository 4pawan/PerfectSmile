using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.Repository.Abstract;
using Prism.Interactivity.InteractionRequest;

namespace PerfectSmile.ViewModels
{
    public class PatientDetailsViewModel : BaseViewModel, IInteractionRequestAware
    {
        private PatientDetailsNotification _notification;
        public INotification Notification
        {
            get
            {
                return this._notification;
            }
            set
            {
                if (value is PatientDetailsNotification)
                {
                    this._notification = (PatientDetailsNotification)value;
                    this.OnPropertyChanged(() => this.Notification);
                }
            }
        }
        public Action FinishInteraction { get; set; }

    }


    public class PatientHistoryViewModel : BaseViewModel
    {
        private long _patientId;
        public long PatientId
        {
            get { return _patientId; }
            set
            {
                SetProperty(ref _patientId, value);
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                SetProperty(ref _phone, value);
            }
        }

        private DateTime? _nextAppointment;
        public DateTime? NextAppointment
        {
            get { return _nextAppointment; }
            set
            {
                SetProperty(ref _nextAppointment, value);
            }
        }

        private DateTime? _visitedOn;
        public DateTime? VisitedOn
        {
            get { return _visitedOn; }
            set
            {
                SetProperty(ref _visitedOn, value);
            }
        }

        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                SetProperty(ref _balance, value);
            }
        }

        private decimal _paymentDone;
        public decimal PaymentDone
        {
            get { return _paymentDone; }
            set
            {
                SetProperty(ref _paymentDone, value);
            }
        }

        private string _treatmentDone;
        public string TreatmentDone
        {
            get { return _treatmentDone; }
            set
            {
                SetProperty(ref _treatmentDone, value);
            }
        }

        private string _additionalComment;
        public string AdditionalComment
        {
            get { return _additionalComment; }
            set
            {
                SetProperty(ref _additionalComment, value);
            }
        }
    }


    public class PatientDetailsNotification : Confirmation
    {
        public long PatientId { get; set; }
        public ObservableCollection<PatientHistoryViewModel> PatientDetailsSource { get; set; }

    }





}
