using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SPS.Core.Helper
{
    public class Response : Response<object>, IResponse
    {
        public Response(HttpStatusCode httpStatusCode = HttpStatusCode.OK, object data = default,
            IList<ErrorDetail> errorDetails = default)
            : base(httpStatusCode, data, errorDetails)
        {

        }
    }

    public class Response<T> :ObjectResult, IResponse
    {
        public Response(HttpStatusCode httpStatusCode, object data = default,
            IList<ErrorDetail> errorDetails = default):base(null)
        {
            string messageId = "IdSuccess";
            string message = "Success";
            switch(httpStatusCode)
            {
                case HttpStatusCode.Created:
                    messageId = "MSG_CREATE_SUCCESS";
                    message = "Create success";
                    break;
                case HttpStatusCode.BadRequest:
                    messageId = "MSG_VALID_ERROR";
                    message = "Valid";
                    break;
                case HttpStatusCode.Unauthorized:
                    messageId = "MSG_AUTH_ERROR_01";
                    message = "Not Authorize";
                    break;
                case HttpStatusCode.Forbidden:
                    messageId = "MSG_AUTH_ERROR_02";
                    message = "Not Authorize";
                    break;
                case HttpStatusCode.NotFound:
                    messageId = "MSG_NF_ERROR";
                    message = "Not Found";
                    break;
                case HttpStatusCode.InternalServerError:
                    messageId = "MSG_SERVER_ERROR";
                    message = "Server Error";
                    break;
            }
            StatusCode = (int)httpStatusCode;
            Value = new ResponseValue
            {
                httpStatusCode = httpStatusCode,
                Message = message,
                MessageId = messageId,
                Data = data,
                errorDetails = errorDetails
            };
        }
    }
}
