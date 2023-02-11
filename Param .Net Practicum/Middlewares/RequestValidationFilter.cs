using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Param_.Net_Practicum.Core.Applicaiton.Dtos.ResponseDto;

namespace Param_.Net_Practicum.Middlewares
{
    public class RequestValidationFilter : IAsyncActionFilter
    {
        /// <summary>
        /// It puts the incoming request into the 
        // validation rules before it enters the controller, and if it is not verified, 
        /// it cancels and prints the errors on the screen.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(ErrorResponse.Fail(errors, 400));
                return;
            }
            await next();
        }
    }
}
