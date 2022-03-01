using FluentValidation;
using FluentValidation.Results;
using System;


namespace SPS.Core.RequestValidators
{
    public abstract class BaseRequestValidator<TRequest> : AbstractValidator<TRequest>
    {
        protected override bool PreValidate(ValidationContext<TRequest> context, ValidationResult result)
        {
            bool isContinueTheValidation = true;

            if(context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure(String.Empty, Constants.Constants.RequestHandling.Messages.InvalidRequest));
                isContinueTheValidation = false;
            }
            return isContinueTheValidation;
        }
    }
}
