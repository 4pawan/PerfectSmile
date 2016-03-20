using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectSmile.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {

        private string _name = "Test";
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }


        public MainWindowViewModel()
        {

        }
    }
}
