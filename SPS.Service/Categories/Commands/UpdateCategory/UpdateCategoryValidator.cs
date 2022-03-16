using FluentValidation;
using SPS.Core.RequestValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryValidator : BaseRequestValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                .WithMessage("Please enter your ID!");
        }
    }
}
