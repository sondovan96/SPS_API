using FluentValidation;
using SPS.Core.RequestValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Products.Commands.AddProduct
{
    public class AddProductValidator : BaseRequestValidator<AddProductRequest>
    {
        public AddProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty()
                .WithMessage("Please input product name!");

            RuleFor(x => x.Price).NotEmpty()
                .WithMessage("Please input price!");

            RuleFor(x => x.OriginalPrice).NotEmpty()
                .WithMessage("Please input original price!");
        }
    }
}
