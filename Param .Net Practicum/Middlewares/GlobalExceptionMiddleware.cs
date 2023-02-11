using Param_.Net_Practicum.Core.Applicaiton.Dtos.ResponseDto;
using Param_.Net_Practicum.Core.Applicaiton.Exceptions;
using System.Text.Json;

namespace Param_.Net_Practicum.Middlewares
{
    /// <summary>
    ///  The class where we check the errors from a single place
    /// </summary>
    public class GlobalExceptionMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // It checks for exception with try catch and redirects to handle function if any
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        /// <summary>
        /// If there is any error, 
        /// it will be sent along with the message and the httpsStatusCode specific to the error; 
        /// it return within the Error Response model
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = exception switch
            {
                AuthException => StatusCodes.Status401Unauthorized,
                ClientSideException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            var model = ErrorResponse.Fail(exception.Message, httpContext.Response.StatusCode);
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(model));
        }
    }
}
