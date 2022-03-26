using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SPS.Core.Helper;
using System.Net;

namespace SPS.API.Filters
{
    public class ResponseActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            if (context.Result is ObjectResult)
            {
                ObjectResult response = context.Result as ObjectResult;
                context.Result = new Response((HttpStatusCode)response.StatusCode, response.Value);
            }
            else if(context.Result is StatusCodeResult)
            {
                StatusCodeResult response = context.Result as StatusCodeResult;
                if(response is UnauthorizedResult)
                {
                    context.Result = null;
                    context.HttpContext.Response.StatusCode = 401;
                }
                else
                {
                    context.Result = new Response((HttpStatusCode)response.StatusCode, default);
                }
            }
            
        }
    }
}
