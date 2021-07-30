using Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.ModelValidations
{
    class Ticket_EnsureDueDateIsAfterReportDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;
            if (ticket.DueDate.HasValue && ticket.ReportDate.HasValue && ticket.DueDate.Value < ticket.ReportDate.Value)
                return new ValidationResult("Due date has to be after report date");
            return ValidationResult.Success;
        }
    }
}
