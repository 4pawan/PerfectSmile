using PerfectSmile.EF;
using PerfectSmile.Repository.Abstract;
using Prism.Commands;
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

        public DelegateCommand NavigateToPatientListCommand { get; set; }
        public DelegateCommand NavigateToNextAppointmentCommand { get; set; }
        public DelegateCommand NavigateToPatientBasicFormCommand { get; set; }
        public DelegateCommand NavigateToPatientHistoryCommand { get; set; }

        public ShellViewModel(IRegionManager regionManager, ILoginRepository loginRepository)
        {
            _regionManager = regionManager;
            _loginRepository = loginRepository;

            var aa = loginRepository.IsUserValid("pk", "pk");

            NavigateToPatientListCommand = new DelegateCommand(NavigateToPatientList);
            NavigateToNextAppointmentCommand = new DelegateCommand(NavigateToNextAppointment);
            NavigateToPatientBasicFormCommand = new DelegateCommand(NavigateToPatientBasicForm);
            NavigateToPatientHistoryCommand = new DelegateCommand(NavigateToPatientHistory);

            IsPatientListSelected = true;
        }

        private void NavigateToPatientList()
        {
            _regionManager.RequestNavigate(Constant.Constant.Region.MainRegion, Constant.Constant.View.PatientList);

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
