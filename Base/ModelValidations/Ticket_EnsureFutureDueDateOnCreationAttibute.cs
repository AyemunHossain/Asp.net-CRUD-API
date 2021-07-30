using Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace core.ModelValidations
{
    class Ticket_EnsureFutureDueDateOnCreationAttibute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;
            if (ticket != null && ticket.Id == null)
            {
                if ( ticket.ReportDate.HasValue && ticket.DueDate.HasValue && ticket.DueDate.Value < DateTime.Now)
                {
                    return new ValidationResult("Due date has to be in future");
                }
            }
            return ValidationResult.Success;

        }
    }
}
