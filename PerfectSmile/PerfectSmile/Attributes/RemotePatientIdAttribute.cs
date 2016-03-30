using System;
using System.ComponentModel.DataAnnotations;
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

            using (var contxt = new PatientDbContext())
            {
                var a = contxt.Patients;
            }

            return true;
        }
    }
}
