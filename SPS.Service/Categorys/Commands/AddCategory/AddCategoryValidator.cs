using FluentValidation;
using SPS.Core.RequestValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Categorys.Commands.AddCategory
{
    public class AddCategoryValidator : BaseRequestValidator<AddCategoryRequest>
    {
        public AddCategoryValidator()
        {
            RuleFor(x => x.Title).NotEmpty()
                .WithMessage("Please enter your username!"); 
        }
    }
}
