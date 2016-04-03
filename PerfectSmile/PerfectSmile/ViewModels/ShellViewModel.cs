using System.Windows;
using System.Windows.Input;
using PerfectSmile.EF;
using PerfectSmile.Events;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;

namespace PerfectSmile.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly ILoginRepository _loginRepository;
        private IEventAggregator _eventAggregator;

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
        public InteractionRequest<LoginNotification> CustomPopupViewRequest { get; private set; }

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
        public ICommand RaiseCustomPopupViewOnWindowLoadCommand { get; private set; }
        public ICommand WindowLoaded { get; set; }

        public ShellViewModel(IRegionManager regionManager, ILoginRepository loginRepository, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _loginRepository = loginRepository;
            _eventAggregator = eventAggregator;

            CustomPopupViewRequest = new InteractionRequest<LoginNotification>();
            RaiseCustomPopupViewOnWindowLoadCommand = new DelegateCommand<Shell>(RaiseCustomPopupView);

            NavigateToPatientListCommand = new DelegateCommand(NavigateToPatientList);
            NavigateToNextAppointmentCommand = new DelegateCommand(NavigateToNextAppointment);
            NavigateToPatientBasicFormCommand = new DelegateCommand(NavigateToPatientBasicForm);
            NavigateToPatientHistoryCommand = new DelegateCommand(NavigateToPatientHistory);

            IsPatientListSelected = true;

            _eventAggregator.GetEvent<RaiseShellContextEvent>().Publish(this);
        }

        private void RaiseCustomPopupView(Shell model)
        {
            _eventAggregator.GetEvent<RaiseShellContextEvent>().Publish(this);

            model.Visibility = Visibility.Hidden;
            model.IsEnabled = false;

            LoginNotification notification = new LoginNotification { Title = Constant.Constant.Login.Title };

            InteractionResultMessage = "";
            CustomPopupViewRequest.Raise(notification, returned =>
            {
                if (returned != null && returned.Confirmed && returned.IsAuthenticatedUser)
                {
                    this.InteractionResultMessage = "The user is authenticated.";
                    model.Visibility = Visibility.Visible;
                    model.IsEnabled = true;
                }
                else
                {
                    this.InteractionResultMessage = "The user cancelled login window";
                    model.Close();
                }
            });
        }


        private void NavigateToPatientList()
        {
            IsPatientListSelected = true;
            IsNextAppintmentSelected = false;
            IsPatientBasicFormSelected = false;
            IsPatientHistoryFormSelected = false;

            _regionManager.RequestNavigate(Constant.Constant.Region.MainRegion, Constant.Constant.View.PatientList);
            _eventAggregator.GetEvent<RaiseShellContextEvent>().Publish(this);


        }

        private void NavigateToNextAppointment()
        {
            IsPatientListSelected = false;
            IsNextAppintmentSelected = true;
            IsPatientBasicFormSelected = false;
            IsPatientHistoryFormSelected = false;

            _regionManager.RequestNavigate(Constant.Constant.Region.MainRegion, Constant.Constant.View.NextAppointment);
        }
        private void NavigateToPatientBasicForm()
        {
            IsPatientListSelected = false;
            IsNextAppintmentSelected = false;
            IsPatientBasicFormSelected = true;
            IsPatientHistoryFormSelected = false;

            _regionManager.RequestNavigate(Constant.Constant.Region.MainRegion, Constant.Constant.View.PatientBasicForm);
        }
        private void NavigateToPatientHistory()
        {
            IsPatientListSelected = false;
            IsNextAppintmentSelected = false;
            IsPatientBasicFormSelected = false;
            IsPatientHistoryFormSelected = true;

            _regionManager.RequestNavigate(Constant.Constant.Region.MainRegion, Constant.Constant.View.PatientHistoryForm);
        }

    }
}
