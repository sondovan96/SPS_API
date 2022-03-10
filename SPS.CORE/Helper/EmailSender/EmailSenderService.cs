using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using SPS.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace SPS.Core.Helper.EmailSender
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailOptions _emailSetting;

        public EmailSenderService(IOptions<GmailOption> emailSetting)
        {
            _emailSetting = emailSetting.Value;
        }

        public async Task SendEmail(string userEmail, string subject, string htmlBody)
        {
            MimeMessage mimeMessage = CreateMimeMessage(userEmail, subject, htmlBody);
            await Send(mimeMessage);
        }

        /// <summary>
        /// Create mime message for email
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="subject"></param>
        /// <param name="htmlBody"></param>
        /// <returns></returns>
        private MimeMessage CreateMimeMessage(string userEmail, string subject, string htmlBody)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailSetting.SenderName, _emailSetting.SenderEmail));
            message.To.Add(MailboxAddress.Parse(userEmail));
            message.Subject = subject;
            message.Body = new BodyBuilder
            {
                HtmlBody = htmlBody
            }.ToMessageBody();
            return message;
        }

        private async Task Send(MimeMessage mimeMessage)
        {
            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await smtpClient.ConnectAsync(_emailSetting.Server, _emailSetting.Port, true).ConfigureAwait(false);
                    await smtpClient.AuthenticateAsync(_emailSetting.SenderEmail, _emailSetting.Password).ConfigureAwait(false);
                    await smtpClient.SendAsync(mimeMessage).ConfigureAwait(false);
                    await smtpClient.DisconnectAsync(true).ConfigureAwait(false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
