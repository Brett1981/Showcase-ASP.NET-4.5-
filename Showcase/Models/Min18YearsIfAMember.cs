using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
        
            
            if (customer.MembershipTypeId == MembershipType.UNKNOWN || customer.MembershipTypeId == MembershipType.PAYASYOUGO)
            {
                return ValidationResult.Success;
            }
            if(customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required.");
            }
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer must be at l8 years old for membership");
        }
    }
}