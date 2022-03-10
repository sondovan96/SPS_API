using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Core.Models.Account
{
    public class EmailOptions
    {
        public string Server { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
    public class YandexOption : EmailOptions
    {
        public const string Key = "YandexSmtpSettings";
    }
    public class GmailOption : EmailOptions
    {
        public const string Key = "GmailSmtpSettings";
    }
}
