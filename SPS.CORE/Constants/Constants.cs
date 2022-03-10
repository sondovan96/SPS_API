using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Core.Constants
{
    public static class Constants
    {
        public static class Configurations
        {
            public const string AutoMapperProfileAssembly = "SPS.Core";
        }
        public static class RequestHandling
        {
            public static class Messages
            {
                public const string InvalidRequest = "Invalid request. The request cannot be null.";
            }
        }
        public static class Messages
        {
            public const string LoginFail = "Login Fail";
        }
        public static class ApplicationSettings
        {
            public static class DefaultValues
            {
                public const int PageSize = 25;
            }
        }
        public static class HTTPClient
        {
            public const string BearerTokenHeader = "Bearer";
        }
        public static class User
        {
            public static class Email
            {
                public const string EmailconfirmationSubject = "[SP SHOP] Email confirmation";
                public const bool RequireEmailConfirmation = false;
            }
            public static class Role
            {
                public const string Customer = "Customer";
            }
        }
        
    }
}
