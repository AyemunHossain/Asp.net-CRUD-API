using Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace core.ModelValidations
{
    class Ticket_EnsureDueDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;
            if (ticket.ReportDate.HasValue && !ticket.DueDate.HasValue)
            {
                return new ValidationResult("Due Date is Required");
            }
            return ValidationResult.Success;
        }
    }
}
