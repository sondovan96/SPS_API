using MediatR;
using Microsoft.AspNetCore.Identity;
using SPS.Core.Constants;
using SPS.Core.Helper.EmailSender;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Accounts.Queries.EmailConfirmToken
{
    public class EmailConfirmTokenHandler : IRequestHandler<EmailConfirmTokenRequest>
    {
        private readonly UserManager<Account> _userManager;
        private readonly IEmailSenderService _emailSenderService;

        public EmailConfirmTokenHandler(UserManager<Account> userManager, IEmailSenderService emailSenderService)
        {
            _userManager = userManager;
            _emailSenderService = emailSenderService;
        }

        public async Task<Unit> Handle(EmailConfirmTokenRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            string callbackUrl = request.RedirectUrl +
                "?Email=" + user.Email +
                "&Token=" + token;
            string htmlBody = $"Please <a href=\"{callbackUrl}\">Click here</a> to confirm your email";
            await _emailSenderService.SendEmail(user.Email, Constants.User.Email.EmailconfirmationSubject, htmlBody);
            return Unit.Value;
        }
    }
}
