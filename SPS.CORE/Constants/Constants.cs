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
        
    }
}
