using System;
using System.ComponentModel.DataAnnotations;

namespace PerfectSmile.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DisableFutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
                return true;

            DateTime dt;
            DateTime.TryParse(value.ToString(), out dt);
            return dt.Date <= DateTime.Now.Date;
        }
    }
}
