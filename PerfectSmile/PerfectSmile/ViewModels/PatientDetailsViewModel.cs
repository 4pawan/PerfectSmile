using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PerfectSmile.Events;
using PerfectSmile.Repository.Abstract;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;

namespace PerfectSmile.ViewModels
{
    public class PatientDetailsViewModel : BaseViewModel, IInteractionRequestAware
    {
        private IPatientRepository _patientRepository;
        private ILog4NetLogger _log4NetLogger;
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;


        public PatientDetailsViewModel(IPatientRepository patientRepository, IEventAggregator eventAggregator)
        {
            _patientRepository = patientRepository;
            _eventAggregator = eventAggregator;

            ConfirmDeleteRequestPatientHistoryInfo = new InteractionRequest<IConfirmation>();
            DeletePatientHistoryInfo = new DelegateCommand<PatientHistoryViewModel>(DeleteRequestPatientHistoryInfoEvent);

        }


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
        public ICommand DeletePatientHistoryInfo { get; set; }

        public InteractionRequest<IConfirmation> ConfirmDeleteRequestPatientHistoryInfo { get; private set; }

        private void DeleteRequestPatientHistoryInfoEvent(PatientHistoryViewModel obj)
        {
            Debug.WriteLine("-------->:DeletePatientHistoryInfo");
            this.ConfirmDeleteRequestPatientHistoryInfo.Raise(
               new Confirmation { Content = "Are you sure you want to delete this record for patient " + obj.Name + " ?", Title = "Confirmation" },
                c =>
                {
                    if (c.Confirmed)
                    {
                        bool isPatientHistroyDeleted = _patientRepository.DeletePatientHistoryForId(obj.PatientDetailsId);
                        _eventAggregator.GetEvent<RaiseNextAppointmentEvent>().Publish(isPatientHistroyDeleted && obj.NextAppointment != null);
                        //_eventAggregator.GetEvent<RaisePatientDetailsFinishedEvent>().Publish(isPatientHistroyDeleted);
                        FinishInteraction();
                    }
                });

        }


    }


    public class PatientHistoryViewModel : BaseViewModel
    {
        private long _patientDetailsId;
        public long PatientDetailsId
        {
            get { return _patientDetailsId; }
            set
            {
                SetProperty(ref _patientDetailsId, value);
            }
        }

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
