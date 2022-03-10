using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Core.Helper.EmailSender
{
    public interface IEmailSenderService
    {
        Task SendEmail(string userEmail, string subject, string htmlBody);
    }
}
