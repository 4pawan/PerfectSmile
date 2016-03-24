using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;
using PerfectSmile.Common;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Repository.Implementation;
using PerfectSmile.Service;
using PerfectSmile.Views;
using Prism.Commands;

namespace PerfectSmile.ViewModels
{
    public class PatientBasicFormViewModel : BaseViewModel
    {
        private string name;

        [StringLength(5, ErrorMessage = "EmpFormViewModel_Name_Name_cant_be_more_than_5_char")]
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }



        public PatientBasicFormViewModel()
        {
            
        }


    }
}
