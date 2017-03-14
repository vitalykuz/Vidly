/* This class is responsible for checking if a customer is older than 18 years. 
   This rule only applies if a MemebershipType is anything but Pay as You go, because
   it does not require 18 years old

   In order this thing to work, I need to add [Min18YearsIfAMember] annotation in Customer -> Birthdate
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            /* check the memebershipTypeId by using valudationContext. ObjectInstance gives access to the Model class,
             * in this case it's Customer. Because it is a class we need to cast
             */
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.PayAsYouGo || customer.MembershipTypeId == MembershipType.Unknown)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthday == null)
            {
                return new ValidationResult("Birthdate is required");
            }

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer must be at least 18 years old to go on a membership");
        }
    }
}