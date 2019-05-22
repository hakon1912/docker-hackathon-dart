using System.Linq;
using System.Net;
using Api.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string authKey = context.HttpContext.Request.Headers["Authorization"].SingleOrDefault();

            if (string.IsNullOrWhiteSpace(authKey))
                throw new HttpException(HttpStatusCode.Unauthorized);
        }
    }
}
