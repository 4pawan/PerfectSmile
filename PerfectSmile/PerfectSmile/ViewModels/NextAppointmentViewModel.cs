using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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

namespace PerfectSmile.ViewModels
{
    public class NextAppointmentViewModel : BaseViewModel
    {
        private IPatientRepository _patientRepository;
        private ILog4NetLogger _log4NetLogger;


        public NextAppointmentViewModel(IPatientRepository patientRepository, ILog4NetLogger log4NetLogger, IEventAggregator eventAggregator)
        {
            _patientRepository = patientRepository;
            _log4NetLogger = log4NetLogger;
            eventAggregator.GetEvent<RaiseNextAppointmentEvent>().Subscribe(RaiseNextAppointmentEvent);
            RaiseNextAppointmentEvent(true);
        }

        private void RaiseNextAppointmentEvent(bool obj = false)
        {
            if (obj)
            {
                NextAppointmentSource = _patientRepository.GetNextAppointmentSource();
            }
        }

        private ObservableCollection<NextAppointmentItemViewModel> _nextAppointmentSource;
        public ObservableCollection<NextAppointmentItemViewModel> NextAppointmentSource
        {
            get { return _nextAppointmentSource; }
            set
            {
                SetProperty(ref _nextAppointmentSource, value);
            }
        }

     
    }

    public class NextAppointmentItemViewModel : BaseViewModel
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

        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                SetProperty(ref _balance, value);
            }
        }
    }
}
