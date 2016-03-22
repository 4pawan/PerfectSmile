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


        public ShellViewModel()
        {

        }
    }
}
