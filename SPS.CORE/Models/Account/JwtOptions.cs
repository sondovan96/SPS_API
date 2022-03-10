using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Core.Models.Account
{
    public class JwtOptions
    {
        public const string Key = "Jwt";
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public static IList<string> ValidAudiences { get; } = new List<string>();
    }
}
