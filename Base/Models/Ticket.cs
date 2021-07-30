using core.ModelValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Models
{
    public class Ticket
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public int? ProjectId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public string Owner { get; set; }

        [Ticket_EnsureReportDate]
        public DateTime? ReportDate { get; set; }

        [Ticket_EnsureDueDate]
        [Ticket_EnsureFutureDueDateOnCreationAttibute]
        [Ticket_EnsureDueDateIsAfterReportDate]

        public DateTime? DueDate { get; set; }

        public Project Projects { get; set; }
    }
}
