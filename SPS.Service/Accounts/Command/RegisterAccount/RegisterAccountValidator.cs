using FluentValidation;
using SPS.Core.RequestValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Accounts.Command.RegisterAccount
{
    public class RegisterAccountValidator :BaseRequestValidator<RegisterAccountRequest>
    {
        [Obsolete]
        public RegisterAccountValidator()
        {
            RuleFor(x => x.Email).NotEmpty()
                .WithMessage("Please enter your Email!");
            RuleFor(x => x.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex)
                .WithMessage("'Email' is not a valid email address");
            RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Please enter your Password!");
            RuleFor(x => x.ConfirmPassword).NotEmpty()
                .WithMessage("Please enter your confirmation password!");
            RuleFor(x => x.ConfirmPassword).Equal(x=>x.Password)
                .WithMessage("Confirmation password must same your password!");
            RuleFor(x => x.FirstName).NotEmpty()
                .WithMessage("Please enter your First Name!");
            RuleFor(x => x.LastName).NotEmpty()
                .WithMessage("Please enter your Last Name!!");
        }
    }
}
