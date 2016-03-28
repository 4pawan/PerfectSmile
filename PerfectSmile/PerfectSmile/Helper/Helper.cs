using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.EF;
using PerfectSmile.ViewModels;

namespace PerfectSmile.Helper
{
    public class Helper
    {
        public static Patient ConvertToPatientModel(PatientBasicFormViewModel vm)
        {
            return new Patient
            {
                Name = vm.Name,
                Phone = vm.Phone,
                Remark = vm.Remark
              
            };
        }
    }
}
