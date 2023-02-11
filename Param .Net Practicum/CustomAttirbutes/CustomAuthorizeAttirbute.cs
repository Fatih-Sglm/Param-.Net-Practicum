using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Param_.Net_Practicum.Core.Applicaiton.Exceptions;
using Param_.Net_Practicum.Core.Applicaiton.Extensions;
using System;

namespace Param_.Net_Practicum.CustomAttirbutes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomAuthorizeAttirbute : Attribute, IAsyncActionFilter
    {
        /// <summary>
        /// Attribute that checks whether the incoming token is valid
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="AuthException"></exception>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var token = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "token").Value.ToString();
            if (token == null || token != TokenDto.Token || TokenDto.ExpireDate < DateTime.Now)
            {
                throw new AuthException("Please login to the page");
            }
            await next();
        }

    }
}
