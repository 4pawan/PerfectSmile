using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PerfectSmile.EF;


namespace PerfectSmile.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RemotePatientIdAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || (string)value == "")
                return true;

            long id = -1;
            long.TryParse(value.ToString(), out id);

            bool flag = false;
            using (var contxt = new PatientDbContext())
            {
                flag = contxt.Patients.Any(p => p.Id == id);
            }

            return flag;
        }
    }
}
