using System.Windows.Input;
using PerfectSmile.EF;
using PerfectSmile.Repository.Abstract;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;

namespace PerfectSmile.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly ILoginRepository _loginRepository;

        private bool _isPatientListSelected;
        public bool IsPatientListSelected
        {
            get { return _isPatientListSelected; }
            set { SetProperty(ref _isPatientListSelected, value); }
        }

        private bool _isNextAppintmentSelected;
        public bool IsNextAppintmentSelected
        {
            get { return _isNextAppintmentSelected; }
            set { SetProperty(ref _isNextAppintmentSelected, value); }
        }

        private bool _isPatientBasicFormSelected;
        public bool IsPatientBasicFormSelected
        {
            get { return _isPatientBasicFormSelected; }
            set { SetProperty(ref _isPatientBasicFormSelected, value); }
        }

        private bool _isPatientHistoryFormSelected;
        public bool IsPatientHistoryFormSelected
        {
            get { return _isPatientHistoryFormSelected; }
            set { SetProperty(ref _isPatientHistoryFormSelected, value); }
        }

        private string resultMessage;
        public InteractionRequest<INotification> CustomPopupViewRequest { get; private set; }

        public string InteractionResultMessage
        {
            get
            {
                return this.resultMessage;
            }
            set
            {
                this.resultMessage = value;
                this.OnPropertyChanged("InteractionResultMessage");
            }
        }

        public DelegateCommand NavigateToPatientListCommand { get; set; }
        public DelegateCommand NavigateToNextAppointmentCommand { get; set; }
        public DelegateCommand NavigateToPatientBasicFormCommand { get; set; }
        public DelegateCommand NavigateToPatientHistoryCommand { get; set; }
        public ICommand RaiseCustomPopupViewCommand { get; private set; }


        public ShellViewModel(IRegionManager regionManager, ILoginRepository loginRepository)
        {
            _regionManager = regionManager;
            _loginRepository = loginRepository;

            CustomPopupViewRequest = new InteractionRequest<INotification>();
            //RaiseCustomPopupViewCommand = new DelegateCommand(this.RaiseCustomPopupView);
         
            var aa = loginRepository.IsUserValid("pk", "pk");

            NavigateToPatientListCommand = new DelegateCommand(NavigateToPatientList);
            NavigateToNextAppointmentCommand = new DelegateCommand(NavigateToNextAppointment);
            NavigateToPatientBasicFormCommand = new DelegateCommand(NavigateToPatientBasicForm);
            NavigateToPatientHistoryCommand = new DelegateCommand(NavigateToPatientHistory);
           
            IsPatientListSelected = true;

            RaiseCustomPopupView();
        }

        private void RaiseCustomPopupView()
        {
            InteractionResultMessage = "";
            CustomPopupViewRequest.Raise(
                new Notification { Content = "Message for the CustomPopupView", Title = "Custom Popup" });
        }


        private void NavigateToPatientList()
        {
            _regionManager.RequestNavigate(Constant.Constant.Region.MainRegion, Constant.Constant.View.PatientList);
            RaiseCustomPopupView();
            IsPatientListSelected = true;
            IsNextAppintmentSelected = false;
            IsPatientBasicFormSelected = false;
            IsPatientHistoryFormSelected = false;
        }

        private void NavigateToNextAppointment()
        {
            _regionManager.RequestNavigate(Constant.Constant.Region.MainRegion, Constant.Constant.View.NextAppointment);

            IsPatientListSelected = false;
            IsNextAppintmentSelected = true;
            IsPatientBasicFormSelected = false;
            IsPatientHistoryFormSelected = false;
        }
        private void NavigateToPatientBasicForm()
        {
            _regionManager.RequestNavigate(Constant.Constant.Region.MainRegion, Constant.Constant.View.PatientBasicForm);

            IsPatientListSelected = false;
            IsNextAppintmentSelected = false;
            IsPatientBasicFormSelected = true;
            IsPatientHistoryFormSelected = false;
        }
        private void NavigateToPatientHistory()
        {
            _regionManager.RequestNavigate(Constant.Constant.Region.MainRegion, Constant.Constant.View.PatientHistoryForm);

            IsPatientListSelected = false;
            IsNextAppintmentSelected = false;
            IsPatientBasicFormSelected = false;
            IsPatientHistoryFormSelected = true;
        }

    }
}
