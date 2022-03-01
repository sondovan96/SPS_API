using FluentValidation;
using SPS.Core.RequestValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Accounts.Queries.Login
{
    public class LoginValidator : BaseRequestValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty()
                .WithMessage("Please enter your username!");
            RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Please enter your password!");
        }
    }
}
