using System;
using System.ComponentModel.DataAnnotations;

namespace PerfectSmile.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DecimalOnlyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
                return true;

            decimal result;
            return decimal.TryParse(value.ToString(), out result) ;
        }
    }
}
