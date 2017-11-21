using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_HandsOn.Models
{
    public class Min18Yrs:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cust = (customer)validationContext.ObjectInstance;
            if (cust.MemberShipTypeId == MemberShipType.unknown || cust.MemberShipTypeId == MemberShipType.PayAsYouGo)
                return ValidationResult.Success;
            if (cust.dob == null)
                return new ValidationResult("Birthday is reqd");

            var age = DateTime.Today.Year - cust.dob.Value.Year;
            return (age > 18) ? ValidationResult.Success : new ValidationResult("age must be >18");
        }
    }
}