using FluentValidation;
using FluentValidation.Results;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalinhaCaipira.Domain.Validators
{
    public class ValidatorBase<T, TValidator> : Notifiable, IValidatorBase<T> where T : class where TValidator : AbstractValidator<T>, new()
    {
        public void Validate(T obj)
        {
            AbstractValidator<T> validator = new TValidator();

            ValidationResult results = validator.Validate(obj);

            if (!results.IsValid)
            {
                foreach (var result in results.Errors)
                {
                    AddNotification(result.PropertyName, result.ErrorMessage);
                }
            }
        }
    }
}
