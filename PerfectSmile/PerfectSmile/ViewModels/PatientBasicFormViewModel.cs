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
       
        [RegularExpression("((\\(\\d{3}\\)?)|(\\d{3}))([\\s-./]?)(\\d{3})([\\s-./]?)(\\d{4})",ErrorMessage ="Phone no is not valid")]
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

        public PatientBasicFormViewModel()
        {
            SaveCommand = new DelegateCommand(() =>
            {
                MessageBox.Show("Hello :)");
            });
        }


    }
}
