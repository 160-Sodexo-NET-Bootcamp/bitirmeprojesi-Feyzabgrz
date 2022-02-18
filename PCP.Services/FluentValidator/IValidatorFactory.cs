using System.Collections.Generic;
using FluentValidation;

namespace PCP.Services.FluentValidator
{
    public interface IValidatorFactory
    {
        List<AbstractValidator<T>> GetAllValidators<T>();
        AbstractValidator<T> GetDefaultValidator<T>();
    }
}