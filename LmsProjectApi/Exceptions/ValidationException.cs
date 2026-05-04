using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace LmsProjectApi.Exceptions
{
    public class ValidationException : BaseException
    {
        public Dictionary<string, string[]> Errors { get; }

        public ValidationException(Dictionary<string, string[]> errors)
            : base("One or more validation error occured.", StatusCodes.Status422UnprocessableEntity, "VALIDATION_ERROR")
        {
            Errors = errors;
        }

        public ValidationException(string propertyName, string errorMessage)
            : base("Validation error occurred.", StatusCodes.Status422UnprocessableEntity, "VALIDATION_ERROR")
        {
            Errors = new Dictionary<string, string[]>
            {
                { propertyName, [errorMessage] }
            };
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
        : base("Validation error occured.", StatusCodes.Status422UnprocessableEntity, "VALIDATION_ERROR")
        {
            Errors = failures
                .GroupBy(f => f.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(f=> f.ErrorMessage).ToArray()
                );
        }

    }
}
