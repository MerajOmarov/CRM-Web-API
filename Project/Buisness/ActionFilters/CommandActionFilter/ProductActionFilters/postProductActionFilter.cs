using Buisness.DTOs.Command.Customer;
using Buisness.DTOs.Command.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.ActionFilters.CommandActionFilter.ProductActionFilters
{
    public class postProductActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //var param = context.ActionArguments.SingleOrDefault(p => p.Value is productPostDTO);
            //if (param.Value == null)
            //{
            //    context.Result = new BadRequestObjectResult("Action Filter Error: Object is null");
            //    return;
            //}

            //if (!context.ModelState.IsValid)
            //{
            //    context.Result = new BadRequestObjectResult("Action Filter Error: DTO format is incorrect");
            //}
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // throw new NotImplementedException();
        }
    }
}
