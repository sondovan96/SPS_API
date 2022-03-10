using MediatR;
using SPS.Core.Models.Account;
using SPS.Service.Accounts.JWTGeneration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPS.Service.Accounts.Queries.Login
{
    public class LoginRequest : IRequest<JWTGenerationRequest>
    {
        [Required]
        public string Email { set; get; }

        [Required]
        public string Password { set; get; }

        public string EmailConfirmationRedirectUrl { set; get; }
    }
}
