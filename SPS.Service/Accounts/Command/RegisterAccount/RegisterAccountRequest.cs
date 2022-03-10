using MediatR;
using SPS.Service.Accounts.JWTGeneration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPS.Service.Accounts.Command.RegisterAccount
{
    public class RegisterAccountRequest:IRequest<JWTGenerationRequest>
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid RoleId { get; set; }
        public string About { get; set; }
        public string EmailConfirmationRedirectUrl { get; set; }

    }
}
