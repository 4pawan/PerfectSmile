using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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
    public class PatientBasicFormViewModel : BaseViewModel
    {

        private IPatientRepository _patientRepository;
        private ILog4NetLogger _log4NetLogger;
        public InteractionRequest<INotification> NotificationRequest { get; private set; }

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
            }
        }

        private string _phone;

        //[RegularExpression("((\\(\\d{3}\\)?)|(\\d{3}))([\\s-./]?)(\\d{3})([\\s-./]?)(\\d{4})",ErrorMessage ="Phone no is not valid")]
        public string Phone
        {
            get { return _phone; }
            set
            {
                ValidateProperty(value);
                SetProperty(ref _phone, value);
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
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand ClearCommand { get; set; }


        public PatientBasicFormViewModel(IPatientRepository patientRepository, ILog4NetLogger log4NetLogger)
        {
            _patientRepository = patientRepository;
            _log4NetLogger = log4NetLogger;
            NotificationRequest = new InteractionRequest<INotification>();
            SaveCommand = new DelegateCommand(() =>
            {

                var id = _patientRepository.AddPatientBasicInfo(this);
                _log4NetLogger.Info("Patient with name" + Name + " and Id " + id + "saved in db successfully.");
                //Debug.WriteLine("Patient with name" + Name + " and Id " + id + "saved in db successfully.");
                RaiseNotification();
            });

            ClearCommand = new DelegateCommand(ClearExec);

        }

        private void ClearExec()
        {
            Remark = Phone = Name = "";

        }

        private void RaiseNotification()
        {
            this.NotificationRequest.Raise(
               new Notification { Content = "Patient with name " + Name + " saved successfully.", Title = "Notification" },
               n => { });
        }



    }
}
