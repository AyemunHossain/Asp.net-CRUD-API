using Base.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApiCore.Filters
{
    public class Ticket_EnsureEnteredDate : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ticket = context.ActionArguments["ticket"] as Ticket;
            
            //Check if entered date is given or not
            if(ticket!=null && !string.IsNullOrWhiteSpace(ticket.Owner) && ticket.ReportDate.HasValue == false)
            {
                context.ModelState.AddModelError("EnteredDate", "EnteredDate is required when have a owner");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
