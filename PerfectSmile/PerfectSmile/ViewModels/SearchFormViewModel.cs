using System;
using System.Windows;
using System.Windows.Input;
using PerfectSmile.Common;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Repository.Implementation;
using PerfectSmile.Service;
using PerfectSmile.Views;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace PerfectSmile.ViewModels
{
    public class SearchFormViewModel : BaseViewModel
    {

        private IPatientRepository _patientRepository;
        private ILog4NetLogger _log4NetLogger;


        //public SearchFormViewModel(IPatientRepository patientRepository, ILog4NetLogger log4NetLogger)
        //{
        //    _patientRepository = patientRepository;
        //    _log4NetLogger = log4NetLogger;
        //}

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

        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set
            {
                SetProperty(ref _remark, value);
            }
        }


        private DateTime? _lastVisitedOn;
        public DateTime? LastVisitedOn
        {
            get { return _lastVisitedOn; }
            set
            {
                SetProperty(ref _lastVisitedOn, value);
            }
        }


        private decimal _lastAmountPaid;
        public decimal LastAmountPaid
        {
            get { return _lastAmountPaid; }
            set
            {
                SetProperty(ref _lastAmountPaid, value);
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
