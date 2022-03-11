using FluentValidation;
using SPS.Core.RequestValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Orders.Commands.CreateOrder
{
    public class CreateOrderValidator: BaseRequestValidator<CreateOrderRequest>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.UserId).NotEmpty()
                .WithMessage("UserId cannot be empty!");
        }
    }
}
