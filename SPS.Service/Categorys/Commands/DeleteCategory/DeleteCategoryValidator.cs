using FluentValidation;
using SPS.Core.RequestValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Categorys.Commands.DeleteCategory
{
    public class DeleteCategoryValidator : BaseRequestValidator<DeleteCategoryRequest>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                .WithMessage("Please enter your ID!");
        }
    }
}
