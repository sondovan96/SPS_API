using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SPS.Core.Helper
{
    public class ResponseValue:ResponseValue<object>
    {
    }

    public class ResponseValue<T>
    {
        public HttpStatusCode httpStatusCode { get; set; }
        public string MessageId { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public IList<ErrorDetail> errorDetails { get; set; }

    }

    public class ErrorDetail
    {
        public string ErrorMessageId { get; set; }
        public string ErrorMessage { get; set; }
        public string Key { get; set; }
        public object Value { get; set; }
        public IList<ErrorDetail> Errors { get; set;}
    }
}
