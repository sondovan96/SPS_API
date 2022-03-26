using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SPS.Core.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPS.API.Filters.Middleware
{
    public class ExceptionHandlerMiddleware:IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;

                response.ContentType = "application/json";

                var errors = new List<ErrorDetail>();
                while (ex != null)
                {
                    errors.Add(new ErrorDetail()
                    {
                        ErrorMessageId = ex.StackTrace,
                        ErrorMessage = ex.Message,
                    });
                    ex = ex.InnerException;
                }

                var result = new Response((System.Net.HttpStatusCode)500, null, errors);

                await context.Response.WriteAsync(JsonConvert.SerializeObject(result.Value));
            }
        }

    }
}
