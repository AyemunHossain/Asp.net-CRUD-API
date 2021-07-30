using Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.ModelValidations
{
    class Ticket_EnsureReportDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;
            if(ticket!=null && !string.IsNullOrWhiteSpace(ticket.Owner) && ticket.ReportDate.HasValue == false)
            {
                return new ValidationResult("Report Date is required when have an owner");
            }
            return ValidationResult.Success;
        }
    }
}
