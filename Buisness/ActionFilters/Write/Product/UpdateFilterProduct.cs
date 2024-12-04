using Microsoft.AspNetCore.Mvc.Filters;

namespace Buisness.ActionFilters.CommandActionFilter.ProductActionFilters
{
    public class UpdateFilterProduct : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //var param = context.ActionArguments.SingleOrDefault(p => p.Value is productUpdateDTO);
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
            //throw new NotImplementedException();
        }
    }
}
