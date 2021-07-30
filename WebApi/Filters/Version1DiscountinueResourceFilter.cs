using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Filters
{
    public class Version1DiscountinueResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
          
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (!context.HttpContext.Request.Path.Value.ToLower().Contains("v2"))
            {
                context.Result = new BadRequestObjectResult(
                    new
                    {
                        Versioning = new[] { "This version of API has expired, please use the latest version" }
                    }
                    );
            }
            
        }
    }

}
