using Prism.Commands;
using Prism.Regions;

namespace PerfectSmile.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {

        private string _name = "Test";
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; set; }

        public ShellViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string uri)
        {
            _regionManager.RequestNavigate("ContentRegion", uri);
        }


    }
}
