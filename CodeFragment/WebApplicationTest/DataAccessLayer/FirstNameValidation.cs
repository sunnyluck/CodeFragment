using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationTest.DataAccessLayer
{
    public class CustomValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("不允许为空");
            }
            else
            {
                if(value.ToString().Contains("@"))
                    return new ValidationResult("should contain @");
            }
            return ValidationResult.Success;
        }

        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
    }
}