using System;
using System.ComponentModel.DataAnnotations;

namespace PerfectSmile.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DisablePastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || (string)value == "")
                return true;

            DateTime dt;
            DateTime.TryParse(value.ToString(), out dt);
            return dt.Date >= DateTime.Now.Date;
        }
    }
}
