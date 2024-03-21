using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors) Errors.Add(error.ErrorMessage);
        }

        public List<string> Errors { get; set; } = new();
    }
}